/*
 * GrGen: graph rewrite generator tool -- release GrGen.NET 4.4
 * Copyright (C) 2003-2015 Universitaet Karlsruhe, Institut fuer Programmstrukturen und Datenorganisation, LS Goos; and free programmers
 * licensed under LGPL v3 (see LICENSE.txt included in the packaging of this file)
 * www.grgen.net
 */

package de.unika.ipd.grgen.ir.exprevals;

public class GraphAddCopyNodeProc extends ProcedureInvocationBase {
	private final Expression oldNode;

	public GraphAddCopyNodeProc(Expression nodeType) {
		super("graph add copy node procedure");
		this.oldNode = nodeType;
	}

	public Expression getOldNodeExpr() {
		return oldNode;
	}

	public ProcedureBase getProcedureBase() {
		return null; // dummy needed for interface, not accessed because the type of the class already defines the procedure
	}

	/** @see de.unika.ipd.grgen.ir.Expression#collectNeededEntities() */
	public void collectNeededEntities(NeededEntities needs) {
		needs.needsGraph();
		oldNode.collectNeededEntities(needs);
	}
}

