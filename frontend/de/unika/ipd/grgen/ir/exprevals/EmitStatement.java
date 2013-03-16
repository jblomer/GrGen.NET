/*
 * GrGen: graph rewrite generator tool -- release GrGen.NET 3.6
 * Copyright (C) 2003-2013 Universitaet Karlsruhe, Institut fuer Programmstrukturen und Datenorganisation, LS Goos; and free programmers
 * licensed under LGPL v3 (see LICENSE.txt included in the packaging of this file)
 * www.grgen.net
 */

package de.unika.ipd.grgen.ir.exprevals;

public class EmitStatement extends EvalStatement {
	private Expression toEmitExpr;

	public EmitStatement(Expression toEmitExpr) {
		super("emit statement");
		this.toEmitExpr = toEmitExpr;
	}

	public Expression getToEmitExpr() {
		return toEmitExpr;
	}

	public void collectNeededEntities(NeededEntities needs) {
		needs.needsGraph();
		toEmitExpr.collectNeededEntities(needs);
	}
}