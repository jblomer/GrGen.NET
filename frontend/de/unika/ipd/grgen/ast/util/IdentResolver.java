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
 * @author Sebastian Hack
 * @version $Id$
 */
package de.unika.ipd.grgen.ast.util;

import de.unika.ipd.grgen.ast.BaseNode;
import de.unika.ipd.grgen.ast.IdentNode;
import de.unika.ipd.grgen.util.Util;

/**
 * Base class for identifier resolvers,
 * replacing an identifier node with it's corresponding declaration node.
 * Searching of the declaration occurs within the subclasses,
 * which must overwrite resolveIdent for that purpose.
 */
public abstract class IdentResolver extends Resolver {
	/** The set of classes the resolved node must be an instance of */
	private Class<?>[] classes;

	/** A string with names of the classes, which are expected. */
	private String expectList;


	/**
	 * Make a new ident resolver.
	 * @param classes An array of classes the resolved ident
	 * must be an instance of.
	 */
	protected IdentResolver(Class<?>[] classes) {
		this.classes = classes;

		try {
			expectList = Util.getStrListWithOr(
				classes, BaseNode.class, "getUseStr");
		}
		catch(Exception e) {
		}
	}

	/**
	 * @see de.unika.ipd.grgen.ast.util.Resolver#resolve(de.unika.ipd.grgen.ast.BaseNode, int)
	 * The function resolves an IdentNode into it's declaration node.
	 * If <code>n</code> at position <code>pos</code> is not an IdentNode,
	 * the method returns true and the node is considered as resolved.
	 */
	public boolean resolve(BaseNode n, int pos) {
		assert pos < n.children() : "position exceeds children count";

		debug.report(NOTE, "resolving position: " + pos);
		BaseNode childToResolve = n.getChild(pos);
		debug.report(NOTE, "child is a: " + childToResolve.getName() + " (" + childToResolve + ")");
		if(!(childToResolve instanceof IdentNode)) {
			// if the desired node isn't an identifier everything is fine, return true
			//  reportError(n, "Expected an identifier, not a \"" + c.getName() + "\"");
			return true;
		}

		IdentNode identNode = (IdentNode)childToResolve;
		BaseNode get = resolveIdent(identNode);
		debug.report(NOTE, "resolved to a: " + get.getName());

		// Check, if the class of the resolved node is one of the desired classes.
		// If that's true, replace the desired node with the resolved one.
		for(int i = 0; i < classes.length; i++) {
			if(classes[i].isInstance(get)) {
				n.replaceChild(pos, get);
				debug.report(NOTE, "child is now a: " + n.getChild(pos));
				return true;
			}
		}

		// If not, replace with error node
		reportError(identNode, "\"" + identNode + "\" is a " + get.getUseString() +
						" but a " + expectList + " is expected");
		n.replaceChild(pos, getDefaultResolution());
		return false;
	}

	/**
	 * Get a default resolution if the resolving fails (error node).
	 */
	protected BaseNode getDefaultResolution() {
		return BaseNode.getErrorNode();
	}

	/**
	 * Get the resolved AST node for an Identifier.
	 * This can be the declaration, the identifier occurs in, for example.
	 * See {@link DeclResolver} as an example.
	 * @param n The identifier.
	 * @return The resolved AST node.
	 */
	protected abstract BaseNode resolveIdent(IdentNode n);
}

