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

import de.unika.ipd.grgen.ast.util.Checker;
import de.unika.ipd.grgen.ast.util.CollectChecker;
import de.unika.ipd.grgen.ast.util.SimpleChecker;
import de.unika.ipd.grgen.ir.Assignment;
import de.unika.ipd.grgen.ir.Graph;
import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.ir.PatternGraph;
import de.unika.ipd.grgen.ir.Rule;
import java.util.Collection;
import java.util.Vector;
import java.util.Set;
import java.util.Map;
import java.util.HashSet;
import java.util.HashMap;
import java.util.LinkedHashSet;


/**
 * AST node for a replacement rule.
 */
public class RuleDeclNode extends TestDeclNode
{
	static {
		setName(RuleDeclNode.class, "rule declaration");
	}

	BaseNode right;
	BaseNode eval;

	/** Type for this declaration. */
	private static final TypeNode ruleType = new RuleTypeNode();

	/**
	 * Make a new rule.
	 * @param id The identifier of this rule.
	 * @param left The left hand side (The pattern to match).
	 * @param right The right hand side.
	 * @param neg The context preventing the rule to match.
	 * @param eval The evaluations.
	 */
	public RuleDeclNode(IdentNode id, PatternGraphNode left, GraphNode right, CollectNode neg,
				CollectNode eval, CollectNode params, CollectNode rets) {
		super(id, ruleType, left, neg, params, rets);
		this.right = right==null ? NULL : right;
		becomeParent(this.right);
		this.eval = eval==null ? NULL : eval;
		becomeParent(this.eval);
	}

	/** returns children of this node */
	public Collection<BaseNode> getChildren() {
		Vector<BaseNode> children = new Vector<BaseNode>();
		children.add(ident);
		children.add(type);
		children.add(param);
		children.add(ret);
		children.add(pattern);
		children.add(neg);
		children.add(right);
		children.add(eval);
		return children;
	}
	
	/** returns names of the children, same order as in getChildren */
	public Collection<String> getChildrenNames() {
		Vector<String> childrenNames = new Vector<String>();
		childrenNames.add("ident"); 
		childrenNames.add("type");
		childrenNames.add("param");
		childrenNames.add("ret");
		childrenNames.add("pattern");
		childrenNames.add("neg");
		childrenNames.add("right");
		childrenNames.add("eval");
		return childrenNames;
	}
	
	/** @see de.unika.ipd.grgen.ast.BaseNode#resolve() */
	protected boolean resolve() {
		if(isResolved()) {
			return resolutionResult();
		}
		
		debug.report(NOTE, "resolve in: " + getId() + "(" + getClass() + ")");
		boolean successfullyResolved = true;
		nodeResolvedSetResult(successfullyResolved); // local result
		
		successfullyResolved = ident.resolve() && successfullyResolved;
		successfullyResolved = type.resolve() && successfullyResolved;
		successfullyResolved = param.resolve() && successfullyResolved;
		successfullyResolved = ret.resolve() && successfullyResolved;
		successfullyResolved = pattern.resolve() && successfullyResolved;
		successfullyResolved = neg.resolve() && successfullyResolved;
		successfullyResolved = right.resolve() && successfullyResolved;
		successfullyResolved = eval.resolve() && successfullyResolved;
		return successfullyResolved;
	}
	
	/** @see de.unika.ipd.grgen.ast.BaseNode#check() */
	protected boolean check() {
		if(!resolutionResult()) {
			return false;
		}
		if(isChecked()) {
			return getChecked();
		}
		
		boolean successfullyChecked = checkLocal();
		nodeCheckedSetResult(successfullyChecked);
		
		successfullyChecked = ident.check() && successfullyChecked;
		successfullyChecked = type.check() && successfullyChecked;
		successfullyChecked = param.check() && successfullyChecked;
		successfullyChecked = ret.check() && successfullyChecked;
		successfullyChecked = pattern.check() && successfullyChecked;
		successfullyChecked = neg.check() && successfullyChecked;
		successfullyChecked = right.check() && successfullyChecked;
		successfullyChecked = eval.check() && successfullyChecked;
		return successfullyChecked;
	}

	protected Collection<GraphNode> getGraphs() {
		Collection<GraphNode> res = super.getGraphs();
		res.add((GraphNode) right);
		return res;
	}

	protected Set<DeclNode> getDelete()
	{
		Set<DeclNode> res = new LinkedHashSet<DeclNode>();

		GraphNode lhs = (GraphNode) pattern;
		GraphNode rhs = (GraphNode) right;

		for (BaseNode x : lhs.getEdges()) {
			assert (x instanceof DeclNode);
			if ( ! rhs.getEdges().contains(x) ) {
				res.add((DeclNode)x);
			}
		}
		for (BaseNode x : lhs.getNodes()) {
			assert (x instanceof DeclNode);
			if ( ! rhs.getNodes().contains(x) ) {
				res.add((DeclNode)x);
			}
		}
		for (BaseNode x : param.getChildren()) {
			assert (x instanceof DeclNode);
			if ( !( rhs.getNodes().contains(x) || rhs.getEdges().contains(x)) ) {
				res.add((DeclNode)x);
			}
		}

		return res;
	}

	/** Check that only graph elements are returned, that are not deleted. */
	protected boolean checkReturnedElemsNotDeleted(PatternGraphNode left, GraphNode right)
	{
		boolean res = true;
		CollectNode returns = (CollectNode) right.getReturn();
		for (BaseNode x : returns.getChildren()) {
			IdentNode ident = (IdentNode) x;
			DeclNode retElem = ident.getDecl();
			DeclNode oldElem = retElem;

			// get original elem if return elem is a retyped one
			if (retElem instanceof NodeTypeChangeNode) {
				oldElem = (NodeDeclNode) ((NodeTypeChangeNode)retElem).getOldNode();
			} else if (retElem instanceof EdgeTypeChangeNode) {
				oldElem = (EdgeDeclNode) ((EdgeTypeChangeNode)retElem).getOldEdge();
			}
			
			// rhsElems contains all elems of the RHS except for the old nodes
			// and edges (in case of retyping)
			Collection<BaseNode> rhsElems = right.getNodes();
			rhsElems.addAll(right.getEdges());

			// nodeOrEdge is used in error messages
			String nodeOrEdge = "";
			if (retElem instanceof NodeDeclNode) {
				nodeOrEdge = "node";
			} else if (retElem instanceof EdgeDeclNode) {
				nodeOrEdge = "edge";
			} else {
				nodeOrEdge = "entity";
			}

			//TODO:	The job of the following should be done by a resolver resolving
			//		the childs of the return node from identifiers to instances of
			//		NodeDeclNode or EdgeDevleNode respectively.
			if ( ! ((retElem instanceof NodeDeclNode) || (retElem instanceof EdgeDeclNode))) {
				res = false;
				ident.reportError("The element \"" + ident + "\" is neither a node nor an edge");
			}

			if ( ! rhsElems.contains(retElem) ) {
				res = false;

				//TODO:	The job of the following should be done by a resolver resolving
				//		the childs of the return nore from identifiers to instances of
				//		NodeDeclNode or EdgeDevleNode respectively.
				if ( ! (left.getNodes().contains(oldElem)
						|| left.getEdges().contains(oldElem)
						|| param.getChildren().contains(retElem)))
				{
					ident.reportError(
						"\"" + ident + "\", that is neither a parameter, " +
						"nor contained in LHS, nor in RHS, occurs in a return");

					continue;
				}

				ident.reportError("The deleted " + nodeOrEdge +
						" \"" + ident + "\" must not be returned");
			}
		}
		return res;
	}

	/** Check whether the returned elements are valid and
	 *  whether the number of returned elements is right. */
	protected boolean checkRetSignatureAdhered(PatternGraphNode left, GraphNode right)
	{
		boolean res = true;

		Vector<BaseNode> retSignature =	(Vector<BaseNode>) ret.getChildren();
		CollectNode returns = (CollectNode) right.getReturn();

		int declaredNumRets = retSignature.size();
		int actualNumRets = returns.getChildren().size();

		for (int i = 0; i < Math.min(declaredNumRets, actualNumRets); i++) {
			IdentNode ident = (IdentNode) ((Vector<BaseNode>)returns.getChildren()).get(i);
			DeclNode retElem = ident.getDecl();

			if (retElem.equals(DeclNode.getInvalid())) {
				res = false;
				ident.reportError("\"" + ident + "\" is undeclared");
				continue;
			}

			if ( !(retElem instanceof NodeDeclNode) && !(retElem instanceof EdgeDeclNode)) {
				res = false;
				ident.reportError("\"" + ident + "\" is neither a node nor an edge");
				continue;
			}

			if ( ((IdentNode) retSignature.get(i)).getDecl().equals(DeclNode.getInvalid()) ) {
				res = false;
				//this should have been reported elsewhere
				continue;
			}

			IdentNode retIdent = (IdentNode) retSignature.get(i);
			BaseNode retDeclType = retIdent.getDecl().getDeclType();
			if(!(retDeclType instanceof InheritanceTypeNode)) {
				res = false;
				retIdent.reportError("\"" + retIdent + "\" is neither a node nor an edge type");
				continue;
			}

			InheritanceTypeNode declaredRetType = (InheritanceTypeNode)	retDeclType;
			InheritanceTypeNode actualRetType =	(InheritanceTypeNode) retElem.getDeclType();

			if ( ! actualRetType.isA(declaredRetType) ) {
				res = false;
				ident.reportError("Return parameter \"" + ident + "\" has wrong type");
				continue;
			}
		}

		//check the number of returned elements
		if (actualNumRets != declaredNumRets) {
			res = false;
			if (declaredNumRets == 0) {
				returns.reportError("No return values declared for rule \"" + ident + "\"");
			} else if(actualNumRets == 0) {
				reportError("Missing return statement for rule \"" + ident + "\"");
			} else {
				returns.reportError("Return statement has wrong number of parameters");
			}
		}
		return res;
	}

	/* Checks, whether the reused nodes and edges of the RHS are consistent with the LHS.
	 * If consistent, replace the dummy nodes with the nodes the pattern edge is
	 * incident to (if these aren't dummy nodes themselves, of course). */
	protected boolean checkRhsReuse(PatternGraphNode left, GraphNode right)
	{
		boolean res = true;
		Collection<EdgeDeclNode> alreadyReported = new HashSet<EdgeDeclNode>();
		for (BaseNode lc : left.getConnections()) {
			for (BaseNode rc : right.getConnections()) {
				if (lc instanceof SingleNodeConnNode ||	rc instanceof SingleNodeConnNode ) {
					continue;
				}

				ConnectionNode lConn = (ConnectionNode) lc;
				ConnectionNode rConn = (ConnectionNode) rc;

				EdgeDeclNode le = (EdgeDeclNode) lConn.getEdge();
				EdgeDeclNode re = (EdgeDeclNode) rConn.getEdge();

				if (re instanceof EdgeTypeChangeNode) {
					re = (EdgeDeclNode) ((EdgeTypeChangeNode)re).getOldEdge();
				}

				if ( ! le.equals(re) ) {
					continue;
				}

				NodeDeclNode lSrc = (NodeDeclNode) lConn.getSrc();
				NodeDeclNode lTgt = (NodeDeclNode) lConn.getTgt();
				NodeDeclNode rSrc = (NodeDeclNode) rConn.getSrc();
				NodeDeclNode rTgt = (NodeDeclNode) rConn.getTgt();

				Collection<BaseNode> rhsNodes = right.getNodes();

				if (rSrc instanceof NodeTypeChangeNode) {
					rSrc = (NodeDeclNode) ((NodeTypeChangeNode)rSrc).getOldNode();
					rhsNodes.add(rSrc);
				}
				if (rTgt instanceof NodeTypeChangeNode) {
					rTgt = (NodeDeclNode) ((NodeTypeChangeNode)rTgt).getOldNode();
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
					} else if (lSrc != rSrc) {
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
					} else if ( lTgt != rTgt ) {
						res = false;
						rConn.reportError("Reused edge \"" + le + "\" does not connect the same nodes");
						alreadyReported.add(re);
					}
				}

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
	private void warnHomDeleteReturnConflict()
	{
		Set<DeclNode> delSet = getDelete();
		Set<IdentNode> retSet = new HashSet<IdentNode>();

		Collection<BaseNode> rets = ((CollectNode) ((GraphNode) right).getReturn()).getChildren();

		for (BaseNode x : rets) {
			retSet.add(((IdentNode)x));
		}

		Map<DeclNode, Set<BaseNode>> elemToHomElems = new HashMap<DeclNode, Set<BaseNode>>();

		// represent homomorphism cliques and map each elem to the clique
		// it belong to
		for (BaseNode x : ((PatternGraphNode)pattern).getHoms()) {
			HomNode hn = (HomNode) x;

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
			for (IdentNode r : retSet) {
				if ( alreadyReported.contains(r) ) {
					continue;
				}

				Set<BaseNode> homSet = elemToHomElems.get(d);
				if (homSet == null) {
					continue;
				}

				if (homSet.contains(r.getDecl())) {
					alreadyReported.add(r);
					r.reportWarning("returning \"" + r + "\" that may be " +
							"matched homomorphically with deleted \"" + d + "\"");
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
		Checker evalChecker = new CollectChecker(new SimpleChecker(AssignNode.class));
		boolean leftHandGraphsOk = super.checkLocal()
			&& (new SimpleChecker(GraphNode.class)).check(this.right, error)
			&& evalChecker.check(this.eval, error);

		PatternGraphNode left = (PatternGraphNode) pattern;
		GraphNode right = (GraphNode) this.right;

		boolean noReturnInPatternOk = true;
		CollectNode returns = (CollectNode) ((GraphNode) pattern).getReturn();
		if(returns.children.size() > 0) {
			error.error(getCoords(), "No return statements in pattern parts of rules allowed");
			noReturnInPatternOk = false;
		}

		warnHomDeleteReturnConflict();

		return leftHandGraphsOk & checkRhsReuse(left, right) & noReturnInPatternOk
			& checkReturnedElemsNotDeleted(left, right)
			& checkRetSignatureAdhered(left, right);
	}

	/**
	 * @see de.unika.ipd.grgen.ast.BaseNode#constructIR()
	 */
	protected IR constructIR() {
		PatternGraph left = ((PatternGraphNode) pattern).getPatternGraph();
		Graph right = ((GraphNode) this.right).getGraph();

		Rule rule = new Rule(getIdentNode().getIdent(), left, right);

		constructImplicitNegs(rule);
		constructIRaux(rule, ((GraphNode) this.right).getReturn());

		// add Eval statements to the IR
		for (BaseNode n : eval.getChildren()) {
			AssignNode eval = (AssignNode) n;
			rule.addEval((Assignment) eval.checkIR(Assignment.class));
		}

		return rule;
	}

	/**
	 * add NACs for induced- or DPO-semantic
	 */
	protected void constructImplicitNegs(Rule rule) {
		PatternGraphNode leftNode = (PatternGraphNode) pattern;
		for (PatternGraph neg : leftNode.getImplicitNegGraphs(this)) {
			rule.addNegGraph(neg);
		}
	}
	
	// debug guards to protect again accessing wrong elements
	public void addChild(BaseNode n) {
		assert(false);
	}
	public void setChild(int pos, BaseNode n) {
		assert(false);
	}
	public BaseNode getChild(int i) {
		assert(false);
		return null;
	}
	public int children() {
		assert(false);
		return 0;
	}
	public BaseNode replaceChild(int i, BaseNode n) {
		assert(false);
		return null;
	}
}
