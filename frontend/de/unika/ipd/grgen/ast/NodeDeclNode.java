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
 * @author Sebastian Hack
 * @version $Id$
 */
package de.unika.ipd.grgen.ast;

import de.unika.ipd.grgen.ast.util.Resolver;
import de.unika.ipd.grgen.ast.util.DeclResolver;
import de.unika.ipd.grgen.ast.util.Checker;
import de.unika.ipd.grgen.ast.util.SimpleChecker;
import de.unika.ipd.grgen.ast.util.TypeChecker;
import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.ir.Node;
import de.unika.ipd.grgen.ir.NodeType;
import java.awt.Color;
import java.util.Collection;
import java.util.Vector;

/**
 * Declaration of a node.
 */
public class NodeDeclNode extends ConstraintDeclNode implements NodeCharacter
{
	static {
		setName(NodeDeclNode.class, "node");
	}

	protected static final Resolver typeResolver =
		new DeclResolver(new Class[] { NodeDeclNode.class, TypeDeclNode.class });
	
	/**
	 * Make a new node declaration.
	 * @param id The identifier of the node.
	 * @param type The type of the node.
	 */
	public NodeDeclNode(IdentNode id, BaseNode type, BaseNode constr) {
		super(id, type, constr);
	}

	public NodeDeclNode(IdentNode id, BaseNode type) {
		this(id, type, TypeExprNode.getEmpty());
	}

	/** returns children of this node */
	public Collection<BaseNode> getChildren() {
		Vector<BaseNode> children = new Vector<BaseNode>();
		children.add(ident);
		children.add(type);
		children.add(constraints);
		return children;
	}
	
	/** returns names of the children, same order as in getChildren */
	public Collection<String> getChildrenNames() {
		Vector<String> childrenNames = new Vector<String>();
		childrenNames.add("ident"); 
		childrenNames.add("type");
		childrenNames.add("constraints");
		return childrenNames;
	}
	
  	/** @see de.unika.ipd.grgen.ast.BaseNode#resolve() */
	protected boolean resolve() {
		if(isResolved()) {
			return resolutionResult();
		}
		
		debug.report(NOTE, "resolve in: " + getId() + "(" + getClass() + ")");
		boolean successfullyResolved = true;
		BaseNode resolved = typeResolver.resolve(type);
		successfullyResolved = resolved!=null && successfullyResolved;
		type = ownedResolutionResult(type, resolved);
		nodeResolvedSetResult(successfullyResolved); // local result
		if(!successfullyResolved) {
			debug.report(NOTE, "resolve error");
		}
		
		successfullyResolved = ident.resolve() && successfullyResolved;
		successfullyResolved = type.resolve() && successfullyResolved;
		successfullyResolved = constraints.resolve() && successfullyResolved;
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
			childrenChecked = constraints.check() && childrenChecked;
		}
		
		boolean locallyChecked = checkLocal();
		nodeCheckedSetResult(locallyChecked);
		
		return childrenChecked && locallyChecked;
	}
	
	protected boolean checkLocal() {
		Checker typeChecker = new TypeChecker(NodeTypeNode.class);
		return super.checkLocal()
			&& (new SimpleChecker(IdentNode.class)).check(ident, error)
			&& typeChecker.check(type, error);
	}
	
	/**
	 * Yields a dummy <code>NodeDeclNode</code> needed as
	 * dummy tgt or src node for dangling edges.
	 */
	public static NodeDeclNode getDummy(IdentNode id, BaseNode type) {
		return new DummyNodeDeclNode(id, type);
	}
	
	public boolean isDummy() {
		return false;
	}
		
	/**
	 * @see de.unika.ipd.grgen.util.GraphDumpable#getNodeColor()
	 */
	public Color getNodeColor() {
		return Color.GREEN;
	}
	
	/**
	 * @see de.unika.ipd.grgen.ast.NodeCharacter#getNode()
	 */
	public Node getNode() {
		return (Node) checkIR(Node.class);
	}
	
	/**
	 * The TYPE child could be a node in case the type is
	 * inherited dynamically via the typeof operator
	 */
	public BaseNode getDeclType() {
		return ((DeclNode)type).getDeclType();
	}
	
	protected boolean inheritsType() {
		return (type instanceof NodeDeclNode);
	}
	
	/**
	 * @see de.unika.ipd.grgen.ast.BaseNode#constructIR()
	 */
	protected IR constructIR() {
		// This cast must be ok after checking.
		NodeTypeNode tn = (NodeTypeNode) getDeclType();
		NodeType nt = tn.getNodeType();
		IdentNode ident = getIdentNode();
		
		Node res = new Node(ident.getIdent(), nt, ident.getAttributes());
		res.setConstraints(getConstraints());
		
		if( res.getConstraints().contains(res.getType()) ) {
			error.error(getCoords(), "Self NodeType may not be contained in TypeCondition of Node "
					+ "("+ res.getType() + ")");
		}
		
		if(inheritsType()) {
			res.setTypeof((Node)type.checkIR(Node.class));
		}
		
		return res;
	}
	
	public static String getKindStr() {
		return "node declaration";
	}
	public static String getUseStr() {
		return "node";
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
