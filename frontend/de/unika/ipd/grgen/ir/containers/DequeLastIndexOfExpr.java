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

public class DequeLastIndexOfExpr extends Expression {
	private Expression targetExpr, valueExpr;

	public DequeLastIndexOfExpr(Expression targetExpr, Expression valueExpr) {
		super("deque lastIndexOf expr", IntType.getType());
		this.targetExpr = targetExpr;
		this.valueExpr = valueExpr;
	}

	public Expression getTargetExpr() {
		return targetExpr;
	}

	public Expression getValueExpr() {
		return valueExpr;
	}

	public void collectNeededEntities(NeededEntities needs) {
		targetExpr.collectNeededEntities(needs);
		valueExpr.collectNeededEntities(needs);
	}
}