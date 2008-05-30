/*
 * GrGen: graph rewrite generator tool -- release GrGen.NET v2 beta
 * Copyright (C) 2008 Universitaet Karlsruhe, Institut fuer Programmstrukturen und Datenorganisation, LS Goos
 * licensed under GPL v3 (see LICENSE.txt included in the packaging of this file)
 */

/**
 * @version $Id$
 */
package de.unika.ipd.grgen.ast;

import java.util.Collection;
import java.util.Vector;

import de.unika.ipd.grgen.ast.util.DeclarationPairResolver;
import de.unika.ipd.grgen.ast.util.Pair;
import de.unika.ipd.grgen.ir.Entity;
import de.unika.ipd.grgen.ir.Expression;
import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.ir.Visited;
import de.unika.ipd.grgen.parser.Coords;

public class VisitedNode extends ExprNode {
	static {
		setName(VisitedNode.class, "visited");
	}
	
	ExprNode visitorIDExpr;
	
	BaseNode entityUnresolved;
	NodeDeclNode entityNodeDecl;
	EdgeDeclNode entityEdgeDecl;
	
	public VisitedNode(Coords coords, ExprNode visitorIDExpr, BaseNode entity) {
		super(coords);
		
		this.visitorIDExpr = visitorIDExpr;
		becomeParent(visitorIDExpr);
		
		entityUnresolved = entity;
		becomeParent(entityUnresolved);
	}

	public Collection<? extends BaseNode> getChildren() {
		Vector<BaseNode> children = new Vector<BaseNode>();
		children.add(visitorIDExpr);
		children.add(getValidVersion(entityUnresolved, entityEdgeDecl, entityNodeDecl));
		return children;
	}

	public Collection<String> getChildrenNames() {
		Vector<String> childrenNames = new Vector<String>();
		childrenNames.add("visitorID");
		childrenNames.add("entity");
		return childrenNames;
	}

	private static final DeclarationPairResolver<EdgeDeclNode, NodeDeclNode> entityResolver =
		new DeclarationPairResolver<EdgeDeclNode, NodeDeclNode>(EdgeDeclNode.class, NodeDeclNode.class);
	
	protected boolean resolveLocal() {
		Pair<EdgeDeclNode, NodeDeclNode> resolved = entityResolver.resolve(entityUnresolved, this);
		if (resolved != null) {
			entityEdgeDecl = resolved.fst;
			entityNodeDecl = resolved.snd;
		}

		return (resolved != null);
	}

	protected boolean checkLocal() {
		if(!visitorIDExpr.getType().isEqual(BasicTypeNode.intType)) {
			visitorIDExpr.reportError("Visitor ID expression must be of type int");
			return false;
		}
		return true;
	}
	
	protected IR constructIR() {
		Entity entity = getValidResolvedVersion(entityEdgeDecl, entityNodeDecl).checkIR(Entity.class);

		return new Visited(visitorIDExpr.checkIR(Expression.class), entity);
	}
	
	public TypeNode getType() {
		return BasicTypeNode.booleanType;
	}
}