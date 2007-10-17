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
 * @author Rubino Geiss
 * @version $Id$
 */
package de.unika.ipd.grgen.ir;


import java.util.Set;

public class Typeof extends Expression {
	/** The entitiy whose type we want to know. */
	private final Entity entity;

	public Typeof(Entity entity) {
		super("typeof", entity.getType());
		this.entity = entity;
	}
	
	public Entity getEntity() {
		return entity;
	}
	
	public String getNodeLabel() {
		return "typeof<" + entity + ">";
	}

	/**
	 * Method collectNodesnEdges extracts the nodes and edges occuring in this Expression.
	 * @param    nodes               a  Set to contain the nodes of cond
	 * @param    edges               a  Set to contain the edges of cond
	 * @param    cond                an Expression
	 */
	public void collectNodesnEdges(Set<Node> nodes, Set<Edge> edges) {
		if(entity instanceof Node)
			nodes.add((Node)entity);
		else if(entity instanceof Edge)
			edges.add((Edge)entity);
		else
			throw new UnsupportedOperationException("Unsupported Entity (" + entity + ")");
	}
}

