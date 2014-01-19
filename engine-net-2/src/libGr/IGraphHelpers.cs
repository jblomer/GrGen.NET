/*
 * GrGen: graph rewrite generator tool -- release GrGen.NET 4.2
 * Copyright (C) 2003-2014 Universitaet Karlsruhe, Institut fuer Programmstrukturen und Datenorganisation, LS Goos; and free programmers
 * licensed under LGPL v3 (see LICENSE.txt included in the packaging of this file)
 * www.grgen.net
 */

using System;
using System.Diagnostics;

namespace de.unika.ipd.grGen.libGr
{
    /// <summary>
    /// A named graph-global variable.
    /// </summary>
    public class Variable
    {
        /// <summary>
        /// The name of the variable.
        /// </summary>
        public readonly String Name;

        /// <summary>
        /// The value pointed to by the variable.
        /// </summary>
        public object Value;

        /// <summary>
        /// Initializes a Variable instance.
        /// </summary>
        /// <param name="name">The name of the variable.</param>
        /// <param name="value">The value pointed to by the variable.</param>
        public Variable(String name, object value)
        {
            Name = name;
            Value = value;
        }
    }

    /// <summary>
    /// The changes which might occur to graph element attributes.
    /// </summary>
    public enum AttributeChangeType
    {
        /// <summary>
        /// Assignment of a value to some attribute.
        /// Value semantics, even if assigned attribute is a set or a map, not a primitive type.
        /// </summary>
        Assign,

        /// <summary>
        /// Inserting a value into some set or a key value pair into some map or a value into some array.
        /// </summary>
        PutElement,

        /// <summary>
        /// Removing a value from some set or a key value pair from some map or a key/index from some array.
        /// </summary>
        RemoveElement,

        /// <summary>
        /// Assignment of a value to a key/index position in an array, overwriting old element at that position.
        /// </summary>
        AssignElement
    }

    /// <summary>
    /// An interface for managing graph transactions.
    /// </summary>
    public interface ITransactionManager
    {
        /// <summary>
        /// Starts a transaction
        /// </summary>
        /// <returns>A transaction ID to be used with Commit or Rollback</returns>
        int Start();

        /// <summary>
        /// Pauses the running transactions,
        /// i.e. changes done from now on until resume won't be undone in case of a rollback
        /// </summary>
        void Pause();

        /// <summary>
        /// Resumes the running transactions after a pause,
        /// i.e. changes done from now on will be undone again in case of a rollback
        /// </summary>
        void Resume();

        /// <summary>
        /// Removes the rollback data and stops this transaction
        /// </summary>
        /// <param name="transactionID">Transaction ID returned by a Start call</param>
        void Commit(int transactionID);

        /// <summary>
        /// Undoes all changes during a transaction
        /// </summary>
        /// <param name="transactionID">The ID of the transaction to be rollbacked</param>
        void Rollback(int transactionID);

        /// <summary>
        /// Indicates, whether a transaction is currently active.
        /// </summary>
        bool IsActive { get; }
    }

    /// <summary>
    /// An interface for recording changes (and their causes) applied to a graph into a file,
    /// so that they can get replayed.
    /// </summary>
    public interface IRecorder
    {
        /// <summary>
        /// Creates a file which initially gets filled with a .grs export of the graph.
        /// Afterwards the changes applied to the graph are recorded into the file,
        /// in the order they occur.
        /// You can start multiple recordings into differently named files.
        /// </summary>
        /// <param name="filename">The name of the file to record to</param>
        void StartRecording(string filename);

        /// <summary>
        /// Stops recording of the changes applied to the graph to the given file.
        /// </summary>
        /// <param name="filename">The name of the file to stop recording to</param>
        void StopRecording(string filename);

        /// <summary>
        /// Returns whether the graph changes get currently recorded into the given file.
        /// </summary>
        /// <param name="filename">The name of the file whose recording status gets queried</param>
        /// <returns>The recording status of the file queried</returns>
        bool IsRecording(string filename);

        /// <summary>
        /// Writes the given string to the currently ongoing recordings
        /// </summary>
        /// <param name="value">The string to write to the recordings</param>
        void Write(string value);

        /// <summary>
        /// Writes the given string to the currently ongoing recordings followed by a new line
        /// </summary>
        /// <param name="value">The string to write to the recordings</param>
        void WriteLine(string value);

        /// <summary>
        /// Flushes the writer
        /// </summary>
        void Flush();

        ////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Called by the transaction manager when a transaction is started
        /// </summary>
        /// <param name="transactionID">The id of the transaction</param>
        void TransactionStart(int transactionID);

        /// <summary>
        /// Called by the transaction manager when a transaction is committed
        /// </summary>
        /// <param name="transactionID">The id of the transaction</param>
        void TransactionCommit(int transactionID);

        /// <summary>
        /// Called by the transaction manager when a transaction is rolled back
        /// </summary>
        /// <param name="transactionID">The id of the transaction</param>
        /// <param name="start">true when called at rollback start, false when called at rollback end</param>
        void TransactionRollback(int transactionID, bool start);
    }

    /// <summary>
    /// The different graph validation modes
    /// </summary>
    public enum ValidationMode
    {
        OnlyMultiplicitiesOfMatchingTypes, // check the multiplicities of the incoming/outgoing edges which match the types specified
        StrictOnlySpecified, // as first and additionally check that edges with connections assertions specified are covered by at least on connection assertion
        Strict // as first and additionally check that all edges are covered by at least one connection assertion
    }

    /// <summary>
    /// An object accumulating information about needed time, number of found matches and number of performed rewrites.
    /// </summary>
    public class PerformanceInfo
    {
        /// <summary>
        /// Accumulated number of matches found by any rule since last Reset.
        /// </summary>
        public int MatchesFound;

        /// <summary>
        /// Accumulated number of rewrites performed by any rule since last Reset.
        /// This differs from <see cref="MatchesFound"/> for test rules, tested rules, and undone rules.
        /// </summary>
        public int RewritesPerformed;

        /// <summary>
        /// Accumulated number of search steps carried out since last Reset.
        /// (Number of bindings of a graph element to a pattern element, but bindings where only one choice is available don't count into this.)
        /// Only incremented if gathering of profiling information was requested ("-profile", "new set profile on").
        /// </summary>
        public long SearchSteps;

        /// <summary>
        /// The accumulated time of rule and sequence applications in seconds since last Reset,
        /// as defined by the intervals between Start and Stop.
        /// </summary>
        public double TimeNeeded { get { return ((double)totalTime) / Stopwatch.Frequency; } }

        /// <summary>
        /// Starts time measurement.
        /// </summary>
        public void Start()
        {
            stopwatch.Start();
            totalStart = stopwatch.ElapsedTicks;
        }

        /// <summary>
        /// Stops time measurement and increases the TimeNeeded by the elapsed time 
        /// between this call and the last call to Start().
        /// </summary>
        public void Stop()
        {
            totalTime += stopwatch.ElapsedTicks - totalStart;
        }

        private Stopwatch stopwatch = new Stopwatch();
        private long totalStart;
        private long totalTime;

        /// <summary>
        /// Resets all accumulated information.
        /// </summary>
        public void Reset()
        {
            MatchesFound = 0;
            RewritesPerformed = 0;
            SearchSteps = 0;
            totalTime = 0;

#if DEBUGACTIONS || MATCHREWRITEDETAIL
            localStart = 0;
            totalMatchTime = 0;
            totalRewriteTime = 0;
            LastMatchTime = 0;
            LastRewriteTime = 0;
#endif
        }

#if DEBUGACTIONS || MATCHREWRITEDETAIL
        private int localStart;
        private int totalMatchTime;
        private int totalRewriteTime;

        /// <summary>
        /// The time needed for the last matching.
        /// </summary>
        public long LastMatchTime;

        /// <summary>
        /// The time needed for the last rewriting.
        /// </summary>
        public long LastRewriteTime;

        /// <summary>
        /// The total time needed for matching.
        /// Due to timer resolution, this should not be used, except for very difficult patterns.
        /// </summary>
        public int TotalMatchTimeMS { get { return totalMatchTime; } }

        /// <summary>
        /// The total time needed for rewriting.
        /// Due to timer resolution, this should not be used, except for very big rewrites.
        /// </summary>
        public int TotalRewriteTimeMS { get { return totalRewriteTime; } }

        /// <summary>
        /// Starts a local time measurement to be used with either StopMatch() or StopRewrite().
        /// </summary>
        public void StartLocal()
        {
            localStart = Environment.TickCount;
        }

        /// <summary>
        /// Stops a local time measurement, sets LastMatchTime to the elapsed time between this call
        /// and the last call to StartLocal() and increases the TotalMatchTime by this amount.
        /// </summary>
        public void StopMatch()
        {
            int diff = Environment.TickCount - localStart;
            totalMatchTime += diff;
            LastMatchTime = diff;
            LastRewriteTime = 0;
        }

        /// <summary>
        /// Stops a local time measurement, sets LastRewriteTime to the elapsed time between this call
        /// and the last call to StartLocal() and increases the TotalRewriteTime by this amount.
        /// </summary>
        public void StopRewrite()
        {
            int diff = Environment.TickCount - localStart;
            totalRewriteTime += diff;
            LastRewriteTime = diff;
        }

        public int TimeDiffToMS(long diff)
        {
            return (int) diff;
        }
#endif
    }

    /// <summary>
    /// Describes a range with a minimum and a maximum value.
    /// </summary>
    public struct Range
    {
        /// <summary>
        /// Constant value representing positive infinity for a range.
        /// </summary>
        public const int Infinite = int.MaxValue;

        /// <summary>
        /// The lower bound of the range.
        /// </summary>
        public int Min;

        /// <summary>
        /// The upper bound of the range.
        /// </summary>
        public int Max;

        /// <summary>
        /// Constructs a Range object.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public Range(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}
