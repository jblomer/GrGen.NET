/**
 * @author Sebastian Hack
 * @version $Id$
 */
package de.unika.ipd.grgen.ir;

import java.util.Iterator;

import de.unika.ipd.grgen.util.ArrayIterator;

/**
 * An action that represents something that does graph matching.
 */
public abstract class MatchingAction extends Action {

	/** Children names of this node. */
	private static final String[] childrenNames = {
	  "pattern"
	};

	/** The graph pattern to match against. */
	protected Graph pattern;

	/**
	 * The condition of this rule.
	 */
	protected Condition condition = new Condition();

  /**
   * @param name The name of this action.
   * @param ident The identifier that identifies this object.
   * @param pattern The graph pattern to match against.
   */
  public MatchingAction(String name, Ident ident, Graph pattern) {
    super(name, ident, null);
    this.pattern = pattern;
    setChildrenNames(childrenNames);
  }
  
  /**
   * Get the graph pattern.
   * @return The graph pattern.
   */
  public Graph getPattern() {
  	return pattern;
  }

  /**
   * @see de.unika.ipd.grgen.util.Walkable#getWalkableChildren()
   */
  public Iterator getWalkableChildren() {
  	return new ArrayIterator(new Object[] { pattern, condition });
  }


	/**
	 * Return a list of conditions.
	 * @return The conditions.
	 */
	public Condition getCondition() {
		return condition;
	}

}
