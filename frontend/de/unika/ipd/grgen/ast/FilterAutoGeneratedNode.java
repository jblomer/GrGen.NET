/*
 * GrGen: graph rewrite generator tool -- release GrGen.NET 4.3
 * Copyright (C) 2003-2014 Universitaet Karlsruhe, Institut fuer Programmstrukturen und Datenorganisation, LS Goos; and free programmers
 * licensed under LGPL v3 (see LICENSE.txt included in the packaging of this file)
 * www.grgen.net
 */

/**
 * @author Edgar Jakumeit
 */

package de.unika.ipd.grgen.ast;

import java.util.Collection;
import java.util.Vector;

import de.unika.ipd.grgen.ast.util.DeclarationResolver;
import de.unika.ipd.grgen.ir.FilterAutoGenerated;
import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.parser.Coords;


/**
 * AST node class representing filter function declarations
 */
public class FilterAutoGeneratedNode extends BaseNode implements FilterCharacter {
	static {
		setName(FilterFunctionDeclNode.class, "filter function declaration");
	}
	
	protected String name;
	protected String entity;

	protected IdentNode actionUnresolved;
	protected TestDeclNode action;

	public FilterAutoGeneratedNode(Coords coords, String name, String entity, IdentNode action) {
		super(coords);
		this.name = name;
		this.entity = entity;
		this.actionUnresolved = action;
	}

	/** returns children of this node */
	@Override
	public Collection<BaseNode> getChildren() {
		Vector<BaseNode> children = new Vector<BaseNode>();
		children.add(actionUnresolved);
		return children;
	}

	/** returns names of the children, same order as in getChildren */
	@Override
	public Collection<String> getChildrenNames() {
		Vector<String> childrenNames = new Vector<String>();
		childrenNames.add("action");
		return childrenNames;
	}

	private static final DeclarationResolver<TestDeclNode> actionResolver =
		new DeclarationResolver<TestDeclNode>(TestDeclNode.class);

	/** @see de.unika.ipd.grgen.ast.BaseNode#resolveLocal() */
	@Override
	protected boolean resolveLocal() {
		action = actionResolver.resolve(actionUnresolved, this);
		return action != null;
	}

	/** @see de.unika.ipd.grgen.ast.BaseNode#resolveLocal() */
	@Override
	protected boolean checkLocal() {
		if(entity==null) {
			if(!name.equals("auto")) {
				reportError("Unknown auto-generated filter " + name);
				return false;
			}
			return true;
		}
		if(!name.equals("orderAscendingBy")
			&& !name.equals("orderDescendingBy")
			&& !name.equals("groupBy")
			&& !name.equals("keepSameAsFirst")
			&& !name.equals("keepSameAsLast")
			&& !name.equals("keepOneForEach")) {
				reportError("Unknown auto-generated filter " + name + " for def-variable " + entity);
				return false;
		}
		return true;
	}

	public String getFilterName() {
		return name;
	}
	
	public TestDeclNode getActionNode()	{
		return action;
	}

	/** Returns the IR object for this autogen filter node. */
    public FilterAutoGenerated getFilterAutoGenerated() {
        return checkIR(FilterAutoGenerated.class);
    }
    
	@Override
	protected IR constructIR() {
		// return if the IR object was already constructed
		// that may happen in recursive calls
		if (isIRAlreadySet()) {
			return getIR();
		}

		FilterAutoGenerated filterAutoGen = new FilterAutoGenerated(name, entity);

		// mark this node as already visited
		setIR(filterAutoGen);

		filterAutoGen.setAction(action.getAction());
		action.getAction().addFilter(filterAutoGen);
		
		return filterAutoGen;
	}
}


