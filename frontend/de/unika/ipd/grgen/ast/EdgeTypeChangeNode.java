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
 * @author Sebastian Hack, Adam Szalkowski
 * @version $Id$
 */
package de.unika.ipd.grgen.ast;

import de.unika.ipd.grgen.ast.util.Checker;
import de.unika.ipd.grgen.ast.util.DeclResolver;
import de.unika.ipd.grgen.ast.util.Resolver;
import de.unika.ipd.grgen.ast.util.TypeChecker;
import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.ir.Edge;
import de.unika.ipd.grgen.ir.EdgeType;
import de.unika.ipd.grgen.ir.RetypedEdge;

/**
 *
 */
public class EdgeTypeChangeNode extends EdgeDeclNode implements EdgeCharacter
{
	static {
		setName(EdgeTypeChangeNode.class, "edge type change decl");
	}

	private static final int OLD = CONSTRAINTS + 1;
	
	private static final Resolver edgeResolver =
		new DeclResolver(new Class[] { EdgeDeclNode.class});
	
	private static final Checker edgeChecker =
		new TypeChecker(EdgeTypeNode.class);
		
	public EdgeTypeChangeNode(IdentNode id, BaseNode newType, BaseNode oldid) {

		super(id, newType, TypeExprNode.getEmpty());
		addChild(oldid);
	}

  	/** @see de.unika.ipd.grgen.ast.BaseNode#resolve() */
	protected boolean resolve() {
		if(isResolved()) {
			return resolutionResult();
		}
		
		debug.report(NOTE, "resolve in: " + getId() + "(" + getClass() + ")");
		boolean successfullyResolved = true;
		successfullyResolved = typeResolver.resolve(this, TYPE) && successfullyResolved;
		successfullyResolved = edgeResolver.resolve(this, OLD) && successfullyResolved;
		nodeResolvedSetResult(successfullyResolved); // local result
		if(!successfullyResolved) {
			debug.report(NOTE, "resolve error");
		}
		
		successfullyResolved = getChild(IDENT).resolve() && successfullyResolved;
		successfullyResolved = getChild(TYPE).resolve() && successfullyResolved;
		successfullyResolved = getChild(CONSTRAINTS).resolve() && successfullyResolved;
		successfullyResolved = getChild(OLD).resolve() && successfullyResolved;
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
		
		boolean successfullyChecked = checkLocal();
		nodeCheckedSetResult(successfullyChecked);
		if(successfullyChecked) {
			assert(!isTypeChecked());
			successfullyChecked = typeCheckLocal();
			nodeTypeCheckedSetResult(successfullyChecked);
		}
		
		successfullyChecked = getChild(IDENT).check() && successfullyChecked;
		successfullyChecked = getChild(TYPE).check() && successfullyChecked;
		successfullyChecked = getChild(CONSTRAINTS).check() && successfullyChecked;
		successfullyChecked = getChild(OLD).check() && successfullyChecked;
		return successfullyChecked;
	}
	
	/**
	 * @return the original edge for this retyped edge
	 */
	public EdgeCharacter getOldEdge() {
		return (EdgeCharacter) getChild(OLD);
	}

	public IdentNode getOldEdgeIdent() {
		if (getChild(OLD) instanceof IdentNode) {
			return (IdentNode) getChild(OLD);
		}
		if (getChild(OLD) instanceof EdgeDeclNode) {
			return ((EdgeDeclNode) getChild(OLD)).getIdentNode();
		}

		return IdentNode.getInvalid();
	}
  
	/**
	 * @see de.unika.ipd.grgen.ast.BaseEdge#checkLocal()
	 */
	protected boolean checkLocal() {
		return super.checkLocal() && checkChild(OLD, edgeChecker);
	}

	public Edge getEdge() {
		return (Edge) checkIR(Edge.class);
	}

	/**
	 * @see de.unika.ipd.grgen.ast.BaseEdge#constructIR()
	 */
	protected IR constructIR() {
		// This cast must be ok after checking.
		EdgeCharacter oldEdgeDecl = (EdgeCharacter) getChild(OLD);

		// This cast must be ok after checking.
		EdgeTypeNode etn = (EdgeTypeNode) getDeclType();
		EdgeType et = etn.getEdgeType();
		IdentNode ident = getIdentNode();

		RetypedEdge res = new RetypedEdge(ident.getIdent(), et, ident
				.getAttributes());

		Edge oldEdge = oldEdgeDecl.getEdge();
		oldEdge.setRetypedEdge(res);
		res.setOldEdge(oldEdge);

		if (inheritsType()) {
			res.setTypeof((Edge) getChild(TYPE).checkIR(Edge.class));
		}

		return res;
	}
}


