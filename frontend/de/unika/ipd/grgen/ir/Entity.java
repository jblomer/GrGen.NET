/*
 * GrGen: graph rewrite generator tool -- release GrGen.NET 2.0
 * Copyright (C) 2008 Universitaet Karlsruhe, Institut fuer Programmstrukturen und Datenorganisation, LS Goos
 * licensed under GPL v3 (see LICENSE.txt included in the packaging of this file)
 */

/**
 * @author shack
 * @version $Id$
 */
package de.unika.ipd.grgen.ir;

import java.util.Collections;
import java.util.Map;
import java.util.Set;

/**
 * An instantiation of a type.
 */
public class Entity extends Identifiable {

	protected static final String[] childrenNames = { "type" };

	/** Type of the entity. */
	protected final Type type;

	/** The entity's owner. */
	protected Type owner = null;


	/**
	 * Make a new entity of a given type
	 * @param name The name of the entity.
	 * @param ident The declaring identifier.
	 * @param type The type used in the declaration.
	 */
	public Entity(String name, Ident ident, Type type) {
		super(name, ident);
		setChildrenNames(childrenNames);
		this.type = type;
	}

	/** @return The entity's type. */
	public Type getType() {
		return type;
	}

	/** @return The entity's owner. */
	public Type getOwner() {
		return owner;
	}

	/**
	 * Set the owner of the entity.
	 * This function is just called from other IR classes.
	 * @param type The owner of the entity.
	 */
	protected void setOwner(Type type) {
		owner = type;
	}

	/** @return true, if the entity has an owner, else false */
	public boolean hasOwner() {
		return owner != null;
	}

	public void addFields(Map<String, Object> fields) {
		super.addFields(fields);
		fields.put("type", Collections.singleton(type));
		fields.put("owner", Collections.singleton(owner));
	}

	/** @return true, if this is a retyped entity, else false */
	public boolean isRetyped() {
		return false;
	}

	/** The only walkable child here is the type
	 *  @see de.unika.ipd.grgen.util.Walkable#getWalkableChildren() */
	public Set<? extends IR> getWalkableChildren() {
		return Collections.singleton(type);
	}
}
