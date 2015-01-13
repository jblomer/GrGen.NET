/*
 * GrGen: graph rewrite generator tool -- release GrGen.NET 4.4
 * Copyright (C) 2003-2015 Universitaet Karlsruhe, Institut fuer Programmstrukturen und Datenorganisation, LS Goos; and free programmers
 * licensed under LGPL v3 (see LICENSE.txt included in the packaging of this file)
 * www.grgen.net
 */

/**
 * @author Edgar Jakumeit
 */

package de.unika.ipd.grgen.ast.containers;

import java.util.Collection;
import java.util.Vector;

import de.unika.ipd.grgen.ast.*;
import de.unika.ipd.grgen.ast.exprevals.*;
import de.unika.ipd.grgen.ir.exprevals.Expression;
import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.ir.containers.ArrayAsMapExpr;
import de.unika.ipd.grgen.parser.Coords;

public class ArrayAsMapNode extends ExprNode
{
	static {
		setName(ArrayAsMapNode.class, "array as map expression");
	}

	private ExprNode targetExpr;

	public ArrayAsMapNode(Coords coords, ExprNode targetExpr)
	{
		super(coords);
		this.targetExpr = becomeParent(targetExpr);
	}

	@Override
	public Collection<? extends BaseNode> getChildren() {
		Vector<BaseNode> children = new Vector<BaseNode>();
		children.add(targetExpr);
		return children;
	}

	@Override
	public Collection<String> getChildrenNames() {
		Vector<String> childrenNames = new Vector<String>();
		childrenNames.add("targetExpr");
		return childrenNames;
	}

	@Override
	protected boolean resolveLocal() {
		getType().resolve(); // call to ensure the set type exists
		return true;
	}
	
	@Override
	protected boolean checkLocal() {
		TypeNode targetType = targetExpr.getType();
		if(!(targetType instanceof ArrayTypeNode)) {
			targetExpr.reportError("This argument to array as map expression must be of type array<T>");
			return false;
		}
		return true;
	}

	@Override
	public TypeNode getType() {
		return MapTypeNode.getMapType(BasicTypeNode.intType.getIdentNode(), ((ArrayTypeNode)targetExpr.getType()).valueTypeUnresolved);
	}

	@Override
	protected IR constructIR() {
		return new ArrayAsMapExpr(targetExpr.checkIR(Expression.class), getType().getType());
	}
}
