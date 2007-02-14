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
package de.unika.ipd.grgen.ast;

import de.unika.ipd.grgen.ir.Assignment;
import de.unika.ipd.grgen.ir.Expression;
import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.ir.Node;
import de.unika.ipd.grgen.ir.Qualification;
import de.unika.ipd.grgen.parser.Coords;

/**
 * An expression node, denoting an assignment.
 */
public class AssignNode extends BaseNode {
	static {
		setName(AssignNode.class, "Assign");
	}
	
	private static final int LHS = 0;
	private static final int RHS = 1;
	
	/**
	 * @param coords The source code coordinates of = operator.
	 * @param qual The left hand side.
	 * @param expr The expression, that is assigned.
	 */
	public AssignNode(Coords coords, BaseNode qual, BaseNode expr) {
		super(coords);
		addChild(qual);
		addChild(expr);
	}
	
	/**
	 * @see de.unika.ipd.grgen.ast.BaseNode#check()
	 */
	protected boolean check() {
		boolean lhsOk = checkChild(LHS, QualIdentNode.class);
		boolean rhsOk = checkChild(RHS, ExprNode.class);
		
		if(lhsOk) {
			QualIdentNode qual = (QualIdentNode) getChild(LHS);
			DeclNode owner = qual.getOwner();
			BaseNode ty = owner.getDeclType();
			
			if(ty instanceof InheritanceTypeNode) {
				InheritanceTypeNode inhTy = (InheritanceTypeNode) ty;
				
				if(inhTy.isConst()) {
					error.error(getCoords(), "assignment to a const type object not allowed");
					return false;
				}
			}
		}
		
		return lhsOk && rhsOk;
	}
	
	/**
	 * Construct the immediate representation from an assignment node.
	 * @see de.unika.ipd.grgen.ast.BaseNode#constructIR()
	 */
	protected IR constructIR() {
		Qualification qual = (Qualification) getChild(LHS).checkIR(Qualification.class);
		if(qual.getOwner() instanceof Node && ((Node)qual.getOwner()).typeChanges())
			error.error(getCoords(), "assignment to an old node of a type changed node is not allowed");
		return new Assignment(qual, (Expression) getChild(RHS).checkIR(Expression.class));
	}
	
}
