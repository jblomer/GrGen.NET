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
 * @file CollectNode.java
 * @author shack
 * @date Jul 21, 2003
 * @version $Id$
 */
package de.unika.ipd.grgen.ast;

import java.awt.Color;
import java.util.Collection;
import java.util.Vector;
import de.unika.ipd.grgen.ast.util.Checker;
import de.unika.ipd.grgen.ast.util.DeclResolver;
import de.unika.ipd.grgen.ast.util.Resolver;
import de.unika.ipd.grgen.ast.util.SimpleChecker;
import de.unika.ipd.grgen.ast.util.TypeChecker;
import de.unika.ipd.grgen.parser.Coords;

/**
 * AST node that represents a set of potentially homomorph nodes
 * children: *:IdentNode resolved to NodeDeclNode|EdgeDeclNoe
 */
public class HomNode extends BaseNode
{
	static {
		setName(HomNode.class, "homomorph");
	}

	public HomNode(Coords coords) {
		super(coords);
	}

	/** implementation of Walkable @see de.unika.ipd.grgen.util.Walkable#getWalkableChildren() */
	public Collection<? extends BaseNode> getWalkableChildren() {
		return children;
	}
	
	/** get names of the walkable children, same order as in getWalkableChildren */
	public Collection<String> getChildrenNames() {
		Vector<String> childrenNames = new Vector<String>();
		// nameless children
		return childrenNames;
	}

	/** @see de.unika.ipd.grgen.ast.BaseNode#resolve() */
	protected boolean resolve() {
		if(isResolved()) {
			return resolutionResult();
		}
		
		debug.report(NOTE, "resolve in: " + getId() + "(" + getClass() + ")");
		boolean successfullyResolved = true;
		Resolver resolver = new DeclResolver(
				new Class[] { NodeDeclNode.class, EdgeDeclNode.class });
		for(int i=0; i<children(); ++i) {
			successfullyResolved = resolver.resolve(this, i) && successfullyResolved;
		}
		nodeResolvedSetResult(successfullyResolved); // local result
		if(!successfullyResolved) {
			debug.report(NOTE, "resolve error");
		}

		for(int i=0; i<children(); ++i) {
			successfullyResolved = getChild(i).resolve() && successfullyResolved;
		}
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
		
		boolean childrenChecked = true;
		if(!visitedDuringCheck()) {
			setCheckVisited();
			
			for(int i=0; i<children(); ++i) {
				childrenChecked = getChild(i).check() && childrenChecked;
			}
		}
		
		boolean locallyChecked = checkLocal();
		nodeCheckedSetResult(locallyChecked);
		
		return childrenChecked && locallyChecked;
	}
	
	/**
	 * Check whether all children are of same type (node or edge)
	 * and additionally one entity may not be used in two different hom
	 * statements
	 */
	protected boolean checkLocal() {
		if (getChildren().isEmpty()) {
			this.reportError("Hom statement is empty");
			return false;
		}
		
		boolean successfullyChecked = true;
		Checker checker = new SimpleChecker(DeclNode.class);
		for(BaseNode n : getChildren()) {
			successfullyChecked = checker.check(n, error) && successfullyChecked;
		}
		if(!successfullyChecked) {
			return false;
		}

		DeclNode child = (DeclNode) getChild(0);
		TypeChecker typeChecker;

		if (child.getDeclType() instanceof NodeTypeNode) {
			typeChecker = new TypeChecker(NodeTypeNode.class);
		} else {
			typeChecker = new TypeChecker(EdgeTypeNode.class);
		}

		for(BaseNode n : getChildren()) {
			successfullyChecked = typeChecker.check(n, error) && successfullyChecked;
		}
		return successfullyChecked;
	}

	public Color getNodeColor() {
		return Color.PINK;
	}
}
