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

import java.util.Collections;
import java.util.LinkedList;
import java.util.List;

import de.unika.ipd.grgen.ir.*;

/**
 * A computation.
 */
public class Computation extends Identifiable {
	/** A list of the parameters */
	private List<Entity> params = new LinkedList<Entity>();

	/** The return-parameter type */
	private Type retType = null;
	
	/** The computation statements */
	private List<EvalStatement> computationStatements = new LinkedList<EvalStatement>();


	public Computation(String name, Ident ident, Type retType) {
		super(name, ident);

		this.retType = retType;
	}

	/** Add a parameter to the computation. */
	public void addParameter(Entity entity) {
		params.add(entity);
	}

	/** Get all parameters of this computation. */
	public List<Entity> getParameters() {
		return Collections.unmodifiableList(params);
	}

	/** Get the return type of this computation. */
	public Type getReturnType() {
		return retType;
	}
	
	/** Add a computation statement to the computation. */
	public void addComputationStatement(EvalStatement eval) {
		computationStatements.add(eval);
	}

	/** Get all computation statements of this computation. */
	public List<EvalStatement> getComputationStatements() {
		return Collections.unmodifiableList(computationStatements);
	}
}