/*
 * GrGen: graph rewrite generator tool -- release GrGen.NET 2.6
 * Copyright (C) 2003-2009 Universitaet Karlsruhe, Institut fuer Programmstrukturen und Datenorganisation, LS Goos
 * licensed under LGPL v3 (see LICENSE.txt included in the packaging of this file)
 */

/**
 * @author shack
 * @version $Id$
 */
package de.unika.ipd.grgen.ast;

import de.unika.ipd.grgen.ir.Rule;

/**
 * Base class for all action type ast nodes
 */
public abstract class ActionDeclNode extends DeclNode
{
	public ActionDeclNode(IdentNode id, TypeNode type) {
        super(id, type);
    }

    /**
     * Get the IR object for this action node.
     * The IR object is instance of Rule.
     * @return The IR object.
     */
    protected Rule getAction() {
        return checkIR(Rule.class);
    }
}
