/*
 * GrGen: graph rewrite generator tool -- release GrGen.NET 3.6
 * Copyright (C) 2003-2013 Universitaet Karlsruhe, Institut fuer Programmstrukturen und Datenorganisation, LS Goos; and free programmers
 * licensed under LGPL v3 (see LICENSE.txt included in the packaging of this file)
 * www.grgen.net
 */

/**
 * @author Edgar Jakumeit
 */

package de.unika.ipd.grgen.ir.exprevals;

public class CommitTransaction extends EvalStatement {
	private Expression transactionIdExpr;

	public CommitTransaction(Expression stringExpr) {
		super("commit transaction statement");
		this.transactionIdExpr = stringExpr;
	}

	public Expression getTransactionId() {
		return transactionIdExpr;
	}

	public void collectNeededEntities(NeededEntities needs) {
		needs.needsGraph();
		transactionIdExpr.collectNeededEntities(needs);
	}
}
