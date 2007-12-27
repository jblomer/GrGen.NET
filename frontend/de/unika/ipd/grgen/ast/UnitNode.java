/*
  GrGen: graph rewrite generator tool.
  Copyright (C) 2005  IPD Goos, Universit"at Karlsruhe, Germany

  This library is free software; you can redistribute it and/or
  modify it under the terms of the GNU Lesser General Public
  License as published by the Free Software Foundation; either
  version 2.1 of the License, or (at your option) any later version.

  This library is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
  Lesser General Public License for more details.

  You should have received a copy of the GNU Lesser General Public
  License along with this library; if not, write to the Free Software
  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/


/**
 * @author shack
 * @version $Id$
 */
package de.unika.ipd.grgen.ast;

import java.util.Collection;
import java.util.Vector;
import de.unika.ipd.grgen.ast.util.Resolver;
import de.unika.ipd.grgen.ast.util.CollectResolver;
import de.unika.ipd.grgen.ast.util.DeclResolver;
import de.unika.ipd.grgen.ast.util.Checker;
import de.unika.ipd.grgen.ast.util.CollectChecker;
import de.unika.ipd.grgen.ast.util.SimpleChecker;
import de.unika.ipd.grgen.ir.Action;
import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.ir.Ident;
import de.unika.ipd.grgen.ir.Model;
import de.unika.ipd.grgen.ir.Unit;

/**
 * The main node of the text. It is the root of the AST.
 */
public class UnitNode extends DeclNode
{
	static {
		setName(UnitNode.class, "unit declaration");
	}

	protected static final TypeNode mainType = new MainTypeNode();
		
	/** The index of the model child. */
	protected static final int MODELS = 2;
	
	/** Index of the decl collect node in the children. */
	private static final int DECLS = 3;
		
	/** Contains the classes of all valid types which can be declared */
	private static Class<?>[] validTypes = {
		TestDeclNode.class, RuleDeclNode.class
	};
	
	/**
	 * The filename for this main node.
	 */
	private String filename;
	
	public UnitNode(IdentNode id, String filename) {
		super(id, mainType);
		this.filename = filename;
	}
	
	/** returns children of this node */
	public Collection<BaseNode> getChildren() {
		return children;
	}

	/** returns names of the children, same order as in getChildren */
	public Collection<String> getChildrenNames() {
		Vector<String> childrenNames = new Vector<String>();
		childrenNames.add("ident"); 
		childrenNames.add("type");
		childrenNames.add("models");
		childrenNames.add("decls");
		return childrenNames;
	}

  	/** @see de.unika.ipd.grgen.ast.BaseNode#resolve() */
	protected boolean resolve() {
		if(isResolved()) {
			return resolutionResult();
		}
		
		debug.report(NOTE, "resolve in: " + getId() + "(" + getClass() + ")");
		boolean successfullyResolved = true;
		Resolver declResolver = new CollectResolver(new DeclResolver(validTypes));
		successfullyResolved = declResolver.resolve(this, DECLS) && successfullyResolved;
		nodeResolvedSetResult(successfullyResolved); // local result
		if(!successfullyResolved) {
			debug.report(NOTE, "resolve error");
		}
		
		successfullyResolved = getChild(IDENT).resolve() && successfullyResolved;
		successfullyResolved = getChild(TYPE).resolve() && successfullyResolved;
		successfullyResolved = getChild(MODELS).resolve() && successfullyResolved;
		successfullyResolved = getChild(DECLS).resolve() && successfullyResolved;
		return successfullyResolved;
	}
	
	/** @see de.unika.ipd.grgen.ast.BaseNode#check() */
	protected boolean check() {
		if(!resolutionResult()) {
			return false;
		}
		if(isChecked()) {
			return getChecked();
		}
		
		boolean successfullyChecked = checkLocal();
		nodeCheckedSetResult(successfullyChecked);
		
		successfullyChecked = getChild(IDENT).check() && successfullyChecked;
		successfullyChecked = getChild(TYPE).check() && successfullyChecked;
		successfullyChecked = getChild(MODELS).check() && successfullyChecked;
		successfullyChecked = getChild(DECLS).check() && successfullyChecked;
		return successfullyChecked;
	}
	
	/**
	 * The main node has an ident node and a collect node with
	 * - group declarations
	 * - edge class declarations
	 * - node class declarations
	 * as child.
	 * @see de.unika.ipd.grgen.ast.BaseNode#checkLocal()
	 */
	protected boolean checkLocal() {
		Checker modelChecker = new CollectChecker(new SimpleChecker(ModelNode.class));
		Checker declChecker = new CollectChecker(new SimpleChecker(validTypes));
		return modelChecker.check(getChild(MODELS), error)
			&& declChecker.check(getChild(DECLS), error);
	}
	
	/**
	 * Get the IR unit node for this AST node.
	 * @return The Unit for this AST node.
	 */
	public Unit getUnit() {
		return (Unit) checkIR(Unit.class);
	}
	
	/**
	 * Construct the IR object for this AST node.
	 * For a main node, this is a unit.
	 * @see de.unika.ipd.grgen.ast.BaseNode#constructIR()
	 */
	protected IR constructIR() {
		Ident id = (Ident) getChild(IDENT).checkIR(Ident.class);
		Unit res = new Unit(id, filename);
		
		for(BaseNode n : getChild(MODELS).getChildren()) {
			Model model = ((ModelNode)n).getModel();
			res.addModel(model);
		}

		for(BaseNode n : getChild(DECLS).getChildren()) {
			Action act = ((ActionDeclNode)n).getAction();
			res.addAction(act);
		}

		return res;
	}
}
