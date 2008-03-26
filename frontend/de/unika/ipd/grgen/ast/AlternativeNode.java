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
 * @author Edgar Jakumeit
 * @version $Id$
 */
package de.unika.ipd.grgen.ast;

import java.util.Collection;
import java.util.Vector;

import de.unika.ipd.grgen.ir.Alternative;
import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.ir.Rule;
import de.unika.ipd.grgen.parser.Coords;

/**
 * AST node that represents an alternative, containing the alternative graph patterns
 */
public class AlternativeNode extends BaseNode {
	static {
		setName(AlternativeNode.class, "alternative");
	}

	Vector<AlternativeCaseNode> children = new Vector<AlternativeCaseNode>();

	public AlternativeNode(Coords coords) {
		super(coords);
	}

	public void addChild(AlternativeCaseNode n) {
		assert(!isResolved());
		becomeParent(n);
		children.add(n);
	}

	/** returns children of this node */
	public Collection<AlternativeCaseNode> getChildren() {
		return children;
	}

	/** returns names of the children, same order as in getChildren */
	public Collection<String> getChildrenNames() {
		Vector<String> childrenNames = new Vector<String>();
		// nameless children
		return childrenNames;
	}

	/** @see de.unika.ipd.grgen.ast.BaseNode#resolveLocal() */
	protected boolean resolveLocal() {
		return true;
	}

	/** @see de.unika.ipd.grgen.ast.BaseNode#checkLocal() */
	protected boolean checkLocal() {
		if (children.isEmpty()) {
			this.reportError("alternative is empty");
			return false;
		}

		return true;
	}

	/** @see de.unika.ipd.grgen.ast.BaseNode#constructIR() */
	protected IR constructIR() {
		Alternative alternative = new Alternative();
		for (AlternativeCaseNode alternativeCaseNode : children) {
			Rule alternativeCaseRule = (Rule)alternativeCaseNode.getIR();
			alternative.addAlternativeCase(alternativeCaseRule);
		}
		return alternative;
	}
}
