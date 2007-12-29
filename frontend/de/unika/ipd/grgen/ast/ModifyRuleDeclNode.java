package de.unika.ipd.grgen.ast;

import java.util.Collection;
import java.util.HashSet;
import java.util.Vector;
import de.unika.ipd.grgen.ast.util.Checker;
import de.unika.ipd.grgen.ast.util.CollectChecker;
import de.unika.ipd.grgen.ast.util.DeclResolver;
import de.unika.ipd.grgen.ast.util.SimpleChecker;
import de.unika.ipd.grgen.ast.util.Resolver;
import de.unika.ipd.grgen.ir.Assignment;
import de.unika.ipd.grgen.ir.Edge;
import de.unika.ipd.grgen.ir.Entity;
import de.unika.ipd.grgen.ir.Graph;
import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.ir.Node;
import de.unika.ipd.grgen.ir.PatternGraph;
import de.unika.ipd.grgen.ir.Rule;
import java.util.Set;


public class ModifyRuleDeclNode extends RuleDeclNode
{
	BaseNode delete;
	
	public ModifyRuleDeclNode(IdentNode id, PatternGraphNode left, GraphNode right,
							  CollectNode neg, CollectNode eval, CollectNode params, CollectNode rets, CollectNode dels) {
		super(id, left, right, neg, eval, params, rets);
		this.delete = dels==null ? NULL : dels;
		becomeParent(this.delete);
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
		children.add(delete);
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
		childrenNames.add("delete");
		return childrenNames;
	}
	
	/** @see de.unika.ipd.grgen.ast.BaseNode#resolve() */
	protected boolean resolve() {
		if(isResolved()) {
			return resolutionResult();
		}
		
		debug.report(NOTE, "resolve in: " + getId() + "(" + getClass() + ")");
		boolean successfullyResolved = true;
		Resolver deleteResolver = new DeclResolver(new Class[] { NodeDeclNode.class, EdgeDeclNode.class });
		successfullyResolved = ((CollectNode)delete).resolveChildren(deleteResolver) && successfullyResolved;
		nodeResolvedSetResult(successfullyResolved); // local result
		if(!successfullyResolved) {
			debug.report(NOTE, "resolve error");
		}
		
		successfullyResolved = ident.resolve() && successfullyResolved;
		successfullyResolved = type.resolve() && successfullyResolved;
		successfullyResolved = param.resolve() && successfullyResolved;
		successfullyResolved = ret.resolve() && successfullyResolved;
		successfullyResolved = pattern.resolve() && successfullyResolved;
		successfullyResolved = neg.resolve() && successfullyResolved;
		successfullyResolved = right.resolve() && successfullyResolved;
		successfullyResolved = eval.resolve() && successfullyResolved;
		successfullyResolved = delete.resolve() && successfullyResolved;
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
		
		boolean childrenChecked = true;
		if(!visitedDuringCheck()) {
			setCheckVisited();
			
			childrenChecked = ident.check() && childrenChecked;
			childrenChecked = type.check() && childrenChecked;
			childrenChecked = param.check() && childrenChecked;
			childrenChecked = ret.check() && childrenChecked;
			childrenChecked = pattern.check() && childrenChecked;
			childrenChecked = neg.check() && childrenChecked;
			childrenChecked = right.check() && childrenChecked;
			childrenChecked = eval.check() && childrenChecked;
			childrenChecked = delete.check() && childrenChecked;
		}
		
		boolean locallyChecked = checkLocal();
		nodeCheckedSetResult(locallyChecked);
		
		return childrenChecked && locallyChecked;
	}
	
	protected Set<DeclNode> getDelete()
	{
		Set<DeclNode> res = new HashSet<DeclNode>();

		for (BaseNode x : delete.getChildren()) {
			assert (x instanceof DeclNode);
			assert(!x.isKept());
			res.add((DeclNode)x);
		}
		return res;
	}
	
	protected boolean checkReturnedElemsNotDeleted(PatternGraphNode left, GraphNode right)
	{
		boolean res = true;
		CollectNode returns = (CollectNode) right.getReturn();
		CollectNode deletions = (CollectNode) delete;
		
		Collection<DeclNode> deletedElems = new HashSet<DeclNode>();
		for (BaseNode x: deletions.getChildren()) {
			assert (x instanceof DeclNode): "expected a declared entity";
			deletedElems.add((DeclNode)x);
		}
				
		for (BaseNode x : returns.getChildren()) {
			IdentNode ident = (IdentNode) x;
			DeclNode retElem = ident.getDecl();

			if (((retElem instanceof NodeDeclNode) || (retElem instanceof EdgeDeclNode))
				&& deletedElems.contains(retElem))
			{
				res = false;

				String nodeOrEdge = "";
				if (retElem instanceof NodeDeclNode) {
					nodeOrEdge = "node";
				} else if (retElem instanceof NodeDeclNode) {
					nodeOrEdge = "edge";
				} else {
					nodeOrEdge = "element";
				}
				
				if (left.getNodes().contains(retElem) || param.getChildren().contains(retElem)) {
					((IdentNode)ident).reportError("The deleted " + nodeOrEdge + " \"" + ident + "\" must not be returned");
				} else {
					assert false: "the " + nodeOrEdge + " \"" + ident + "\", that is" +
						"neither a parameter, nor contained in LHS, nor in " +
						"RHS, occurs in a return";
				}
			}
		}
		return res;
	}

	protected boolean checkRhsReuse(PatternGraphNode left, GraphNode right)
	{
		boolean res = true;
		Collection<EdgeDeclNode> alreadyReported = new HashSet<EdgeDeclNode>();
		for (BaseNode lc : left.getConnections()) {
			for (BaseNode rc : right.getConnections()) {
				if (lc instanceof SingleNodeConnNode || rc instanceof SingleNodeConnNode ) {
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
				
				//check, whether reuse of nodes and edges is consistent with the LHS
				if ( rSrc.isDummy() ) {
					rConn.setSrc(lSrc);
				} else if ( ! rSrc.equals(lSrc) ) {
					res = false;
					rConn.reportError("Reused edge \"" + le + "\" does not connect the same nodes");
					alreadyReported.add(re);
				}
				
				if ( rTgt.isDummy() ) {
					rConn.setTgt(lTgt);
				} else if ( ! rTgt.equals(lTgt) ) {
					res = false;
					rConn.reportError("Reused edge \"" + le + "\" does not connect the same nodes");
					alreadyReported.add(re);
				}

				//check, whether RHS "adds" a node to a dangling end of a edge
				if ( ! alreadyReported.contains(re) ) {
					if ( lSrc.isDummy() && ! rSrc.isDummy() ) {
						res = false;
						rConn.reportError("Reused edge dangles on LHS, but has a source node on RHS");
						alreadyReported.add(re);
					}
					if ( lTgt.isDummy() && ! rTgt.isDummy() )
					{
						res = false;
						rConn.reportError("Reused edge dangles on LHS, but has a target node on RHS");
						alreadyReported.add(re);
					}
				}
			}
		}
		return res;
	}
	
	private void warnElemAppearsInsideAndOutsideDelete() {
		Set<DeclNode> deletes = getDelete();
		GraphNode right = (GraphNode) this.right;
		
		Set<BaseNode> alreadyReported = new HashSet<BaseNode>();
		for (BaseNode x : right.getConnections()) {
			BaseNode elem = BaseNode.getErrorNode();
			if (x instanceof SingleNodeConnNode) {
				elem = ((SingleNodeConnNode)x).getNode();
			} else if (x instanceof ConnectionNode) {
				elem = (BaseNode) ((ConnectionNode)x).getEdge();
			}
			
			if (alreadyReported.contains(elem)) {
				continue;
			}
			
			for (BaseNode y : deletes) {
				if (elem.equals(y)) {
					x.reportWarning("\"" + y + "\" appears inside as well as outside a delete statement");
					alreadyReported.add(elem);
				}
			}
		}
	}
		
	@Override
	protected boolean checkLocal() {
		warnElemAppearsInsideAndOutsideDelete();
		Checker deleteChecker = new CollectChecker(new SimpleChecker(new Class[] { NodeDeclNode.class, EdgeDeclNode.class }));
		return super.checkLocal()
			&& deleteChecker.check(delete, error);
	}
	
	@Override
	protected IR constructIR() {
		PatternGraph left = ((PatternGraphNode) pattern).getPatternGraph();
		Graph right = ((GraphNode) this.right).getGraph();
		
		Collection<Entity> deleteSet = new HashSet<Entity>();
		for(BaseNode n : delete.getChildren()) {
			deleteSet.add((Entity)n.checkIR(Entity.class));
		}
		
		for(Node n : left.getNodes()) {
			if(!deleteSet.contains(n)) {
				right.addSingleNode(n);
			}
		}
		for(Edge e : left.getEdges()) {
			if(!deleteSet.contains(e)
				&& !deleteSet.contains(left.getSource(e))
				&& !deleteSet.contains(left.getTarget(e)))
			{
				right.addConnection(left.getSource(e), e, left.getTarget(e));
			}
		}
		
		Rule rule = new Rule(getIdentNode().getIdent(), left, right);
		
		constructImplicitNegs(rule);
		constructIRaux(rule, ((GraphNode)this.right).getReturn());
		
		// add Params to the IR
		for(BaseNode n : param.getChildren()) {
			DeclNode param = (DeclNode)n;
			if(!deleteSet.contains(param.getIR())) {
				if(param instanceof NodeCharacter) {
					right.addSingleNode(((NodeCharacter)param).getNode());
				} else if (param instanceof EdgeCharacter) {
					Edge e = ((EdgeCharacter)param).getEdge();
					if(!deleteSet.contains(e)
						&& !deleteSet.contains(left.getSource(e))
						&& !deleteSet.contains(left.getTarget(e)))
					{
						right.addSingleEdge(e); //TODO
						//right.addConnection(left.getSource(e),e, left.getTarget((e)));
					}
				} else {
					throw new IllegalArgumentException("unknown Class: " + n);
				}
			}
		}
		
		// add Eval statements to the IR
		for(BaseNode n : eval.getChildren()) {
			AssignNode eval = (AssignNode)n;
			rule.addEval((Assignment) eval.checkIR(Assignment.class));
		}
		
		return rule;
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
