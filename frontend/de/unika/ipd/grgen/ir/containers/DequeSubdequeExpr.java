/*
 * GrGen: graph rewrite generator tool -- release GrGen.NET 3.5
 * Copyright (C) 2003-2012 Universitaet Karlsruhe, Institut fuer Programmstrukturen und Datenorganisation, LS Goos
 * licensed under LGPL v3 (see LICENSE.txt included in the packaging of this file)
 * www.grgen.net
 */

/**
 * @author Edgar Jakumeit
 */
package de.unika.ipd.grgen.ir.containers;

import de.unika.ipd.grgen.ir.*;

public class DequeSubdequeExpr extends Expression {
	private Expression targetExpr, startExpr, lengthExpr;

	public DequeSubdequeExpr(Expression targetExpr, Expression startExpr, Expression lengthExpr) {
		super("deque subdeque expr", (DequeType)targetExpr.getType());
		this.targetExpr = targetExpr;
		this.startExpr = startExpr;
		this.lengthExpr = lengthExpr;
	}

	public Expression getTargetExpr() {
		return targetExpr;
	}

	public Expression getStartExpr() {
		return startExpr;
	}

	public Expression getLengthExpr() {
		return lengthExpr;
	}

	public void collectNeededEntities(NeededEntities needs) {
		targetExpr.collectNeededEntities(needs);
		startExpr.collectNeededEntities(needs);
		lengthExpr.collectNeededEntities(needs);
	}
}