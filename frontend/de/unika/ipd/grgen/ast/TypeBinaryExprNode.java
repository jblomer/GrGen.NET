/*
 GrGen: graph rewrite generator tool.
 Copyright (C) 2007  IPD Goos, Universit"at Karlsruhe, Germany

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


package de.unika.ipd.grgen.ast;

import de.unika.ipd.grgen.ast.util.Checker;
import de.unika.ipd.grgen.ast.util.SimpleChecker;
import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.ir.TypeExpr;
import de.unika.ipd.grgen.ir.TypeExprSetOperator;
import de.unika.ipd.grgen.parser.Coords;
import java.util.Collection;
import java.util.Vector;

/**
 * AST node representing binary type expressions.
 */
public class TypeBinaryExprNode extends TypeExprNode {
	static {
		setName(TypeBinaryExprNode.class, "type binary expr");
	}

	TypeExprNode lhs;
	TypeExprNode rhs;

	public TypeBinaryExprNode(Coords coords, int op, TypeExprNode op0, TypeExprNode op1) {
		super(coords, op);
		this.lhs = op0;
		becomeParent(this.lhs);
		this.rhs = op1;
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

	protected boolean checkLocal() {
		// check the child node types
		boolean typesOk = true;
		Checker checker = new SimpleChecker(TypeExprNode.class);
		typesOk = checker.check(lhs, error) && typesOk;
		typesOk = checker.check(rhs, error) && typesOk;
		return typesOk;
	}

	protected IR constructIR() {
		TypeExpr lhs = (TypeExpr) this.lhs.checkIR(TypeExpr.class);
		TypeExpr rhs = (TypeExpr) this.rhs.checkIR(TypeExpr.class);

		TypeExprSetOperator expr = new TypeExprSetOperator(irOp[op]);
		expr.addOperand(lhs);
		expr.addOperand(rhs);

		return expr;
	}
}
