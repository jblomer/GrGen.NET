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
 * @author adam
 * @version $Id$
 */
package de.unika.ipd.grgen.ast.util;

import de.unika.ipd.grgen.ast.BaseNode;
import de.unika.ipd.grgen.ast.DeclNode;
import de.unika.ipd.grgen.util.report.ErrorReporter;

/**
 * A type checker, that checks if the declaration node is of a certain type 
 */
public class TypeChecker implements Checker {

	/// The class the decl type is to checked for
	private Class c;

	public TypeChecker(Class c) {
		this.c = c;
	}

  /**
   * Check, if node is an instance of DeclNode and then check, if the declaration
   * has the right type  
   * @see de.unika.ipd.grgen.ast.check.Checker#check(de.unika.ipd.grgen.ast.BaseNode, de.unika.ipd.grgen.util.report.ErrorReporter)
   */
  public boolean check(BaseNode node, ErrorReporter reporter) {
  	boolean res = node instanceof DeclNode;
  	
  	if(!res) {
  		node.reportError("not of type " + DeclNode.class.getName());
  	} else {
  		BaseNode type = ((DeclNode)node).getDeclType();
  		res = c.isInstance(type);
  		
  		if(!res)
  	  		node.reportError("decl not of type " + c.getName());
  	}
  		
  	return res;	
  }
}
