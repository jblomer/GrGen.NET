/*
 * GrGen: graph rewrite generator tool -- release GrGen.NET 3.5
 * Copyright (C) 2003-2012 Universitaet Karlsruhe, Institut fuer Programmstrukturen und Datenorganisation, LS Goos
 * licensed under LGPL v3 (see LICENSE.txt included in the packaging of this file)
 * www.grgen.net
 */

/**
 * @author Moritz Kroll
 * @version $Id$
 */
package de.unika.ipd.grgen.ir;

/**
 * A exec variable expression node.
 */
public class ExecVariableExpression extends Expression {
	private ExecVariable var;

	public ExecVariableExpression(ExecVariable var) {
		super("exec variable", var.getType());
		this.var = var;
	}

	/** Returns the exec variable of this exec variable expression. */
	public ExecVariable getVariable() {
		return var;
	}

	/** @see de.unika.ipd.grgen.ir.Expression#collectNeededEntities() */
	public void collectNeededEntities(NeededEntities needs) {
	}

	public boolean equals(Object other) {
		if(!(other instanceof ExecVariableExpression)) return false;
		return var == ((ExecVariableExpression) other).getVariable();
	}

	public int hashCode() {
		return var.hashCode();
	}
}
