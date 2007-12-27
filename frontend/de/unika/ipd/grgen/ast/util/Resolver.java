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
import de.unika.ipd.grgen.util.Base;

/**
 * something, that resolves a node to another node.
 */
public abstract class Resolver extends Base {
	/**
	 * Resolve a node.
	 * @param node The parent node of the node to resolve.
	 * @param child The index of the node to resolve in <code>node</code>'s
	 * children.
	 * @return true, if the resolving was successful, false, if not.
	 */
	public abstract boolean resolve(BaseNode node, int child);

	/**
	 * Resolve a node. 
	 * That means this method returns the resolve node, but doesn't replace the node in the AST,
	 * in contrast to resolve(BaseNode node, int child), which does replace the node
	 * @param node The original node to resolve.
	 * @return The node the original node was resolved to (which might be the original node itself),
	 *         or null if the resolving failed
	 */
	public abstract BaseNode resolve(BaseNode node);

	/**
	 * Report an error during resolution.
	 * Some resolvers might want to overwrite this method, so
	 * {@link BaseNode#reportError(String)} is not used directly.
	 * @param node The node that caused the error.
	 * @param msg The error message to be printed.
	 */
	protected void reportError(BaseNode node, String msg) {
		node.reportError(msg);
	}
}

