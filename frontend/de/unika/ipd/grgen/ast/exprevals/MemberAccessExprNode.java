/*
 * GrGen: graph rewrite generator tool -- release GrGen.NET 3.6
 * Copyright (C) 2003-2013 Universitaet Karlsruhe, Institut fuer Programmstrukturen und Datenorganisation, LS Goos; and free programmers
 * licensed under LGPL v3 (see LICENSE.txt included in the packaging of this file)
 * www.grgen.net
 */

/**
 * @author Moritz Kroll
 */

package de.unika.ipd.grgen.ast.exprevals;

import java.util.Collection;
import java.util.Vector;

import de.unika.ipd.grgen.ast.*;
import de.unika.ipd.grgen.ast.util.DeclarationResolver;
import de.unika.ipd.grgen.ir.Entity;
import de.unika.ipd.grgen.ir.exprevals.GraphEntityExpression;
import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.ir.exprevals.MatchAccess;
import de.unika.ipd.grgen.ir.exprevals.Qualification;
import de.unika.ipd.grgen.ir.UntypedExecVarType;
import de.unika.ipd.grgen.parser.Coords;

public class MemberAccessExprNode extends ExprNode
{
	static {
		setName(MemberAccessExprNode.class, "member access expression");
	}

	private ExprNode targetExpr; // resulting from primary expression, most often an IdentExprNode
	private IdentNode memberIdent;
	private MemberDeclNode member;

	public MemberAccessExprNode(Coords coords, ExprNode targetExpr, IdentNode memberIdent) {
		super(coords);
		this.targetExpr  = becomeParent(targetExpr);
		this.memberIdent = becomeParent(memberIdent);
	}

	@Override
	public Collection<? extends BaseNode> getChildren() {
		Vector<BaseNode> children = new Vector<BaseNode>();
		if(isResolved() && resolutionResult() && targetExpr.getType() instanceof MatchTypeNode) {
			return children; // behave like a nop in case we're a match access
		}
		children.add(targetExpr);
		children.add(memberIdent);
		return children;
	}

	@Override
	public Collection<String> getChildrenNames() {
		Vector<String> childrenNames = new Vector<String>();
		childrenNames.add("targetExpr");
		childrenNames.add("memberIdent");
		return childrenNames;
	}

	private static final DeclarationResolver<MemberDeclNode> memberResolver
	        = new DeclarationResolver<MemberDeclNode>(MemberDeclNode.class);

	@Override
	protected boolean resolveLocal() {
		if(!targetExpr.resolve()) return false;

		TypeNode ownerType = targetExpr.getType();
		
		if(ownerType instanceof MatchTypeNode) {
			return true; // behave like a nop in case we're a match access
		}
		
		if(!(ownerType instanceof ScopeOwner)) {
			reportError("Left hand side of '.' has no members.");
			return false;
		}

		if(!(ownerType instanceof InheritanceTypeNode)) {
			reportError("Only member access of nodes and edges supported.");
			return false;
		}

		ScopeOwner o = (ScopeOwner) ownerType;
		o.fixupDefinition(memberIdent);
		member = memberResolver.resolve(memberIdent, this);

		return member != null;
	}

	@Override
	protected boolean checkLocal() {
		if(targetExpr instanceof MethodInvocationExprNode) {
			reportError("Can't access attributes of graph elements returned from method invocation (i.e. peek(); node/edge typed sets/maps are only to be accessed by the eval statements add() and rem().)");
			return false;
		}

		return true;
	}

	protected final ExprNode getTarget() {
		return targetExpr; // resulting from primary expression, most often an IdentExprNode
	}

	protected final MemberDeclNode getDecl() {
		assert isResolved();

		return member;
	}

	@Override
	public TypeNode getType() {
		if(targetExpr.getType() instanceof MatchTypeNode) {
			return new UntypedExecVarTypeNode(); // behave like a nop in case we're a match access
		}

		return member.getDecl().getDeclType();
	}

	@Override
	protected IR constructIR() {
		if(targetExpr.getType() instanceof MatchTypeNode)
			return new MatchAccess((UntypedExecVarType) new UntypedExecVarTypeNode().getType()); // behave like a nop in case we're a match access
		return new Qualification(targetExpr.checkIR(GraphEntityExpression.class).getGraphEntity(), member.checkIR(Entity.class));
	}

	public static String getKindStr() {
		return "member";
	}

	public static String getUseStr() {
		return "member access";
	}
}