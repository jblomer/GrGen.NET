using System.Collections.Generic;
using System;

namespace de.unika.ipd.grGen.libGr
{
    /// <summary>
    /// Used to specify whether and how already existing C# files shall be used while processing a specification
    /// </summary>
    public enum UseExistingKind
    {
        /// <summary>
        /// Do not use existing files
        /// </summary>
        None,

        /// <summary>
        /// Only use existing C# files generated by the Java frontend
        /// </summary>
        OnlyJavaGenerated,

        /// <summary>
        /// Use all existing C# files
        /// </summary>
        Full
    }

    /// <summary>
    /// A helper class for backend independent graph and rule handling.
    /// </summary>
    public interface IBackend
    {
        /// <summary>
        /// The name of the backend.
        /// </summary>
        String Name { get; }

        /// <summary>
        /// Enumerates the names of the arguments which can be optionally passed to the create/open functions.
        /// Not currently used...
        /// </summary>
        IEnumerable<String> ArgumentNames { get; }

        /// <summary>
        /// Creates a new IGraph backend instance with the given graph model and name.
        /// </summary>
        /// <param name="graphModel">An IGraphModel instance.</param>
        /// <param name="graphName">Name of the graph.</param>
        /// <param name="parameters">Backend specific parameters.</param>
        /// <returns>The new IGraph backend instance.</returns>
        IGraph CreateGraph(IGraphModel graphModel, String graphName, params String[] parameters);

        /// <summary>
        /// Creates a new IGraph backend instance with the graph model provided by the graph model file and a name.
        /// </summary>
        /// <param name="modelFilename">Filename of a graph model file.</param>
        /// <param name="graphName">Name of the graph.</param>
        /// <param name="parameters">Backend specific parameters.</param>
        /// <returns>The new IGraph backend instance.</returns>
        IGraph CreateGraph(String modelFilename, String graphName, params String[] parameters);

        /// <summary>
        /// Creates a new IGraph and BaseActions backend instance from the specified specification file.
        /// If neccessary, any processing steps are performed automatically.
        /// </summary>
        /// <param name="grgFilename">Filename of the rule specification file (.grg).</param>
        /// <param name="graphName">Name of the new graph.</param>
        /// <param name="newGraph">Returns the new graph.</param>
        /// <param name="newActions">Returns the new BaseActions object.</param>
        /// <exception cref="System.Exception">Thrown when something goes wrong.</exception>
        void CreateFromSpec(String grgFilename, String graphName, out IGraph newGraph, out BaseActions newActions);

        /// <summary>
        /// Opens an existing graph identified by graphName using the specified IGraphModel.
        /// This may not be supported by the backend, if the data is not persistent.
        /// </summary>
        /// <param name="modelFilename">Filename of a graph model file</param>
        /// <param name="graphName">Name of an existing graph</param>
        /// <param name="parameters">Backend specific parameters</param>
        /// <returns>The IGraph backend instance</returns>
        IGraph OpenGraph(String modelFilename, String graphName, params String[] parameters);

        /// <summary>
        /// An enumerable of KeyValuePairs, where the keys are names of existing graphs and the
        /// values are the names of the appropriate models (not filenames).
        /// </summary>
        IEnumerable<KeyValuePair<String, String>> ExistingGraphs { get; }

        /// <summary>
        /// Processes the given rule specification file and generates a model and actions library.
        /// </summary>
        /// <param name="specPath">The path to the rule specification file (.grg).</param>
        /// <param name="destDir">The directory, where the generated libraries are to be placed.</param>
        /// <param name="intermediateDir">A directory, where intermediate files can be placed.</param>
        /// <param name="useExisting">Specifies whether and how existing files in the intermediate directory will be used.</param>
        /// <param name="keepIntermediateDir">If true, more files may be generated in the intermediate directory.</param>
        /// <param name="compileWithDebug">If true, debug information will be generated for the generated assemblies.</param>
        /// <exception cref="System.Exception">Thrown, when an error occurred.</exception>
        void ProcessSpecification(String specPath, String destDir, String intermediateDir, UseExistingKind useExisting,
            bool keepIntermediateDir, bool compileWithDebug);
        
        /// <summary>
        /// Processes the given rule specification file and generates a model and actions library in the same directory as the specification file.
        /// </summary>
        /// <param name="specPath">The path to the rule specification file (.grg).</param>
        /// <exception cref="System.Exception">Thrown, when an error occurred.</exception>
        void ProcessSpecification(String specPath);
    }
}