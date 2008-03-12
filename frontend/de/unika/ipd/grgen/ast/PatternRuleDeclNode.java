/*
 GrGen: graph rewrite generator tool.
 Copyright (C) 2005  IPD Goos, Universit"at Karlsruhe, Germany

 This library is free software; you can redistribute it and/or
 modify it under the terms of the GNU Lesser General Public
 License as published by the Free Software Foundation; either
 version 2.1 of the License, or (at your option) any later version.

 This library is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 Lesser General Public License for more details.

 You should have received a copy of the GNU Lesser General Public
 License along with this library; if not, write to the Free Software
 Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
 */


/**
 * @author Sebastian Hack, Daniel Grund
 * @version $Id$
 */
package de.unika.ipd.grgen.ast;


import java.util.Collection;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;
import java.util.Vector;

import de.unika.ipd.grgen.ast.util.DeclarationTypeResolver;
import de.unika.ipd.grgen.ir.Assignment;
import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.ir.PatternGraph;
import de.unika.ipd.grgen.ir.Rule;


/**
 * AST node for a pattern with replacements.
 */
public class PatternRuleDeclNode extends PatternTestDeclNode {
	static {
		setName(PatternRuleDeclNode.class, "pattern rule declaration");
	}

	protected RhsDeclNode right;
	protected PatternRuleTypeNode type;

	/** Type for this declaration. */
	private static final TypeNode patternType = new PatternRuleTypeNode();

	/**
	 * Make a new rule.
	 * @param id The identifier of this rule.
	 * @param left The left hand side (The pattern to match).
	 * @param right The right hand side.
	 * @param neg The context preventing the rule to match.
	 */
	public PatternRuleDeclNode(IdentNode id, PatternGraphNode left, RhsDeclNode right) {
		super(id, patternType, left);
		this.right = right;
		becomeParent(this.right);
	}

	/** returns children of this node */
	public Collection<BaseNode> getChildren() {
		Vector<BaseNode> children = new Vector<BaseNode>();
		children.add(ident);
		children.add(getValidVersion(typeUnresolved, type));
		children.add(pattern);
		children.add(right);
		return children;
	}

	/** returns names of the children, same order as in getChildren */
	public Collection<String> getChildrenNames() {
		Vector<String> childrenNames = new Vector<String>();
		childrenNames.add("ident");
		childrenNames.add("type");
		childrenNames.add("pattern");
		childrenNames.add("right");
		return childrenNames;
	}

	protected static final DeclarationTypeResolver<PatternRuleTypeNode> typeResolver =	new DeclarationTypeResolver<PatternRuleTypeNode>(PatternRuleTypeNode.class);

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

		for (ConstraintDeclNode retElem : right.graph.returns.getChildren()) {
			Set<DeclNode> delete = right.getDelete(left);

			if (delete.contains(retElem)) {
				res = false;

				ident.reportError("The deleted " + retElem.getUseString() +
									  " \"" + retElem.ident + "\" must not be returned");
			}
		}
		return res;
	}


	/** Check that only graph elements are returned, that are not deleted. */
	protected boolean checkExecParamsNotDeleted(PatternGraphNode left, GraphNode right) {
		boolean res = true;
		Set<DeclNode> dels = getDelete();
		for (BaseNode x : right.imperativeStmts.getChildren()) {
			if(x instanceof ExecNode) {
				ExecNode exec = (ExecNode)x;
				for(CallActionNode callAction : exec.callActions.getChildren())
					if(!Collections.disjoint(callAction.params.getChildren(), dels)) {
						// FIXME error message
						callAction.reportError("Parameter of call \"" + callAction.getName() + "\"");
						// TODO ...
						res = false;
					}


			}
		}
		return res;
	}

	/* Checks, whether the reused nodes and edges of the RHS are consistent with the LHS.
	 * If consistent, replace the dummy nodes with the nodes the pattern edge is
	 * incident to (if these aren't dummy nodes themselves, of course). */
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

				Collection<BaseNode> rhsNodes = right.getReusedNodes(left);

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

		// No warnings for DPO
		if (pattern.isDPO()) {
			return;
		}

		Set<DeclNode> delSet = getDelete();
		Collection<ConstraintDeclNode> retSet = right.graph.returns.getChildren();

		Map<DeclNode, Set<BaseNode>> elemToHomElems = new HashMap<DeclNode, Set<BaseNode>>();

		// represent homomorphism cliques and map each elem to the clique
		// it belong to
		for (HomNode hn : pattern.getHoms()) {
			Set<BaseNode> homSet;
			for (BaseNode y : hn.getChildren()) {
				DeclNode elem = (DeclNode) y;

				homSet = elemToHomElems.get(elem);
				if (homSet == null) {
					homSet = new HashSet<BaseNode>();
					elemToHomElems.put(elem, homSet);
				}
				homSet.addAll(hn.getChildren());
			}
		}

		// for all pairs of deleted and returned elems check whether
		// homomorphic matching is allowed
		HashSet<BaseNode> alreadyReported = new HashSet<BaseNode>();
		for (DeclNode d : delSet) {
			for (ConstraintDeclNode r : retSet) {
				if ( alreadyReported.contains(r) ) {
					continue;
				}

				Set<BaseNode> homSet = elemToHomElems.get(d);
				if (homSet == null) {
					continue;
				}

				if (homSet.contains(r)) {
					r.maybeDeleted = true;
					if(!r.getIdentNode().getAnnotations().isFlagSet("mayBeDeleted")) {
						alreadyReported.add(r);
						r.reportWarning("returning \"" + r.ident + "\" that may be " +
								"matched homomorphically with deleted \"" + d.ident + "\"");
					}
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

		// check if parameters of patterns are deleted
		boolean noDeleteOfPatternParameters = true;
		Collection<DeclNode> deletedEnities = getDelete();
		for (DeclNode p : pattern.getParamDecls()) {
			if (deletedEnities.contains(p)) {
				error.error(getCoords(), "Deletion of parameters in patterns are not allowed");
				noDeleteOfPatternParameters = false;
			}
        }

		boolean noReturnInPatternOk = true;
		if(pattern.returns.children.size() > 0) {
			error.error(getCoords(), "No return statements in pattern parts of rules allowed");
			noReturnInPatternOk = false;
		}

		warnHomDeleteReturnConflict();

		boolean abstr = true;
		for(BaseNode n : right.getNodes()) {
			NodeDeclNode node = (NodeDeclNode)n;
			if(!node.hasTypeof() && ((InheritanceTypeNode)node.getDeclType()).isAbstract() && !left.getNodes().contains(node)) {
				error.error(node.getCoords(), "Instances of abstract nodes are not allowed");
				abstr = false;
			}
		}
		for(BaseNode e : right.getEdges()) {
			EdgeDeclNode edge = (EdgeDeclNode) e;
			if(!edge.hasTypeof() && ((InheritanceTypeNode)edge.getDeclType()).isAbstract() && !left.getEdges().contains(edge)) {
				error.error(edge.getCoords(), "Instances of abstract edges are not allowed");
				abstr = false;
			}
		}

		return leftHandGraphsOk & noDeleteOfPatternParameters
			& checkRhsReuse(left, this.right) & noReturnInPatternOk & abstr
			& checkReturnedElemsNotDeleted(left, this.right)
			& checkExecParamsNotDeleted(left, right);
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
		constructIRaux(rule);

		// add Eval statements to the IR
		for (Assignment n : this.right.getAssignments()) {
			rule.addEval(n);
		}

		return rule;
	}

	/**
	 * add NACs for induced- or DPO-semantic
	 */
	protected void constructImplicitNegs(PatternGraph left) {
		PatternGraphNode leftNode = pattern;
		for (PatternGraph neg : leftNode.getImplicitNegGraphs()) {
			left.addNegGraph(neg);
		}
	}

	@Override
		public PatternRuleTypeNode getDeclType() {
		assert isResolved();

		return type;
	}

	public static String getKindStr() {
		return "pattern rule declaration";
	}
}
