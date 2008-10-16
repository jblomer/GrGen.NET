/*
 * GrGen: graph rewrite generator tool -- release GrGen.NET 2.0
 * Copyright (C) 2008 Universitaet Karlsruhe, Institut fuer Programmstrukturen und Datenorganisation, LS Goos
 * licensed under GPL v3 (see LICENSE.txt included in the packaging of this file)
 */

/**
 * @author Sebastian Hack, Daniel Grund
 * @version $Id$
 */
package de.unika.ipd.grgen.ast;


import de.unika.ipd.grgen.ast.util.DeclarationTypeResolver;
import de.unika.ipd.grgen.ir.EvalStatement;
import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.ir.PatternGraph;
import de.unika.ipd.grgen.ir.Rule;
import java.util.Collection;
import java.util.HashSet;
import java.util.Set;
import java.util.Vector;


/**
 * AST node for a replacement rule.
 */
public class RuleDeclNode extends TestDeclNode {
	static {
		setName(RuleDeclNode.class, "rule declaration");
	}

	protected RhsDeclNode right;
	protected RuleTypeNode type;

	/** Type for this declaration. */
	private static final TypeNode ruleType = new RuleTypeNode();

	/**
	 * Make a new rule.
	 * @param id The identifier of this rule.
	 * @param left The left hand side (The pattern to match).
	 * @param right The right hand side.
	 * @param neg The context preventing the rule to match.
	 */
	public RuleDeclNode(IdentNode id, PatternGraphNode left, RhsDeclNode right,
			CollectNode<IdentNode> rets) {
		super(id, ruleType, left, rets);
		this.right = right;
		becomeParent(this.right);
	}

	/** returns children of this node */
	public Collection<BaseNode> getChildren() {
		Vector<BaseNode> children = new Vector<BaseNode>();
		children.add(ident);
		children.add(getValidVersion(typeUnresolved, type));
		children.add(returnFormalParameters);
		children.add(pattern);
		children.add(right);
		return children;
	}

	/** returns names of the children, same order as in getChildren */
	public Collection<String> getChildrenNames() {
		Vector<String> childrenNames = new Vector<String>();
		childrenNames.add("ident");
		childrenNames.add("type");
		childrenNames.add("ret");
		childrenNames.add("pattern");
		childrenNames.add("right");
		return childrenNames;
	}

	protected static final DeclarationTypeResolver<RuleTypeNode> typeResolver =	new DeclarationTypeResolver<RuleTypeNode>(RuleTypeNode.class);

	/** @see de.unika.ipd.grgen.ast.BaseNode#resolveLocal() */
	protected boolean resolveLocal() {
		type = typeResolver.resolve(typeUnresolved, this);

		return type != null;
	}

	protected Set<DeclNode> getDelete() {
		return right.getDelete(pattern);
	}

	/** Check that only graph elements are returned, that are not deleted. */
	protected boolean checkReturnedElemsNotDeleted(PatternGraphNode left, RhsDeclNode right) {
		assert isResolved();

		boolean res = true;
		Set<DeclNode> delete = right.getDelete(left);

		for (ExprNode expr : right.graph.returns.getChildren()) {
			if(!(expr instanceof DeclExprNode)) continue;
			ConstraintDeclNode retElem = ((DeclExprNode) expr).getConstraintDeclNode();
			if(retElem == null) continue;

			if (delete.contains(retElem)) {
				res = false;

				ident.reportError("The deleted " + retElem.getUseString()
						+ " \"" + retElem.ident + "\" must not be returned");
			}
		}
		return res;
	}


	/** Check that only graph elements are returned, that are not deleted. */
	protected boolean checkExecParamsNotDeleted(PatternGraphNode left, GraphNode right) {
		boolean res = true;
		Set<DeclNode> dels = getDelete();
		for (BaseNode x : right.imperativeStmts.getChildren()) {
			if(!(x instanceof ExecNode)) continue;

			ExecNode exec = (ExecNode) x;
			for(CallActionNode callAction : exec.callActions.getChildren()) {
				for(ExprNode arg : callAction.params.getChildren()) {
					if(!(arg instanceof DeclExprNode)) continue;

					ConstraintDeclNode declNode = ((DeclExprNode) arg).getConstraintDeclNode();
					if(declNode != null && dels.contains(declNode)) {
						callAction.reportError("The deleted " + declNode.getUseString()
								+ " \"" + declNode.ident + "\" must not be passed to an exec statement");
						res = false;
					}
				}
			}
		}
		return res;
	}

	/**
	 * Checks, whether the reused nodes and edges of the RHS are consistent with the LHS.
	 * If consistent, replace the dummy nodes with the nodes the pattern edge is
	 * incident to (if these aren't dummy nodes themselves, of course).
	 */
	protected boolean checkRhsReuse(PatternGraphNode left, RhsDeclNode right) {
		boolean res = true;
		Collection<EdgeDeclNode> alreadyReported = new HashSet<EdgeDeclNode>();
		for (ConnectionNode rConn : right.getReusedConnections(left)) {
			boolean occursInLHS = false;
			EdgeDeclNode re = rConn.getEdge();

			if (re instanceof EdgeTypeChangeNode) {
				re = ((EdgeTypeChangeNode)re).getOldEdge();
			}

			for (BaseNode lc : left.getConnections()) {
				if (!(lc instanceof ConnectionNode)) {
					continue;
				}

				ConnectionNode lConn = (ConnectionNode) lc;

				EdgeDeclNode le = lConn.getEdge();

				if ( ! le.equals(re) ) {
					continue;
				}
				occursInLHS = true;

				if (lConn.getConnectionKind() != rConn.getConnectionKind()) {
					res = false;
					rConn.reportError("Reused edge does not have the same connection kind");
					// if you don't add to alreadyReported erroneous errors can occur,
					// e.g. lhs=x-e->y, rhs=y-e-x
					alreadyReported.add(re);
				}

				NodeDeclNode lSrc = lConn.getSrc();
				NodeDeclNode lTgt = lConn.getTgt();
				NodeDeclNode rSrc = rConn.getSrc();
				NodeDeclNode rTgt = rConn.getTgt();

				HashSet<BaseNode> rhsNodes = new HashSet<BaseNode>();
				rhsNodes.addAll(right.getReusedNodes(left));

				if (rSrc instanceof NodeTypeChangeNode) {
					rSrc = ((NodeTypeChangeNode)rSrc).getOldNode();
					rhsNodes.add(rSrc);
				}
				if (rTgt instanceof NodeTypeChangeNode) {
					rTgt = ((NodeTypeChangeNode)rTgt).getOldNode();
					rhsNodes.add(rTgt);
				}

				if ( ! lSrc.isDummy() ) {
					if ( rSrc.isDummy() ) {
						if ( rhsNodes.contains(lSrc) ) {
							//replace the dummy src node by the src node of the pattern connection
							rConn.setSrc(lSrc);
						} else if ( ! alreadyReported.contains(re) ) {
							res = false;
							rConn.reportError("The source node of reused edge \"" + le + "\" must be reused, too");
							alreadyReported.add(re);
						}
					} else if (lSrc != rSrc && ! alreadyReported.contains(re)) {
						res = false;
						rConn.reportError("Reused edge \"" + le + "\" does not connect the same nodes");
						alreadyReported.add(re);
					}
				}

				if ( ! lTgt.isDummy() ) {
					if ( rTgt.isDummy() ) {
						if ( rhsNodes.contains(lTgt) ) {
							//replace the dummy tgt node by the tgt node of the pattern connection
							rConn.setTgt(lTgt);
						} else if ( ! alreadyReported.contains(re) ) {
							res = false;
							rConn.reportError("The target node of reused edge \"" + le + "\" must be reused, too");
							alreadyReported.add(re);
						}
					} else if ( lTgt != rTgt && ! alreadyReported.contains(re)) {
						res = false;
						rConn.reportError("Reused edge \"" + le + "\" does not connect the same nodes");
						alreadyReported.add(re);
					}
				}

				//check, whether RHS "adds" a node to a dangling end of a edge
				if ( ! alreadyReported.contains(re) ) {
					if ( lSrc.isDummy() && ! rSrc.isDummy() ) {
						res = false;
						rConn.reportError("Reused edge dangles on LHS, but has a source node on RHS");
						alreadyReported.add(re);
					}
					if ( lTgt.isDummy() && ! rTgt.isDummy() ) {
						res = false;
						rConn.reportError("Reused edge dangles on LHS, but has a target node on RHS");
						alreadyReported.add(re);
					}
				}
			}
			if (!occursInLHS) {
				// alreadyReported can not be set here
				if (rConn.getConnectionKind() == ConnectionNode.ARBITRARY) {
					res = false;
					rConn.reportError("New instances of ?--? are not allowed in RHS");
				}
				if (rConn.getConnectionKind() == ConnectionNode.ARBITRARY_DIRECTED) {
					res = false;
					rConn.reportError("New instances of <--> are not allowed in RHS");
				}
			}
		}
		return res;
	}

	/** Raises a warning if a "delete-return-conflict" for potentially
	 *  homomorphic nodes is detected or---more precisely---if a node is
	 *  returned such that homomorphic matching is allowed with a deleted node.
	 *
	 *  NOTE: The implementation of this method must be changed when
	 *        non-transitive homomorphism is invented.
	 * */
	private void warnHomDeleteReturnConflict() {
		assert isResolved();

		Collection<DeclNode> maybeDeleted = right.getMaybeDeleted(pattern);
		Collection<ExprNode> retSet = right.graph.returns.getChildren();

		// for all pairs of deleted and returned elems check whether
		// homomorphic matching is allowed
		HashSet<BaseNode> alreadyReported = new HashSet<BaseNode>();
		for(ExprNode expr : retSet) {
			if(!(expr instanceof DeclExprNode)) continue;
			ConstraintDeclNode retElem = ((DeclExprNode) expr).getConstraintDeclNode();
			if(retElem == null) continue;

			if(maybeDeleted.contains(retElem)) {
				retElem.maybeDeleted = true;
				if(!retElem.getIdentNode().getAnnotations().isFlagSet("maybeDeleted")) {
					alreadyReported.add(retElem);
					String warning = "Returning \"" + retElem.ident + "\" that may be deleted"
							+ ", possibly it's homomorphic with a deleted " + retElem.getUseString();
					if(retElem instanceof EdgeDeclNode) {
						warning += " or \"" + retElem.ident + "\" is a dangling " + retElem.getUseString()
								+ " and a deleted node exists";
					}
					retElem.reportWarning(warning);
				}
			}
		}
	}

	private void calcMaybeRetyped() {
		for(HomNode hom : pattern.getHoms()) {
			boolean containsRetypedElem = false;
			for(BaseNode e : hom.getChildren()) {
				ConstraintDeclNode elem = (ConstraintDeclNode) e;
				if(elem.getRetypedElement() != null) {
					containsRetypedElem = true;
					break;
				}
			}

			// If there was one homomorphic element, which is retyped,
			// all non-retyped elements in the same hom group are marked
			// as maybeRetyped.
			if(containsRetypedElem) {
				for(BaseNode e : hom.getChildren()) {
					ConstraintDeclNode elem = (ConstraintDeclNode) e;
					if(elem.getRetypedElement() == null)
						elem.maybeRetyped = true;
				}
			}
		}
	}

	/**
	 * Check, if the rule type node is right.
	 * The children of a rule type are
	 * 1) a pattern for the left side.
	 * 2) a pattern for the right side.
	 * @see de.unika.ipd.grgen.ast.BaseNode#checkLocal()
	 */
	protected boolean checkLocal() {
		right.warnElemAppearsInsideAndOutsideDelete(pattern);

		boolean leftHandGraphsOk = super.checkLocal();

		PatternGraphNode left = pattern;
		GraphNode right = this.right.graph;

		// check if the pattern name equals the rule name
		// named replace/modify parts are only allowed in subpatterns
		String ruleName = ident.toString();
		if (!right.nameOfGraph.equals(ruleName)) {
			error.error(this.right.getCoords(), "Named replace/modify parts in rules are not allowed");
		}

		// check if parameters only exists for subpatterns
		if (right.params.getChildren().size() > 0) {
			error.error(this.right.getCoords(), "Parameters for the replace/modify part are only allowed in subpatterns");
		}

		boolean noReturnInPatternOk = true;
		if(pattern.returns.children.size() > 0) {
			error.error(getCoords(), "No return statements in pattern parts of rules allowed");
			noReturnInPatternOk = false;
		}

		calcMaybeRetyped();

		warnHomDeleteReturnConflict();

		boolean abstr = true;
		for(BaseNode n : right.getNodes()) {
			NodeDeclNode node = (NodeDeclNode)n;
			if(!node.hasTypeof() && node.getDeclType().isAbstract() && !left.getNodes().contains(node)) {
				error.error(node.getCoords(), "Instances of abstract nodes are not allowed");
				abstr = false;
			}
		}
		for(BaseNode e : right.getEdges()) {
			EdgeDeclNode edge = (EdgeDeclNode) e;
			if(!edge.hasTypeof() && edge.getDeclType().isAbstract() && !left.getEdges().contains(edge)) {
				error.error(edge.getCoords(), "Instances of abstract edges are not allowed");
				abstr = false;
			}
		}

		return leftHandGraphsOk
			& checkRhsReuse(left, this.right) & noReturnInPatternOk & abstr
			& checkReturnedElemsNotDeleted(left, this.right)
			& checkExecParamsNotDeleted(left, right)
			& checkReturns(right.returns);
	}

	/**
	 * @see de.unika.ipd.grgen.ast.BaseNode#constructIR()
	 */
	protected IR constructIR() {
		PatternGraph left = pattern.getPatternGraph();

		// return if the pattern graph already constructed the IR object
		// that may happens in recursive patterns
		if (isIRAlreadySet()) {
			return getIR();
		}

		PatternGraph right = this.right.getPatternGraph(left);

		// return if the pattern graph already constructed the IR object
		// that may happens in recursive patterns
		if (isIRAlreadySet()) {
			return getIR();
		}

		Rule rule = new Rule(getIdentNode().getIdent(), left, right);

		constructImplicitNegs(left);
		constructIRaux(rule, this.right.graph.returns);

		// add eval statements to the IR
		for (EvalStatement n : this.right.getEvalStatements()) {
			rule.addEval(n);
		}

		return rule;
	}

	@Override
	public RuleTypeNode getDeclType() {
		assert isResolved();

		return type;
	}
}

