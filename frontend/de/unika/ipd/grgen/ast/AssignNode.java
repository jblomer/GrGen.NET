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

import java.util.Collection;
import java.util.Vector;
import de.unika.ipd.grgen.ast.util.SimpleChecker;
import de.unika.ipd.grgen.ir.Assignment;
import de.unika.ipd.grgen.ir.Edge;
import de.unika.ipd.grgen.ir.Expression;
import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.ir.Node;
import de.unika.ipd.grgen.ir.Qualification;
import de.unika.ipd.grgen.parser.Coords;

/**
 * AST node representing an assignment.
 * children: LHS:QualIdentNode, RHS:ExprNode
 */
public class AssignNode extends BaseNode
{
	static {
		setName(AssignNode.class, "Assign");
	}
		
	BaseNode lhs;
	BaseNode rhs;
	
	/**
	 * @param coords The source code coordinates of = operator.
	 * @param qual The left hand side.
	 * @param expr The expression, that is assigned.
	 */
	public AssignNode(Coords coords, BaseNode qual, BaseNode expr) {
		super(coords);
		this.lhs = qual==null ? NULL : qual;
		becomeParent(this.lhs);
		this.rhs = expr==null ? NULL : expr;
		becomeParent(this.rhs);
	}

	/** returns children of this node */
	public Collection<BaseNode> getChildren() {
		Vector<BaseNode> children = new Vector<BaseNode>();
		children.add(lhs);
		children.add(rhs);
		return children;
	}
	
	/** returns names of the children, same order as in getChildren */
	public Collection<String> getChildrenNames() {
		Vector<String> childrenNames = new Vector<String>();
		childrenNames.add("lhs");
		childrenNames.add("rhs");
		return childrenNames;
	}
	
	/** @see de.unika.ipd.grgen.ast.BaseNode#resolve() */
	protected boolean resolve() {
		if(isResolved()) {
			return resolutionResult();
		}
		
		debug.report(NOTE, "resolve in: " + getId() + "(" + getClass() + ")");
		boolean successfullyResolved = true;
		nodeResolvedSetResult(successfullyResolved); // local result
		
		successfullyResolved = lhs.resolve() && successfullyResolved;
		successfullyResolved = rhs.resolve() && successfullyResolved;
		return successfullyResolved;
	}

	/** @see de.unika.ipd.grgen.ast.BaseNode#check() */
	protected boolean check() {
		if(!resolutionResult()) {
			return false;
		}
		if(isChecked()) {
			return getChecked();
		}

		boolean childrenChecked = true;
		if(!visitedDuringCheck()) {
			setCheckVisited();
			
			childrenChecked = lhs.check() && childrenChecked;
			childrenChecked = rhs.check() && childrenChecked;
		}
		
		boolean locallyChecked = checkLocal();
		if(locallyChecked) {
			locallyChecked = typeCheckLocal();
		}
		nodeCheckedSetResult(locallyChecked );
		
		return childrenChecked && locallyChecked;
	}

	/** @see de.unika.ipd.grgen.ast.BaseNode#checkLocal() */
	protected boolean checkLocal() {
		boolean lhsOk = (new SimpleChecker(QualIdentNode.class)).check(lhs, error);
		boolean rhsOk = (new SimpleChecker(ExprNode.class)).check(rhs, error);
		
		if(lhsOk) {
			QualIdentNode qual = (QualIdentNode) lhs;
			DeclNode owner = qual.getOwner();
			BaseNode ty = owner.getDeclType();
			
			if(ty instanceof InheritanceTypeNode) {
				InheritanceTypeNode inhTy = (InheritanceTypeNode) ty;
				
				if(inhTy.isConst()) {
					error.error(getCoords(), "Assignment to a const type object not allowed");
					return false;
				}
			}
		}
		
		return lhsOk && rhsOk;
	}

	/**
	 * Checks whether the expression has a type equal, compatible or castable
	 * to the type of the target. Inserts implicit cast if compatible.
	 * @return true, if the types are equal or compatible, false otherwise
	 */
	protected boolean typeCheckLocal() {
		ExprNode expr = (ExprNode) rhs;
		
		TypeNode targetType = (TypeNode) ((QualIdentNode)lhs).getDecl().getDeclType();
		TypeNode exprType = (TypeNode) expr.getType();
		
		if (! exprType.isEqual(targetType)) {
			expr = expr.adjustType(targetType);
			becomeParent(expr);
			rhs = expr;

			if (expr == ConstNode.getInvalid()) {
				String msg;
				if (exprType.isCastableTo(targetType)) {
					msg = "Assignment of " + exprType + " to " + targetType + " without a cast";
				} else {
					msg = "Incompatible assignment from " + exprType + " to " + targetType;
				}
				error.error(getCoords(), msg);
				return false;
			}
		}
		return true;
	}

	/**
	 * Construct the immediate representation from an assignment node.
	 * @see de.unika.ipd.grgen.ast.BaseNode#constructIR()
	 */
	protected IR constructIR() {
		Qualification qual = (Qualification) lhs.checkIR(Qualification.class);
		if(qual.getOwner() instanceof Node && ((Node)qual.getOwner()).changesType()) {
			error.error(getCoords(), "Assignment to an old node of a type changed node is not allowed");
		}
		if(qual.getOwner() instanceof Edge && ((Edge)qual.getOwner()).changesType()) {
			error.error(getCoords(), "Assignment to an old edge of a type changed edge is not allowed");
		}
		return new Assignment(qual, (Expression) ((ExprNode)rhs).evaluate().checkIR(Expression.class));
	}
	
	// debug guards to protect again accessing wrong elements
	public void addChild(BaseNode n) {
		assert(false);
	}
	public void setChild(int pos, BaseNode n) {
		assert(false);
	}
	public BaseNode getChild(int i) {
		assert(false);
		return null;
	}
	public int children() {
		assert(false);
		return 0;
	}
	public BaseNode replaceChild(int i, BaseNode n) {
		assert(false);
		return null;
	}
}

