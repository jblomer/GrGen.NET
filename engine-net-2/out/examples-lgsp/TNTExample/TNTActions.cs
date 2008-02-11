using System;
using System.Collections.Generic;
using System.Text;
using de.unika.ipd.grGen.libGr;
using de.unika.ipd.grGen.lgsp;
using de.unika.ipd.grGen.models.TNT;

namespace de.unika.ipd.grGen.actions.TNT
{
	public class Pattern_Hydrogen : LGSPRulePattern
	{
		private static Pattern_Hydrogen instance = null;
		public static Pattern_Hydrogen Instance { get { if (instance==null) instance = new Pattern_Hydrogen(); return instance; } }

		public static NodeType[] node_anchor_AllowedTypes = null;
		public static NodeType[] node__node0_AllowedTypes = null;
		public static bool[] node_anchor_IsAllowedType = null;
		public static bool[] node__node0_IsAllowedType = null;
		public static EdgeType[] edge__edge0_AllowedTypes = null;
		public static bool[] edge__edge0_IsAllowedType = null;

		public enum NodeNums { @anchor, @_node0, };
		public enum EdgeNums { @_edge0, };
		public enum PatternNums { };

		private Pattern_Hydrogen()
		{
			name = "Hydrogen";
			isSubpattern = true;
			PatternNode node_anchor = new PatternNode((int) NodeTypes.@C, "node_anchor", node_anchor_AllowedTypes, node_anchor_IsAllowedType, PatternElementType.Preset, 0);
			PatternNode node__node0 = new PatternNode((int) NodeTypes.@H, "node__node0", node__node0_AllowedTypes, node__node0_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge0 = new PatternEdge(node_anchor, node__node0, (int) EdgeTypes.@Edge, "edge__edge0", edge__edge0_AllowedTypes, edge__edge0_IsAllowedType, PatternElementType.Normal, -1);
			patternGraph = new PatternGraph(
				"pattern Hydrogen.pattern",
				new PatternNode[] { node_anchor, node__node0 }, 
				new PatternEdge[] { edge__edge0 }, 
				new PatternGraphEmbedding[] {  }, 
				new Condition[] { },
				new bool[2, 2] {
					{ true, false, },
					{ false, true, },
				},
				new bool[1, 1] {
					{ true, },
				},
				new bool[] {
					false, false, },
				new bool[] {
					false, },
				new bool[] {
					true, true, },
				new bool[] {
					true, }
			);

			negativePatternGraphs = new PatternGraph[] {};
			inputs = new GrGenType[] { NodeType_C.typeVar, };
			inputNames = new string[] { "node_anchor", };
			outputs = new GrGenType[] { };
			outputNames = new string[] { };
		}


		public override IGraphElement[] Modify(LGSPGraph graph, LGSPMatch match)
		{  // currently empty
			return EmptyReturnElements;
		}
		public override IGraphElement[] ModifyNoReuse(LGSPGraph graph, LGSPMatch match)
		{  // currently empty
			return EmptyReturnElements;
		}
		private static String[] addedNodeNames = new String[] {};
		public override String[] AddedNodeNames { get { return addedNodeNames; } }
		private static String[] addedEdgeNames = new String[] {};
		public override String[] AddedEdgeNames { get { return addedEdgeNames; } }
	}

#if INITIAL_WARMUP
	public class Schedule_Hydrogen : LGSPStaticScheduleInfo
	{
		public Schedule_Hydrogen()
		{
			ActionName = "Hydrogen";
			this.RulePattern = Pattern_Hydrogen.Instance;
			NodeCost = new float[] { 5.5F, 5.5F,  };
			EdgeCost = new float[] { 5.5F,  };
			NegNodeCost = new float[][] { };
			NegEdgeCost = new float[][] { };
		}
	}
#endif

	public class Pattern_Hydroxyl : LGSPRulePattern
	{
		private static Pattern_Hydroxyl instance = null;
		public static Pattern_Hydroxyl Instance { get { if (instance==null) instance = new Pattern_Hydroxyl(); return instance; } }

		public static NodeType[] node_anchor_AllowedTypes = null;
		public static NodeType[] node__node0_AllowedTypes = null;
		public static NodeType[] node__node1_AllowedTypes = null;
		public static bool[] node_anchor_IsAllowedType = null;
		public static bool[] node__node0_IsAllowedType = null;
		public static bool[] node__node1_IsAllowedType = null;
		public static EdgeType[] edge__edge0_AllowedTypes = null;
		public static EdgeType[] edge__edge1_AllowedTypes = null;
		public static bool[] edge__edge0_IsAllowedType = null;
		public static bool[] edge__edge1_IsAllowedType = null;

		public enum NodeNums { @anchor, @_node0, @_node1, };
		public enum EdgeNums { @_edge0, @_edge1, };
		public enum PatternNums { };

		private Pattern_Hydroxyl()
		{
			name = "Hydroxyl";
			isSubpattern = true;
			PatternNode node_anchor = new PatternNode((int) NodeTypes.@C, "node_anchor", node_anchor_AllowedTypes, node_anchor_IsAllowedType, PatternElementType.Preset, 0);
			PatternNode node__node0 = new PatternNode((int) NodeTypes.@O, "node__node0", node__node0_AllowedTypes, node__node0_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node1 = new PatternNode((int) NodeTypes.@H, "node__node1", node__node1_AllowedTypes, node__node1_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge0 = new PatternEdge(node_anchor, node__node0, (int) EdgeTypes.@Edge, "edge__edge0", edge__edge0_AllowedTypes, edge__edge0_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge1 = new PatternEdge(node__node0, node__node1, (int) EdgeTypes.@Edge, "edge__edge1", edge__edge1_AllowedTypes, edge__edge1_IsAllowedType, PatternElementType.Normal, -1);
			patternGraph = new PatternGraph(
				"pattern Hydroxyl.pattern",
				new PatternNode[] { node_anchor, node__node0, node__node1 }, 
				new PatternEdge[] { edge__edge0, edge__edge1 }, 
				new PatternGraphEmbedding[] {  }, 
				new Condition[] { },
				new bool[3, 3] {
					{ true, false, false, },
					{ false, true, false, },
					{ false, false, true, },
				},
				new bool[2, 2] {
					{ true, false, },
					{ false, true, },
				},
				new bool[] {
					false, false, false, },
				new bool[] {
					false, false, },
				new bool[] {
					true, true, true, },
				new bool[] {
					true, true, }
			);

			negativePatternGraphs = new PatternGraph[] {};
			inputs = new GrGenType[] { NodeType_C.typeVar, };
			inputNames = new string[] { "node_anchor", };
			outputs = new GrGenType[] { };
			outputNames = new string[] { };
		}


		public override IGraphElement[] Modify(LGSPGraph graph, LGSPMatch match)
		{  // currently empty
			return EmptyReturnElements;
		}
		public override IGraphElement[] ModifyNoReuse(LGSPGraph graph, LGSPMatch match)
		{  // currently empty
			return EmptyReturnElements;
		}
		private static String[] addedNodeNames = new String[] {};
		public override String[] AddedNodeNames { get { return addedNodeNames; } }
		private static String[] addedEdgeNames = new String[] {};
		public override String[] AddedEdgeNames { get { return addedEdgeNames; } }
	}

#if INITIAL_WARMUP
	public class Schedule_Hydroxyl : LGSPStaticScheduleInfo
	{
		public Schedule_Hydroxyl()
		{
			ActionName = "Hydroxyl";
			this.RulePattern = Pattern_Hydroxyl.Instance;
			NodeCost = new float[] { 5.5F, 5.5F, 5.5F,  };
			EdgeCost = new float[] { 5.5F, 5.5F,  };
			NegNodeCost = new float[][] { };
			NegEdgeCost = new float[][] { };
		}
	}
#endif

	public class Pattern_Methyl : LGSPRulePattern
	{
		private static Pattern_Methyl instance = null;
		public static Pattern_Methyl Instance { get { if (instance==null) instance = new Pattern_Methyl(); return instance; } }

		public static NodeType[] node_anchor_AllowedTypes = null;
		public static NodeType[] node_c_AllowedTypes = null;
		public static NodeType[] node__node0_AllowedTypes = null;
		public static NodeType[] node__node1_AllowedTypes = null;
		public static NodeType[] node__node2_AllowedTypes = null;
		public static bool[] node_anchor_IsAllowedType = null;
		public static bool[] node_c_IsAllowedType = null;
		public static bool[] node__node0_IsAllowedType = null;
		public static bool[] node__node1_IsAllowedType = null;
		public static bool[] node__node2_IsAllowedType = null;
		public static EdgeType[] edge__edge0_AllowedTypes = null;
		public static EdgeType[] edge__edge1_AllowedTypes = null;
		public static EdgeType[] edge__edge2_AllowedTypes = null;
		public static EdgeType[] edge__edge3_AllowedTypes = null;
		public static bool[] edge__edge0_IsAllowedType = null;
		public static bool[] edge__edge1_IsAllowedType = null;
		public static bool[] edge__edge2_IsAllowedType = null;
		public static bool[] edge__edge3_IsAllowedType = null;

		public enum NodeNums { @anchor, @c, @_node0, @_node1, @_node2, };
		public enum EdgeNums { @_edge0, @_edge1, @_edge2, @_edge3, };
		public enum PatternNums { };

		private Pattern_Methyl()
		{
			name = "Methyl";
			isSubpattern = true;
			PatternNode node_anchor = new PatternNode((int) NodeTypes.@C, "node_anchor", node_anchor_AllowedTypes, node_anchor_IsAllowedType, PatternElementType.Preset, 0);
			PatternNode node_c = new PatternNode((int) NodeTypes.@C, "node_c", node_c_AllowedTypes, node_c_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node0 = new PatternNode((int) NodeTypes.@H, "node__node0", node__node0_AllowedTypes, node__node0_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node1 = new PatternNode((int) NodeTypes.@H, "node__node1", node__node1_AllowedTypes, node__node1_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node2 = new PatternNode((int) NodeTypes.@H, "node__node2", node__node2_AllowedTypes, node__node2_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge0 = new PatternEdge(node_anchor, node_c, (int) EdgeTypes.@Edge, "edge__edge0", edge__edge0_AllowedTypes, edge__edge0_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge1 = new PatternEdge(node_c, node__node0, (int) EdgeTypes.@Edge, "edge__edge1", edge__edge1_AllowedTypes, edge__edge1_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge2 = new PatternEdge(node_c, node__node1, (int) EdgeTypes.@Edge, "edge__edge2", edge__edge2_AllowedTypes, edge__edge2_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge3 = new PatternEdge(node_c, node__node2, (int) EdgeTypes.@Edge, "edge__edge3", edge__edge3_AllowedTypes, edge__edge3_IsAllowedType, PatternElementType.Normal, -1);
			patternGraph = new PatternGraph(
				"pattern Methyl.pattern",
				new PatternNode[] { node_anchor, node_c, node__node0, node__node1, node__node2 }, 
				new PatternEdge[] { edge__edge0, edge__edge1, edge__edge2, edge__edge3 }, 
				new PatternGraphEmbedding[] {  }, 
				new Condition[] { },
				new bool[5, 5] {
					{ true, false, false, false, false, },
					{ false, true, false, false, false, },
					{ false, false, true, false, false, },
					{ false, false, false, true, false, },
					{ false, false, false, false, true, },
				},
				new bool[4, 4] {
					{ true, false, false, false, },
					{ false, true, false, false, },
					{ false, false, true, false, },
					{ false, false, false, true, },
				},
				new bool[] {
					false, false, false, false, false, },
				new bool[] {
					false, false, false, false, },
				new bool[] {
					true, true, true, true, true, },
				new bool[] {
					true, true, true, true, }
			);

			negativePatternGraphs = new PatternGraph[] {};
			inputs = new GrGenType[] { NodeType_C.typeVar, };
			inputNames = new string[] { "node_anchor", };
			outputs = new GrGenType[] { };
			outputNames = new string[] { };
		}


		public override IGraphElement[] Modify(LGSPGraph graph, LGSPMatch match)
		{  // currently empty
			return EmptyReturnElements;
		}
		public override IGraphElement[] ModifyNoReuse(LGSPGraph graph, LGSPMatch match)
		{  // currently empty
			return EmptyReturnElements;
		}
		private static String[] addedNodeNames = new String[] {};
		public override String[] AddedNodeNames { get { return addedNodeNames; } }
		private static String[] addedEdgeNames = new String[] {};
		public override String[] AddedEdgeNames { get { return addedEdgeNames; } }
	}

#if INITIAL_WARMUP
	public class Schedule_Methyl : LGSPStaticScheduleInfo
	{
		public Schedule_Methyl()
		{
			ActionName = "Methyl";
			this.RulePattern = Pattern_Methyl.Instance;
			NodeCost = new float[] { 5.5F, 5.5F, 5.5F, 5.5F, 5.5F,  };
			EdgeCost = new float[] { 5.5F, 5.5F, 5.5F, 5.5F,  };
			NegNodeCost = new float[][] { };
			NegEdgeCost = new float[][] { };
		}
	}
#endif

	public class Pattern_Nitro : LGSPRulePattern
	{
		private static Pattern_Nitro instance = null;
		public static Pattern_Nitro Instance { get { if (instance==null) instance = new Pattern_Nitro(); return instance; } }

		public static NodeType[] node_anchor_AllowedTypes = null;
		public static NodeType[] node_n_AllowedTypes = null;
		public static NodeType[] node__node0_AllowedTypes = null;
		public static NodeType[] node__node1_AllowedTypes = null;
		public static bool[] node_anchor_IsAllowedType = null;
		public static bool[] node_n_IsAllowedType = null;
		public static bool[] node__node0_IsAllowedType = null;
		public static bool[] node__node1_IsAllowedType = null;
		public static EdgeType[] edge__edge0_AllowedTypes = null;
		public static EdgeType[] edge__edge1_AllowedTypes = null;
		public static EdgeType[] edge__edge2_AllowedTypes = null;
		public static bool[] edge__edge0_IsAllowedType = null;
		public static bool[] edge__edge1_IsAllowedType = null;
		public static bool[] edge__edge2_IsAllowedType = null;

		public enum NodeNums { @anchor, @n, @_node0, @_node1, };
		public enum EdgeNums { @_edge0, @_edge1, @_edge2, };
		public enum PatternNums { };

		private Pattern_Nitro()
		{
			name = "Nitro";
			isSubpattern = true;
			PatternNode node_anchor = new PatternNode((int) NodeTypes.@C, "node_anchor", node_anchor_AllowedTypes, node_anchor_IsAllowedType, PatternElementType.Preset, 0);
			PatternNode node_n = new PatternNode((int) NodeTypes.@N, "node_n", node_n_AllowedTypes, node_n_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node0 = new PatternNode((int) NodeTypes.@O, "node__node0", node__node0_AllowedTypes, node__node0_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node1 = new PatternNode((int) NodeTypes.@O, "node__node1", node__node1_AllowedTypes, node__node1_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge0 = new PatternEdge(node_anchor, node_n, (int) EdgeTypes.@Edge, "edge__edge0", edge__edge0_AllowedTypes, edge__edge0_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge1 = new PatternEdge(node_n, node__node0, (int) EdgeTypes.@Edge, "edge__edge1", edge__edge1_AllowedTypes, edge__edge1_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge2 = new PatternEdge(node_n, node__node1, (int) EdgeTypes.@Edge, "edge__edge2", edge__edge2_AllowedTypes, edge__edge2_IsAllowedType, PatternElementType.Normal, -1);
			patternGraph = new PatternGraph(
				"pattern Nitro.pattern",
				new PatternNode[] { node_anchor, node_n, node__node0, node__node1 }, 
				new PatternEdge[] { edge__edge0, edge__edge1, edge__edge2 }, 
				new PatternGraphEmbedding[] {  }, 
				new Condition[] { },
				new bool[4, 4] {
					{ true, false, false, false, },
					{ false, true, false, false, },
					{ false, false, true, false, },
					{ false, false, false, true, },
				},
				new bool[3, 3] {
					{ true, false, false, },
					{ false, true, false, },
					{ false, false, true, },
				},
				new bool[] {
					false, false, false, false, },
				new bool[] {
					false, false, false, },
				new bool[] {
					true, true, true, true, },
				new bool[] {
					true, true, true, }
			);

			negativePatternGraphs = new PatternGraph[] {};
			inputs = new GrGenType[] { NodeType_C.typeVar, };
			inputNames = new string[] { "node_anchor", };
			outputs = new GrGenType[] { };
			outputNames = new string[] { };
		}


		public override IGraphElement[] Modify(LGSPGraph graph, LGSPMatch match)
		{  // currently empty
			return EmptyReturnElements;
		}
		public override IGraphElement[] ModifyNoReuse(LGSPGraph graph, LGSPMatch match)
		{  // currently empty
			return EmptyReturnElements;
		}
		private static String[] addedNodeNames = new String[] {};
		public override String[] AddedNodeNames { get { return addedNodeNames; } }
		private static String[] addedEdgeNames = new String[] {};
		public override String[] AddedEdgeNames { get { return addedEdgeNames; } }
	}

#if INITIAL_WARMUP
	public class Schedule_Nitro : LGSPStaticScheduleInfo
	{
		public Schedule_Nitro()
		{
			ActionName = "Nitro";
			this.RulePattern = Pattern_Nitro.Instance;
			NodeCost = new float[] { 5.5F, 5.5F, 5.5F, 5.5F,  };
			EdgeCost = new float[] { 5.5F, 5.5F, 5.5F,  };
			NegNodeCost = new float[][] { };
			NegEdgeCost = new float[][] { };
		}
	}
#endif

	public class Rule_DNT : LGSPRulePattern
	{
		private static Rule_DNT instance = null;
		public static Rule_DNT Instance { get { if (instance==null) instance = new Rule_DNT(); return instance; } }

		public static NodeType[] node_c1_AllowedTypes = null;
		public static NodeType[] node_c2_AllowedTypes = null;
		public static NodeType[] node_c3_AllowedTypes = null;
		public static NodeType[] node_c4_AllowedTypes = null;
		public static NodeType[] node_c5_AllowedTypes = null;
		public static NodeType[] node_c6_AllowedTypes = null;
		public static bool[] node_c1_IsAllowedType = null;
		public static bool[] node_c2_IsAllowedType = null;
		public static bool[] node_c3_IsAllowedType = null;
		public static bool[] node_c4_IsAllowedType = null;
		public static bool[] node_c5_IsAllowedType = null;
		public static bool[] node_c6_IsAllowedType = null;
		public static EdgeType[] edge__edge0_AllowedTypes = null;
		public static EdgeType[] edge__edge1_AllowedTypes = null;
		public static EdgeType[] edge__edge2_AllowedTypes = null;
		public static EdgeType[] edge__edge3_AllowedTypes = null;
		public static EdgeType[] edge__edge4_AllowedTypes = null;
		public static EdgeType[] edge__edge5_AllowedTypes = null;
		public static EdgeType[] edge__edge6_AllowedTypes = null;
		public static EdgeType[] edge__edge7_AllowedTypes = null;
		public static EdgeType[] edge__edge8_AllowedTypes = null;
		public static bool[] edge__edge0_IsAllowedType = null;
		public static bool[] edge__edge1_IsAllowedType = null;
		public static bool[] edge__edge2_IsAllowedType = null;
		public static bool[] edge__edge3_IsAllowedType = null;
		public static bool[] edge__edge4_IsAllowedType = null;
		public static bool[] edge__edge5_IsAllowedType = null;
		public static bool[] edge__edge6_IsAllowedType = null;
		public static bool[] edge__edge7_IsAllowedType = null;
		public static bool[] edge__edge8_IsAllowedType = null;

		public enum NodeNums { @c1, @c2, @c3, @c4, @c5, @c6, };
		public enum EdgeNums { @_edge0, @_edge1, @_edge2, @_edge3, @_edge4, @_edge5, @_edge6, @_edge7, @_edge8, };
		public enum PatternNums { @_subpattern0, @_subpattern1, @_subpattern2, @_subpattern3, @_subpattern4, @_subpattern5, };

		private Rule_DNT()
		{
			name = "DNT";
			isSubpattern = false;
			PatternNode node_c1 = new PatternNode((int) NodeTypes.@C, "node_c1", node_c1_AllowedTypes, node_c1_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c2 = new PatternNode((int) NodeTypes.@C, "node_c2", node_c2_AllowedTypes, node_c2_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c3 = new PatternNode((int) NodeTypes.@C, "node_c3", node_c3_AllowedTypes, node_c3_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c4 = new PatternNode((int) NodeTypes.@C, "node_c4", node_c4_AllowedTypes, node_c4_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c5 = new PatternNode((int) NodeTypes.@C, "node_c5", node_c5_AllowedTypes, node_c5_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c6 = new PatternNode((int) NodeTypes.@C, "node_c6", node_c6_AllowedTypes, node_c6_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge0 = new PatternEdge(node_c1, node_c2, (int) EdgeTypes.@Edge, "edge__edge0", edge__edge0_AllowedTypes, edge__edge0_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge1 = new PatternEdge(node_c2, node_c3, (int) EdgeTypes.@Edge, "edge__edge1", edge__edge1_AllowedTypes, edge__edge1_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge2 = new PatternEdge(node_c3, node_c4, (int) EdgeTypes.@Edge, "edge__edge2", edge__edge2_AllowedTypes, edge__edge2_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge3 = new PatternEdge(node_c4, node_c5, (int) EdgeTypes.@Edge, "edge__edge3", edge__edge3_AllowedTypes, edge__edge3_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge4 = new PatternEdge(node_c5, node_c6, (int) EdgeTypes.@Edge, "edge__edge4", edge__edge4_AllowedTypes, edge__edge4_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge5 = new PatternEdge(node_c6, node_c1, (int) EdgeTypes.@Edge, "edge__edge5", edge__edge5_AllowedTypes, edge__edge5_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge6 = new PatternEdge(node_c1, node_c2, (int) EdgeTypes.@Edge, "edge__edge6", edge__edge6_AllowedTypes, edge__edge6_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge7 = new PatternEdge(node_c3, node_c4, (int) EdgeTypes.@Edge, "edge__edge7", edge__edge7_AllowedTypes, edge__edge7_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge8 = new PatternEdge(node_c5, node_c6, (int) EdgeTypes.@Edge, "edge__edge8", edge__edge8_AllowedTypes, edge__edge8_IsAllowedType, PatternElementType.Normal, -1);
			PatternGraphEmbedding _subpattern0 = new PatternGraphEmbedding("_subpattern0", Pattern_Methyl.Instance, new PatternElement[] { node_c1 });
			PatternGraphEmbedding _subpattern1 = new PatternGraphEmbedding("_subpattern1", Pattern_Nitro.Instance, new PatternElement[] { node_c2 });
			PatternGraphEmbedding _subpattern2 = new PatternGraphEmbedding("_subpattern2", Pattern_Hydrogen.Instance, new PatternElement[] { node_c3 });
			PatternGraphEmbedding _subpattern3 = new PatternGraphEmbedding("_subpattern3", Pattern_Nitro.Instance, new PatternElement[] { node_c4 });
			PatternGraphEmbedding _subpattern4 = new PatternGraphEmbedding("_subpattern4", Pattern_Hydrogen.Instance, new PatternElement[] { node_c5 });
			PatternGraphEmbedding _subpattern5 = new PatternGraphEmbedding("_subpattern5", Pattern_Hydrogen.Instance, new PatternElement[] { node_c6 });
			patternGraph = new PatternGraph(
				"test DNT.pattern",
				new PatternNode[] { node_c1, node_c2, node_c3, node_c4, node_c5, node_c6 }, 
				new PatternEdge[] { edge__edge0, edge__edge1, edge__edge2, edge__edge3, edge__edge4, edge__edge5, edge__edge6, edge__edge7, edge__edge8 }, 
				new PatternGraphEmbedding[] { _subpattern0, _subpattern1, _subpattern2, _subpattern3, _subpattern4, _subpattern5 }, 
				new Condition[] { },
				new bool[6, 6] {
					{ true, false, false, false, false, false, },
					{ false, true, false, false, false, false, },
					{ false, false, true, false, false, false, },
					{ false, false, false, true, false, false, },
					{ false, false, false, false, true, false, },
					{ false, false, false, false, false, true, },
				},
				new bool[9, 9] {
					{ true, false, false, false, false, false, false, false, false, },
					{ false, true, false, false, false, false, false, false, false, },
					{ false, false, true, false, false, false, false, false, false, },
					{ false, false, false, true, false, false, false, false, false, },
					{ false, false, false, false, true, false, false, false, false, },
					{ false, false, false, false, false, true, false, false, false, },
					{ false, false, false, false, false, false, true, false, false, },
					{ false, false, false, false, false, false, false, true, false, },
					{ false, false, false, false, false, false, false, false, true, },
				},
				new bool[] {
					false, false, false, false, false, false, },
				new bool[] {
					false, false, false, false, false, false, false, false, false, },
				new bool[] {
					true, true, true, true, true, true, },
				new bool[] {
					true, true, true, true, true, true, true, true, true, }
			);

			negativePatternGraphs = new PatternGraph[] {};
			inputs = new GrGenType[] { };
			inputNames = new string[] { };
			outputs = new GrGenType[] { };
			outputNames = new string[] { };
		}


		public override IGraphElement[] Modify(LGSPGraph graph, LGSPMatch match)
		{  // test does not have modifications
			return EmptyReturnElements;
		}
		public override IGraphElement[] ModifyNoReuse(LGSPGraph graph, LGSPMatch match)
		{  // test does not have modifications
			return EmptyReturnElements;
		}
		private static String[] addedNodeNames = new String[] {};
		public override String[] AddedNodeNames { get { return addedNodeNames; } }
		private static String[] addedEdgeNames = new String[] {};
		public override String[] AddedEdgeNames { get { return addedEdgeNames; } }
	}

#if INITIAL_WARMUP
	public class Schedule_DNT : LGSPStaticScheduleInfo
	{
		public Schedule_DNT()
		{
			ActionName = "DNT";
			this.RulePattern = Rule_DNT.Instance;
			NodeCost = new float[] { 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F,  };
			EdgeCost = new float[] { 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F,  };
			NegNodeCost = new float[][] { };
			NegEdgeCost = new float[][] { };
		}
	}
#endif

	public class Rule_DNTUnfolded : LGSPRulePattern
	{
		private static Rule_DNTUnfolded instance = null;
		public static Rule_DNTUnfolded Instance { get { if (instance==null) instance = new Rule_DNTUnfolded(); return instance; } }

		public static NodeType[] node_c1_AllowedTypes = null;
		public static NodeType[] node_c2_AllowedTypes = null;
		public static NodeType[] node_c3_AllowedTypes = null;
		public static NodeType[] node_c4_AllowedTypes = null;
		public static NodeType[] node_c5_AllowedTypes = null;
		public static NodeType[] node_c6_AllowedTypes = null;
		public static NodeType[] node_c_AllowedTypes = null;
		public static NodeType[] node__node0_AllowedTypes = null;
		public static NodeType[] node__node1_AllowedTypes = null;
		public static NodeType[] node__node2_AllowedTypes = null;
		public static NodeType[] node_n2_AllowedTypes = null;
		public static NodeType[] node__node3_AllowedTypes = null;
		public static NodeType[] node__node4_AllowedTypes = null;
		public static NodeType[] node__node5_AllowedTypes = null;
		public static NodeType[] node_n4_AllowedTypes = null;
		public static NodeType[] node__node6_AllowedTypes = null;
		public static NodeType[] node__node7_AllowedTypes = null;
		public static NodeType[] node__node8_AllowedTypes = null;
		public static NodeType[] node__node9_AllowedTypes = null;
		public static bool[] node_c1_IsAllowedType = null;
		public static bool[] node_c2_IsAllowedType = null;
		public static bool[] node_c3_IsAllowedType = null;
		public static bool[] node_c4_IsAllowedType = null;
		public static bool[] node_c5_IsAllowedType = null;
		public static bool[] node_c6_IsAllowedType = null;
		public static bool[] node_c_IsAllowedType = null;
		public static bool[] node__node0_IsAllowedType = null;
		public static bool[] node__node1_IsAllowedType = null;
		public static bool[] node__node2_IsAllowedType = null;
		public static bool[] node_n2_IsAllowedType = null;
		public static bool[] node__node3_IsAllowedType = null;
		public static bool[] node__node4_IsAllowedType = null;
		public static bool[] node__node5_IsAllowedType = null;
		public static bool[] node_n4_IsAllowedType = null;
		public static bool[] node__node6_IsAllowedType = null;
		public static bool[] node__node7_IsAllowedType = null;
		public static bool[] node__node8_IsAllowedType = null;
		public static bool[] node__node9_IsAllowedType = null;
		public static EdgeType[] edge__edge0_AllowedTypes = null;
		public static EdgeType[] edge__edge1_AllowedTypes = null;
		public static EdgeType[] edge__edge2_AllowedTypes = null;
		public static EdgeType[] edge__edge3_AllowedTypes = null;
		public static EdgeType[] edge__edge4_AllowedTypes = null;
		public static EdgeType[] edge__edge5_AllowedTypes = null;
		public static EdgeType[] edge__edge6_AllowedTypes = null;
		public static EdgeType[] edge__edge7_AllowedTypes = null;
		public static EdgeType[] edge__edge8_AllowedTypes = null;
		public static EdgeType[] edge__edge9_AllowedTypes = null;
		public static EdgeType[] edge__edge10_AllowedTypes = null;
		public static EdgeType[] edge__edge11_AllowedTypes = null;
		public static EdgeType[] edge__edge12_AllowedTypes = null;
		public static EdgeType[] edge__edge13_AllowedTypes = null;
		public static EdgeType[] edge__edge14_AllowedTypes = null;
		public static EdgeType[] edge__edge15_AllowedTypes = null;
		public static EdgeType[] edge__edge16_AllowedTypes = null;
		public static EdgeType[] edge__edge17_AllowedTypes = null;
		public static EdgeType[] edge__edge18_AllowedTypes = null;
		public static EdgeType[] edge__edge19_AllowedTypes = null;
		public static EdgeType[] edge__edge20_AllowedTypes = null;
		public static EdgeType[] edge__edge21_AllowedTypes = null;
		public static bool[] edge__edge0_IsAllowedType = null;
		public static bool[] edge__edge1_IsAllowedType = null;
		public static bool[] edge__edge2_IsAllowedType = null;
		public static bool[] edge__edge3_IsAllowedType = null;
		public static bool[] edge__edge4_IsAllowedType = null;
		public static bool[] edge__edge5_IsAllowedType = null;
		public static bool[] edge__edge6_IsAllowedType = null;
		public static bool[] edge__edge7_IsAllowedType = null;
		public static bool[] edge__edge8_IsAllowedType = null;
		public static bool[] edge__edge9_IsAllowedType = null;
		public static bool[] edge__edge10_IsAllowedType = null;
		public static bool[] edge__edge11_IsAllowedType = null;
		public static bool[] edge__edge12_IsAllowedType = null;
		public static bool[] edge__edge13_IsAllowedType = null;
		public static bool[] edge__edge14_IsAllowedType = null;
		public static bool[] edge__edge15_IsAllowedType = null;
		public static bool[] edge__edge16_IsAllowedType = null;
		public static bool[] edge__edge17_IsAllowedType = null;
		public static bool[] edge__edge18_IsAllowedType = null;
		public static bool[] edge__edge19_IsAllowedType = null;
		public static bool[] edge__edge20_IsAllowedType = null;
		public static bool[] edge__edge21_IsAllowedType = null;

		public enum NodeNums { @c1, @c2, @c3, @c4, @c5, @c6, @c, @_node0, @_node1, @_node2, @n2, @_node3, @_node4, @_node5, @n4, @_node6, @_node7, @_node8, @_node9, };
		public enum EdgeNums { @_edge0, @_edge1, @_edge2, @_edge3, @_edge4, @_edge5, @_edge6, @_edge7, @_edge8, @_edge9, @_edge10, @_edge11, @_edge12, @_edge13, @_edge14, @_edge15, @_edge16, @_edge17, @_edge18, @_edge19, @_edge20, @_edge21, };
		public enum PatternNums { };

		private Rule_DNTUnfolded()
		{
			name = "DNTUnfolded";
			isSubpattern = false;
			PatternNode node_c1 = new PatternNode((int) NodeTypes.@C, "node_c1", node_c1_AllowedTypes, node_c1_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c2 = new PatternNode((int) NodeTypes.@C, "node_c2", node_c2_AllowedTypes, node_c2_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c3 = new PatternNode((int) NodeTypes.@C, "node_c3", node_c3_AllowedTypes, node_c3_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c4 = new PatternNode((int) NodeTypes.@C, "node_c4", node_c4_AllowedTypes, node_c4_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c5 = new PatternNode((int) NodeTypes.@C, "node_c5", node_c5_AllowedTypes, node_c5_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c6 = new PatternNode((int) NodeTypes.@C, "node_c6", node_c6_AllowedTypes, node_c6_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c = new PatternNode((int) NodeTypes.@C, "node_c", node_c_AllowedTypes, node_c_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node0 = new PatternNode((int) NodeTypes.@H, "node__node0", node__node0_AllowedTypes, node__node0_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node1 = new PatternNode((int) NodeTypes.@H, "node__node1", node__node1_AllowedTypes, node__node1_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node2 = new PatternNode((int) NodeTypes.@H, "node__node2", node__node2_AllowedTypes, node__node2_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_n2 = new PatternNode((int) NodeTypes.@N, "node_n2", node_n2_AllowedTypes, node_n2_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node3 = new PatternNode((int) NodeTypes.@O, "node__node3", node__node3_AllowedTypes, node__node3_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node4 = new PatternNode((int) NodeTypes.@O, "node__node4", node__node4_AllowedTypes, node__node4_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node5 = new PatternNode((int) NodeTypes.@H, "node__node5", node__node5_AllowedTypes, node__node5_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_n4 = new PatternNode((int) NodeTypes.@N, "node_n4", node_n4_AllowedTypes, node_n4_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node6 = new PatternNode((int) NodeTypes.@O, "node__node6", node__node6_AllowedTypes, node__node6_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node7 = new PatternNode((int) NodeTypes.@O, "node__node7", node__node7_AllowedTypes, node__node7_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node8 = new PatternNode((int) NodeTypes.@H, "node__node8", node__node8_AllowedTypes, node__node8_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node9 = new PatternNode((int) NodeTypes.@H, "node__node9", node__node9_AllowedTypes, node__node9_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge0 = new PatternEdge(node_c1, node_c2, (int) EdgeTypes.@Edge, "edge__edge0", edge__edge0_AllowedTypes, edge__edge0_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge1 = new PatternEdge(node_c2, node_c3, (int) EdgeTypes.@Edge, "edge__edge1", edge__edge1_AllowedTypes, edge__edge1_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge2 = new PatternEdge(node_c3, node_c4, (int) EdgeTypes.@Edge, "edge__edge2", edge__edge2_AllowedTypes, edge__edge2_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge3 = new PatternEdge(node_c4, node_c5, (int) EdgeTypes.@Edge, "edge__edge3", edge__edge3_AllowedTypes, edge__edge3_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge4 = new PatternEdge(node_c5, node_c6, (int) EdgeTypes.@Edge, "edge__edge4", edge__edge4_AllowedTypes, edge__edge4_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge5 = new PatternEdge(node_c6, node_c1, (int) EdgeTypes.@Edge, "edge__edge5", edge__edge5_AllowedTypes, edge__edge5_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge6 = new PatternEdge(node_c1, node_c2, (int) EdgeTypes.@Edge, "edge__edge6", edge__edge6_AllowedTypes, edge__edge6_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge7 = new PatternEdge(node_c3, node_c4, (int) EdgeTypes.@Edge, "edge__edge7", edge__edge7_AllowedTypes, edge__edge7_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge8 = new PatternEdge(node_c5, node_c6, (int) EdgeTypes.@Edge, "edge__edge8", edge__edge8_AllowedTypes, edge__edge8_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge9 = new PatternEdge(node_c1, node_c, (int) EdgeTypes.@Edge, "edge__edge9", edge__edge9_AllowedTypes, edge__edge9_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge10 = new PatternEdge(node_c, node__node0, (int) EdgeTypes.@Edge, "edge__edge10", edge__edge10_AllowedTypes, edge__edge10_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge11 = new PatternEdge(node_c, node__node1, (int) EdgeTypes.@Edge, "edge__edge11", edge__edge11_AllowedTypes, edge__edge11_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge12 = new PatternEdge(node_c, node__node2, (int) EdgeTypes.@Edge, "edge__edge12", edge__edge12_AllowedTypes, edge__edge12_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge13 = new PatternEdge(node_c2, node_n2, (int) EdgeTypes.@Edge, "edge__edge13", edge__edge13_AllowedTypes, edge__edge13_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge14 = new PatternEdge(node_n2, node__node3, (int) EdgeTypes.@Edge, "edge__edge14", edge__edge14_AllowedTypes, edge__edge14_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge15 = new PatternEdge(node_n2, node__node4, (int) EdgeTypes.@Edge, "edge__edge15", edge__edge15_AllowedTypes, edge__edge15_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge16 = new PatternEdge(node_c3, node__node5, (int) EdgeTypes.@Edge, "edge__edge16", edge__edge16_AllowedTypes, edge__edge16_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge17 = new PatternEdge(node_c4, node_n4, (int) EdgeTypes.@Edge, "edge__edge17", edge__edge17_AllowedTypes, edge__edge17_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge18 = new PatternEdge(node_n4, node__node6, (int) EdgeTypes.@Edge, "edge__edge18", edge__edge18_AllowedTypes, edge__edge18_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge19 = new PatternEdge(node_n4, node__node7, (int) EdgeTypes.@Edge, "edge__edge19", edge__edge19_AllowedTypes, edge__edge19_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge20 = new PatternEdge(node_c5, node__node8, (int) EdgeTypes.@Edge, "edge__edge20", edge__edge20_AllowedTypes, edge__edge20_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge21 = new PatternEdge(node_c6, node__node9, (int) EdgeTypes.@Edge, "edge__edge21", edge__edge21_AllowedTypes, edge__edge21_IsAllowedType, PatternElementType.Normal, -1);
			patternGraph = new PatternGraph(
				"test DNTUnfolded.pattern",
				new PatternNode[] { node_c1, node_c2, node_c3, node_c4, node_c5, node_c6, node_c, node__node0, node__node1, node__node2, node_n2, node__node3, node__node4, node__node5, node_n4, node__node6, node__node7, node__node8, node__node9 }, 
				new PatternEdge[] { edge__edge0, edge__edge1, edge__edge2, edge__edge3, edge__edge4, edge__edge5, edge__edge6, edge__edge7, edge__edge8, edge__edge9, edge__edge10, edge__edge11, edge__edge12, edge__edge13, edge__edge14, edge__edge15, edge__edge16, edge__edge17, edge__edge18, edge__edge19, edge__edge20, edge__edge21 }, 
				new PatternGraphEmbedding[] {  }, 
				new Condition[] { },
				new bool[19, 19] {
					{ true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, },
				},
				new bool[22, 22] {
					{ true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, },
				},
				new bool[] {
					false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
				new bool[] {
					false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
				new bool[] {
					true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, },
				new bool[] {
					true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, }
			);

			negativePatternGraphs = new PatternGraph[] {};
			inputs = new GrGenType[] { };
			inputNames = new string[] { };
			outputs = new GrGenType[] { };
			outputNames = new string[] { };
		}


		public override IGraphElement[] Modify(LGSPGraph graph, LGSPMatch match)
		{  // test does not have modifications
			return EmptyReturnElements;
		}
		public override IGraphElement[] ModifyNoReuse(LGSPGraph graph, LGSPMatch match)
		{  // test does not have modifications
			return EmptyReturnElements;
		}
		private static String[] addedNodeNames = new String[] {};
		public override String[] AddedNodeNames { get { return addedNodeNames; } }
		private static String[] addedEdgeNames = new String[] {};
		public override String[] AddedEdgeNames { get { return addedEdgeNames; } }
	}

#if INITIAL_WARMUP
	public class Schedule_DNTUnfolded : LGSPStaticScheduleInfo
	{
		public Schedule_DNTUnfolded()
		{
			ActionName = "DNTUnfolded";
			this.RulePattern = Rule_DNTUnfolded.Instance;
			NodeCost = new float[] { 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F,  };
			EdgeCost = new float[] { 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F,  };
			NegNodeCost = new float[][] { };
			NegEdgeCost = new float[][] { };
		}
	}
#endif

	public class Rule_TNB : LGSPRulePattern
	{
		private static Rule_TNB instance = null;
		public static Rule_TNB Instance { get { if (instance==null) instance = new Rule_TNB(); return instance; } }

		public static NodeType[] node_c1_AllowedTypes = null;
		public static NodeType[] node_c2_AllowedTypes = null;
		public static NodeType[] node_c3_AllowedTypes = null;
		public static NodeType[] node_c4_AllowedTypes = null;
		public static NodeType[] node_c5_AllowedTypes = null;
		public static NodeType[] node_c6_AllowedTypes = null;
		public static bool[] node_c1_IsAllowedType = null;
		public static bool[] node_c2_IsAllowedType = null;
		public static bool[] node_c3_IsAllowedType = null;
		public static bool[] node_c4_IsAllowedType = null;
		public static bool[] node_c5_IsAllowedType = null;
		public static bool[] node_c6_IsAllowedType = null;
		public static EdgeType[] edge__edge0_AllowedTypes = null;
		public static EdgeType[] edge__edge1_AllowedTypes = null;
		public static EdgeType[] edge__edge2_AllowedTypes = null;
		public static EdgeType[] edge__edge3_AllowedTypes = null;
		public static EdgeType[] edge__edge4_AllowedTypes = null;
		public static EdgeType[] edge__edge5_AllowedTypes = null;
		public static EdgeType[] edge__edge6_AllowedTypes = null;
		public static EdgeType[] edge__edge7_AllowedTypes = null;
		public static EdgeType[] edge__edge8_AllowedTypes = null;
		public static bool[] edge__edge0_IsAllowedType = null;
		public static bool[] edge__edge1_IsAllowedType = null;
		public static bool[] edge__edge2_IsAllowedType = null;
		public static bool[] edge__edge3_IsAllowedType = null;
		public static bool[] edge__edge4_IsAllowedType = null;
		public static bool[] edge__edge5_IsAllowedType = null;
		public static bool[] edge__edge6_IsAllowedType = null;
		public static bool[] edge__edge7_IsAllowedType = null;
		public static bool[] edge__edge8_IsAllowedType = null;

		public enum NodeNums { @c1, @c2, @c3, @c4, @c5, @c6, };
		public enum EdgeNums { @_edge0, @_edge1, @_edge2, @_edge3, @_edge4, @_edge5, @_edge6, @_edge7, @_edge8, };
		public enum PatternNums { @_subpattern0, @_subpattern1, @_subpattern2, @_subpattern3, @_subpattern4, @_subpattern5, };

		private Rule_TNB()
		{
			name = "TNB";
			isSubpattern = false;
			PatternNode node_c1 = new PatternNode((int) NodeTypes.@C, "node_c1", node_c1_AllowedTypes, node_c1_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c2 = new PatternNode((int) NodeTypes.@C, "node_c2", node_c2_AllowedTypes, node_c2_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c3 = new PatternNode((int) NodeTypes.@C, "node_c3", node_c3_AllowedTypes, node_c3_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c4 = new PatternNode((int) NodeTypes.@C, "node_c4", node_c4_AllowedTypes, node_c4_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c5 = new PatternNode((int) NodeTypes.@C, "node_c5", node_c5_AllowedTypes, node_c5_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c6 = new PatternNode((int) NodeTypes.@C, "node_c6", node_c6_AllowedTypes, node_c6_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge0 = new PatternEdge(node_c1, node_c2, (int) EdgeTypes.@Edge, "edge__edge0", edge__edge0_AllowedTypes, edge__edge0_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge1 = new PatternEdge(node_c2, node_c3, (int) EdgeTypes.@Edge, "edge__edge1", edge__edge1_AllowedTypes, edge__edge1_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge2 = new PatternEdge(node_c3, node_c4, (int) EdgeTypes.@Edge, "edge__edge2", edge__edge2_AllowedTypes, edge__edge2_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge3 = new PatternEdge(node_c4, node_c5, (int) EdgeTypes.@Edge, "edge__edge3", edge__edge3_AllowedTypes, edge__edge3_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge4 = new PatternEdge(node_c5, node_c6, (int) EdgeTypes.@Edge, "edge__edge4", edge__edge4_AllowedTypes, edge__edge4_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge5 = new PatternEdge(node_c6, node_c1, (int) EdgeTypes.@Edge, "edge__edge5", edge__edge5_AllowedTypes, edge__edge5_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge6 = new PatternEdge(node_c1, node_c2, (int) EdgeTypes.@Edge, "edge__edge6", edge__edge6_AllowedTypes, edge__edge6_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge7 = new PatternEdge(node_c3, node_c4, (int) EdgeTypes.@Edge, "edge__edge7", edge__edge7_AllowedTypes, edge__edge7_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge8 = new PatternEdge(node_c5, node_c6, (int) EdgeTypes.@Edge, "edge__edge8", edge__edge8_AllowedTypes, edge__edge8_IsAllowedType, PatternElementType.Normal, -1);
			PatternGraphEmbedding _subpattern0 = new PatternGraphEmbedding("_subpattern0", Pattern_Hydrogen.Instance, new PatternElement[] { node_c1 });
			PatternGraphEmbedding _subpattern1 = new PatternGraphEmbedding("_subpattern1", Pattern_Nitro.Instance, new PatternElement[] { node_c2 });
			PatternGraphEmbedding _subpattern2 = new PatternGraphEmbedding("_subpattern2", Pattern_Hydrogen.Instance, new PatternElement[] { node_c3 });
			PatternGraphEmbedding _subpattern3 = new PatternGraphEmbedding("_subpattern3", Pattern_Nitro.Instance, new PatternElement[] { node_c4 });
			PatternGraphEmbedding _subpattern4 = new PatternGraphEmbedding("_subpattern4", Pattern_Hydrogen.Instance, new PatternElement[] { node_c5 });
			PatternGraphEmbedding _subpattern5 = new PatternGraphEmbedding("_subpattern5", Pattern_Nitro.Instance, new PatternElement[] { node_c6 });
			patternGraph = new PatternGraph(
				"test TNB.pattern",
				new PatternNode[] { node_c1, node_c2, node_c3, node_c4, node_c5, node_c6 }, 
				new PatternEdge[] { edge__edge0, edge__edge1, edge__edge2, edge__edge3, edge__edge4, edge__edge5, edge__edge6, edge__edge7, edge__edge8 }, 
				new PatternGraphEmbedding[] { _subpattern0, _subpattern1, _subpattern2, _subpattern3, _subpattern4, _subpattern5 }, 
				new Condition[] { },
				new bool[6, 6] {
					{ true, false, false, false, false, false, },
					{ false, true, false, false, false, false, },
					{ false, false, true, false, false, false, },
					{ false, false, false, true, false, false, },
					{ false, false, false, false, true, false, },
					{ false, false, false, false, false, true, },
				},
				new bool[9, 9] {
					{ true, false, false, false, false, false, false, false, false, },
					{ false, true, false, false, false, false, false, false, false, },
					{ false, false, true, false, false, false, false, false, false, },
					{ false, false, false, true, false, false, false, false, false, },
					{ false, false, false, false, true, false, false, false, false, },
					{ false, false, false, false, false, true, false, false, false, },
					{ false, false, false, false, false, false, true, false, false, },
					{ false, false, false, false, false, false, false, true, false, },
					{ false, false, false, false, false, false, false, false, true, },
				},
				new bool[] {
					false, false, false, false, false, false, },
				new bool[] {
					false, false, false, false, false, false, false, false, false, },
				new bool[] {
					true, true, true, true, true, true, },
				new bool[] {
					true, true, true, true, true, true, true, true, true, }
			);

			negativePatternGraphs = new PatternGraph[] {};
			inputs = new GrGenType[] { };
			inputNames = new string[] { };
			outputs = new GrGenType[] { };
			outputNames = new string[] { };
		}


		public override IGraphElement[] Modify(LGSPGraph graph, LGSPMatch match)
		{  // test does not have modifications
			return EmptyReturnElements;
		}
		public override IGraphElement[] ModifyNoReuse(LGSPGraph graph, LGSPMatch match)
		{  // test does not have modifications
			return EmptyReturnElements;
		}
		private static String[] addedNodeNames = new String[] {};
		public override String[] AddedNodeNames { get { return addedNodeNames; } }
		private static String[] addedEdgeNames = new String[] {};
		public override String[] AddedEdgeNames { get { return addedEdgeNames; } }
	}

#if INITIAL_WARMUP
	public class Schedule_TNB : LGSPStaticScheduleInfo
	{
		public Schedule_TNB()
		{
			ActionName = "TNB";
			this.RulePattern = Rule_TNB.Instance;
			NodeCost = new float[] { 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F,  };
			EdgeCost = new float[] { 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F,  };
			NegNodeCost = new float[][] { };
			NegEdgeCost = new float[][] { };
		}
	}
#endif

	public class Rule_TNBUnfolded : LGSPRulePattern
	{
		private static Rule_TNBUnfolded instance = null;
		public static Rule_TNBUnfolded Instance { get { if (instance==null) instance = new Rule_TNBUnfolded(); return instance; } }

		public static NodeType[] node_c1_AllowedTypes = null;
		public static NodeType[] node_c2_AllowedTypes = null;
		public static NodeType[] node_c3_AllowedTypes = null;
		public static NodeType[] node_c4_AllowedTypes = null;
		public static NodeType[] node_c5_AllowedTypes = null;
		public static NodeType[] node_c6_AllowedTypes = null;
		public static NodeType[] node__node0_AllowedTypes = null;
		public static NodeType[] node_n2_AllowedTypes = null;
		public static NodeType[] node__node1_AllowedTypes = null;
		public static NodeType[] node__node2_AllowedTypes = null;
		public static NodeType[] node__node3_AllowedTypes = null;
		public static NodeType[] node_n4_AllowedTypes = null;
		public static NodeType[] node__node4_AllowedTypes = null;
		public static NodeType[] node__node5_AllowedTypes = null;
		public static NodeType[] node__node6_AllowedTypes = null;
		public static NodeType[] node_n6_AllowedTypes = null;
		public static NodeType[] node__node7_AllowedTypes = null;
		public static NodeType[] node__node8_AllowedTypes = null;
		public static bool[] node_c1_IsAllowedType = null;
		public static bool[] node_c2_IsAllowedType = null;
		public static bool[] node_c3_IsAllowedType = null;
		public static bool[] node_c4_IsAllowedType = null;
		public static bool[] node_c5_IsAllowedType = null;
		public static bool[] node_c6_IsAllowedType = null;
		public static bool[] node__node0_IsAllowedType = null;
		public static bool[] node_n2_IsAllowedType = null;
		public static bool[] node__node1_IsAllowedType = null;
		public static bool[] node__node2_IsAllowedType = null;
		public static bool[] node__node3_IsAllowedType = null;
		public static bool[] node_n4_IsAllowedType = null;
		public static bool[] node__node4_IsAllowedType = null;
		public static bool[] node__node5_IsAllowedType = null;
		public static bool[] node__node6_IsAllowedType = null;
		public static bool[] node_n6_IsAllowedType = null;
		public static bool[] node__node7_IsAllowedType = null;
		public static bool[] node__node8_IsAllowedType = null;
		public static EdgeType[] edge__edge0_AllowedTypes = null;
		public static EdgeType[] edge__edge1_AllowedTypes = null;
		public static EdgeType[] edge__edge2_AllowedTypes = null;
		public static EdgeType[] edge__edge3_AllowedTypes = null;
		public static EdgeType[] edge__edge4_AllowedTypes = null;
		public static EdgeType[] edge__edge5_AllowedTypes = null;
		public static EdgeType[] edge__edge6_AllowedTypes = null;
		public static EdgeType[] edge__edge7_AllowedTypes = null;
		public static EdgeType[] edge__edge8_AllowedTypes = null;
		public static EdgeType[] edge__edge9_AllowedTypes = null;
		public static EdgeType[] edge__edge10_AllowedTypes = null;
		public static EdgeType[] edge__edge11_AllowedTypes = null;
		public static EdgeType[] edge__edge12_AllowedTypes = null;
		public static EdgeType[] edge__edge13_AllowedTypes = null;
		public static EdgeType[] edge__edge14_AllowedTypes = null;
		public static EdgeType[] edge__edge15_AllowedTypes = null;
		public static EdgeType[] edge__edge16_AllowedTypes = null;
		public static EdgeType[] edge__edge17_AllowedTypes = null;
		public static EdgeType[] edge__edge18_AllowedTypes = null;
		public static EdgeType[] edge__edge19_AllowedTypes = null;
		public static EdgeType[] edge__edge20_AllowedTypes = null;
		public static bool[] edge__edge0_IsAllowedType = null;
		public static bool[] edge__edge1_IsAllowedType = null;
		public static bool[] edge__edge2_IsAllowedType = null;
		public static bool[] edge__edge3_IsAllowedType = null;
		public static bool[] edge__edge4_IsAllowedType = null;
		public static bool[] edge__edge5_IsAllowedType = null;
		public static bool[] edge__edge6_IsAllowedType = null;
		public static bool[] edge__edge7_IsAllowedType = null;
		public static bool[] edge__edge8_IsAllowedType = null;
		public static bool[] edge__edge9_IsAllowedType = null;
		public static bool[] edge__edge10_IsAllowedType = null;
		public static bool[] edge__edge11_IsAllowedType = null;
		public static bool[] edge__edge12_IsAllowedType = null;
		public static bool[] edge__edge13_IsAllowedType = null;
		public static bool[] edge__edge14_IsAllowedType = null;
		public static bool[] edge__edge15_IsAllowedType = null;
		public static bool[] edge__edge16_IsAllowedType = null;
		public static bool[] edge__edge17_IsAllowedType = null;
		public static bool[] edge__edge18_IsAllowedType = null;
		public static bool[] edge__edge19_IsAllowedType = null;
		public static bool[] edge__edge20_IsAllowedType = null;

		public enum NodeNums { @c1, @c2, @c3, @c4, @c5, @c6, @_node0, @n2, @_node1, @_node2, @_node3, @n4, @_node4, @_node5, @_node6, @n6, @_node7, @_node8, };
		public enum EdgeNums { @_edge0, @_edge1, @_edge2, @_edge3, @_edge4, @_edge5, @_edge6, @_edge7, @_edge8, @_edge9, @_edge10, @_edge11, @_edge12, @_edge13, @_edge14, @_edge15, @_edge16, @_edge17, @_edge18, @_edge19, @_edge20, };
		public enum PatternNums { };

		private Rule_TNBUnfolded()
		{
			name = "TNBUnfolded";
			isSubpattern = false;
			PatternNode node_c1 = new PatternNode((int) NodeTypes.@C, "node_c1", node_c1_AllowedTypes, node_c1_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c2 = new PatternNode((int) NodeTypes.@C, "node_c2", node_c2_AllowedTypes, node_c2_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c3 = new PatternNode((int) NodeTypes.@C, "node_c3", node_c3_AllowedTypes, node_c3_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c4 = new PatternNode((int) NodeTypes.@C, "node_c4", node_c4_AllowedTypes, node_c4_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c5 = new PatternNode((int) NodeTypes.@C, "node_c5", node_c5_AllowedTypes, node_c5_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c6 = new PatternNode((int) NodeTypes.@C, "node_c6", node_c6_AllowedTypes, node_c6_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node0 = new PatternNode((int) NodeTypes.@H, "node__node0", node__node0_AllowedTypes, node__node0_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_n2 = new PatternNode((int) NodeTypes.@N, "node_n2", node_n2_AllowedTypes, node_n2_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node1 = new PatternNode((int) NodeTypes.@O, "node__node1", node__node1_AllowedTypes, node__node1_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node2 = new PatternNode((int) NodeTypes.@O, "node__node2", node__node2_AllowedTypes, node__node2_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node3 = new PatternNode((int) NodeTypes.@H, "node__node3", node__node3_AllowedTypes, node__node3_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_n4 = new PatternNode((int) NodeTypes.@N, "node_n4", node_n4_AllowedTypes, node_n4_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node4 = new PatternNode((int) NodeTypes.@O, "node__node4", node__node4_AllowedTypes, node__node4_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node5 = new PatternNode((int) NodeTypes.@O, "node__node5", node__node5_AllowedTypes, node__node5_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node6 = new PatternNode((int) NodeTypes.@H, "node__node6", node__node6_AllowedTypes, node__node6_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_n6 = new PatternNode((int) NodeTypes.@N, "node_n6", node_n6_AllowedTypes, node_n6_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node7 = new PatternNode((int) NodeTypes.@O, "node__node7", node__node7_AllowedTypes, node__node7_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node8 = new PatternNode((int) NodeTypes.@O, "node__node8", node__node8_AllowedTypes, node__node8_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge0 = new PatternEdge(node_c1, node_c2, (int) EdgeTypes.@Edge, "edge__edge0", edge__edge0_AllowedTypes, edge__edge0_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge1 = new PatternEdge(node_c2, node_c3, (int) EdgeTypes.@Edge, "edge__edge1", edge__edge1_AllowedTypes, edge__edge1_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge2 = new PatternEdge(node_c3, node_c4, (int) EdgeTypes.@Edge, "edge__edge2", edge__edge2_AllowedTypes, edge__edge2_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge3 = new PatternEdge(node_c4, node_c5, (int) EdgeTypes.@Edge, "edge__edge3", edge__edge3_AllowedTypes, edge__edge3_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge4 = new PatternEdge(node_c5, node_c6, (int) EdgeTypes.@Edge, "edge__edge4", edge__edge4_AllowedTypes, edge__edge4_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge5 = new PatternEdge(node_c6, node_c1, (int) EdgeTypes.@Edge, "edge__edge5", edge__edge5_AllowedTypes, edge__edge5_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge6 = new PatternEdge(node_c1, node_c2, (int) EdgeTypes.@Edge, "edge__edge6", edge__edge6_AllowedTypes, edge__edge6_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge7 = new PatternEdge(node_c3, node_c4, (int) EdgeTypes.@Edge, "edge__edge7", edge__edge7_AllowedTypes, edge__edge7_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge8 = new PatternEdge(node_c5, node_c6, (int) EdgeTypes.@Edge, "edge__edge8", edge__edge8_AllowedTypes, edge__edge8_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge9 = new PatternEdge(node_c1, node__node0, (int) EdgeTypes.@Edge, "edge__edge9", edge__edge9_AllowedTypes, edge__edge9_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge10 = new PatternEdge(node_c2, node_n2, (int) EdgeTypes.@Edge, "edge__edge10", edge__edge10_AllowedTypes, edge__edge10_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge11 = new PatternEdge(node_n2, node__node1, (int) EdgeTypes.@Edge, "edge__edge11", edge__edge11_AllowedTypes, edge__edge11_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge12 = new PatternEdge(node_n2, node__node2, (int) EdgeTypes.@Edge, "edge__edge12", edge__edge12_AllowedTypes, edge__edge12_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge13 = new PatternEdge(node_c3, node__node3, (int) EdgeTypes.@Edge, "edge__edge13", edge__edge13_AllowedTypes, edge__edge13_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge14 = new PatternEdge(node_c4, node_n4, (int) EdgeTypes.@Edge, "edge__edge14", edge__edge14_AllowedTypes, edge__edge14_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge15 = new PatternEdge(node_n4, node__node4, (int) EdgeTypes.@Edge, "edge__edge15", edge__edge15_AllowedTypes, edge__edge15_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge16 = new PatternEdge(node_n4, node__node5, (int) EdgeTypes.@Edge, "edge__edge16", edge__edge16_AllowedTypes, edge__edge16_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge17 = new PatternEdge(node_c5, node__node6, (int) EdgeTypes.@Edge, "edge__edge17", edge__edge17_AllowedTypes, edge__edge17_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge18 = new PatternEdge(node_c6, node_n6, (int) EdgeTypes.@Edge, "edge__edge18", edge__edge18_AllowedTypes, edge__edge18_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge19 = new PatternEdge(node_n6, node__node7, (int) EdgeTypes.@Edge, "edge__edge19", edge__edge19_AllowedTypes, edge__edge19_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge20 = new PatternEdge(node_n6, node__node8, (int) EdgeTypes.@Edge, "edge__edge20", edge__edge20_AllowedTypes, edge__edge20_IsAllowedType, PatternElementType.Normal, -1);
			patternGraph = new PatternGraph(
				"test TNBUnfolded.pattern",
				new PatternNode[] { node_c1, node_c2, node_c3, node_c4, node_c5, node_c6, node__node0, node_n2, node__node1, node__node2, node__node3, node_n4, node__node4, node__node5, node__node6, node_n6, node__node7, node__node8 }, 
				new PatternEdge[] { edge__edge0, edge__edge1, edge__edge2, edge__edge3, edge__edge4, edge__edge5, edge__edge6, edge__edge7, edge__edge8, edge__edge9, edge__edge10, edge__edge11, edge__edge12, edge__edge13, edge__edge14, edge__edge15, edge__edge16, edge__edge17, edge__edge18, edge__edge19, edge__edge20 }, 
				new PatternGraphEmbedding[] {  }, 
				new Condition[] { },
				new bool[18, 18] {
					{ true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, },
				},
				new bool[21, 21] {
					{ true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, },
				},
				new bool[] {
					false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
				new bool[] {
					false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
				new bool[] {
					true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, },
				new bool[] {
					true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, }
			);

			negativePatternGraphs = new PatternGraph[] {};
			inputs = new GrGenType[] { };
			inputNames = new string[] { };
			outputs = new GrGenType[] { };
			outputNames = new string[] { };
		}


		public override IGraphElement[] Modify(LGSPGraph graph, LGSPMatch match)
		{  // test does not have modifications
			return EmptyReturnElements;
		}
		public override IGraphElement[] ModifyNoReuse(LGSPGraph graph, LGSPMatch match)
		{  // test does not have modifications
			return EmptyReturnElements;
		}
		private static String[] addedNodeNames = new String[] {};
		public override String[] AddedNodeNames { get { return addedNodeNames; } }
		private static String[] addedEdgeNames = new String[] {};
		public override String[] AddedEdgeNames { get { return addedEdgeNames; } }
	}

#if INITIAL_WARMUP
	public class Schedule_TNBUnfolded : LGSPStaticScheduleInfo
	{
		public Schedule_TNBUnfolded()
		{
			ActionName = "TNBUnfolded";
			this.RulePattern = Rule_TNBUnfolded.Instance;
			NodeCost = new float[] { 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F,  };
			EdgeCost = new float[] { 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F,  };
			NegNodeCost = new float[][] { };
			NegEdgeCost = new float[][] { };
		}
	}
#endif

	public class Rule_TNT : LGSPRulePattern
	{
		private static Rule_TNT instance = null;
		public static Rule_TNT Instance { get { if (instance==null) instance = new Rule_TNT(); return instance; } }

		public static NodeType[] node_c1_AllowedTypes = null;
		public static NodeType[] node_c2_AllowedTypes = null;
		public static NodeType[] node_c3_AllowedTypes = null;
		public static NodeType[] node_c4_AllowedTypes = null;
		public static NodeType[] node_c5_AllowedTypes = null;
		public static NodeType[] node_c6_AllowedTypes = null;
		public static bool[] node_c1_IsAllowedType = null;
		public static bool[] node_c2_IsAllowedType = null;
		public static bool[] node_c3_IsAllowedType = null;
		public static bool[] node_c4_IsAllowedType = null;
		public static bool[] node_c5_IsAllowedType = null;
		public static bool[] node_c6_IsAllowedType = null;
		public static EdgeType[] edge__edge0_AllowedTypes = null;
		public static EdgeType[] edge__edge1_AllowedTypes = null;
		public static EdgeType[] edge__edge2_AllowedTypes = null;
		public static EdgeType[] edge__edge3_AllowedTypes = null;
		public static EdgeType[] edge__edge4_AllowedTypes = null;
		public static EdgeType[] edge__edge5_AllowedTypes = null;
		public static EdgeType[] edge__edge6_AllowedTypes = null;
		public static EdgeType[] edge__edge7_AllowedTypes = null;
		public static EdgeType[] edge__edge8_AllowedTypes = null;
		public static bool[] edge__edge0_IsAllowedType = null;
		public static bool[] edge__edge1_IsAllowedType = null;
		public static bool[] edge__edge2_IsAllowedType = null;
		public static bool[] edge__edge3_IsAllowedType = null;
		public static bool[] edge__edge4_IsAllowedType = null;
		public static bool[] edge__edge5_IsAllowedType = null;
		public static bool[] edge__edge6_IsAllowedType = null;
		public static bool[] edge__edge7_IsAllowedType = null;
		public static bool[] edge__edge8_IsAllowedType = null;

		public enum NodeNums { @c1, @c2, @c3, @c4, @c5, @c6, };
		public enum EdgeNums { @_edge0, @_edge1, @_edge2, @_edge3, @_edge4, @_edge5, @_edge6, @_edge7, @_edge8, };
		public enum PatternNums { @_subpattern0, @_subpattern1, @_subpattern2, @_subpattern3, @_subpattern4, @_subpattern5, };

		private Rule_TNT()
		{
			name = "TNT";
			isSubpattern = false;
			PatternNode node_c1 = new PatternNode((int) NodeTypes.@C, "node_c1", node_c1_AllowedTypes, node_c1_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c2 = new PatternNode((int) NodeTypes.@C, "node_c2", node_c2_AllowedTypes, node_c2_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c3 = new PatternNode((int) NodeTypes.@C, "node_c3", node_c3_AllowedTypes, node_c3_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c4 = new PatternNode((int) NodeTypes.@C, "node_c4", node_c4_AllowedTypes, node_c4_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c5 = new PatternNode((int) NodeTypes.@C, "node_c5", node_c5_AllowedTypes, node_c5_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c6 = new PatternNode((int) NodeTypes.@C, "node_c6", node_c6_AllowedTypes, node_c6_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge0 = new PatternEdge(node_c1, node_c2, (int) EdgeTypes.@Edge, "edge__edge0", edge__edge0_AllowedTypes, edge__edge0_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge1 = new PatternEdge(node_c2, node_c3, (int) EdgeTypes.@Edge, "edge__edge1", edge__edge1_AllowedTypes, edge__edge1_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge2 = new PatternEdge(node_c3, node_c4, (int) EdgeTypes.@Edge, "edge__edge2", edge__edge2_AllowedTypes, edge__edge2_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge3 = new PatternEdge(node_c4, node_c5, (int) EdgeTypes.@Edge, "edge__edge3", edge__edge3_AllowedTypes, edge__edge3_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge4 = new PatternEdge(node_c5, node_c6, (int) EdgeTypes.@Edge, "edge__edge4", edge__edge4_AllowedTypes, edge__edge4_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge5 = new PatternEdge(node_c6, node_c1, (int) EdgeTypes.@Edge, "edge__edge5", edge__edge5_AllowedTypes, edge__edge5_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge6 = new PatternEdge(node_c1, node_c2, (int) EdgeTypes.@Edge, "edge__edge6", edge__edge6_AllowedTypes, edge__edge6_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge7 = new PatternEdge(node_c3, node_c4, (int) EdgeTypes.@Edge, "edge__edge7", edge__edge7_AllowedTypes, edge__edge7_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge8 = new PatternEdge(node_c5, node_c6, (int) EdgeTypes.@Edge, "edge__edge8", edge__edge8_AllowedTypes, edge__edge8_IsAllowedType, PatternElementType.Normal, -1);
			PatternGraphEmbedding _subpattern0 = new PatternGraphEmbedding("_subpattern0", Pattern_Methyl.Instance, new PatternElement[] { node_c1 });
			PatternGraphEmbedding _subpattern1 = new PatternGraphEmbedding("_subpattern1", Pattern_Nitro.Instance, new PatternElement[] { node_c2 });
			PatternGraphEmbedding _subpattern2 = new PatternGraphEmbedding("_subpattern2", Pattern_Hydrogen.Instance, new PatternElement[] { node_c3 });
			PatternGraphEmbedding _subpattern3 = new PatternGraphEmbedding("_subpattern3", Pattern_Nitro.Instance, new PatternElement[] { node_c4 });
			PatternGraphEmbedding _subpattern4 = new PatternGraphEmbedding("_subpattern4", Pattern_Hydrogen.Instance, new PatternElement[] { node_c5 });
			PatternGraphEmbedding _subpattern5 = new PatternGraphEmbedding("_subpattern5", Pattern_Nitro.Instance, new PatternElement[] { node_c6 });
			patternGraph = new PatternGraph(
				"test TNT.pattern",
				new PatternNode[] { node_c1, node_c2, node_c3, node_c4, node_c5, node_c6 }, 
				new PatternEdge[] { edge__edge0, edge__edge1, edge__edge2, edge__edge3, edge__edge4, edge__edge5, edge__edge6, edge__edge7, edge__edge8 }, 
				new PatternGraphEmbedding[] { _subpattern0, _subpattern1, _subpattern2, _subpattern3, _subpattern4, _subpattern5 }, 
				new Condition[] { },
				new bool[6, 6] {
					{ true, false, false, false, false, false, },
					{ false, true, false, false, false, false, },
					{ false, false, true, false, false, false, },
					{ false, false, false, true, false, false, },
					{ false, false, false, false, true, false, },
					{ false, false, false, false, false, true, },
				},
				new bool[9, 9] {
					{ true, false, false, false, false, false, false, false, false, },
					{ false, true, false, false, false, false, false, false, false, },
					{ false, false, true, false, false, false, false, false, false, },
					{ false, false, false, true, false, false, false, false, false, },
					{ false, false, false, false, true, false, false, false, false, },
					{ false, false, false, false, false, true, false, false, false, },
					{ false, false, false, false, false, false, true, false, false, },
					{ false, false, false, false, false, false, false, true, false, },
					{ false, false, false, false, false, false, false, false, true, },
				},
				new bool[] {
					false, false, false, false, false, false, },
				new bool[] {
					false, false, false, false, false, false, false, false, false, },
				new bool[] {
					true, true, true, true, true, true, },
				new bool[] {
					true, true, true, true, true, true, true, true, true, }
			);

			negativePatternGraphs = new PatternGraph[] {};
			inputs = new GrGenType[] { };
			inputNames = new string[] { };
			outputs = new GrGenType[] { };
			outputNames = new string[] { };
		}


		public override IGraphElement[] Modify(LGSPGraph graph, LGSPMatch match)
		{  // test does not have modifications
			return EmptyReturnElements;
		}
		public override IGraphElement[] ModifyNoReuse(LGSPGraph graph, LGSPMatch match)
		{  // test does not have modifications
			return EmptyReturnElements;
		}
		private static String[] addedNodeNames = new String[] {};
		public override String[] AddedNodeNames { get { return addedNodeNames; } }
		private static String[] addedEdgeNames = new String[] {};
		public override String[] AddedEdgeNames { get { return addedEdgeNames; } }
	}

#if INITIAL_WARMUP
	public class Schedule_TNT : LGSPStaticScheduleInfo
	{
		public Schedule_TNT()
		{
			ActionName = "TNT";
			this.RulePattern = Rule_TNT.Instance;
			NodeCost = new float[] { 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F,  };
			EdgeCost = new float[] { 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F,  };
			NegNodeCost = new float[][] { };
			NegEdgeCost = new float[][] { };
		}
	}
#endif

	public class Rule_TNTUnfolded : LGSPRulePattern
	{
		private static Rule_TNTUnfolded instance = null;
		public static Rule_TNTUnfolded Instance { get { if (instance==null) instance = new Rule_TNTUnfolded(); return instance; } }

		public static NodeType[] node_c1_AllowedTypes = null;
		public static NodeType[] node_c2_AllowedTypes = null;
		public static NodeType[] node_c3_AllowedTypes = null;
		public static NodeType[] node_c4_AllowedTypes = null;
		public static NodeType[] node_c5_AllowedTypes = null;
		public static NodeType[] node_c6_AllowedTypes = null;
		public static NodeType[] node_c_AllowedTypes = null;
		public static NodeType[] node__node0_AllowedTypes = null;
		public static NodeType[] node__node1_AllowedTypes = null;
		public static NodeType[] node__node2_AllowedTypes = null;
		public static NodeType[] node_n2_AllowedTypes = null;
		public static NodeType[] node__node3_AllowedTypes = null;
		public static NodeType[] node__node4_AllowedTypes = null;
		public static NodeType[] node__node5_AllowedTypes = null;
		public static NodeType[] node_n4_AllowedTypes = null;
		public static NodeType[] node__node6_AllowedTypes = null;
		public static NodeType[] node__node7_AllowedTypes = null;
		public static NodeType[] node__node8_AllowedTypes = null;
		public static NodeType[] node_n6_AllowedTypes = null;
		public static NodeType[] node__node9_AllowedTypes = null;
		public static NodeType[] node__node10_AllowedTypes = null;
		public static bool[] node_c1_IsAllowedType = null;
		public static bool[] node_c2_IsAllowedType = null;
		public static bool[] node_c3_IsAllowedType = null;
		public static bool[] node_c4_IsAllowedType = null;
		public static bool[] node_c5_IsAllowedType = null;
		public static bool[] node_c6_IsAllowedType = null;
		public static bool[] node_c_IsAllowedType = null;
		public static bool[] node__node0_IsAllowedType = null;
		public static bool[] node__node1_IsAllowedType = null;
		public static bool[] node__node2_IsAllowedType = null;
		public static bool[] node_n2_IsAllowedType = null;
		public static bool[] node__node3_IsAllowedType = null;
		public static bool[] node__node4_IsAllowedType = null;
		public static bool[] node__node5_IsAllowedType = null;
		public static bool[] node_n4_IsAllowedType = null;
		public static bool[] node__node6_IsAllowedType = null;
		public static bool[] node__node7_IsAllowedType = null;
		public static bool[] node__node8_IsAllowedType = null;
		public static bool[] node_n6_IsAllowedType = null;
		public static bool[] node__node9_IsAllowedType = null;
		public static bool[] node__node10_IsAllowedType = null;
		public static EdgeType[] edge__edge0_AllowedTypes = null;
		public static EdgeType[] edge__edge1_AllowedTypes = null;
		public static EdgeType[] edge__edge2_AllowedTypes = null;
		public static EdgeType[] edge__edge3_AllowedTypes = null;
		public static EdgeType[] edge__edge4_AllowedTypes = null;
		public static EdgeType[] edge__edge5_AllowedTypes = null;
		public static EdgeType[] edge__edge6_AllowedTypes = null;
		public static EdgeType[] edge__edge7_AllowedTypes = null;
		public static EdgeType[] edge__edge8_AllowedTypes = null;
		public static EdgeType[] edge__edge9_AllowedTypes = null;
		public static EdgeType[] edge__edge10_AllowedTypes = null;
		public static EdgeType[] edge__edge11_AllowedTypes = null;
		public static EdgeType[] edge__edge12_AllowedTypes = null;
		public static EdgeType[] edge__edge13_AllowedTypes = null;
		public static EdgeType[] edge__edge14_AllowedTypes = null;
		public static EdgeType[] edge__edge15_AllowedTypes = null;
		public static EdgeType[] edge__edge16_AllowedTypes = null;
		public static EdgeType[] edge__edge17_AllowedTypes = null;
		public static EdgeType[] edge__edge18_AllowedTypes = null;
		public static EdgeType[] edge__edge19_AllowedTypes = null;
		public static EdgeType[] edge__edge20_AllowedTypes = null;
		public static EdgeType[] edge__edge21_AllowedTypes = null;
		public static EdgeType[] edge__edge22_AllowedTypes = null;
		public static EdgeType[] edge__edge23_AllowedTypes = null;
		public static bool[] edge__edge0_IsAllowedType = null;
		public static bool[] edge__edge1_IsAllowedType = null;
		public static bool[] edge__edge2_IsAllowedType = null;
		public static bool[] edge__edge3_IsAllowedType = null;
		public static bool[] edge__edge4_IsAllowedType = null;
		public static bool[] edge__edge5_IsAllowedType = null;
		public static bool[] edge__edge6_IsAllowedType = null;
		public static bool[] edge__edge7_IsAllowedType = null;
		public static bool[] edge__edge8_IsAllowedType = null;
		public static bool[] edge__edge9_IsAllowedType = null;
		public static bool[] edge__edge10_IsAllowedType = null;
		public static bool[] edge__edge11_IsAllowedType = null;
		public static bool[] edge__edge12_IsAllowedType = null;
		public static bool[] edge__edge13_IsAllowedType = null;
		public static bool[] edge__edge14_IsAllowedType = null;
		public static bool[] edge__edge15_IsAllowedType = null;
		public static bool[] edge__edge16_IsAllowedType = null;
		public static bool[] edge__edge17_IsAllowedType = null;
		public static bool[] edge__edge18_IsAllowedType = null;
		public static bool[] edge__edge19_IsAllowedType = null;
		public static bool[] edge__edge20_IsAllowedType = null;
		public static bool[] edge__edge21_IsAllowedType = null;
		public static bool[] edge__edge22_IsAllowedType = null;
		public static bool[] edge__edge23_IsAllowedType = null;

		public enum NodeNums { @c1, @c2, @c3, @c4, @c5, @c6, @c, @_node0, @_node1, @_node2, @n2, @_node3, @_node4, @_node5, @n4, @_node6, @_node7, @_node8, @n6, @_node9, @_node10, };
		public enum EdgeNums { @_edge0, @_edge1, @_edge2, @_edge3, @_edge4, @_edge5, @_edge6, @_edge7, @_edge8, @_edge9, @_edge10, @_edge11, @_edge12, @_edge13, @_edge14, @_edge15, @_edge16, @_edge17, @_edge18, @_edge19, @_edge20, @_edge21, @_edge22, @_edge23, };
		public enum PatternNums { };

		private Rule_TNTUnfolded()
		{
			name = "TNTUnfolded";
			isSubpattern = false;
			PatternNode node_c1 = new PatternNode((int) NodeTypes.@C, "node_c1", node_c1_AllowedTypes, node_c1_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c2 = new PatternNode((int) NodeTypes.@C, "node_c2", node_c2_AllowedTypes, node_c2_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c3 = new PatternNode((int) NodeTypes.@C, "node_c3", node_c3_AllowedTypes, node_c3_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c4 = new PatternNode((int) NodeTypes.@C, "node_c4", node_c4_AllowedTypes, node_c4_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c5 = new PatternNode((int) NodeTypes.@C, "node_c5", node_c5_AllowedTypes, node_c5_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c6 = new PatternNode((int) NodeTypes.@C, "node_c6", node_c6_AllowedTypes, node_c6_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_c = new PatternNode((int) NodeTypes.@C, "node_c", node_c_AllowedTypes, node_c_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node0 = new PatternNode((int) NodeTypes.@H, "node__node0", node__node0_AllowedTypes, node__node0_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node1 = new PatternNode((int) NodeTypes.@H, "node__node1", node__node1_AllowedTypes, node__node1_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node2 = new PatternNode((int) NodeTypes.@H, "node__node2", node__node2_AllowedTypes, node__node2_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_n2 = new PatternNode((int) NodeTypes.@N, "node_n2", node_n2_AllowedTypes, node_n2_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node3 = new PatternNode((int) NodeTypes.@O, "node__node3", node__node3_AllowedTypes, node__node3_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node4 = new PatternNode((int) NodeTypes.@O, "node__node4", node__node4_AllowedTypes, node__node4_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node5 = new PatternNode((int) NodeTypes.@H, "node__node5", node__node5_AllowedTypes, node__node5_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_n4 = new PatternNode((int) NodeTypes.@N, "node_n4", node_n4_AllowedTypes, node_n4_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node6 = new PatternNode((int) NodeTypes.@O, "node__node6", node__node6_AllowedTypes, node__node6_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node7 = new PatternNode((int) NodeTypes.@O, "node__node7", node__node7_AllowedTypes, node__node7_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node8 = new PatternNode((int) NodeTypes.@H, "node__node8", node__node8_AllowedTypes, node__node8_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node_n6 = new PatternNode((int) NodeTypes.@N, "node_n6", node_n6_AllowedTypes, node_n6_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node9 = new PatternNode((int) NodeTypes.@O, "node__node9", node__node9_AllowedTypes, node__node9_IsAllowedType, PatternElementType.Normal, -1);
			PatternNode node__node10 = new PatternNode((int) NodeTypes.@O, "node__node10", node__node10_AllowedTypes, node__node10_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge0 = new PatternEdge(node_c1, node_c2, (int) EdgeTypes.@Edge, "edge__edge0", edge__edge0_AllowedTypes, edge__edge0_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge1 = new PatternEdge(node_c2, node_c3, (int) EdgeTypes.@Edge, "edge__edge1", edge__edge1_AllowedTypes, edge__edge1_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge2 = new PatternEdge(node_c3, node_c4, (int) EdgeTypes.@Edge, "edge__edge2", edge__edge2_AllowedTypes, edge__edge2_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge3 = new PatternEdge(node_c4, node_c5, (int) EdgeTypes.@Edge, "edge__edge3", edge__edge3_AllowedTypes, edge__edge3_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge4 = new PatternEdge(node_c5, node_c6, (int) EdgeTypes.@Edge, "edge__edge4", edge__edge4_AllowedTypes, edge__edge4_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge5 = new PatternEdge(node_c6, node_c1, (int) EdgeTypes.@Edge, "edge__edge5", edge__edge5_AllowedTypes, edge__edge5_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge6 = new PatternEdge(node_c1, node_c2, (int) EdgeTypes.@Edge, "edge__edge6", edge__edge6_AllowedTypes, edge__edge6_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge7 = new PatternEdge(node_c3, node_c4, (int) EdgeTypes.@Edge, "edge__edge7", edge__edge7_AllowedTypes, edge__edge7_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge8 = new PatternEdge(node_c5, node_c6, (int) EdgeTypes.@Edge, "edge__edge8", edge__edge8_AllowedTypes, edge__edge8_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge9 = new PatternEdge(node_c1, node_c, (int) EdgeTypes.@Edge, "edge__edge9", edge__edge9_AllowedTypes, edge__edge9_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge10 = new PatternEdge(node_c, node__node0, (int) EdgeTypes.@Edge, "edge__edge10", edge__edge10_AllowedTypes, edge__edge10_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge11 = new PatternEdge(node_c, node__node1, (int) EdgeTypes.@Edge, "edge__edge11", edge__edge11_AllowedTypes, edge__edge11_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge12 = new PatternEdge(node_c, node__node2, (int) EdgeTypes.@Edge, "edge__edge12", edge__edge12_AllowedTypes, edge__edge12_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge13 = new PatternEdge(node_c2, node_n2, (int) EdgeTypes.@Edge, "edge__edge13", edge__edge13_AllowedTypes, edge__edge13_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge14 = new PatternEdge(node_n2, node__node3, (int) EdgeTypes.@Edge, "edge__edge14", edge__edge14_AllowedTypes, edge__edge14_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge15 = new PatternEdge(node_n2, node__node4, (int) EdgeTypes.@Edge, "edge__edge15", edge__edge15_AllowedTypes, edge__edge15_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge16 = new PatternEdge(node_c3, node__node5, (int) EdgeTypes.@Edge, "edge__edge16", edge__edge16_AllowedTypes, edge__edge16_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge17 = new PatternEdge(node_c4, node_n4, (int) EdgeTypes.@Edge, "edge__edge17", edge__edge17_AllowedTypes, edge__edge17_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge18 = new PatternEdge(node_n4, node__node6, (int) EdgeTypes.@Edge, "edge__edge18", edge__edge18_AllowedTypes, edge__edge18_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge19 = new PatternEdge(node_n4, node__node7, (int) EdgeTypes.@Edge, "edge__edge19", edge__edge19_AllowedTypes, edge__edge19_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge20 = new PatternEdge(node_c5, node__node8, (int) EdgeTypes.@Edge, "edge__edge20", edge__edge20_AllowedTypes, edge__edge20_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge21 = new PatternEdge(node_c6, node_n6, (int) EdgeTypes.@Edge, "edge__edge21", edge__edge21_AllowedTypes, edge__edge21_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge22 = new PatternEdge(node_n6, node__node9, (int) EdgeTypes.@Edge, "edge__edge22", edge__edge22_AllowedTypes, edge__edge22_IsAllowedType, PatternElementType.Normal, -1);
			PatternEdge edge__edge23 = new PatternEdge(node_n6, node__node10, (int) EdgeTypes.@Edge, "edge__edge23", edge__edge23_AllowedTypes, edge__edge23_IsAllowedType, PatternElementType.Normal, -1);
			patternGraph = new PatternGraph(
				"test TNTUnfolded.pattern",
				new PatternNode[] { node_c1, node_c2, node_c3, node_c4, node_c5, node_c6, node_c, node__node0, node__node1, node__node2, node_n2, node__node3, node__node4, node__node5, node_n4, node__node6, node__node7, node__node8, node_n6, node__node9, node__node10 }, 
				new PatternEdge[] { edge__edge0, edge__edge1, edge__edge2, edge__edge3, edge__edge4, edge__edge5, edge__edge6, edge__edge7, edge__edge8, edge__edge9, edge__edge10, edge__edge11, edge__edge12, edge__edge13, edge__edge14, edge__edge15, edge__edge16, edge__edge17, edge__edge18, edge__edge19, edge__edge20, edge__edge21, edge__edge22, edge__edge23 }, 
				new PatternGraphEmbedding[] {  }, 
				new Condition[] { },
				new bool[21, 21] {
					{ true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, },
				},
				new bool[24, 24] {
					{ true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, },
					{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, },
				},
				new bool[] {
					false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
				new bool[] {
					false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
				new bool[] {
					true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, },
				new bool[] {
					true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, }
			);

			negativePatternGraphs = new PatternGraph[] {};
			inputs = new GrGenType[] { };
			inputNames = new string[] { };
			outputs = new GrGenType[] { };
			outputNames = new string[] { };
		}


		public override IGraphElement[] Modify(LGSPGraph graph, LGSPMatch match)
		{  // test does not have modifications
			return EmptyReturnElements;
		}
		public override IGraphElement[] ModifyNoReuse(LGSPGraph graph, LGSPMatch match)
		{  // test does not have modifications
			return EmptyReturnElements;
		}
		private static String[] addedNodeNames = new String[] {};
		public override String[] AddedNodeNames { get { return addedNodeNames; } }
		private static String[] addedEdgeNames = new String[] {};
		public override String[] AddedEdgeNames { get { return addedEdgeNames; } }
	}

#if INITIAL_WARMUP
	public class Schedule_TNTUnfolded : LGSPStaticScheduleInfo
	{
		public Schedule_TNTUnfolded()
		{
			ActionName = "TNTUnfolded";
			this.RulePattern = Rule_TNTUnfolded.Instance;
			NodeCost = new float[] { 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F,  };
			EdgeCost = new float[] { 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F, 5.5F,  };
			NegNodeCost = new float[][] { };
			NegEdgeCost = new float[][] { };
		}
	}
#endif

	public class Rule_createDNT : LGSPRulePattern
	{
		private static Rule_createDNT instance = null;
		public static Rule_createDNT Instance { get { if (instance==null) instance = new Rule_createDNT(); return instance; } }


		public enum NodeNums { };
		public enum EdgeNums { };
		public enum PatternNums { };

		private Rule_createDNT()
		{
			name = "createDNT";
			isSubpattern = false;
			patternGraph = new PatternGraph(
				"rule createDNT.pattern",
				new PatternNode[] {  }, 
				new PatternEdge[] {  }, 
				new PatternGraphEmbedding[] {  }, 
				new Condition[] { },
				new bool[0, 0] ,
				new bool[0, 0] ,
				new bool[] {},
				new bool[] {},
				new bool[] {},
				new bool[] {}
			);

			negativePatternGraphs = new PatternGraph[] {};
			inputs = new GrGenType[] { };
			inputNames = new string[] { };
			outputs = new GrGenType[] { };
			outputNames = new string[] { };
		}


		public override IGraphElement[] Modify(LGSPGraph graph, LGSPMatch match)
		{
			Node_C node_c = Node_C.CreateNode(graph);
			Node_H node__node9 = Node_H.CreateNode(graph);
			Node_C node_c1 = Node_C.CreateNode(graph);
			Node_O node__node7 = Node_O.CreateNode(graph);
			Node_H node__node8 = Node_H.CreateNode(graph);
			Node_H node__node5 = Node_H.CreateNode(graph);
			Node_O node__node6 = Node_O.CreateNode(graph);
			Node_O node__node3 = Node_O.CreateNode(graph);
			Node_C node_c6 = Node_C.CreateNode(graph);
			Node_O node__node4 = Node_O.CreateNode(graph);
			Node_H node__node1 = Node_H.CreateNode(graph);
			Node_H node__node2 = Node_H.CreateNode(graph);
			Node_N node_n4 = Node_N.CreateNode(graph);
			Node_C node_c2 = Node_C.CreateNode(graph);
			Node_H node__node0 = Node_H.CreateNode(graph);
			Node_C node_c3 = Node_C.CreateNode(graph);
			Node_N node_n2 = Node_N.CreateNode(graph);
			Node_C node_c4 = Node_C.CreateNode(graph);
			Node_C node_c5 = Node_C.CreateNode(graph);
			Edge_Edge edge__edge8 = Edge_Edge.CreateEdge(graph, node_c5, node_c6);
			Edge_Edge edge__edge9 = Edge_Edge.CreateEdge(graph, node_c1, node_c);
			Edge_Edge edge__edge19 = Edge_Edge.CreateEdge(graph, node_n4, node__node7);
			Edge_Edge edge__edge10 = Edge_Edge.CreateEdge(graph, node_c, node__node0);
			Edge_Edge edge__edge21 = Edge_Edge.CreateEdge(graph, node_c6, node__node9);
			Edge_Edge edge__edge20 = Edge_Edge.CreateEdge(graph, node_c5, node__node8);
			Edge_Edge edge__edge18 = Edge_Edge.CreateEdge(graph, node_n4, node__node6);
			Edge_Edge edge__edge3 = Edge_Edge.CreateEdge(graph, node_c4, node_c5);
			Edge_Edge edge__edge17 = Edge_Edge.CreateEdge(graph, node_c4, node_n4);
			Edge_Edge edge__edge2 = Edge_Edge.CreateEdge(graph, node_c3, node_c4);
			Edge_Edge edge__edge16 = Edge_Edge.CreateEdge(graph, node_c3, node__node5);
			Edge_Edge edge__edge1 = Edge_Edge.CreateEdge(graph, node_c2, node_c3);
			Edge_Edge edge__edge15 = Edge_Edge.CreateEdge(graph, node_n2, node__node4);
			Edge_Edge edge__edge0 = Edge_Edge.CreateEdge(graph, node_c1, node_c2);
			Edge_Edge edge__edge14 = Edge_Edge.CreateEdge(graph, node_n2, node__node3);
			Edge_Edge edge__edge7 = Edge_Edge.CreateEdge(graph, node_c3, node_c4);
			Edge_Edge edge__edge13 = Edge_Edge.CreateEdge(graph, node_c2, node_n2);
			Edge_Edge edge__edge6 = Edge_Edge.CreateEdge(graph, node_c1, node_c2);
			Edge_Edge edge__edge12 = Edge_Edge.CreateEdge(graph, node_c, node__node2);
			Edge_Edge edge__edge5 = Edge_Edge.CreateEdge(graph, node_c6, node_c1);
			Edge_Edge edge__edge11 = Edge_Edge.CreateEdge(graph, node_c, node__node1);
			Edge_Edge edge__edge4 = Edge_Edge.CreateEdge(graph, node_c5, node_c6);
			return EmptyReturnElements;
		}

		public override IGraphElement[] ModifyNoReuse(LGSPGraph graph, LGSPMatch match)
		{
			Node_C node_c = Node_C.CreateNode(graph);
			Node_H node__node9 = Node_H.CreateNode(graph);
			Node_C node_c1 = Node_C.CreateNode(graph);
			Node_O node__node7 = Node_O.CreateNode(graph);
			Node_H node__node8 = Node_H.CreateNode(graph);
			Node_H node__node5 = Node_H.CreateNode(graph);
			Node_O node__node6 = Node_O.CreateNode(graph);
			Node_O node__node3 = Node_O.CreateNode(graph);
			Node_C node_c6 = Node_C.CreateNode(graph);
			Node_O node__node4 = Node_O.CreateNode(graph);
			Node_H node__node1 = Node_H.CreateNode(graph);
			Node_H node__node2 = Node_H.CreateNode(graph);
			Node_N node_n4 = Node_N.CreateNode(graph);
			Node_C node_c2 = Node_C.CreateNode(graph);
			Node_H node__node0 = Node_H.CreateNode(graph);
			Node_C node_c3 = Node_C.CreateNode(graph);
			Node_N node_n2 = Node_N.CreateNode(graph);
			Node_C node_c4 = Node_C.CreateNode(graph);
			Node_C node_c5 = Node_C.CreateNode(graph);
			Edge_Edge edge__edge8 = Edge_Edge.CreateEdge(graph, node_c5, node_c6);
			Edge_Edge edge__edge9 = Edge_Edge.CreateEdge(graph, node_c1, node_c);
			Edge_Edge edge__edge19 = Edge_Edge.CreateEdge(graph, node_n4, node__node7);
			Edge_Edge edge__edge10 = Edge_Edge.CreateEdge(graph, node_c, node__node0);
			Edge_Edge edge__edge21 = Edge_Edge.CreateEdge(graph, node_c6, node__node9);
			Edge_Edge edge__edge20 = Edge_Edge.CreateEdge(graph, node_c5, node__node8);
			Edge_Edge edge__edge18 = Edge_Edge.CreateEdge(graph, node_n4, node__node6);
			Edge_Edge edge__edge3 = Edge_Edge.CreateEdge(graph, node_c4, node_c5);
			Edge_Edge edge__edge17 = Edge_Edge.CreateEdge(graph, node_c4, node_n4);
			Edge_Edge edge__edge2 = Edge_Edge.CreateEdge(graph, node_c3, node_c4);
			Edge_Edge edge__edge16 = Edge_Edge.CreateEdge(graph, node_c3, node__node5);
			Edge_Edge edge__edge1 = Edge_Edge.CreateEdge(graph, node_c2, node_c3);
			Edge_Edge edge__edge15 = Edge_Edge.CreateEdge(graph, node_n2, node__node4);
			Edge_Edge edge__edge0 = Edge_Edge.CreateEdge(graph, node_c1, node_c2);
			Edge_Edge edge__edge14 = Edge_Edge.CreateEdge(graph, node_n2, node__node3);
			Edge_Edge edge__edge7 = Edge_Edge.CreateEdge(graph, node_c3, node_c4);
			Edge_Edge edge__edge13 = Edge_Edge.CreateEdge(graph, node_c2, node_n2);
			Edge_Edge edge__edge6 = Edge_Edge.CreateEdge(graph, node_c1, node_c2);
			Edge_Edge edge__edge12 = Edge_Edge.CreateEdge(graph, node_c, node__node2);
			Edge_Edge edge__edge5 = Edge_Edge.CreateEdge(graph, node_c6, node_c1);
			Edge_Edge edge__edge11 = Edge_Edge.CreateEdge(graph, node_c, node__node1);
			Edge_Edge edge__edge4 = Edge_Edge.CreateEdge(graph, node_c5, node_c6);
			return EmptyReturnElements;
		}
		private static String[] addedNodeNames = new String[] { "c", "_node9", "c1", "_node7", "_node8", "_node5", "_node6", "_node3", "c6", "_node4", "_node1", "_node2", "n4", "c2", "_node0", "c3", "n2", "c4", "c5" };
		public override String[] AddedNodeNames { get { return addedNodeNames; } }
		private static String[] addedEdgeNames = new String[] { "_edge8", "_edge9", "_edge19", "_edge10", "_edge21", "_edge20", "_edge18", "_edge3", "_edge17", "_edge2", "_edge16", "_edge1", "_edge15", "_edge0", "_edge14", "_edge7", "_edge13", "_edge6", "_edge12", "_edge5", "_edge11", "_edge4" };
		public override String[] AddedEdgeNames { get { return addedEdgeNames; } }
	}

#if INITIAL_WARMUP
	public class Schedule_createDNT : LGSPStaticScheduleInfo
	{
		public Schedule_createDNT()
		{
			ActionName = "createDNT";
			this.RulePattern = Rule_createDNT.Instance;
			NodeCost = new float[] {  };
			EdgeCost = new float[] {  };
			NegNodeCost = new float[][] { };
			NegEdgeCost = new float[][] { };
		}
	}
#endif

	public class Rule_createTNB : LGSPRulePattern
	{
		private static Rule_createTNB instance = null;
		public static Rule_createTNB Instance { get { if (instance==null) instance = new Rule_createTNB(); return instance; } }


		public enum NodeNums { };
		public enum EdgeNums { };
		public enum PatternNums { };

		private Rule_createTNB()
		{
			name = "createTNB";
			isSubpattern = false;
			patternGraph = new PatternGraph(
				"rule createTNB.pattern",
				new PatternNode[] {  }, 
				new PatternEdge[] {  }, 
				new PatternGraphEmbedding[] {  }, 
				new Condition[] { },
				new bool[0, 0] ,
				new bool[0, 0] ,
				new bool[] {},
				new bool[] {},
				new bool[] {},
				new bool[] {}
			);

			negativePatternGraphs = new PatternGraph[] {};
			inputs = new GrGenType[] { };
			inputNames = new string[] { };
			outputs = new GrGenType[] { };
			outputNames = new string[] { };
		}


		public override IGraphElement[] Modify(LGSPGraph graph, LGSPMatch match)
		{
			Node_N node_n6 = Node_N.CreateNode(graph);
			Node_C node_c1 = Node_C.CreateNode(graph);
			Node_O node__node7 = Node_O.CreateNode(graph);
			Node_O node__node8 = Node_O.CreateNode(graph);
			Node_O node__node5 = Node_O.CreateNode(graph);
			Node_H node__node6 = Node_H.CreateNode(graph);
			Node_H node__node3 = Node_H.CreateNode(graph);
			Node_C node_c6 = Node_C.CreateNode(graph);
			Node_O node__node4 = Node_O.CreateNode(graph);
			Node_O node__node1 = Node_O.CreateNode(graph);
			Node_O node__node2 = Node_O.CreateNode(graph);
			Node_N node_n4 = Node_N.CreateNode(graph);
			Node_C node_c2 = Node_C.CreateNode(graph);
			Node_H node__node0 = Node_H.CreateNode(graph);
			Node_C node_c3 = Node_C.CreateNode(graph);
			Node_N node_n2 = Node_N.CreateNode(graph);
			Node_C node_c4 = Node_C.CreateNode(graph);
			Node_C node_c5 = Node_C.CreateNode(graph);
			Edge_Edge edge__edge8 = Edge_Edge.CreateEdge(graph, node_c5, node_c6);
			Edge_Edge edge__edge9 = Edge_Edge.CreateEdge(graph, node_c1, node__node0);
			Edge_Edge edge__edge19 = Edge_Edge.CreateEdge(graph, node_n6, node__node7);
			Edge_Edge edge__edge10 = Edge_Edge.CreateEdge(graph, node_c2, node_n2);
			Edge_Edge edge__edge20 = Edge_Edge.CreateEdge(graph, node_n6, node__node8);
			Edge_Edge edge__edge18 = Edge_Edge.CreateEdge(graph, node_c6, node_n6);
			Edge_Edge edge__edge3 = Edge_Edge.CreateEdge(graph, node_c4, node_c5);
			Edge_Edge edge__edge17 = Edge_Edge.CreateEdge(graph, node_c5, node__node6);
			Edge_Edge edge__edge2 = Edge_Edge.CreateEdge(graph, node_c3, node_c4);
			Edge_Edge edge__edge16 = Edge_Edge.CreateEdge(graph, node_n4, node__node5);
			Edge_Edge edge__edge1 = Edge_Edge.CreateEdge(graph, node_c2, node_c3);
			Edge_Edge edge__edge15 = Edge_Edge.CreateEdge(graph, node_n4, node__node4);
			Edge_Edge edge__edge0 = Edge_Edge.CreateEdge(graph, node_c1, node_c2);
			Edge_Edge edge__edge14 = Edge_Edge.CreateEdge(graph, node_c4, node_n4);
			Edge_Edge edge__edge7 = Edge_Edge.CreateEdge(graph, node_c3, node_c4);
			Edge_Edge edge__edge13 = Edge_Edge.CreateEdge(graph, node_c3, node__node3);
			Edge_Edge edge__edge6 = Edge_Edge.CreateEdge(graph, node_c1, node_c2);
			Edge_Edge edge__edge12 = Edge_Edge.CreateEdge(graph, node_n2, node__node2);
			Edge_Edge edge__edge5 = Edge_Edge.CreateEdge(graph, node_c6, node_c1);
			Edge_Edge edge__edge11 = Edge_Edge.CreateEdge(graph, node_n2, node__node1);
			Edge_Edge edge__edge4 = Edge_Edge.CreateEdge(graph, node_c5, node_c6);
			return EmptyReturnElements;
		}

		public override IGraphElement[] ModifyNoReuse(LGSPGraph graph, LGSPMatch match)
		{
			Node_N node_n6 = Node_N.CreateNode(graph);
			Node_C node_c1 = Node_C.CreateNode(graph);
			Node_O node__node7 = Node_O.CreateNode(graph);
			Node_O node__node8 = Node_O.CreateNode(graph);
			Node_O node__node5 = Node_O.CreateNode(graph);
			Node_H node__node6 = Node_H.CreateNode(graph);
			Node_H node__node3 = Node_H.CreateNode(graph);
			Node_C node_c6 = Node_C.CreateNode(graph);
			Node_O node__node4 = Node_O.CreateNode(graph);
			Node_O node__node1 = Node_O.CreateNode(graph);
			Node_O node__node2 = Node_O.CreateNode(graph);
			Node_N node_n4 = Node_N.CreateNode(graph);
			Node_C node_c2 = Node_C.CreateNode(graph);
			Node_H node__node0 = Node_H.CreateNode(graph);
			Node_C node_c3 = Node_C.CreateNode(graph);
			Node_N node_n2 = Node_N.CreateNode(graph);
			Node_C node_c4 = Node_C.CreateNode(graph);
			Node_C node_c5 = Node_C.CreateNode(graph);
			Edge_Edge edge__edge8 = Edge_Edge.CreateEdge(graph, node_c5, node_c6);
			Edge_Edge edge__edge9 = Edge_Edge.CreateEdge(graph, node_c1, node__node0);
			Edge_Edge edge__edge19 = Edge_Edge.CreateEdge(graph, node_n6, node__node7);
			Edge_Edge edge__edge10 = Edge_Edge.CreateEdge(graph, node_c2, node_n2);
			Edge_Edge edge__edge20 = Edge_Edge.CreateEdge(graph, node_n6, node__node8);
			Edge_Edge edge__edge18 = Edge_Edge.CreateEdge(graph, node_c6, node_n6);
			Edge_Edge edge__edge3 = Edge_Edge.CreateEdge(graph, node_c4, node_c5);
			Edge_Edge edge__edge17 = Edge_Edge.CreateEdge(graph, node_c5, node__node6);
			Edge_Edge edge__edge2 = Edge_Edge.CreateEdge(graph, node_c3, node_c4);
			Edge_Edge edge__edge16 = Edge_Edge.CreateEdge(graph, node_n4, node__node5);
			Edge_Edge edge__edge1 = Edge_Edge.CreateEdge(graph, node_c2, node_c3);
			Edge_Edge edge__edge15 = Edge_Edge.CreateEdge(graph, node_n4, node__node4);
			Edge_Edge edge__edge0 = Edge_Edge.CreateEdge(graph, node_c1, node_c2);
			Edge_Edge edge__edge14 = Edge_Edge.CreateEdge(graph, node_c4, node_n4);
			Edge_Edge edge__edge7 = Edge_Edge.CreateEdge(graph, node_c3, node_c4);
			Edge_Edge edge__edge13 = Edge_Edge.CreateEdge(graph, node_c3, node__node3);
			Edge_Edge edge__edge6 = Edge_Edge.CreateEdge(graph, node_c1, node_c2);
			Edge_Edge edge__edge12 = Edge_Edge.CreateEdge(graph, node_n2, node__node2);
			Edge_Edge edge__edge5 = Edge_Edge.CreateEdge(graph, node_c6, node_c1);
			Edge_Edge edge__edge11 = Edge_Edge.CreateEdge(graph, node_n2, node__node1);
			Edge_Edge edge__edge4 = Edge_Edge.CreateEdge(graph, node_c5, node_c6);
			return EmptyReturnElements;
		}
		private static String[] addedNodeNames = new String[] { "n6", "c1", "_node7", "_node8", "_node5", "_node6", "_node3", "c6", "_node4", "_node1", "_node2", "n4", "c2", "_node0", "c3", "n2", "c4", "c5" };
		public override String[] AddedNodeNames { get { return addedNodeNames; } }
		private static String[] addedEdgeNames = new String[] { "_edge8", "_edge9", "_edge19", "_edge10", "_edge20", "_edge18", "_edge3", "_edge17", "_edge2", "_edge16", "_edge1", "_edge15", "_edge0", "_edge14", "_edge7", "_edge13", "_edge6", "_edge12", "_edge5", "_edge11", "_edge4" };
		public override String[] AddedEdgeNames { get { return addedEdgeNames; } }
	}

#if INITIAL_WARMUP
	public class Schedule_createTNB : LGSPStaticScheduleInfo
	{
		public Schedule_createTNB()
		{
			ActionName = "createTNB";
			this.RulePattern = Rule_createTNB.Instance;
			NodeCost = new float[] {  };
			EdgeCost = new float[] {  };
			NegNodeCost = new float[][] { };
			NegEdgeCost = new float[][] { };
		}
	}
#endif

	public class Rule_createTNT : LGSPRulePattern
	{
		private static Rule_createTNT instance = null;
		public static Rule_createTNT Instance { get { if (instance==null) instance = new Rule_createTNT(); return instance; } }


		public enum NodeNums { };
		public enum EdgeNums { };
		public enum PatternNums { };

		private Rule_createTNT()
		{
			name = "createTNT";
			isSubpattern = false;
			patternGraph = new PatternGraph(
				"rule createTNT.pattern",
				new PatternNode[] {  }, 
				new PatternEdge[] {  }, 
				new PatternGraphEmbedding[] {  }, 
				new Condition[] { },
				new bool[0, 0] ,
				new bool[0, 0] ,
				new bool[] {},
				new bool[] {},
				new bool[] {},
				new bool[] {}
			);

			negativePatternGraphs = new PatternGraph[] {};
			inputs = new GrGenType[] { };
			inputNames = new string[] { };
			outputs = new GrGenType[] { };
			outputNames = new string[] { };
		}


		public override IGraphElement[] Modify(LGSPGraph graph, LGSPMatch match)
		{
			Node_N node_n6 = Node_N.CreateNode(graph);
			Node_O node__node10 = Node_O.CreateNode(graph);
			Node_C node_c = Node_C.CreateNode(graph);
			Node_O node__node9 = Node_O.CreateNode(graph);
			Node_C node_c1 = Node_C.CreateNode(graph);
			Node_O node__node7 = Node_O.CreateNode(graph);
			Node_H node__node8 = Node_H.CreateNode(graph);
			Node_H node__node5 = Node_H.CreateNode(graph);
			Node_O node__node6 = Node_O.CreateNode(graph);
			Node_O node__node3 = Node_O.CreateNode(graph);
			Node_C node_c6 = Node_C.CreateNode(graph);
			Node_O node__node4 = Node_O.CreateNode(graph);
			Node_H node__node1 = Node_H.CreateNode(graph);
			Node_H node__node2 = Node_H.CreateNode(graph);
			Node_N node_n4 = Node_N.CreateNode(graph);
			Node_C node_c2 = Node_C.CreateNode(graph);
			Node_H node__node0 = Node_H.CreateNode(graph);
			Node_C node_c3 = Node_C.CreateNode(graph);
			Node_N node_n2 = Node_N.CreateNode(graph);
			Node_C node_c4 = Node_C.CreateNode(graph);
			Node_C node_c5 = Node_C.CreateNode(graph);
			Edge_Edge edge__edge8 = Edge_Edge.CreateEdge(graph, node_c5, node_c6);
			Edge_Edge edge__edge9 = Edge_Edge.CreateEdge(graph, node_c1, node_c);
			Edge_Edge edge__edge19 = Edge_Edge.CreateEdge(graph, node_n4, node__node7);
			Edge_Edge edge__edge10 = Edge_Edge.CreateEdge(graph, node_c, node__node0);
			Edge_Edge edge__edge18 = Edge_Edge.CreateEdge(graph, node_n4, node__node6);
			Edge_Edge edge__edge3 = Edge_Edge.CreateEdge(graph, node_c4, node_c5);
			Edge_Edge edge__edge17 = Edge_Edge.CreateEdge(graph, node_c4, node_n4);
			Edge_Edge edge__edge2 = Edge_Edge.CreateEdge(graph, node_c3, node_c4);
			Edge_Edge edge__edge16 = Edge_Edge.CreateEdge(graph, node_c3, node__node5);
			Edge_Edge edge__edge1 = Edge_Edge.CreateEdge(graph, node_c2, node_c3);
			Edge_Edge edge__edge15 = Edge_Edge.CreateEdge(graph, node_n2, node__node4);
			Edge_Edge edge__edge0 = Edge_Edge.CreateEdge(graph, node_c1, node_c2);
			Edge_Edge edge__edge14 = Edge_Edge.CreateEdge(graph, node_n2, node__node3);
			Edge_Edge edge__edge7 = Edge_Edge.CreateEdge(graph, node_c3, node_c4);
			Edge_Edge edge__edge13 = Edge_Edge.CreateEdge(graph, node_c2, node_n2);
			Edge_Edge edge__edge6 = Edge_Edge.CreateEdge(graph, node_c1, node_c2);
			Edge_Edge edge__edge12 = Edge_Edge.CreateEdge(graph, node_c, node__node2);
			Edge_Edge edge__edge5 = Edge_Edge.CreateEdge(graph, node_c6, node_c1);
			Edge_Edge edge__edge11 = Edge_Edge.CreateEdge(graph, node_c, node__node1);
			Edge_Edge edge__edge4 = Edge_Edge.CreateEdge(graph, node_c5, node_c6);
			Edge_Edge edge__edge21 = Edge_Edge.CreateEdge(graph, node_c6, node_n6);
			Edge_Edge edge__edge20 = Edge_Edge.CreateEdge(graph, node_c5, node__node8);
			Edge_Edge edge__edge23 = Edge_Edge.CreateEdge(graph, node_n6, node__node10);
			Edge_Edge edge__edge22 = Edge_Edge.CreateEdge(graph, node_n6, node__node9);
			return EmptyReturnElements;
		}

		public override IGraphElement[] ModifyNoReuse(LGSPGraph graph, LGSPMatch match)
		{
			Node_N node_n6 = Node_N.CreateNode(graph);
			Node_O node__node10 = Node_O.CreateNode(graph);
			Node_C node_c = Node_C.CreateNode(graph);
			Node_O node__node9 = Node_O.CreateNode(graph);
			Node_C node_c1 = Node_C.CreateNode(graph);
			Node_O node__node7 = Node_O.CreateNode(graph);
			Node_H node__node8 = Node_H.CreateNode(graph);
			Node_H node__node5 = Node_H.CreateNode(graph);
			Node_O node__node6 = Node_O.CreateNode(graph);
			Node_O node__node3 = Node_O.CreateNode(graph);
			Node_C node_c6 = Node_C.CreateNode(graph);
			Node_O node__node4 = Node_O.CreateNode(graph);
			Node_H node__node1 = Node_H.CreateNode(graph);
			Node_H node__node2 = Node_H.CreateNode(graph);
			Node_N node_n4 = Node_N.CreateNode(graph);
			Node_C node_c2 = Node_C.CreateNode(graph);
			Node_H node__node0 = Node_H.CreateNode(graph);
			Node_C node_c3 = Node_C.CreateNode(graph);
			Node_N node_n2 = Node_N.CreateNode(graph);
			Node_C node_c4 = Node_C.CreateNode(graph);
			Node_C node_c5 = Node_C.CreateNode(graph);
			Edge_Edge edge__edge8 = Edge_Edge.CreateEdge(graph, node_c5, node_c6);
			Edge_Edge edge__edge9 = Edge_Edge.CreateEdge(graph, node_c1, node_c);
			Edge_Edge edge__edge19 = Edge_Edge.CreateEdge(graph, node_n4, node__node7);
			Edge_Edge edge__edge10 = Edge_Edge.CreateEdge(graph, node_c, node__node0);
			Edge_Edge edge__edge18 = Edge_Edge.CreateEdge(graph, node_n4, node__node6);
			Edge_Edge edge__edge3 = Edge_Edge.CreateEdge(graph, node_c4, node_c5);
			Edge_Edge edge__edge17 = Edge_Edge.CreateEdge(graph, node_c4, node_n4);
			Edge_Edge edge__edge2 = Edge_Edge.CreateEdge(graph, node_c3, node_c4);
			Edge_Edge edge__edge16 = Edge_Edge.CreateEdge(graph, node_c3, node__node5);
			Edge_Edge edge__edge1 = Edge_Edge.CreateEdge(graph, node_c2, node_c3);
			Edge_Edge edge__edge15 = Edge_Edge.CreateEdge(graph, node_n2, node__node4);
			Edge_Edge edge__edge0 = Edge_Edge.CreateEdge(graph, node_c1, node_c2);
			Edge_Edge edge__edge14 = Edge_Edge.CreateEdge(graph, node_n2, node__node3);
			Edge_Edge edge__edge7 = Edge_Edge.CreateEdge(graph, node_c3, node_c4);
			Edge_Edge edge__edge13 = Edge_Edge.CreateEdge(graph, node_c2, node_n2);
			Edge_Edge edge__edge6 = Edge_Edge.CreateEdge(graph, node_c1, node_c2);
			Edge_Edge edge__edge12 = Edge_Edge.CreateEdge(graph, node_c, node__node2);
			Edge_Edge edge__edge5 = Edge_Edge.CreateEdge(graph, node_c6, node_c1);
			Edge_Edge edge__edge11 = Edge_Edge.CreateEdge(graph, node_c, node__node1);
			Edge_Edge edge__edge4 = Edge_Edge.CreateEdge(graph, node_c5, node_c6);
			Edge_Edge edge__edge21 = Edge_Edge.CreateEdge(graph, node_c6, node_n6);
			Edge_Edge edge__edge20 = Edge_Edge.CreateEdge(graph, node_c5, node__node8);
			Edge_Edge edge__edge23 = Edge_Edge.CreateEdge(graph, node_n6, node__node10);
			Edge_Edge edge__edge22 = Edge_Edge.CreateEdge(graph, node_n6, node__node9);
			return EmptyReturnElements;
		}
		private static String[] addedNodeNames = new String[] { "n6", "_node10", "c", "_node9", "c1", "_node7", "_node8", "_node5", "_node6", "_node3", "c6", "_node4", "_node1", "_node2", "n4", "c2", "_node0", "c3", "n2", "c4", "c5" };
		public override String[] AddedNodeNames { get { return addedNodeNames; } }
		private static String[] addedEdgeNames = new String[] { "_edge8", "_edge9", "_edge19", "_edge10", "_edge18", "_edge3", "_edge17", "_edge2", "_edge16", "_edge1", "_edge15", "_edge0", "_edge14", "_edge7", "_edge13", "_edge6", "_edge12", "_edge5", "_edge11", "_edge4", "_edge21", "_edge20", "_edge23", "_edge22" };
		public override String[] AddedEdgeNames { get { return addedEdgeNames; } }
	}

#if INITIAL_WARMUP
	public class Schedule_createTNT : LGSPStaticScheduleInfo
	{
		public Schedule_createTNT()
		{
			ActionName = "createTNT";
			this.RulePattern = Rule_createTNT.Instance;
			NodeCost = new float[] {  };
			EdgeCost = new float[] {  };
			NegNodeCost = new float[][] { };
			NegEdgeCost = new float[][] { };
		}
	}
#endif


	public class PatternAction_Hydrogen : LGSPSubpatternAction
	{
		public PatternAction_Hydrogen(LGSPGraph graph_, Stack<LGSPSubpatternAction> openTasks_) {
			graph = graph_; openTasks = openTasks_;
			rulePattern = Pattern_Hydrogen.Instance;
		}

		public LGSPNode node_anchor;

        public override void myMatch(List<Stack<LGSPMatch>> foundPartialMatches, int maxMatches)
        {
            openTasks.Pop();
            List<Stack<LGSPMatch>> matchesList = foundPartialMatches;
            if(matchesList.Count!=0) throw new ApplicationException(); //debug assert
            // SubPreset node_anchor 
            LGSPNode node_cur_node_anchor = node_anchor;
            // Extend outgoing edge__edge0 from node_anchor 
            LGSPEdge edge_head_edge__edge0 = node_cur_node_anchor.outhead;
            if(edge_head_edge__edge0 != null)
            {
                LGSPEdge edge_cur_edge__edge0 = edge_head_edge__edge0;
                do
                {
                    if(!EdgeType_Edge.isMyType[edge_cur_edge__edge0.type.TypeID]) {
                        continue;
                    }
                    if(edge_cur_edge__edge0.isMatchedByEnclosingPattern)
                    {
                        continue;
                    }
                    // Implicit target node__node0 from edge__edge0 
                    LGSPNode node_cur_node__node0 = edge_cur_edge__edge0.target;
                    if(!NodeType_H.isMyType[node_cur_node__node0.type.TypeID]) {
                        continue;
                    }
                    if(node_cur_node__node0.isMatchedByEnclosingPattern)
                    {
                        continue;
                    }
                    // Check whether there are subpattern matching tasks left to execute
                    if(openTasks.Count==0)
                    {
                        Stack<LGSPMatch> currentFoundPartialMatch = new Stack<LGSPMatch>();
                        foundPartialMatches.Add(currentFoundPartialMatch);
                        LGSPMatch match = new LGSPMatch(new LGSPNode[2], new LGSPEdge[1], new LGSPMatch[0]);
                        match.patternGraph = rulePattern.patternGraph;
                        match.Nodes[(int)Pattern_Hydrogen.NodeNums.@anchor] = node_cur_node_anchor;
                        match.Nodes[(int)Pattern_Hydrogen.NodeNums.@_node0] = node_cur_node__node0;
                        match.Edges[(int)Pattern_Hydrogen.EdgeNums.@_edge0] = edge_cur_edge__edge0;
                        currentFoundPartialMatch.Push(match);
                        // if enough matches were found, we leave
                        if(maxMatches > 0 && foundPartialMatches.Count >= maxMatches)
                        {
                            openTasks.Push(this);
                            return;
                        }
                        continue;
                    }
                    node_cur_node__node0.isMatchedByEnclosingPattern = true;
                    edge_cur_edge__edge0.isMatchedByEnclosingPattern = true;
                    // Match subpatterns
                    openTasks.Peek().myMatch(matchesList, maxMatches - foundPartialMatches.Count);
                    // Check whether subpatterns were found 
                    if(matchesList.Count>0) {
                        // subpatterns were found, extend the partial matches by our local match object
                        foreach(Stack<LGSPMatch> currentFoundPartialMatch in matchesList)
                        {
                            LGSPMatch match = new LGSPMatch(new LGSPNode[2], new LGSPEdge[1], new LGSPMatch[0]);
                            match.patternGraph = rulePattern.patternGraph;
                            match.Nodes[(int)Pattern_Hydrogen.NodeNums.@anchor] = node_cur_node_anchor;
                            match.Nodes[(int)Pattern_Hydrogen.NodeNums.@_node0] = node_cur_node__node0;
                            match.Edges[(int)Pattern_Hydrogen.EdgeNums.@_edge0] = edge_cur_edge__edge0;
                            currentFoundPartialMatch.Push(match);
                        }
                        if(matchesList==foundPartialMatches) {
                            matchesList = new List<Stack<LGSPMatch>>();
                        } else {
                            foreach(Stack<LGSPMatch> match in matchesList)
                            {
                                foundPartialMatches.Add(match);
                            }
                            matchesList.Clear();
                        }
                        // if enough matches were found, we leave
                        if(maxMatches > 0 && foundPartialMatches.Count >= maxMatches)
                        {
                            edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                            node_cur_node__node0.isMatchedByEnclosingPattern = false;
                            openTasks.Push(this);
                            return;
                        }
                        edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                        node_cur_node__node0.isMatchedByEnclosingPattern = false;
                        continue;
                    }
                    node_cur_node__node0.isMatchedByEnclosingPattern = false;
                    edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                }
                while( (edge_cur_edge__edge0 = edge_cur_edge__edge0.outNext) != edge_head_edge__edge0 );
            }
            openTasks.Push(this);
            return;
        }
	}
	public class PatternAction_Hydroxyl : LGSPSubpatternAction
	{
		public PatternAction_Hydroxyl(LGSPGraph graph_, Stack<LGSPSubpatternAction> openTasks_) {
			graph = graph_; openTasks = openTasks_;
			rulePattern = Pattern_Hydroxyl.Instance;
		}

		public LGSPNode node_anchor;

        public override void myMatch(List<Stack<LGSPMatch>> foundPartialMatches, int maxMatches)
        {
            openTasks.Pop();
            List<Stack<LGSPMatch>> matchesList = foundPartialMatches;
            if(matchesList.Count!=0) throw new ApplicationException(); //debug assert
            // SubPreset node_anchor 
            LGSPNode node_cur_node_anchor = node_anchor;
            // Extend outgoing edge__edge0 from node_anchor 
            LGSPEdge edge_head_edge__edge0 = node_cur_node_anchor.outhead;
            if(edge_head_edge__edge0 != null)
            {
                LGSPEdge edge_cur_edge__edge0 = edge_head_edge__edge0;
                do
                {
                    if(!EdgeType_Edge.isMyType[edge_cur_edge__edge0.type.TypeID]) {
                        continue;
                    }
                    if(edge_cur_edge__edge0.isMatchedByEnclosingPattern)
                    {
                        continue;
                    }
                    bool edge_cur_edge__edge0_prevIsMatched = edge_cur_edge__edge0.isMatched;
                    edge_cur_edge__edge0.isMatched = true;
                    // Implicit target node__node0 from edge__edge0 
                    LGSPNode node_cur_node__node0 = edge_cur_edge__edge0.target;
                    if(!NodeType_O.isMyType[node_cur_node__node0.type.TypeID]) {
                        edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                        continue;
                    }
                    if(node_cur_node__node0.isMatchedByEnclosingPattern)
                    {
                        edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                        continue;
                    }
                    // Extend outgoing edge__edge1 from node__node0 
                    LGSPEdge edge_head_edge__edge1 = node_cur_node__node0.outhead;
                    if(edge_head_edge__edge1 != null)
                    {
                        LGSPEdge edge_cur_edge__edge1 = edge_head_edge__edge1;
                        do
                        {
                            if(!EdgeType_Edge.isMyType[edge_cur_edge__edge1.type.TypeID]) {
                                continue;
                            }
                            if(edge_cur_edge__edge1.isMatched
                                && edge_cur_edge__edge1==edge_cur_edge__edge0
                                )
                            {
                                continue;
                            }
                            if(edge_cur_edge__edge1.isMatchedByEnclosingPattern)
                            {
                                continue;
                            }
                            // Implicit target node__node1 from edge__edge1 
                            LGSPNode node_cur_node__node1 = edge_cur_edge__edge1.target;
                            if(!NodeType_H.isMyType[node_cur_node__node1.type.TypeID]) {
                                continue;
                            }
                            if(node_cur_node__node1.isMatchedByEnclosingPattern)
                            {
                                continue;
                            }
                            // Check whether there are subpattern matching tasks left to execute
                            if(openTasks.Count==0)
                            {
                                Stack<LGSPMatch> currentFoundPartialMatch = new Stack<LGSPMatch>();
                                foundPartialMatches.Add(currentFoundPartialMatch);
                                LGSPMatch match = new LGSPMatch(new LGSPNode[3], new LGSPEdge[2], new LGSPMatch[0]);
                                match.patternGraph = rulePattern.patternGraph;
                                match.Nodes[(int)Pattern_Hydroxyl.NodeNums.@anchor] = node_cur_node_anchor;
                                match.Nodes[(int)Pattern_Hydroxyl.NodeNums.@_node0] = node_cur_node__node0;
                                match.Nodes[(int)Pattern_Hydroxyl.NodeNums.@_node1] = node_cur_node__node1;
                                match.Edges[(int)Pattern_Hydroxyl.EdgeNums.@_edge0] = edge_cur_edge__edge0;
                                match.Edges[(int)Pattern_Hydroxyl.EdgeNums.@_edge1] = edge_cur_edge__edge1;
                                currentFoundPartialMatch.Push(match);
                                // if enough matches were found, we leave
                                if(maxMatches > 0 && foundPartialMatches.Count >= maxMatches)
                                {
                                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                                    openTasks.Push(this);
                                    return;
                                }
                                continue;
                            }
                            node_cur_node__node0.isMatchedByEnclosingPattern = true;
                            node_cur_node__node1.isMatchedByEnclosingPattern = true;
                            edge_cur_edge__edge0.isMatchedByEnclosingPattern = true;
                            edge_cur_edge__edge1.isMatchedByEnclosingPattern = true;
                            // Match subpatterns
                            openTasks.Peek().myMatch(matchesList, maxMatches - foundPartialMatches.Count);
                            // Check whether subpatterns were found 
                            if(matchesList.Count>0) {
                                // subpatterns were found, extend the partial matches by our local match object
                                foreach(Stack<LGSPMatch> currentFoundPartialMatch in matchesList)
                                {
                                    LGSPMatch match = new LGSPMatch(new LGSPNode[3], new LGSPEdge[2], new LGSPMatch[0]);
                                    match.patternGraph = rulePattern.patternGraph;
                                    match.Nodes[(int)Pattern_Hydroxyl.NodeNums.@anchor] = node_cur_node_anchor;
                                    match.Nodes[(int)Pattern_Hydroxyl.NodeNums.@_node0] = node_cur_node__node0;
                                    match.Nodes[(int)Pattern_Hydroxyl.NodeNums.@_node1] = node_cur_node__node1;
                                    match.Edges[(int)Pattern_Hydroxyl.EdgeNums.@_edge0] = edge_cur_edge__edge0;
                                    match.Edges[(int)Pattern_Hydroxyl.EdgeNums.@_edge1] = edge_cur_edge__edge1;
                                    currentFoundPartialMatch.Push(match);
                                }
                                if(matchesList==foundPartialMatches) {
                                    matchesList = new List<Stack<LGSPMatch>>();
                                } else {
                                    foreach(Stack<LGSPMatch> match in matchesList)
                                    {
                                        foundPartialMatches.Add(match);
                                    }
                                    matchesList.Clear();
                                }
                                // if enough matches were found, we leave
                                if(maxMatches > 0 && foundPartialMatches.Count >= maxMatches)
                                {
                                    edge_cur_edge__edge1.isMatchedByEnclosingPattern = false;
                                    edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                                    node_cur_node__node1.isMatchedByEnclosingPattern = false;
                                    node_cur_node__node0.isMatchedByEnclosingPattern = false;
                                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                                    openTasks.Push(this);
                                    return;
                                }
                                edge_cur_edge__edge1.isMatchedByEnclosingPattern = false;
                                edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                                node_cur_node__node1.isMatchedByEnclosingPattern = false;
                                node_cur_node__node0.isMatchedByEnclosingPattern = false;
                                continue;
                            }
                            node_cur_node__node0.isMatchedByEnclosingPattern = false;
                            node_cur_node__node1.isMatchedByEnclosingPattern = false;
                            edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                            edge_cur_edge__edge1.isMatchedByEnclosingPattern = false;
                        }
                        while( (edge_cur_edge__edge1 = edge_cur_edge__edge1.outNext) != edge_head_edge__edge1 );
                    }
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                }
                while( (edge_cur_edge__edge0 = edge_cur_edge__edge0.outNext) != edge_head_edge__edge0 );
            }
            openTasks.Push(this);
            return;
        }
	}
	public class PatternAction_Methyl : LGSPSubpatternAction
	{
		public PatternAction_Methyl(LGSPGraph graph_, Stack<LGSPSubpatternAction> openTasks_) {
			graph = graph_; openTasks = openTasks_;
			rulePattern = Pattern_Methyl.Instance;
		}

		public LGSPNode node_anchor;

        public override void myMatch(List<Stack<LGSPMatch>> foundPartialMatches, int maxMatches)
        {
            openTasks.Pop();
            List<Stack<LGSPMatch>> matchesList = foundPartialMatches;
            if(matchesList.Count!=0) throw new ApplicationException(); //debug assert
            // SubPreset node_anchor 
            LGSPNode node_cur_node_anchor = node_anchor;
            // Extend outgoing edge__edge0 from node_anchor 
            LGSPEdge edge_head_edge__edge0 = node_cur_node_anchor.outhead;
            if(edge_head_edge__edge0 != null)
            {
                LGSPEdge edge_cur_edge__edge0 = edge_head_edge__edge0;
                do
                {
                    if(!EdgeType_Edge.isMyType[edge_cur_edge__edge0.type.TypeID]) {
                        continue;
                    }
                    if(edge_cur_edge__edge0.isMatchedByEnclosingPattern)
                    {
                        continue;
                    }
                    bool edge_cur_edge__edge0_prevIsMatched = edge_cur_edge__edge0.isMatched;
                    edge_cur_edge__edge0.isMatched = true;
                    // Implicit target node_c from edge__edge0 
                    LGSPNode node_cur_node_c = edge_cur_edge__edge0.target;
                    if(!NodeType_C.isMyType[node_cur_node_c.type.TypeID]) {
                        edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                        continue;
                    }
                    if(node_cur_node_c.isMatched
                        && node_cur_node_c==node_cur_node_anchor
                        )
                    {
                        edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                        continue;
                    }
                    if(node_cur_node_c.isMatchedByEnclosingPattern)
                    {
                        edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                        continue;
                    }
                    // Extend outgoing edge__edge1 from node_c 
                    LGSPEdge edge_head_edge__edge1 = node_cur_node_c.outhead;
                    if(edge_head_edge__edge1 != null)
                    {
                        LGSPEdge edge_cur_edge__edge1 = edge_head_edge__edge1;
                        do
                        {
                            if(!EdgeType_Edge.isMyType[edge_cur_edge__edge1.type.TypeID]) {
                                continue;
                            }
                            if(edge_cur_edge__edge1.isMatched
                                && edge_cur_edge__edge1==edge_cur_edge__edge0
                                )
                            {
                                continue;
                            }
                            if(edge_cur_edge__edge1.isMatchedByEnclosingPattern)
                            {
                                continue;
                            }
                            bool edge_cur_edge__edge1_prevIsMatched = edge_cur_edge__edge1.isMatched;
                            edge_cur_edge__edge1.isMatched = true;
                            // Implicit target node__node0 from edge__edge1 
                            LGSPNode node_cur_node__node0 = edge_cur_edge__edge1.target;
                            if(!NodeType_H.isMyType[node_cur_node__node0.type.TypeID]) {
                                edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                continue;
                            }
                            if(node_cur_node__node0.isMatchedByEnclosingPattern)
                            {
                                edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                continue;
                            }
                            bool node_cur_node__node0_prevIsMatched = node_cur_node__node0.isMatched;
                            node_cur_node__node0.isMatched = true;
                            // Extend outgoing edge__edge2 from node_c 
                            LGSPEdge edge_head_edge__edge2 = node_cur_node_c.outhead;
                            if(edge_head_edge__edge2 != null)
                            {
                                LGSPEdge edge_cur_edge__edge2 = edge_head_edge__edge2;
                                do
                                {
                                    if(!EdgeType_Edge.isMyType[edge_cur_edge__edge2.type.TypeID]) {
                                        continue;
                                    }
                                    if(edge_cur_edge__edge2.isMatched
                                        && (edge_cur_edge__edge2==edge_cur_edge__edge0
                                            || edge_cur_edge__edge2==edge_cur_edge__edge1
                                            )
                                        )
                                    {
                                        continue;
                                    }
                                    if(edge_cur_edge__edge2.isMatchedByEnclosingPattern)
                                    {
                                        continue;
                                    }
                                    bool edge_cur_edge__edge2_prevIsMatched = edge_cur_edge__edge2.isMatched;
                                    edge_cur_edge__edge2.isMatched = true;
                                    // Implicit target node__node1 from edge__edge2 
                                    LGSPNode node_cur_node__node1 = edge_cur_edge__edge2.target;
                                    if(!NodeType_H.isMyType[node_cur_node__node1.type.TypeID]) {
                                        edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                        continue;
                                    }
                                    if(node_cur_node__node1.isMatched
                                        && node_cur_node__node1==node_cur_node__node0
                                        )
                                    {
                                        edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                        continue;
                                    }
                                    if(node_cur_node__node1.isMatchedByEnclosingPattern)
                                    {
                                        edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                        continue;
                                    }
                                    bool node_cur_node__node1_prevIsMatched = node_cur_node__node1.isMatched;
                                    node_cur_node__node1.isMatched = true;
                                    // Extend outgoing edge__edge3 from node_c 
                                    LGSPEdge edge_head_edge__edge3 = node_cur_node_c.outhead;
                                    if(edge_head_edge__edge3 != null)
                                    {
                                        LGSPEdge edge_cur_edge__edge3 = edge_head_edge__edge3;
                                        do
                                        {
                                            if(!EdgeType_Edge.isMyType[edge_cur_edge__edge3.type.TypeID]) {
                                                continue;
                                            }
                                            if(edge_cur_edge__edge3.isMatched
                                                && (edge_cur_edge__edge3==edge_cur_edge__edge0
                                                    || edge_cur_edge__edge3==edge_cur_edge__edge1
                                                    || edge_cur_edge__edge3==edge_cur_edge__edge2
                                                    )
                                                )
                                            {
                                                continue;
                                            }
                                            if(edge_cur_edge__edge3.isMatchedByEnclosingPattern)
                                            {
                                                continue;
                                            }
                                            // Implicit target node__node2 from edge__edge3 
                                            LGSPNode node_cur_node__node2 = edge_cur_edge__edge3.target;
                                            if(!NodeType_H.isMyType[node_cur_node__node2.type.TypeID]) {
                                                continue;
                                            }
                                            if(node_cur_node__node2.isMatched
                                                && (node_cur_node__node2==node_cur_node__node0
                                                    || node_cur_node__node2==node_cur_node__node1
                                                    )
                                                )
                                            {
                                                continue;
                                            }
                                            if(node_cur_node__node2.isMatchedByEnclosingPattern)
                                            {
                                                continue;
                                            }
                                            // Check whether there are subpattern matching tasks left to execute
                                            if(openTasks.Count==0)
                                            {
                                                Stack<LGSPMatch> currentFoundPartialMatch = new Stack<LGSPMatch>();
                                                foundPartialMatches.Add(currentFoundPartialMatch);
                                                LGSPMatch match = new LGSPMatch(new LGSPNode[5], new LGSPEdge[4], new LGSPMatch[0]);
                                                match.patternGraph = rulePattern.patternGraph;
                                                match.Nodes[(int)Pattern_Methyl.NodeNums.@anchor] = node_cur_node_anchor;
                                                match.Nodes[(int)Pattern_Methyl.NodeNums.@c] = node_cur_node_c;
                                                match.Nodes[(int)Pattern_Methyl.NodeNums.@_node0] = node_cur_node__node0;
                                                match.Nodes[(int)Pattern_Methyl.NodeNums.@_node1] = node_cur_node__node1;
                                                match.Nodes[(int)Pattern_Methyl.NodeNums.@_node2] = node_cur_node__node2;
                                                match.Edges[(int)Pattern_Methyl.EdgeNums.@_edge0] = edge_cur_edge__edge0;
                                                match.Edges[(int)Pattern_Methyl.EdgeNums.@_edge1] = edge_cur_edge__edge1;
                                                match.Edges[(int)Pattern_Methyl.EdgeNums.@_edge2] = edge_cur_edge__edge2;
                                                match.Edges[(int)Pattern_Methyl.EdgeNums.@_edge3] = edge_cur_edge__edge3;
                                                currentFoundPartialMatch.Push(match);
                                                // if enough matches were found, we leave
                                                if(maxMatches > 0 && foundPartialMatches.Count >= maxMatches)
                                                {
                                                    node_cur_node__node1.isMatched = node_cur_node__node1_prevIsMatched;
                                                    edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                                    node_cur_node__node0.isMatched = node_cur_node__node0_prevIsMatched;
                                                    edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                                                    openTasks.Push(this);
                                                    return;
                                                }
                                                continue;
                                            }
                                            node_cur_node_c.isMatchedByEnclosingPattern = true;
                                            node_cur_node__node0.isMatchedByEnclosingPattern = true;
                                            node_cur_node__node1.isMatchedByEnclosingPattern = true;
                                            node_cur_node__node2.isMatchedByEnclosingPattern = true;
                                            edge_cur_edge__edge0.isMatchedByEnclosingPattern = true;
                                            edge_cur_edge__edge1.isMatchedByEnclosingPattern = true;
                                            edge_cur_edge__edge2.isMatchedByEnclosingPattern = true;
                                            edge_cur_edge__edge3.isMatchedByEnclosingPattern = true;
                                            // Match subpatterns
                                            openTasks.Peek().myMatch(matchesList, maxMatches - foundPartialMatches.Count);
                                            // Check whether subpatterns were found 
                                            if(matchesList.Count>0) {
                                                // subpatterns were found, extend the partial matches by our local match object
                                                foreach(Stack<LGSPMatch> currentFoundPartialMatch in matchesList)
                                                {
                                                    LGSPMatch match = new LGSPMatch(new LGSPNode[5], new LGSPEdge[4], new LGSPMatch[0]);
                                                    match.patternGraph = rulePattern.patternGraph;
                                                    match.Nodes[(int)Pattern_Methyl.NodeNums.@anchor] = node_cur_node_anchor;
                                                    match.Nodes[(int)Pattern_Methyl.NodeNums.@c] = node_cur_node_c;
                                                    match.Nodes[(int)Pattern_Methyl.NodeNums.@_node0] = node_cur_node__node0;
                                                    match.Nodes[(int)Pattern_Methyl.NodeNums.@_node1] = node_cur_node__node1;
                                                    match.Nodes[(int)Pattern_Methyl.NodeNums.@_node2] = node_cur_node__node2;
                                                    match.Edges[(int)Pattern_Methyl.EdgeNums.@_edge0] = edge_cur_edge__edge0;
                                                    match.Edges[(int)Pattern_Methyl.EdgeNums.@_edge1] = edge_cur_edge__edge1;
                                                    match.Edges[(int)Pattern_Methyl.EdgeNums.@_edge2] = edge_cur_edge__edge2;
                                                    match.Edges[(int)Pattern_Methyl.EdgeNums.@_edge3] = edge_cur_edge__edge3;
                                                    currentFoundPartialMatch.Push(match);
                                                }
                                                if(matchesList==foundPartialMatches) {
                                                    matchesList = new List<Stack<LGSPMatch>>();
                                                } else {
                                                    foreach(Stack<LGSPMatch> match in matchesList)
                                                    {
                                                        foundPartialMatches.Add(match);
                                                    }
                                                    matchesList.Clear();
                                                }
                                                // if enough matches were found, we leave
                                                if(maxMatches > 0 && foundPartialMatches.Count >= maxMatches)
                                                {
                                                    edge_cur_edge__edge3.isMatchedByEnclosingPattern = false;
                                                    edge_cur_edge__edge2.isMatchedByEnclosingPattern = false;
                                                    edge_cur_edge__edge1.isMatchedByEnclosingPattern = false;
                                                    edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                                                    node_cur_node__node2.isMatchedByEnclosingPattern = false;
                                                    node_cur_node__node1.isMatchedByEnclosingPattern = false;
                                                    node_cur_node__node0.isMatchedByEnclosingPattern = false;
                                                    node_cur_node_c.isMatchedByEnclosingPattern = false;
                                                    node_cur_node__node1.isMatched = node_cur_node__node1_prevIsMatched;
                                                    edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                                    node_cur_node__node0.isMatched = node_cur_node__node0_prevIsMatched;
                                                    edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                                                    openTasks.Push(this);
                                                    return;
                                                }
                                                edge_cur_edge__edge3.isMatchedByEnclosingPattern = false;
                                                edge_cur_edge__edge2.isMatchedByEnclosingPattern = false;
                                                edge_cur_edge__edge1.isMatchedByEnclosingPattern = false;
                                                edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                                                node_cur_node__node2.isMatchedByEnclosingPattern = false;
                                                node_cur_node__node1.isMatchedByEnclosingPattern = false;
                                                node_cur_node__node0.isMatchedByEnclosingPattern = false;
                                                node_cur_node_c.isMatchedByEnclosingPattern = false;
                                                continue;
                                            }
                                            node_cur_node_c.isMatchedByEnclosingPattern = false;
                                            node_cur_node__node0.isMatchedByEnclosingPattern = false;
                                            node_cur_node__node1.isMatchedByEnclosingPattern = false;
                                            node_cur_node__node2.isMatchedByEnclosingPattern = false;
                                            edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                                            edge_cur_edge__edge1.isMatchedByEnclosingPattern = false;
                                            edge_cur_edge__edge2.isMatchedByEnclosingPattern = false;
                                            edge_cur_edge__edge3.isMatchedByEnclosingPattern = false;
                                        }
                                        while( (edge_cur_edge__edge3 = edge_cur_edge__edge3.outNext) != edge_head_edge__edge3 );
                                    }
                                    node_cur_node__node1.isMatched = node_cur_node__node1_prevIsMatched;
                                    edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                }
                                while( (edge_cur_edge__edge2 = edge_cur_edge__edge2.outNext) != edge_head_edge__edge2 );
                            }
                            node_cur_node__node0.isMatched = node_cur_node__node0_prevIsMatched;
                            edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                        }
                        while( (edge_cur_edge__edge1 = edge_cur_edge__edge1.outNext) != edge_head_edge__edge1 );
                    }
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                }
                while( (edge_cur_edge__edge0 = edge_cur_edge__edge0.outNext) != edge_head_edge__edge0 );
            }
            openTasks.Push(this);
            return;
        }
	}
	public class PatternAction_Nitro : LGSPSubpatternAction
	{
		public PatternAction_Nitro(LGSPGraph graph_, Stack<LGSPSubpatternAction> openTasks_) {
			graph = graph_; openTasks = openTasks_;
			rulePattern = Pattern_Nitro.Instance;
		}

		public LGSPNode node_anchor;

        public override void myMatch(List<Stack<LGSPMatch>> foundPartialMatches, int maxMatches)
        {
            openTasks.Pop();
            List<Stack<LGSPMatch>> matchesList = foundPartialMatches;
            if(matchesList.Count!=0) throw new ApplicationException(); //debug assert
            // SubPreset node_anchor 
            LGSPNode node_cur_node_anchor = node_anchor;
            // Extend outgoing edge__edge0 from node_anchor 
            LGSPEdge edge_head_edge__edge0 = node_cur_node_anchor.outhead;
            if(edge_head_edge__edge0 != null)
            {
                LGSPEdge edge_cur_edge__edge0 = edge_head_edge__edge0;
                do
                {
                    if(!EdgeType_Edge.isMyType[edge_cur_edge__edge0.type.TypeID]) {
                        continue;
                    }
                    if(edge_cur_edge__edge0.isMatchedByEnclosingPattern)
                    {
                        continue;
                    }
                    bool edge_cur_edge__edge0_prevIsMatched = edge_cur_edge__edge0.isMatched;
                    edge_cur_edge__edge0.isMatched = true;
                    // Implicit target node_n from edge__edge0 
                    LGSPNode node_cur_node_n = edge_cur_edge__edge0.target;
                    if(!NodeType_N.isMyType[node_cur_node_n.type.TypeID]) {
                        edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                        continue;
                    }
                    if(node_cur_node_n.isMatchedByEnclosingPattern)
                    {
                        edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                        continue;
                    }
                    // Extend outgoing edge__edge1 from node_n 
                    LGSPEdge edge_head_edge__edge1 = node_cur_node_n.outhead;
                    if(edge_head_edge__edge1 != null)
                    {
                        LGSPEdge edge_cur_edge__edge1 = edge_head_edge__edge1;
                        do
                        {
                            if(!EdgeType_Edge.isMyType[edge_cur_edge__edge1.type.TypeID]) {
                                continue;
                            }
                            if(edge_cur_edge__edge1.isMatched
                                && edge_cur_edge__edge1==edge_cur_edge__edge0
                                )
                            {
                                continue;
                            }
                            if(edge_cur_edge__edge1.isMatchedByEnclosingPattern)
                            {
                                continue;
                            }
                            bool edge_cur_edge__edge1_prevIsMatched = edge_cur_edge__edge1.isMatched;
                            edge_cur_edge__edge1.isMatched = true;
                            // Implicit target node__node0 from edge__edge1 
                            LGSPNode node_cur_node__node0 = edge_cur_edge__edge1.target;
                            if(!NodeType_O.isMyType[node_cur_node__node0.type.TypeID]) {
                                edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                continue;
                            }
                            if(node_cur_node__node0.isMatchedByEnclosingPattern)
                            {
                                edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                continue;
                            }
                            bool node_cur_node__node0_prevIsMatched = node_cur_node__node0.isMatched;
                            node_cur_node__node0.isMatched = true;
                            // Extend outgoing edge__edge2 from node_n 
                            LGSPEdge edge_head_edge__edge2 = node_cur_node_n.outhead;
                            if(edge_head_edge__edge2 != null)
                            {
                                LGSPEdge edge_cur_edge__edge2 = edge_head_edge__edge2;
                                do
                                {
                                    if(!EdgeType_Edge.isMyType[edge_cur_edge__edge2.type.TypeID]) {
                                        continue;
                                    }
                                    if(edge_cur_edge__edge2.isMatched
                                        && (edge_cur_edge__edge2==edge_cur_edge__edge0
                                            || edge_cur_edge__edge2==edge_cur_edge__edge1
                                            )
                                        )
                                    {
                                        continue;
                                    }
                                    if(edge_cur_edge__edge2.isMatchedByEnclosingPattern)
                                    {
                                        continue;
                                    }
                                    // Implicit target node__node1 from edge__edge2 
                                    LGSPNode node_cur_node__node1 = edge_cur_edge__edge2.target;
                                    if(!NodeType_O.isMyType[node_cur_node__node1.type.TypeID]) {
                                        continue;
                                    }
                                    if(node_cur_node__node1.isMatched
                                        && node_cur_node__node1==node_cur_node__node0
                                        )
                                    {
                                        continue;
                                    }
                                    if(node_cur_node__node1.isMatchedByEnclosingPattern)
                                    {
                                        continue;
                                    }
                                    // Check whether there are subpattern matching tasks left to execute
                                    if(openTasks.Count==0)
                                    {
                                        Stack<LGSPMatch> currentFoundPartialMatch = new Stack<LGSPMatch>();
                                        foundPartialMatches.Add(currentFoundPartialMatch);
                                        LGSPMatch match = new LGSPMatch(new LGSPNode[4], new LGSPEdge[3], new LGSPMatch[0]);
                                        match.patternGraph = rulePattern.patternGraph;
                                        match.Nodes[(int)Pattern_Nitro.NodeNums.@anchor] = node_cur_node_anchor;
                                        match.Nodes[(int)Pattern_Nitro.NodeNums.@n] = node_cur_node_n;
                                        match.Nodes[(int)Pattern_Nitro.NodeNums.@_node0] = node_cur_node__node0;
                                        match.Nodes[(int)Pattern_Nitro.NodeNums.@_node1] = node_cur_node__node1;
                                        match.Edges[(int)Pattern_Nitro.EdgeNums.@_edge0] = edge_cur_edge__edge0;
                                        match.Edges[(int)Pattern_Nitro.EdgeNums.@_edge1] = edge_cur_edge__edge1;
                                        match.Edges[(int)Pattern_Nitro.EdgeNums.@_edge2] = edge_cur_edge__edge2;
                                        currentFoundPartialMatch.Push(match);
                                        // if enough matches were found, we leave
                                        if(maxMatches > 0 && foundPartialMatches.Count >= maxMatches)
                                        {
                                            node_cur_node__node0.isMatched = node_cur_node__node0_prevIsMatched;
                                            edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                            edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                                            openTasks.Push(this);
                                            return;
                                        }
                                        continue;
                                    }
                                    node_cur_node_n.isMatchedByEnclosingPattern = true;
                                    node_cur_node__node0.isMatchedByEnclosingPattern = true;
                                    node_cur_node__node1.isMatchedByEnclosingPattern = true;
                                    edge_cur_edge__edge0.isMatchedByEnclosingPattern = true;
                                    edge_cur_edge__edge1.isMatchedByEnclosingPattern = true;
                                    edge_cur_edge__edge2.isMatchedByEnclosingPattern = true;
                                    // Match subpatterns
                                    openTasks.Peek().myMatch(matchesList, maxMatches - foundPartialMatches.Count);
                                    // Check whether subpatterns were found 
                                    if(matchesList.Count>0) {
                                        // subpatterns were found, extend the partial matches by our local match object
                                        foreach(Stack<LGSPMatch> currentFoundPartialMatch in matchesList)
                                        {
                                            LGSPMatch match = new LGSPMatch(new LGSPNode[4], new LGSPEdge[3], new LGSPMatch[0]);
                                            match.patternGraph = rulePattern.patternGraph;
                                            match.Nodes[(int)Pattern_Nitro.NodeNums.@anchor] = node_cur_node_anchor;
                                            match.Nodes[(int)Pattern_Nitro.NodeNums.@n] = node_cur_node_n;
                                            match.Nodes[(int)Pattern_Nitro.NodeNums.@_node0] = node_cur_node__node0;
                                            match.Nodes[(int)Pattern_Nitro.NodeNums.@_node1] = node_cur_node__node1;
                                            match.Edges[(int)Pattern_Nitro.EdgeNums.@_edge0] = edge_cur_edge__edge0;
                                            match.Edges[(int)Pattern_Nitro.EdgeNums.@_edge1] = edge_cur_edge__edge1;
                                            match.Edges[(int)Pattern_Nitro.EdgeNums.@_edge2] = edge_cur_edge__edge2;
                                            currentFoundPartialMatch.Push(match);
                                        }
                                        if(matchesList==foundPartialMatches) {
                                            matchesList = new List<Stack<LGSPMatch>>();
                                        } else {
                                            foreach(Stack<LGSPMatch> match in matchesList)
                                            {
                                                foundPartialMatches.Add(match);
                                            }
                                            matchesList.Clear();
                                        }
                                        // if enough matches were found, we leave
                                        if(maxMatches > 0 && foundPartialMatches.Count >= maxMatches)
                                        {
                                            edge_cur_edge__edge2.isMatchedByEnclosingPattern = false;
                                            edge_cur_edge__edge1.isMatchedByEnclosingPattern = false;
                                            edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                                            node_cur_node__node1.isMatchedByEnclosingPattern = false;
                                            node_cur_node__node0.isMatchedByEnclosingPattern = false;
                                            node_cur_node_n.isMatchedByEnclosingPattern = false;
                                            node_cur_node__node0.isMatched = node_cur_node__node0_prevIsMatched;
                                            edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                            edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                                            openTasks.Push(this);
                                            return;
                                        }
                                        edge_cur_edge__edge2.isMatchedByEnclosingPattern = false;
                                        edge_cur_edge__edge1.isMatchedByEnclosingPattern = false;
                                        edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                                        node_cur_node__node1.isMatchedByEnclosingPattern = false;
                                        node_cur_node__node0.isMatchedByEnclosingPattern = false;
                                        node_cur_node_n.isMatchedByEnclosingPattern = false;
                                        continue;
                                    }
                                    node_cur_node_n.isMatchedByEnclosingPattern = false;
                                    node_cur_node__node0.isMatchedByEnclosingPattern = false;
                                    node_cur_node__node1.isMatchedByEnclosingPattern = false;
                                    edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                                    edge_cur_edge__edge1.isMatchedByEnclosingPattern = false;
                                    edge_cur_edge__edge2.isMatchedByEnclosingPattern = false;
                                }
                                while( (edge_cur_edge__edge2 = edge_cur_edge__edge2.outNext) != edge_head_edge__edge2 );
                            }
                            node_cur_node__node0.isMatched = node_cur_node__node0_prevIsMatched;
                            edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                        }
                        while( (edge_cur_edge__edge1 = edge_cur_edge__edge1.outNext) != edge_head_edge__edge1 );
                    }
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                }
                while( (edge_cur_edge__edge0 = edge_cur_edge__edge0.outNext) != edge_head_edge__edge0 );
            }
            openTasks.Push(this);
            return;
        }
	}
	public class Action_DNT : LGSPAction
	{
		public Action_DNT() {
			rulePattern = Rule_DNT.Instance;
			DynamicMatch = myMatch; matches = new LGSPMatches(this, 6, 9, 6);
		}

		public override string Name { get { return "DNT"; } }
		private LGSPMatches matches;

		public static LGSPAction Instance { get { return instance; } }
		private static Action_DNT instance = new Action_DNT();

        public LGSPMatches myMatch(LGSPGraph graph, int maxMatches, IGraphElement[] parameters)
        {
            matches.matchesList.Clear();
            Stack<LGSPSubpatternAction> openTasks = new Stack<LGSPSubpatternAction>();
            List<Stack<LGSPMatch>> foundPartialMatches = new List<Stack<LGSPMatch>>();
            List<Stack<LGSPMatch>> matchesList = foundPartialMatches;
            // Lookup edge__edge0 
            int edge_type_id_edge__edge0 = 2;
            for(LGSPEdge edge_head_edge__edge0 = graph.edgesByTypeHeads[edge_type_id_edge__edge0], edge_cur_edge__edge0 = edge_head_edge__edge0.typeNext; edge_cur_edge__edge0 != edge_head_edge__edge0; edge_cur_edge__edge0 = edge_cur_edge__edge0.typeNext)
            {
                bool edge_cur_edge__edge0_prevIsMatched = edge_cur_edge__edge0.isMatched;
                edge_cur_edge__edge0.isMatched = true;
                // Implicit source node_c1 from edge__edge0 
                LGSPNode node_cur_node_c1 = edge_cur_edge__edge0.source;
                if(!NodeType_C.isMyType[node_cur_node_c1.type.TypeID]) {
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                    continue;
                }
                bool node_cur_node_c1_prevIsMatched = node_cur_node_c1.isMatched;
                node_cur_node_c1.isMatched = true;
                // Implicit target node_c2 from edge__edge0 
                LGSPNode node_cur_node_c2 = edge_cur_edge__edge0.target;
                if(!NodeType_C.isMyType[node_cur_node_c2.type.TypeID]) {
                    node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                    continue;
                }
                if(node_cur_node_c2.isMatched
                    && node_cur_node_c2==node_cur_node_c1
                    )
                {
                    node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                    continue;
                }
                bool node_cur_node_c2_prevIsMatched = node_cur_node_c2.isMatched;
                node_cur_node_c2.isMatched = true;
                // Extend outgoing edge__edge6 from node_c1 
                LGSPEdge edge_head_edge__edge6 = node_cur_node_c1.outhead;
                if(edge_head_edge__edge6 != null)
                {
                    LGSPEdge edge_cur_edge__edge6 = edge_head_edge__edge6;
                    do
                    {
                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge6.type.TypeID]) {
                            continue;
                        }
                        if(edge_cur_edge__edge6.target != node_cur_node_c2) {
                            continue;
                        }
                        if(edge_cur_edge__edge6.isMatched
                            && edge_cur_edge__edge6==edge_cur_edge__edge0
                            )
                        {
                            continue;
                        }
                        bool edge_cur_edge__edge6_prevIsMatched = edge_cur_edge__edge6.isMatched;
                        edge_cur_edge__edge6.isMatched = true;
                        // Extend outgoing edge__edge1 from node_c2 
                        LGSPEdge edge_head_edge__edge1 = node_cur_node_c2.outhead;
                        if(edge_head_edge__edge1 != null)
                        {
                            LGSPEdge edge_cur_edge__edge1 = edge_head_edge__edge1;
                            do
                            {
                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge1.type.TypeID]) {
                                    continue;
                                }
                                if(edge_cur_edge__edge1.isMatched
                                    && (edge_cur_edge__edge1==edge_cur_edge__edge0
                                        || edge_cur_edge__edge1==edge_cur_edge__edge6
                                        )
                                    )
                                {
                                    continue;
                                }
                                bool edge_cur_edge__edge1_prevIsMatched = edge_cur_edge__edge1.isMatched;
                                edge_cur_edge__edge1.isMatched = true;
                                // Implicit target node_c3 from edge__edge1 
                                LGSPNode node_cur_node_c3 = edge_cur_edge__edge1.target;
                                if(!NodeType_C.isMyType[node_cur_node_c3.type.TypeID]) {
                                    edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                    continue;
                                }
                                if(node_cur_node_c3.isMatched
                                    && (node_cur_node_c3==node_cur_node_c1
                                        || node_cur_node_c3==node_cur_node_c2
                                        )
                                    )
                                {
                                    edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                    continue;
                                }
                                bool node_cur_node_c3_prevIsMatched = node_cur_node_c3.isMatched;
                                node_cur_node_c3.isMatched = true;
                                // Extend outgoing edge__edge2 from node_c3 
                                LGSPEdge edge_head_edge__edge2 = node_cur_node_c3.outhead;
                                if(edge_head_edge__edge2 != null)
                                {
                                    LGSPEdge edge_cur_edge__edge2 = edge_head_edge__edge2;
                                    do
                                    {
                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge2.type.TypeID]) {
                                            continue;
                                        }
                                        if(edge_cur_edge__edge2.isMatched
                                            && (edge_cur_edge__edge2==edge_cur_edge__edge0
                                                || edge_cur_edge__edge2==edge_cur_edge__edge6
                                                || edge_cur_edge__edge2==edge_cur_edge__edge1
                                                )
                                            )
                                        {
                                            continue;
                                        }
                                        bool edge_cur_edge__edge2_prevIsMatched = edge_cur_edge__edge2.isMatched;
                                        edge_cur_edge__edge2.isMatched = true;
                                        // Implicit target node_c4 from edge__edge2 
                                        LGSPNode node_cur_node_c4 = edge_cur_edge__edge2.target;
                                        if(!NodeType_C.isMyType[node_cur_node_c4.type.TypeID]) {
                                            edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                            continue;
                                        }
                                        if(node_cur_node_c4.isMatched
                                            && (node_cur_node_c4==node_cur_node_c1
                                                || node_cur_node_c4==node_cur_node_c2
                                                || node_cur_node_c4==node_cur_node_c3
                                                )
                                            )
                                        {
                                            edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                            continue;
                                        }
                                        bool node_cur_node_c4_prevIsMatched = node_cur_node_c4.isMatched;
                                        node_cur_node_c4.isMatched = true;
                                        // Extend outgoing edge__edge7 from node_c3 
                                        LGSPEdge edge_head_edge__edge7 = node_cur_node_c3.outhead;
                                        if(edge_head_edge__edge7 != null)
                                        {
                                            LGSPEdge edge_cur_edge__edge7 = edge_head_edge__edge7;
                                            do
                                            {
                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge7.type.TypeID]) {
                                                    continue;
                                                }
                                                if(edge_cur_edge__edge7.target != node_cur_node_c4) {
                                                    continue;
                                                }
                                                if(edge_cur_edge__edge7.isMatched
                                                    && (edge_cur_edge__edge7==edge_cur_edge__edge0
                                                        || edge_cur_edge__edge7==edge_cur_edge__edge6
                                                        || edge_cur_edge__edge7==edge_cur_edge__edge1
                                                        || edge_cur_edge__edge7==edge_cur_edge__edge2
                                                        )
                                                    )
                                                {
                                                    continue;
                                                }
                                                bool edge_cur_edge__edge7_prevIsMatched = edge_cur_edge__edge7.isMatched;
                                                edge_cur_edge__edge7.isMatched = true;
                                                // Extend outgoing edge__edge3 from node_c4 
                                                LGSPEdge edge_head_edge__edge3 = node_cur_node_c4.outhead;
                                                if(edge_head_edge__edge3 != null)
                                                {
                                                    LGSPEdge edge_cur_edge__edge3 = edge_head_edge__edge3;
                                                    do
                                                    {
                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge3.type.TypeID]) {
                                                            continue;
                                                        }
                                                        if(edge_cur_edge__edge3.isMatched
                                                            && (edge_cur_edge__edge3==edge_cur_edge__edge0
                                                                || edge_cur_edge__edge3==edge_cur_edge__edge6
                                                                || edge_cur_edge__edge3==edge_cur_edge__edge1
                                                                || edge_cur_edge__edge3==edge_cur_edge__edge2
                                                                || edge_cur_edge__edge3==edge_cur_edge__edge7
                                                                )
                                                            )
                                                        {
                                                            continue;
                                                        }
                                                        bool edge_cur_edge__edge3_prevIsMatched = edge_cur_edge__edge3.isMatched;
                                                        edge_cur_edge__edge3.isMatched = true;
                                                        // Implicit target node_c5 from edge__edge3 
                                                        LGSPNode node_cur_node_c5 = edge_cur_edge__edge3.target;
                                                        if(!NodeType_C.isMyType[node_cur_node_c5.type.TypeID]) {
                                                            edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                            continue;
                                                        }
                                                        if(node_cur_node_c5.isMatched
                                                            && (node_cur_node_c5==node_cur_node_c1
                                                                || node_cur_node_c5==node_cur_node_c2
                                                                || node_cur_node_c5==node_cur_node_c3
                                                                || node_cur_node_c5==node_cur_node_c4
                                                                )
                                                            )
                                                        {
                                                            edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                            continue;
                                                        }
                                                        bool node_cur_node_c5_prevIsMatched = node_cur_node_c5.isMatched;
                                                        node_cur_node_c5.isMatched = true;
                                                        // Extend outgoing edge__edge4 from node_c5 
                                                        LGSPEdge edge_head_edge__edge4 = node_cur_node_c5.outhead;
                                                        if(edge_head_edge__edge4 != null)
                                                        {
                                                            LGSPEdge edge_cur_edge__edge4 = edge_head_edge__edge4;
                                                            do
                                                            {
                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge4.type.TypeID]) {
                                                                    continue;
                                                                }
                                                                if(edge_cur_edge__edge4.isMatched
                                                                    && (edge_cur_edge__edge4==edge_cur_edge__edge0
                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge6
                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge1
                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge2
                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge7
                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge3
                                                                        )
                                                                    )
                                                                {
                                                                    continue;
                                                                }
                                                                bool edge_cur_edge__edge4_prevIsMatched = edge_cur_edge__edge4.isMatched;
                                                                edge_cur_edge__edge4.isMatched = true;
                                                                // Implicit target node_c6 from edge__edge4 
                                                                LGSPNode node_cur_node_c6 = edge_cur_edge__edge4.target;
                                                                if(!NodeType_C.isMyType[node_cur_node_c6.type.TypeID]) {
                                                                    edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                    continue;
                                                                }
                                                                if(node_cur_node_c6.isMatched
                                                                    && (node_cur_node_c6==node_cur_node_c1
                                                                        || node_cur_node_c6==node_cur_node_c2
                                                                        || node_cur_node_c6==node_cur_node_c3
                                                                        || node_cur_node_c6==node_cur_node_c4
                                                                        || node_cur_node_c6==node_cur_node_c5
                                                                        )
                                                                    )
                                                                {
                                                                    edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                    continue;
                                                                }
                                                                // Extend outgoing edge__edge8 from node_c5 
                                                                LGSPEdge edge_head_edge__edge8 = node_cur_node_c5.outhead;
                                                                if(edge_head_edge__edge8 != null)
                                                                {
                                                                    LGSPEdge edge_cur_edge__edge8 = edge_head_edge__edge8;
                                                                    do
                                                                    {
                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge8.type.TypeID]) {
                                                                            continue;
                                                                        }
                                                                        if(edge_cur_edge__edge8.target != node_cur_node_c6) {
                                                                            continue;
                                                                        }
                                                                        if(edge_cur_edge__edge8.isMatched
                                                                            && (edge_cur_edge__edge8==edge_cur_edge__edge0
                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge6
                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge1
                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge2
                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge7
                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge3
                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge4
                                                                                )
                                                                            )
                                                                        {
                                                                            continue;
                                                                        }
                                                                        bool edge_cur_edge__edge8_prevIsMatched = edge_cur_edge__edge8.isMatched;
                                                                        edge_cur_edge__edge8.isMatched = true;
                                                                        // Extend outgoing edge__edge5 from node_c6 
                                                                        LGSPEdge edge_head_edge__edge5 = node_cur_node_c6.outhead;
                                                                        if(edge_head_edge__edge5 != null)
                                                                        {
                                                                            LGSPEdge edge_cur_edge__edge5 = edge_head_edge__edge5;
                                                                            do
                                                                            {
                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge5.type.TypeID]) {
                                                                                    continue;
                                                                                }
                                                                                if(edge_cur_edge__edge5.target != node_cur_node_c1) {
                                                                                    continue;
                                                                                }
                                                                                if(edge_cur_edge__edge5.isMatched
                                                                                    && (edge_cur_edge__edge5==edge_cur_edge__edge0
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge6
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge1
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge2
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge7
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge3
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge4
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge8
                                                                                        )
                                                                                    )
                                                                                {
                                                                                    continue;
                                                                                }
                                                                                // Push subpattern matching task for _subpattern5
                                                                                PatternAction_Hydrogen taskFor__subpattern5 = new PatternAction_Hydrogen(graph, openTasks);
                                                                                taskFor__subpattern5.node_anchor = node_cur_node_c6;
                                                                                openTasks.Push(taskFor__subpattern5);
                                                                                // Push subpattern matching task for _subpattern4
                                                                                PatternAction_Hydrogen taskFor__subpattern4 = new PatternAction_Hydrogen(graph, openTasks);
                                                                                taskFor__subpattern4.node_anchor = node_cur_node_c5;
                                                                                openTasks.Push(taskFor__subpattern4);
                                                                                // Push subpattern matching task for _subpattern3
                                                                                PatternAction_Nitro taskFor__subpattern3 = new PatternAction_Nitro(graph, openTasks);
                                                                                taskFor__subpattern3.node_anchor = node_cur_node_c4;
                                                                                openTasks.Push(taskFor__subpattern3);
                                                                                // Push subpattern matching task for _subpattern2
                                                                                PatternAction_Hydrogen taskFor__subpattern2 = new PatternAction_Hydrogen(graph, openTasks);
                                                                                taskFor__subpattern2.node_anchor = node_cur_node_c3;
                                                                                openTasks.Push(taskFor__subpattern2);
                                                                                // Push subpattern matching task for _subpattern1
                                                                                PatternAction_Nitro taskFor__subpattern1 = new PatternAction_Nitro(graph, openTasks);
                                                                                taskFor__subpattern1.node_anchor = node_cur_node_c2;
                                                                                openTasks.Push(taskFor__subpattern1);
                                                                                // Push subpattern matching task for _subpattern0
                                                                                PatternAction_Methyl taskFor__subpattern0 = new PatternAction_Methyl(graph, openTasks);
                                                                                taskFor__subpattern0.node_anchor = node_cur_node_c1;
                                                                                openTasks.Push(taskFor__subpattern0);
                                                                                node_cur_node_c1.isMatchedByEnclosingPattern = true;
                                                                                node_cur_node_c2.isMatchedByEnclosingPattern = true;
                                                                                node_cur_node_c3.isMatchedByEnclosingPattern = true;
                                                                                node_cur_node_c4.isMatchedByEnclosingPattern = true;
                                                                                node_cur_node_c5.isMatchedByEnclosingPattern = true;
                                                                                node_cur_node_c6.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge0.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge1.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge2.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge3.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge4.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge5.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge6.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge7.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge8.isMatchedByEnclosingPattern = true;
                                                                                // Match subpatterns
                                                                                openTasks.Peek().myMatch(matchesList, maxMatches - foundPartialMatches.Count);
                                                                                //Pop subpattern matching task for _subpattern0
                                                                                openTasks.Pop();
                                                                                //Pop subpattern matching task for _subpattern1
                                                                                openTasks.Pop();
                                                                                //Pop subpattern matching task for _subpattern2
                                                                                openTasks.Pop();
                                                                                //Pop subpattern matching task for _subpattern3
                                                                                openTasks.Pop();
                                                                                //Pop subpattern matching task for _subpattern4
                                                                                openTasks.Pop();
                                                                                //Pop subpattern matching task for _subpattern5
                                                                                openTasks.Pop();
                                                                                // Check whether subpatterns were found 
                                                                                if(matchesList.Count>0) {
                                                                                    // subpatterns were found, extend the partial matches by our local match object, becoming a complete match object and save it
                                                                                    foreach(Stack<LGSPMatch> currentFoundPartialMatch in matchesList)
                                                                                    {
                                                                                        LGSPMatch match = matches.matchesList.GetEmptyMatchFromList();
                                                                                        match.patternGraph = rulePattern.patternGraph;
                                                                                        match.Nodes[(int)Rule_DNT.NodeNums.@c1] = node_cur_node_c1;
                                                                                        match.Nodes[(int)Rule_DNT.NodeNums.@c2] = node_cur_node_c2;
                                                                                        match.Nodes[(int)Rule_DNT.NodeNums.@c3] = node_cur_node_c3;
                                                                                        match.Nodes[(int)Rule_DNT.NodeNums.@c4] = node_cur_node_c4;
                                                                                        match.Nodes[(int)Rule_DNT.NodeNums.@c5] = node_cur_node_c5;
                                                                                        match.Nodes[(int)Rule_DNT.NodeNums.@c6] = node_cur_node_c6;
                                                                                        match.Edges[(int)Rule_DNT.EdgeNums.@_edge0] = edge_cur_edge__edge0;
                                                                                        match.Edges[(int)Rule_DNT.EdgeNums.@_edge1] = edge_cur_edge__edge1;
                                                                                        match.Edges[(int)Rule_DNT.EdgeNums.@_edge2] = edge_cur_edge__edge2;
                                                                                        match.Edges[(int)Rule_DNT.EdgeNums.@_edge3] = edge_cur_edge__edge3;
                                                                                        match.Edges[(int)Rule_DNT.EdgeNums.@_edge4] = edge_cur_edge__edge4;
                                                                                        match.Edges[(int)Rule_DNT.EdgeNums.@_edge5] = edge_cur_edge__edge5;
                                                                                        match.Edges[(int)Rule_DNT.EdgeNums.@_edge6] = edge_cur_edge__edge6;
                                                                                        match.Edges[(int)Rule_DNT.EdgeNums.@_edge7] = edge_cur_edge__edge7;
                                                                                        match.Edges[(int)Rule_DNT.EdgeNums.@_edge8] = edge_cur_edge__edge8;
                                                                                        match.EmbeddedGraphs[(int)Rule_DNT.PatternNums.@_subpattern0] = currentFoundPartialMatch.Pop();
                                                                                        match.EmbeddedGraphs[(int)Rule_DNT.PatternNums.@_subpattern1] = currentFoundPartialMatch.Pop();
                                                                                        match.EmbeddedGraphs[(int)Rule_DNT.PatternNums.@_subpattern2] = currentFoundPartialMatch.Pop();
                                                                                        match.EmbeddedGraphs[(int)Rule_DNT.PatternNums.@_subpattern3] = currentFoundPartialMatch.Pop();
                                                                                        match.EmbeddedGraphs[(int)Rule_DNT.PatternNums.@_subpattern4] = currentFoundPartialMatch.Pop();
                                                                                        match.EmbeddedGraphs[(int)Rule_DNT.PatternNums.@_subpattern5] = currentFoundPartialMatch.Pop();
                                                                                        matches.matchesList.EmptyMatchWasFilledFixIt();
                                                                                    }
                                                                                    matchesList.Clear();
                                                                                    // if enough matches were found, we leave
                                                                                    if(maxMatches > 0 && matches.matchesList.Count >= maxMatches)
                                                                                    {
                                                                                        edge_cur_edge__edge8.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge7.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge6.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge5.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge4.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge3.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge2.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge1.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                                                                                        node_cur_node_c6.isMatchedByEnclosingPattern = false;
                                                                                        node_cur_node_c5.isMatchedByEnclosingPattern = false;
                                                                                        node_cur_node_c4.isMatchedByEnclosingPattern = false;
                                                                                        node_cur_node_c3.isMatchedByEnclosingPattern = false;
                                                                                        node_cur_node_c2.isMatchedByEnclosingPattern = false;
                                                                                        node_cur_node_c1.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge8.isMatched = edge_cur_edge__edge8_prevIsMatched;
                                                                                        edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                                        node_cur_node_c5.isMatched = node_cur_node_c5_prevIsMatched;
                                                                                        edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                                                        edge_cur_edge__edge7.isMatched = edge_cur_edge__edge7_prevIsMatched;
                                                                                        node_cur_node_c4.isMatched = node_cur_node_c4_prevIsMatched;
                                                                                        edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                                                                        node_cur_node_c3.isMatched = node_cur_node_c3_prevIsMatched;
                                                                                        edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                                                                        edge_cur_edge__edge6.isMatched = edge_cur_edge__edge6_prevIsMatched;
                                                                                        node_cur_node_c2.isMatched = node_cur_node_c2_prevIsMatched;
                                                                                        node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                                                                                        edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                                                                                        return matches;
                                                                                    }
                                                                                    edge_cur_edge__edge8.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge7.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge6.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge5.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge4.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge3.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge2.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge1.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                                                                                    node_cur_node_c6.isMatchedByEnclosingPattern = false;
                                                                                    node_cur_node_c5.isMatchedByEnclosingPattern = false;
                                                                                    node_cur_node_c4.isMatchedByEnclosingPattern = false;
                                                                                    node_cur_node_c3.isMatchedByEnclosingPattern = false;
                                                                                    node_cur_node_c2.isMatchedByEnclosingPattern = false;
                                                                                    node_cur_node_c1.isMatchedByEnclosingPattern = false;
                                                                                    continue;
                                                                                }
                                                                                node_cur_node_c1.isMatchedByEnclosingPattern = false;
                                                                                node_cur_node_c2.isMatchedByEnclosingPattern = false;
                                                                                node_cur_node_c3.isMatchedByEnclosingPattern = false;
                                                                                node_cur_node_c4.isMatchedByEnclosingPattern = false;
                                                                                node_cur_node_c5.isMatchedByEnclosingPattern = false;
                                                                                node_cur_node_c6.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge1.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge2.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge3.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge4.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge5.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge6.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge7.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge8.isMatchedByEnclosingPattern = false;
                                                                            }
                                                                            while( (edge_cur_edge__edge5 = edge_cur_edge__edge5.outNext) != edge_head_edge__edge5 );
                                                                        }
                                                                        edge_cur_edge__edge8.isMatched = edge_cur_edge__edge8_prevIsMatched;
                                                                    }
                                                                    while( (edge_cur_edge__edge8 = edge_cur_edge__edge8.outNext) != edge_head_edge__edge8 );
                                                                }
                                                                edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                            }
                                                            while( (edge_cur_edge__edge4 = edge_cur_edge__edge4.outNext) != edge_head_edge__edge4 );
                                                        }
                                                        node_cur_node_c5.isMatched = node_cur_node_c5_prevIsMatched;
                                                        edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                    }
                                                    while( (edge_cur_edge__edge3 = edge_cur_edge__edge3.outNext) != edge_head_edge__edge3 );
                                                }
                                                edge_cur_edge__edge7.isMatched = edge_cur_edge__edge7_prevIsMatched;
                                            }
                                            while( (edge_cur_edge__edge7 = edge_cur_edge__edge7.outNext) != edge_head_edge__edge7 );
                                        }
                                        node_cur_node_c4.isMatched = node_cur_node_c4_prevIsMatched;
                                        edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                    }
                                    while( (edge_cur_edge__edge2 = edge_cur_edge__edge2.outNext) != edge_head_edge__edge2 );
                                }
                                node_cur_node_c3.isMatched = node_cur_node_c3_prevIsMatched;
                                edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                            }
                            while( (edge_cur_edge__edge1 = edge_cur_edge__edge1.outNext) != edge_head_edge__edge1 );
                        }
                        edge_cur_edge__edge6.isMatched = edge_cur_edge__edge6_prevIsMatched;
                    }
                    while( (edge_cur_edge__edge6 = edge_cur_edge__edge6.outNext) != edge_head_edge__edge6 );
                }
                node_cur_node_c2.isMatched = node_cur_node_c2_prevIsMatched;
                node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
            }
            return matches;
        }
	}
	public class Action_DNTUnfolded : LGSPAction
	{
		public Action_DNTUnfolded() {
			rulePattern = Rule_DNTUnfolded.Instance;
			DynamicMatch = myMatch; matches = new LGSPMatches(this, 19, 22, 0);
		}

		public override string Name { get { return "DNTUnfolded"; } }
		private LGSPMatches matches;

		public static LGSPAction Instance { get { return instance; } }
		private static Action_DNTUnfolded instance = new Action_DNTUnfolded();

        public LGSPMatches myMatch(LGSPGraph graph, int maxMatches, IGraphElement[] parameters)
        {
            matches.matchesList.Clear();
            // Lookup edge__edge0 
            int edge_type_id_edge__edge0 = 2;
            for(LGSPEdge edge_head_edge__edge0 = graph.edgesByTypeHeads[edge_type_id_edge__edge0], edge_cur_edge__edge0 = edge_head_edge__edge0.typeNext; edge_cur_edge__edge0 != edge_head_edge__edge0; edge_cur_edge__edge0 = edge_cur_edge__edge0.typeNext)
            {
                bool edge_cur_edge__edge0_prevIsMatched = edge_cur_edge__edge0.isMatched;
                edge_cur_edge__edge0.isMatched = true;
                // Implicit source node_c1 from edge__edge0 
                LGSPNode node_cur_node_c1 = edge_cur_edge__edge0.source;
                if(!NodeType_C.isMyType[node_cur_node_c1.type.TypeID]) {
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                    continue;
                }
                bool node_cur_node_c1_prevIsMatched = node_cur_node_c1.isMatched;
                node_cur_node_c1.isMatched = true;
                // Implicit target node_c2 from edge__edge0 
                LGSPNode node_cur_node_c2 = edge_cur_edge__edge0.target;
                if(!NodeType_C.isMyType[node_cur_node_c2.type.TypeID]) {
                    node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                    continue;
                }
                if(node_cur_node_c2.isMatched
                    && node_cur_node_c2==node_cur_node_c1
                    )
                {
                    node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                    continue;
                }
                bool node_cur_node_c2_prevIsMatched = node_cur_node_c2.isMatched;
                node_cur_node_c2.isMatched = true;
                // Extend outgoing edge__edge6 from node_c1 
                LGSPEdge edge_head_edge__edge6 = node_cur_node_c1.outhead;
                if(edge_head_edge__edge6 != null)
                {
                    LGSPEdge edge_cur_edge__edge6 = edge_head_edge__edge6;
                    do
                    {
                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge6.type.TypeID]) {
                            continue;
                        }
                        if(edge_cur_edge__edge6.target != node_cur_node_c2) {
                            continue;
                        }
                        if(edge_cur_edge__edge6.isMatched
                            && edge_cur_edge__edge6==edge_cur_edge__edge0
                            )
                        {
                            continue;
                        }
                        bool edge_cur_edge__edge6_prevIsMatched = edge_cur_edge__edge6.isMatched;
                        edge_cur_edge__edge6.isMatched = true;
                        // Extend outgoing edge__edge9 from node_c1 
                        LGSPEdge edge_head_edge__edge9 = node_cur_node_c1.outhead;
                        if(edge_head_edge__edge9 != null)
                        {
                            LGSPEdge edge_cur_edge__edge9 = edge_head_edge__edge9;
                            do
                            {
                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge9.type.TypeID]) {
                                    continue;
                                }
                                if(edge_cur_edge__edge9.isMatched
                                    && (edge_cur_edge__edge9==edge_cur_edge__edge0
                                        || edge_cur_edge__edge9==edge_cur_edge__edge6
                                        )
                                    )
                                {
                                    continue;
                                }
                                bool edge_cur_edge__edge9_prevIsMatched = edge_cur_edge__edge9.isMatched;
                                edge_cur_edge__edge9.isMatched = true;
                                // Implicit target node_c from edge__edge9 
                                LGSPNode node_cur_node_c = edge_cur_edge__edge9.target;
                                if(!NodeType_C.isMyType[node_cur_node_c.type.TypeID]) {
                                    edge_cur_edge__edge9.isMatched = edge_cur_edge__edge9_prevIsMatched;
                                    continue;
                                }
                                if(node_cur_node_c.isMatched
                                    && (node_cur_node_c==node_cur_node_c1
                                        || node_cur_node_c==node_cur_node_c2
                                        )
                                    )
                                {
                                    edge_cur_edge__edge9.isMatched = edge_cur_edge__edge9_prevIsMatched;
                                    continue;
                                }
                                bool node_cur_node_c_prevIsMatched = node_cur_node_c.isMatched;
                                node_cur_node_c.isMatched = true;
                                // Extend outgoing edge__edge1 from node_c2 
                                LGSPEdge edge_head_edge__edge1 = node_cur_node_c2.outhead;
                                if(edge_head_edge__edge1 != null)
                                {
                                    LGSPEdge edge_cur_edge__edge1 = edge_head_edge__edge1;
                                    do
                                    {
                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge1.type.TypeID]) {
                                            continue;
                                        }
                                        if(edge_cur_edge__edge1.isMatched
                                            && (edge_cur_edge__edge1==edge_cur_edge__edge0
                                                || edge_cur_edge__edge1==edge_cur_edge__edge6
                                                || edge_cur_edge__edge1==edge_cur_edge__edge9
                                                )
                                            )
                                        {
                                            continue;
                                        }
                                        bool edge_cur_edge__edge1_prevIsMatched = edge_cur_edge__edge1.isMatched;
                                        edge_cur_edge__edge1.isMatched = true;
                                        // Implicit target node_c3 from edge__edge1 
                                        LGSPNode node_cur_node_c3 = edge_cur_edge__edge1.target;
                                        if(!NodeType_C.isMyType[node_cur_node_c3.type.TypeID]) {
                                            edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                            continue;
                                        }
                                        if(node_cur_node_c3.isMatched
                                            && (node_cur_node_c3==node_cur_node_c1
                                                || node_cur_node_c3==node_cur_node_c2
                                                || node_cur_node_c3==node_cur_node_c
                                                )
                                            )
                                        {
                                            edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                            continue;
                                        }
                                        bool node_cur_node_c3_prevIsMatched = node_cur_node_c3.isMatched;
                                        node_cur_node_c3.isMatched = true;
                                        // Extend outgoing edge__edge13 from node_c2 
                                        LGSPEdge edge_head_edge__edge13 = node_cur_node_c2.outhead;
                                        if(edge_head_edge__edge13 != null)
                                        {
                                            LGSPEdge edge_cur_edge__edge13 = edge_head_edge__edge13;
                                            do
                                            {
                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge13.type.TypeID]) {
                                                    continue;
                                                }
                                                if(edge_cur_edge__edge13.isMatched
                                                    && (edge_cur_edge__edge13==edge_cur_edge__edge0
                                                        || edge_cur_edge__edge13==edge_cur_edge__edge6
                                                        || edge_cur_edge__edge13==edge_cur_edge__edge9
                                                        || edge_cur_edge__edge13==edge_cur_edge__edge1
                                                        )
                                                    )
                                                {
                                                    continue;
                                                }
                                                bool edge_cur_edge__edge13_prevIsMatched = edge_cur_edge__edge13.isMatched;
                                                edge_cur_edge__edge13.isMatched = true;
                                                // Implicit target node_n2 from edge__edge13 
                                                LGSPNode node_cur_node_n2 = edge_cur_edge__edge13.target;
                                                if(!NodeType_N.isMyType[node_cur_node_n2.type.TypeID]) {
                                                    edge_cur_edge__edge13.isMatched = edge_cur_edge__edge13_prevIsMatched;
                                                    continue;
                                                }
                                                bool node_cur_node_n2_prevIsMatched = node_cur_node_n2.isMatched;
                                                node_cur_node_n2.isMatched = true;
                                                // Extend outgoing edge__edge10 from node_c 
                                                LGSPEdge edge_head_edge__edge10 = node_cur_node_c.outhead;
                                                if(edge_head_edge__edge10 != null)
                                                {
                                                    LGSPEdge edge_cur_edge__edge10 = edge_head_edge__edge10;
                                                    do
                                                    {
                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge10.type.TypeID]) {
                                                            continue;
                                                        }
                                                        if(edge_cur_edge__edge10.isMatched
                                                            && (edge_cur_edge__edge10==edge_cur_edge__edge0
                                                                || edge_cur_edge__edge10==edge_cur_edge__edge6
                                                                || edge_cur_edge__edge10==edge_cur_edge__edge9
                                                                || edge_cur_edge__edge10==edge_cur_edge__edge1
                                                                || edge_cur_edge__edge10==edge_cur_edge__edge13
                                                                )
                                                            )
                                                        {
                                                            continue;
                                                        }
                                                        bool edge_cur_edge__edge10_prevIsMatched = edge_cur_edge__edge10.isMatched;
                                                        edge_cur_edge__edge10.isMatched = true;
                                                        // Implicit target node__node0 from edge__edge10 
                                                        LGSPNode node_cur_node__node0 = edge_cur_edge__edge10.target;
                                                        if(!NodeType_H.isMyType[node_cur_node__node0.type.TypeID]) {
                                                            edge_cur_edge__edge10.isMatched = edge_cur_edge__edge10_prevIsMatched;
                                                            continue;
                                                        }
                                                        bool node_cur_node__node0_prevIsMatched = node_cur_node__node0.isMatched;
                                                        node_cur_node__node0.isMatched = true;
                                                        // Extend outgoing edge__edge11 from node_c 
                                                        LGSPEdge edge_head_edge__edge11 = node_cur_node_c.outhead;
                                                        if(edge_head_edge__edge11 != null)
                                                        {
                                                            LGSPEdge edge_cur_edge__edge11 = edge_head_edge__edge11;
                                                            do
                                                            {
                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge11.type.TypeID]) {
                                                                    continue;
                                                                }
                                                                if(edge_cur_edge__edge11.isMatched
                                                                    && (edge_cur_edge__edge11==edge_cur_edge__edge0
                                                                        || edge_cur_edge__edge11==edge_cur_edge__edge6
                                                                        || edge_cur_edge__edge11==edge_cur_edge__edge9
                                                                        || edge_cur_edge__edge11==edge_cur_edge__edge1
                                                                        || edge_cur_edge__edge11==edge_cur_edge__edge13
                                                                        || edge_cur_edge__edge11==edge_cur_edge__edge10
                                                                        )
                                                                    )
                                                                {
                                                                    continue;
                                                                }
                                                                bool edge_cur_edge__edge11_prevIsMatched = edge_cur_edge__edge11.isMatched;
                                                                edge_cur_edge__edge11.isMatched = true;
                                                                // Implicit target node__node1 from edge__edge11 
                                                                LGSPNode node_cur_node__node1 = edge_cur_edge__edge11.target;
                                                                if(!NodeType_H.isMyType[node_cur_node__node1.type.TypeID]) {
                                                                    edge_cur_edge__edge11.isMatched = edge_cur_edge__edge11_prevIsMatched;
                                                                    continue;
                                                                }
                                                                if(node_cur_node__node1.isMatched
                                                                    && node_cur_node__node1==node_cur_node__node0
                                                                    )
                                                                {
                                                                    edge_cur_edge__edge11.isMatched = edge_cur_edge__edge11_prevIsMatched;
                                                                    continue;
                                                                }
                                                                bool node_cur_node__node1_prevIsMatched = node_cur_node__node1.isMatched;
                                                                node_cur_node__node1.isMatched = true;
                                                                // Extend outgoing edge__edge12 from node_c 
                                                                LGSPEdge edge_head_edge__edge12 = node_cur_node_c.outhead;
                                                                if(edge_head_edge__edge12 != null)
                                                                {
                                                                    LGSPEdge edge_cur_edge__edge12 = edge_head_edge__edge12;
                                                                    do
                                                                    {
                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge12.type.TypeID]) {
                                                                            continue;
                                                                        }
                                                                        if(edge_cur_edge__edge12.isMatched
                                                                            && (edge_cur_edge__edge12==edge_cur_edge__edge0
                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge6
                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge9
                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge1
                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge13
                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge10
                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge11
                                                                                )
                                                                            )
                                                                        {
                                                                            continue;
                                                                        }
                                                                        bool edge_cur_edge__edge12_prevIsMatched = edge_cur_edge__edge12.isMatched;
                                                                        edge_cur_edge__edge12.isMatched = true;
                                                                        // Implicit target node__node2 from edge__edge12 
                                                                        LGSPNode node_cur_node__node2 = edge_cur_edge__edge12.target;
                                                                        if(!NodeType_H.isMyType[node_cur_node__node2.type.TypeID]) {
                                                                            edge_cur_edge__edge12.isMatched = edge_cur_edge__edge12_prevIsMatched;
                                                                            continue;
                                                                        }
                                                                        if(node_cur_node__node2.isMatched
                                                                            && (node_cur_node__node2==node_cur_node__node0
                                                                                || node_cur_node__node2==node_cur_node__node1
                                                                                )
                                                                            )
                                                                        {
                                                                            edge_cur_edge__edge12.isMatched = edge_cur_edge__edge12_prevIsMatched;
                                                                            continue;
                                                                        }
                                                                        bool node_cur_node__node2_prevIsMatched = node_cur_node__node2.isMatched;
                                                                        node_cur_node__node2.isMatched = true;
                                                                        // Extend outgoing edge__edge2 from node_c3 
                                                                        LGSPEdge edge_head_edge__edge2 = node_cur_node_c3.outhead;
                                                                        if(edge_head_edge__edge2 != null)
                                                                        {
                                                                            LGSPEdge edge_cur_edge__edge2 = edge_head_edge__edge2;
                                                                            do
                                                                            {
                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge2.type.TypeID]) {
                                                                                    continue;
                                                                                }
                                                                                if(edge_cur_edge__edge2.isMatched
                                                                                    && (edge_cur_edge__edge2==edge_cur_edge__edge0
                                                                                        || edge_cur_edge__edge2==edge_cur_edge__edge6
                                                                                        || edge_cur_edge__edge2==edge_cur_edge__edge9
                                                                                        || edge_cur_edge__edge2==edge_cur_edge__edge1
                                                                                        || edge_cur_edge__edge2==edge_cur_edge__edge13
                                                                                        || edge_cur_edge__edge2==edge_cur_edge__edge10
                                                                                        || edge_cur_edge__edge2==edge_cur_edge__edge11
                                                                                        || edge_cur_edge__edge2==edge_cur_edge__edge12
                                                                                        )
                                                                                    )
                                                                                {
                                                                                    continue;
                                                                                }
                                                                                bool edge_cur_edge__edge2_prevIsMatched = edge_cur_edge__edge2.isMatched;
                                                                                edge_cur_edge__edge2.isMatched = true;
                                                                                // Implicit target node_c4 from edge__edge2 
                                                                                LGSPNode node_cur_node_c4 = edge_cur_edge__edge2.target;
                                                                                if(!NodeType_C.isMyType[node_cur_node_c4.type.TypeID]) {
                                                                                    edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                                                                    continue;
                                                                                }
                                                                                if(node_cur_node_c4.isMatched
                                                                                    && (node_cur_node_c4==node_cur_node_c1
                                                                                        || node_cur_node_c4==node_cur_node_c2
                                                                                        || node_cur_node_c4==node_cur_node_c
                                                                                        || node_cur_node_c4==node_cur_node_c3
                                                                                        )
                                                                                    )
                                                                                {
                                                                                    edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                                                                    continue;
                                                                                }
                                                                                bool node_cur_node_c4_prevIsMatched = node_cur_node_c4.isMatched;
                                                                                node_cur_node_c4.isMatched = true;
                                                                                // Extend outgoing edge__edge7 from node_c3 
                                                                                LGSPEdge edge_head_edge__edge7 = node_cur_node_c3.outhead;
                                                                                if(edge_head_edge__edge7 != null)
                                                                                {
                                                                                    LGSPEdge edge_cur_edge__edge7 = edge_head_edge__edge7;
                                                                                    do
                                                                                    {
                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge7.type.TypeID]) {
                                                                                            continue;
                                                                                        }
                                                                                        if(edge_cur_edge__edge7.target != node_cur_node_c4) {
                                                                                            continue;
                                                                                        }
                                                                                        if(edge_cur_edge__edge7.isMatched
                                                                                            && (edge_cur_edge__edge7==edge_cur_edge__edge0
                                                                                                || edge_cur_edge__edge7==edge_cur_edge__edge6
                                                                                                || edge_cur_edge__edge7==edge_cur_edge__edge9
                                                                                                || edge_cur_edge__edge7==edge_cur_edge__edge1
                                                                                                || edge_cur_edge__edge7==edge_cur_edge__edge13
                                                                                                || edge_cur_edge__edge7==edge_cur_edge__edge10
                                                                                                || edge_cur_edge__edge7==edge_cur_edge__edge11
                                                                                                || edge_cur_edge__edge7==edge_cur_edge__edge12
                                                                                                || edge_cur_edge__edge7==edge_cur_edge__edge2
                                                                                                )
                                                                                            )
                                                                                        {
                                                                                            continue;
                                                                                        }
                                                                                        bool edge_cur_edge__edge7_prevIsMatched = edge_cur_edge__edge7.isMatched;
                                                                                        edge_cur_edge__edge7.isMatched = true;
                                                                                        // Extend outgoing edge__edge16 from node_c3 
                                                                                        LGSPEdge edge_head_edge__edge16 = node_cur_node_c3.outhead;
                                                                                        if(edge_head_edge__edge16 != null)
                                                                                        {
                                                                                            LGSPEdge edge_cur_edge__edge16 = edge_head_edge__edge16;
                                                                                            do
                                                                                            {
                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge16.type.TypeID]) {
                                                                                                    continue;
                                                                                                }
                                                                                                if(edge_cur_edge__edge16.isMatched
                                                                                                    && (edge_cur_edge__edge16==edge_cur_edge__edge0
                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge6
                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge9
                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge1
                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge13
                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge10
                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge11
                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge12
                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge2
                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge7
                                                                                                        )
                                                                                                    )
                                                                                                {
                                                                                                    continue;
                                                                                                }
                                                                                                bool edge_cur_edge__edge16_prevIsMatched = edge_cur_edge__edge16.isMatched;
                                                                                                edge_cur_edge__edge16.isMatched = true;
                                                                                                // Implicit target node__node5 from edge__edge16 
                                                                                                LGSPNode node_cur_node__node5 = edge_cur_edge__edge16.target;
                                                                                                if(!NodeType_H.isMyType[node_cur_node__node5.type.TypeID]) {
                                                                                                    edge_cur_edge__edge16.isMatched = edge_cur_edge__edge16_prevIsMatched;
                                                                                                    continue;
                                                                                                }
                                                                                                if(node_cur_node__node5.isMatched
                                                                                                    && (node_cur_node__node5==node_cur_node__node0
                                                                                                        || node_cur_node__node5==node_cur_node__node1
                                                                                                        || node_cur_node__node5==node_cur_node__node2
                                                                                                        )
                                                                                                    )
                                                                                                {
                                                                                                    edge_cur_edge__edge16.isMatched = edge_cur_edge__edge16_prevIsMatched;
                                                                                                    continue;
                                                                                                }
                                                                                                bool node_cur_node__node5_prevIsMatched = node_cur_node__node5.isMatched;
                                                                                                node_cur_node__node5.isMatched = true;
                                                                                                // Extend outgoing edge__edge14 from node_n2 
                                                                                                LGSPEdge edge_head_edge__edge14 = node_cur_node_n2.outhead;
                                                                                                if(edge_head_edge__edge14 != null)
                                                                                                {
                                                                                                    LGSPEdge edge_cur_edge__edge14 = edge_head_edge__edge14;
                                                                                                    do
                                                                                                    {
                                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge14.type.TypeID]) {
                                                                                                            continue;
                                                                                                        }
                                                                                                        if(edge_cur_edge__edge14.isMatched
                                                                                                            && (edge_cur_edge__edge14==edge_cur_edge__edge0
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge6
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge9
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge1
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge13
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge10
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge11
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge12
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge2
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge7
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge16
                                                                                                                )
                                                                                                            )
                                                                                                        {
                                                                                                            continue;
                                                                                                        }
                                                                                                        bool edge_cur_edge__edge14_prevIsMatched = edge_cur_edge__edge14.isMatched;
                                                                                                        edge_cur_edge__edge14.isMatched = true;
                                                                                                        // Implicit target node__node3 from edge__edge14 
                                                                                                        LGSPNode node_cur_node__node3 = edge_cur_edge__edge14.target;
                                                                                                        if(!NodeType_O.isMyType[node_cur_node__node3.type.TypeID]) {
                                                                                                            edge_cur_edge__edge14.isMatched = edge_cur_edge__edge14_prevIsMatched;
                                                                                                            continue;
                                                                                                        }
                                                                                                        bool node_cur_node__node3_prevIsMatched = node_cur_node__node3.isMatched;
                                                                                                        node_cur_node__node3.isMatched = true;
                                                                                                        // Extend outgoing edge__edge15 from node_n2 
                                                                                                        LGSPEdge edge_head_edge__edge15 = node_cur_node_n2.outhead;
                                                                                                        if(edge_head_edge__edge15 != null)
                                                                                                        {
                                                                                                            LGSPEdge edge_cur_edge__edge15 = edge_head_edge__edge15;
                                                                                                            do
                                                                                                            {
                                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge15.type.TypeID]) {
                                                                                                                    continue;
                                                                                                                }
                                                                                                                if(edge_cur_edge__edge15.isMatched
                                                                                                                    && (edge_cur_edge__edge15==edge_cur_edge__edge0
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge6
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge9
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge1
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge13
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge10
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge11
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge12
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge2
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge7
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge16
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge14
                                                                                                                        )
                                                                                                                    )
                                                                                                                {
                                                                                                                    continue;
                                                                                                                }
                                                                                                                bool edge_cur_edge__edge15_prevIsMatched = edge_cur_edge__edge15.isMatched;
                                                                                                                edge_cur_edge__edge15.isMatched = true;
                                                                                                                // Implicit target node__node4 from edge__edge15 
                                                                                                                LGSPNode node_cur_node__node4 = edge_cur_edge__edge15.target;
                                                                                                                if(!NodeType_O.isMyType[node_cur_node__node4.type.TypeID]) {
                                                                                                                    edge_cur_edge__edge15.isMatched = edge_cur_edge__edge15_prevIsMatched;
                                                                                                                    continue;
                                                                                                                }
                                                                                                                if(node_cur_node__node4.isMatched
                                                                                                                    && node_cur_node__node4==node_cur_node__node3
                                                                                                                    )
                                                                                                                {
                                                                                                                    edge_cur_edge__edge15.isMatched = edge_cur_edge__edge15_prevIsMatched;
                                                                                                                    continue;
                                                                                                                }
                                                                                                                bool node_cur_node__node4_prevIsMatched = node_cur_node__node4.isMatched;
                                                                                                                node_cur_node__node4.isMatched = true;
                                                                                                                // Extend outgoing edge__edge3 from node_c4 
                                                                                                                LGSPEdge edge_head_edge__edge3 = node_cur_node_c4.outhead;
                                                                                                                if(edge_head_edge__edge3 != null)
                                                                                                                {
                                                                                                                    LGSPEdge edge_cur_edge__edge3 = edge_head_edge__edge3;
                                                                                                                    do
                                                                                                                    {
                                                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge3.type.TypeID]) {
                                                                                                                            continue;
                                                                                                                        }
                                                                                                                        if(edge_cur_edge__edge3.isMatched
                                                                                                                            && (edge_cur_edge__edge3==edge_cur_edge__edge0
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge6
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge9
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge1
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge13
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge10
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge11
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge12
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge2
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge7
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge16
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge14
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge15
                                                                                                                                )
                                                                                                                            )
                                                                                                                        {
                                                                                                                            continue;
                                                                                                                        }
                                                                                                                        bool edge_cur_edge__edge3_prevIsMatched = edge_cur_edge__edge3.isMatched;
                                                                                                                        edge_cur_edge__edge3.isMatched = true;
                                                                                                                        // Implicit target node_c5 from edge__edge3 
                                                                                                                        LGSPNode node_cur_node_c5 = edge_cur_edge__edge3.target;
                                                                                                                        if(!NodeType_C.isMyType[node_cur_node_c5.type.TypeID]) {
                                                                                                                            edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                                                                                            continue;
                                                                                                                        }
                                                                                                                        if(node_cur_node_c5.isMatched
                                                                                                                            && (node_cur_node_c5==node_cur_node_c1
                                                                                                                                || node_cur_node_c5==node_cur_node_c2
                                                                                                                                || node_cur_node_c5==node_cur_node_c
                                                                                                                                || node_cur_node_c5==node_cur_node_c3
                                                                                                                                || node_cur_node_c5==node_cur_node_c4
                                                                                                                                )
                                                                                                                            )
                                                                                                                        {
                                                                                                                            edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                                                                                            continue;
                                                                                                                        }
                                                                                                                        bool node_cur_node_c5_prevIsMatched = node_cur_node_c5.isMatched;
                                                                                                                        node_cur_node_c5.isMatched = true;
                                                                                                                        // Extend outgoing edge__edge17 from node_c4 
                                                                                                                        LGSPEdge edge_head_edge__edge17 = node_cur_node_c4.outhead;
                                                                                                                        if(edge_head_edge__edge17 != null)
                                                                                                                        {
                                                                                                                            LGSPEdge edge_cur_edge__edge17 = edge_head_edge__edge17;
                                                                                                                            do
                                                                                                                            {
                                                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge17.type.TypeID]) {
                                                                                                                                    continue;
                                                                                                                                }
                                                                                                                                if(edge_cur_edge__edge17.isMatched
                                                                                                                                    && (edge_cur_edge__edge17==edge_cur_edge__edge0
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge6
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge9
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge1
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge13
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge10
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge11
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge12
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge2
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge7
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge16
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge14
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge15
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge3
                                                                                                                                        )
                                                                                                                                    )
                                                                                                                                {
                                                                                                                                    continue;
                                                                                                                                }
                                                                                                                                bool edge_cur_edge__edge17_prevIsMatched = edge_cur_edge__edge17.isMatched;
                                                                                                                                edge_cur_edge__edge17.isMatched = true;
                                                                                                                                // Implicit target node_n4 from edge__edge17 
                                                                                                                                LGSPNode node_cur_node_n4 = edge_cur_edge__edge17.target;
                                                                                                                                if(!NodeType_N.isMyType[node_cur_node_n4.type.TypeID]) {
                                                                                                                                    edge_cur_edge__edge17.isMatched = edge_cur_edge__edge17_prevIsMatched;
                                                                                                                                    continue;
                                                                                                                                }
                                                                                                                                if(node_cur_node_n4.isMatched
                                                                                                                                    && node_cur_node_n4==node_cur_node_n2
                                                                                                                                    )
                                                                                                                                {
                                                                                                                                    edge_cur_edge__edge17.isMatched = edge_cur_edge__edge17_prevIsMatched;
                                                                                                                                    continue;
                                                                                                                                }
                                                                                                                                // Extend outgoing edge__edge4 from node_c5 
                                                                                                                                LGSPEdge edge_head_edge__edge4 = node_cur_node_c5.outhead;
                                                                                                                                if(edge_head_edge__edge4 != null)
                                                                                                                                {
                                                                                                                                    LGSPEdge edge_cur_edge__edge4 = edge_head_edge__edge4;
                                                                                                                                    do
                                                                                                                                    {
                                                                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge4.type.TypeID]) {
                                                                                                                                            continue;
                                                                                                                                        }
                                                                                                                                        if(edge_cur_edge__edge4.isMatched
                                                                                                                                            && (edge_cur_edge__edge4==edge_cur_edge__edge0
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge6
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge9
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge1
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge13
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge10
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge11
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge12
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge2
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge7
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge16
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge14
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge15
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge3
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge17
                                                                                                                                                )
                                                                                                                                            )
                                                                                                                                        {
                                                                                                                                            continue;
                                                                                                                                        }
                                                                                                                                        bool edge_cur_edge__edge4_prevIsMatched = edge_cur_edge__edge4.isMatched;
                                                                                                                                        edge_cur_edge__edge4.isMatched = true;
                                                                                                                                        // Implicit target node_c6 from edge__edge4 
                                                                                                                                        LGSPNode node_cur_node_c6 = edge_cur_edge__edge4.target;
                                                                                                                                        if(!NodeType_C.isMyType[node_cur_node_c6.type.TypeID]) {
                                                                                                                                            edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                                                                                            continue;
                                                                                                                                        }
                                                                                                                                        if(node_cur_node_c6.isMatched
                                                                                                                                            && (node_cur_node_c6==node_cur_node_c1
                                                                                                                                                || node_cur_node_c6==node_cur_node_c2
                                                                                                                                                || node_cur_node_c6==node_cur_node_c
                                                                                                                                                || node_cur_node_c6==node_cur_node_c3
                                                                                                                                                || node_cur_node_c6==node_cur_node_c4
                                                                                                                                                || node_cur_node_c6==node_cur_node_c5
                                                                                                                                                )
                                                                                                                                            )
                                                                                                                                        {
                                                                                                                                            edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                                                                                            continue;
                                                                                                                                        }
                                                                                                                                        // Extend outgoing edge__edge8 from node_c5 
                                                                                                                                        LGSPEdge edge_head_edge__edge8 = node_cur_node_c5.outhead;
                                                                                                                                        if(edge_head_edge__edge8 != null)
                                                                                                                                        {
                                                                                                                                            LGSPEdge edge_cur_edge__edge8 = edge_head_edge__edge8;
                                                                                                                                            do
                                                                                                                                            {
                                                                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge8.type.TypeID]) {
                                                                                                                                                    continue;
                                                                                                                                                }
                                                                                                                                                if(edge_cur_edge__edge8.target != node_cur_node_c6) {
                                                                                                                                                    continue;
                                                                                                                                                }
                                                                                                                                                if(edge_cur_edge__edge8.isMatched
                                                                                                                                                    && (edge_cur_edge__edge8==edge_cur_edge__edge0
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge6
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge9
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge1
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge13
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge10
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge11
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge12
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge2
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge7
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge16
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge14
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge15
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge3
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge17
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge4
                                                                                                                                                        )
                                                                                                                                                    )
                                                                                                                                                {
                                                                                                                                                    continue;
                                                                                                                                                }
                                                                                                                                                bool edge_cur_edge__edge8_prevIsMatched = edge_cur_edge__edge8.isMatched;
                                                                                                                                                edge_cur_edge__edge8.isMatched = true;
                                                                                                                                                // Extend outgoing edge__edge20 from node_c5 
                                                                                                                                                LGSPEdge edge_head_edge__edge20 = node_cur_node_c5.outhead;
                                                                                                                                                if(edge_head_edge__edge20 != null)
                                                                                                                                                {
                                                                                                                                                    LGSPEdge edge_cur_edge__edge20 = edge_head_edge__edge20;
                                                                                                                                                    do
                                                                                                                                                    {
                                                                                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge20.type.TypeID]) {
                                                                                                                                                            continue;
                                                                                                                                                        }
                                                                                                                                                        if(edge_cur_edge__edge20.isMatched
                                                                                                                                                            && (edge_cur_edge__edge20==edge_cur_edge__edge0
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge6
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge9
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge1
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge13
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge10
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge11
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge12
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge2
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge7
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge16
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge14
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge15
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge3
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge17
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge4
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge8
                                                                                                                                                                )
                                                                                                                                                            )
                                                                                                                                                        {
                                                                                                                                                            continue;
                                                                                                                                                        }
                                                                                                                                                        bool edge_cur_edge__edge20_prevIsMatched = edge_cur_edge__edge20.isMatched;
                                                                                                                                                        edge_cur_edge__edge20.isMatched = true;
                                                                                                                                                        // Implicit target node__node8 from edge__edge20 
                                                                                                                                                        LGSPNode node_cur_node__node8 = edge_cur_edge__edge20.target;
                                                                                                                                                        if(!NodeType_H.isMyType[node_cur_node__node8.type.TypeID]) {
                                                                                                                                                            edge_cur_edge__edge20.isMatched = edge_cur_edge__edge20_prevIsMatched;
                                                                                                                                                            continue;
                                                                                                                                                        }
                                                                                                                                                        if(node_cur_node__node8.isMatched
                                                                                                                                                            && (node_cur_node__node8==node_cur_node__node0
                                                                                                                                                                || node_cur_node__node8==node_cur_node__node1
                                                                                                                                                                || node_cur_node__node8==node_cur_node__node2
                                                                                                                                                                || node_cur_node__node8==node_cur_node__node5
                                                                                                                                                                )
                                                                                                                                                            )
                                                                                                                                                        {
                                                                                                                                                            edge_cur_edge__edge20.isMatched = edge_cur_edge__edge20_prevIsMatched;
                                                                                                                                                            continue;
                                                                                                                                                        }
                                                                                                                                                        bool node_cur_node__node8_prevIsMatched = node_cur_node__node8.isMatched;
                                                                                                                                                        node_cur_node__node8.isMatched = true;
                                                                                                                                                        // Extend outgoing edge__edge18 from node_n4 
                                                                                                                                                        LGSPEdge edge_head_edge__edge18 = node_cur_node_n4.outhead;
                                                                                                                                                        if(edge_head_edge__edge18 != null)
                                                                                                                                                        {
                                                                                                                                                            LGSPEdge edge_cur_edge__edge18 = edge_head_edge__edge18;
                                                                                                                                                            do
                                                                                                                                                            {
                                                                                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge18.type.TypeID]) {
                                                                                                                                                                    continue;
                                                                                                                                                                }
                                                                                                                                                                if(edge_cur_edge__edge18.isMatched
                                                                                                                                                                    && (edge_cur_edge__edge18==edge_cur_edge__edge0
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge6
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge9
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge1
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge13
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge10
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge11
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge12
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge2
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge7
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge16
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge14
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge15
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge3
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge17
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge4
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge8
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge20
                                                                                                                                                                        )
                                                                                                                                                                    )
                                                                                                                                                                {
                                                                                                                                                                    continue;
                                                                                                                                                                }
                                                                                                                                                                bool edge_cur_edge__edge18_prevIsMatched = edge_cur_edge__edge18.isMatched;
                                                                                                                                                                edge_cur_edge__edge18.isMatched = true;
                                                                                                                                                                // Implicit target node__node6 from edge__edge18 
                                                                                                                                                                LGSPNode node_cur_node__node6 = edge_cur_edge__edge18.target;
                                                                                                                                                                if(!NodeType_O.isMyType[node_cur_node__node6.type.TypeID]) {
                                                                                                                                                                    edge_cur_edge__edge18.isMatched = edge_cur_edge__edge18_prevIsMatched;
                                                                                                                                                                    continue;
                                                                                                                                                                }
                                                                                                                                                                if(node_cur_node__node6.isMatched
                                                                                                                                                                    && (node_cur_node__node6==node_cur_node__node3
                                                                                                                                                                        || node_cur_node__node6==node_cur_node__node4
                                                                                                                                                                        )
                                                                                                                                                                    )
                                                                                                                                                                {
                                                                                                                                                                    edge_cur_edge__edge18.isMatched = edge_cur_edge__edge18_prevIsMatched;
                                                                                                                                                                    continue;
                                                                                                                                                                }
                                                                                                                                                                bool node_cur_node__node6_prevIsMatched = node_cur_node__node6.isMatched;
                                                                                                                                                                node_cur_node__node6.isMatched = true;
                                                                                                                                                                // Extend outgoing edge__edge19 from node_n4 
                                                                                                                                                                LGSPEdge edge_head_edge__edge19 = node_cur_node_n4.outhead;
                                                                                                                                                                if(edge_head_edge__edge19 != null)
                                                                                                                                                                {
                                                                                                                                                                    LGSPEdge edge_cur_edge__edge19 = edge_head_edge__edge19;
                                                                                                                                                                    do
                                                                                                                                                                    {
                                                                                                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge19.type.TypeID]) {
                                                                                                                                                                            continue;
                                                                                                                                                                        }
                                                                                                                                                                        if(edge_cur_edge__edge19.isMatched
                                                                                                                                                                            && (edge_cur_edge__edge19==edge_cur_edge__edge0
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge6
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge9
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge1
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge13
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge10
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge11
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge12
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge2
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge7
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge16
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge14
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge15
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge3
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge17
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge4
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge8
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge20
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge18
                                                                                                                                                                                )
                                                                                                                                                                            )
                                                                                                                                                                        {
                                                                                                                                                                            continue;
                                                                                                                                                                        }
                                                                                                                                                                        bool edge_cur_edge__edge19_prevIsMatched = edge_cur_edge__edge19.isMatched;
                                                                                                                                                                        edge_cur_edge__edge19.isMatched = true;
                                                                                                                                                                        // Implicit target node__node7 from edge__edge19 
                                                                                                                                                                        LGSPNode node_cur_node__node7 = edge_cur_edge__edge19.target;
                                                                                                                                                                        if(!NodeType_O.isMyType[node_cur_node__node7.type.TypeID]) {
                                                                                                                                                                            edge_cur_edge__edge19.isMatched = edge_cur_edge__edge19_prevIsMatched;
                                                                                                                                                                            continue;
                                                                                                                                                                        }
                                                                                                                                                                        if(node_cur_node__node7.isMatched
                                                                                                                                                                            && (node_cur_node__node7==node_cur_node__node3
                                                                                                                                                                                || node_cur_node__node7==node_cur_node__node4
                                                                                                                                                                                || node_cur_node__node7==node_cur_node__node6
                                                                                                                                                                                )
                                                                                                                                                                            )
                                                                                                                                                                        {
                                                                                                                                                                            edge_cur_edge__edge19.isMatched = edge_cur_edge__edge19_prevIsMatched;
                                                                                                                                                                            continue;
                                                                                                                                                                        }
                                                                                                                                                                        // Extend outgoing edge__edge5 from node_c6 
                                                                                                                                                                        LGSPEdge edge_head_edge__edge5 = node_cur_node_c6.outhead;
                                                                                                                                                                        if(edge_head_edge__edge5 != null)
                                                                                                                                                                        {
                                                                                                                                                                            LGSPEdge edge_cur_edge__edge5 = edge_head_edge__edge5;
                                                                                                                                                                            do
                                                                                                                                                                            {
                                                                                                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge5.type.TypeID]) {
                                                                                                                                                                                    continue;
                                                                                                                                                                                }
                                                                                                                                                                                if(edge_cur_edge__edge5.target != node_cur_node_c1) {
                                                                                                                                                                                    continue;
                                                                                                                                                                                }
                                                                                                                                                                                if(edge_cur_edge__edge5.isMatched
                                                                                                                                                                                    && (edge_cur_edge__edge5==edge_cur_edge__edge0
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge6
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge9
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge1
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge13
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge10
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge11
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge12
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge2
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge7
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge16
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge14
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge15
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge3
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge17
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge4
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge8
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge20
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge18
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge19
                                                                                                                                                                                        )
                                                                                                                                                                                    )
                                                                                                                                                                                {
                                                                                                                                                                                    continue;
                                                                                                                                                                                }
                                                                                                                                                                                bool edge_cur_edge__edge5_prevIsMatched = edge_cur_edge__edge5.isMatched;
                                                                                                                                                                                edge_cur_edge__edge5.isMatched = true;
                                                                                                                                                                                // Extend outgoing edge__edge21 from node_c6 
                                                                                                                                                                                LGSPEdge edge_head_edge__edge21 = node_cur_node_c6.outhead;
                                                                                                                                                                                if(edge_head_edge__edge21 != null)
                                                                                                                                                                                {
                                                                                                                                                                                    LGSPEdge edge_cur_edge__edge21 = edge_head_edge__edge21;
                                                                                                                                                                                    do
                                                                                                                                                                                    {
                                                                                                                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge21.type.TypeID]) {
                                                                                                                                                                                            continue;
                                                                                                                                                                                        }
                                                                                                                                                                                        if(edge_cur_edge__edge21.isMatched
                                                                                                                                                                                            && (edge_cur_edge__edge21==edge_cur_edge__edge0
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge6
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge9
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge1
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge13
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge10
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge11
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge12
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge2
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge7
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge16
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge14
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge15
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge3
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge17
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge4
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge8
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge20
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge18
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge19
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge5
                                                                                                                                                                                                )
                                                                                                                                                                                            )
                                                                                                                                                                                        {
                                                                                                                                                                                            continue;
                                                                                                                                                                                        }
                                                                                                                                                                                        // Implicit target node__node9 from edge__edge21 
                                                                                                                                                                                        LGSPNode node_cur_node__node9 = edge_cur_edge__edge21.target;
                                                                                                                                                                                        if(!NodeType_H.isMyType[node_cur_node__node9.type.TypeID]) {
                                                                                                                                                                                            continue;
                                                                                                                                                                                        }
                                                                                                                                                                                        if(node_cur_node__node9.isMatched
                                                                                                                                                                                            && (node_cur_node__node9==node_cur_node__node0
                                                                                                                                                                                                || node_cur_node__node9==node_cur_node__node1
                                                                                                                                                                                                || node_cur_node__node9==node_cur_node__node2
                                                                                                                                                                                                || node_cur_node__node9==node_cur_node__node5
                                                                                                                                                                                                || node_cur_node__node9==node_cur_node__node8
                                                                                                                                                                                                )
                                                                                                                                                                                            )
                                                                                                                                                                                        {
                                                                                                                                                                                            continue;
                                                                                                                                                                                        }
                                                                                                                                                                                        LGSPMatch match = matches.matchesList.GetEmptyMatchFromList();
                                                                                                                                                                                        match.patternGraph = rulePattern.patternGraph;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@c1] = node_cur_node_c1;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@c2] = node_cur_node_c2;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@c3] = node_cur_node_c3;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@c4] = node_cur_node_c4;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@c5] = node_cur_node_c5;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@c6] = node_cur_node_c6;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@c] = node_cur_node_c;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@_node0] = node_cur_node__node0;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@_node1] = node_cur_node__node1;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@_node2] = node_cur_node__node2;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@n2] = node_cur_node_n2;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@_node3] = node_cur_node__node3;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@_node4] = node_cur_node__node4;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@_node5] = node_cur_node__node5;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@n4] = node_cur_node_n4;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@_node6] = node_cur_node__node6;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@_node7] = node_cur_node__node7;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@_node8] = node_cur_node__node8;
                                                                                                                                                                                        match.Nodes[(int)Rule_DNTUnfolded.NodeNums.@_node9] = node_cur_node__node9;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge0] = edge_cur_edge__edge0;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge1] = edge_cur_edge__edge1;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge2] = edge_cur_edge__edge2;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge3] = edge_cur_edge__edge3;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge4] = edge_cur_edge__edge4;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge5] = edge_cur_edge__edge5;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge6] = edge_cur_edge__edge6;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge7] = edge_cur_edge__edge7;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge8] = edge_cur_edge__edge8;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge9] = edge_cur_edge__edge9;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge10] = edge_cur_edge__edge10;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge11] = edge_cur_edge__edge11;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge12] = edge_cur_edge__edge12;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge13] = edge_cur_edge__edge13;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge14] = edge_cur_edge__edge14;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge15] = edge_cur_edge__edge15;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge16] = edge_cur_edge__edge16;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge17] = edge_cur_edge__edge17;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge18] = edge_cur_edge__edge18;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge19] = edge_cur_edge__edge19;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge20] = edge_cur_edge__edge20;
                                                                                                                                                                                        match.Edges[(int)Rule_DNTUnfolded.EdgeNums.@_edge21] = edge_cur_edge__edge21;
                                                                                                                                                                                        matches.matchesList.EmptyMatchWasFilledFixIt();
                                                                                                                                                                                        // if enough matches were found, we leave
                                                                                                                                                                                        if(maxMatches > 0 && matches.matchesList.Count >= maxMatches)
                                                                                                                                                                                        {
                                                                                                                                                                                            node_cur_node_c6.MoveOutHeadAfter(edge_cur_edge__edge21);
                                                                                                                                                                                            node_cur_node_c6.MoveOutHeadAfter(edge_cur_edge__edge5);
                                                                                                                                                                                            node_cur_node_n4.MoveOutHeadAfter(edge_cur_edge__edge19);
                                                                                                                                                                                            node_cur_node_n4.MoveOutHeadAfter(edge_cur_edge__edge18);
                                                                                                                                                                                            node_cur_node_c5.MoveOutHeadAfter(edge_cur_edge__edge20);
                                                                                                                                                                                            node_cur_node_c5.MoveOutHeadAfter(edge_cur_edge__edge8);
                                                                                                                                                                                            node_cur_node_c5.MoveOutHeadAfter(edge_cur_edge__edge4);
                                                                                                                                                                                            node_cur_node_c4.MoveOutHeadAfter(edge_cur_edge__edge17);
                                                                                                                                                                                            node_cur_node_c4.MoveOutHeadAfter(edge_cur_edge__edge3);
                                                                                                                                                                                            node_cur_node_n2.MoveOutHeadAfter(edge_cur_edge__edge15);
                                                                                                                                                                                            node_cur_node_n2.MoveOutHeadAfter(edge_cur_edge__edge14);
                                                                                                                                                                                            node_cur_node_c3.MoveOutHeadAfter(edge_cur_edge__edge16);
                                                                                                                                                                                            node_cur_node_c3.MoveOutHeadAfter(edge_cur_edge__edge7);
                                                                                                                                                                                            node_cur_node_c3.MoveOutHeadAfter(edge_cur_edge__edge2);
                                                                                                                                                                                            node_cur_node_c.MoveOutHeadAfter(edge_cur_edge__edge12);
                                                                                                                                                                                            node_cur_node_c.MoveOutHeadAfter(edge_cur_edge__edge11);
                                                                                                                                                                                            node_cur_node_c.MoveOutHeadAfter(edge_cur_edge__edge10);
                                                                                                                                                                                            node_cur_node_c2.MoveOutHeadAfter(edge_cur_edge__edge13);
                                                                                                                                                                                            node_cur_node_c2.MoveOutHeadAfter(edge_cur_edge__edge1);
                                                                                                                                                                                            node_cur_node_c1.MoveOutHeadAfter(edge_cur_edge__edge9);
                                                                                                                                                                                            node_cur_node_c1.MoveOutHeadAfter(edge_cur_edge__edge6);
                                                                                                                                                                                            graph.MoveHeadAfter(edge_cur_edge__edge0);
                                                                                                                                                                                            edge_cur_edge__edge5.isMatched = edge_cur_edge__edge5_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge19.isMatched = edge_cur_edge__edge19_prevIsMatched;
                                                                                                                                                                                            node_cur_node__node6.isMatched = node_cur_node__node6_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge18.isMatched = edge_cur_edge__edge18_prevIsMatched;
                                                                                                                                                                                            node_cur_node__node8.isMatched = node_cur_node__node8_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge20.isMatched = edge_cur_edge__edge20_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge8.isMatched = edge_cur_edge__edge8_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge17.isMatched = edge_cur_edge__edge17_prevIsMatched;
                                                                                                                                                                                            node_cur_node_c5.isMatched = node_cur_node_c5_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                                                                                                                                                            node_cur_node__node4.isMatched = node_cur_node__node4_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge15.isMatched = edge_cur_edge__edge15_prevIsMatched;
                                                                                                                                                                                            node_cur_node__node3.isMatched = node_cur_node__node3_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge14.isMatched = edge_cur_edge__edge14_prevIsMatched;
                                                                                                                                                                                            node_cur_node__node5.isMatched = node_cur_node__node5_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge16.isMatched = edge_cur_edge__edge16_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge7.isMatched = edge_cur_edge__edge7_prevIsMatched;
                                                                                                                                                                                            node_cur_node_c4.isMatched = node_cur_node_c4_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                                                                                                                                                                            node_cur_node__node2.isMatched = node_cur_node__node2_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge12.isMatched = edge_cur_edge__edge12_prevIsMatched;
                                                                                                                                                                                            node_cur_node__node1.isMatched = node_cur_node__node1_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge11.isMatched = edge_cur_edge__edge11_prevIsMatched;
                                                                                                                                                                                            node_cur_node__node0.isMatched = node_cur_node__node0_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge10.isMatched = edge_cur_edge__edge10_prevIsMatched;
                                                                                                                                                                                            node_cur_node_n2.isMatched = node_cur_node_n2_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge13.isMatched = edge_cur_edge__edge13_prevIsMatched;
                                                                                                                                                                                            node_cur_node_c3.isMatched = node_cur_node_c3_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                                                                                                                                                                            node_cur_node_c.isMatched = node_cur_node_c_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge9.isMatched = edge_cur_edge__edge9_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge6.isMatched = edge_cur_edge__edge6_prevIsMatched;
                                                                                                                                                                                            node_cur_node_c2.isMatched = node_cur_node_c2_prevIsMatched;
                                                                                                                                                                                            node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                                                                                                                                                                                            edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                                                                                                                                                                                            return matches;
                                                                                                                                                                                        }
                                                                                                                                                                                    }
                                                                                                                                                                                    while( (edge_cur_edge__edge21 = edge_cur_edge__edge21.outNext) != edge_head_edge__edge21 );
                                                                                                                                                                                }
                                                                                                                                                                                edge_cur_edge__edge5.isMatched = edge_cur_edge__edge5_prevIsMatched;
                                                                                                                                                                            }
                                                                                                                                                                            while( (edge_cur_edge__edge5 = edge_cur_edge__edge5.outNext) != edge_head_edge__edge5 );
                                                                                                                                                                        }
                                                                                                                                                                        edge_cur_edge__edge19.isMatched = edge_cur_edge__edge19_prevIsMatched;
                                                                                                                                                                    }
                                                                                                                                                                    while( (edge_cur_edge__edge19 = edge_cur_edge__edge19.outNext) != edge_head_edge__edge19 );
                                                                                                                                                                }
                                                                                                                                                                node_cur_node__node6.isMatched = node_cur_node__node6_prevIsMatched;
                                                                                                                                                                edge_cur_edge__edge18.isMatched = edge_cur_edge__edge18_prevIsMatched;
                                                                                                                                                            }
                                                                                                                                                            while( (edge_cur_edge__edge18 = edge_cur_edge__edge18.outNext) != edge_head_edge__edge18 );
                                                                                                                                                        }
                                                                                                                                                        node_cur_node__node8.isMatched = node_cur_node__node8_prevIsMatched;
                                                                                                                                                        edge_cur_edge__edge20.isMatched = edge_cur_edge__edge20_prevIsMatched;
                                                                                                                                                    }
                                                                                                                                                    while( (edge_cur_edge__edge20 = edge_cur_edge__edge20.outNext) != edge_head_edge__edge20 );
                                                                                                                                                }
                                                                                                                                                edge_cur_edge__edge8.isMatched = edge_cur_edge__edge8_prevIsMatched;
                                                                                                                                            }
                                                                                                                                            while( (edge_cur_edge__edge8 = edge_cur_edge__edge8.outNext) != edge_head_edge__edge8 );
                                                                                                                                        }
                                                                                                                                        edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                                                                                    }
                                                                                                                                    while( (edge_cur_edge__edge4 = edge_cur_edge__edge4.outNext) != edge_head_edge__edge4 );
                                                                                                                                }
                                                                                                                                edge_cur_edge__edge17.isMatched = edge_cur_edge__edge17_prevIsMatched;
                                                                                                                            }
                                                                                                                            while( (edge_cur_edge__edge17 = edge_cur_edge__edge17.outNext) != edge_head_edge__edge17 );
                                                                                                                        }
                                                                                                                        node_cur_node_c5.isMatched = node_cur_node_c5_prevIsMatched;
                                                                                                                        edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                                                                                    }
                                                                                                                    while( (edge_cur_edge__edge3 = edge_cur_edge__edge3.outNext) != edge_head_edge__edge3 );
                                                                                                                }
                                                                                                                node_cur_node__node4.isMatched = node_cur_node__node4_prevIsMatched;
                                                                                                                edge_cur_edge__edge15.isMatched = edge_cur_edge__edge15_prevIsMatched;
                                                                                                            }
                                                                                                            while( (edge_cur_edge__edge15 = edge_cur_edge__edge15.outNext) != edge_head_edge__edge15 );
                                                                                                        }
                                                                                                        node_cur_node__node3.isMatched = node_cur_node__node3_prevIsMatched;
                                                                                                        edge_cur_edge__edge14.isMatched = edge_cur_edge__edge14_prevIsMatched;
                                                                                                    }
                                                                                                    while( (edge_cur_edge__edge14 = edge_cur_edge__edge14.outNext) != edge_head_edge__edge14 );
                                                                                                }
                                                                                                node_cur_node__node5.isMatched = node_cur_node__node5_prevIsMatched;
                                                                                                edge_cur_edge__edge16.isMatched = edge_cur_edge__edge16_prevIsMatched;
                                                                                            }
                                                                                            while( (edge_cur_edge__edge16 = edge_cur_edge__edge16.outNext) != edge_head_edge__edge16 );
                                                                                        }
                                                                                        edge_cur_edge__edge7.isMatched = edge_cur_edge__edge7_prevIsMatched;
                                                                                    }
                                                                                    while( (edge_cur_edge__edge7 = edge_cur_edge__edge7.outNext) != edge_head_edge__edge7 );
                                                                                }
                                                                                node_cur_node_c4.isMatched = node_cur_node_c4_prevIsMatched;
                                                                                edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                                                            }
                                                                            while( (edge_cur_edge__edge2 = edge_cur_edge__edge2.outNext) != edge_head_edge__edge2 );
                                                                        }
                                                                        node_cur_node__node2.isMatched = node_cur_node__node2_prevIsMatched;
                                                                        edge_cur_edge__edge12.isMatched = edge_cur_edge__edge12_prevIsMatched;
                                                                    }
                                                                    while( (edge_cur_edge__edge12 = edge_cur_edge__edge12.outNext) != edge_head_edge__edge12 );
                                                                }
                                                                node_cur_node__node1.isMatched = node_cur_node__node1_prevIsMatched;
                                                                edge_cur_edge__edge11.isMatched = edge_cur_edge__edge11_prevIsMatched;
                                                            }
                                                            while( (edge_cur_edge__edge11 = edge_cur_edge__edge11.outNext) != edge_head_edge__edge11 );
                                                        }
                                                        node_cur_node__node0.isMatched = node_cur_node__node0_prevIsMatched;
                                                        edge_cur_edge__edge10.isMatched = edge_cur_edge__edge10_prevIsMatched;
                                                    }
                                                    while( (edge_cur_edge__edge10 = edge_cur_edge__edge10.outNext) != edge_head_edge__edge10 );
                                                }
                                                node_cur_node_n2.isMatched = node_cur_node_n2_prevIsMatched;
                                                edge_cur_edge__edge13.isMatched = edge_cur_edge__edge13_prevIsMatched;
                                            }
                                            while( (edge_cur_edge__edge13 = edge_cur_edge__edge13.outNext) != edge_head_edge__edge13 );
                                        }
                                        node_cur_node_c3.isMatched = node_cur_node_c3_prevIsMatched;
                                        edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                    }
                                    while( (edge_cur_edge__edge1 = edge_cur_edge__edge1.outNext) != edge_head_edge__edge1 );
                                }
                                node_cur_node_c.isMatched = node_cur_node_c_prevIsMatched;
                                edge_cur_edge__edge9.isMatched = edge_cur_edge__edge9_prevIsMatched;
                            }
                            while( (edge_cur_edge__edge9 = edge_cur_edge__edge9.outNext) != edge_head_edge__edge9 );
                        }
                        edge_cur_edge__edge6.isMatched = edge_cur_edge__edge6_prevIsMatched;
                    }
                    while( (edge_cur_edge__edge6 = edge_cur_edge__edge6.outNext) != edge_head_edge__edge6 );
                }
                node_cur_node_c2.isMatched = node_cur_node_c2_prevIsMatched;
                node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
            }
            return matches;
        }
	}
	public class Action_TNB : LGSPAction
	{
		public Action_TNB() {
			rulePattern = Rule_TNB.Instance;
			DynamicMatch = myMatch; matches = new LGSPMatches(this, 6, 9, 6);
		}

		public override string Name { get { return "TNB"; } }
		private LGSPMatches matches;

		public static LGSPAction Instance { get { return instance; } }
		private static Action_TNB instance = new Action_TNB();

        public LGSPMatches myMatch(LGSPGraph graph, int maxMatches, IGraphElement[] parameters)
        {
            matches.matchesList.Clear();
            Stack<LGSPSubpatternAction> openTasks = new Stack<LGSPSubpatternAction>();
            List<Stack<LGSPMatch>> foundPartialMatches = new List<Stack<LGSPMatch>>();
            List<Stack<LGSPMatch>> matchesList = foundPartialMatches;
            // Lookup edge__edge0 
            int edge_type_id_edge__edge0 = 2;
            for(LGSPEdge edge_head_edge__edge0 = graph.edgesByTypeHeads[edge_type_id_edge__edge0], edge_cur_edge__edge0 = edge_head_edge__edge0.typeNext; edge_cur_edge__edge0 != edge_head_edge__edge0; edge_cur_edge__edge0 = edge_cur_edge__edge0.typeNext)
            {
                bool edge_cur_edge__edge0_prevIsMatched = edge_cur_edge__edge0.isMatched;
                edge_cur_edge__edge0.isMatched = true;
                // Implicit source node_c1 from edge__edge0 
                LGSPNode node_cur_node_c1 = edge_cur_edge__edge0.source;
                if(!NodeType_C.isMyType[node_cur_node_c1.type.TypeID]) {
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                    continue;
                }
                bool node_cur_node_c1_prevIsMatched = node_cur_node_c1.isMatched;
                node_cur_node_c1.isMatched = true;
                // Implicit target node_c2 from edge__edge0 
                LGSPNode node_cur_node_c2 = edge_cur_edge__edge0.target;
                if(!NodeType_C.isMyType[node_cur_node_c2.type.TypeID]) {
                    node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                    continue;
                }
                if(node_cur_node_c2.isMatched
                    && node_cur_node_c2==node_cur_node_c1
                    )
                {
                    node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                    continue;
                }
                bool node_cur_node_c2_prevIsMatched = node_cur_node_c2.isMatched;
                node_cur_node_c2.isMatched = true;
                // Extend outgoing edge__edge6 from node_c1 
                LGSPEdge edge_head_edge__edge6 = node_cur_node_c1.outhead;
                if(edge_head_edge__edge6 != null)
                {
                    LGSPEdge edge_cur_edge__edge6 = edge_head_edge__edge6;
                    do
                    {
                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge6.type.TypeID]) {
                            continue;
                        }
                        if(edge_cur_edge__edge6.target != node_cur_node_c2) {
                            continue;
                        }
                        if(edge_cur_edge__edge6.isMatched
                            && edge_cur_edge__edge6==edge_cur_edge__edge0
                            )
                        {
                            continue;
                        }
                        bool edge_cur_edge__edge6_prevIsMatched = edge_cur_edge__edge6.isMatched;
                        edge_cur_edge__edge6.isMatched = true;
                        // Extend outgoing edge__edge1 from node_c2 
                        LGSPEdge edge_head_edge__edge1 = node_cur_node_c2.outhead;
                        if(edge_head_edge__edge1 != null)
                        {
                            LGSPEdge edge_cur_edge__edge1 = edge_head_edge__edge1;
                            do
                            {
                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge1.type.TypeID]) {
                                    continue;
                                }
                                if(edge_cur_edge__edge1.isMatched
                                    && (edge_cur_edge__edge1==edge_cur_edge__edge0
                                        || edge_cur_edge__edge1==edge_cur_edge__edge6
                                        )
                                    )
                                {
                                    continue;
                                }
                                bool edge_cur_edge__edge1_prevIsMatched = edge_cur_edge__edge1.isMatched;
                                edge_cur_edge__edge1.isMatched = true;
                                // Implicit target node_c3 from edge__edge1 
                                LGSPNode node_cur_node_c3 = edge_cur_edge__edge1.target;
                                if(!NodeType_C.isMyType[node_cur_node_c3.type.TypeID]) {
                                    edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                    continue;
                                }
                                if(node_cur_node_c3.isMatched
                                    && (node_cur_node_c3==node_cur_node_c1
                                        || node_cur_node_c3==node_cur_node_c2
                                        )
                                    )
                                {
                                    edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                    continue;
                                }
                                bool node_cur_node_c3_prevIsMatched = node_cur_node_c3.isMatched;
                                node_cur_node_c3.isMatched = true;
                                // Extend outgoing edge__edge2 from node_c3 
                                LGSPEdge edge_head_edge__edge2 = node_cur_node_c3.outhead;
                                if(edge_head_edge__edge2 != null)
                                {
                                    LGSPEdge edge_cur_edge__edge2 = edge_head_edge__edge2;
                                    do
                                    {
                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge2.type.TypeID]) {
                                            continue;
                                        }
                                        if(edge_cur_edge__edge2.isMatched
                                            && (edge_cur_edge__edge2==edge_cur_edge__edge0
                                                || edge_cur_edge__edge2==edge_cur_edge__edge6
                                                || edge_cur_edge__edge2==edge_cur_edge__edge1
                                                )
                                            )
                                        {
                                            continue;
                                        }
                                        bool edge_cur_edge__edge2_prevIsMatched = edge_cur_edge__edge2.isMatched;
                                        edge_cur_edge__edge2.isMatched = true;
                                        // Implicit target node_c4 from edge__edge2 
                                        LGSPNode node_cur_node_c4 = edge_cur_edge__edge2.target;
                                        if(!NodeType_C.isMyType[node_cur_node_c4.type.TypeID]) {
                                            edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                            continue;
                                        }
                                        if(node_cur_node_c4.isMatched
                                            && (node_cur_node_c4==node_cur_node_c1
                                                || node_cur_node_c4==node_cur_node_c2
                                                || node_cur_node_c4==node_cur_node_c3
                                                )
                                            )
                                        {
                                            edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                            continue;
                                        }
                                        bool node_cur_node_c4_prevIsMatched = node_cur_node_c4.isMatched;
                                        node_cur_node_c4.isMatched = true;
                                        // Extend outgoing edge__edge7 from node_c3 
                                        LGSPEdge edge_head_edge__edge7 = node_cur_node_c3.outhead;
                                        if(edge_head_edge__edge7 != null)
                                        {
                                            LGSPEdge edge_cur_edge__edge7 = edge_head_edge__edge7;
                                            do
                                            {
                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge7.type.TypeID]) {
                                                    continue;
                                                }
                                                if(edge_cur_edge__edge7.target != node_cur_node_c4) {
                                                    continue;
                                                }
                                                if(edge_cur_edge__edge7.isMatched
                                                    && (edge_cur_edge__edge7==edge_cur_edge__edge0
                                                        || edge_cur_edge__edge7==edge_cur_edge__edge6
                                                        || edge_cur_edge__edge7==edge_cur_edge__edge1
                                                        || edge_cur_edge__edge7==edge_cur_edge__edge2
                                                        )
                                                    )
                                                {
                                                    continue;
                                                }
                                                bool edge_cur_edge__edge7_prevIsMatched = edge_cur_edge__edge7.isMatched;
                                                edge_cur_edge__edge7.isMatched = true;
                                                // Extend outgoing edge__edge3 from node_c4 
                                                LGSPEdge edge_head_edge__edge3 = node_cur_node_c4.outhead;
                                                if(edge_head_edge__edge3 != null)
                                                {
                                                    LGSPEdge edge_cur_edge__edge3 = edge_head_edge__edge3;
                                                    do
                                                    {
                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge3.type.TypeID]) {
                                                            continue;
                                                        }
                                                        if(edge_cur_edge__edge3.isMatched
                                                            && (edge_cur_edge__edge3==edge_cur_edge__edge0
                                                                || edge_cur_edge__edge3==edge_cur_edge__edge6
                                                                || edge_cur_edge__edge3==edge_cur_edge__edge1
                                                                || edge_cur_edge__edge3==edge_cur_edge__edge2
                                                                || edge_cur_edge__edge3==edge_cur_edge__edge7
                                                                )
                                                            )
                                                        {
                                                            continue;
                                                        }
                                                        bool edge_cur_edge__edge3_prevIsMatched = edge_cur_edge__edge3.isMatched;
                                                        edge_cur_edge__edge3.isMatched = true;
                                                        // Implicit target node_c5 from edge__edge3 
                                                        LGSPNode node_cur_node_c5 = edge_cur_edge__edge3.target;
                                                        if(!NodeType_C.isMyType[node_cur_node_c5.type.TypeID]) {
                                                            edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                            continue;
                                                        }
                                                        if(node_cur_node_c5.isMatched
                                                            && (node_cur_node_c5==node_cur_node_c1
                                                                || node_cur_node_c5==node_cur_node_c2
                                                                || node_cur_node_c5==node_cur_node_c3
                                                                || node_cur_node_c5==node_cur_node_c4
                                                                )
                                                            )
                                                        {
                                                            edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                            continue;
                                                        }
                                                        bool node_cur_node_c5_prevIsMatched = node_cur_node_c5.isMatched;
                                                        node_cur_node_c5.isMatched = true;
                                                        // Extend outgoing edge__edge4 from node_c5 
                                                        LGSPEdge edge_head_edge__edge4 = node_cur_node_c5.outhead;
                                                        if(edge_head_edge__edge4 != null)
                                                        {
                                                            LGSPEdge edge_cur_edge__edge4 = edge_head_edge__edge4;
                                                            do
                                                            {
                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge4.type.TypeID]) {
                                                                    continue;
                                                                }
                                                                if(edge_cur_edge__edge4.isMatched
                                                                    && (edge_cur_edge__edge4==edge_cur_edge__edge0
                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge6
                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge1
                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge2
                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge7
                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge3
                                                                        )
                                                                    )
                                                                {
                                                                    continue;
                                                                }
                                                                bool edge_cur_edge__edge4_prevIsMatched = edge_cur_edge__edge4.isMatched;
                                                                edge_cur_edge__edge4.isMatched = true;
                                                                // Implicit target node_c6 from edge__edge4 
                                                                LGSPNode node_cur_node_c6 = edge_cur_edge__edge4.target;
                                                                if(!NodeType_C.isMyType[node_cur_node_c6.type.TypeID]) {
                                                                    edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                    continue;
                                                                }
                                                                if(node_cur_node_c6.isMatched
                                                                    && (node_cur_node_c6==node_cur_node_c1
                                                                        || node_cur_node_c6==node_cur_node_c2
                                                                        || node_cur_node_c6==node_cur_node_c3
                                                                        || node_cur_node_c6==node_cur_node_c4
                                                                        || node_cur_node_c6==node_cur_node_c5
                                                                        )
                                                                    )
                                                                {
                                                                    edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                    continue;
                                                                }
                                                                // Extend outgoing edge__edge8 from node_c5 
                                                                LGSPEdge edge_head_edge__edge8 = node_cur_node_c5.outhead;
                                                                if(edge_head_edge__edge8 != null)
                                                                {
                                                                    LGSPEdge edge_cur_edge__edge8 = edge_head_edge__edge8;
                                                                    do
                                                                    {
                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge8.type.TypeID]) {
                                                                            continue;
                                                                        }
                                                                        if(edge_cur_edge__edge8.target != node_cur_node_c6) {
                                                                            continue;
                                                                        }
                                                                        if(edge_cur_edge__edge8.isMatched
                                                                            && (edge_cur_edge__edge8==edge_cur_edge__edge0
                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge6
                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge1
                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge2
                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge7
                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge3
                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge4
                                                                                )
                                                                            )
                                                                        {
                                                                            continue;
                                                                        }
                                                                        bool edge_cur_edge__edge8_prevIsMatched = edge_cur_edge__edge8.isMatched;
                                                                        edge_cur_edge__edge8.isMatched = true;
                                                                        // Extend outgoing edge__edge5 from node_c6 
                                                                        LGSPEdge edge_head_edge__edge5 = node_cur_node_c6.outhead;
                                                                        if(edge_head_edge__edge5 != null)
                                                                        {
                                                                            LGSPEdge edge_cur_edge__edge5 = edge_head_edge__edge5;
                                                                            do
                                                                            {
                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge5.type.TypeID]) {
                                                                                    continue;
                                                                                }
                                                                                if(edge_cur_edge__edge5.target != node_cur_node_c1) {
                                                                                    continue;
                                                                                }
                                                                                if(edge_cur_edge__edge5.isMatched
                                                                                    && (edge_cur_edge__edge5==edge_cur_edge__edge0
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge6
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge1
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge2
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge7
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge3
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge4
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge8
                                                                                        )
                                                                                    )
                                                                                {
                                                                                    continue;
                                                                                }
                                                                                // Push subpattern matching task for _subpattern5
                                                                                PatternAction_Nitro taskFor__subpattern5 = new PatternAction_Nitro(graph, openTasks);
                                                                                taskFor__subpattern5.node_anchor = node_cur_node_c6;
                                                                                openTasks.Push(taskFor__subpattern5);
                                                                                // Push subpattern matching task for _subpattern4
                                                                                PatternAction_Hydrogen taskFor__subpattern4 = new PatternAction_Hydrogen(graph, openTasks);
                                                                                taskFor__subpattern4.node_anchor = node_cur_node_c5;
                                                                                openTasks.Push(taskFor__subpattern4);
                                                                                // Push subpattern matching task for _subpattern3
                                                                                PatternAction_Nitro taskFor__subpattern3 = new PatternAction_Nitro(graph, openTasks);
                                                                                taskFor__subpattern3.node_anchor = node_cur_node_c4;
                                                                                openTasks.Push(taskFor__subpattern3);
                                                                                // Push subpattern matching task for _subpattern2
                                                                                PatternAction_Hydrogen taskFor__subpattern2 = new PatternAction_Hydrogen(graph, openTasks);
                                                                                taskFor__subpattern2.node_anchor = node_cur_node_c3;
                                                                                openTasks.Push(taskFor__subpattern2);
                                                                                // Push subpattern matching task for _subpattern1
                                                                                PatternAction_Nitro taskFor__subpattern1 = new PatternAction_Nitro(graph, openTasks);
                                                                                taskFor__subpattern1.node_anchor = node_cur_node_c2;
                                                                                openTasks.Push(taskFor__subpattern1);
                                                                                // Push subpattern matching task for _subpattern0
                                                                                PatternAction_Hydrogen taskFor__subpattern0 = new PatternAction_Hydrogen(graph, openTasks);
                                                                                taskFor__subpattern0.node_anchor = node_cur_node_c1;
                                                                                openTasks.Push(taskFor__subpattern0);
                                                                                node_cur_node_c1.isMatchedByEnclosingPattern = true;
                                                                                node_cur_node_c2.isMatchedByEnclosingPattern = true;
                                                                                node_cur_node_c3.isMatchedByEnclosingPattern = true;
                                                                                node_cur_node_c4.isMatchedByEnclosingPattern = true;
                                                                                node_cur_node_c5.isMatchedByEnclosingPattern = true;
                                                                                node_cur_node_c6.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge0.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge1.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge2.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge3.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge4.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge5.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge6.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge7.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge8.isMatchedByEnclosingPattern = true;
                                                                                // Match subpatterns
                                                                                openTasks.Peek().myMatch(matchesList, maxMatches - foundPartialMatches.Count);
                                                                                //Pop subpattern matching task for _subpattern0
                                                                                openTasks.Pop();
                                                                                //Pop subpattern matching task for _subpattern1
                                                                                openTasks.Pop();
                                                                                //Pop subpattern matching task for _subpattern2
                                                                                openTasks.Pop();
                                                                                //Pop subpattern matching task for _subpattern3
                                                                                openTasks.Pop();
                                                                                //Pop subpattern matching task for _subpattern4
                                                                                openTasks.Pop();
                                                                                //Pop subpattern matching task for _subpattern5
                                                                                openTasks.Pop();
                                                                                // Check whether subpatterns were found 
                                                                                if(matchesList.Count>0) {
                                                                                    // subpatterns were found, extend the partial matches by our local match object, becoming a complete match object and save it
                                                                                    foreach(Stack<LGSPMatch> currentFoundPartialMatch in matchesList)
                                                                                    {
                                                                                        LGSPMatch match = matches.matchesList.GetEmptyMatchFromList();
                                                                                        match.patternGraph = rulePattern.patternGraph;
                                                                                        match.Nodes[(int)Rule_TNB.NodeNums.@c1] = node_cur_node_c1;
                                                                                        match.Nodes[(int)Rule_TNB.NodeNums.@c2] = node_cur_node_c2;
                                                                                        match.Nodes[(int)Rule_TNB.NodeNums.@c3] = node_cur_node_c3;
                                                                                        match.Nodes[(int)Rule_TNB.NodeNums.@c4] = node_cur_node_c4;
                                                                                        match.Nodes[(int)Rule_TNB.NodeNums.@c5] = node_cur_node_c5;
                                                                                        match.Nodes[(int)Rule_TNB.NodeNums.@c6] = node_cur_node_c6;
                                                                                        match.Edges[(int)Rule_TNB.EdgeNums.@_edge0] = edge_cur_edge__edge0;
                                                                                        match.Edges[(int)Rule_TNB.EdgeNums.@_edge1] = edge_cur_edge__edge1;
                                                                                        match.Edges[(int)Rule_TNB.EdgeNums.@_edge2] = edge_cur_edge__edge2;
                                                                                        match.Edges[(int)Rule_TNB.EdgeNums.@_edge3] = edge_cur_edge__edge3;
                                                                                        match.Edges[(int)Rule_TNB.EdgeNums.@_edge4] = edge_cur_edge__edge4;
                                                                                        match.Edges[(int)Rule_TNB.EdgeNums.@_edge5] = edge_cur_edge__edge5;
                                                                                        match.Edges[(int)Rule_TNB.EdgeNums.@_edge6] = edge_cur_edge__edge6;
                                                                                        match.Edges[(int)Rule_TNB.EdgeNums.@_edge7] = edge_cur_edge__edge7;
                                                                                        match.Edges[(int)Rule_TNB.EdgeNums.@_edge8] = edge_cur_edge__edge8;
                                                                                        match.EmbeddedGraphs[(int)Rule_TNB.PatternNums.@_subpattern0] = currentFoundPartialMatch.Pop();
                                                                                        match.EmbeddedGraphs[(int)Rule_TNB.PatternNums.@_subpattern1] = currentFoundPartialMatch.Pop();
                                                                                        match.EmbeddedGraphs[(int)Rule_TNB.PatternNums.@_subpattern2] = currentFoundPartialMatch.Pop();
                                                                                        match.EmbeddedGraphs[(int)Rule_TNB.PatternNums.@_subpattern3] = currentFoundPartialMatch.Pop();
                                                                                        match.EmbeddedGraphs[(int)Rule_TNB.PatternNums.@_subpattern4] = currentFoundPartialMatch.Pop();
                                                                                        match.EmbeddedGraphs[(int)Rule_TNB.PatternNums.@_subpattern5] = currentFoundPartialMatch.Pop();
                                                                                        matches.matchesList.EmptyMatchWasFilledFixIt();
                                                                                    }
                                                                                    matchesList.Clear();
                                                                                    // if enough matches were found, we leave
                                                                                    if(maxMatches > 0 && matches.matchesList.Count >= maxMatches)
                                                                                    {
                                                                                        edge_cur_edge__edge8.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge7.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge6.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge5.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge4.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge3.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge2.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge1.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                                                                                        node_cur_node_c6.isMatchedByEnclosingPattern = false;
                                                                                        node_cur_node_c5.isMatchedByEnclosingPattern = false;
                                                                                        node_cur_node_c4.isMatchedByEnclosingPattern = false;
                                                                                        node_cur_node_c3.isMatchedByEnclosingPattern = false;
                                                                                        node_cur_node_c2.isMatchedByEnclosingPattern = false;
                                                                                        node_cur_node_c1.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge8.isMatched = edge_cur_edge__edge8_prevIsMatched;
                                                                                        edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                                        node_cur_node_c5.isMatched = node_cur_node_c5_prevIsMatched;
                                                                                        edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                                                        edge_cur_edge__edge7.isMatched = edge_cur_edge__edge7_prevIsMatched;
                                                                                        node_cur_node_c4.isMatched = node_cur_node_c4_prevIsMatched;
                                                                                        edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                                                                        node_cur_node_c3.isMatched = node_cur_node_c3_prevIsMatched;
                                                                                        edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                                                                        edge_cur_edge__edge6.isMatched = edge_cur_edge__edge6_prevIsMatched;
                                                                                        node_cur_node_c2.isMatched = node_cur_node_c2_prevIsMatched;
                                                                                        node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                                                                                        edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                                                                                        return matches;
                                                                                    }
                                                                                    edge_cur_edge__edge8.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge7.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge6.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge5.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge4.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge3.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge2.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge1.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                                                                                    node_cur_node_c6.isMatchedByEnclosingPattern = false;
                                                                                    node_cur_node_c5.isMatchedByEnclosingPattern = false;
                                                                                    node_cur_node_c4.isMatchedByEnclosingPattern = false;
                                                                                    node_cur_node_c3.isMatchedByEnclosingPattern = false;
                                                                                    node_cur_node_c2.isMatchedByEnclosingPattern = false;
                                                                                    node_cur_node_c1.isMatchedByEnclosingPattern = false;
                                                                                    continue;
                                                                                }
                                                                                node_cur_node_c1.isMatchedByEnclosingPattern = false;
                                                                                node_cur_node_c2.isMatchedByEnclosingPattern = false;
                                                                                node_cur_node_c3.isMatchedByEnclosingPattern = false;
                                                                                node_cur_node_c4.isMatchedByEnclosingPattern = false;
                                                                                node_cur_node_c5.isMatchedByEnclosingPattern = false;
                                                                                node_cur_node_c6.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge1.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge2.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge3.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge4.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge5.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge6.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge7.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge8.isMatchedByEnclosingPattern = false;
                                                                            }
                                                                            while( (edge_cur_edge__edge5 = edge_cur_edge__edge5.outNext) != edge_head_edge__edge5 );
                                                                        }
                                                                        edge_cur_edge__edge8.isMatched = edge_cur_edge__edge8_prevIsMatched;
                                                                    }
                                                                    while( (edge_cur_edge__edge8 = edge_cur_edge__edge8.outNext) != edge_head_edge__edge8 );
                                                                }
                                                                edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                            }
                                                            while( (edge_cur_edge__edge4 = edge_cur_edge__edge4.outNext) != edge_head_edge__edge4 );
                                                        }
                                                        node_cur_node_c5.isMatched = node_cur_node_c5_prevIsMatched;
                                                        edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                    }
                                                    while( (edge_cur_edge__edge3 = edge_cur_edge__edge3.outNext) != edge_head_edge__edge3 );
                                                }
                                                edge_cur_edge__edge7.isMatched = edge_cur_edge__edge7_prevIsMatched;
                                            }
                                            while( (edge_cur_edge__edge7 = edge_cur_edge__edge7.outNext) != edge_head_edge__edge7 );
                                        }
                                        node_cur_node_c4.isMatched = node_cur_node_c4_prevIsMatched;
                                        edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                    }
                                    while( (edge_cur_edge__edge2 = edge_cur_edge__edge2.outNext) != edge_head_edge__edge2 );
                                }
                                node_cur_node_c3.isMatched = node_cur_node_c3_prevIsMatched;
                                edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                            }
                            while( (edge_cur_edge__edge1 = edge_cur_edge__edge1.outNext) != edge_head_edge__edge1 );
                        }
                        edge_cur_edge__edge6.isMatched = edge_cur_edge__edge6_prevIsMatched;
                    }
                    while( (edge_cur_edge__edge6 = edge_cur_edge__edge6.outNext) != edge_head_edge__edge6 );
                }
                node_cur_node_c2.isMatched = node_cur_node_c2_prevIsMatched;
                node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
            }
            return matches;
        }
	}
	public class Action_TNBUnfolded : LGSPAction
	{
		public Action_TNBUnfolded() {
			rulePattern = Rule_TNBUnfolded.Instance;
			DynamicMatch = myMatch; matches = new LGSPMatches(this, 18, 21, 0);
		}

		public override string Name { get { return "TNBUnfolded"; } }
		private LGSPMatches matches;

		public static LGSPAction Instance { get { return instance; } }
		private static Action_TNBUnfolded instance = new Action_TNBUnfolded();

        public LGSPMatches myMatch(LGSPGraph graph, int maxMatches, IGraphElement[] parameters)
        {
            matches.matchesList.Clear();
            // Lookup edge__edge0 
            int edge_type_id_edge__edge0 = 2;
            for(LGSPEdge edge_head_edge__edge0 = graph.edgesByTypeHeads[edge_type_id_edge__edge0], edge_cur_edge__edge0 = edge_head_edge__edge0.typeNext; edge_cur_edge__edge0 != edge_head_edge__edge0; edge_cur_edge__edge0 = edge_cur_edge__edge0.typeNext)
            {
                bool edge_cur_edge__edge0_prevIsMatched = edge_cur_edge__edge0.isMatched;
                edge_cur_edge__edge0.isMatched = true;
                // Implicit source node_c1 from edge__edge0 
                LGSPNode node_cur_node_c1 = edge_cur_edge__edge0.source;
                if(!NodeType_C.isMyType[node_cur_node_c1.type.TypeID]) {
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                    continue;
                }
                bool node_cur_node_c1_prevIsMatched = node_cur_node_c1.isMatched;
                node_cur_node_c1.isMatched = true;
                // Implicit target node_c2 from edge__edge0 
                LGSPNode node_cur_node_c2 = edge_cur_edge__edge0.target;
                if(!NodeType_C.isMyType[node_cur_node_c2.type.TypeID]) {
                    node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                    continue;
                }
                if(node_cur_node_c2.isMatched
                    && node_cur_node_c2==node_cur_node_c1
                    )
                {
                    node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                    continue;
                }
                bool node_cur_node_c2_prevIsMatched = node_cur_node_c2.isMatched;
                node_cur_node_c2.isMatched = true;
                // Extend outgoing edge__edge6 from node_c1 
                LGSPEdge edge_head_edge__edge6 = node_cur_node_c1.outhead;
                if(edge_head_edge__edge6 != null)
                {
                    LGSPEdge edge_cur_edge__edge6 = edge_head_edge__edge6;
                    do
                    {
                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge6.type.TypeID]) {
                            continue;
                        }
                        if(edge_cur_edge__edge6.target != node_cur_node_c2) {
                            continue;
                        }
                        if(edge_cur_edge__edge6.isMatched
                            && edge_cur_edge__edge6==edge_cur_edge__edge0
                            )
                        {
                            continue;
                        }
                        bool edge_cur_edge__edge6_prevIsMatched = edge_cur_edge__edge6.isMatched;
                        edge_cur_edge__edge6.isMatched = true;
                        // Extend outgoing edge__edge9 from node_c1 
                        LGSPEdge edge_head_edge__edge9 = node_cur_node_c1.outhead;
                        if(edge_head_edge__edge9 != null)
                        {
                            LGSPEdge edge_cur_edge__edge9 = edge_head_edge__edge9;
                            do
                            {
                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge9.type.TypeID]) {
                                    continue;
                                }
                                if(edge_cur_edge__edge9.isMatched
                                    && (edge_cur_edge__edge9==edge_cur_edge__edge0
                                        || edge_cur_edge__edge9==edge_cur_edge__edge6
                                        )
                                    )
                                {
                                    continue;
                                }
                                bool edge_cur_edge__edge9_prevIsMatched = edge_cur_edge__edge9.isMatched;
                                edge_cur_edge__edge9.isMatched = true;
                                // Implicit target node__node0 from edge__edge9 
                                LGSPNode node_cur_node__node0 = edge_cur_edge__edge9.target;
                                if(!NodeType_H.isMyType[node_cur_node__node0.type.TypeID]) {
                                    edge_cur_edge__edge9.isMatched = edge_cur_edge__edge9_prevIsMatched;
                                    continue;
                                }
                                bool node_cur_node__node0_prevIsMatched = node_cur_node__node0.isMatched;
                                node_cur_node__node0.isMatched = true;
                                // Extend outgoing edge__edge1 from node_c2 
                                LGSPEdge edge_head_edge__edge1 = node_cur_node_c2.outhead;
                                if(edge_head_edge__edge1 != null)
                                {
                                    LGSPEdge edge_cur_edge__edge1 = edge_head_edge__edge1;
                                    do
                                    {
                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge1.type.TypeID]) {
                                            continue;
                                        }
                                        if(edge_cur_edge__edge1.isMatched
                                            && (edge_cur_edge__edge1==edge_cur_edge__edge0
                                                || edge_cur_edge__edge1==edge_cur_edge__edge6
                                                || edge_cur_edge__edge1==edge_cur_edge__edge9
                                                )
                                            )
                                        {
                                            continue;
                                        }
                                        bool edge_cur_edge__edge1_prevIsMatched = edge_cur_edge__edge1.isMatched;
                                        edge_cur_edge__edge1.isMatched = true;
                                        // Implicit target node_c3 from edge__edge1 
                                        LGSPNode node_cur_node_c3 = edge_cur_edge__edge1.target;
                                        if(!NodeType_C.isMyType[node_cur_node_c3.type.TypeID]) {
                                            edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                            continue;
                                        }
                                        if(node_cur_node_c3.isMatched
                                            && (node_cur_node_c3==node_cur_node_c1
                                                || node_cur_node_c3==node_cur_node_c2
                                                )
                                            )
                                        {
                                            edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                            continue;
                                        }
                                        bool node_cur_node_c3_prevIsMatched = node_cur_node_c3.isMatched;
                                        node_cur_node_c3.isMatched = true;
                                        // Extend outgoing edge__edge10 from node_c2 
                                        LGSPEdge edge_head_edge__edge10 = node_cur_node_c2.outhead;
                                        if(edge_head_edge__edge10 != null)
                                        {
                                            LGSPEdge edge_cur_edge__edge10 = edge_head_edge__edge10;
                                            do
                                            {
                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge10.type.TypeID]) {
                                                    continue;
                                                }
                                                if(edge_cur_edge__edge10.isMatched
                                                    && (edge_cur_edge__edge10==edge_cur_edge__edge0
                                                        || edge_cur_edge__edge10==edge_cur_edge__edge6
                                                        || edge_cur_edge__edge10==edge_cur_edge__edge9
                                                        || edge_cur_edge__edge10==edge_cur_edge__edge1
                                                        )
                                                    )
                                                {
                                                    continue;
                                                }
                                                bool edge_cur_edge__edge10_prevIsMatched = edge_cur_edge__edge10.isMatched;
                                                edge_cur_edge__edge10.isMatched = true;
                                                // Implicit target node_n2 from edge__edge10 
                                                LGSPNode node_cur_node_n2 = edge_cur_edge__edge10.target;
                                                if(!NodeType_N.isMyType[node_cur_node_n2.type.TypeID]) {
                                                    edge_cur_edge__edge10.isMatched = edge_cur_edge__edge10_prevIsMatched;
                                                    continue;
                                                }
                                                bool node_cur_node_n2_prevIsMatched = node_cur_node_n2.isMatched;
                                                node_cur_node_n2.isMatched = true;
                                                // Extend outgoing edge__edge2 from node_c3 
                                                LGSPEdge edge_head_edge__edge2 = node_cur_node_c3.outhead;
                                                if(edge_head_edge__edge2 != null)
                                                {
                                                    LGSPEdge edge_cur_edge__edge2 = edge_head_edge__edge2;
                                                    do
                                                    {
                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge2.type.TypeID]) {
                                                            continue;
                                                        }
                                                        if(edge_cur_edge__edge2.isMatched
                                                            && (edge_cur_edge__edge2==edge_cur_edge__edge0
                                                                || edge_cur_edge__edge2==edge_cur_edge__edge6
                                                                || edge_cur_edge__edge2==edge_cur_edge__edge9
                                                                || edge_cur_edge__edge2==edge_cur_edge__edge1
                                                                || edge_cur_edge__edge2==edge_cur_edge__edge10
                                                                )
                                                            )
                                                        {
                                                            continue;
                                                        }
                                                        bool edge_cur_edge__edge2_prevIsMatched = edge_cur_edge__edge2.isMatched;
                                                        edge_cur_edge__edge2.isMatched = true;
                                                        // Implicit target node_c4 from edge__edge2 
                                                        LGSPNode node_cur_node_c4 = edge_cur_edge__edge2.target;
                                                        if(!NodeType_C.isMyType[node_cur_node_c4.type.TypeID]) {
                                                            edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                                            continue;
                                                        }
                                                        if(node_cur_node_c4.isMatched
                                                            && (node_cur_node_c4==node_cur_node_c1
                                                                || node_cur_node_c4==node_cur_node_c2
                                                                || node_cur_node_c4==node_cur_node_c3
                                                                )
                                                            )
                                                        {
                                                            edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                                            continue;
                                                        }
                                                        bool node_cur_node_c4_prevIsMatched = node_cur_node_c4.isMatched;
                                                        node_cur_node_c4.isMatched = true;
                                                        // Extend outgoing edge__edge7 from node_c3 
                                                        LGSPEdge edge_head_edge__edge7 = node_cur_node_c3.outhead;
                                                        if(edge_head_edge__edge7 != null)
                                                        {
                                                            LGSPEdge edge_cur_edge__edge7 = edge_head_edge__edge7;
                                                            do
                                                            {
                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge7.type.TypeID]) {
                                                                    continue;
                                                                }
                                                                if(edge_cur_edge__edge7.target != node_cur_node_c4) {
                                                                    continue;
                                                                }
                                                                if(edge_cur_edge__edge7.isMatched
                                                                    && (edge_cur_edge__edge7==edge_cur_edge__edge0
                                                                        || edge_cur_edge__edge7==edge_cur_edge__edge6
                                                                        || edge_cur_edge__edge7==edge_cur_edge__edge9
                                                                        || edge_cur_edge__edge7==edge_cur_edge__edge1
                                                                        || edge_cur_edge__edge7==edge_cur_edge__edge10
                                                                        || edge_cur_edge__edge7==edge_cur_edge__edge2
                                                                        )
                                                                    )
                                                                {
                                                                    continue;
                                                                }
                                                                bool edge_cur_edge__edge7_prevIsMatched = edge_cur_edge__edge7.isMatched;
                                                                edge_cur_edge__edge7.isMatched = true;
                                                                // Extend outgoing edge__edge13 from node_c3 
                                                                LGSPEdge edge_head_edge__edge13 = node_cur_node_c3.outhead;
                                                                if(edge_head_edge__edge13 != null)
                                                                {
                                                                    LGSPEdge edge_cur_edge__edge13 = edge_head_edge__edge13;
                                                                    do
                                                                    {
                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge13.type.TypeID]) {
                                                                            continue;
                                                                        }
                                                                        if(edge_cur_edge__edge13.isMatched
                                                                            && (edge_cur_edge__edge13==edge_cur_edge__edge0
                                                                                || edge_cur_edge__edge13==edge_cur_edge__edge6
                                                                                || edge_cur_edge__edge13==edge_cur_edge__edge9
                                                                                || edge_cur_edge__edge13==edge_cur_edge__edge1
                                                                                || edge_cur_edge__edge13==edge_cur_edge__edge10
                                                                                || edge_cur_edge__edge13==edge_cur_edge__edge2
                                                                                || edge_cur_edge__edge13==edge_cur_edge__edge7
                                                                                )
                                                                            )
                                                                        {
                                                                            continue;
                                                                        }
                                                                        bool edge_cur_edge__edge13_prevIsMatched = edge_cur_edge__edge13.isMatched;
                                                                        edge_cur_edge__edge13.isMatched = true;
                                                                        // Implicit target node__node3 from edge__edge13 
                                                                        LGSPNode node_cur_node__node3 = edge_cur_edge__edge13.target;
                                                                        if(!NodeType_H.isMyType[node_cur_node__node3.type.TypeID]) {
                                                                            edge_cur_edge__edge13.isMatched = edge_cur_edge__edge13_prevIsMatched;
                                                                            continue;
                                                                        }
                                                                        if(node_cur_node__node3.isMatched
                                                                            && node_cur_node__node3==node_cur_node__node0
                                                                            )
                                                                        {
                                                                            edge_cur_edge__edge13.isMatched = edge_cur_edge__edge13_prevIsMatched;
                                                                            continue;
                                                                        }
                                                                        bool node_cur_node__node3_prevIsMatched = node_cur_node__node3.isMatched;
                                                                        node_cur_node__node3.isMatched = true;
                                                                        // Extend outgoing edge__edge11 from node_n2 
                                                                        LGSPEdge edge_head_edge__edge11 = node_cur_node_n2.outhead;
                                                                        if(edge_head_edge__edge11 != null)
                                                                        {
                                                                            LGSPEdge edge_cur_edge__edge11 = edge_head_edge__edge11;
                                                                            do
                                                                            {
                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge11.type.TypeID]) {
                                                                                    continue;
                                                                                }
                                                                                if(edge_cur_edge__edge11.isMatched
                                                                                    && (edge_cur_edge__edge11==edge_cur_edge__edge0
                                                                                        || edge_cur_edge__edge11==edge_cur_edge__edge6
                                                                                        || edge_cur_edge__edge11==edge_cur_edge__edge9
                                                                                        || edge_cur_edge__edge11==edge_cur_edge__edge1
                                                                                        || edge_cur_edge__edge11==edge_cur_edge__edge10
                                                                                        || edge_cur_edge__edge11==edge_cur_edge__edge2
                                                                                        || edge_cur_edge__edge11==edge_cur_edge__edge7
                                                                                        || edge_cur_edge__edge11==edge_cur_edge__edge13
                                                                                        )
                                                                                    )
                                                                                {
                                                                                    continue;
                                                                                }
                                                                                bool edge_cur_edge__edge11_prevIsMatched = edge_cur_edge__edge11.isMatched;
                                                                                edge_cur_edge__edge11.isMatched = true;
                                                                                // Implicit target node__node1 from edge__edge11 
                                                                                LGSPNode node_cur_node__node1 = edge_cur_edge__edge11.target;
                                                                                if(!NodeType_O.isMyType[node_cur_node__node1.type.TypeID]) {
                                                                                    edge_cur_edge__edge11.isMatched = edge_cur_edge__edge11_prevIsMatched;
                                                                                    continue;
                                                                                }
                                                                                bool node_cur_node__node1_prevIsMatched = node_cur_node__node1.isMatched;
                                                                                node_cur_node__node1.isMatched = true;
                                                                                // Extend outgoing edge__edge12 from node_n2 
                                                                                LGSPEdge edge_head_edge__edge12 = node_cur_node_n2.outhead;
                                                                                if(edge_head_edge__edge12 != null)
                                                                                {
                                                                                    LGSPEdge edge_cur_edge__edge12 = edge_head_edge__edge12;
                                                                                    do
                                                                                    {
                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge12.type.TypeID]) {
                                                                                            continue;
                                                                                        }
                                                                                        if(edge_cur_edge__edge12.isMatched
                                                                                            && (edge_cur_edge__edge12==edge_cur_edge__edge0
                                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge6
                                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge9
                                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge1
                                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge10
                                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge2
                                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge7
                                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge13
                                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge11
                                                                                                )
                                                                                            )
                                                                                        {
                                                                                            continue;
                                                                                        }
                                                                                        bool edge_cur_edge__edge12_prevIsMatched = edge_cur_edge__edge12.isMatched;
                                                                                        edge_cur_edge__edge12.isMatched = true;
                                                                                        // Implicit target node__node2 from edge__edge12 
                                                                                        LGSPNode node_cur_node__node2 = edge_cur_edge__edge12.target;
                                                                                        if(!NodeType_O.isMyType[node_cur_node__node2.type.TypeID]) {
                                                                                            edge_cur_edge__edge12.isMatched = edge_cur_edge__edge12_prevIsMatched;
                                                                                            continue;
                                                                                        }
                                                                                        if(node_cur_node__node2.isMatched
                                                                                            && node_cur_node__node2==node_cur_node__node1
                                                                                            )
                                                                                        {
                                                                                            edge_cur_edge__edge12.isMatched = edge_cur_edge__edge12_prevIsMatched;
                                                                                            continue;
                                                                                        }
                                                                                        bool node_cur_node__node2_prevIsMatched = node_cur_node__node2.isMatched;
                                                                                        node_cur_node__node2.isMatched = true;
                                                                                        // Extend outgoing edge__edge3 from node_c4 
                                                                                        LGSPEdge edge_head_edge__edge3 = node_cur_node_c4.outhead;
                                                                                        if(edge_head_edge__edge3 != null)
                                                                                        {
                                                                                            LGSPEdge edge_cur_edge__edge3 = edge_head_edge__edge3;
                                                                                            do
                                                                                            {
                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge3.type.TypeID]) {
                                                                                                    continue;
                                                                                                }
                                                                                                if(edge_cur_edge__edge3.isMatched
                                                                                                    && (edge_cur_edge__edge3==edge_cur_edge__edge0
                                                                                                        || edge_cur_edge__edge3==edge_cur_edge__edge6
                                                                                                        || edge_cur_edge__edge3==edge_cur_edge__edge9
                                                                                                        || edge_cur_edge__edge3==edge_cur_edge__edge1
                                                                                                        || edge_cur_edge__edge3==edge_cur_edge__edge10
                                                                                                        || edge_cur_edge__edge3==edge_cur_edge__edge2
                                                                                                        || edge_cur_edge__edge3==edge_cur_edge__edge7
                                                                                                        || edge_cur_edge__edge3==edge_cur_edge__edge13
                                                                                                        || edge_cur_edge__edge3==edge_cur_edge__edge11
                                                                                                        || edge_cur_edge__edge3==edge_cur_edge__edge12
                                                                                                        )
                                                                                                    )
                                                                                                {
                                                                                                    continue;
                                                                                                }
                                                                                                bool edge_cur_edge__edge3_prevIsMatched = edge_cur_edge__edge3.isMatched;
                                                                                                edge_cur_edge__edge3.isMatched = true;
                                                                                                // Implicit target node_c5 from edge__edge3 
                                                                                                LGSPNode node_cur_node_c5 = edge_cur_edge__edge3.target;
                                                                                                if(!NodeType_C.isMyType[node_cur_node_c5.type.TypeID]) {
                                                                                                    edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                                                                    continue;
                                                                                                }
                                                                                                if(node_cur_node_c5.isMatched
                                                                                                    && (node_cur_node_c5==node_cur_node_c1
                                                                                                        || node_cur_node_c5==node_cur_node_c2
                                                                                                        || node_cur_node_c5==node_cur_node_c3
                                                                                                        || node_cur_node_c5==node_cur_node_c4
                                                                                                        )
                                                                                                    )
                                                                                                {
                                                                                                    edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                                                                    continue;
                                                                                                }
                                                                                                bool node_cur_node_c5_prevIsMatched = node_cur_node_c5.isMatched;
                                                                                                node_cur_node_c5.isMatched = true;
                                                                                                // Extend outgoing edge__edge14 from node_c4 
                                                                                                LGSPEdge edge_head_edge__edge14 = node_cur_node_c4.outhead;
                                                                                                if(edge_head_edge__edge14 != null)
                                                                                                {
                                                                                                    LGSPEdge edge_cur_edge__edge14 = edge_head_edge__edge14;
                                                                                                    do
                                                                                                    {
                                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge14.type.TypeID]) {
                                                                                                            continue;
                                                                                                        }
                                                                                                        if(edge_cur_edge__edge14.isMatched
                                                                                                            && (edge_cur_edge__edge14==edge_cur_edge__edge0
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge6
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge9
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge1
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge10
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge2
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge7
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge13
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge11
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge12
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge3
                                                                                                                )
                                                                                                            )
                                                                                                        {
                                                                                                            continue;
                                                                                                        }
                                                                                                        bool edge_cur_edge__edge14_prevIsMatched = edge_cur_edge__edge14.isMatched;
                                                                                                        edge_cur_edge__edge14.isMatched = true;
                                                                                                        // Implicit target node_n4 from edge__edge14 
                                                                                                        LGSPNode node_cur_node_n4 = edge_cur_edge__edge14.target;
                                                                                                        if(!NodeType_N.isMyType[node_cur_node_n4.type.TypeID]) {
                                                                                                            edge_cur_edge__edge14.isMatched = edge_cur_edge__edge14_prevIsMatched;
                                                                                                            continue;
                                                                                                        }
                                                                                                        if(node_cur_node_n4.isMatched
                                                                                                            && node_cur_node_n4==node_cur_node_n2
                                                                                                            )
                                                                                                        {
                                                                                                            edge_cur_edge__edge14.isMatched = edge_cur_edge__edge14_prevIsMatched;
                                                                                                            continue;
                                                                                                        }
                                                                                                        bool node_cur_node_n4_prevIsMatched = node_cur_node_n4.isMatched;
                                                                                                        node_cur_node_n4.isMatched = true;
                                                                                                        // Extend outgoing edge__edge4 from node_c5 
                                                                                                        LGSPEdge edge_head_edge__edge4 = node_cur_node_c5.outhead;
                                                                                                        if(edge_head_edge__edge4 != null)
                                                                                                        {
                                                                                                            LGSPEdge edge_cur_edge__edge4 = edge_head_edge__edge4;
                                                                                                            do
                                                                                                            {
                                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge4.type.TypeID]) {
                                                                                                                    continue;
                                                                                                                }
                                                                                                                if(edge_cur_edge__edge4.isMatched
                                                                                                                    && (edge_cur_edge__edge4==edge_cur_edge__edge0
                                                                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge6
                                                                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge9
                                                                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge1
                                                                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge10
                                                                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge2
                                                                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge7
                                                                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge13
                                                                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge11
                                                                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge12
                                                                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge3
                                                                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge14
                                                                                                                        )
                                                                                                                    )
                                                                                                                {
                                                                                                                    continue;
                                                                                                                }
                                                                                                                bool edge_cur_edge__edge4_prevIsMatched = edge_cur_edge__edge4.isMatched;
                                                                                                                edge_cur_edge__edge4.isMatched = true;
                                                                                                                // Implicit target node_c6 from edge__edge4 
                                                                                                                LGSPNode node_cur_node_c6 = edge_cur_edge__edge4.target;
                                                                                                                if(!NodeType_C.isMyType[node_cur_node_c6.type.TypeID]) {
                                                                                                                    edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                                                                    continue;
                                                                                                                }
                                                                                                                if(node_cur_node_c6.isMatched
                                                                                                                    && (node_cur_node_c6==node_cur_node_c1
                                                                                                                        || node_cur_node_c6==node_cur_node_c2
                                                                                                                        || node_cur_node_c6==node_cur_node_c3
                                                                                                                        || node_cur_node_c6==node_cur_node_c4
                                                                                                                        || node_cur_node_c6==node_cur_node_c5
                                                                                                                        )
                                                                                                                    )
                                                                                                                {
                                                                                                                    edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                                                                    continue;
                                                                                                                }
                                                                                                                // Extend outgoing edge__edge8 from node_c5 
                                                                                                                LGSPEdge edge_head_edge__edge8 = node_cur_node_c5.outhead;
                                                                                                                if(edge_head_edge__edge8 != null)
                                                                                                                {
                                                                                                                    LGSPEdge edge_cur_edge__edge8 = edge_head_edge__edge8;
                                                                                                                    do
                                                                                                                    {
                                                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge8.type.TypeID]) {
                                                                                                                            continue;
                                                                                                                        }
                                                                                                                        if(edge_cur_edge__edge8.target != node_cur_node_c6) {
                                                                                                                            continue;
                                                                                                                        }
                                                                                                                        if(edge_cur_edge__edge8.isMatched
                                                                                                                            && (edge_cur_edge__edge8==edge_cur_edge__edge0
                                                                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge6
                                                                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge9
                                                                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge1
                                                                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge10
                                                                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge2
                                                                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge7
                                                                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge13
                                                                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge11
                                                                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge12
                                                                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge3
                                                                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge14
                                                                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge4
                                                                                                                                )
                                                                                                                            )
                                                                                                                        {
                                                                                                                            continue;
                                                                                                                        }
                                                                                                                        bool edge_cur_edge__edge8_prevIsMatched = edge_cur_edge__edge8.isMatched;
                                                                                                                        edge_cur_edge__edge8.isMatched = true;
                                                                                                                        // Extend outgoing edge__edge17 from node_c5 
                                                                                                                        LGSPEdge edge_head_edge__edge17 = node_cur_node_c5.outhead;
                                                                                                                        if(edge_head_edge__edge17 != null)
                                                                                                                        {
                                                                                                                            LGSPEdge edge_cur_edge__edge17 = edge_head_edge__edge17;
                                                                                                                            do
                                                                                                                            {
                                                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge17.type.TypeID]) {
                                                                                                                                    continue;
                                                                                                                                }
                                                                                                                                if(edge_cur_edge__edge17.isMatched
                                                                                                                                    && (edge_cur_edge__edge17==edge_cur_edge__edge0
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge6
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge9
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge1
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge10
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge2
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge7
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge13
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge11
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge12
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge3
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge14
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge4
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge8
                                                                                                                                        )
                                                                                                                                    )
                                                                                                                                {
                                                                                                                                    continue;
                                                                                                                                }
                                                                                                                                bool edge_cur_edge__edge17_prevIsMatched = edge_cur_edge__edge17.isMatched;
                                                                                                                                edge_cur_edge__edge17.isMatched = true;
                                                                                                                                // Implicit target node__node6 from edge__edge17 
                                                                                                                                LGSPNode node_cur_node__node6 = edge_cur_edge__edge17.target;
                                                                                                                                if(!NodeType_H.isMyType[node_cur_node__node6.type.TypeID]) {
                                                                                                                                    edge_cur_edge__edge17.isMatched = edge_cur_edge__edge17_prevIsMatched;
                                                                                                                                    continue;
                                                                                                                                }
                                                                                                                                if(node_cur_node__node6.isMatched
                                                                                                                                    && (node_cur_node__node6==node_cur_node__node0
                                                                                                                                        || node_cur_node__node6==node_cur_node__node3
                                                                                                                                        )
                                                                                                                                    )
                                                                                                                                {
                                                                                                                                    edge_cur_edge__edge17.isMatched = edge_cur_edge__edge17_prevIsMatched;
                                                                                                                                    continue;
                                                                                                                                }
                                                                                                                                // Extend outgoing edge__edge15 from node_n4 
                                                                                                                                LGSPEdge edge_head_edge__edge15 = node_cur_node_n4.outhead;
                                                                                                                                if(edge_head_edge__edge15 != null)
                                                                                                                                {
                                                                                                                                    LGSPEdge edge_cur_edge__edge15 = edge_head_edge__edge15;
                                                                                                                                    do
                                                                                                                                    {
                                                                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge15.type.TypeID]) {
                                                                                                                                            continue;
                                                                                                                                        }
                                                                                                                                        if(edge_cur_edge__edge15.isMatched
                                                                                                                                            && (edge_cur_edge__edge15==edge_cur_edge__edge0
                                                                                                                                                || edge_cur_edge__edge15==edge_cur_edge__edge6
                                                                                                                                                || edge_cur_edge__edge15==edge_cur_edge__edge9
                                                                                                                                                || edge_cur_edge__edge15==edge_cur_edge__edge1
                                                                                                                                                || edge_cur_edge__edge15==edge_cur_edge__edge10
                                                                                                                                                || edge_cur_edge__edge15==edge_cur_edge__edge2
                                                                                                                                                || edge_cur_edge__edge15==edge_cur_edge__edge7
                                                                                                                                                || edge_cur_edge__edge15==edge_cur_edge__edge13
                                                                                                                                                || edge_cur_edge__edge15==edge_cur_edge__edge11
                                                                                                                                                || edge_cur_edge__edge15==edge_cur_edge__edge12
                                                                                                                                                || edge_cur_edge__edge15==edge_cur_edge__edge3
                                                                                                                                                || edge_cur_edge__edge15==edge_cur_edge__edge14
                                                                                                                                                || edge_cur_edge__edge15==edge_cur_edge__edge4
                                                                                                                                                || edge_cur_edge__edge15==edge_cur_edge__edge8
                                                                                                                                                || edge_cur_edge__edge15==edge_cur_edge__edge17
                                                                                                                                                )
                                                                                                                                            )
                                                                                                                                        {
                                                                                                                                            continue;
                                                                                                                                        }
                                                                                                                                        bool edge_cur_edge__edge15_prevIsMatched = edge_cur_edge__edge15.isMatched;
                                                                                                                                        edge_cur_edge__edge15.isMatched = true;
                                                                                                                                        // Implicit target node__node4 from edge__edge15 
                                                                                                                                        LGSPNode node_cur_node__node4 = edge_cur_edge__edge15.target;
                                                                                                                                        if(!NodeType_O.isMyType[node_cur_node__node4.type.TypeID]) {
                                                                                                                                            edge_cur_edge__edge15.isMatched = edge_cur_edge__edge15_prevIsMatched;
                                                                                                                                            continue;
                                                                                                                                        }
                                                                                                                                        if(node_cur_node__node4.isMatched
                                                                                                                                            && (node_cur_node__node4==node_cur_node__node1
                                                                                                                                                || node_cur_node__node4==node_cur_node__node2
                                                                                                                                                )
                                                                                                                                            )
                                                                                                                                        {
                                                                                                                                            edge_cur_edge__edge15.isMatched = edge_cur_edge__edge15_prevIsMatched;
                                                                                                                                            continue;
                                                                                                                                        }
                                                                                                                                        bool node_cur_node__node4_prevIsMatched = node_cur_node__node4.isMatched;
                                                                                                                                        node_cur_node__node4.isMatched = true;
                                                                                                                                        // Extend outgoing edge__edge16 from node_n4 
                                                                                                                                        LGSPEdge edge_head_edge__edge16 = node_cur_node_n4.outhead;
                                                                                                                                        if(edge_head_edge__edge16 != null)
                                                                                                                                        {
                                                                                                                                            LGSPEdge edge_cur_edge__edge16 = edge_head_edge__edge16;
                                                                                                                                            do
                                                                                                                                            {
                                                                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge16.type.TypeID]) {
                                                                                                                                                    continue;
                                                                                                                                                }
                                                                                                                                                if(edge_cur_edge__edge16.isMatched
                                                                                                                                                    && (edge_cur_edge__edge16==edge_cur_edge__edge0
                                                                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge6
                                                                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge9
                                                                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge1
                                                                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge10
                                                                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge2
                                                                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge7
                                                                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge13
                                                                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge11
                                                                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge12
                                                                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge3
                                                                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge14
                                                                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge4
                                                                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge8
                                                                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge17
                                                                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge15
                                                                                                                                                        )
                                                                                                                                                    )
                                                                                                                                                {
                                                                                                                                                    continue;
                                                                                                                                                }
                                                                                                                                                bool edge_cur_edge__edge16_prevIsMatched = edge_cur_edge__edge16.isMatched;
                                                                                                                                                edge_cur_edge__edge16.isMatched = true;
                                                                                                                                                // Implicit target node__node5 from edge__edge16 
                                                                                                                                                LGSPNode node_cur_node__node5 = edge_cur_edge__edge16.target;
                                                                                                                                                if(!NodeType_O.isMyType[node_cur_node__node5.type.TypeID]) {
                                                                                                                                                    edge_cur_edge__edge16.isMatched = edge_cur_edge__edge16_prevIsMatched;
                                                                                                                                                    continue;
                                                                                                                                                }
                                                                                                                                                if(node_cur_node__node5.isMatched
                                                                                                                                                    && (node_cur_node__node5==node_cur_node__node1
                                                                                                                                                        || node_cur_node__node5==node_cur_node__node2
                                                                                                                                                        || node_cur_node__node5==node_cur_node__node4
                                                                                                                                                        )
                                                                                                                                                    )
                                                                                                                                                {
                                                                                                                                                    edge_cur_edge__edge16.isMatched = edge_cur_edge__edge16_prevIsMatched;
                                                                                                                                                    continue;
                                                                                                                                                }
                                                                                                                                                bool node_cur_node__node5_prevIsMatched = node_cur_node__node5.isMatched;
                                                                                                                                                node_cur_node__node5.isMatched = true;
                                                                                                                                                // Extend outgoing edge__edge5 from node_c6 
                                                                                                                                                LGSPEdge edge_head_edge__edge5 = node_cur_node_c6.outhead;
                                                                                                                                                if(edge_head_edge__edge5 != null)
                                                                                                                                                {
                                                                                                                                                    LGSPEdge edge_cur_edge__edge5 = edge_head_edge__edge5;
                                                                                                                                                    do
                                                                                                                                                    {
                                                                                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge5.type.TypeID]) {
                                                                                                                                                            continue;
                                                                                                                                                        }
                                                                                                                                                        if(edge_cur_edge__edge5.target != node_cur_node_c1) {
                                                                                                                                                            continue;
                                                                                                                                                        }
                                                                                                                                                        if(edge_cur_edge__edge5.isMatched
                                                                                                                                                            && (edge_cur_edge__edge5==edge_cur_edge__edge0
                                                                                                                                                                || edge_cur_edge__edge5==edge_cur_edge__edge6
                                                                                                                                                                || edge_cur_edge__edge5==edge_cur_edge__edge9
                                                                                                                                                                || edge_cur_edge__edge5==edge_cur_edge__edge1
                                                                                                                                                                || edge_cur_edge__edge5==edge_cur_edge__edge10
                                                                                                                                                                || edge_cur_edge__edge5==edge_cur_edge__edge2
                                                                                                                                                                || edge_cur_edge__edge5==edge_cur_edge__edge7
                                                                                                                                                                || edge_cur_edge__edge5==edge_cur_edge__edge13
                                                                                                                                                                || edge_cur_edge__edge5==edge_cur_edge__edge11
                                                                                                                                                                || edge_cur_edge__edge5==edge_cur_edge__edge12
                                                                                                                                                                || edge_cur_edge__edge5==edge_cur_edge__edge3
                                                                                                                                                                || edge_cur_edge__edge5==edge_cur_edge__edge14
                                                                                                                                                                || edge_cur_edge__edge5==edge_cur_edge__edge4
                                                                                                                                                                || edge_cur_edge__edge5==edge_cur_edge__edge8
                                                                                                                                                                || edge_cur_edge__edge5==edge_cur_edge__edge17
                                                                                                                                                                || edge_cur_edge__edge5==edge_cur_edge__edge15
                                                                                                                                                                || edge_cur_edge__edge5==edge_cur_edge__edge16
                                                                                                                                                                )
                                                                                                                                                            )
                                                                                                                                                        {
                                                                                                                                                            continue;
                                                                                                                                                        }
                                                                                                                                                        bool edge_cur_edge__edge5_prevIsMatched = edge_cur_edge__edge5.isMatched;
                                                                                                                                                        edge_cur_edge__edge5.isMatched = true;
                                                                                                                                                        // Extend outgoing edge__edge18 from node_c6 
                                                                                                                                                        LGSPEdge edge_head_edge__edge18 = node_cur_node_c6.outhead;
                                                                                                                                                        if(edge_head_edge__edge18 != null)
                                                                                                                                                        {
                                                                                                                                                            LGSPEdge edge_cur_edge__edge18 = edge_head_edge__edge18;
                                                                                                                                                            do
                                                                                                                                                            {
                                                                                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge18.type.TypeID]) {
                                                                                                                                                                    continue;
                                                                                                                                                                }
                                                                                                                                                                if(edge_cur_edge__edge18.isMatched
                                                                                                                                                                    && (edge_cur_edge__edge18==edge_cur_edge__edge0
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge6
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge9
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge1
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge10
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge2
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge7
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge13
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge11
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge12
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge3
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge14
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge4
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge8
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge17
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge15
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge16
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge5
                                                                                                                                                                        )
                                                                                                                                                                    )
                                                                                                                                                                {
                                                                                                                                                                    continue;
                                                                                                                                                                }
                                                                                                                                                                bool edge_cur_edge__edge18_prevIsMatched = edge_cur_edge__edge18.isMatched;
                                                                                                                                                                edge_cur_edge__edge18.isMatched = true;
                                                                                                                                                                // Implicit target node_n6 from edge__edge18 
                                                                                                                                                                LGSPNode node_cur_node_n6 = edge_cur_edge__edge18.target;
                                                                                                                                                                if(!NodeType_N.isMyType[node_cur_node_n6.type.TypeID]) {
                                                                                                                                                                    edge_cur_edge__edge18.isMatched = edge_cur_edge__edge18_prevIsMatched;
                                                                                                                                                                    continue;
                                                                                                                                                                }
                                                                                                                                                                if(node_cur_node_n6.isMatched
                                                                                                                                                                    && (node_cur_node_n6==node_cur_node_n2
                                                                                                                                                                        || node_cur_node_n6==node_cur_node_n4
                                                                                                                                                                        )
                                                                                                                                                                    )
                                                                                                                                                                {
                                                                                                                                                                    edge_cur_edge__edge18.isMatched = edge_cur_edge__edge18_prevIsMatched;
                                                                                                                                                                    continue;
                                                                                                                                                                }
                                                                                                                                                                // Extend outgoing edge__edge19 from node_n6 
                                                                                                                                                                LGSPEdge edge_head_edge__edge19 = node_cur_node_n6.outhead;
                                                                                                                                                                if(edge_head_edge__edge19 != null)
                                                                                                                                                                {
                                                                                                                                                                    LGSPEdge edge_cur_edge__edge19 = edge_head_edge__edge19;
                                                                                                                                                                    do
                                                                                                                                                                    {
                                                                                                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge19.type.TypeID]) {
                                                                                                                                                                            continue;
                                                                                                                                                                        }
                                                                                                                                                                        if(edge_cur_edge__edge19.isMatched
                                                                                                                                                                            && (edge_cur_edge__edge19==edge_cur_edge__edge0
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge6
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge9
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge1
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge10
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge2
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge7
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge13
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge11
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge12
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge3
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge14
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge4
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge8
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge17
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge15
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge16
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge5
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge18
                                                                                                                                                                                )
                                                                                                                                                                            )
                                                                                                                                                                        {
                                                                                                                                                                            continue;
                                                                                                                                                                        }
                                                                                                                                                                        bool edge_cur_edge__edge19_prevIsMatched = edge_cur_edge__edge19.isMatched;
                                                                                                                                                                        edge_cur_edge__edge19.isMatched = true;
                                                                                                                                                                        // Implicit target node__node7 from edge__edge19 
                                                                                                                                                                        LGSPNode node_cur_node__node7 = edge_cur_edge__edge19.target;
                                                                                                                                                                        if(!NodeType_O.isMyType[node_cur_node__node7.type.TypeID]) {
                                                                                                                                                                            edge_cur_edge__edge19.isMatched = edge_cur_edge__edge19_prevIsMatched;
                                                                                                                                                                            continue;
                                                                                                                                                                        }
                                                                                                                                                                        if(node_cur_node__node7.isMatched
                                                                                                                                                                            && (node_cur_node__node7==node_cur_node__node1
                                                                                                                                                                                || node_cur_node__node7==node_cur_node__node2
                                                                                                                                                                                || node_cur_node__node7==node_cur_node__node4
                                                                                                                                                                                || node_cur_node__node7==node_cur_node__node5
                                                                                                                                                                                )
                                                                                                                                                                            )
                                                                                                                                                                        {
                                                                                                                                                                            edge_cur_edge__edge19.isMatched = edge_cur_edge__edge19_prevIsMatched;
                                                                                                                                                                            continue;
                                                                                                                                                                        }
                                                                                                                                                                        bool node_cur_node__node7_prevIsMatched = node_cur_node__node7.isMatched;
                                                                                                                                                                        node_cur_node__node7.isMatched = true;
                                                                                                                                                                        // Extend outgoing edge__edge20 from node_n6 
                                                                                                                                                                        LGSPEdge edge_head_edge__edge20 = node_cur_node_n6.outhead;
                                                                                                                                                                        if(edge_head_edge__edge20 != null)
                                                                                                                                                                        {
                                                                                                                                                                            LGSPEdge edge_cur_edge__edge20 = edge_head_edge__edge20;
                                                                                                                                                                            do
                                                                                                                                                                            {
                                                                                                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge20.type.TypeID]) {
                                                                                                                                                                                    continue;
                                                                                                                                                                                }
                                                                                                                                                                                if(edge_cur_edge__edge20.isMatched
                                                                                                                                                                                    && (edge_cur_edge__edge20==edge_cur_edge__edge0
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge6
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge9
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge1
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge10
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge2
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge7
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge13
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge11
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge12
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge3
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge14
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge4
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge8
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge17
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge15
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge16
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge5
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge18
                                                                                                                                                                                        || edge_cur_edge__edge20==edge_cur_edge__edge19
                                                                                                                                                                                        )
                                                                                                                                                                                    )
                                                                                                                                                                                {
                                                                                                                                                                                    continue;
                                                                                                                                                                                }
                                                                                                                                                                                // Implicit target node__node8 from edge__edge20 
                                                                                                                                                                                LGSPNode node_cur_node__node8 = edge_cur_edge__edge20.target;
                                                                                                                                                                                if(!NodeType_O.isMyType[node_cur_node__node8.type.TypeID]) {
                                                                                                                                                                                    continue;
                                                                                                                                                                                }
                                                                                                                                                                                if(node_cur_node__node8.isMatched
                                                                                                                                                                                    && (node_cur_node__node8==node_cur_node__node1
                                                                                                                                                                                        || node_cur_node__node8==node_cur_node__node2
                                                                                                                                                                                        || node_cur_node__node8==node_cur_node__node4
                                                                                                                                                                                        || node_cur_node__node8==node_cur_node__node5
                                                                                                                                                                                        || node_cur_node__node8==node_cur_node__node7
                                                                                                                                                                                        )
                                                                                                                                                                                    )
                                                                                                                                                                                {
                                                                                                                                                                                    continue;
                                                                                                                                                                                }
                                                                                                                                                                                LGSPMatch match = matches.matchesList.GetEmptyMatchFromList();
                                                                                                                                                                                match.patternGraph = rulePattern.patternGraph;
                                                                                                                                                                                match.Nodes[(int)Rule_TNBUnfolded.NodeNums.@c1] = node_cur_node_c1;
                                                                                                                                                                                match.Nodes[(int)Rule_TNBUnfolded.NodeNums.@c2] = node_cur_node_c2;
                                                                                                                                                                                match.Nodes[(int)Rule_TNBUnfolded.NodeNums.@c3] = node_cur_node_c3;
                                                                                                                                                                                match.Nodes[(int)Rule_TNBUnfolded.NodeNums.@c4] = node_cur_node_c4;
                                                                                                                                                                                match.Nodes[(int)Rule_TNBUnfolded.NodeNums.@c5] = node_cur_node_c5;
                                                                                                                                                                                match.Nodes[(int)Rule_TNBUnfolded.NodeNums.@c6] = node_cur_node_c6;
                                                                                                                                                                                match.Nodes[(int)Rule_TNBUnfolded.NodeNums.@_node0] = node_cur_node__node0;
                                                                                                                                                                                match.Nodes[(int)Rule_TNBUnfolded.NodeNums.@n2] = node_cur_node_n2;
                                                                                                                                                                                match.Nodes[(int)Rule_TNBUnfolded.NodeNums.@_node1] = node_cur_node__node1;
                                                                                                                                                                                match.Nodes[(int)Rule_TNBUnfolded.NodeNums.@_node2] = node_cur_node__node2;
                                                                                                                                                                                match.Nodes[(int)Rule_TNBUnfolded.NodeNums.@_node3] = node_cur_node__node3;
                                                                                                                                                                                match.Nodes[(int)Rule_TNBUnfolded.NodeNums.@n4] = node_cur_node_n4;
                                                                                                                                                                                match.Nodes[(int)Rule_TNBUnfolded.NodeNums.@_node4] = node_cur_node__node4;
                                                                                                                                                                                match.Nodes[(int)Rule_TNBUnfolded.NodeNums.@_node5] = node_cur_node__node5;
                                                                                                                                                                                match.Nodes[(int)Rule_TNBUnfolded.NodeNums.@_node6] = node_cur_node__node6;
                                                                                                                                                                                match.Nodes[(int)Rule_TNBUnfolded.NodeNums.@n6] = node_cur_node_n6;
                                                                                                                                                                                match.Nodes[(int)Rule_TNBUnfolded.NodeNums.@_node7] = node_cur_node__node7;
                                                                                                                                                                                match.Nodes[(int)Rule_TNBUnfolded.NodeNums.@_node8] = node_cur_node__node8;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge0] = edge_cur_edge__edge0;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge1] = edge_cur_edge__edge1;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge2] = edge_cur_edge__edge2;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge3] = edge_cur_edge__edge3;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge4] = edge_cur_edge__edge4;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge5] = edge_cur_edge__edge5;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge6] = edge_cur_edge__edge6;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge7] = edge_cur_edge__edge7;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge8] = edge_cur_edge__edge8;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge9] = edge_cur_edge__edge9;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge10] = edge_cur_edge__edge10;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge11] = edge_cur_edge__edge11;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge12] = edge_cur_edge__edge12;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge13] = edge_cur_edge__edge13;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge14] = edge_cur_edge__edge14;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge15] = edge_cur_edge__edge15;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge16] = edge_cur_edge__edge16;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge17] = edge_cur_edge__edge17;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge18] = edge_cur_edge__edge18;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge19] = edge_cur_edge__edge19;
                                                                                                                                                                                match.Edges[(int)Rule_TNBUnfolded.EdgeNums.@_edge20] = edge_cur_edge__edge20;
                                                                                                                                                                                matches.matchesList.EmptyMatchWasFilledFixIt();
                                                                                                                                                                                // if enough matches were found, we leave
                                                                                                                                                                                if(maxMatches > 0 && matches.matchesList.Count >= maxMatches)
                                                                                                                                                                                {
                                                                                                                                                                                    node_cur_node_n6.MoveOutHeadAfter(edge_cur_edge__edge20);
                                                                                                                                                                                    node_cur_node_n6.MoveOutHeadAfter(edge_cur_edge__edge19);
                                                                                                                                                                                    node_cur_node_c6.MoveOutHeadAfter(edge_cur_edge__edge18);
                                                                                                                                                                                    node_cur_node_c6.MoveOutHeadAfter(edge_cur_edge__edge5);
                                                                                                                                                                                    node_cur_node_n4.MoveOutHeadAfter(edge_cur_edge__edge16);
                                                                                                                                                                                    node_cur_node_n4.MoveOutHeadAfter(edge_cur_edge__edge15);
                                                                                                                                                                                    node_cur_node_c5.MoveOutHeadAfter(edge_cur_edge__edge17);
                                                                                                                                                                                    node_cur_node_c5.MoveOutHeadAfter(edge_cur_edge__edge8);
                                                                                                                                                                                    node_cur_node_c5.MoveOutHeadAfter(edge_cur_edge__edge4);
                                                                                                                                                                                    node_cur_node_c4.MoveOutHeadAfter(edge_cur_edge__edge14);
                                                                                                                                                                                    node_cur_node_c4.MoveOutHeadAfter(edge_cur_edge__edge3);
                                                                                                                                                                                    node_cur_node_n2.MoveOutHeadAfter(edge_cur_edge__edge12);
                                                                                                                                                                                    node_cur_node_n2.MoveOutHeadAfter(edge_cur_edge__edge11);
                                                                                                                                                                                    node_cur_node_c3.MoveOutHeadAfter(edge_cur_edge__edge13);
                                                                                                                                                                                    node_cur_node_c3.MoveOutHeadAfter(edge_cur_edge__edge7);
                                                                                                                                                                                    node_cur_node_c3.MoveOutHeadAfter(edge_cur_edge__edge2);
                                                                                                                                                                                    node_cur_node_c2.MoveOutHeadAfter(edge_cur_edge__edge10);
                                                                                                                                                                                    node_cur_node_c2.MoveOutHeadAfter(edge_cur_edge__edge1);
                                                                                                                                                                                    node_cur_node_c1.MoveOutHeadAfter(edge_cur_edge__edge9);
                                                                                                                                                                                    node_cur_node_c1.MoveOutHeadAfter(edge_cur_edge__edge6);
                                                                                                                                                                                    graph.MoveHeadAfter(edge_cur_edge__edge0);
                                                                                                                                                                                    node_cur_node__node7.isMatched = node_cur_node__node7_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge19.isMatched = edge_cur_edge__edge19_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge18.isMatched = edge_cur_edge__edge18_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge5.isMatched = edge_cur_edge__edge5_prevIsMatched;
                                                                                                                                                                                    node_cur_node__node5.isMatched = node_cur_node__node5_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge16.isMatched = edge_cur_edge__edge16_prevIsMatched;
                                                                                                                                                                                    node_cur_node__node4.isMatched = node_cur_node__node4_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge15.isMatched = edge_cur_edge__edge15_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge17.isMatched = edge_cur_edge__edge17_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge8.isMatched = edge_cur_edge__edge8_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                                                                                                                                    node_cur_node_n4.isMatched = node_cur_node_n4_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge14.isMatched = edge_cur_edge__edge14_prevIsMatched;
                                                                                                                                                                                    node_cur_node_c5.isMatched = node_cur_node_c5_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                                                                                                                                                    node_cur_node__node2.isMatched = node_cur_node__node2_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge12.isMatched = edge_cur_edge__edge12_prevIsMatched;
                                                                                                                                                                                    node_cur_node__node1.isMatched = node_cur_node__node1_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge11.isMatched = edge_cur_edge__edge11_prevIsMatched;
                                                                                                                                                                                    node_cur_node__node3.isMatched = node_cur_node__node3_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge13.isMatched = edge_cur_edge__edge13_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge7.isMatched = edge_cur_edge__edge7_prevIsMatched;
                                                                                                                                                                                    node_cur_node_c4.isMatched = node_cur_node_c4_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                                                                                                                                                                    node_cur_node_n2.isMatched = node_cur_node_n2_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge10.isMatched = edge_cur_edge__edge10_prevIsMatched;
                                                                                                                                                                                    node_cur_node_c3.isMatched = node_cur_node_c3_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                                                                                                                                                                    node_cur_node__node0.isMatched = node_cur_node__node0_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge9.isMatched = edge_cur_edge__edge9_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge6.isMatched = edge_cur_edge__edge6_prevIsMatched;
                                                                                                                                                                                    node_cur_node_c2.isMatched = node_cur_node_c2_prevIsMatched;
                                                                                                                                                                                    node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                                                                                                                                                                                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                                                                                                                                                                                    return matches;
                                                                                                                                                                                }
                                                                                                                                                                            }
                                                                                                                                                                            while( (edge_cur_edge__edge20 = edge_cur_edge__edge20.outNext) != edge_head_edge__edge20 );
                                                                                                                                                                        }
                                                                                                                                                                        node_cur_node__node7.isMatched = node_cur_node__node7_prevIsMatched;
                                                                                                                                                                        edge_cur_edge__edge19.isMatched = edge_cur_edge__edge19_prevIsMatched;
                                                                                                                                                                    }
                                                                                                                                                                    while( (edge_cur_edge__edge19 = edge_cur_edge__edge19.outNext) != edge_head_edge__edge19 );
                                                                                                                                                                }
                                                                                                                                                                edge_cur_edge__edge18.isMatched = edge_cur_edge__edge18_prevIsMatched;
                                                                                                                                                            }
                                                                                                                                                            while( (edge_cur_edge__edge18 = edge_cur_edge__edge18.outNext) != edge_head_edge__edge18 );
                                                                                                                                                        }
                                                                                                                                                        edge_cur_edge__edge5.isMatched = edge_cur_edge__edge5_prevIsMatched;
                                                                                                                                                    }
                                                                                                                                                    while( (edge_cur_edge__edge5 = edge_cur_edge__edge5.outNext) != edge_head_edge__edge5 );
                                                                                                                                                }
                                                                                                                                                node_cur_node__node5.isMatched = node_cur_node__node5_prevIsMatched;
                                                                                                                                                edge_cur_edge__edge16.isMatched = edge_cur_edge__edge16_prevIsMatched;
                                                                                                                                            }
                                                                                                                                            while( (edge_cur_edge__edge16 = edge_cur_edge__edge16.outNext) != edge_head_edge__edge16 );
                                                                                                                                        }
                                                                                                                                        node_cur_node__node4.isMatched = node_cur_node__node4_prevIsMatched;
                                                                                                                                        edge_cur_edge__edge15.isMatched = edge_cur_edge__edge15_prevIsMatched;
                                                                                                                                    }
                                                                                                                                    while( (edge_cur_edge__edge15 = edge_cur_edge__edge15.outNext) != edge_head_edge__edge15 );
                                                                                                                                }
                                                                                                                                edge_cur_edge__edge17.isMatched = edge_cur_edge__edge17_prevIsMatched;
                                                                                                                            }
                                                                                                                            while( (edge_cur_edge__edge17 = edge_cur_edge__edge17.outNext) != edge_head_edge__edge17 );
                                                                                                                        }
                                                                                                                        edge_cur_edge__edge8.isMatched = edge_cur_edge__edge8_prevIsMatched;
                                                                                                                    }
                                                                                                                    while( (edge_cur_edge__edge8 = edge_cur_edge__edge8.outNext) != edge_head_edge__edge8 );
                                                                                                                }
                                                                                                                edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                                                            }
                                                                                                            while( (edge_cur_edge__edge4 = edge_cur_edge__edge4.outNext) != edge_head_edge__edge4 );
                                                                                                        }
                                                                                                        node_cur_node_n4.isMatched = node_cur_node_n4_prevIsMatched;
                                                                                                        edge_cur_edge__edge14.isMatched = edge_cur_edge__edge14_prevIsMatched;
                                                                                                    }
                                                                                                    while( (edge_cur_edge__edge14 = edge_cur_edge__edge14.outNext) != edge_head_edge__edge14 );
                                                                                                }
                                                                                                node_cur_node_c5.isMatched = node_cur_node_c5_prevIsMatched;
                                                                                                edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                                                            }
                                                                                            while( (edge_cur_edge__edge3 = edge_cur_edge__edge3.outNext) != edge_head_edge__edge3 );
                                                                                        }
                                                                                        node_cur_node__node2.isMatched = node_cur_node__node2_prevIsMatched;
                                                                                        edge_cur_edge__edge12.isMatched = edge_cur_edge__edge12_prevIsMatched;
                                                                                    }
                                                                                    while( (edge_cur_edge__edge12 = edge_cur_edge__edge12.outNext) != edge_head_edge__edge12 );
                                                                                }
                                                                                node_cur_node__node1.isMatched = node_cur_node__node1_prevIsMatched;
                                                                                edge_cur_edge__edge11.isMatched = edge_cur_edge__edge11_prevIsMatched;
                                                                            }
                                                                            while( (edge_cur_edge__edge11 = edge_cur_edge__edge11.outNext) != edge_head_edge__edge11 );
                                                                        }
                                                                        node_cur_node__node3.isMatched = node_cur_node__node3_prevIsMatched;
                                                                        edge_cur_edge__edge13.isMatched = edge_cur_edge__edge13_prevIsMatched;
                                                                    }
                                                                    while( (edge_cur_edge__edge13 = edge_cur_edge__edge13.outNext) != edge_head_edge__edge13 );
                                                                }
                                                                edge_cur_edge__edge7.isMatched = edge_cur_edge__edge7_prevIsMatched;
                                                            }
                                                            while( (edge_cur_edge__edge7 = edge_cur_edge__edge7.outNext) != edge_head_edge__edge7 );
                                                        }
                                                        node_cur_node_c4.isMatched = node_cur_node_c4_prevIsMatched;
                                                        edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                                    }
                                                    while( (edge_cur_edge__edge2 = edge_cur_edge__edge2.outNext) != edge_head_edge__edge2 );
                                                }
                                                node_cur_node_n2.isMatched = node_cur_node_n2_prevIsMatched;
                                                edge_cur_edge__edge10.isMatched = edge_cur_edge__edge10_prevIsMatched;
                                            }
                                            while( (edge_cur_edge__edge10 = edge_cur_edge__edge10.outNext) != edge_head_edge__edge10 );
                                        }
                                        node_cur_node_c3.isMatched = node_cur_node_c3_prevIsMatched;
                                        edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                    }
                                    while( (edge_cur_edge__edge1 = edge_cur_edge__edge1.outNext) != edge_head_edge__edge1 );
                                }
                                node_cur_node__node0.isMatched = node_cur_node__node0_prevIsMatched;
                                edge_cur_edge__edge9.isMatched = edge_cur_edge__edge9_prevIsMatched;
                            }
                            while( (edge_cur_edge__edge9 = edge_cur_edge__edge9.outNext) != edge_head_edge__edge9 );
                        }
                        edge_cur_edge__edge6.isMatched = edge_cur_edge__edge6_prevIsMatched;
                    }
                    while( (edge_cur_edge__edge6 = edge_cur_edge__edge6.outNext) != edge_head_edge__edge6 );
                }
                node_cur_node_c2.isMatched = node_cur_node_c2_prevIsMatched;
                node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
            }
            return matches;
        }
	}
	public class Action_TNT : LGSPAction
	{
		public Action_TNT() {
			rulePattern = Rule_TNT.Instance;
			DynamicMatch = myMatch; matches = new LGSPMatches(this, 6, 9, 6);
		}

		public override string Name { get { return "TNT"; } }
		private LGSPMatches matches;

		public static LGSPAction Instance { get { return instance; } }
		private static Action_TNT instance = new Action_TNT();

        public LGSPMatches myMatch(LGSPGraph graph, int maxMatches, IGraphElement[] parameters)
        {
            matches.matchesList.Clear();
            Stack<LGSPSubpatternAction> openTasks = new Stack<LGSPSubpatternAction>();
            List<Stack<LGSPMatch>> foundPartialMatches = new List<Stack<LGSPMatch>>();
            List<Stack<LGSPMatch>> matchesList = foundPartialMatches;
            // Lookup edge__edge0 
            int edge_type_id_edge__edge0 = 2;
            for(LGSPEdge edge_head_edge__edge0 = graph.edgesByTypeHeads[edge_type_id_edge__edge0], edge_cur_edge__edge0 = edge_head_edge__edge0.typeNext; edge_cur_edge__edge0 != edge_head_edge__edge0; edge_cur_edge__edge0 = edge_cur_edge__edge0.typeNext)
            {
                bool edge_cur_edge__edge0_prevIsMatched = edge_cur_edge__edge0.isMatched;
                edge_cur_edge__edge0.isMatched = true;
                // Implicit source node_c1 from edge__edge0 
                LGSPNode node_cur_node_c1 = edge_cur_edge__edge0.source;
                if(!NodeType_C.isMyType[node_cur_node_c1.type.TypeID]) {
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                    continue;
                }
                bool node_cur_node_c1_prevIsMatched = node_cur_node_c1.isMatched;
                node_cur_node_c1.isMatched = true;
                // Implicit target node_c2 from edge__edge0 
                LGSPNode node_cur_node_c2 = edge_cur_edge__edge0.target;
                if(!NodeType_C.isMyType[node_cur_node_c2.type.TypeID]) {
                    node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                    continue;
                }
                if(node_cur_node_c2.isMatched
                    && node_cur_node_c2==node_cur_node_c1
                    )
                {
                    node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                    continue;
                }
                bool node_cur_node_c2_prevIsMatched = node_cur_node_c2.isMatched;
                node_cur_node_c2.isMatched = true;
                // Extend outgoing edge__edge6 from node_c1 
                LGSPEdge edge_head_edge__edge6 = node_cur_node_c1.outhead;
                if(edge_head_edge__edge6 != null)
                {
                    LGSPEdge edge_cur_edge__edge6 = edge_head_edge__edge6;
                    do
                    {
                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge6.type.TypeID]) {
                            continue;
                        }
                        if(edge_cur_edge__edge6.target != node_cur_node_c2) {
                            continue;
                        }
                        if(edge_cur_edge__edge6.isMatched
                            && edge_cur_edge__edge6==edge_cur_edge__edge0
                            )
                        {
                            continue;
                        }
                        bool edge_cur_edge__edge6_prevIsMatched = edge_cur_edge__edge6.isMatched;
                        edge_cur_edge__edge6.isMatched = true;
                        // Extend outgoing edge__edge1 from node_c2 
                        LGSPEdge edge_head_edge__edge1 = node_cur_node_c2.outhead;
                        if(edge_head_edge__edge1 != null)
                        {
                            LGSPEdge edge_cur_edge__edge1 = edge_head_edge__edge1;
                            do
                            {
                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge1.type.TypeID]) {
                                    continue;
                                }
                                if(edge_cur_edge__edge1.isMatched
                                    && (edge_cur_edge__edge1==edge_cur_edge__edge0
                                        || edge_cur_edge__edge1==edge_cur_edge__edge6
                                        )
                                    )
                                {
                                    continue;
                                }
                                bool edge_cur_edge__edge1_prevIsMatched = edge_cur_edge__edge1.isMatched;
                                edge_cur_edge__edge1.isMatched = true;
                                // Implicit target node_c3 from edge__edge1 
                                LGSPNode node_cur_node_c3 = edge_cur_edge__edge1.target;
                                if(!NodeType_C.isMyType[node_cur_node_c3.type.TypeID]) {
                                    edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                    continue;
                                }
                                if(node_cur_node_c3.isMatched
                                    && (node_cur_node_c3==node_cur_node_c1
                                        || node_cur_node_c3==node_cur_node_c2
                                        )
                                    )
                                {
                                    edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                    continue;
                                }
                                bool node_cur_node_c3_prevIsMatched = node_cur_node_c3.isMatched;
                                node_cur_node_c3.isMatched = true;
                                // Extend outgoing edge__edge2 from node_c3 
                                LGSPEdge edge_head_edge__edge2 = node_cur_node_c3.outhead;
                                if(edge_head_edge__edge2 != null)
                                {
                                    LGSPEdge edge_cur_edge__edge2 = edge_head_edge__edge2;
                                    do
                                    {
                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge2.type.TypeID]) {
                                            continue;
                                        }
                                        if(edge_cur_edge__edge2.isMatched
                                            && (edge_cur_edge__edge2==edge_cur_edge__edge0
                                                || edge_cur_edge__edge2==edge_cur_edge__edge6
                                                || edge_cur_edge__edge2==edge_cur_edge__edge1
                                                )
                                            )
                                        {
                                            continue;
                                        }
                                        bool edge_cur_edge__edge2_prevIsMatched = edge_cur_edge__edge2.isMatched;
                                        edge_cur_edge__edge2.isMatched = true;
                                        // Implicit target node_c4 from edge__edge2 
                                        LGSPNode node_cur_node_c4 = edge_cur_edge__edge2.target;
                                        if(!NodeType_C.isMyType[node_cur_node_c4.type.TypeID]) {
                                            edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                            continue;
                                        }
                                        if(node_cur_node_c4.isMatched
                                            && (node_cur_node_c4==node_cur_node_c1
                                                || node_cur_node_c4==node_cur_node_c2
                                                || node_cur_node_c4==node_cur_node_c3
                                                )
                                            )
                                        {
                                            edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                            continue;
                                        }
                                        bool node_cur_node_c4_prevIsMatched = node_cur_node_c4.isMatched;
                                        node_cur_node_c4.isMatched = true;
                                        // Extend outgoing edge__edge7 from node_c3 
                                        LGSPEdge edge_head_edge__edge7 = node_cur_node_c3.outhead;
                                        if(edge_head_edge__edge7 != null)
                                        {
                                            LGSPEdge edge_cur_edge__edge7 = edge_head_edge__edge7;
                                            do
                                            {
                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge7.type.TypeID]) {
                                                    continue;
                                                }
                                                if(edge_cur_edge__edge7.target != node_cur_node_c4) {
                                                    continue;
                                                }
                                                if(edge_cur_edge__edge7.isMatched
                                                    && (edge_cur_edge__edge7==edge_cur_edge__edge0
                                                        || edge_cur_edge__edge7==edge_cur_edge__edge6
                                                        || edge_cur_edge__edge7==edge_cur_edge__edge1
                                                        || edge_cur_edge__edge7==edge_cur_edge__edge2
                                                        )
                                                    )
                                                {
                                                    continue;
                                                }
                                                bool edge_cur_edge__edge7_prevIsMatched = edge_cur_edge__edge7.isMatched;
                                                edge_cur_edge__edge7.isMatched = true;
                                                // Extend outgoing edge__edge3 from node_c4 
                                                LGSPEdge edge_head_edge__edge3 = node_cur_node_c4.outhead;
                                                if(edge_head_edge__edge3 != null)
                                                {
                                                    LGSPEdge edge_cur_edge__edge3 = edge_head_edge__edge3;
                                                    do
                                                    {
                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge3.type.TypeID]) {
                                                            continue;
                                                        }
                                                        if(edge_cur_edge__edge3.isMatched
                                                            && (edge_cur_edge__edge3==edge_cur_edge__edge0
                                                                || edge_cur_edge__edge3==edge_cur_edge__edge6
                                                                || edge_cur_edge__edge3==edge_cur_edge__edge1
                                                                || edge_cur_edge__edge3==edge_cur_edge__edge2
                                                                || edge_cur_edge__edge3==edge_cur_edge__edge7
                                                                )
                                                            )
                                                        {
                                                            continue;
                                                        }
                                                        bool edge_cur_edge__edge3_prevIsMatched = edge_cur_edge__edge3.isMatched;
                                                        edge_cur_edge__edge3.isMatched = true;
                                                        // Implicit target node_c5 from edge__edge3 
                                                        LGSPNode node_cur_node_c5 = edge_cur_edge__edge3.target;
                                                        if(!NodeType_C.isMyType[node_cur_node_c5.type.TypeID]) {
                                                            edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                            continue;
                                                        }
                                                        if(node_cur_node_c5.isMatched
                                                            && (node_cur_node_c5==node_cur_node_c1
                                                                || node_cur_node_c5==node_cur_node_c2
                                                                || node_cur_node_c5==node_cur_node_c3
                                                                || node_cur_node_c5==node_cur_node_c4
                                                                )
                                                            )
                                                        {
                                                            edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                            continue;
                                                        }
                                                        bool node_cur_node_c5_prevIsMatched = node_cur_node_c5.isMatched;
                                                        node_cur_node_c5.isMatched = true;
                                                        // Extend outgoing edge__edge4 from node_c5 
                                                        LGSPEdge edge_head_edge__edge4 = node_cur_node_c5.outhead;
                                                        if(edge_head_edge__edge4 != null)
                                                        {
                                                            LGSPEdge edge_cur_edge__edge4 = edge_head_edge__edge4;
                                                            do
                                                            {
                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge4.type.TypeID]) {
                                                                    continue;
                                                                }
                                                                if(edge_cur_edge__edge4.isMatched
                                                                    && (edge_cur_edge__edge4==edge_cur_edge__edge0
                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge6
                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge1
                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge2
                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge7
                                                                        || edge_cur_edge__edge4==edge_cur_edge__edge3
                                                                        )
                                                                    )
                                                                {
                                                                    continue;
                                                                }
                                                                bool edge_cur_edge__edge4_prevIsMatched = edge_cur_edge__edge4.isMatched;
                                                                edge_cur_edge__edge4.isMatched = true;
                                                                // Implicit target node_c6 from edge__edge4 
                                                                LGSPNode node_cur_node_c6 = edge_cur_edge__edge4.target;
                                                                if(!NodeType_C.isMyType[node_cur_node_c6.type.TypeID]) {
                                                                    edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                    continue;
                                                                }
                                                                if(node_cur_node_c6.isMatched
                                                                    && (node_cur_node_c6==node_cur_node_c1
                                                                        || node_cur_node_c6==node_cur_node_c2
                                                                        || node_cur_node_c6==node_cur_node_c3
                                                                        || node_cur_node_c6==node_cur_node_c4
                                                                        || node_cur_node_c6==node_cur_node_c5
                                                                        )
                                                                    )
                                                                {
                                                                    edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                    continue;
                                                                }
                                                                // Extend outgoing edge__edge8 from node_c5 
                                                                LGSPEdge edge_head_edge__edge8 = node_cur_node_c5.outhead;
                                                                if(edge_head_edge__edge8 != null)
                                                                {
                                                                    LGSPEdge edge_cur_edge__edge8 = edge_head_edge__edge8;
                                                                    do
                                                                    {
                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge8.type.TypeID]) {
                                                                            continue;
                                                                        }
                                                                        if(edge_cur_edge__edge8.target != node_cur_node_c6) {
                                                                            continue;
                                                                        }
                                                                        if(edge_cur_edge__edge8.isMatched
                                                                            && (edge_cur_edge__edge8==edge_cur_edge__edge0
                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge6
                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge1
                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge2
                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge7
                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge3
                                                                                || edge_cur_edge__edge8==edge_cur_edge__edge4
                                                                                )
                                                                            )
                                                                        {
                                                                            continue;
                                                                        }
                                                                        bool edge_cur_edge__edge8_prevIsMatched = edge_cur_edge__edge8.isMatched;
                                                                        edge_cur_edge__edge8.isMatched = true;
                                                                        // Extend outgoing edge__edge5 from node_c6 
                                                                        LGSPEdge edge_head_edge__edge5 = node_cur_node_c6.outhead;
                                                                        if(edge_head_edge__edge5 != null)
                                                                        {
                                                                            LGSPEdge edge_cur_edge__edge5 = edge_head_edge__edge5;
                                                                            do
                                                                            {
                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge5.type.TypeID]) {
                                                                                    continue;
                                                                                }
                                                                                if(edge_cur_edge__edge5.target != node_cur_node_c1) {
                                                                                    continue;
                                                                                }
                                                                                if(edge_cur_edge__edge5.isMatched
                                                                                    && (edge_cur_edge__edge5==edge_cur_edge__edge0
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge6
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge1
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge2
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge7
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge3
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge4
                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge8
                                                                                        )
                                                                                    )
                                                                                {
                                                                                    continue;
                                                                                }
                                                                                // Push subpattern matching task for _subpattern5
                                                                                PatternAction_Nitro taskFor__subpattern5 = new PatternAction_Nitro(graph, openTasks);
                                                                                taskFor__subpattern5.node_anchor = node_cur_node_c6;
                                                                                openTasks.Push(taskFor__subpattern5);
                                                                                // Push subpattern matching task for _subpattern4
                                                                                PatternAction_Hydrogen taskFor__subpattern4 = new PatternAction_Hydrogen(graph, openTasks);
                                                                                taskFor__subpattern4.node_anchor = node_cur_node_c5;
                                                                                openTasks.Push(taskFor__subpattern4);
                                                                                // Push subpattern matching task for _subpattern3
                                                                                PatternAction_Nitro taskFor__subpattern3 = new PatternAction_Nitro(graph, openTasks);
                                                                                taskFor__subpattern3.node_anchor = node_cur_node_c4;
                                                                                openTasks.Push(taskFor__subpattern3);
                                                                                // Push subpattern matching task for _subpattern2
                                                                                PatternAction_Hydrogen taskFor__subpattern2 = new PatternAction_Hydrogen(graph, openTasks);
                                                                                taskFor__subpattern2.node_anchor = node_cur_node_c3;
                                                                                openTasks.Push(taskFor__subpattern2);
                                                                                // Push subpattern matching task for _subpattern1
                                                                                PatternAction_Nitro taskFor__subpattern1 = new PatternAction_Nitro(graph, openTasks);
                                                                                taskFor__subpattern1.node_anchor = node_cur_node_c2;
                                                                                openTasks.Push(taskFor__subpattern1);
                                                                                // Push subpattern matching task for _subpattern0
                                                                                PatternAction_Methyl taskFor__subpattern0 = new PatternAction_Methyl(graph, openTasks);
                                                                                taskFor__subpattern0.node_anchor = node_cur_node_c1;
                                                                                openTasks.Push(taskFor__subpattern0);
                                                                                node_cur_node_c1.isMatchedByEnclosingPattern = true;
                                                                                node_cur_node_c2.isMatchedByEnclosingPattern = true;
                                                                                node_cur_node_c3.isMatchedByEnclosingPattern = true;
                                                                                node_cur_node_c4.isMatchedByEnclosingPattern = true;
                                                                                node_cur_node_c5.isMatchedByEnclosingPattern = true;
                                                                                node_cur_node_c6.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge0.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge1.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge2.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge3.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge4.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge5.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge6.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge7.isMatchedByEnclosingPattern = true;
                                                                                edge_cur_edge__edge8.isMatchedByEnclosingPattern = true;
                                                                                // Match subpatterns
                                                                                openTasks.Peek().myMatch(matchesList, maxMatches - foundPartialMatches.Count);
                                                                                //Pop subpattern matching task for _subpattern0
                                                                                openTasks.Pop();
                                                                                //Pop subpattern matching task for _subpattern1
                                                                                openTasks.Pop();
                                                                                //Pop subpattern matching task for _subpattern2
                                                                                openTasks.Pop();
                                                                                //Pop subpattern matching task for _subpattern3
                                                                                openTasks.Pop();
                                                                                //Pop subpattern matching task for _subpattern4
                                                                                openTasks.Pop();
                                                                                //Pop subpattern matching task for _subpattern5
                                                                                openTasks.Pop();
                                                                                // Check whether subpatterns were found 
                                                                                if(matchesList.Count>0) {
                                                                                    // subpatterns were found, extend the partial matches by our local match object, becoming a complete match object and save it
                                                                                    foreach(Stack<LGSPMatch> currentFoundPartialMatch in matchesList)
                                                                                    {
                                                                                        LGSPMatch match = matches.matchesList.GetEmptyMatchFromList();
                                                                                        match.patternGraph = rulePattern.patternGraph;
                                                                                        match.Nodes[(int)Rule_TNT.NodeNums.@c1] = node_cur_node_c1;
                                                                                        match.Nodes[(int)Rule_TNT.NodeNums.@c2] = node_cur_node_c2;
                                                                                        match.Nodes[(int)Rule_TNT.NodeNums.@c3] = node_cur_node_c3;
                                                                                        match.Nodes[(int)Rule_TNT.NodeNums.@c4] = node_cur_node_c4;
                                                                                        match.Nodes[(int)Rule_TNT.NodeNums.@c5] = node_cur_node_c5;
                                                                                        match.Nodes[(int)Rule_TNT.NodeNums.@c6] = node_cur_node_c6;
                                                                                        match.Edges[(int)Rule_TNT.EdgeNums.@_edge0] = edge_cur_edge__edge0;
                                                                                        match.Edges[(int)Rule_TNT.EdgeNums.@_edge1] = edge_cur_edge__edge1;
                                                                                        match.Edges[(int)Rule_TNT.EdgeNums.@_edge2] = edge_cur_edge__edge2;
                                                                                        match.Edges[(int)Rule_TNT.EdgeNums.@_edge3] = edge_cur_edge__edge3;
                                                                                        match.Edges[(int)Rule_TNT.EdgeNums.@_edge4] = edge_cur_edge__edge4;
                                                                                        match.Edges[(int)Rule_TNT.EdgeNums.@_edge5] = edge_cur_edge__edge5;
                                                                                        match.Edges[(int)Rule_TNT.EdgeNums.@_edge6] = edge_cur_edge__edge6;
                                                                                        match.Edges[(int)Rule_TNT.EdgeNums.@_edge7] = edge_cur_edge__edge7;
                                                                                        match.Edges[(int)Rule_TNT.EdgeNums.@_edge8] = edge_cur_edge__edge8;
                                                                                        match.EmbeddedGraphs[(int)Rule_TNT.PatternNums.@_subpattern0] = currentFoundPartialMatch.Pop();
                                                                                        match.EmbeddedGraphs[(int)Rule_TNT.PatternNums.@_subpattern1] = currentFoundPartialMatch.Pop();
                                                                                        match.EmbeddedGraphs[(int)Rule_TNT.PatternNums.@_subpattern2] = currentFoundPartialMatch.Pop();
                                                                                        match.EmbeddedGraphs[(int)Rule_TNT.PatternNums.@_subpattern3] = currentFoundPartialMatch.Pop();
                                                                                        match.EmbeddedGraphs[(int)Rule_TNT.PatternNums.@_subpattern4] = currentFoundPartialMatch.Pop();
                                                                                        match.EmbeddedGraphs[(int)Rule_TNT.PatternNums.@_subpattern5] = currentFoundPartialMatch.Pop();
                                                                                        matches.matchesList.EmptyMatchWasFilledFixIt();
                                                                                    }
                                                                                    matchesList.Clear();
                                                                                    // if enough matches were found, we leave
                                                                                    if(maxMatches > 0 && matches.matchesList.Count >= maxMatches)
                                                                                    {
                                                                                        edge_cur_edge__edge8.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge7.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge6.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge5.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge4.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge3.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge2.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge1.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                                                                                        node_cur_node_c6.isMatchedByEnclosingPattern = false;
                                                                                        node_cur_node_c5.isMatchedByEnclosingPattern = false;
                                                                                        node_cur_node_c4.isMatchedByEnclosingPattern = false;
                                                                                        node_cur_node_c3.isMatchedByEnclosingPattern = false;
                                                                                        node_cur_node_c2.isMatchedByEnclosingPattern = false;
                                                                                        node_cur_node_c1.isMatchedByEnclosingPattern = false;
                                                                                        edge_cur_edge__edge8.isMatched = edge_cur_edge__edge8_prevIsMatched;
                                                                                        edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                                        node_cur_node_c5.isMatched = node_cur_node_c5_prevIsMatched;
                                                                                        edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                                                        edge_cur_edge__edge7.isMatched = edge_cur_edge__edge7_prevIsMatched;
                                                                                        node_cur_node_c4.isMatched = node_cur_node_c4_prevIsMatched;
                                                                                        edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                                                                        node_cur_node_c3.isMatched = node_cur_node_c3_prevIsMatched;
                                                                                        edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                                                                        edge_cur_edge__edge6.isMatched = edge_cur_edge__edge6_prevIsMatched;
                                                                                        node_cur_node_c2.isMatched = node_cur_node_c2_prevIsMatched;
                                                                                        node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                                                                                        edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                                                                                        return matches;
                                                                                    }
                                                                                    edge_cur_edge__edge8.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge7.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge6.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge5.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge4.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge3.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge2.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge1.isMatchedByEnclosingPattern = false;
                                                                                    edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                                                                                    node_cur_node_c6.isMatchedByEnclosingPattern = false;
                                                                                    node_cur_node_c5.isMatchedByEnclosingPattern = false;
                                                                                    node_cur_node_c4.isMatchedByEnclosingPattern = false;
                                                                                    node_cur_node_c3.isMatchedByEnclosingPattern = false;
                                                                                    node_cur_node_c2.isMatchedByEnclosingPattern = false;
                                                                                    node_cur_node_c1.isMatchedByEnclosingPattern = false;
                                                                                    continue;
                                                                                }
                                                                                node_cur_node_c1.isMatchedByEnclosingPattern = false;
                                                                                node_cur_node_c2.isMatchedByEnclosingPattern = false;
                                                                                node_cur_node_c3.isMatchedByEnclosingPattern = false;
                                                                                node_cur_node_c4.isMatchedByEnclosingPattern = false;
                                                                                node_cur_node_c5.isMatchedByEnclosingPattern = false;
                                                                                node_cur_node_c6.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge0.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge1.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge2.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge3.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge4.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge5.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge6.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge7.isMatchedByEnclosingPattern = false;
                                                                                edge_cur_edge__edge8.isMatchedByEnclosingPattern = false;
                                                                            }
                                                                            while( (edge_cur_edge__edge5 = edge_cur_edge__edge5.outNext) != edge_head_edge__edge5 );
                                                                        }
                                                                        edge_cur_edge__edge8.isMatched = edge_cur_edge__edge8_prevIsMatched;
                                                                    }
                                                                    while( (edge_cur_edge__edge8 = edge_cur_edge__edge8.outNext) != edge_head_edge__edge8 );
                                                                }
                                                                edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                            }
                                                            while( (edge_cur_edge__edge4 = edge_cur_edge__edge4.outNext) != edge_head_edge__edge4 );
                                                        }
                                                        node_cur_node_c5.isMatched = node_cur_node_c5_prevIsMatched;
                                                        edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                    }
                                                    while( (edge_cur_edge__edge3 = edge_cur_edge__edge3.outNext) != edge_head_edge__edge3 );
                                                }
                                                edge_cur_edge__edge7.isMatched = edge_cur_edge__edge7_prevIsMatched;
                                            }
                                            while( (edge_cur_edge__edge7 = edge_cur_edge__edge7.outNext) != edge_head_edge__edge7 );
                                        }
                                        node_cur_node_c4.isMatched = node_cur_node_c4_prevIsMatched;
                                        edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                    }
                                    while( (edge_cur_edge__edge2 = edge_cur_edge__edge2.outNext) != edge_head_edge__edge2 );
                                }
                                node_cur_node_c3.isMatched = node_cur_node_c3_prevIsMatched;
                                edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                            }
                            while( (edge_cur_edge__edge1 = edge_cur_edge__edge1.outNext) != edge_head_edge__edge1 );
                        }
                        edge_cur_edge__edge6.isMatched = edge_cur_edge__edge6_prevIsMatched;
                    }
                    while( (edge_cur_edge__edge6 = edge_cur_edge__edge6.outNext) != edge_head_edge__edge6 );
                }
                node_cur_node_c2.isMatched = node_cur_node_c2_prevIsMatched;
                node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
            }
            return matches;
        }
	}
	public class Action_TNTUnfolded : LGSPAction
	{
		public Action_TNTUnfolded() {
			rulePattern = Rule_TNTUnfolded.Instance;
			DynamicMatch = myMatch; matches = new LGSPMatches(this, 21, 24, 0);
		}

		public override string Name { get { return "TNTUnfolded"; } }
		private LGSPMatches matches;

		public static LGSPAction Instance { get { return instance; } }
		private static Action_TNTUnfolded instance = new Action_TNTUnfolded();

        public LGSPMatches myMatch(LGSPGraph graph, int maxMatches, IGraphElement[] parameters)
        {
            matches.matchesList.Clear();
            // Lookup edge__edge0 
            int edge_type_id_edge__edge0 = 2;
            for(LGSPEdge edge_head_edge__edge0 = graph.edgesByTypeHeads[edge_type_id_edge__edge0], edge_cur_edge__edge0 = edge_head_edge__edge0.typeNext; edge_cur_edge__edge0 != edge_head_edge__edge0; edge_cur_edge__edge0 = edge_cur_edge__edge0.typeNext)
            {
                bool edge_cur_edge__edge0_prevIsMatched = edge_cur_edge__edge0.isMatched;
                edge_cur_edge__edge0.isMatched = true;
                // Implicit source node_c1 from edge__edge0 
                LGSPNode node_cur_node_c1 = edge_cur_edge__edge0.source;
                if(!NodeType_C.isMyType[node_cur_node_c1.type.TypeID]) {
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                    continue;
                }
                bool node_cur_node_c1_prevIsMatched = node_cur_node_c1.isMatched;
                node_cur_node_c1.isMatched = true;
                // Implicit target node_c2 from edge__edge0 
                LGSPNode node_cur_node_c2 = edge_cur_edge__edge0.target;
                if(!NodeType_C.isMyType[node_cur_node_c2.type.TypeID]) {
                    node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                    continue;
                }
                if(node_cur_node_c2.isMatched
                    && node_cur_node_c2==node_cur_node_c1
                    )
                {
                    node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                    edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                    continue;
                }
                bool node_cur_node_c2_prevIsMatched = node_cur_node_c2.isMatched;
                node_cur_node_c2.isMatched = true;
                // Extend outgoing edge__edge6 from node_c1 
                LGSPEdge edge_head_edge__edge6 = node_cur_node_c1.outhead;
                if(edge_head_edge__edge6 != null)
                {
                    LGSPEdge edge_cur_edge__edge6 = edge_head_edge__edge6;
                    do
                    {
                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge6.type.TypeID]) {
                            continue;
                        }
                        if(edge_cur_edge__edge6.target != node_cur_node_c2) {
                            continue;
                        }
                        if(edge_cur_edge__edge6.isMatched
                            && edge_cur_edge__edge6==edge_cur_edge__edge0
                            )
                        {
                            continue;
                        }
                        bool edge_cur_edge__edge6_prevIsMatched = edge_cur_edge__edge6.isMatched;
                        edge_cur_edge__edge6.isMatched = true;
                        // Extend outgoing edge__edge9 from node_c1 
                        LGSPEdge edge_head_edge__edge9 = node_cur_node_c1.outhead;
                        if(edge_head_edge__edge9 != null)
                        {
                            LGSPEdge edge_cur_edge__edge9 = edge_head_edge__edge9;
                            do
                            {
                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge9.type.TypeID]) {
                                    continue;
                                }
                                if(edge_cur_edge__edge9.isMatched
                                    && (edge_cur_edge__edge9==edge_cur_edge__edge0
                                        || edge_cur_edge__edge9==edge_cur_edge__edge6
                                        )
                                    )
                                {
                                    continue;
                                }
                                bool edge_cur_edge__edge9_prevIsMatched = edge_cur_edge__edge9.isMatched;
                                edge_cur_edge__edge9.isMatched = true;
                                // Implicit target node_c from edge__edge9 
                                LGSPNode node_cur_node_c = edge_cur_edge__edge9.target;
                                if(!NodeType_C.isMyType[node_cur_node_c.type.TypeID]) {
                                    edge_cur_edge__edge9.isMatched = edge_cur_edge__edge9_prevIsMatched;
                                    continue;
                                }
                                if(node_cur_node_c.isMatched
                                    && (node_cur_node_c==node_cur_node_c1
                                        || node_cur_node_c==node_cur_node_c2
                                        )
                                    )
                                {
                                    edge_cur_edge__edge9.isMatched = edge_cur_edge__edge9_prevIsMatched;
                                    continue;
                                }
                                bool node_cur_node_c_prevIsMatched = node_cur_node_c.isMatched;
                                node_cur_node_c.isMatched = true;
                                // Extend outgoing edge__edge1 from node_c2 
                                LGSPEdge edge_head_edge__edge1 = node_cur_node_c2.outhead;
                                if(edge_head_edge__edge1 != null)
                                {
                                    LGSPEdge edge_cur_edge__edge1 = edge_head_edge__edge1;
                                    do
                                    {
                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge1.type.TypeID]) {
                                            continue;
                                        }
                                        if(edge_cur_edge__edge1.isMatched
                                            && (edge_cur_edge__edge1==edge_cur_edge__edge0
                                                || edge_cur_edge__edge1==edge_cur_edge__edge6
                                                || edge_cur_edge__edge1==edge_cur_edge__edge9
                                                )
                                            )
                                        {
                                            continue;
                                        }
                                        bool edge_cur_edge__edge1_prevIsMatched = edge_cur_edge__edge1.isMatched;
                                        edge_cur_edge__edge1.isMatched = true;
                                        // Implicit target node_c3 from edge__edge1 
                                        LGSPNode node_cur_node_c3 = edge_cur_edge__edge1.target;
                                        if(!NodeType_C.isMyType[node_cur_node_c3.type.TypeID]) {
                                            edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                            continue;
                                        }
                                        if(node_cur_node_c3.isMatched
                                            && (node_cur_node_c3==node_cur_node_c1
                                                || node_cur_node_c3==node_cur_node_c2
                                                || node_cur_node_c3==node_cur_node_c
                                                )
                                            )
                                        {
                                            edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                            continue;
                                        }
                                        bool node_cur_node_c3_prevIsMatched = node_cur_node_c3.isMatched;
                                        node_cur_node_c3.isMatched = true;
                                        // Extend outgoing edge__edge13 from node_c2 
                                        LGSPEdge edge_head_edge__edge13 = node_cur_node_c2.outhead;
                                        if(edge_head_edge__edge13 != null)
                                        {
                                            LGSPEdge edge_cur_edge__edge13 = edge_head_edge__edge13;
                                            do
                                            {
                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge13.type.TypeID]) {
                                                    continue;
                                                }
                                                if(edge_cur_edge__edge13.isMatched
                                                    && (edge_cur_edge__edge13==edge_cur_edge__edge0
                                                        || edge_cur_edge__edge13==edge_cur_edge__edge6
                                                        || edge_cur_edge__edge13==edge_cur_edge__edge9
                                                        || edge_cur_edge__edge13==edge_cur_edge__edge1
                                                        )
                                                    )
                                                {
                                                    continue;
                                                }
                                                bool edge_cur_edge__edge13_prevIsMatched = edge_cur_edge__edge13.isMatched;
                                                edge_cur_edge__edge13.isMatched = true;
                                                // Implicit target node_n2 from edge__edge13 
                                                LGSPNode node_cur_node_n2 = edge_cur_edge__edge13.target;
                                                if(!NodeType_N.isMyType[node_cur_node_n2.type.TypeID]) {
                                                    edge_cur_edge__edge13.isMatched = edge_cur_edge__edge13_prevIsMatched;
                                                    continue;
                                                }
                                                bool node_cur_node_n2_prevIsMatched = node_cur_node_n2.isMatched;
                                                node_cur_node_n2.isMatched = true;
                                                // Extend outgoing edge__edge10 from node_c 
                                                LGSPEdge edge_head_edge__edge10 = node_cur_node_c.outhead;
                                                if(edge_head_edge__edge10 != null)
                                                {
                                                    LGSPEdge edge_cur_edge__edge10 = edge_head_edge__edge10;
                                                    do
                                                    {
                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge10.type.TypeID]) {
                                                            continue;
                                                        }
                                                        if(edge_cur_edge__edge10.isMatched
                                                            && (edge_cur_edge__edge10==edge_cur_edge__edge0
                                                                || edge_cur_edge__edge10==edge_cur_edge__edge6
                                                                || edge_cur_edge__edge10==edge_cur_edge__edge9
                                                                || edge_cur_edge__edge10==edge_cur_edge__edge1
                                                                || edge_cur_edge__edge10==edge_cur_edge__edge13
                                                                )
                                                            )
                                                        {
                                                            continue;
                                                        }
                                                        bool edge_cur_edge__edge10_prevIsMatched = edge_cur_edge__edge10.isMatched;
                                                        edge_cur_edge__edge10.isMatched = true;
                                                        // Implicit target node__node0 from edge__edge10 
                                                        LGSPNode node_cur_node__node0 = edge_cur_edge__edge10.target;
                                                        if(!NodeType_H.isMyType[node_cur_node__node0.type.TypeID]) {
                                                            edge_cur_edge__edge10.isMatched = edge_cur_edge__edge10_prevIsMatched;
                                                            continue;
                                                        }
                                                        bool node_cur_node__node0_prevIsMatched = node_cur_node__node0.isMatched;
                                                        node_cur_node__node0.isMatched = true;
                                                        // Extend outgoing edge__edge11 from node_c 
                                                        LGSPEdge edge_head_edge__edge11 = node_cur_node_c.outhead;
                                                        if(edge_head_edge__edge11 != null)
                                                        {
                                                            LGSPEdge edge_cur_edge__edge11 = edge_head_edge__edge11;
                                                            do
                                                            {
                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge11.type.TypeID]) {
                                                                    continue;
                                                                }
                                                                if(edge_cur_edge__edge11.isMatched
                                                                    && (edge_cur_edge__edge11==edge_cur_edge__edge0
                                                                        || edge_cur_edge__edge11==edge_cur_edge__edge6
                                                                        || edge_cur_edge__edge11==edge_cur_edge__edge9
                                                                        || edge_cur_edge__edge11==edge_cur_edge__edge1
                                                                        || edge_cur_edge__edge11==edge_cur_edge__edge13
                                                                        || edge_cur_edge__edge11==edge_cur_edge__edge10
                                                                        )
                                                                    )
                                                                {
                                                                    continue;
                                                                }
                                                                bool edge_cur_edge__edge11_prevIsMatched = edge_cur_edge__edge11.isMatched;
                                                                edge_cur_edge__edge11.isMatched = true;
                                                                // Implicit target node__node1 from edge__edge11 
                                                                LGSPNode node_cur_node__node1 = edge_cur_edge__edge11.target;
                                                                if(!NodeType_H.isMyType[node_cur_node__node1.type.TypeID]) {
                                                                    edge_cur_edge__edge11.isMatched = edge_cur_edge__edge11_prevIsMatched;
                                                                    continue;
                                                                }
                                                                if(node_cur_node__node1.isMatched
                                                                    && node_cur_node__node1==node_cur_node__node0
                                                                    )
                                                                {
                                                                    edge_cur_edge__edge11.isMatched = edge_cur_edge__edge11_prevIsMatched;
                                                                    continue;
                                                                }
                                                                bool node_cur_node__node1_prevIsMatched = node_cur_node__node1.isMatched;
                                                                node_cur_node__node1.isMatched = true;
                                                                // Extend outgoing edge__edge12 from node_c 
                                                                LGSPEdge edge_head_edge__edge12 = node_cur_node_c.outhead;
                                                                if(edge_head_edge__edge12 != null)
                                                                {
                                                                    LGSPEdge edge_cur_edge__edge12 = edge_head_edge__edge12;
                                                                    do
                                                                    {
                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge12.type.TypeID]) {
                                                                            continue;
                                                                        }
                                                                        if(edge_cur_edge__edge12.isMatched
                                                                            && (edge_cur_edge__edge12==edge_cur_edge__edge0
                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge6
                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge9
                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge1
                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge13
                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge10
                                                                                || edge_cur_edge__edge12==edge_cur_edge__edge11
                                                                                )
                                                                            )
                                                                        {
                                                                            continue;
                                                                        }
                                                                        bool edge_cur_edge__edge12_prevIsMatched = edge_cur_edge__edge12.isMatched;
                                                                        edge_cur_edge__edge12.isMatched = true;
                                                                        // Implicit target node__node2 from edge__edge12 
                                                                        LGSPNode node_cur_node__node2 = edge_cur_edge__edge12.target;
                                                                        if(!NodeType_H.isMyType[node_cur_node__node2.type.TypeID]) {
                                                                            edge_cur_edge__edge12.isMatched = edge_cur_edge__edge12_prevIsMatched;
                                                                            continue;
                                                                        }
                                                                        if(node_cur_node__node2.isMatched
                                                                            && (node_cur_node__node2==node_cur_node__node0
                                                                                || node_cur_node__node2==node_cur_node__node1
                                                                                )
                                                                            )
                                                                        {
                                                                            edge_cur_edge__edge12.isMatched = edge_cur_edge__edge12_prevIsMatched;
                                                                            continue;
                                                                        }
                                                                        bool node_cur_node__node2_prevIsMatched = node_cur_node__node2.isMatched;
                                                                        node_cur_node__node2.isMatched = true;
                                                                        // Extend outgoing edge__edge2 from node_c3 
                                                                        LGSPEdge edge_head_edge__edge2 = node_cur_node_c3.outhead;
                                                                        if(edge_head_edge__edge2 != null)
                                                                        {
                                                                            LGSPEdge edge_cur_edge__edge2 = edge_head_edge__edge2;
                                                                            do
                                                                            {
                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge2.type.TypeID]) {
                                                                                    continue;
                                                                                }
                                                                                if(edge_cur_edge__edge2.isMatched
                                                                                    && (edge_cur_edge__edge2==edge_cur_edge__edge0
                                                                                        || edge_cur_edge__edge2==edge_cur_edge__edge6
                                                                                        || edge_cur_edge__edge2==edge_cur_edge__edge9
                                                                                        || edge_cur_edge__edge2==edge_cur_edge__edge1
                                                                                        || edge_cur_edge__edge2==edge_cur_edge__edge13
                                                                                        || edge_cur_edge__edge2==edge_cur_edge__edge10
                                                                                        || edge_cur_edge__edge2==edge_cur_edge__edge11
                                                                                        || edge_cur_edge__edge2==edge_cur_edge__edge12
                                                                                        )
                                                                                    )
                                                                                {
                                                                                    continue;
                                                                                }
                                                                                bool edge_cur_edge__edge2_prevIsMatched = edge_cur_edge__edge2.isMatched;
                                                                                edge_cur_edge__edge2.isMatched = true;
                                                                                // Implicit target node_c4 from edge__edge2 
                                                                                LGSPNode node_cur_node_c4 = edge_cur_edge__edge2.target;
                                                                                if(!NodeType_C.isMyType[node_cur_node_c4.type.TypeID]) {
                                                                                    edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                                                                    continue;
                                                                                }
                                                                                if(node_cur_node_c4.isMatched
                                                                                    && (node_cur_node_c4==node_cur_node_c1
                                                                                        || node_cur_node_c4==node_cur_node_c2
                                                                                        || node_cur_node_c4==node_cur_node_c
                                                                                        || node_cur_node_c4==node_cur_node_c3
                                                                                        )
                                                                                    )
                                                                                {
                                                                                    edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                                                                    continue;
                                                                                }
                                                                                bool node_cur_node_c4_prevIsMatched = node_cur_node_c4.isMatched;
                                                                                node_cur_node_c4.isMatched = true;
                                                                                // Extend outgoing edge__edge7 from node_c3 
                                                                                LGSPEdge edge_head_edge__edge7 = node_cur_node_c3.outhead;
                                                                                if(edge_head_edge__edge7 != null)
                                                                                {
                                                                                    LGSPEdge edge_cur_edge__edge7 = edge_head_edge__edge7;
                                                                                    do
                                                                                    {
                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge7.type.TypeID]) {
                                                                                            continue;
                                                                                        }
                                                                                        if(edge_cur_edge__edge7.target != node_cur_node_c4) {
                                                                                            continue;
                                                                                        }
                                                                                        if(edge_cur_edge__edge7.isMatched
                                                                                            && (edge_cur_edge__edge7==edge_cur_edge__edge0
                                                                                                || edge_cur_edge__edge7==edge_cur_edge__edge6
                                                                                                || edge_cur_edge__edge7==edge_cur_edge__edge9
                                                                                                || edge_cur_edge__edge7==edge_cur_edge__edge1
                                                                                                || edge_cur_edge__edge7==edge_cur_edge__edge13
                                                                                                || edge_cur_edge__edge7==edge_cur_edge__edge10
                                                                                                || edge_cur_edge__edge7==edge_cur_edge__edge11
                                                                                                || edge_cur_edge__edge7==edge_cur_edge__edge12
                                                                                                || edge_cur_edge__edge7==edge_cur_edge__edge2
                                                                                                )
                                                                                            )
                                                                                        {
                                                                                            continue;
                                                                                        }
                                                                                        bool edge_cur_edge__edge7_prevIsMatched = edge_cur_edge__edge7.isMatched;
                                                                                        edge_cur_edge__edge7.isMatched = true;
                                                                                        // Extend outgoing edge__edge16 from node_c3 
                                                                                        LGSPEdge edge_head_edge__edge16 = node_cur_node_c3.outhead;
                                                                                        if(edge_head_edge__edge16 != null)
                                                                                        {
                                                                                            LGSPEdge edge_cur_edge__edge16 = edge_head_edge__edge16;
                                                                                            do
                                                                                            {
                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge16.type.TypeID]) {
                                                                                                    continue;
                                                                                                }
                                                                                                if(edge_cur_edge__edge16.isMatched
                                                                                                    && (edge_cur_edge__edge16==edge_cur_edge__edge0
                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge6
                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge9
                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge1
                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge13
                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge10
                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge11
                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge12
                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge2
                                                                                                        || edge_cur_edge__edge16==edge_cur_edge__edge7
                                                                                                        )
                                                                                                    )
                                                                                                {
                                                                                                    continue;
                                                                                                }
                                                                                                bool edge_cur_edge__edge16_prevIsMatched = edge_cur_edge__edge16.isMatched;
                                                                                                edge_cur_edge__edge16.isMatched = true;
                                                                                                // Implicit target node__node5 from edge__edge16 
                                                                                                LGSPNode node_cur_node__node5 = edge_cur_edge__edge16.target;
                                                                                                if(!NodeType_H.isMyType[node_cur_node__node5.type.TypeID]) {
                                                                                                    edge_cur_edge__edge16.isMatched = edge_cur_edge__edge16_prevIsMatched;
                                                                                                    continue;
                                                                                                }
                                                                                                if(node_cur_node__node5.isMatched
                                                                                                    && (node_cur_node__node5==node_cur_node__node0
                                                                                                        || node_cur_node__node5==node_cur_node__node1
                                                                                                        || node_cur_node__node5==node_cur_node__node2
                                                                                                        )
                                                                                                    )
                                                                                                {
                                                                                                    edge_cur_edge__edge16.isMatched = edge_cur_edge__edge16_prevIsMatched;
                                                                                                    continue;
                                                                                                }
                                                                                                bool node_cur_node__node5_prevIsMatched = node_cur_node__node5.isMatched;
                                                                                                node_cur_node__node5.isMatched = true;
                                                                                                // Extend outgoing edge__edge14 from node_n2 
                                                                                                LGSPEdge edge_head_edge__edge14 = node_cur_node_n2.outhead;
                                                                                                if(edge_head_edge__edge14 != null)
                                                                                                {
                                                                                                    LGSPEdge edge_cur_edge__edge14 = edge_head_edge__edge14;
                                                                                                    do
                                                                                                    {
                                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge14.type.TypeID]) {
                                                                                                            continue;
                                                                                                        }
                                                                                                        if(edge_cur_edge__edge14.isMatched
                                                                                                            && (edge_cur_edge__edge14==edge_cur_edge__edge0
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge6
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge9
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge1
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge13
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge10
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge11
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge12
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge2
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge7
                                                                                                                || edge_cur_edge__edge14==edge_cur_edge__edge16
                                                                                                                )
                                                                                                            )
                                                                                                        {
                                                                                                            continue;
                                                                                                        }
                                                                                                        bool edge_cur_edge__edge14_prevIsMatched = edge_cur_edge__edge14.isMatched;
                                                                                                        edge_cur_edge__edge14.isMatched = true;
                                                                                                        // Implicit target node__node3 from edge__edge14 
                                                                                                        LGSPNode node_cur_node__node3 = edge_cur_edge__edge14.target;
                                                                                                        if(!NodeType_O.isMyType[node_cur_node__node3.type.TypeID]) {
                                                                                                            edge_cur_edge__edge14.isMatched = edge_cur_edge__edge14_prevIsMatched;
                                                                                                            continue;
                                                                                                        }
                                                                                                        bool node_cur_node__node3_prevIsMatched = node_cur_node__node3.isMatched;
                                                                                                        node_cur_node__node3.isMatched = true;
                                                                                                        // Extend outgoing edge__edge15 from node_n2 
                                                                                                        LGSPEdge edge_head_edge__edge15 = node_cur_node_n2.outhead;
                                                                                                        if(edge_head_edge__edge15 != null)
                                                                                                        {
                                                                                                            LGSPEdge edge_cur_edge__edge15 = edge_head_edge__edge15;
                                                                                                            do
                                                                                                            {
                                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge15.type.TypeID]) {
                                                                                                                    continue;
                                                                                                                }
                                                                                                                if(edge_cur_edge__edge15.isMatched
                                                                                                                    && (edge_cur_edge__edge15==edge_cur_edge__edge0
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge6
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge9
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge1
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge13
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge10
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge11
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge12
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge2
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge7
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge16
                                                                                                                        || edge_cur_edge__edge15==edge_cur_edge__edge14
                                                                                                                        )
                                                                                                                    )
                                                                                                                {
                                                                                                                    continue;
                                                                                                                }
                                                                                                                bool edge_cur_edge__edge15_prevIsMatched = edge_cur_edge__edge15.isMatched;
                                                                                                                edge_cur_edge__edge15.isMatched = true;
                                                                                                                // Implicit target node__node4 from edge__edge15 
                                                                                                                LGSPNode node_cur_node__node4 = edge_cur_edge__edge15.target;
                                                                                                                if(!NodeType_O.isMyType[node_cur_node__node4.type.TypeID]) {
                                                                                                                    edge_cur_edge__edge15.isMatched = edge_cur_edge__edge15_prevIsMatched;
                                                                                                                    continue;
                                                                                                                }
                                                                                                                if(node_cur_node__node4.isMatched
                                                                                                                    && node_cur_node__node4==node_cur_node__node3
                                                                                                                    )
                                                                                                                {
                                                                                                                    edge_cur_edge__edge15.isMatched = edge_cur_edge__edge15_prevIsMatched;
                                                                                                                    continue;
                                                                                                                }
                                                                                                                bool node_cur_node__node4_prevIsMatched = node_cur_node__node4.isMatched;
                                                                                                                node_cur_node__node4.isMatched = true;
                                                                                                                // Extend outgoing edge__edge3 from node_c4 
                                                                                                                LGSPEdge edge_head_edge__edge3 = node_cur_node_c4.outhead;
                                                                                                                if(edge_head_edge__edge3 != null)
                                                                                                                {
                                                                                                                    LGSPEdge edge_cur_edge__edge3 = edge_head_edge__edge3;
                                                                                                                    do
                                                                                                                    {
                                                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge3.type.TypeID]) {
                                                                                                                            continue;
                                                                                                                        }
                                                                                                                        if(edge_cur_edge__edge3.isMatched
                                                                                                                            && (edge_cur_edge__edge3==edge_cur_edge__edge0
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge6
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge9
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge1
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge13
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge10
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge11
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge12
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge2
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge7
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge16
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge14
                                                                                                                                || edge_cur_edge__edge3==edge_cur_edge__edge15
                                                                                                                                )
                                                                                                                            )
                                                                                                                        {
                                                                                                                            continue;
                                                                                                                        }
                                                                                                                        bool edge_cur_edge__edge3_prevIsMatched = edge_cur_edge__edge3.isMatched;
                                                                                                                        edge_cur_edge__edge3.isMatched = true;
                                                                                                                        // Implicit target node_c5 from edge__edge3 
                                                                                                                        LGSPNode node_cur_node_c5 = edge_cur_edge__edge3.target;
                                                                                                                        if(!NodeType_C.isMyType[node_cur_node_c5.type.TypeID]) {
                                                                                                                            edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                                                                                            continue;
                                                                                                                        }
                                                                                                                        if(node_cur_node_c5.isMatched
                                                                                                                            && (node_cur_node_c5==node_cur_node_c1
                                                                                                                                || node_cur_node_c5==node_cur_node_c2
                                                                                                                                || node_cur_node_c5==node_cur_node_c
                                                                                                                                || node_cur_node_c5==node_cur_node_c3
                                                                                                                                || node_cur_node_c5==node_cur_node_c4
                                                                                                                                )
                                                                                                                            )
                                                                                                                        {
                                                                                                                            edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                                                                                            continue;
                                                                                                                        }
                                                                                                                        bool node_cur_node_c5_prevIsMatched = node_cur_node_c5.isMatched;
                                                                                                                        node_cur_node_c5.isMatched = true;
                                                                                                                        // Extend outgoing edge__edge17 from node_c4 
                                                                                                                        LGSPEdge edge_head_edge__edge17 = node_cur_node_c4.outhead;
                                                                                                                        if(edge_head_edge__edge17 != null)
                                                                                                                        {
                                                                                                                            LGSPEdge edge_cur_edge__edge17 = edge_head_edge__edge17;
                                                                                                                            do
                                                                                                                            {
                                                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge17.type.TypeID]) {
                                                                                                                                    continue;
                                                                                                                                }
                                                                                                                                if(edge_cur_edge__edge17.isMatched
                                                                                                                                    && (edge_cur_edge__edge17==edge_cur_edge__edge0
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge6
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge9
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge1
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge13
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge10
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge11
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge12
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge2
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge7
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge16
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge14
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge15
                                                                                                                                        || edge_cur_edge__edge17==edge_cur_edge__edge3
                                                                                                                                        )
                                                                                                                                    )
                                                                                                                                {
                                                                                                                                    continue;
                                                                                                                                }
                                                                                                                                bool edge_cur_edge__edge17_prevIsMatched = edge_cur_edge__edge17.isMatched;
                                                                                                                                edge_cur_edge__edge17.isMatched = true;
                                                                                                                                // Implicit target node_n4 from edge__edge17 
                                                                                                                                LGSPNode node_cur_node_n4 = edge_cur_edge__edge17.target;
                                                                                                                                if(!NodeType_N.isMyType[node_cur_node_n4.type.TypeID]) {
                                                                                                                                    edge_cur_edge__edge17.isMatched = edge_cur_edge__edge17_prevIsMatched;
                                                                                                                                    continue;
                                                                                                                                }
                                                                                                                                if(node_cur_node_n4.isMatched
                                                                                                                                    && node_cur_node_n4==node_cur_node_n2
                                                                                                                                    )
                                                                                                                                {
                                                                                                                                    edge_cur_edge__edge17.isMatched = edge_cur_edge__edge17_prevIsMatched;
                                                                                                                                    continue;
                                                                                                                                }
                                                                                                                                bool node_cur_node_n4_prevIsMatched = node_cur_node_n4.isMatched;
                                                                                                                                node_cur_node_n4.isMatched = true;
                                                                                                                                // Extend outgoing edge__edge4 from node_c5 
                                                                                                                                LGSPEdge edge_head_edge__edge4 = node_cur_node_c5.outhead;
                                                                                                                                if(edge_head_edge__edge4 != null)
                                                                                                                                {
                                                                                                                                    LGSPEdge edge_cur_edge__edge4 = edge_head_edge__edge4;
                                                                                                                                    do
                                                                                                                                    {
                                                                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge4.type.TypeID]) {
                                                                                                                                            continue;
                                                                                                                                        }
                                                                                                                                        if(edge_cur_edge__edge4.isMatched
                                                                                                                                            && (edge_cur_edge__edge4==edge_cur_edge__edge0
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge6
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge9
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge1
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge13
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge10
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge11
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge12
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge2
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge7
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge16
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge14
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge15
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge3
                                                                                                                                                || edge_cur_edge__edge4==edge_cur_edge__edge17
                                                                                                                                                )
                                                                                                                                            )
                                                                                                                                        {
                                                                                                                                            continue;
                                                                                                                                        }
                                                                                                                                        bool edge_cur_edge__edge4_prevIsMatched = edge_cur_edge__edge4.isMatched;
                                                                                                                                        edge_cur_edge__edge4.isMatched = true;
                                                                                                                                        // Implicit target node_c6 from edge__edge4 
                                                                                                                                        LGSPNode node_cur_node_c6 = edge_cur_edge__edge4.target;
                                                                                                                                        if(!NodeType_C.isMyType[node_cur_node_c6.type.TypeID]) {
                                                                                                                                            edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                                                                                            continue;
                                                                                                                                        }
                                                                                                                                        if(node_cur_node_c6.isMatched
                                                                                                                                            && (node_cur_node_c6==node_cur_node_c1
                                                                                                                                                || node_cur_node_c6==node_cur_node_c2
                                                                                                                                                || node_cur_node_c6==node_cur_node_c
                                                                                                                                                || node_cur_node_c6==node_cur_node_c3
                                                                                                                                                || node_cur_node_c6==node_cur_node_c4
                                                                                                                                                || node_cur_node_c6==node_cur_node_c5
                                                                                                                                                )
                                                                                                                                            )
                                                                                                                                        {
                                                                                                                                            edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                                                                                            continue;
                                                                                                                                        }
                                                                                                                                        // Extend outgoing edge__edge8 from node_c5 
                                                                                                                                        LGSPEdge edge_head_edge__edge8 = node_cur_node_c5.outhead;
                                                                                                                                        if(edge_head_edge__edge8 != null)
                                                                                                                                        {
                                                                                                                                            LGSPEdge edge_cur_edge__edge8 = edge_head_edge__edge8;
                                                                                                                                            do
                                                                                                                                            {
                                                                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge8.type.TypeID]) {
                                                                                                                                                    continue;
                                                                                                                                                }
                                                                                                                                                if(edge_cur_edge__edge8.target != node_cur_node_c6) {
                                                                                                                                                    continue;
                                                                                                                                                }
                                                                                                                                                if(edge_cur_edge__edge8.isMatched
                                                                                                                                                    && (edge_cur_edge__edge8==edge_cur_edge__edge0
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge6
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge9
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge1
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge13
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge10
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge11
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge12
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge2
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge7
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge16
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge14
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge15
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge3
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge17
                                                                                                                                                        || edge_cur_edge__edge8==edge_cur_edge__edge4
                                                                                                                                                        )
                                                                                                                                                    )
                                                                                                                                                {
                                                                                                                                                    continue;
                                                                                                                                                }
                                                                                                                                                bool edge_cur_edge__edge8_prevIsMatched = edge_cur_edge__edge8.isMatched;
                                                                                                                                                edge_cur_edge__edge8.isMatched = true;
                                                                                                                                                // Extend outgoing edge__edge20 from node_c5 
                                                                                                                                                LGSPEdge edge_head_edge__edge20 = node_cur_node_c5.outhead;
                                                                                                                                                if(edge_head_edge__edge20 != null)
                                                                                                                                                {
                                                                                                                                                    LGSPEdge edge_cur_edge__edge20 = edge_head_edge__edge20;
                                                                                                                                                    do
                                                                                                                                                    {
                                                                                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge20.type.TypeID]) {
                                                                                                                                                            continue;
                                                                                                                                                        }
                                                                                                                                                        if(edge_cur_edge__edge20.isMatched
                                                                                                                                                            && (edge_cur_edge__edge20==edge_cur_edge__edge0
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge6
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge9
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge1
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge13
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge10
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge11
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge12
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge2
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge7
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge16
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge14
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge15
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge3
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge17
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge4
                                                                                                                                                                || edge_cur_edge__edge20==edge_cur_edge__edge8
                                                                                                                                                                )
                                                                                                                                                            )
                                                                                                                                                        {
                                                                                                                                                            continue;
                                                                                                                                                        }
                                                                                                                                                        bool edge_cur_edge__edge20_prevIsMatched = edge_cur_edge__edge20.isMatched;
                                                                                                                                                        edge_cur_edge__edge20.isMatched = true;
                                                                                                                                                        // Implicit target node__node8 from edge__edge20 
                                                                                                                                                        LGSPNode node_cur_node__node8 = edge_cur_edge__edge20.target;
                                                                                                                                                        if(!NodeType_H.isMyType[node_cur_node__node8.type.TypeID]) {
                                                                                                                                                            edge_cur_edge__edge20.isMatched = edge_cur_edge__edge20_prevIsMatched;
                                                                                                                                                            continue;
                                                                                                                                                        }
                                                                                                                                                        if(node_cur_node__node8.isMatched
                                                                                                                                                            && (node_cur_node__node8==node_cur_node__node0
                                                                                                                                                                || node_cur_node__node8==node_cur_node__node1
                                                                                                                                                                || node_cur_node__node8==node_cur_node__node2
                                                                                                                                                                || node_cur_node__node8==node_cur_node__node5
                                                                                                                                                                )
                                                                                                                                                            )
                                                                                                                                                        {
                                                                                                                                                            edge_cur_edge__edge20.isMatched = edge_cur_edge__edge20_prevIsMatched;
                                                                                                                                                            continue;
                                                                                                                                                        }
                                                                                                                                                        // Extend outgoing edge__edge18 from node_n4 
                                                                                                                                                        LGSPEdge edge_head_edge__edge18 = node_cur_node_n4.outhead;
                                                                                                                                                        if(edge_head_edge__edge18 != null)
                                                                                                                                                        {
                                                                                                                                                            LGSPEdge edge_cur_edge__edge18 = edge_head_edge__edge18;
                                                                                                                                                            do
                                                                                                                                                            {
                                                                                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge18.type.TypeID]) {
                                                                                                                                                                    continue;
                                                                                                                                                                }
                                                                                                                                                                if(edge_cur_edge__edge18.isMatched
                                                                                                                                                                    && (edge_cur_edge__edge18==edge_cur_edge__edge0
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge6
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge9
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge1
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge13
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge10
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge11
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge12
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge2
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge7
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge16
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge14
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge15
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge3
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge17
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge4
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge8
                                                                                                                                                                        || edge_cur_edge__edge18==edge_cur_edge__edge20
                                                                                                                                                                        )
                                                                                                                                                                    )
                                                                                                                                                                {
                                                                                                                                                                    continue;
                                                                                                                                                                }
                                                                                                                                                                bool edge_cur_edge__edge18_prevIsMatched = edge_cur_edge__edge18.isMatched;
                                                                                                                                                                edge_cur_edge__edge18.isMatched = true;
                                                                                                                                                                // Implicit target node__node6 from edge__edge18 
                                                                                                                                                                LGSPNode node_cur_node__node6 = edge_cur_edge__edge18.target;
                                                                                                                                                                if(!NodeType_O.isMyType[node_cur_node__node6.type.TypeID]) {
                                                                                                                                                                    edge_cur_edge__edge18.isMatched = edge_cur_edge__edge18_prevIsMatched;
                                                                                                                                                                    continue;
                                                                                                                                                                }
                                                                                                                                                                if(node_cur_node__node6.isMatched
                                                                                                                                                                    && (node_cur_node__node6==node_cur_node__node3
                                                                                                                                                                        || node_cur_node__node6==node_cur_node__node4
                                                                                                                                                                        )
                                                                                                                                                                    )
                                                                                                                                                                {
                                                                                                                                                                    edge_cur_edge__edge18.isMatched = edge_cur_edge__edge18_prevIsMatched;
                                                                                                                                                                    continue;
                                                                                                                                                                }
                                                                                                                                                                bool node_cur_node__node6_prevIsMatched = node_cur_node__node6.isMatched;
                                                                                                                                                                node_cur_node__node6.isMatched = true;
                                                                                                                                                                // Extend outgoing edge__edge19 from node_n4 
                                                                                                                                                                LGSPEdge edge_head_edge__edge19 = node_cur_node_n4.outhead;
                                                                                                                                                                if(edge_head_edge__edge19 != null)
                                                                                                                                                                {
                                                                                                                                                                    LGSPEdge edge_cur_edge__edge19 = edge_head_edge__edge19;
                                                                                                                                                                    do
                                                                                                                                                                    {
                                                                                                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge19.type.TypeID]) {
                                                                                                                                                                            continue;
                                                                                                                                                                        }
                                                                                                                                                                        if(edge_cur_edge__edge19.isMatched
                                                                                                                                                                            && (edge_cur_edge__edge19==edge_cur_edge__edge0
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge6
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge9
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge1
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge13
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge10
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge11
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge12
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge2
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge7
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge16
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge14
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge15
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge3
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge17
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge4
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge8
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge20
                                                                                                                                                                                || edge_cur_edge__edge19==edge_cur_edge__edge18
                                                                                                                                                                                )
                                                                                                                                                                            )
                                                                                                                                                                        {
                                                                                                                                                                            continue;
                                                                                                                                                                        }
                                                                                                                                                                        bool edge_cur_edge__edge19_prevIsMatched = edge_cur_edge__edge19.isMatched;
                                                                                                                                                                        edge_cur_edge__edge19.isMatched = true;
                                                                                                                                                                        // Implicit target node__node7 from edge__edge19 
                                                                                                                                                                        LGSPNode node_cur_node__node7 = edge_cur_edge__edge19.target;
                                                                                                                                                                        if(!NodeType_O.isMyType[node_cur_node__node7.type.TypeID]) {
                                                                                                                                                                            edge_cur_edge__edge19.isMatched = edge_cur_edge__edge19_prevIsMatched;
                                                                                                                                                                            continue;
                                                                                                                                                                        }
                                                                                                                                                                        if(node_cur_node__node7.isMatched
                                                                                                                                                                            && (node_cur_node__node7==node_cur_node__node3
                                                                                                                                                                                || node_cur_node__node7==node_cur_node__node4
                                                                                                                                                                                || node_cur_node__node7==node_cur_node__node6
                                                                                                                                                                                )
                                                                                                                                                                            )
                                                                                                                                                                        {
                                                                                                                                                                            edge_cur_edge__edge19.isMatched = edge_cur_edge__edge19_prevIsMatched;
                                                                                                                                                                            continue;
                                                                                                                                                                        }
                                                                                                                                                                        bool node_cur_node__node7_prevIsMatched = node_cur_node__node7.isMatched;
                                                                                                                                                                        node_cur_node__node7.isMatched = true;
                                                                                                                                                                        // Extend outgoing edge__edge5 from node_c6 
                                                                                                                                                                        LGSPEdge edge_head_edge__edge5 = node_cur_node_c6.outhead;
                                                                                                                                                                        if(edge_head_edge__edge5 != null)
                                                                                                                                                                        {
                                                                                                                                                                            LGSPEdge edge_cur_edge__edge5 = edge_head_edge__edge5;
                                                                                                                                                                            do
                                                                                                                                                                            {
                                                                                                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge5.type.TypeID]) {
                                                                                                                                                                                    continue;
                                                                                                                                                                                }
                                                                                                                                                                                if(edge_cur_edge__edge5.target != node_cur_node_c1) {
                                                                                                                                                                                    continue;
                                                                                                                                                                                }
                                                                                                                                                                                if(edge_cur_edge__edge5.isMatched
                                                                                                                                                                                    && (edge_cur_edge__edge5==edge_cur_edge__edge0
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge6
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge9
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge1
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge13
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge10
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge11
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge12
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge2
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge7
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge16
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge14
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge15
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge3
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge17
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge4
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge8
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge20
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge18
                                                                                                                                                                                        || edge_cur_edge__edge5==edge_cur_edge__edge19
                                                                                                                                                                                        )
                                                                                                                                                                                    )
                                                                                                                                                                                {
                                                                                                                                                                                    continue;
                                                                                                                                                                                }
                                                                                                                                                                                bool edge_cur_edge__edge5_prevIsMatched = edge_cur_edge__edge5.isMatched;
                                                                                                                                                                                edge_cur_edge__edge5.isMatched = true;
                                                                                                                                                                                // Extend outgoing edge__edge21 from node_c6 
                                                                                                                                                                                LGSPEdge edge_head_edge__edge21 = node_cur_node_c6.outhead;
                                                                                                                                                                                if(edge_head_edge__edge21 != null)
                                                                                                                                                                                {
                                                                                                                                                                                    LGSPEdge edge_cur_edge__edge21 = edge_head_edge__edge21;
                                                                                                                                                                                    do
                                                                                                                                                                                    {
                                                                                                                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge21.type.TypeID]) {
                                                                                                                                                                                            continue;
                                                                                                                                                                                        }
                                                                                                                                                                                        if(edge_cur_edge__edge21.isMatched
                                                                                                                                                                                            && (edge_cur_edge__edge21==edge_cur_edge__edge0
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge6
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge9
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge1
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge13
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge10
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge11
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge12
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge2
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge7
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge16
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge14
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge15
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge3
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge17
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge4
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge8
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge20
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge18
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge19
                                                                                                                                                                                                || edge_cur_edge__edge21==edge_cur_edge__edge5
                                                                                                                                                                                                )
                                                                                                                                                                                            )
                                                                                                                                                                                        {
                                                                                                                                                                                            continue;
                                                                                                                                                                                        }
                                                                                                                                                                                        bool edge_cur_edge__edge21_prevIsMatched = edge_cur_edge__edge21.isMatched;
                                                                                                                                                                                        edge_cur_edge__edge21.isMatched = true;
                                                                                                                                                                                        // Implicit target node_n6 from edge__edge21 
                                                                                                                                                                                        LGSPNode node_cur_node_n6 = edge_cur_edge__edge21.target;
                                                                                                                                                                                        if(!NodeType_N.isMyType[node_cur_node_n6.type.TypeID]) {
                                                                                                                                                                                            edge_cur_edge__edge21.isMatched = edge_cur_edge__edge21_prevIsMatched;
                                                                                                                                                                                            continue;
                                                                                                                                                                                        }
                                                                                                                                                                                        if(node_cur_node_n6.isMatched
                                                                                                                                                                                            && (node_cur_node_n6==node_cur_node_n2
                                                                                                                                                                                                || node_cur_node_n6==node_cur_node_n4
                                                                                                                                                                                                )
                                                                                                                                                                                            )
                                                                                                                                                                                        {
                                                                                                                                                                                            edge_cur_edge__edge21.isMatched = edge_cur_edge__edge21_prevIsMatched;
                                                                                                                                                                                            continue;
                                                                                                                                                                                        }
                                                                                                                                                                                        // Extend outgoing edge__edge22 from node_n6 
                                                                                                                                                                                        LGSPEdge edge_head_edge__edge22 = node_cur_node_n6.outhead;
                                                                                                                                                                                        if(edge_head_edge__edge22 != null)
                                                                                                                                                                                        {
                                                                                                                                                                                            LGSPEdge edge_cur_edge__edge22 = edge_head_edge__edge22;
                                                                                                                                                                                            do
                                                                                                                                                                                            {
                                                                                                                                                                                                if(!EdgeType_Edge.isMyType[edge_cur_edge__edge22.type.TypeID]) {
                                                                                                                                                                                                    continue;
                                                                                                                                                                                                }
                                                                                                                                                                                                if(edge_cur_edge__edge22.isMatched
                                                                                                                                                                                                    && (edge_cur_edge__edge22==edge_cur_edge__edge0
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge6
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge9
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge1
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge13
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge10
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge11
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge12
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge2
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge7
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge16
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge14
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge15
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge3
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge17
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge4
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge8
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge20
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge18
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge19
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge5
                                                                                                                                                                                                        || edge_cur_edge__edge22==edge_cur_edge__edge21
                                                                                                                                                                                                        )
                                                                                                                                                                                                    )
                                                                                                                                                                                                {
                                                                                                                                                                                                    continue;
                                                                                                                                                                                                }
                                                                                                                                                                                                bool edge_cur_edge__edge22_prevIsMatched = edge_cur_edge__edge22.isMatched;
                                                                                                                                                                                                edge_cur_edge__edge22.isMatched = true;
                                                                                                                                                                                                // Implicit target node__node9 from edge__edge22 
                                                                                                                                                                                                LGSPNode node_cur_node__node9 = edge_cur_edge__edge22.target;
                                                                                                                                                                                                if(!NodeType_O.isMyType[node_cur_node__node9.type.TypeID]) {
                                                                                                                                                                                                    edge_cur_edge__edge22.isMatched = edge_cur_edge__edge22_prevIsMatched;
                                                                                                                                                                                                    continue;
                                                                                                                                                                                                }
                                                                                                                                                                                                if(node_cur_node__node9.isMatched
                                                                                                                                                                                                    && (node_cur_node__node9==node_cur_node__node3
                                                                                                                                                                                                        || node_cur_node__node9==node_cur_node__node4
                                                                                                                                                                                                        || node_cur_node__node9==node_cur_node__node6
                                                                                                                                                                                                        || node_cur_node__node9==node_cur_node__node7
                                                                                                                                                                                                        )
                                                                                                                                                                                                    )
                                                                                                                                                                                                {
                                                                                                                                                                                                    edge_cur_edge__edge22.isMatched = edge_cur_edge__edge22_prevIsMatched;
                                                                                                                                                                                                    continue;
                                                                                                                                                                                                }
                                                                                                                                                                                                bool node_cur_node__node9_prevIsMatched = node_cur_node__node9.isMatched;
                                                                                                                                                                                                node_cur_node__node9.isMatched = true;
                                                                                                                                                                                                // Extend outgoing edge__edge23 from node_n6 
                                                                                                                                                                                                LGSPEdge edge_head_edge__edge23 = node_cur_node_n6.outhead;
                                                                                                                                                                                                if(edge_head_edge__edge23 != null)
                                                                                                                                                                                                {
                                                                                                                                                                                                    LGSPEdge edge_cur_edge__edge23 = edge_head_edge__edge23;
                                                                                                                                                                                                    do
                                                                                                                                                                                                    {
                                                                                                                                                                                                        if(!EdgeType_Edge.isMyType[edge_cur_edge__edge23.type.TypeID]) {
                                                                                                                                                                                                            continue;
                                                                                                                                                                                                        }
                                                                                                                                                                                                        if(edge_cur_edge__edge23.isMatched
                                                                                                                                                                                                            && (edge_cur_edge__edge23==edge_cur_edge__edge0
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge6
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge9
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge1
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge13
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge10
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge11
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge12
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge2
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge7
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge16
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge14
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge15
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge3
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge17
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge4
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge8
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge20
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge18
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge19
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge5
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge21
                                                                                                                                                                                                                || edge_cur_edge__edge23==edge_cur_edge__edge22
                                                                                                                                                                                                                )
                                                                                                                                                                                                            )
                                                                                                                                                                                                        {
                                                                                                                                                                                                            continue;
                                                                                                                                                                                                        }
                                                                                                                                                                                                        // Implicit target node__node10 from edge__edge23 
                                                                                                                                                                                                        LGSPNode node_cur_node__node10 = edge_cur_edge__edge23.target;
                                                                                                                                                                                                        if(!NodeType_O.isMyType[node_cur_node__node10.type.TypeID]) {
                                                                                                                                                                                                            continue;
                                                                                                                                                                                                        }
                                                                                                                                                                                                        if(node_cur_node__node10.isMatched
                                                                                                                                                                                                            && (node_cur_node__node10==node_cur_node__node3
                                                                                                                                                                                                                || node_cur_node__node10==node_cur_node__node4
                                                                                                                                                                                                                || node_cur_node__node10==node_cur_node__node6
                                                                                                                                                                                                                || node_cur_node__node10==node_cur_node__node7
                                                                                                                                                                                                                || node_cur_node__node10==node_cur_node__node9
                                                                                                                                                                                                                )
                                                                                                                                                                                                            )
                                                                                                                                                                                                        {
                                                                                                                                                                                                            continue;
                                                                                                                                                                                                        }
                                                                                                                                                                                                        LGSPMatch match = matches.matchesList.GetEmptyMatchFromList();
                                                                                                                                                                                                        match.patternGraph = rulePattern.patternGraph;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@c1] = node_cur_node_c1;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@c2] = node_cur_node_c2;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@c3] = node_cur_node_c3;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@c4] = node_cur_node_c4;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@c5] = node_cur_node_c5;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@c6] = node_cur_node_c6;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@c] = node_cur_node_c;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@_node0] = node_cur_node__node0;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@_node1] = node_cur_node__node1;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@_node2] = node_cur_node__node2;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@n2] = node_cur_node_n2;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@_node3] = node_cur_node__node3;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@_node4] = node_cur_node__node4;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@_node5] = node_cur_node__node5;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@n4] = node_cur_node_n4;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@_node6] = node_cur_node__node6;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@_node7] = node_cur_node__node7;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@_node8] = node_cur_node__node8;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@n6] = node_cur_node_n6;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@_node9] = node_cur_node__node9;
                                                                                                                                                                                                        match.Nodes[(int)Rule_TNTUnfolded.NodeNums.@_node10] = node_cur_node__node10;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge0] = edge_cur_edge__edge0;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge1] = edge_cur_edge__edge1;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge2] = edge_cur_edge__edge2;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge3] = edge_cur_edge__edge3;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge4] = edge_cur_edge__edge4;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge5] = edge_cur_edge__edge5;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge6] = edge_cur_edge__edge6;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge7] = edge_cur_edge__edge7;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge8] = edge_cur_edge__edge8;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge9] = edge_cur_edge__edge9;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge10] = edge_cur_edge__edge10;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge11] = edge_cur_edge__edge11;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge12] = edge_cur_edge__edge12;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge13] = edge_cur_edge__edge13;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge14] = edge_cur_edge__edge14;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge15] = edge_cur_edge__edge15;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge16] = edge_cur_edge__edge16;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge17] = edge_cur_edge__edge17;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge18] = edge_cur_edge__edge18;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge19] = edge_cur_edge__edge19;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge20] = edge_cur_edge__edge20;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge21] = edge_cur_edge__edge21;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge22] = edge_cur_edge__edge22;
                                                                                                                                                                                                        match.Edges[(int)Rule_TNTUnfolded.EdgeNums.@_edge23] = edge_cur_edge__edge23;
                                                                                                                                                                                                        matches.matchesList.EmptyMatchWasFilledFixIt();
                                                                                                                                                                                                        // if enough matches were found, we leave
                                                                                                                                                                                                        if(maxMatches > 0 && matches.matchesList.Count >= maxMatches)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            node_cur_node_n6.MoveOutHeadAfter(edge_cur_edge__edge23);
                                                                                                                                                                                                            node_cur_node_n6.MoveOutHeadAfter(edge_cur_edge__edge22);
                                                                                                                                                                                                            node_cur_node_c6.MoveOutHeadAfter(edge_cur_edge__edge21);
                                                                                                                                                                                                            node_cur_node_c6.MoveOutHeadAfter(edge_cur_edge__edge5);
                                                                                                                                                                                                            node_cur_node_n4.MoveOutHeadAfter(edge_cur_edge__edge19);
                                                                                                                                                                                                            node_cur_node_n4.MoveOutHeadAfter(edge_cur_edge__edge18);
                                                                                                                                                                                                            node_cur_node_c5.MoveOutHeadAfter(edge_cur_edge__edge20);
                                                                                                                                                                                                            node_cur_node_c5.MoveOutHeadAfter(edge_cur_edge__edge8);
                                                                                                                                                                                                            node_cur_node_c5.MoveOutHeadAfter(edge_cur_edge__edge4);
                                                                                                                                                                                                            node_cur_node_c4.MoveOutHeadAfter(edge_cur_edge__edge17);
                                                                                                                                                                                                            node_cur_node_c4.MoveOutHeadAfter(edge_cur_edge__edge3);
                                                                                                                                                                                                            node_cur_node_n2.MoveOutHeadAfter(edge_cur_edge__edge15);
                                                                                                                                                                                                            node_cur_node_n2.MoveOutHeadAfter(edge_cur_edge__edge14);
                                                                                                                                                                                                            node_cur_node_c3.MoveOutHeadAfter(edge_cur_edge__edge16);
                                                                                                                                                                                                            node_cur_node_c3.MoveOutHeadAfter(edge_cur_edge__edge7);
                                                                                                                                                                                                            node_cur_node_c3.MoveOutHeadAfter(edge_cur_edge__edge2);
                                                                                                                                                                                                            node_cur_node_c.MoveOutHeadAfter(edge_cur_edge__edge12);
                                                                                                                                                                                                            node_cur_node_c.MoveOutHeadAfter(edge_cur_edge__edge11);
                                                                                                                                                                                                            node_cur_node_c.MoveOutHeadAfter(edge_cur_edge__edge10);
                                                                                                                                                                                                            node_cur_node_c2.MoveOutHeadAfter(edge_cur_edge__edge13);
                                                                                                                                                                                                            node_cur_node_c2.MoveOutHeadAfter(edge_cur_edge__edge1);
                                                                                                                                                                                                            node_cur_node_c1.MoveOutHeadAfter(edge_cur_edge__edge9);
                                                                                                                                                                                                            node_cur_node_c1.MoveOutHeadAfter(edge_cur_edge__edge6);
                                                                                                                                                                                                            graph.MoveHeadAfter(edge_cur_edge__edge0);
                                                                                                                                                                                                            node_cur_node__node9.isMatched = node_cur_node__node9_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge22.isMatched = edge_cur_edge__edge22_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge21.isMatched = edge_cur_edge__edge21_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge5.isMatched = edge_cur_edge__edge5_prevIsMatched;
                                                                                                                                                                                                            node_cur_node__node7.isMatched = node_cur_node__node7_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge19.isMatched = edge_cur_edge__edge19_prevIsMatched;
                                                                                                                                                                                                            node_cur_node__node6.isMatched = node_cur_node__node6_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge18.isMatched = edge_cur_edge__edge18_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge20.isMatched = edge_cur_edge__edge20_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge8.isMatched = edge_cur_edge__edge8_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                                                                                                                                                            node_cur_node_n4.isMatched = node_cur_node_n4_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge17.isMatched = edge_cur_edge__edge17_prevIsMatched;
                                                                                                                                                                                                            node_cur_node_c5.isMatched = node_cur_node_c5_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                                                                                                                                                                            node_cur_node__node4.isMatched = node_cur_node__node4_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge15.isMatched = edge_cur_edge__edge15_prevIsMatched;
                                                                                                                                                                                                            node_cur_node__node3.isMatched = node_cur_node__node3_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge14.isMatched = edge_cur_edge__edge14_prevIsMatched;
                                                                                                                                                                                                            node_cur_node__node5.isMatched = node_cur_node__node5_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge16.isMatched = edge_cur_edge__edge16_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge7.isMatched = edge_cur_edge__edge7_prevIsMatched;
                                                                                                                                                                                                            node_cur_node_c4.isMatched = node_cur_node_c4_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                                                                                                                                                                                            node_cur_node__node2.isMatched = node_cur_node__node2_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge12.isMatched = edge_cur_edge__edge12_prevIsMatched;
                                                                                                                                                                                                            node_cur_node__node1.isMatched = node_cur_node__node1_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge11.isMatched = edge_cur_edge__edge11_prevIsMatched;
                                                                                                                                                                                                            node_cur_node__node0.isMatched = node_cur_node__node0_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge10.isMatched = edge_cur_edge__edge10_prevIsMatched;
                                                                                                                                                                                                            node_cur_node_n2.isMatched = node_cur_node_n2_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge13.isMatched = edge_cur_edge__edge13_prevIsMatched;
                                                                                                                                                                                                            node_cur_node_c3.isMatched = node_cur_node_c3_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                                                                                                                                                                                            node_cur_node_c.isMatched = node_cur_node_c_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge9.isMatched = edge_cur_edge__edge9_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge6.isMatched = edge_cur_edge__edge6_prevIsMatched;
                                                                                                                                                                                                            node_cur_node_c2.isMatched = node_cur_node_c2_prevIsMatched;
                                                                                                                                                                                                            node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                                                                                                                                                                                                            edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
                                                                                                                                                                                                            return matches;
                                                                                                                                                                                                        }
                                                                                                                                                                                                    }
                                                                                                                                                                                                    while( (edge_cur_edge__edge23 = edge_cur_edge__edge23.outNext) != edge_head_edge__edge23 );
                                                                                                                                                                                                }
                                                                                                                                                                                                node_cur_node__node9.isMatched = node_cur_node__node9_prevIsMatched;
                                                                                                                                                                                                edge_cur_edge__edge22.isMatched = edge_cur_edge__edge22_prevIsMatched;
                                                                                                                                                                                            }
                                                                                                                                                                                            while( (edge_cur_edge__edge22 = edge_cur_edge__edge22.outNext) != edge_head_edge__edge22 );
                                                                                                                                                                                        }
                                                                                                                                                                                        edge_cur_edge__edge21.isMatched = edge_cur_edge__edge21_prevIsMatched;
                                                                                                                                                                                    }
                                                                                                                                                                                    while( (edge_cur_edge__edge21 = edge_cur_edge__edge21.outNext) != edge_head_edge__edge21 );
                                                                                                                                                                                }
                                                                                                                                                                                edge_cur_edge__edge5.isMatched = edge_cur_edge__edge5_prevIsMatched;
                                                                                                                                                                            }
                                                                                                                                                                            while( (edge_cur_edge__edge5 = edge_cur_edge__edge5.outNext) != edge_head_edge__edge5 );
                                                                                                                                                                        }
                                                                                                                                                                        node_cur_node__node7.isMatched = node_cur_node__node7_prevIsMatched;
                                                                                                                                                                        edge_cur_edge__edge19.isMatched = edge_cur_edge__edge19_prevIsMatched;
                                                                                                                                                                    }
                                                                                                                                                                    while( (edge_cur_edge__edge19 = edge_cur_edge__edge19.outNext) != edge_head_edge__edge19 );
                                                                                                                                                                }
                                                                                                                                                                node_cur_node__node6.isMatched = node_cur_node__node6_prevIsMatched;
                                                                                                                                                                edge_cur_edge__edge18.isMatched = edge_cur_edge__edge18_prevIsMatched;
                                                                                                                                                            }
                                                                                                                                                            while( (edge_cur_edge__edge18 = edge_cur_edge__edge18.outNext) != edge_head_edge__edge18 );
                                                                                                                                                        }
                                                                                                                                                        edge_cur_edge__edge20.isMatched = edge_cur_edge__edge20_prevIsMatched;
                                                                                                                                                    }
                                                                                                                                                    while( (edge_cur_edge__edge20 = edge_cur_edge__edge20.outNext) != edge_head_edge__edge20 );
                                                                                                                                                }
                                                                                                                                                edge_cur_edge__edge8.isMatched = edge_cur_edge__edge8_prevIsMatched;
                                                                                                                                            }
                                                                                                                                            while( (edge_cur_edge__edge8 = edge_cur_edge__edge8.outNext) != edge_head_edge__edge8 );
                                                                                                                                        }
                                                                                                                                        edge_cur_edge__edge4.isMatched = edge_cur_edge__edge4_prevIsMatched;
                                                                                                                                    }
                                                                                                                                    while( (edge_cur_edge__edge4 = edge_cur_edge__edge4.outNext) != edge_head_edge__edge4 );
                                                                                                                                }
                                                                                                                                node_cur_node_n4.isMatched = node_cur_node_n4_prevIsMatched;
                                                                                                                                edge_cur_edge__edge17.isMatched = edge_cur_edge__edge17_prevIsMatched;
                                                                                                                            }
                                                                                                                            while( (edge_cur_edge__edge17 = edge_cur_edge__edge17.outNext) != edge_head_edge__edge17 );
                                                                                                                        }
                                                                                                                        node_cur_node_c5.isMatched = node_cur_node_c5_prevIsMatched;
                                                                                                                        edge_cur_edge__edge3.isMatched = edge_cur_edge__edge3_prevIsMatched;
                                                                                                                    }
                                                                                                                    while( (edge_cur_edge__edge3 = edge_cur_edge__edge3.outNext) != edge_head_edge__edge3 );
                                                                                                                }
                                                                                                                node_cur_node__node4.isMatched = node_cur_node__node4_prevIsMatched;
                                                                                                                edge_cur_edge__edge15.isMatched = edge_cur_edge__edge15_prevIsMatched;
                                                                                                            }
                                                                                                            while( (edge_cur_edge__edge15 = edge_cur_edge__edge15.outNext) != edge_head_edge__edge15 );
                                                                                                        }
                                                                                                        node_cur_node__node3.isMatched = node_cur_node__node3_prevIsMatched;
                                                                                                        edge_cur_edge__edge14.isMatched = edge_cur_edge__edge14_prevIsMatched;
                                                                                                    }
                                                                                                    while( (edge_cur_edge__edge14 = edge_cur_edge__edge14.outNext) != edge_head_edge__edge14 );
                                                                                                }
                                                                                                node_cur_node__node5.isMatched = node_cur_node__node5_prevIsMatched;
                                                                                                edge_cur_edge__edge16.isMatched = edge_cur_edge__edge16_prevIsMatched;
                                                                                            }
                                                                                            while( (edge_cur_edge__edge16 = edge_cur_edge__edge16.outNext) != edge_head_edge__edge16 );
                                                                                        }
                                                                                        edge_cur_edge__edge7.isMatched = edge_cur_edge__edge7_prevIsMatched;
                                                                                    }
                                                                                    while( (edge_cur_edge__edge7 = edge_cur_edge__edge7.outNext) != edge_head_edge__edge7 );
                                                                                }
                                                                                node_cur_node_c4.isMatched = node_cur_node_c4_prevIsMatched;
                                                                                edge_cur_edge__edge2.isMatched = edge_cur_edge__edge2_prevIsMatched;
                                                                            }
                                                                            while( (edge_cur_edge__edge2 = edge_cur_edge__edge2.outNext) != edge_head_edge__edge2 );
                                                                        }
                                                                        node_cur_node__node2.isMatched = node_cur_node__node2_prevIsMatched;
                                                                        edge_cur_edge__edge12.isMatched = edge_cur_edge__edge12_prevIsMatched;
                                                                    }
                                                                    while( (edge_cur_edge__edge12 = edge_cur_edge__edge12.outNext) != edge_head_edge__edge12 );
                                                                }
                                                                node_cur_node__node1.isMatched = node_cur_node__node1_prevIsMatched;
                                                                edge_cur_edge__edge11.isMatched = edge_cur_edge__edge11_prevIsMatched;
                                                            }
                                                            while( (edge_cur_edge__edge11 = edge_cur_edge__edge11.outNext) != edge_head_edge__edge11 );
                                                        }
                                                        node_cur_node__node0.isMatched = node_cur_node__node0_prevIsMatched;
                                                        edge_cur_edge__edge10.isMatched = edge_cur_edge__edge10_prevIsMatched;
                                                    }
                                                    while( (edge_cur_edge__edge10 = edge_cur_edge__edge10.outNext) != edge_head_edge__edge10 );
                                                }
                                                node_cur_node_n2.isMatched = node_cur_node_n2_prevIsMatched;
                                                edge_cur_edge__edge13.isMatched = edge_cur_edge__edge13_prevIsMatched;
                                            }
                                            while( (edge_cur_edge__edge13 = edge_cur_edge__edge13.outNext) != edge_head_edge__edge13 );
                                        }
                                        node_cur_node_c3.isMatched = node_cur_node_c3_prevIsMatched;
                                        edge_cur_edge__edge1.isMatched = edge_cur_edge__edge1_prevIsMatched;
                                    }
                                    while( (edge_cur_edge__edge1 = edge_cur_edge__edge1.outNext) != edge_head_edge__edge1 );
                                }
                                node_cur_node_c.isMatched = node_cur_node_c_prevIsMatched;
                                edge_cur_edge__edge9.isMatched = edge_cur_edge__edge9_prevIsMatched;
                            }
                            while( (edge_cur_edge__edge9 = edge_cur_edge__edge9.outNext) != edge_head_edge__edge9 );
                        }
                        edge_cur_edge__edge6.isMatched = edge_cur_edge__edge6_prevIsMatched;
                    }
                    while( (edge_cur_edge__edge6 = edge_cur_edge__edge6.outNext) != edge_head_edge__edge6 );
                }
                node_cur_node_c2.isMatched = node_cur_node_c2_prevIsMatched;
                node_cur_node_c1.isMatched = node_cur_node_c1_prevIsMatched;
                edge_cur_edge__edge0.isMatched = edge_cur_edge__edge0_prevIsMatched;
            }
            return matches;
        }
	}
	public class Action_createDNT : LGSPAction
	{
		public Action_createDNT() {
			rulePattern = Rule_createDNT.Instance;
			DynamicMatch = myMatch; matches = new LGSPMatches(this, 0, 0, 0);
		}

		public override string Name { get { return "createDNT"; } }
		private LGSPMatches matches;

		public static LGSPAction Instance { get { return instance; } }
		private static Action_createDNT instance = new Action_createDNT();

        public LGSPMatches myMatch(LGSPGraph graph, int maxMatches, IGraphElement[] parameters)
        {
            matches.matchesList.Clear();
            LGSPMatch match = matches.matchesList.GetEmptyMatchFromList();
            match.patternGraph = rulePattern.patternGraph;
            matches.matchesList.EmptyMatchWasFilledFixIt();
            // if enough matches were found, we leave
            if(maxMatches > 0 && matches.matchesList.Count >= maxMatches)
            {
                return matches;
            }
            return matches;
        }
	}
	public class Action_createTNB : LGSPAction
	{
		public Action_createTNB() {
			rulePattern = Rule_createTNB.Instance;
			DynamicMatch = myMatch; matches = new LGSPMatches(this, 0, 0, 0);
		}

		public override string Name { get { return "createTNB"; } }
		private LGSPMatches matches;

		public static LGSPAction Instance { get { return instance; } }
		private static Action_createTNB instance = new Action_createTNB();

        public LGSPMatches myMatch(LGSPGraph graph, int maxMatches, IGraphElement[] parameters)
        {
            matches.matchesList.Clear();
            LGSPMatch match = matches.matchesList.GetEmptyMatchFromList();
            match.patternGraph = rulePattern.patternGraph;
            matches.matchesList.EmptyMatchWasFilledFixIt();
            // if enough matches were found, we leave
            if(maxMatches > 0 && matches.matchesList.Count >= maxMatches)
            {
                return matches;
            }
            return matches;
        }
	}
	public class Action_createTNT : LGSPAction
	{
		public Action_createTNT() {
			rulePattern = Rule_createTNT.Instance;
			DynamicMatch = myMatch; matches = new LGSPMatches(this, 0, 0, 0);
		}

		public override string Name { get { return "createTNT"; } }
		private LGSPMatches matches;

		public static LGSPAction Instance { get { return instance; } }
		private static Action_createTNT instance = new Action_createTNT();

        public LGSPMatches myMatch(LGSPGraph graph, int maxMatches, IGraphElement[] parameters)
        {
            matches.matchesList.Clear();
            LGSPMatch match = matches.matchesList.GetEmptyMatchFromList();
            match.patternGraph = rulePattern.patternGraph;
            matches.matchesList.EmptyMatchWasFilledFixIt();
            // if enough matches were found, we leave
            if(maxMatches > 0 && matches.matchesList.Count >= maxMatches)
            {
                return matches;
            }
            return matches;
        }
	}

    public class TNTActions : LGSPActions
    {
        public TNTActions(LGSPGraph lgspgraph, IDumperFactory dumperfactory, String modelAsmName, String actionsAsmName)
            : base(lgspgraph, dumperfactory, modelAsmName, actionsAsmName)
        {
            InitActions();
        }

        public TNTActions(LGSPGraph lgspgraph)
            : base(lgspgraph)
        {
            InitActions();
        }

        private void InitActions()
        {
            actions.Add("DNT", (LGSPAction) Action_DNT.Instance);
            actions.Add("DNTUnfolded", (LGSPAction) Action_DNTUnfolded.Instance);
            actions.Add("TNB", (LGSPAction) Action_TNB.Instance);
            actions.Add("TNBUnfolded", (LGSPAction) Action_TNBUnfolded.Instance);
            actions.Add("TNT", (LGSPAction) Action_TNT.Instance);
            actions.Add("TNTUnfolded", (LGSPAction) Action_TNTUnfolded.Instance);
            actions.Add("createDNT", (LGSPAction) Action_createDNT.Instance);
            actions.Add("createTNB", (LGSPAction) Action_createTNB.Instance);
            actions.Add("createTNT", (LGSPAction) Action_createTNT.Instance);
        }

        public override String Name { get { return "TNTActions"; } }
        public override String ModelMD5Hash { get { return "271b47a37bac7e7d1b30af05a6a923c8"; } }
    }
}