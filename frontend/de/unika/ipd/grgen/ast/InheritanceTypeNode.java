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

import de.unika.ipd.grgen.ast.util.*;

import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.ir.InheritanceType;
import de.unika.ipd.grgen.ir.MemberInit;
import de.unika.ipd.grgen.ir.NodeType;
import java.util.Collection;
import java.util.HashSet;

/**
 * Base class for compound types, that allow inheritance.
 */
public abstract class InheritanceTypeNode extends CompoundTypeNode {

	public static final int MOD_CONST = 1;

	public static final int MOD_ABSTRACT = 2;

	private static final int EXTENDS = 0;

	private static final int BODY = 1;


	private static final String[] childrenNames = {
		"extends", "body"
	};

	private static final Checker bodyChecker =
		new CollectChecker(new SimpleChecker(new Class[] {MemberDeclNode.class, MemberInitNode.class}));

	private static final Resolver bodyResolver =
		new CollectResolver(new DeclResolver(new Class[] {MemberDeclNode.class, MemberInitNode.class}));

	/**
	 * The modifiers for this type.
	 * An ORed combination of the constants above.
	 */
	private int modifiers = 0;

	/** The inheritance checker. */
	private final Checker inhChecker;

	private static final Checker myInhChecker =
		new CollectChecker(new SimpleChecker(InheritanceTypeNode.class));

	/**
	 * @param bodyIndex Index of the body collect node.
	 * @param inhIndex Index of the inheritance types collect node.
	 */
	protected InheritanceTypeNode(CollectNode ext,
								  CollectNode body,
								  Checker inhChecker,
								  Resolver inhResolver) {

		super(BODY, bodyChecker, bodyResolver);
		this.inhChecker = inhChecker;

		addChild(ext);
		addChild(body);

		setChildrenNames(childrenNames);
		addResolver(EXTENDS, inhResolver);
	}

	public boolean isA(InheritanceTypeNode type) {
		if (
			   (this instanceof NodeTypeNode) && !(type instanceof NodeTypeNode)
		) return false;

		if (
			   (this instanceof EdgeTypeNode) && !(type instanceof EdgeTypeNode)
		) return false;

		Collection<BaseNode> superTypes = new HashSet<BaseNode>();
		superTypes.add(this);

		boolean changed;
		do {
			changed = false;
			if ( superTypes.contains(type) ) return true;
			for (BaseNode x : superTypes) {
				InheritanceTypeNode t = (InheritanceTypeNode) x;
				Collection<BaseNode> dsts = t.getDirectSuperTypes();
				changed = superTypes.addAll(dsts) || changed;
			}
		}
		while (changed);

		return false;
	}

	/**
	 * @see de.unika.ipd.grgen.ast.BaseNode#check()
	 */
	protected boolean check() {
		return super.check()
			&& checkChild(EXTENDS, myInhChecker)
			&& checkChild(EXTENDS, inhChecker);
	}

	/**
	 * @see de.unika.ipd.grgen.ast.ScopeOwner#fixupDefinition(de.unika.ipd.grgen.ast.IdentNode)
	 */
	public boolean fixupDefinition(IdentNode id) {
		boolean found = super.fixupDefinition(id, false);

		if(!found) {

			for(BaseNode n : getChild(EXTENDS).getChildren()) {
				InheritanceTypeNode t = (InheritanceTypeNode)n;
				boolean result = t.fixupDefinition(id);

				if(found && result)
					reportError("Identifier " + id + " is ambiguous");

				found = found || result;
			}
		}

		return found;
	}

	protected void doGetCompatibleToTypes(Collection<TypeNode> coll) {
		for(BaseNode n : getChild(EXTENDS).getChildren()) {
			InheritanceTypeNode inh = (InheritanceTypeNode)n;
			coll.add(inh);
			inh.getCompatibleToTypes(coll);
		}
	}

	/**
	 * @see de.unika.ipd.grgen.ast.TypeNode#doGetCastableToTypes(java.util.Collection)
	 */
	/*	protected void doGetCastableToTypes(Collection<TypeNode> coll) {
	 // TODO This is wrong!!!
	 for(BaseNode n : getChild(inhIndex).getChildren())
	 coll.add((TypeNode)n);
	 } */


	public void setModifiers(int modifiers) {
		this.modifiers = modifiers;
	}

	public final boolean isAbstract() {
		return (modifiers & MOD_ABSTRACT) != 0;
	}

	public final boolean isConst() {
		return (modifiers & MOD_CONST) != 0;
	}

	protected final int getIRModifiers() {
		return (isAbstract() ? InheritanceType.ABSTRACT : 0)
			| (isConst() ? InheritanceType.CONST : 0);
	}


	public Collection<BaseNode> getDirectSuperTypes() {
		return getChild(EXTENDS).getChildren();
	}

	protected void constructIR(InheritanceType inhType) {
		for(BaseNode n : getChild(BODY).getChildren()) {
			if(n instanceof DeclNode) {
				DeclNode decl = (DeclNode)n;
				inhType.addMember(decl.getEntity());
			}
			else if(n instanceof MemberInitNode) {
				MemberInitNode mi = (MemberInitNode)n;
				inhType.addMemberInit((MemberInit)mi.getIR());
			}
		}
		for(BaseNode n : getChild(EXTENDS).getChildren()) {
			InheritanceTypeNode x = (InheritanceTypeNode)n;
			inhType.addDirectSuperType((InheritanceType)x.getType());
		}

		// to check overwriting of attributes
		inhType.getAllMembers();
	}
}
