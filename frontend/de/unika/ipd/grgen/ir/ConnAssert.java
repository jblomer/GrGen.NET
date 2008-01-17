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
 * @author shack
 * @version $Id$
 */
package de.unika.ipd.grgen.ir;

/**
 * Denotes the connections assertions of nodes and edges.
 */
import java.util.Collections;
import java.util.Map;

public class ConnAssert extends IR {
	private final long srcLower;
	private final long srcUpper;
	private final long tgtLower;
	private final long tgtUpper;
	private final NodeType srcType;
	private final NodeType tgtType;

	public ConnAssert(NodeType srcType, long srcLower, long srcUpper,
										NodeType tgtType, long tgtLower, long tgtUpper) {
		super("conn assert");
		this.srcType = srcType;
		this.srcLower = srcLower;
		this.srcUpper = srcUpper;
		this.tgtType = tgtType;
		this.tgtLower = tgtLower;
		this.tgtUpper = tgtUpper;
	}

	public NodeType getSrcType() {
		return srcType;
	}

	public NodeType getTgtType() {
		return tgtType;
	}

	public long getSrcLower() {
		return srcLower;
	}

	public long getSrcUpper() {
		return srcUpper;
	}

	public long getTgtLower() {
		return tgtLower;
	}

	public long getTgtUpper() {
		return tgtUpper;
	}

	public void addFields(Map<String, Object> fields) {
		super.addFields(fields);
		fields.put("src_lower", Long.toString(srcLower));
		fields.put("src_upper", Long.toString(srcUpper));
		fields.put("tgt_lower", Long.toString(tgtLower));
		fields.put("tgt_upper", Long.toString(tgtUpper));
		fields.put("src_type", Collections.singleton(getSrcType()));
		fields.put("tgt_type", Collections.singleton(getTgtType()));
	}

	public boolean equals(ConnAssert ca) {
		return
			srcLower == ca.srcLower &&
			srcUpper == ca.srcUpper &&
			tgtLower == ca.tgtLower &&
			tgtUpper == ca.tgtUpper &&
			getSrcType() == ca.getSrcType() &&
			getTgtType() == ca.getTgtType();
	}

	/**
	 * Compares a given connection assert with <code>this</code> one.
	 * @return a negative integer, zero, or a positive integer as the
     * 	       argument is less than, equal to, or greater than
     *	       <code>this</code> connection assertion.
	 */
	public int compareTo(ConnAssert ca) {
		if (this.equals(ca)) return 0;
		if (this.srcLower < ca.srcLower)
			if (this.srcUpper < ca.srcUpper)
				if (this.tgtLower < ca.tgtLower)
					if (this.tgtUpper < ca.tgtUpper)
						return -1;
		return 1;
	}

	public String toString() {
		return
			getName() +
			" {" +
			"("+ srcType +" [" + srcLower + ".." + srcUpper + "])," +
			"("+ tgtType +" [" + tgtLower + ".." + tgtUpper + "])" +
			"}";
	}
}

