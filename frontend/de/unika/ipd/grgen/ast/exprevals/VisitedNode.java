/*
 * GrGen: graph rewrite generator tool -- release GrGen.NET 3.6
 * Copyright (C) 2003-2013 Universitaet Karlsruhe, Institut fuer Programmstrukturen und Datenorganisation, LS Goos; and free programmers
 * licensed under LGPL v3 (see LICENSE.txt included in the packaging of this file)
 * www.grgen.net
 */

package de.unika.ipd.grgen.ast.exprevals;

import java.util.Collection;
import java.util.Vector;

import de.unika.ipd.grgen.ast.*;
import de.unika.ipd.grgen.ast.util.DeclarationPairResolver;
import de.unika.ipd.grgen.ast.util.Pair;
import de.unika.ipd.grgen.ir.Entity;
import de.unika.ipd.grgen.ir.exprevals.Expression;
import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.ir.exprevals.Visited;
import de.unika.ipd.grgen.parser.Coords;

public class VisitedNode extends ExprNode {
	static {
		setName(VisitedNode.class, "visited");
	}

	private ExprNode visitorIDExpr;

	private BaseNode entityUnresolved;
	private NodeDeclNode entityNodeDecl;
	private EdgeDeclNode entityEdgeDecl;

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

	@Override
	protected boolean resolveLocal() {
		boolean res = fixupDefinition(entityUnresolved, entityUnresolved.getScope());
		
		Pair<EdgeDeclNode, NodeDeclNode> resolved = entityResolver.resolve(entityUnresolved, this);
		if (resolved != null) {
			entityEdgeDecl = resolved.fst;
			entityNodeDecl = resolved.snd;
		}

		return res && resolved != null;
	}

	@Override
	protected boolean checkLocal() {
		if(!visitorIDExpr.getType().isEqual(BasicTypeNode.intType)) {
			visitorIDExpr.reportError("Visitor ID expression must be of type int");
			return false;
		}
		return true;
	}

	@Override
	protected IR constructIR() {
		Entity entity = getValidResolvedVersion(entityEdgeDecl, entityNodeDecl).checkIR(Entity.class);

		return new Visited(visitorIDExpr.checkIR(Expression.class), entity);
	}

	@Override
	public TypeNode getType() {
		return BasicTypeNode.booleanType;
	}
	
	public boolean noDefElementInCondition() {
		if(entityEdgeDecl!=null) {
			if(entityEdgeDecl.defEntityToBeYieldedTo) {
				entityEdgeDecl.reportError("A def entity ("+entityEdgeDecl+") can't be accessed from an if");
				return false;
			}
		}
		if(entityNodeDecl!=null) {
			if(entityNodeDecl.defEntityToBeYieldedTo) {
				entityNodeDecl.reportError("A def variable ("+entityNodeDecl+") can't be accessed from an if");
				return false;
			}
		}
		return true;
	}
}