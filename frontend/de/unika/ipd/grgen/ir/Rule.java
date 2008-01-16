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
 * @author shack, Daniel Grund
 * @version $Id$
 */
package de.unika.ipd.grgen.ir;

import java.util.Collection;
import java.util.Collections;
import java.util.HashSet;
import java.util.LinkedList;

/**
 * A replacement rule.
 */
public class Rule extends MatchingAction {
	/** Names of the children of this node. */
	private static final String[] childrenNames = {
		"left", "right", "eval"
	};
	
	/** The right hand side of the rule. */
	private final Graph right;
	
	/** The evaluation assignments of this rule. */
	private final Collection<Assignment> evals = new LinkedList<Assignment>();
	
	/**
	 * Make a new rule.
	 * @param ident The identifier with which the rule was declared.
	 * @param left The left side graph of the rule.
	 * @param right The right side graph of the rule.
	 */
	public Rule(Ident ident, PatternGraph left, Graph right) {
		super("rule", ident, left);
		setChildrenNames(childrenNames);
		this.right = right;
		left.setName("L");
		right.setName("R");
		// coalesceAnonymousEdges(); not here, because neg-graphs not added yet.
	}
	

	/** @return A collection containing all eval assignments of this rule. */
	public Collection<Assignment> getEvals() {
		return Collections.unmodifiableCollection(evals);
	}
	
	/** Add an assignment to the list of evaluations. */
	public void addEval(Assignment a) {
		evals.add(a);
	}
	
	/** @return A set with nodes, that occur on the left _and_ on the right side of the rule. */
	public Collection<Node> getCommonNodes() {
		Collection<Node> common = new HashSet<Node>(pattern.getNodes());
		common.retainAll(right.getNodes());
		return common;
	}
	
	/** @return A set with edges, that occur on the left _and_ on the right side of the rule. */
	public Collection<Edge> getCommonEdges() {
		Collection<Edge> common = new HashSet<Edge>(pattern.getEdges());
		common.retainAll(right.getEdges());
		return common;
	}
	
	/**
	 * Get all graphs that are involved in this rule besides the pattern part.
	 * For an ordinary matching actions, these are the negative ones.
	 * @return A collection holding all additional graphs in this matching action.
	 */
	public Collection<Graph> getAdditionalGraphs() {
		Collection<Graph> res = new LinkedList<Graph>(super.getAdditionalGraphs());
		res.add(right);
		return res;
	}
	
	
	/** @return The left hand side graph. */
	public PatternGraph getLeft() {
		return pattern;
	}
	
	/** @return The right hand side graph. */
	public Graph getRight() {
		return right;
	}
}
