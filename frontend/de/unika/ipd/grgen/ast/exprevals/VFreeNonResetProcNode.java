/*
 * GrGen: graph rewrite generator tool -- release GrGen.NET 4.4
 * Copyright (C) 2003-2015 Universitaet Karlsruhe, Institut fuer Programmstrukturen und Datenorganisation, LS Goos; and free programmers
 * licensed under LGPL v3 (see LICENSE.txt included in the packaging of this file)
 * www.grgen.net
 */

/**
 * @author Edgar Jakumeit
 */

package de.unika.ipd.grgen.ast.exprevals;

import java.util.Collection;
import java.util.Vector;

import de.unika.ipd.grgen.ast.*;
import de.unika.ipd.grgen.ir.exprevals.Expression;
import de.unika.ipd.grgen.ir.exprevals.VFreeNonResetProc;
import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.parser.Coords;

public class VFreeNonResetProcNode extends ProcedureInvocationBaseNode {
	static {
		setName(VFreeNonResetProcNode.class, "vfreenonreset procedure");
	}

	private ExprNode visFlagExpr;


	public VFreeNonResetProcNode(Coords coords, ExprNode visFlagExpr) {
		super(coords);

		this.visFlagExpr = becomeParent(visFlagExpr);
	}

	@Override
	public Collection<? extends BaseNode> getChildren() {
		Vector<BaseNode> children = new Vector<BaseNode>();
		children.add(visFlagExpr);
		return children;
	}

	@Override
	public Collection<String> getChildrenNames() {
		Vector<String> childrenNames = new Vector<String>();
		childrenNames.add("visFlagExpr");
		return childrenNames;
	}

	@Override
	protected boolean resolveLocal() {
		return true;
	}

	@Override
	protected boolean checkLocal() {
		if(!visFlagExpr.getType().isEqual(BasicTypeNode.intType)) {
			visFlagExpr.reportError("Argument (visited flag id) to vfreenonreset statement must be of type int");
			return false;
		}
		return true;
	}

	public boolean checkStatementLocal(boolean isLHS, DeclNode root, EvalStatementNode enclosingLoop) {
		return true;
	}

	@Override
	protected IR constructIR() {
		return new VFreeNonResetProc(visFlagExpr.checkIR(Expression.class));
	}
}
