/*
 * GrGen: graph rewrite generator tool -- release GrGen.NET 3.5
 * Copyright (C) 2003-2012 Universitaet Karlsruhe, Institut fuer Programmstrukturen und Datenorganisation, LS Goos
 * licensed under LGPL v3 (see LICENSE.txt included in the packaging of this file)
 * www.grgen.net
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using de.unika.ipd.grGen.libGr;
using de.unika.ipd.grGen.lgsp;

namespace de.unika.ipd.grGen.lgsp
{
    /// <summary>
    /// Interface implemented by the compiled graph matchers
    /// </summary>
    public interface GraphComparisonMatcher
    {
        /// <summary>
        /// Returns whether the graph which resulted in thisPattern is isomorph to the graph given.        
        /// </summary>
        bool IsIsomorph(PatternGraph thisPattern, LGSPGraph graph);
    }
}

