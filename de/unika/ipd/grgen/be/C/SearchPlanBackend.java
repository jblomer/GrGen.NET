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
 * A GrGen Backend which generates C code for a frame-based
 * graph model impl and a frame based graph matcher
 * @author Veit Batz, Rubino Geiss
 * @version $Id$
 */
package de.unika.ipd.grgen.be.C;

import de.unika.ipd.grgen.ir.*;
import java.util.*;

import de.unika.ipd.grgen.Sys;
import de.unika.ipd.grgen.be.Backend;
import de.unika.ipd.grgen.be.BackendException;
import de.unika.ipd.grgen.be.BackendFactory;
import de.unika.ipd.grgen.be.C.fb.AttrTypeDescriptor;
import de.unika.ipd.grgen.be.C.fb.EnumDescriptor;
import de.unika.ipd.grgen.be.C.fb.MoreInformationCollector;
import de.unika.ipd.grgen.util.Attributed;
import de.unika.ipd.grgen.util.Attributes;
import java.io.File;
import java.io.PrintStream;

public class SearchPlanBackend extends MoreInformationCollector implements Backend, BackendFactory {
	
	private final int OUT = 0;
	private final int IN = 1;
	
	private final String MODE_EDGE_NAME = "has_mode";
	
	protected final boolean emit_subgraph_info = false;
	
	/* binary operator symbols of the C-language */
	// ATTENTION: the forst two shift operations are signed shifts
	// 		the second right shift is signed. This Backend simply gens
	//		C-bitwise-shift-operations on signed integers, for simplicity ;-)
	private String[] opSymbols = {
		null, "||", "&&", "|", "^", "&",
			"==", "!=", "<", "<=", ">", ">=", "<<", ">>", ">>", "+",
			"-", "*", "/", "%", null, null, null, null
	};
	
	
	private class IdGenerator<T> {
		ArrayList<T> list = new ArrayList<T>();
		Set<T> set = new HashSet<T>();
		
		private int computeId(T elem) {
			if(!set.contains(elem)) {
				set.add(elem);
				list.add(elem);
			}
			return list.indexOf(elem);
		}
		
		private boolean isKnown(T elem) {
			return set.contains(elem);
		}
	}
	
	//Kann man das entfernen???
	//ToDo: Pruefe das, ob man diese Methode wegschmeissen kann!!!
	
	/**
	 * Method makeEvals
	 *
	 * @param    ps                  a  PrintStream
	 *
	 */
	protected void makeEvals(PrintStream ps) {
		// TODO
	}
	
//	// The unit to generate code for.
//	protected Unit unit;
//	// keine Ahnung wozu das gut sein soll
//	protected Sys system;
//	// The output path as handed over by the frontend.
//	private File path;
	
	/**
	 * Create a new backend.
	 * @return A new backend.
	 */
	public Backend getBackend() throws BackendException {
		return this;
	}
	
	/**
	 * Initializes the FrameBasedBackend
	 * @see de.unika.ipd.grgen.be.Backend#init(de.unika.ipd.grgen.ir.Unit, de.unika.ipd.grgen.Sys, java.io.File)
	 */
	public void init(Unit unit, Sys system, File outputPath) {
		super.init(unit, system, outputPath);
//		this.unit = unit;
//		this.path = outputPath;
//		this.system = system;
//		path.mkdirs();
	}
	
	/**
	 * Starts the C-code Genration of the FrameBasedBackend
	 * @see de.unika.ipd.grgen.be.Backend#generate()
	 */
	public void generate() {
		// Emit an include file for Makefiles
		PrintStream ps = openFile("unit.mak");
		ps.println("#\n# generated by grgen, don't edit\n#");
		ps.println("UNIT_NAME = " + formatId(unit.getIdent().toString()));
		closeFile(ps);
		
		System.out.println("The frame-based GrGen backend...");
		System.out.println("  generating the pattern...");
		
		//gen the C-code of the evals
		StringBuffer sb = new StringBuffer();
		sb.append("/* generated by grgen, don't edit */\n\n");
		sb.append("#include <libfirm/firm.h>\n");
		sb.append("#include <libfirm/ext/grs/grs.h>\n\n");
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
	
	/**
	 * Method genTypes
	 *
	 * @param    sb                  a  StringBuffer
	 *
	 */
	private void genTypes(StringBuffer sb) {
		String indent = "  ";
		StringBuffer initsb = new StringBuffer();
		sb.append("/* nodeTypeMap */ \n");
		initsb.append("/* init node ops and modes */\n");
		initsb.append("static void init() {\n");
		for(Identifiable id : nodeTypeMap.keySet()) {
			String type = id.getIdent().toString();
			sb.append("static ir_op* grs_op_" + type + ";\n");
			initsb.append(indent+"grs_op_" + type + " = ext_grs_lookup_op(\""+ type +"\");\n");
			initsb.append(indent+"grs_op_" + type + " = grs_op_" + type +
							  " ? grs_op_" + type + " : new_ir_op(get_next_ir_opcode(), \"" +
							  type + "\", op_pin_state_pinned,  irop_flag_none, oparity_dynamic,  0, 0, NULL);\n");
		}
		sb.append("/* nodeTypeMap END */\n\n");
		initsb.append("} /* init node ops and modes */\n\n");
		sb.append(initsb);
	}
	
	
	/**
	 * Method genPatterns generates the patterns needed by the seach plan
	 * builder. It consists mainly of the left hand side of the rule.
	 *
	 * @param    sb                  a  StringBuffer
	 *
	 */
	private void genPatterns(StringBuffer sb) {
		String indent = "  ";
		for(Action action : unit.getActions()) {
			if(action instanceof Rule) {
				String actionName = action.getIdent().toString();
				
				StringBuffer sb2 = new StringBuffer(); // append pattern after condition
				IdGenerator<Node> nodeIds = new IdGenerator<Node>(); // To generate uique numbers per rule
				IdGenerator<Edge> edgeIds = new IdGenerator<Edge>();
				
				sb2.append("/* functions for building the pattern of action " + actionName + " */\n");
				sb2.append("static inline ext_grs_action_t *grs_action_" + actionName + "_init() {\n");
				sb2.append(indent + "ext_grs_action_t *act = ext_grs_new_action(ext_grs_k_test, \"" +
							   actionName + "\");\n");
				sb2.append(indent + "int check;\n");
				
				genPattern(sb2, (Rule)action, nodeIds, edgeIds); // generate the pattern
				
				sb2.append(indent + "check = ext_grs_act_mature(act);\n");
				sb2.append(indent + "assert(check);\n");
				sb2.append(indent + "return act;\n");
				sb2.append("} /* " + actionName + " */\n\n\n");
				
				genConditionFunctions(sb, indent, actionName, (Rule)action, nodeIds, edgeIds);
				
				sb.append(sb2);
			}
			else
				throw new UnsupportedOperationException(action.toString());
		}
	}
	
	
	/**
	 * Method genConditionFunctions generates the fuctions that evaluate the conditions of an action.
	 *
	 * @param    sb                  a  StringBuffer
	 * @param    indent              a  String
	 * @param    actionName          a  String
	 * @param    rule                a  Rule
	 *
	 */
	private void genConditionFunctions(StringBuffer sb, String indent, String actionName, Rule rule,
									   IdGenerator<Node> nodeIds, IdGenerator<Edge> edgeIds) {
		sb.append("/* functions for evaluation of conditions of action " + actionName + " */\n");
		// conditions for L
		genConditionFunction(sb, indent, rule.getLeft(), nodeIds, edgeIds);
		
		// conditions  for NACs
		for(PatternGraph neg : rule.getNegs()) {
			genConditionFunction(sb, indent, neg,  nodeIds, edgeIds);
		}
		sb.append("\n");
	}
	
	
	private void genConditionFunction(StringBuffer sb, String indent, PatternGraph graph,
									  IdGenerator<Node> nodeIds, IdGenerator<Edge> edgeIds) {
		for(Expression cond : graph.getConditions()) {
			sb.append("static int grs_cond_func_" + cond.getId() +
						  "(ir_node **node_map, const ir_edge_t **edge_map) {\n");
			sb.append(indent + "return ");
			genConditionEval(sb, cond, nodeIds, edgeIds);
			sb.append(";\n");
			sb.append("}\n");
		}
	}
	
	
	/**
	 * Method genPattern generates pattern graph for one rule.
	 *
	 * @param    sb                  a  StringBuffer
	 * @param    rule                a  Rule
	 *
	 */
	private void genPattern(StringBuffer sb, Rule rule,
							IdGenerator<Node> nodeIds, IdGenerator<Edge> edgeIds) {
		String indent = "  ";
		
		// code for the pattern graph
		sb.append(indent + "{ /* L */\n");
		genPatternGraph(sb, indent+"  ", "ext_grs_act_get_pattern",
						rule.getLeft(), nodeIds, edgeIds);
		
		
		// code for the negative graphs
		sb.append(indent + "  /* The negative parts of the pattern */\n");
		int i = 0;
		for(PatternGraph neg : rule.getNegs()) {
			sb.append(indent + "  { /* NAC " + i + "  */\n");
			genPatternGraph(sb, indent+"    ", "ext_grs_act_impose_negative",
							neg, nodeIds, edgeIds);
			sb.append(indent + "  } /* NAC " + i + "  */\n");
			sb.append("\n");
			i++;
		}
		sb.append(indent + "} /* L */\n\n");
	}
	
	
	/**
	 * Method genPatternGraph generates code for a L, or a NAC graph.
	 *
	 * @param    sb                  a  StringBuffer
	 * @param    indent              a  String
	 * @param    funcName            a  String containing the C-name for getting the graph
	 * @param    parentNodes         a  Collection<Node> of the nodes of the parent graph
	 * @param    graph               a  Graph
	 *
	 */
	private void genPatternGraph(StringBuffer sb, String indent, String funcName,
								 PatternGraph graph,
								 IdGenerator<Node> nodeIds, IdGenerator<Edge> edgeIds) {
		sb.append(indent + "ext_grs_graph_t *pattern = " + funcName + "(act);\n\n");
		
		// nodes
		genPatternNodes(sb, indent, graph, nodeIds);
		sb.append("\n");
		
		//edges
		genPatternEdges(sb, indent, graph, edgeIds);
		
		// code for the conditions
		genConditions(sb, indent, graph);
	}
	
	
	private void genPatternNodes(StringBuffer sb, String indent, PatternGraph graph, IdGenerator<Node> nodeIds) {
		sb.append(indent + "/* The nodes of the pattern */\n");
		for(Node node : graph.getNodes()) {
			if(nodeIds.isKnown(node))
				continue; // the node is already contained in the parent graph (L)
			
			int nodeId  = nodeIds.computeId(node);
			String name = node.getIdent().toString();
			String type = node.getNodeType().getIdent().toString();
			String mode = "ANY";
			
			for(Edge e : graph.getOutgoing(node)) { // test iff we got an Mode-node
				if(e.getEdgeType().getIdent().toString().equals(MODE_EDGE_NAME)) {
					sb.append("/* mode edge: " + e + "*/\n");
					Node modeNode = graph.getTarget(e);
					//mode = modeNode.getNodeType().getIdent().toString();
					// TODO this is not sufficient.
					// TODO We cannot determine die mode code quite so easyly.
				}
			}
			
			sb.append(indent + "/* TODO typeof("+name+") = " + type +
						  " \\ " + node.getConstraints()  +"*/\n"); // TODO make type constraints
			sb.append(indent + "ext_grs_node_t *n_" + name +
						  " = ext_grs_act_add_node(pattern, \"" +
						  name + "\", grs_op_" + type + ", mode_" + mode +
						  ", " + nodeId + ");\n");
		}
	}
	
	
	private void genPatternEdges(StringBuffer sb, String indent, PatternGraph graph, IdGenerator<Edge> edgeIds) {
		sb.append(indent + "/* The edges of the pattern */\n");
		for(Edge edge : graph.getEdges()) {
			if(edgeIds.isKnown(edge))
				continue;
			int edgeId  = edgeIds.computeId(edge);
			String name = edge.getIdent().toString().replace('$','_');
			Node src = graph.getSource(edge);
			Node tgt = graph.getTarget(edge);
			sb.append(indent + "ext_grs_edge_t *e_" + name +
						  " = ext_grs_act_add_edge(pattern, \"" + name +
						  "\", ext_grs_NO_EDGE_POS, n_" + src.getIdent() + ", n_" +
						  tgt.getIdent() +", " + edgeId + ");\n");
		}
		sb.append("\n");
	}
	
	
	/**
	 * Method genConditions
	 *
	 * @param    sb                  a  StringBuffer
	 * @param    indent              a  String
	 * @param    graph               a  PatternGraph
	 *
	 */
	private void genConditions(StringBuffer sb, String indent, PatternGraph graph) {
		sb.append(indent + "/* The conditions of the pattern */\n");
		for(Expression cond : graph.getConditions()) {
			String indent2 = indent + "  ";
			Set<Node> nodes = new HashSet<Node>();
			Set<Edge> edges = new HashSet<Edge>();
			
			collectNodesnEdges(nodes, edges, cond);
			
			sb.append(indent + "{ /* if */\n");
			
			sb.append(indent2 + "ext_grs_node_t *nodes[" + nodes.size() + "] = ");
			genSet(sb, nodes);
			sb.append(";\n");
			sb.append(indent2 + "ext_grs_edge_t *edges[" + edges.size() + "] = ");
			genSet(sb, edges);
			sb.append(";\n\n");
			
			sb.append(indent2 + "ext_grs_act_register_condition_func(grs_cond_func_"
						  + cond.getId() + ", pattern, " +
						  nodes.size() + ", nodes, " + edges.size() + ", edges);\n");
			
			sb.append(indent + "} /* if */\n\n");
		}
	}
	
	/**
	 * Method genSet dumps C-like Set representaion.
	 *
	 * @param    sb                  a  StringBuffer
	 * @param    set                 a  Set
	 *
	 */
	private void genSet(StringBuffer sb, Set<? extends Entity> set) {
		sb.append('{');
		for(Iterator<? extends Entity> i = set.iterator(); i.hasNext(); ) {
			Entity e = i.next();
			if(e instanceof Node)
				sb.append("n_" + e.getIdent().toString());
			else if (e instanceof Edge)
				sb.append("e_" + e.getIdent().toString());
			else
				sb.append(e.getIdent().toString());
			if(i.hasNext())
				sb.append(", ");
		}
		sb.append('}');
	}
	
	
	/**
	 * Method collectNodesnEdges extracts the nodes and edges occuring in an Expression.
	 *
	 * @param    nodes               a  Set to contain the nodes of cond
	 * @param    edges               a  Set to contain the edges of cond
	 * @param    cond                an Expression
	 *
	 */
	private void collectNodesnEdges(Set<Node> nodes, Set<Edge> edges, Expression cond) {
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
	
	
	private void genConditionEval(StringBuffer sb, Expression cond,
								  IdGenerator<Node> nodeIds, IdGenerator<Edge> edgeIds) {
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
						genConditionEval(sb, op.getOperand(1), nodeIds, edgeIds);
						sb.append(")");
						break;
					}
				default: throw new UnsupportedOperationException("Unsupported Operation arrity (" + op.arity() + ")");
			}
		}
		else if(cond instanceof Qualification) {
			Qualification qual = (Qualification)cond;
			Entity entity = qual.getOwner();
			
			sb.append(" 0 /* TODO attr access */");
			
			if(false) {
				// TODO fix attr access
				if(entity instanceof Node)
					sb.append("node_map["+ nodeIds.computeId((Node)entity) +
								  "/* "+ entity.getIdent() + " */] /*." + qual.getMember().getIdent()+"*/");
				else if (entity instanceof Edge)
					sb.append("edge_map["+ edgeIds.computeId((Edge)entity) +
								  "/* "+ entity.getIdent() + " */] /*." + qual.getMember().getIdent()+"*/");
				else
					throw new UnsupportedOperationException("Unsupported Entity (" + entity + ")");
			}
		}
		else if (cond instanceof Constant) { // gen C-code for constant expressions
			Constant constant = (Constant) cond;
			Type type = constant.getType();
			
			switch (type.classify()) {
				case Type.IS_STRING: //emit C-code for string constants
					sb.append("\"" + constant.getValue() + "\"");
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
	
	
	private void genInterface(StringBuffer sb) {
		String indent = "  ";
		StringBuffer initsb = new StringBuffer();
		String unitName = unit.getIdent().toString();
		
		initsb.append("/* function for initializing the actions */\n");
		sb.append("/* global variables containing the actions */\n");
		initsb.append("ext_grs_action_init_" + unitName + "() {\n");
		initsb.append(indent + "init();\n");
		for(Action action : unit.getActions()) {
			if(action instanceof Rule) {
				String actionName = action.getIdent().toString();
				String fqactionName = "ext_grs_action_" + unitName + "_" + actionName;
				
				initsb.append(indent + fqactionName + " = grs_action_" + actionName + "_init();\n");
				sb.append("ext_grs_action_t *" + fqactionName + ";\n");
			}
		}
		initsb.append("}\n\n");
		sb.append("\n"+initsb);
	}
}



