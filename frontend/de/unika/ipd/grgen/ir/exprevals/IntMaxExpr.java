/*
 * GrGen: graph rewrite generator tool -- release GrGen.NET 4.4
 * Copyright (C) 2003-2015 Universitaet Karlsruhe, Institut fuer Programmstrukturen und Datenorganisation, LS Goos; and free programmers
 * licensed under LGPL v3 (see LICENSE.txt included in the packaging of this file)
 * www.grgen.net
 */

package de.unika.ipd.grgen.ir.exprevals;

public class IntMaxExpr extends Expression {
	public IntMaxExpr() {
		super("intmax expr", IntType.getType());
	}

	public void collectNeededEntities(NeededEntities needs) {
	}
}
