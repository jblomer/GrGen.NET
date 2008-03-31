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
package de.unika.ipd.grgen.ir;

/**
 * An edge in a graph.
 */
import de.unika.ipd.grgen.util.Annotations;
import de.unika.ipd.grgen.util.EmptyAnnotations;

public class Edge extends GraphEntity {

	/** Type of the edge. */
	protected final EdgeType type;

	/** Point of definition, that is the pattern graph the edge was defined in*/
	protected PatternGraph pointOfDefinition;

	protected boolean fixedDirection;

	/**
	 * Make a new edge.
	 * @param ident The identifier for the edge.
	 * @param type The type of the edge.
	 * @param annots The annotations of this edge.
	 * @param maybeDeleted Indicates whether this element might be deleted due to homomorphy.
	 * @param maybeRetyped Indicates whether this element might be retyped due to homomorphy.
	 */
	public Edge(Ident ident, EdgeType type, Annotations annots, boolean maybeDeleted, boolean maybeRetyped) {
		super("edge", ident, type, annots, maybeDeleted, maybeRetyped);
		this.type = type;
	}

	/**
	 * Make a new edge.
	 * @param ident The identifier for the edge.
	 * @param type The type of the edge.
	 * @param maybeDeleted Indicates whether this element might be deleted due to homomorphy
	 * @param maybeRetyped Indicates whether this element might be retyped due to homomorphy.
	 */
	public Edge(Ident ident, EdgeType type, boolean maybeDeleted, boolean maybeRetyped) {
		this(ident, type, EmptyAnnotations.get(), maybeDeleted, maybeRetyped);
	}

	/** @return The type of the edge. */
	public EdgeType getEdgeType() {
		return type;
	}

	/** Get the edge from which this edge inherits its dynamic type */
	public Edge getTypeof() {
		return (Edge)typeof;
	}

	/**
	 * Sets the corresponding retyped version of this edge
	 * @param retyped The retyped edge
	 */
	public void setRetypedEdge(Edge retyped) {
		this.retyped = retyped;
	}

	/**
	 * Returns the corresponding retyped version of this edge
	 * @return The retyped version or <code>null</code>
	 */
	public RetypedEdge getRetypedEdge() {
		return (RetypedEdge)this.retyped;
	}

	/**
	 * @return whether the edge has a fixed direction (i.e. directed Edge) or
	 * not (all other edge kinds)
	 */
	public boolean hasFixedDirection() {
		return fixedDirection;
	}
	
	public void setPointOfDefinition(PatternGraph pointOfDefinition) {
		assert this.pointOfDefinition==null && pointOfDefinition!=null;
		this.pointOfDefinition = pointOfDefinition;
	}
	
	public PatternGraph getPointOfDefinition() {
		return pointOfDefinition;
	}
}
