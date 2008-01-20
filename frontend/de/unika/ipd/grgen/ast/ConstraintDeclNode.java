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
 * ConstraintDeclNode.java
 *
 * @author Sebastian Hack
 */

package de.unika.ipd.grgen.ast;

import de.unika.ipd.grgen.ast.util.SimpleChecker;
import de.unika.ipd.grgen.ir.TypeExpr;

public abstract class ConstraintDeclNode extends DeclNode
{
	TypeExprNode constraints;
	
	int context; // context of declaration, contains CONTEXT_LHS if declaration is located on left hand side,
				 // or CONTEXT_RHS if declaration is located on right hand side 
	
	ConstraintDeclNode(IdentNode id, BaseNode type, int context, TypeExprNode constraints) {
		super(id, type);
		this.constraints = constraints;
		becomeParent(this.constraints);
		this.context = context;
	}
			
	protected boolean checkLocal() {
		return (new SimpleChecker(TypeExprNode.class)).check(constraints, error)
			& onlyPatternElementsAreAllowedToBeConstrained();
	}
	
	protected boolean onlyPatternElementsAreAllowedToBeConstrained() {
		if(constraints!=TypeExprNode.getEmpty()) {
			if((context & CONTEXT_LHS_OR_RHS) != CONTEXT_LHS) {
				constraints.reportError("replacement elements are not allowed to be type constrained, only pattern elements are"); 
				return false;
			}
		}
		return true;
	}
	
	protected final TypeExpr getConstraints() {
		return (TypeExpr) constraints.checkIR(TypeExpr.class);
	}
}

