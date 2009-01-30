/*
 * GrGen: graph rewrite generator tool -- release GrGen.NET 2.1
 * Copyright (C) 2008 Universitaet Karlsruhe, Institut fuer Programmstrukturen und Datenorganisation, LS Goos
 * licensed under GPL v3 (see LICENSE.txt included in the packaging of this file)
 */

/**
 * ModelGen.java
 *
 * Generates the model files for the SearchPlanBackend2 backend.
 *
 * @author Moritz Kroll
 * @version $Id$
 */

package de.unika.ipd.grgen.be.Csharp;

import java.util.BitSet;
import java.util.Collection;
import java.util.Comparator;
import java.util.Date;
import java.util.HashSet;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.LinkedList;
import java.util.Map;
import java.util.Set;
import java.util.TreeSet;

import de.unika.ipd.grgen.ir.BooleanType;
import de.unika.ipd.grgen.ir.ConnAssert;
import de.unika.ipd.grgen.ir.DoubleType;
import de.unika.ipd.grgen.ir.EdgeType;
import de.unika.ipd.grgen.ir.Entity;
import de.unika.ipd.grgen.ir.EnumItem;
import de.unika.ipd.grgen.ir.EnumType;
import de.unika.ipd.grgen.ir.FloatType;
import de.unika.ipd.grgen.ir.InheritanceType;
import de.unika.ipd.grgen.ir.IntType;
import de.unika.ipd.grgen.ir.MapInit;
import de.unika.ipd.grgen.ir.MapItem;
import de.unika.ipd.grgen.ir.MapType;
import de.unika.ipd.grgen.ir.SetInit;
import de.unika.ipd.grgen.ir.SetItem;
import de.unika.ipd.grgen.ir.SetType;
import de.unika.ipd.grgen.ir.MemberInit;
import de.unika.ipd.grgen.ir.Model;
import de.unika.ipd.grgen.ir.NodeType;
import de.unika.ipd.grgen.ir.ObjectType;
import de.unika.ipd.grgen.ir.Qualification;
import de.unika.ipd.grgen.ir.StringType;
import de.unika.ipd.grgen.ir.Type;
import de.unika.ipd.grgen.ir.VoidType;

public class ModelGen extends CSharpBase {
	private final int MAX_OPERATIONS_FOR_ATTRIBUTE_INITIALIZATION_INLINING = 20;

	public ModelGen(SearchPlanBackend2 backend, String nodeTypePrefix, String edgeTypePrefix) {
		super(nodeTypePrefix, edgeTypePrefix);
		be = backend;
		rootTypes = new HashSet<String>();
		rootTypes.add("Node");
		rootTypes.add("Edge");
		rootTypes.add("AEdge");
		rootTypes.add("UEdge");
	}

	/**
	 * Generates the model sourcecode for the current unit.
	 */
	public void genModel(Model model) {
		this.model = model;
		sb = new StringBuffer();
		stubsb = null;

		String filename = model.getIdent() + "Model.cs";

		System.out.println("  generating the " + filename + " file...");

		sb.append("// This file has been generated automatically by GrGen.\n"
				+ "// Do not modify this file! Any changes will be lost!\n"
				+ "// Generated from \"" + be.unit.getFilename() + "\" on " + new Date() + "\n"
				+ "\n"
				+ "using System;\n"
				+ "using System.Collections.Generic;\n"
                + "using GRGEN_LIBGR = de.unika.ipd.grGen.libGr;\n"
                + "using GRGEN_LGSP = de.unika.ipd.grGen.lgsp;\n"
				+ "\n"
				+ "namespace de.unika.ipd.grGen.Model_" + model.getIdent() + "\n"
				+ "{\n"
				+ "\tusing GRGEN_MODEL = de.unika.ipd.grGen.Model_" + model.getIdent() + ";\n");

		System.out.println("    generating enums...");
		genEnums();

		System.out.println("    generating node types...");
		sb.append("\n");
		genTypes(model.getNodeTypes(), true);

		System.out.println("    generating node model...");
		sb.append("\n");
		genModelClass(model.getNodeTypes(), true);

		System.out.println("    generating edge types...");
		sb.append("\n");
		genTypes(model.getEdgeTypes(), false);

		System.out.println("    generating edge model...");
		sb.append("\n");
		genModelClass(model.getEdgeTypes(), false);

		System.out.println("    generating graph model...");
		sb.append("\n");
		genGraphModel();

		sb.append("}\n");

		writeFile(be.path, filename, sb);
		if(stubsb != null) {
			String stubFilename = model.getIdent() + "ModelStub.cs";
			System.out.println("  writing the " + stubFilename + " stub file...");
			writeFile(be.path, stubFilename, stubsb);
		}
	}

	private StringBuffer getStubBuffer() {
		if(stubsb == null) {
			stubsb = new StringBuffer();
			stubsb.append("// This file has been generated automatically by GrGen.\n"
					+ "// Do not modify this file! Any changes will be lost!\n"
					+ "// Rename this file or use a copy!\n"
					+ "// Generated from \"" + be.unit.getFilename() + "\" on " + new Date() + "\n"
					+ "\n"
					+ "using System;\n"
					+ "using System.Collections.Generic;\n"
					+ "using GRGEN_LIBGR = de.unika.ipd.grGen.libGr;\n"
					+ "using GRGEN_LGSP = de.unika.ipd.grGen.lgsp;\n"
					+ "using GRGEN_MODEL = de.unika.ipd.grGen.Model_" + model.getIdent() + ";\n");
		}
		return stubsb;
	}

	private void genEnums() {
		sb.append("\t//\n");
		sb.append("\t// Enums\n");
		sb.append("\t//\n");
		sb.append("\n");

		for(EnumType enumt : model.getEnumTypes()) {
			sb.append("\tpublic enum ENUM_" + formatIdentifiable(enumt) + " { ");
			for(EnumItem enumi : enumt.getItems()) {
				sb.append("@" + formatIdentifiable(enumi) + " = " + enumi.getValue().getValue() + ", ");
			}
			sb.append("};\n\n");
		}

		sb.append("\tpublic class Enums\n");
		sb.append("\t{\n");
		for(EnumType enumt : model.getEnumTypes()) {
			sb.append("\t\tpublic static GRGEN_LIBGR.EnumAttributeType @" + formatIdentifiable(enumt)
					+ " = new GRGEN_LIBGR.EnumAttributeType(\"" + formatIdentifiable(enumt)
					+ "\", typeof(GRGEN_MODEL.ENUM_" + formatIdentifiable(enumt)
					+ "), new GRGEN_LIBGR.EnumMember[] {\n");
			for(EnumItem enumi : enumt.getItems()) {
				sb.append("\t\t\tnew GRGEN_LIBGR.EnumMember(" + enumi.getValue().getValue()
						+ ", \"" + formatIdentifiable(enumi) + "\"),\n");
			}
			sb.append("\t\t});\n");
		}
		sb.append("\t}\n");
	}

	/**
	 * Generates code for all given element types.
	 */
	private void genTypes(Collection<? extends InheritanceType> types, boolean isNode) {
		sb.append("\t//\n");
		sb.append("\t// " + formatNodeOrEdge(isNode) + " types\n");
		sb.append("\t//\n");
		sb.append("\n");
		sb.append("\tpublic enum " + formatNodeOrEdge(isNode) + "Types ");
		genSet(sb, types, "@", "", true);
		sb.append(";\n");

		for(InheritanceType type : types) {
			genType(types, type);
		}
	}

	/**
	 * Generates all code for a given type.
	 */
	private void genType(Collection<? extends InheritanceType> types, InheritanceType type) {
		sb.append("\n");
		sb.append("\t// *** " + formatNodeOrEdge(type) + " " + formatIdentifiable(type) + " ***\n");
		sb.append("\n");

		if(!rootTypes.contains(type.getIdent().toString()))
			genElementInterface(type);
		if(!type.isAbstract())
			genElementImplementation(type);
		genTypeImplementation(types, type);
	}

	//////////////////////////////////
	// Element interface generation //
	//////////////////////////////////

	/**
	 * Generates the element interface for the given type
	 */
	private void genElementInterface(InheritanceType type) {
		String iname = "I" + getNodeOrEdgeTypePrefix(type) + formatIdentifiable(type);
		sb.append("\tpublic interface " + iname + " : ");
		genDirectSuperTypeList(type);
		sb.append("\n");
		sb.append("\t{\n");
		genAttributeAccess(type, type.getMembers(), "");
		sb.append("\t}\n");
	}

	/**
	 * Generate a list of direct supertypes of the given type.
	 */
	private void genDirectSuperTypeList(InheritanceType type) {
		boolean isNode = type instanceof NodeType;
		String elemKind = isNode ? "Node" : "Edge";

		String iprefix = "I" + getNodeOrEdgeTypePrefix(type);
		Collection<InheritanceType> directSuperTypes = type.getDirectSuperTypes();

		if(directSuperTypes.isEmpty())
		{
			sb.append("GRGEN_LIBGR.I" + formatNodeOrEdge(type));		// INode or IEdge
		}

		boolean hasRootType = false;
		boolean first = true;
		for(Iterator<InheritanceType> i = directSuperTypes.iterator(); i.hasNext(); ) {
			InheritanceType superType = i.next();
			if(rootTypes.contains(superType.getIdent().toString())) {
				// avoid problems with "extends Edge, AEdge" mapping to "IEdge, IEdge"
				if(hasRootType) continue;
				hasRootType = true;

				if(first) first = false;
				else sb.append(", ");
				sb.append("GRGEN_LIBGR.I" + elemKind);
			}
			else {
				if(first) first = false;
				else sb.append(", ");
				sb.append(iprefix + formatIdentifiable(superType));
			}
		}
	}

	/**
	 * Generate the attribute accessor declarations of the given members.
	 * @param type The type for which the accessors are to be generated.
	 * @param members A collection of member entities.
	 * @param modifiers A string which may contain modifiers to be applied to the accessors.
	 * 		It must either end with a space or be empty.
	 */
	private void genAttributeAccess(InheritanceType type, Collection<Entity> members,
			String modifiers) {
		for(Entity e : members) {
			sb.append("\t\t" + modifiers);
			if(type.getOverriddenMember(e) != null)
				sb.append("new ");
			if(e.isConst()) {
				sb.append(formatAttributeType(e) + " @" + formatIdentifiable(e) + " { get; }\n");
			} else {
				sb.append(formatAttributeType(e) + " @" + formatIdentifiable(e) + " { get; set; }\n");
			}
		}
	}

	///////////////////////////////////////
	// Element implementation generation //
	///////////////////////////////////////

	/**
	 * Generates the element implementation for the given type
	 */
	private void genElementImplementation(InheritanceType type) {
		boolean isNode = type instanceof NodeType;
		String elemKind = isNode ? "Node" : "Edge";
		String elemname = formatElementClassName(type);
		String elemref = formatElementClassRef(type);
		String extName = type.getExternalName();
		String allocName = extName != null ? "global::" + extName : elemref;
		String typeref = formatTypeClassRef(type);
		String ielemref = formatElementInterfaceRef(type);
		String namespace = null;
		StringBuffer routedSB = sb;
		String routedClassName = elemname;
		String routedDeclName = elemref;

		if(extName == null) {
			sb.append("\n\tpublic sealed class " + elemname + " : GRGEN_LGSP.LGSP"
					+ elemKind + ", " + ielemref + "\n\t{\n");
		}
		else { // what's that?
			routedSB = getStubBuffer();
			int lastDot = extName.lastIndexOf('.');
			String extClassName;
			if(lastDot != -1) {
				namespace = extName.substring(0, lastDot);
				extClassName = extName.substring(lastDot + 1);
				stubsb.append("\n"
						+ "namespace " + namespace + "\n"
						+ "{\n");
			}
			else extClassName = extName;
			routedClassName = extClassName;
			routedDeclName = extClassName;

			stubsb.append("\tpublic class " + extClassName + " : " + elemref + "\n"
					+ "\t{\n"
					+ "\t\tpublic " + extClassName + "() : base() { }\n\n");

			sb.append("\n\tpublic abstract class " + elemname + " : GRGEN_LGSP.LGSP"
					+ elemKind + ", " + ielemref + "\n\t{\n");
		}
		sb.append("\t\tprivate static int poolLevel = 0;\n"
				+ "\t\tprivate static " + elemref + "[] pool = new " + elemref + "[10];\n");

		// Static initialization for constants = static members
		initAllMembersConst(type, elemname, "this", "\t\t\t");

		// Generate constructor
		if(isNode) {
			sb.append("\t\tpublic " + elemname + "() : base("+ typeref + ".typeVar)\n"
					+ "\t\t{\n");
			initAllMembersNonConst(type, "this", "\t\t\t", false, false);
			sb.append("\t\t}\n\n");
		}
		else {
			sb.append("\t\tpublic " + elemname + "(GRGEN_LGSP.LGSPNode source, "
						+ "GRGEN_LGSP.LGSPNode target)\n"
					+ "\t\t\t: base("+ typeref + ".typeVar, source, target)\n"
					+ "\t\t{\n");
			initAllMembersNonConst(type, "this", "\t\t\t", false, false);
			sb.append("\t\t}\n\n");
		}

		// Generate static type getter
		sb.append("\t\tpublic static " + typeref + " TypeInstance { get { return " + typeref + ".typeVar; } }\n\n");

		// Generate the clone and copy constructor
		if(isNode)
			routedSB.append("\t\tpublic override GRGEN_LIBGR.INode Clone() { return new "
						+ routedDeclName + "(this); }\n"
					+ "\n"
					+ "\t\tprivate " + routedClassName + "(" + routedDeclName + " oldElem) : base("
					+ (extName == null ? typeref + ".typeVar" : "") + ")\n");
		else
			routedSB.append("\t\tpublic override GRGEN_LIBGR.IEdge Clone("
						+ "GRGEN_LIBGR.INode newSource, GRGEN_LIBGR.INode newTarget)\n"
					+ "\t\t{ return new " + routedDeclName + "(this, (GRGEN_LGSP.LGSPNode) newSource, "
						+ "(GRGEN_LGSP.LGSPNode) newTarget); }\n"
					+ "\n"
					+ "\t\tprivate " + routedClassName + "(" + routedDeclName
						+ " oldElem, GRGEN_LGSP.LGSPNode newSource, GRGEN_LGSP.LGSPNode newTarget)\n"
					+ "\t\t\t: base("
					+ (extName == null ? typeref + ".typeVar, " : "") + "newSource, newTarget)\n");
		routedSB.append("\t\t{\n");
		for(Entity member : type.getAllMembers()) {
			if(member.isConst())
				continue;

			String attrName = formatIdentifiable(member);
			if(member.getType() instanceof MapType || member.getType() instanceof SetType) {
				routedSB.append("\t\t\t_" + attrName + " = new " + formatAttributeType(member.getType())
						+ "(oldElem._" + attrName + ");\n");
			} else {
				routedSB.append("\t\t\t_" + attrName + " = oldElem._" + attrName + ";\n");
			}
		}
		routedSB.append("\t\t}\n");

		// Generate element creators
		if(isNode) {
			sb.append("\t\tpublic static " + elemref + " CreateNode(GRGEN_LGSP.LGSPGraph graph)\n"
					+ "\t\t{\n"
					+ "\t\t\t" + elemref + " node;\n"
					+ "\t\t\tif(poolLevel == 0)\n"
					+ "\t\t\t\tnode = new " + allocName + "();\n"
					+ "\t\t\telse\n"
					+ "\t\t\t{\n"
					+ "\t\t\t\tnode = pool[--poolLevel];\n"
					+ "\t\t\t\tnode.inhead = null;\n"
					+ "\t\t\t\tnode.outhead = null;\n"
					+ "\t\t\t\tnode.flags &= ~(uint) GRGEN_LGSP.LGSPElemFlags.HAS_VARIABLES;\n");
			initAllMembersNonConst(type, "node", "\t\t\t\t", true, false);
			sb.append("\t\t\t}\n"
					+ "\t\t\tgraph.AddNode(node);\n"
					+ "\t\t\treturn node;\n"
					+ "\t\t}\n\n"
					+ "\t\tpublic static " + elemref + " CreateNode(GRGEN_LGSP.LGSPGraph graph, string varName)\n"
					+ "\t\t{\n"
					+ "\t\t\t" + elemref + " node;\n"
					+ "\t\t\tif(poolLevel == 0)\n"
					+ "\t\t\t\tnode = new " + allocName + "();\n"
					+ "\t\t\telse\n"
					+ "\t\t\t{\n"
					+ "\t\t\t\tnode = pool[--poolLevel];\n"
					+ "\t\t\t\tnode.inhead = null;\n"
					+ "\t\t\t\tnode.outhead = null;\n"
					+ "\t\t\t\tnode.flags &= ~(uint) GRGEN_LGSP.LGSPElemFlags.HAS_VARIABLES;\n");
			initAllMembersNonConst(type, "node", "\t\t\t\t", true, false);
			sb.append("\t\t\t}\n"
					+ "\t\t\tgraph.AddNode(node, varName);\n"
					+ "\t\t\treturn node;\n"
					+ "\t\t}\n\n");
		}
		else {
			sb.append("\t\tpublic static " + elemref + " CreateEdge(GRGEN_LGSP.LGSPGraph graph, "
						+ "GRGEN_LGSP.LGSPNode source, GRGEN_LGSP.LGSPNode target)\n"
					+ "\t\t{\n"
					+ "\t\t\t" + elemref + " edge;\n"
					+ "\t\t\tif(poolLevel == 0)\n"
					+ "\t\t\t\tedge = new " + allocName + "(source, target);\n"
					+ "\t\t\telse\n"
					+ "\t\t\t{\n"
					+ "\t\t\t\tedge = pool[--poolLevel];\n"
					+ "\t\t\t\tedge.flags &= ~(uint) GRGEN_LGSP.LGSPElemFlags.HAS_VARIABLES;\n"
					+ "\t\t\t\tedge.source = source;\n"
					+ "\t\t\t\tedge.target = target;\n");
			initAllMembersNonConst(type, "edge", "\t\t\t\t", true, false);
			sb.append("\t\t\t}\n"
					+ "\t\t\tgraph.AddEdge(edge);\n"
					+ "\t\t\treturn edge;\n"
					+ "\t\t}\n\n"
					+ "\t\tpublic static " + elemref + " CreateEdge(GRGEN_LGSP.LGSPGraph graph, "
						+ "GRGEN_LGSP.LGSPNode source, GRGEN_LGSP.LGSPNode target, string varName)\n"
					+ "\t\t{\n"
					+ "\t\t\t" + elemref + " edge;\n"
					+ "\t\t\tif(poolLevel == 0)\n"
					+ "\t\t\t\tedge = new " + allocName + "(source, target);\n"
					+ "\t\t\telse\n"
					+ "\t\t\t{\n"
					+ "\t\t\t\tedge = pool[--poolLevel];\n"
					+ "\t\t\t\tedge.flags &= ~(uint) GRGEN_LGSP.LGSPElemFlags.HAS_VARIABLES;\n"
					+ "\t\t\t\tedge.source = source;\n"
					+ "\t\t\t\tedge.target = target;\n");
			initAllMembersNonConst(type, "edge", "\t\t\t\t", true, false);
			sb.append("\t\t\t}\n"
					+ "\t\t\tgraph.AddEdge(edge, varName);\n"
					+ "\t\t\treturn edge;\n"
					+ "\t\t}\n\n");
		}
		sb.append("\t\tpublic override void Recycle()\n"
				+ "\t\t{\n"
				+ "\t\t\tif(poolLevel < 10)\n"
				+ "\t\t\t\tpool[poolLevel++] = this;\n"
				+ "\t\t}\n\n");

		genAttributesAndAttributeAccessImpl(type);

		sb.append("\t}\n");

		if(extName != null) {
			stubsb.append(nsIndent + "}\n");		// close class stub
			if(namespace != null)
				stubsb.append("}\n");				// close namespace
		}
	}

	private void initAllMembersNonConst(InheritanceType type, String varName,
			String indentString, boolean withDefaultInits, boolean isResetAllAttributes) {
		curMemberOwner = varName;

		// if we don't currently create the method ResetAllAttributes
		// we replace the initialization code by a call to ResetAllAttributes, if it gets to large
		if(!isResetAllAttributes
				&& initializationOperationsCount(type) > MAX_OPERATIONS_FOR_ATTRIBUTE_INITIALIZATION_INLINING)
		{
			sb.append(indentString + varName +  ".ResetAllAttributes();\n");
			curMemberOwner = null;
			return;
		}

		sb.append(indentString + "// implicit initialization, map/set creation of " + formatIdentifiable(type) + "\n");

		// default attribute inits need to be generated if code must overwrite old values
		// only in constructor not needed, cause there taken care of by c#
		// if there is explicit initialization code, it's not needed, too,
		// but that's left for the compiler to optimize away
		if(withDefaultInits) {
			for(Entity member : type.getAllMembers()) {
				if(member.isConst())
					continue;

				Type t = member.getType();
				// handled down below, as maps/sets must be created independent of initialization
				if(t instanceof MapType || t instanceof SetType)
					continue;

				String attrName = formatIdentifiable(member);
				sb.append(indentString + varName + ".@" + attrName + " = ");
				if(t instanceof IntType || t instanceof DoubleType || t instanceof EnumType) {
					sb.append("0;\n");
				} else if(t instanceof FloatType) {
					sb.append("0f;\n");
				} else if(t instanceof BooleanType) {
					sb.append("false;\n");
				} else if(t instanceof StringType || t instanceof ObjectType || t instanceof VoidType) {
					sb.append("null;\n");
				} else {
					throw new IllegalArgumentException("Unknown Entity: " + member + "(" + t + ")");
				}
			}
		}

		// create maps and sets
		for(Entity member : type.getAllMembers()) {
			if(member.isConst())
				continue;

			Type t = member.getType();
			if(!(t instanceof MapType || t instanceof SetType))
				continue;

			String attrName = formatIdentifiable(member);
			sb.append(indentString + varName + ".@" + attrName + " = ");
			if(t instanceof MapType) {
				MapType mapType = (MapType) t;
				sb.append("new " + formatAttributeType(mapType) + "();\n");
			} else if(t instanceof SetType) {
				SetType setType = (SetType) t;
				sb.append("new " + formatAttributeType(setType) + "();\n");
			}
		}

		// generate the user defined initializations, first for super types
		for(InheritanceType superType : type.getAllSuperTypes())
			genMemberInitNonConst(superType, type, indentString, varName,
					withDefaultInits, isResetAllAttributes);
		// then for current type
		genMemberInitNonConst(type, type, indentString, varName,
				withDefaultInits, isResetAllAttributes);

		curMemberOwner = null;
	}

	private int initializationOperationsCount(InheritanceType targetType) {
		int initializationOperations = 0;

		// attribute initializations from super classes not overridden in target class
		for(InheritanceType superType : targetType.getAllSuperTypes()) {
member_init_loop:
			for(MemberInit memberInit : superType.getMemberInits()) {
				if(memberInit.getMember().isConst())
					continue;
				for(MemberInit tmi : targetType.getMemberInits()) {
					if(memberInit.getMember() == tmi.getMember())
						continue member_init_loop;
				}
				++initializationOperations;
			}
map_init_loop:
			for(MapInit mapInit : superType.getMapInits()) {
				if(mapInit.getMember().isConst())
					continue;
				for(MapInit tmi : targetType.getMapInits()) {
					if(mapInit.getMember() == tmi.getMember())
						continue map_init_loop;
				}
				initializationOperations += mapInit.getMapItems().size();
			}
set_init_loop:
			for(SetInit setInit : superType.getSetInits()) {
				if(setInit.getMember().isConst())
					continue;
				for(SetInit tsi : targetType.getSetInits()) {
					if(setInit.getMember() == tsi.getMember())
						continue set_init_loop;
				}
				initializationOperations += setInit.getSetItems().size();
			}
		}

		// attribute initializations of target class
		for(MemberInit memberInit : targetType.getMemberInits()) {
			if(!memberInit.getMember().isConst())
				++initializationOperations;
		}

		for(MapInit mapInit : targetType.getMapInits()) {
			if(!mapInit.getMember().isConst())
				initializationOperations += mapInit.getMapItems().size();
		}

		for(SetInit setInit : targetType.getSetInits()) {
			if(!setInit.getMember().isConst())
				initializationOperations += setInit.getSetItems().size();
		}

		return initializationOperations;
	}

	private void initAllMembersConst(InheritanceType type, String className,
			String varName, String indentString) {
		curMemberOwner = varName;

		List<String> staticInitializers = new LinkedList<String>();

		sb.append("\t\t\n");

		// generate the user defined initializations, first for super types
		for(InheritanceType superType : type.getAllSuperTypes())
			genMemberInitConst(superType, type, staticInitializers);
		// then for current type
		genMemberInitConst(type, type, staticInitializers);

		sb.append("\t\tstatic " + className + "() {\n");
		for(String staticInit : staticInitializers) {
			sb.append("\t\t\t" + staticInit + "();\n");
		}
		sb.append("\t\t}\n");

		sb.append("\t\t\n");

		curMemberOwner = null;
	}

	private void genMemberInitNonConst(InheritanceType type, InheritanceType targetType,
			String indentString, String varName,
			boolean withDefaultInits, boolean isResetAllAttributes) {
		if(rootTypes.contains(type.getIdent().toString())) // skip root types, they don't possess attributes
			return;
		sb.append(indentString + "// explicit initializations of " + formatIdentifiable(type) + " for target " + formatIdentifiable(targetType) + "\n");

		// init members of primitive value with explicit initialization
member_init_loop:
		for(MemberInit memberInit : type.getMemberInits()) {
			if(memberInit.getMember().isConst())
				continue;

			if(type!=targetType) { // don't generate superclass init if target type contains own init
				for(MemberInit tmi : targetType.getMemberInits()) {
					if(memberInit.getMember() == tmi.getMember())
						continue member_init_loop;
				}
			}

			String attrName = formatIdentifiable(memberInit.getMember());
			sb.append(indentString + varName + ".@" + attrName + " = ");
			genExpression(sb, memberInit.getExpression(), null);
			sb.append(";\n");
		}

		// init members of map value with explicit initialization
map_init_loop:
		for(MapInit mapInit : type.getMapInits()) {
			if(mapInit.getMember().isConst())
				continue;

			if(type!=targetType) { // don't generate superclass init if target type contains own init
				for(MapInit tmi : targetType.getMapInits()) {
					if(mapInit.getMember() == tmi.getMember())
						continue map_init_loop;
				}
			}

			String attrName = formatIdentifiable(mapInit.getMember());
			for(MapItem item : mapInit.getMapItems()) {
				sb.append(indentString + varName + ".@" + attrName + "[");
				genExpression(sb, item.getKeyExpr(), null);
				sb.append("] = ");
				genExpression(sb, item.getValueExpr(), null);
				sb.append(";\n");
			}
		}

		// init members of set value with explicit initialization
set_init_loop:
		for(SetInit setInit : type.getSetInits()) {
			if(setInit.getMember().isConst())
				continue;

			if(type!=targetType) { // don't generate superclass init if target type contains own init
				for(SetInit tsi : targetType.getSetInits()) {
					if(setInit.getMember() == tsi.getMember())
						continue set_init_loop;
				}
			}

			String attrName = formatIdentifiable(setInit.getMember());
			for(SetItem item : setInit.getSetItems()) {
				sb.append(indentString + varName + ".@" + attrName + "[");
				genExpression(sb, item.getValueExpr(), null);
				sb.append("] = null;\n");
			}
		}
	}

	private void genMemberInitConst(InheritanceType type, InheritanceType targetType,
			List<String> staticInitializers) {
		if(rootTypes.contains(type.getIdent().toString())) // skip root types, they don't possess attributes
			return;
		sb.append("\t\t// explicit initializations of " + formatIdentifiable(type) + " for target " + formatIdentifiable(targetType) + "\n");

		HashSet<Entity> initializedConstMembers = new HashSet<Entity>();

		// init const members of primitive value with explicit initialization
member_init_loop:
		for(MemberInit memberInit : type.getMemberInits()) {
			Entity member = memberInit.getMember();
			if(!member.isConst())
				continue;

			if(type!=targetType) { // don't generate superclass init if target type contains own init
				for(MemberInit tmi : targetType.getMemberInits()) {
					if(member == tmi.getMember())
						continue member_init_loop;
				}
			}

			String attrType = formatAttributeType(member);
			String attrName = formatIdentifiable(member);
			sb.append("\t\tprivate static readonly " + attrType + " _" + attrName + " = ");
			genExpression(sb, memberInit.getExpression(), null);
			sb.append(";\n");

			initializedConstMembers.add(member);
		}

		// init const members of map value with explicit initialization
map_init_loop:
		for(MapInit mapInit : type.getMapInits()) {
			Entity member = mapInit.getMember();
			if(!member.isConst())
				continue;

			if(type!=targetType) { // don't generate superclass init if target type contains own init
				for(MapInit tmi : targetType.getMapInits()) {
					if(member == tmi.getMember())
						continue map_init_loop;
				}
			}

			String attrType = formatAttributeType(member);
			String attrName = formatIdentifiable(member);
			sb.append("\t\tprivate static readonly " + attrType + " _" + attrName + " = " +
					"new " + attrType + "();\n");
			staticInitializers.add("init_" + attrName);
			sb.append("\t\tstatic void init_" + attrName + "() {\n");
			for(MapItem item : mapInit.getMapItems()) {
				sb.append("\t\t\t");
				sb.append("_" + attrName);
				sb.append("[");
				genExpression(sb, item.getKeyExpr(), null);
				sb.append("] = ");
				genExpression(sb, item.getValueExpr(), null);
				sb.append(";\n");
			}
			sb.append("\t\t}\n");

			initializedConstMembers.add(member);
		}

		// init const members of set value with explicit initialization
set_init_loop:
		for(SetInit setInit : type.getSetInits()) {
			Entity member = setInit.getMember();
			if(!member.isConst())
				continue;

			if(type!=targetType) { // don't generate superclass init if target type contains own init
				for(SetInit tsi : targetType.getSetInits()) {
					if(member == tsi.getMember())
						continue set_init_loop;
				}
			}

			String attrType = formatAttributeType(member);
			String attrName = formatIdentifiable(member);
			sb.append("\t\tprivate static readonly " + attrType + " _" + attrName + " = " +
					"new " + attrType + "();\n");
			staticInitializers.add("init_" + attrName);
			sb.append("\t\tstatic void init_" + attrName + "() {\n");
			for(SetItem item : setInit.getSetItems()) {
				sb.append("\t\t\t");
				sb.append("_" + attrName);
				sb.append("[");
				genExpression(sb, item.getValueExpr(), null);
				sb.append("] = null;\n");
			}
			sb.append("\t\t}\n");

			initializedConstMembers.add(member);
		}

		sb.append("\t\t// implicit initializations of " + formatIdentifiable(type) + " for target " + formatIdentifiable(targetType) + "\n");

member_loop:
		for(Entity member : type.getMembers()) {
			if(!member.isConst()) continue;
			if(initializedConstMembers.contains(member)) continue;

			if(type != targetType) { // don't generate superclass init if target type contains own init
				for(MemberInit tmi : targetType.getMemberInits()) {
					if(member == tmi.getMember())
						continue member_loop;
				}
			}

			Type memberType = member.getType();
			String attrType = formatAttributeType(member);
			String attrName = formatIdentifiable(member);

			if(memberType instanceof MapType || memberType instanceof SetType)
				sb.append("\t\tprivate static readonly " + attrType + " _" + attrName + " = " +
						"new " + attrType + "();\n");
			else
				sb.append("\t\tprivate static readonly " + attrType + " _" + attrName + ";\n");
		}
	}

	protected void genQualAccess(StringBuffer sb, Qualification qual, Object modifyGenerationState) {
		Entity owner = qual.getOwner();
		sb.append("((I" + getNodeOrEdgeTypePrefix(owner) +
				formatIdentifiable(owner.getType()) + ") ");
		sb.append(formatEntity(owner) + ").@" + formatIdentifiable(qual.getMember()));
	}

	protected void genMemberAccess(StringBuffer sb, Entity member) {
		if(curMemberOwner != null)
			sb.append(curMemberOwner + ".");
		sb.append("@" + formatIdentifiable(member));
	}


	/**
	 * Generate the attribute accessor implementations of the given type
	 */
	private void genAttributesAndAttributeAccessImpl(InheritanceType type) {
		StringBuffer routedSB = sb;
		String extName = type.getExternalName();
		String extModifier = "";

		// what's that?
		if(extName != null) {
			routedSB = getStubBuffer();
			extModifier = "override ";

			genAttributeAccess(type, type.getAllMembers(), "public abstract ");
		}

		// Create the implementation of the attributes.
		// If an external name is given for this type, this is written
		// into the stub file with an "override" modifier on the accessors.

		// member, getter, setter for attributes
		for(Entity e : type.getAllMembers()) {
			String attrType = formatAttributeType(e);
			String attrName = formatIdentifiable(e);

			if(e.isConst()) {
				// no member for const attributes, no setter for const attributes
				// they are class static, the member is created at the point of initialization
				routedSB.append("\t\tpublic " + extModifier + attrType + " @" + attrName + "\n");
				routedSB.append("\t\t{\n");
				routedSB.append("\t\t\tget { return _" + attrName + "; }\n");
				routedSB.append("\t\t}\n");
			} else {
				// member, getter, setter for non-const attributes
				routedSB.append("\n\t\tprivate " + attrType + " _" + attrName + ";\n");
				routedSB.append("\t\tpublic " + extModifier + attrType + " @" + attrName + "\n");
				routedSB.append("\t\t{\n");
				routedSB.append("\t\t\tget { return _" + attrName + "; }\n");
				routedSB.append("\t\t\tset { _" + attrName + " = value; }\n");
				routedSB.append("\t\t}\n");
			}

			// what's that?
			Entity overriddenMember = type.getOverriddenMember(e);
			if(overriddenMember != null) {
				routedSB.append("\n\t\tobject "
						+ formatElementInterfaceRef((InheritanceType) overriddenMember.getOwner())
						+ ".@" + attrName + "\n"
						+ "\t\t{\n"
						+ "\t\t\tget { return _" + attrName + "; }\n"
						+ "\t\t\tset { _" + attrName + " = (" + attrType + ") value; }\n"
						+ "\t\t}\n");
			}
		}

		// get attribute by name
		sb.append("\t\tpublic override object GetAttribute(string attrName)\n");
		sb.append("\t\t{\n");
		if(type.getAllMembers().size() != 0) {
			sb.append("\t\t\tswitch(attrName)\n");
			sb.append("\t\t\t{\n");
			for(Entity e : type.getAllMembers()) {
				String name = formatIdentifiable(e);
				sb.append("\t\t\t\tcase \"" + name + "\": return this.@" + name + ";\n");
			}
			sb.append("\t\t\t}\n");
		}
		sb.append("\t\t\tthrow new NullReferenceException(\n");
		sb.append("\t\t\t\t\"The " + (type instanceof NodeType ? "node" : "edge")
				+ " type \\\"" + formatIdentifiable(type)
				+ "\\\" does not have the attribute \\\" + attrName + \\\"\\\"!\");\n");
		sb.append("\t\t}\n");

		// set attribute by name
		sb.append("\t\tpublic override void SetAttribute(string attrName, object value)\n");
		sb.append("\t\t{\n");
		if(type.getAllMembers().size() != 0) {
			sb.append("\t\t\tswitch(attrName)\n");
			sb.append("\t\t\t{\n");
			for(Entity e : type.getAllMembers()) {
				String name = formatIdentifiable(e);
				if(e.isConst()) {
					sb.append("\t\t\t\tcase \"" + name + "\": ");
					sb.append("throw new NullReferenceException(");
					sb.append("\"The attribute " + name + " of the " + (type instanceof NodeType ? "node" : "edge")
							+ " type \\\"" + formatIdentifiable(type)
							+ "\\\" is read only!\");\n");
				} else {
					sb.append("\t\t\t\tcase \"" + name + "\": this.@" + name + " = ("
							+ formatAttributeType(e) + ") value; return;\n");
				}
			}
			sb.append("\t\t\t}\n");
		}
		sb.append("\t\t\tthrow new NullReferenceException(\n");
		sb.append("\t\t\t\t\"The " + (type instanceof NodeType ? "node" : "edge")
				+ " type \\\"" + formatIdentifiable(type)
				+ "\\\" does not have the attribute \\\" + attrName + \\\"\\\"!\");\n");
		sb.append("\t\t}\n");

		// reset all attributes
		sb.append("\t\tpublic override void ResetAllAttributes()\n");
		sb.append("\t\t{\n");
		initAllMembersNonConst(type, "this", "\t\t\t", true, true);
		sb.append("\t\t}\n");
	}

	////////////////////////////////////
	// Type implementation generation //
	////////////////////////////////////

	/**
	 * Generates the type implementation
	 */
	private void genTypeImplementation(Collection<? extends InheritanceType> types, InheritanceType type) {
		String typeident = formatIdentifiable(type);
		String typename = formatTypeClassName(type);
		String typeref = formatTypeClassRef(type);
		String elemref = formatElementClassRef(type);
		String extName = type.getExternalName();
		String allocName = extName != null ? "global::" + extName : elemref;
		boolean isNode = type instanceof NodeType;
		String elemKind = isNode ? "Node" : "Edge";

		sb.append("\n");
		sb.append("\tpublic sealed class " + typename + " : GRGEN_LIBGR." + elemKind + "Type\n");
		sb.append("\t{\n");
		sb.append("\t\tpublic static " + typeref + " typeVar = new " + typeref + "();\n");
		genIsA(types, type);
		genIsMyType(types, type);
		genAttributeAttributes(type);
		sb.append("\t\tpublic " + typename + "() : base((int) " + formatNodeOrEdge(type) + "Types.@" + typeident + ")\n");
		sb.append("\t\t{\n");
		genAttributeInit(type);
		sb.append("\t\t}\n");
		sb.append("\t\tpublic override string Name { get { return \"" + typeident + "\"; } }\n");

		if(isNode) {
			sb.append("\t\tpublic override GRGEN_LIBGR.INode CreateNode()\n"
					+ "\t\t{\n");
			if(type.isAbstract())
				sb.append("\t\t\tthrow new Exception(\"The abstract node type "
						+ typeident + " cannot be instantiated!\");\n");
			else
				sb.append("\t\t\treturn new " + allocName + "();\n");
			sb.append("\t\t}\n");
		}
		else {
			EdgeType edgeType = (EdgeType) type;
			sb.append("\t\tpublic override GRGEN_LIBGR.Directedness Directedness "
					+ "{ get { return GRGEN_LIBGR.Directedness.");
			switch(edgeType.getDirectedness()) {
				case Arbitrary:
					sb.append("Arbitrary; } }\n");
					break;
				case Directed:
					sb.append("Directed; } }\n");
					break;
				case Undirected:
					sb.append("Undirected; } }\n");
					break;
				default:
					throw new UnsupportedOperationException("Illegal directedness of edge type \""
							+ formatIdentifiable(type) + "\"");
			}
			sb.append("\t\tpublic override GRGEN_LIBGR.IEdge CreateEdge("
						+ "GRGEN_LIBGR.INode source, GRGEN_LIBGR.INode target)\n"
					+ "\t\t{\n");
			if(type.isAbstract())
				sb.append("\t\t\tthrow new Exception(\"The abstract edge type "
						+ typeident + " cannot be instantiated!\");\n");
			else
				sb.append("\t\t\treturn new " + allocName
						+ "((GRGEN_LGSP.LGSPNode) source, (GRGEN_LGSP.LGSPNode) target);\n");
			sb.append("\t\t}\n");
		}

		sb.append("\t\tpublic override bool IsAbstract { get { return " + (type.isAbstract() ? "true" : "false") + "; } }\n");
		sb.append("\t\tpublic override bool IsConst { get { return " + (type.isConst() ? "true" : "false") + "; } }\n");

		sb.append("\t\tpublic override int NumAttributes { get { return " + type.getAllMembers().size() + "; } }\n");
		genAttributeTypesEnum(type);
		genGetAttributeType(type);

		sb.append("\t\tpublic override bool IsA(GRGEN_LIBGR.GrGenType other)\n");
		sb.append("\t\t{\n");
		sb.append("\t\t\treturn (this == other) || isA[other.TypeID];\n");
		sb.append("\t\t}\n");

		genCreateWithCopyCommons(type);
		sb.append("\t}\n");
	}

	private void genIsA(Collection<? extends InheritanceType> types, InheritanceType type) {
		sb.append("\t\tpublic static bool[] isA = new bool[] { ");
		for(InheritanceType nt : types) {
			if(type.isCastableTo(nt))
				sb.append("true, ");
			else
				sb.append("false, ");
		}
		sb.append("};\n");
	}

	private void genIsMyType(Collection<? extends InheritanceType> types, InheritanceType type) {
		sb.append("\t\tpublic static bool[] isMyType = new bool[] { ");
		for(InheritanceType nt : types) {
			if(nt.isCastableTo(type))
				sb.append("true, ");
			else
				sb.append("false, ");
		}
		sb.append("};\n");
	}

	private void genAttributeAttributes(InheritanceType type) {
		for(Entity member : type.getMembers()) // only for locally defined members
			sb.append("\t\tpublic static GRGEN_LIBGR.AttributeType " + formatAttributeTypeName(member) + ";\n");
	}

	private void genAttributeInit(InheritanceType type) {
		for(Entity e : type.getMembers()) {
			sb.append("\t\t\t" + formatAttributeTypeName(e) + " = new GRGEN_LIBGR.AttributeType(");
			sb.append("\"" + formatIdentifiable(e) + "\", this, ");
			Type t = e.getType();

			if (t instanceof EnumType) {
				sb.append(getAttributeKind(t) + ", GRGEN_MODEL.Enums.@" + formatIdentifiable(t) +", "
						+ getAttributeKind(t) + ", " + getAttributeKind(t));
			} else if (t instanceof MapType) {
				MapType mt = (MapType)t;
				sb.append(getAttributeKind(t) + ", null, "
						+ getAttributeKind(mt.getValueType()) + ", " + getAttributeKind(mt.getKeyType()));
			} else if (t instanceof SetType) {
				SetType st = (SetType)t;
				sb.append(getAttributeKind(t) + ", null, "
						+ getAttributeKind(st.getValueType()) + ", " + getAttributeKind(st.getValueType()));
			} else {
				sb.append(getAttributeKind(t) + ", null, "
						+ getAttributeKind(t) + ", " + getAttributeKind(t));
			}

			sb.append(");\n");
		}
	}

	private String getAttributeKind(Type t) {
		if (t instanceof IntType)
			return "GRGEN_LIBGR.AttributeKind.IntegerAttr";
		else if (t instanceof FloatType)
			return "GRGEN_LIBGR.AttributeKind.FloatAttr";
		else if (t instanceof DoubleType)
			return "GRGEN_LIBGR.AttributeKind.DoubleAttr";
		else if (t instanceof BooleanType)
			return "GRGEN_LIBGR.AttributeKind.BooleanAttr";
		else if (t instanceof StringType)
			return "GRGEN_LIBGR.AttributeKind.StringAttr";
		else if (t instanceof EnumType)
			return "GRGEN_LIBGR.AttributeKind.EnumAttr";
		else if (t instanceof ObjectType || t instanceof VoidType)
			return "GRGEN_LIBGR.AttributeKind.ObjectAttr";
		else if (t instanceof MapType)
			return "GRGEN_LIBGR.AttributeKind.MapAttr";
		else if (t instanceof SetType)
			return "GRGEN_LIBGR.AttributeKind.SetAttr";
		else throw new IllegalArgumentException("Unknown Type: " + t);
	}

	private void genAttributeTypesEnum(InheritanceType type) {
		Collection<Entity> allMembers = type.getAllMembers();
		sb.append("\t\tpublic override IEnumerable<GRGEN_LIBGR.AttributeType> AttributeTypes");

		if(allMembers.isEmpty())
			sb.append(" { get { yield break; } }\n");
		else {
			sb.append("\n\t\t{\n");
			sb.append("\t\t\tget\n");
			sb.append("\t\t\t{\n");
			for(Entity e : allMembers) {
				Type ownerType = e.getOwner();
				if(ownerType == type)
					sb.append("\t\t\t\tyield return " + formatAttributeTypeName(e) + ";\n");
				else
					sb.append("\t\t\t\tyield return " + formatTypeClassRef(ownerType) + "." + formatAttributeTypeName(e) + ";\n");
			}
			sb.append("\t\t\t}\n");
			sb.append("\t\t}\n");
		}
	}

	private void genGetAttributeType(InheritanceType type) {
		Collection<Entity> allMembers = type.getAllMembers();
		sb.append("\t\tpublic override GRGEN_LIBGR.AttributeType GetAttributeType(string name)");

		if(allMembers.isEmpty())
			sb.append(" { return null; }\n");
		else {
			sb.append("\n\t\t{\n");
			sb.append("\t\t\tswitch(name)\n");
			sb.append("\t\t\t{\n");
			for(Entity e : allMembers) {
				Type ownerType = e.getOwner();
				if(ownerType == type)
					sb.append("\t\t\t\tcase \"" + formatIdentifiable(e) + "\" : return " +
							formatAttributeTypeName(e) + ";\n");
				else
					sb.append("\t\t\t\tcase \"" + formatIdentifiable(e) + "\" : return " +
							formatTypeClassRef(ownerType) + "." + formatAttributeTypeName(e) + ";\n");
			}
			sb.append("\t\t\t}\n");
			sb.append("\t\t\treturn null;\n");
			sb.append("\t\t}\n");
		}
	}

	private void getFirstCommonAncestors(InheritanceType curType,
			InheritanceType type, Set<InheritanceType> resTypes) {
		if(type.isCastableTo(curType))
			resTypes.add(curType);
		else
			for(InheritanceType superType : curType.getDirectSuperTypes())
				getFirstCommonAncestors(superType, type, resTypes);
	}

	private void genCreateWithCopyCommons(InheritanceType type) {
		boolean isNode = type instanceof NodeType;
		String elemref = formatElementClassRef(type);
		String extName = type.getExternalName();
		String allocName = extName != null ? "global::" + extName : elemref;
		String kindName = isNode ? "Node" : "Edge";

		if(isNode) {
			sb.append("\t\tpublic override GRGEN_LIBGR.INode CreateNodeWithCopyCommons("
						+ "GRGEN_LIBGR.INode oldINode)\n"
					+ "\t\t{\n");
		}
		else {
			sb.append("\t\tpublic override GRGEN_LIBGR.IEdge CreateEdgeWithCopyCommons("
						+ "GRGEN_LIBGR.INode source, GRGEN_LIBGR.INode target, "
						+ "GRGEN_LIBGR.IEdge oldIEdge)\n"
					+ "\t\t{\n");
		}

		if(type.isAbstract()) {
			sb.append("\t\t\tthrow new Exception(\"Cannot retype to the abstract type "
					+ formatIdentifiable(type) + "!\");\n"
					+ "\t\t}\n");
			return;
		}

		Map<BitSet, LinkedList<InheritanceType>> commonGroups = new LinkedHashMap<BitSet, LinkedList<InheritanceType>>();

		Collection<? extends InheritanceType> typeSet =
			isNode ? (Collection<? extends InheritanceType>) model.getNodeTypes()
			: (Collection<? extends InheritanceType>) model.getEdgeTypes();
		for(InheritanceType itype : typeSet) {
			if(itype.isAbstract()) continue;

			Set<InheritanceType> firstCommonAncestors = new LinkedHashSet<InheritanceType>();
			getFirstCommonAncestors(itype, type, firstCommonAncestors);

			TreeSet<InheritanceType> sortedCommonTypes = new TreeSet<InheritanceType>(
				new Comparator<InheritanceType>() {
					public int compare(InheritanceType o1, InheritanceType o2) {
						return o2.getMaxDist() - o1.getMaxDist();
					}
				});

			sortedCommonTypes.addAll(firstCommonAncestors);
			Iterator<InheritanceType> iter = sortedCommonTypes.iterator();
			while(iter.hasNext()) {
				InheritanceType commonType = iter.next();
				if(!firstCommonAncestors.contains(commonType)) continue;
				for(InheritanceType superType : commonType.getAllSuperTypes()) {
					firstCommonAncestors.remove(superType);
				}
			}

			boolean mustCopyAttribs = false;
commonLoop:	for(InheritanceType commonType : firstCommonAncestors) {
				for(Entity member : commonType.getAllMembers()) {
					if(member.getType().isVoid())   // is it an abstract member?
						continue;
					mustCopyAttribs = true;
					break commonLoop;
				}
			}

			if(!mustCopyAttribs) continue;

			BitSet commonTypesBitset = new BitSet();
			for(InheritanceType commonType : firstCommonAncestors) {
				commonTypesBitset.set(commonType.getTypeID());
			}
			LinkedList<InheritanceType> commonList = commonGroups.get(commonTypesBitset);
			if(commonList == null) {
				commonList = new LinkedList<InheritanceType>();
				commonGroups.put(commonTypesBitset, commonList);
			}
			commonList.add(itype);
		}

		if(commonGroups.size() != 0) {
			if(isNode)
				sb.append("\t\t\tGRGEN_LGSP.LGSPNode oldNode = (GRGEN_LGSP.LGSPNode) oldINode;\n"
						+ "\t\t\t" + elemref + " newNode = new " + allocName + "();\n");
			else
				sb.append("\t\t\tGRGEN_LGSP.LGSPEdge oldEdge = (GRGEN_LGSP.LGSPEdge) oldIEdge;\n"
						+ "\t\t\t" + elemref + " newEdge = new " + allocName
						+ "((GRGEN_LGSP.LGSPNode) source, (GRGEN_LGSP.LGSPNode) target);\n");
			sb.append("\t\t\tswitch(old" + kindName + ".Type.TypeID)\n"
					+ "\t\t\t{\n");
			for(Map.Entry<BitSet, LinkedList<InheritanceType>> entry : commonGroups.entrySet()) {
				for(InheritanceType itype : entry.getValue()) {
					sb.append("\t\t\t\tcase (int) " + kindName + "Types.@"
							+ formatIdentifiable(itype) + ":\n");
				}
				BitSet bitset = entry.getKey();
				HashSet<Entity> copiedAttribs = new HashSet<Entity>();
				for(int i = bitset.nextSetBit(0); i >= 0; i = bitset.nextSetBit(i+1)) {
					InheritanceType commonType = InheritanceType.getByTypeID(i);
					Collection<Entity> members = commonType.getAllMembers();
					if(members.size() != 0) {
						sb.append("\t\t\t\t\t// copy attributes for: "
								+ formatIdentifiable(commonType) + "\n");
						boolean alreadyCasted = false;
						for(Entity member : members) {
							if(member.isConst()) {
								sb.append("\t\t\t\t\t\t// is const: " + formatIdentifiable(member) + "\n");
								continue;
							}
							if(member.getType().isVoid()) {
								sb.append("\t\t\t\t\t\t// is abstract: " + formatIdentifiable(member) + "\n");
								continue;
							}
							if(copiedAttribs.contains(member)) {
								sb.append("\t\t\t\t\t\t// already copied: " + formatIdentifiable(member) + "\n");
								continue;
							}
							if(!alreadyCasted) {
								alreadyCasted = true;
								sb.append("\t\t\t\t\t{\n\t\t\t\t\t\t"
										+ formatVarDeclWithCast(formatElementInterfaceRef(commonType), "old")
										+ "old" + kindName + ";\n");
							}
							copiedAttribs.add(member);
							String memberName = formatIdentifiable(member);
							// what's that?
							if(type.getOverriddenMember(member) != null) {
								// Workaround for Mono Bug 357287
								// "Access to hiding properties of interfaces resolves wrong member"
								// https://bugzilla.novell.com/show_bug.cgi?id=357287
								sb.append("\t\t\t\t\t\tnew" + kindName + ".@" + memberName
										+ " = (" + formatAttributeType(member) + ") old.@" + memberName
										+ ";   // Mono workaround (bug #357287)\n");
							} else {
								if(member.getType() instanceof MapType || member.getType() instanceof SetType) {
									sb.append("\t\t\t\t\t\tnew" + kindName + ".@" + memberName
											+ " = new " + formatAttributeType(member.getType()) + "(old.@" + memberName + ");\n");
								} else {
									sb.append("\t\t\t\t\t\tnew" + kindName + ".@" + memberName
											+ " = old.@" + memberName + ";\n");
								}
							}
						}
						if(alreadyCasted)
							sb.append("\t\t\t\t\t}\n");
					}
				}
				sb.append("\t\t\t\t\tbreak;\n");
			}
			sb.append("\t\t\t}\n"
					+ "\t\t\treturn new" + kindName + ";\n"
					+ "\t\t}\n\n");
		}
		else {
			if(isNode) {
				sb.append("\t\t\treturn new " + allocName + "();\n"
					+ "\t\t}\n\n");
			} else {
				sb.append("\t\t\treturn new " + allocName
						+ "((GRGEN_LGSP.LGSPNode) source, (GRGEN_LGSP.LGSPNode) target);\n"
					+ "\t\t}\n\n");
			}
		}
	}

	////////////////////////////
	// Model class generation //
	////////////////////////////

	/**
	 * Generates the model class for the edge or node types.
	 */
	private void genModelClass(Collection<? extends InheritanceType> types, boolean isNode) {
		sb.append("\t//\n");
		sb.append("\t// " + formatNodeOrEdge(isNode) + " model\n");
		sb.append("\t//\n");
		sb.append("\n");
		sb.append("\tpublic sealed class " + model.getIdent() + formatNodeOrEdge(isNode)
				+ "Model : GRGEN_LIBGR.I" + (isNode ? "Node" : "Edge") + "Model\n");
		sb.append("\t{\n");

		InheritanceType rootType = genModelConstructor(isNode, types);

		sb.append("\t\tpublic bool IsNodeModel { get { return " + (isNode?"true":"false") +"; } }\n");
		sb.append("\t\tpublic GRGEN_LIBGR." + (isNode ? "Node" : "Edge") + "Type RootType { get { return "
				+ formatTypeClassRef(rootType) + ".typeVar; } }\n");
		sb.append("\t\tGRGEN_LIBGR.GrGenType GRGEN_LIBGR.ITypeModel.RootType { get { return "
				+ formatTypeClassRef(rootType) + ".typeVar; } }\n");
		sb.append("\t\tpublic GRGEN_LIBGR." + (isNode ? "Node" : "Edge") + "Type GetType(string name)\n");
		sb.append("\t\t{\n");
		sb.append("\t\t\tswitch(name)\n");
		sb.append("\t\t\t{\n");
		for(InheritanceType type : types)
			sb.append("\t\t\t\tcase \"" + formatIdentifiable(type) + "\" : return " + formatTypeClassRef(type) + ".typeVar;\n");
		sb.append("\t\t\t}\n");
		sb.append("\t\t\treturn null;\n");
		sb.append("\t\t}\n");
		sb.append("\t\tGRGEN_LIBGR.GrGenType GRGEN_LIBGR.ITypeModel.GetType(string name)\n");
		sb.append("\t\t{\n");
		sb.append("\t\t\treturn GetType(name);\n");
		sb.append("\t\t}\n");

		String elemKind = isNode ? "Node" : "Edge";
		sb.append("\t\tprivate GRGEN_LIBGR." + elemKind + "Type[] types = {\n");
		for(InheritanceType type : types)
			sb.append("\t\t\t" + formatTypeClassRef(type) + ".typeVar,\n");
		sb.append("\t\t};\n");
		sb.append("\t\tpublic GRGEN_LIBGR." + elemKind + "Type[] Types { get { return types; } }\n");
		sb.append("\t\tGRGEN_LIBGR.GrGenType[] GRGEN_LIBGR.ITypeModel.Types "
				+ "{ get { return types; } }\n");

		sb.append("\t\tprivate Type[] typeTypes = {\n");
		for(InheritanceType type : types)
			sb.append("\t\t\ttypeof(" + formatTypeClassRef(type) + "),\n");
		sb.append("\t\t};\n");
		sb.append("\t\tpublic Type[] TypeTypes { get { return typeTypes; } }\n");

		sb.append("\t\tprivate GRGEN_LIBGR.AttributeType[] attributeTypes = {\n");
		for(InheritanceType type : types) {
			String ctype = formatTypeClassRef(type);
			for(Entity member : type.getMembers())
				sb.append("\t\t\t" + ctype + "." + formatAttributeTypeName(member) + ",\n");
		}
		sb.append("\t\t};\n");
		sb.append("\t\tpublic IEnumerable<GRGEN_LIBGR.AttributeType> AttributeTypes "
				+ "{ get { return attributeTypes; } }\n");

		sb.append("\t}\n");
	}

	private InheritanceType genModelConstructor(boolean isNode, Collection<? extends InheritanceType> types) {
		InheritanceType rootType = null;

		sb.append("\t\tpublic " + model.getIdent() + formatNodeOrEdge(isNode) + "Model()\n");
		sb.append("\t\t{\n");
		for(InheritanceType type : types) {
			String ctype = formatTypeClassRef(type);
			sb.append("\t\t\t" + ctype + ".typeVar.subOrSameGrGenTypes = "
					+ ctype + ".typeVar.subOrSameTypes = new GRGEN_LIBGR."
					+ (isNode ? "Node" : "Edge") + "Type[] {\n");
			sb.append("\t\t\t\t" + ctype + ".typeVar,\n");
			for(InheritanceType otherType : types) {
				if(type != otherType && otherType.isCastableTo(type))
					sb.append("\t\t\t\t" + formatTypeClassRef(otherType) + ".typeVar,\n");
			}
			sb.append("\t\t\t};\n");

			sb.append("\t\t\t" + ctype + ".typeVar.directSubGrGenTypes = "
					+ ctype + ".typeVar.directSubTypes = new GRGEN_LIBGR."
					+ (isNode ? "Node" : "Edge") + "Type[] {\n");
			for(InheritanceType subType : type.getDirectSubTypes()) {
				// TODO: HACK, because direct sub types may also contain types from other models...
				if(!types.contains(subType))
					continue;
				sb.append("\t\t\t\t" + formatTypeClassRef(subType) + ".typeVar,\n");
			}
			sb.append("\t\t\t};\n");

			sb.append("\t\t\t" + ctype + ".typeVar.superOrSameGrGenTypes = "
					+ ctype + ".typeVar.superOrSameTypes = new GRGEN_LIBGR."
					+ (isNode ? "Node" : "Edge") + "Type[] {\n");
			sb.append("\t\t\t\t" + ctype + ".typeVar,\n");
			for(InheritanceType otherType : types) {
				if(type != otherType && type.isCastableTo(otherType))
					sb.append("\t\t\t\t" + formatTypeClassRef(otherType) + ".typeVar,\n");
			}
			sb.append("\t\t\t};\n");

			sb.append("\t\t\t" + ctype + ".typeVar.directSuperGrGenTypes = "
					+ ctype + ".typeVar.directSuperTypes = new GRGEN_LIBGR."
					+ (isNode ? "Node" : "Edge") + "Type[] {\n");
			for(InheritanceType superType : type.getDirectSuperTypes()) {
				sb.append("\t\t\t\t" + formatTypeClassRef(superType) + ".typeVar,\n");
			}
			sb.append("\t\t\t};\n");

			if(type.isRoot())
				rootType = type;
		}
		sb.append("\t\t}\n");

		return rootType;
	}

	/**
	 * Generates the graph model class.
	 */
	private void genGraphModel() {
		String modelName = model.getIdent().toString();
		sb.append("\t//\n");
		sb.append("\t// IGraphModel implementation\n");
		sb.append("\t//\n");
		sb.append("\n");

		sb.append("\tpublic sealed class " + modelName + "GraphModel : GRGEN_LIBGR.IGraphModel\n");
		sb.append("\t{\n");
		genGraphModelBody(modelName);
		sb.append("\t}\n");

		sb.append("\t//\n");
		sb.append("\t// IGraph/IGraphModel implementation\n");
		sb.append("\t//\n");
		sb.append("\n");

		sb.append(
			  "\tpublic class " + modelName + " : GRGEN_LGSP.LGSPGraph, GRGEN_LIBGR.IGraphModel\n"
			+ "\t{\n"
			+ "\t\tpublic " + modelName + "() : base(GetNextGraphName())\n"
			+ "\t\t{\n"
			+ "\t\t\tInitializeGraph(this);\n"
			+ "\t\t}\n\n"
		);

		for(NodeType nodeType : model.getNodeTypes()) {
			if(nodeType.isAbstract()) continue;
			String name = formatIdentifiable(nodeType);
			String elemref = formatElementClassRef(nodeType);
			sb.append(
				  "\t\tpublic " + elemref + " CreateNode" + name + "()\n"
				+ "\t\t{\n"
				+ "\t\t\treturn " + elemref + ".CreateNode(this);\n"
				+ "\t\t}\n\n"
				+ "\t\tpublic " + elemref + " CreateNode" + name + "(string varName)\n"
				+ "\t\t{\n"
				+ "\t\t\treturn " + elemref + ".CreateNode(this, varName);\n"
				+ "\t\t}\n\n"
			);
		}

		for(EdgeType edgeType : model.getEdgeTypes()) {
			if(edgeType.isAbstract()) continue;
			String name = formatIdentifiable(edgeType);
			String elemref = formatElementClassRef(edgeType);
			sb.append(
				  "\t\tpublic @" + elemref + " CreateEdge" + name
					+ "(GRGEN_LGSP.LGSPNode source, GRGEN_LGSP.LGSPNode target)\n"
				+ "\t\t{\n"
				+ "\t\t\treturn @" + elemref + ".CreateEdge(this, source, target);\n"
				+ "\t\t}\n\n"
				+ "\t\tpublic @" + elemref + " CreateEdge" + name
					+ "(GRGEN_LGSP.LGSPNode source, GRGEN_LGSP.LGSPNode target, string varName)\n"
				+ "\t\t{\n"
				+ "\t\t\treturn @" + elemref + ".CreateEdge(this, source, target, varName);\n"
				+ "\t\t}\n\n"
			);
		}

		genGraphModelBody(modelName);
		sb.append("\t}\n");
	}

	private void genGraphModelBody(String modelName) {
		sb.append("\t\tprivate " + modelName + "NodeModel nodeModel = new " + modelName + "NodeModel();\n");
		sb.append("\t\tprivate " + modelName + "EdgeModel edgeModel = new " + modelName + "EdgeModel();\n");
		genValidate();
		genEnumAttributeTypeArray();
		sb.append("\n");

		sb.append("\t\tpublic string ModelName { get { return \"" + modelName + "\"; } }\n");
		sb.append("\t\tpublic GRGEN_LIBGR.INodeModel NodeModel { get { return nodeModel; } }\n");
		sb.append("\t\tpublic GRGEN_LIBGR.IEdgeModel EdgeModel { get { return edgeModel; } }\n");
		sb.append("\t\tpublic IEnumerable<GRGEN_LIBGR.ValidateInfo> ValidateInfo "
				+ "{ get { return validateInfos; } }\n");
		sb.append("\t\tpublic IEnumerable<GRGEN_LIBGR.EnumAttributeType> EnumAttributeTypes "
				+ "{ get { return enumAttributeTypes; } }\n");
		sb.append("\t\tpublic string MD5Hash { get { return \"" + be.unit.getTypeDigest() + "\"; } }\n");
	}

	private void genValidate() {
		sb.append("\t\tprivate GRGEN_LIBGR.ValidateInfo[] validateInfos = {\n");

		for(EdgeType edgeType : model.getEdgeTypes()) {
			for(ConnAssert ca : edgeType.getConnAsserts()) {
				sb.append("\t\t\tnew GRGEN_LIBGR.ValidateInfo(");
				sb.append(formatTypeClassRef(edgeType) + ".typeVar, ");
				sb.append(formatTypeClassRef(ca.getSrcType()) + ".typeVar, ");
				sb.append(formatTypeClassRef(ca.getTgtType()) + ".typeVar, ");
				sb.append(formatLong(ca.getSrcLower()) + ", ");
				sb.append(formatLong(ca.getSrcUpper()) + ", ");
				sb.append(formatLong(ca.getTgtLower()) + ", ");
				sb.append(formatLong(ca.getTgtUpper()));
				sb.append("),\n");
			}
		}

		sb.append("\t\t};\n");
	}

	private void genEnumAttributeTypeArray() {
		sb.append("\t\tprivate GRGEN_LIBGR.EnumAttributeType[] enumAttributeTypes = {\n");
		for(EnumType enumt : model.getEnumTypes()) {
			sb.append("\t\t\tGRGEN_MODEL.Enums.@" + formatIdentifiable(enumt) + ",\n");
		}
		sb.append("\t\t};\n");
	}

	///////////////////////
	// Private variables //
	///////////////////////

	private SearchPlanBackend2 be;
	private Model model;
	private StringBuffer sb = null;
	private StringBuffer stubsb = null;
	private String curMemberOwner = null;
	private String nsIndent = "\t";
	private HashSet<String> rootTypes;
}

