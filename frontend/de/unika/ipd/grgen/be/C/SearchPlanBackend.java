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


/*********************************************************************************
 * This file contains the code generator for firm-internal graph rewriting
 *********************************************************************************/


/**
 * A GrGen Backend which generates C code for a frame-based
 * graph model impl and a frame based graph matcher
 * @author Veit Batz, Rubino Geiss, Andreas Schoesser
 * @version $Id$
 */

package de.unika.ipd.grgen.be.C;

import java.io.File;
import java.io.PrintStream;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Set;

import de.unika.ipd.grgen.Sys;
import de.unika.ipd.grgen.be.Backend;
import de.unika.ipd.grgen.be.BackendFactory;
import de.unika.ipd.grgen.ir.Assignment;
import de.unika.ipd.grgen.ir.Constant;
import de.unika.ipd.grgen.ir.Edge;
import de.unika.ipd.grgen.ir.EdgeType;
import de.unika.ipd.grgen.ir.Entity;
import de.unika.ipd.grgen.ir.Expression;
import de.unika.ipd.grgen.ir.Graph;
import de.unika.ipd.grgen.ir.InheritanceType;
import de.unika.ipd.grgen.ir.Node;
import de.unika.ipd.grgen.ir.NodeType;
import de.unika.ipd.grgen.ir.Operator;
import de.unika.ipd.grgen.ir.PatternGraph;
import de.unika.ipd.grgen.ir.Qualification;
import de.unika.ipd.grgen.ir.Rule;
import de.unika.ipd.grgen.ir.Type;
import de.unika.ipd.grgen.ir.Unit;

public class SearchPlanBackend extends MoreInformationCollector implements Backend, BackendFactory {
	private static final int nodesInUse = 1;
	private static final int edgesInUse = 2;

	private final String MODE_EDGE_NAME = "has_mode";

	protected final boolean emit_subgraph_info = false;

	private enum GraphType
	{
		Pattern,
		Negative,
		Replacement
	}

	/* binary operator symbols of the C-language */
	// ATTENTION: the forst two shift operations are signed shifts
	// 		the second right shift is signed. This Backend simply gens
	//		C-bitwise-shift-operations on signed integers, for simplicity ;-)
	private String[] opSymbols = {
		null, "||", "&&", "|", "^", "&",
			"==", "!=", "<", "<=", ">", ">=", "<<", ">>", ">>", "+",
			"-", "*", "/", "%", null, null, null, null
	};


	// --------------------------------------------------
	// Generates a Id for a Pattern node and saves it for
	// later usage.
	// --------------------------------------------------

	private class IdGenerator<T> {
		ArrayList<T> list = new ArrayList<T>();
		Set<T> set = new HashSet<T>();
		int startIndex = 0;

		public void setStartIndex(int startIndex)
		{
			if(list.size() > 0)
			{
				System.out.println("startIndex cannot be changed after elements have been added!");
				return;
			}

			this.startIndex = startIndex;
		}

		private int computeId(T elem) {
			if(!set.contains(elem)) {
				set.add(elem);
				list.add(elem);
			}
			return (list.indexOf(elem) + startIndex);
		}

		private boolean isKnown(T elem) {
			return set.contains(elem);
		}

		public int getMaxIndex()
		{
			return (list.size() + startIndex - 1);
		}

		public boolean contains(T elem)
		{
			return(set.contains(elem));
		}
	}



	/* ------------------------------------------
	 * Create a new backend.
	 * @return A new backend.
	 * ------------------------------------------ */

	public Backend getBackend() {
		return this;
	}



	/* ---------------------------------------------------------------------------------------------------------
	 * Initializes the FrameBasedBackend
	 * @see de.unika.ipd.grgen.be.Backend#init(de.unika.ipd.grgen.ir.Unit, de.unika.ipd.grgen.Sys, java.io.File)
	 * --------------------------------------------------------------------------------------------------------- */

	public void init(Unit unit, Sys system, File outputPath) {
		super.init(unit, system, outputPath);
//		this.unit = unit;
//		this.path = outputPath;
//		this.system = system;
//		path.mkdirs();
	}



	/* ----------------------------------------------------
	 * Starts the C-code Genration of the FrameBasedBackend
	 * @see de.unika.ipd.grgen.be.Backend#generate()
	 * ---------------------------------------------------- */

	public void generate()
	{
		// Emit an include file for Makefiles
		PrintStream ps = openFile("unit.mak");
		ps.println("#\n# generated by grgen, don't edit\n#");
		ps.println("UNIT_NAME = " + formatId(unit.getUnitName()));
		closeFile(ps);

		System.out.println("The frame-based GrGen backend...");
		System.out.println("  generating the pattern...");

		// Fill the StringBuffer to be written as a file
		StringBuffer sb = new StringBuffer();
		sb.append("/* generated by grgen, don't edit */\n\n");
		sb.append("#include <assert.h>\n");
		sb.append("#include \"firm.h\"\n");
		sb.append("#include \"grs.h\"\n");
		sb.append("#include \"ia32_new_nodes.h\"\n");
		sb.append("#include \"simd/firm_node_ext.h\"\n\n");

		findModeType();
		findConstType();
		genTypes(sb);
		genPatterns(sb);
		genInterface(sb);
		writeFile("gen_patterns.c", sb);

		System.out.println("  generating XML overview...");

		// write an overview of all generated Ids
		ps = openFile("overview.xml");
		writeOverview(ps);
		closeFile(ps);

		System.out.println("  done!");
	}



	/* -------------------------------------------------------------------
	 * Method findModeType
	 *
	 * Look for the generic 'Mode' node that serves as a supertype for all
	 * FIRM modes;
	 * ------------------------------------------------------------------- */

    NodeType MODE_TYPE;
	public void findModeType()
	{
	 	for(NodeType node : nodeTypeMap.keySet())
			if(node.getIdent().toString().equals("Mode")) {
				MODE_TYPE = node;
				return;
			}
		System.out.println("Warning: MODE_TYPE not found!");
	}



	/* -------------------------------------------
	 * Method findConstType
	 *
	 * Look up some other node types we need later
	 * when dumping conditions and evals.
	 * ------------------------------------------ */

	NodeType CONST_TYPE = null;
	NodeType VPROJ_TYPE = null;
	NodeType PROJ_TYPE  = null;
	NodeType MULTIPLE_ADD_TYPE = null;
	NodeType IA32_SUB = null;

	EdgeType DF = null;

	public void findConstType()
	{
	 	for(NodeType node : nodeTypeMap.keySet())
		{
			if(node.getIdent().toString().equals("Const"))
				CONST_TYPE = node;
			if(node.getIdent().toString().equals("VProj"))
				VPROJ_TYPE = node;
			if(node.getIdent().toString().equals("Proj"))
				PROJ_TYPE = node;
			if(node.getIdent().toString().equals("MultipleAdd"))
				MULTIPLE_ADD_TYPE = node;
			if(node.getIdent().toString().equals("ia32_Sub"))
				IA32_SUB = node;
		}
		if(CONST_TYPE == null)
			System.out.println("Warning: CONST_TYPE not found!");
		if(VPROJ_TYPE == null)
			System.out.println("Warning: VPROJ_TYPE not found!");
		if(PROJ_TYPE == null)
			System.out.println("Warning: PROJ_TYPE not found!");
		if(IA32_SUB == null)
			System.out.println("Warning: IA32_SUB not found!");

		for(EdgeType edge : edgeTypeMap.keySet())
		{
			if(edge.getIdent().toString().equals("df"))
				DF = edge;
		}
		if(DF == null)
			System.out.println("Warning: DF not found!");
	}



	/* ---------------------------------------------------------------
	 * Method genTypes
	 *
	 * Generates all FIRM ops. Creates a new one if the FIRM op is not
	 * existing, or uses the existing one.
	 * @param    sb		  a  StringBuffer
	 * --------------------------------------------------------------- */

	private void genTypes(StringBuffer sb)
	{
		String indent = "\t";
		StringBuffer initsb = new StringBuffer();
		sb.append("/* nodeTypeMap */ \n");
		initsb.append("/* init node ops and modes */\n");
		initsb.append("static void init(void) {\n");
		for(NodeType nodeType : nodeTypeMap.keySet()) {
			if(!nodeType.isCastableTo(MODE_TYPE))
			{
				// Only dump nodes that are real FIRM nodes
				// => Skip the pseudo "Mode"-Nodes
				String type = nodeType.getIdent().toString();
				sb.append("ir_op* grs_op_" + type + ";\n");
				initsb.append(indent+"grs_op_" + type + " = ext_grs_lookup_op(\""+ type +"\");\n");
				initsb.append(indent+"grs_op_" + type + " = grs_op_" + type +
							  	" ? grs_op_" + type + " : new_ir_op(get_next_ir_opcode(), \"" +
							  	type + "\", op_pin_state_pinned,  irop_flag_none, oparity_dynamic,  0, 0, NULL);\n");
			}
		}
		sb.append("/* nodeTypeMap END */\n\n");
		initsb.append("} /* init node ops and modes */\n\n");
		sb.append(initsb);
	}



	/* ------------------------------------------------------------------
	 * Method genPatterns generates the patterns needed by the seach plan
	 * builder. It consists mainly of the left hand side of the rule.
	 *
	 * @param    sb		  a  StringBuffer
	 * ------------------------------------------------------------------ */

	private void genPatterns(StringBuffer sb)
	{
		String indent = "\t";
		for(Rule action : unit.getActionRules()) {
			if(action.getRight() != null) {

				String actionName = action.getIdent().toString();

				StringBuffer sb2 = new StringBuffer(); // append pattern after condition
				IdGenerator<Node> nodeIds = new IdGenerator<Node>(); // To generate uique numbers per rule
				IdGenerator<Edge> edgeIds = new IdGenerator<Edge>();

				sb2.append("/* functions for building the pattern of action " + actionName + " */\n");
				sb2.append("static INLINE ext_grs_action_t *grs_action_" + actionName + "_init(void) {\n");
				sb2.append(indent + "ext_grs_action_t *act = ext_grs_new_action(ext_grs_k_rule, \"" +
							   actionName + "\");\n");
				sb2.append(indent + "int check;\n");

				genPattern(sb2, action, nodeIds, edgeIds);

				sb2.append(indent + "check = ext_grs_act_mature(act);\n");
				sb2.append(indent + "assert(check);\n");
				sb2.append(indent + "return act;\n");
				sb2.append("} /* " + actionName + " */\n\n\n");

				genConditionFunctions(sb, indent, actionName, action, nodeIds, edgeIds);
				genEvalFunctions(sb, indent, action, nodeIds, edgeIds);

				sb.append(sb2);
			}
			else
				throw new UnsupportedOperationException(action.toString());
		}
	}



	/* ----------------------------------------------------------------------------------------------
	 * Method genConditionFunctions generates the fuctions that evaluate the conditions of an action.
	 *
	 * @param    sb		  a  StringBuffer
	 * @param    indent	      a  String
	 * @param    actionName	  a  String
	 * @param    rule		a  Rule
	 * ---------------------------------------------------------------------------------------------- */

	private void genConditionFunctions(StringBuffer sb, String indent, String actionName, Rule rule,
									   IdGenerator<Node> nodeIds, IdGenerator<Edge> edgeIds)
	{
		sb.append("/* functions for evaluation of conditions of action " + actionName + " */\n");

		// conditions for L
		genConditionFunction(sb, indent, rule.getLeft(), nodeIds, edgeIds);

		// conditions  for NACs
		for(PatternGraph neg : rule.getLeft().getNegs()) {
			genConditionFunction(sb, indent, neg,  nodeIds, edgeIds);
		}
		sb.append("\n");
	}



	/* -------------------------------------------
	 * Method genConditionFunction
	 *
	 * Generate the function body for a condition
	 * ------------------------------------------- */

	private void genConditionFunction(StringBuffer sb, String indent, PatternGraph graph,
									  IdGenerator<Node> nodeIds, IdGenerator<Edge> edgeIds)
	{
		for(Expression cond : graph.getConditions()) {
			sb.append("static int grs_cond_func_" + cond.getId() +
						  "(ir_node **node_map, const ir_edge_t **edge_map) {\n");
			int useFlags = getUnusedEvalParams(cond);
			if ((useFlags & nodesInUse) == 0) {
				sb.append(indent + "(void) node_map;\n");
			}
			if ((useFlags & edgesInUse) == 0) {
				sb.append(indent + "(void) edge_map;\n");
			}
			sb.append(indent + "return ");
			genConditionEval(sb, cond, nodeIds, edgeIds);
			sb.append(";\n");
			sb.append("}\n");
		}
	}

	private int getUnusedEvalParams(Expression cond)
	{
		if(cond instanceof Operator) {
			Operator op = (Operator)cond;
			switch (op.arity()) {
				case 1:
					return getUnusedEvalParams(op.getOperand(0));
				case 2:
					return
						getUnusedEvalParams(op.getOperand(0)) |
						getUnusedEvalParams(op.getOperand(1));
				case 3:
					if(op.getOpCode()==Operator.COND) {
						return
							getUnusedEvalParams(op.getOperand(0)) |
							getUnusedEvalParams(op.getOperand(1)) |
							getUnusedEvalParams(op.getOperand(2));
					}
				default: /* nothing */;
			}
		}
		else if(cond instanceof Qualification) {
			Qualification qual = (Qualification)cond;
			Entity entity = qual.getOwner();

			if(entity instanceof Node)
			{
				return nodesInUse;
			}
			else if (entity instanceof Edge)
			{
				return edgesInUse;
			}
		}
		return 0;
	}

	/* -------------------------------------------
	 * Method genEvalFunctions
	 *
	 * Generates eval functions for each eval list
	 * ------------------------------------------- */
	private void genEvalFunctions(StringBuffer sb, String indent, Rule rule, IdGenerator<Node> nodeIds, IdGenerator<Edge> edgeIds)
	{
	  	sb.append("/* function to do eval assignments */\n");

		for(Assignment eval : rule.getEvals())
		{
			Qualification target = eval.getTarget();
			Entity targetOwner = target.getOwner();
			Entity targetMember = target.getMember();
			Expression expr = eval.getExpression();

			sb.append("static void *grs_eval_out_func_" + eval.getId() + "(const ir_node **rpl_node_map, const ir_edge_t **rpl_edge_map, ir_node **pat_node_map, void *data) {\n");
			sb.append(indent+"set_"+ targetOwner.getType().getIdent() +"_"+ targetMember.getIdent() +"(");
			// Each node type has to be treated differently when accessing attributes
			// Care about that here.
			if(targetOwner instanceof Node)
			{
				Node n = (Node) targetOwner;
				sb.append("rpl_node_map[" + nodeIds.computeId(n) + "/* " + n.getIdent() + " */], ");
			}
			else if (targetOwner instanceof Edge)
			{
				Edge e = (Edge) targetOwner;
				sb.append("rpl_edge_map[" + edgeIds.computeId(e) + "/* " + e.getIdent() + " */], ");
			}
			else
			{
				throw new UnsupportedOperationException("Unsupported Entity (" + targetOwner + ")");
			}
			genConditionEval(sb, expr, nodeIds, edgeIds);
			sb.append(");\n");

			sb.append(indent + "return(NULL);\n");
			sb.append("}\n");
		}
	}



	/* ------------------------------------------------------------------
	 * Method registerEvalFunctions
	 *
	 * Generates code to register an eval function to the pattern matcher
	 * ------------------------------------------------------------------ */

	private void registerEvalFunctions(StringBuffer sb, String indent, Rule rule)
	{
		for(Assignment eval : rule.getEvals())
		{
			sb.append(indent + "ext_grs_act_register_eval(act, NULL, (ext_grs_eval_out_func_t) &grs_eval_out_func_" + eval.getId() + ");\n");
		}

	}



	/* -------------------------------------------------------
	 * Method genPattern generates pattern graph for one rule.
	 *
	 * @param    sb		  a  StringBuffer
	 * @param    rule		a  Rule
	 * ------------------------------------------------------ */
	private void genPattern(StringBuffer sb, Rule rule,
							IdGenerator<Node> nodeIds, IdGenerator<Edge> edgeIds)
	{
		String indent = "\t";

		// code for the pattern graph
		sb.append(indent + "{ /* The action */\n");
		genPatternGraph(sb, indent + "\t", "ext_grs_act_get_pattern", rule.getLeft(), nodeIds, edgeIds, GraphType.Pattern);

		// code for the negative graphs
		sb.append(indent + "  /* The negative parts of the pattern */\n");
		int i = 0;
		for(PatternGraph neg : rule.getLeft().getNegs()) {
			sb.append(indent + "  { /* NAC " + i + "  */\n");
			genPatternGraph(sb, indent+"    ", "ext_grs_act_impose_negative",
							neg, nodeIds, edgeIds, GraphType.Negative);
			sb.append(indent + "  } /* NAC " + i + "  */\n");
			sb.append("\n");
			i++;
		}

		sb.append("\n\n");

		// Code for the replacement
		sb.append(indent + "  { /* The replacement */\n");
		genGraph(sb, indent + "     ", "ext_grs_act_get_replacement", rule.getRight(), nodeIds, edgeIds, GraphType.Replacement);
		sb.append(indent + "  } /* The replacement */\n\n");

		// Code for registering eval functions
		sb.append(indent + "  /* Eval functions */\n");
		registerEvalFunctions(sb, indent + "\t", rule);

		sb.append(indent + "} /* The Action */\n\n");
	}



	/* -----------------------------------------------------------------------------------
	 * Method genPatternGraph generates code for a L, or a NAC graph.
	 *
	 * @param    sb		  a  StringBuffer
	 * @param    indent	      a  String
	 * @param    funcName	    a  String containing the C-name for getting the graph
	 * @param    parentNodes	 a  Collection<Node> of the nodes of the parent graph
	 * @param    graph	       a  Graph
	 * @param    isNegativeGraph	 true, if current graph is negative
	 * ----------------------------------------------------------------------------------- */

	// The FIRM graph rewriter can't deal with identical node names in pattern/replacement or
	// pattern/NAC's. So for replacement graph or NAC's we change the node name artificially.
	// Remember the changed name in here in relatedNodes. The connection between related nodes
	// is not announced by name like in the GrGen Syntax but by special announce-functions

	HashMap<Node,String> relatedNodes;

	private void genPatternGraph(StringBuffer sb, String indent, String funcName,
								 PatternGraph graph,
								 IdGenerator<Node> nodeIds, IdGenerator<Edge> edgeIds,
								 GraphType graphType)
	{
		// Generate the graph
		genGraph(sb, indent, funcName, graph, nodeIds, edgeIds, graphType);

		// code for the conditions
		genConditions(sb, indent, graph);

	}

	private void genGraph(StringBuffer sb, String indent, String funcName,
						  Graph graph,
						  IdGenerator<Node> nodeIds, IdGenerator<Edge> edgeIds,
						  GraphType graphType)
	{
		sb.append(indent + "ext_grs_graph_t *pattern = " + funcName + "(act);\n\n");

		// nodes
		relatedNodes = new HashMap<Node,String>();
		genPatternNodes(sb, indent, graph, nodeIds, graphType);
		sb.append("\n");

		//edges
		genPatternEdges(sb, indent, graph, edgeIds, graphType);

		// Clean up
		relatedNodes.clear();
	}



	/* --------------------------------------
	 * Method genPatterNodes
	 *
	 * Generates all Nodes of a given pattern
	 * -------------------------------------- */

	private int uin = 0;
	private void genPatternNodes(StringBuffer sb, String indent, Graph graph, IdGenerator<Node> nodeIds, GraphType graphType) {
		sb.append(indent + "/* The nodes of the pattern */\n");

		for(Node node : graph.getNodes()) {

			// Don't dump mode nodes
			if(node.getNodeType().isCastableTo(MODE_TYPE))
				continue;

			boolean related = false;
			String nameSuffix = "";
			if(nodeIds.isKnown(node))
			{
				nameSuffix = "_" + uin; 	// Node is already known (positive pattern), make sure that names are different
				uin++;
				related = true;			// Flag indicates to emit an relation statement afterwards
			}

			int nodeId;
			String name, type;
			if(node.getRetypedNode() == null || graphType != GraphType.Replacement)
			{
				nodeId = nodeIds.computeId(node);
				name = node.getIdent().toString() + nameSuffix;
				type = node.getNodeType().getIdent().toString();
			}
			else
			{ // node gets retyped
				nodeId = nodeIds.computeId(node.getRetypedNode());
				name = node.getRetypedNode().getIdent().toString() + nameSuffix;
				type = node.getRetypedNode().getNodeType().getIdent().toString();
			}
			String mode = "ANY";

			// Search for the "Mode"-edge
			for(Edge e : graph.getOutgoing(node)) { // test iff we got an Mode-node
				if(e.getEdgeType().getIdent().toString().equals(MODE_EDGE_NAME)) {
					// Found the "mode" edge. Save the mode of the current node for dumping
					Node modeNode = graph.getTarget(e);
					//System.out.println("'" + modeNode.getNodeType().getIdent().toString() + "'");
					if (null != modeNode) {
						mode = modeNode.getNodeType().getIdent().toString().substring(5);
					}
				}
			}

			// TODO make type constraints:
			// sb.append(indent + "/* TODO typeof("+name+") = " + type +
			//			  " \\ " + node.getConstraints()  +"*/\n");


			// Check if the node is related to a positiv node
			if(!related)
			{
				String construction_func = (type.equals("IR_node")) ?  "new_ir_node" : "new_rd_" + type;
				sb.append(indent + "ext_grs_node_t *n_" + name +			// No, Write statement to file
						  " = ext_grs_act_add_node(pattern, \"" +
						  name + "\", grs_op_" + type + ", mode_" + mode +
						  ", " + nodeId + ", &" + construction_func + ");\n");

			}
			else
			{
				String addRelatedNodeFunc = (graphType == GraphType.Negative) ? "ext_grs_act_add_related_node" : "ext_grs_act_add_node_to_keep";
				String related_name = node.getIdent().toString(); 			// Yes, the regular node name without suffix
				String construction_func = (type.equals("IR_node")) ?  "new_ir_node" : "new_rd_" + type;
				sb.append(indent + "ext_grs_node_t *n_" + name +	    // Write statement to file
					  	" = " + addRelatedNodeFunc + "(pattern, \"" +
					  	name + "\", grs_op_" + type + ", mode_" + mode +
					  	", " + nodeId + ", n_" + related_name + ", &" +
							construction_func + ");\n");
				System.out.println(relatedNodes + "; " + node + "; " + name);
				relatedNodes.put(node, name);								// Name was changed for neg nodes. Remember new
																			// name for the creation of edges.
			}
		}
	}



	/* ----------------------------
	 * Method genPatternEdges
	 *
	 * Dumps the edges of a pattern
	 * ---------------------------- */

	private void genPatternEdges(StringBuffer sb, String indent, Graph graph, IdGenerator<Edge> edgeIds, GraphType graphType)
	{
		sb.append(indent + "/* The edges of the pattern */\n");
		for(Edge edge : graph.getEdges()) {

			// Don't dump edges to mode nodes
			if(edge.getEdgeType().getIdent().toString().equals(MODE_EDGE_NAME))
				continue;


			String nameSuffix = "";
			boolean related = false;

			if(edgeIds.isKnown(edge))
			{
				nameSuffix = "_" + uin; 	// Edge is already known (positive pattern), make sure the names are different
				uin++;
				related = true;				// Flag indicates to emit an relation statement afterwards
			}
			else if(graphType != GraphType.Pattern)
			{
				nameSuffix = "_" + uin; 	// We're in a negative or replacement graph: Add suffix to avoid name
				uin++;						// collision with positive edge names
			}

			int edgeId  = edgeIds.computeId(edge);
			String edgePos = "ext_grs_NO_EDGE_POS";
			String name = edge.getIdent().toString().replace('$','_') + nameSuffix;
			//System.out.println("'" + edge.getIdent().toString() + "'\n");
			if(name.length() > 4 && name.substring(0, 4).matches("pos[0123456789]"))
			{
				String edgePosNrStr = edge.getIdent().toString().substring(3, 4);
				int edgePosNr = Integer.parseInt(edgePosNrStr);
				edgePosNr -= 1;
				edgePos = "" + edgePosNr;
			}

			Node src = graph.getSource(edge);
			Node tgt = graph.getTarget(edge);

			String sourceName = "";
			String targetName = "";

			// Check if source node is a negative node
			if(relatedNodes.containsKey(src))
				// Yes, get negative node name
				sourceName = relatedNodes.get(src);
			else
				sourceName = src.getIdent().toString(); 	// No, get regular node name

			// Check if dest node is a negative node
			if(relatedNodes.containsKey(tgt))
				targetName = relatedNodes.get(tgt);		// Yes, get negative node name
			else
				targetName = tgt.getIdent().toString();	// No, get regular node name

			// Check if the edge is related to a positive edge
			if(!related)
			{
				// Create a regular, independent edge
				sb.append(indent + "ext_grs_edge_t *e_" + name +			// Write statement to file
						  " = ext_grs_act_add_edge(pattern, \"" + name +
						  "\", " + edgePos + ", n_" + targetName + ", n_" +
						  sourceName +", " + edgeId + ");\n");
			}
			else
			{
				// Create a related edge
				String addRelatedEdgeFunc = (graphType == GraphType.Negative) ? "ext_grs_act_add_related_edge" : "ext_grs_act_add_edge_to_keep";
				String related_name = edge.getIdent().toString().replace('$','_'); 	// The original name without suffix
				sb.append(indent + "ext_grs_edge_t *e_" + name +		   	// Write statement to file
						  " = " + addRelatedEdgeFunc + "(pattern, \"" + name +
						  "\", " + edgePos + ", n_" + targetName + ", n_" +
						  sourceName + ", " + edgeId + ", e_" + related_name + ");\n");
			}
		}
		sb.append("\n");
	}



	/* ---------------------------------------------
	 * Method genConditions
	 *
	 * @param    sb		  a  StringBuffer
	 * @param    indent	      a  String
	 * @param    graph	       a  PatternGraph
	 * --------------------------------------------- */

	private void genConditions(StringBuffer sb, String indent, PatternGraph graph) {
		sb.append(indent + "/* The conditions of the pattern */\n");
		for(Expression cond : graph.getConditions()) {
			String indent2 = indent + "\t";
			Set<Node> nodes = new HashSet<Node>();
			Set<Edge> edges = new HashSet<Edge>();

			collectNodesnEdges(nodes, edges, cond);

			sb.append(indent + "{ /* if */\n");

			if(nodes.size() > 0)
			{
				sb.append(indent2 + "ext_grs_node_t *nodes[" + nodes.size() + "] = ");
				genSet(sb, nodes);
			}
			else
			{
				sb.append(indent2 + "ext_grs_node_t **nodes = NULL");
			}
			sb.append(";\n");

			if(edges.size() > 0)
			{
				sb.append(indent2 + "ext_grs_edge_t *edges[" + edges.size() + "] = ");
				genSet(sb, edges);
			}
			else
			{
				sb.append(indent2 + "ext_grs_edge_t **edges = NULL");
			}
			sb.append(";\n\n");

			sb.append(indent2 + "ext_grs_act_register_condition(grs_cond_func_"
						  + cond.getId() + ", pattern, " +
						  nodes.size() + ", nodes, " + edges.size() + ", edges);\n");

			sb.append(indent + "} /* if */\n\n");
		}
	}



	/* ---------------
	 * Method genEvals
	 * --------------- */

	// TODO use or remove it
	/*private void genEvals(StringBuffer sb, String indent, Action action)
	{
		if(evalActions.containsKey(action.getId()))
		{
			//Evaluation eval = evalActions.get(action.getId());
		/* TODO:
			 * Enumarate through all evals of the current action
	 		 * Find out if eval has to be executed BEFORE or AFTER transformation
	 		 * Register eval using func_in and func_out parameters
	 		 * At some other place:
	 		 * Generate eval function
	 		 *//*

		}
		else
		{
			System.out.println("Action has no evals!");
		}


	}*/



	/* ----------------------------------------------
	 * Method genSet dumps C-like Set representation.
	 *
	 * @param    sb		  a  StringBuffer
	 * @param    set		 a  Set
	 * ---------------------------------------------- */

	private void genSet(StringBuffer sb, Set<? extends Entity> set) {
		sb.append('{');

		String sep = "";
		for(Entity e : set) {
			sb.append(sep);
			if(e instanceof Node)
				sb.append("n_" + e.getIdent().toString());
			else if (e instanceof Edge)
				sb.append("e_" + e.getIdent().toString());
			else
				sb.append(e.getIdent().toString());
			sep = ", ";
		}
		sb.append('}');
	}



	/* ---------------------------------------------------------------------------------
	 * Method collectNodesnEdges extracts the nodes and edges occuring in an Expression.
	 *
	 * @param    nodes	       a  Set to contain the nodes of cond
	 * @param    edges	       a  Set to contain the edges of cond
	 * @param    cond		an Expression
	 * --------------------------------------------------------------------------------- */

	private void collectNodesnEdges(Set<Node> nodes, Set<Edge> edges, Expression cond)
	{
		if(cond instanceof Qualification) {
			Entity entity = ((Qualification)cond).getOwner();
			if(entity instanceof Node)
				nodes.add((Node)entity);
			else if(entity instanceof Edge)
				edges.add((Edge)entity);
			else
				throw new UnsupportedOperationException("Unsupported Entity (" + entity + ")");
		}
		else if(cond instanceof Operator)
			for(Expression child : ((Operator)cond).getWalkableChildren())
				collectNodesnEdges(nodes, edges, child);
	}



	/* ---------------------------------------------
	 * Method genConditionEval
	 *
	 * Generates C code for evaluating an expression
	 * in conditions and eval statenemts
	 * --------------------------------------------- */

	private void genConditionEval(StringBuffer sb, Expression cond,
								  IdGenerator<Node> nodeIds, IdGenerator<Edge> edgeIds)
	{
		if(cond instanceof Operator) {
			Operator op = (Operator)cond;
			switch (op.arity()) {
				case 1:
					genConditionEval(sb, op.getOperand(0), nodeIds, edgeIds);
					break;
				case 2:
					genConditionEval(sb, op.getOperand(0), nodeIds, edgeIds);
					sb.append(" " + opSymbols[op.getOpCode()] + " ");
					genConditionEval(sb, op.getOperand(1), nodeIds, edgeIds);
					break;
				case 3:
					if(op.getOpCode()==Operator.COND) {
						sb.append("(");
						genConditionEval(sb, op.getOperand(0), nodeIds, edgeIds);
						sb.append(") ? (");
						genConditionEval(sb, op.getOperand(1), nodeIds, edgeIds);
						sb.append(") : (");
						genConditionEval(sb, op.getOperand(2), nodeIds, edgeIds);
						sb.append(")");
						break;
					}
				default: throw new UnsupportedOperationException("Unsupported Operation arrity (" + op.arity() + ")");
			}
		}
		else if(cond instanceof Qualification) {
			Qualification qual = (Qualification)cond;
			Entity entity = qual.getOwner();

			if(entity instanceof Node)
			{
				Node n = (Node) entity;

				// We have to treat special FIRM nodes specially

				// Query the tarval of const nodes.
				// Only integer supported so far
				if(n.getNodeType().isCastableTo(CONST_TYPE))
				{
					sb.append("get_tarval_long(get_Const_tarval(node_map["+ nodeIds.computeId(n) +
							  "/* "+ entity.getIdent() + " */]))");
				}
				// Query the proj_nr of a vproj_node
				else if(n.getNodeType().isCastableTo(VPROJ_TYPE))
				{
					sb.append("get_VProj_proj(node_map[" + nodeIds.computeId(n) + "/* " + entity.getIdent() + " */])");
				}
				else if(n.getNodeType().isCastableTo(MULTIPLE_ADD_TYPE))
				{
					sb.append("get_irn_arity(node_map[" + nodeIds.computeId(n) + "/* " + entity.getIdent() + " */])");
				}
				else if(n.getNodeType().isCastableTo(PROJ_TYPE))
				{
					sb.append("get_Proj_proj(node_map[" + nodeIds.computeId(n) + "/* " + entity.getIdent() + " */])");
				}
				else
				{
					throw new UnsupportedOperationException("Unsupported Node type in condition for node " + entity.getIdent());
				}
			}
			else if (entity instanceof Edge)
			{
				// Query the position of a MATCHED egde.
				if(qual.getMember().getIdent().toString().equals("pos"))
				{
					sb.append("get_edge_src_pos(edge_map["+ edgeIds.computeId((Edge)entity) +
						  "/* "+ entity.getIdent() + " */])");
				}
				else
				{
					throw new UnsupportedOperationException("Unsupported Edge attribute (" + entity + ")");
				}
			}
			else
			{
				throw new UnsupportedOperationException("Unsupported Entity (" + entity + ")");
			}
		}
		else if (cond instanceof Constant) { // gen C-code for constant expressions
			Constant constant = (Constant) cond;
			Type type = constant.getType();

			switch (type.classify()) {
				case Type.IS_STRING: //emit C-code for string constants
					// CAUTION! This was modified for INTEGET CONSTANTS!
					// TODO: Make it general if you need it!
					// sb.append("\"" + constant.getValue() + "\"");
					sb.append(constant.getValue().toString());

					break;
				case Type.IS_BOOLEAN: //emit C-code for boolean constans
					Boolean bool_const = (Boolean) constant.getValue();
					if ( bool_const.booleanValue() )
						sb.append("1"); /* true-value */
					else
						sb.append("0"); /* false-value */
					break;
				case Type.IS_INTEGER: //emit C-code for integer constants
					sb.append(constant.getValue().toString()); /* this also applys to enum constants */
			}
		}
		else throw new UnsupportedOperationException("Unsupported expression type (" + cond + ")");
	}



	/* -------------------------------------------------------------------------------
	 * Method genInterface
	 * Generates the init() functions and code to create all the ext_grs_op's
	 * if no corresponding FIRM op exists. Also appoints heritage between IR_OP Types.
	 * ------------------------------------------------------------------------------- */

	private void genInterface(StringBuffer sb) {
		String indent = "\t";
		StringBuffer initsb = new StringBuffer();
		String unitName = unit.getUnitName();

		initsb.append("/* function for initializing the actions */\n");
		sb.append("/* global variables containing the actions */\n");
		initsb.append("void ext_grs_action_init_" + unitName + "(void) {\n");
		initsb.append(indent + "init();\n");
		for(Rule action : unit.getActionRules()) {
			if(action.getRight() != null) {
				String actionName = action.getIdent().toString();
				String fqactionName = "ext_grs_action_" + unitName + "_" + actionName;

				initsb.append(indent + fqactionName + " = grs_action_" + actionName + "_init();\n");
				sb.append("ext_grs_action_t *" + fqactionName + ";\n");
			}
		}
		initsb.append("\n" + indent + "/* establish inherritance */\n");
		for(InheritanceType type : nodeTypeMap.keySet()) {

			if(!type.isCastableTo(MODE_TYPE))
			{
				// Don't dump the inheritance of the pseudo "Mode"-Nodes

				String typeName = type.getIdent().toString();
				for(InheritanceType superType : type.getAllSuperTypes())
					initsb.append(indent + "ext_grs_appoint_heir(grs_op_" + typeName + ", grs_op_" + superType.getIdent() + ");\n");
				initsb.append("\n");
			}
		}
		initsb.append(indent+"ext_grs_inheritance_mature();\n");
		initsb.append(indent+"return;\n");
		initsb.append("}\n\n");
		sb.append("\n"+initsb);
	}


	/* --------------
     * Dumps a figlet
     * --------------
     */
	// TODO use or remove it
	/*private void figlet(String indent, StringBuffer sb) {
		try {
			String line;
			Process p = Runtime.getRuntime().exec
			(System.getenv("windir") +"\\system32\\"+"tree.com /A");
			BufferedReader input = new BufferedReader(new InputStreamReader(p.getInputStream()));
			while ((line = input.readLine()) != null)
			{
				sb.append(indent + line);
			}
			input.close();
		}
		catch (Exception err) {
			err.printStackTrace();
		}
	}*/
}

















