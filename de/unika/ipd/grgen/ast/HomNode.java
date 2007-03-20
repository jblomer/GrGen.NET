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
 * @file CollectNode.java
 * @author shack
 * @date Jul 21, 2003
 * @version $Id$
 */
package de.unika.ipd.grgen.ast;

import java.awt.Color;
import de.unika.ipd.grgen.ast.util.DeclResolver;
import de.unika.ipd.grgen.ast.util.Resolver;
import de.unika.ipd.grgen.ast.util.TypeChecker;
import de.unika.ipd.grgen.util.report.ErrorReporter;
import de.unika.ipd.grgen.parser.Coords;


/**
 * A node that represents a set of potentially homomorph nodes
 */
public class HomNode extends BaseNode {

	static {
		setName(HomNode.class, "homomorph");
	}
	
  public HomNode(Coords coords) {
    super(coords);
  }

	/**
	 * Check whether all children are of same type (node or edge)
	 * and addtionally one entity may not be used in two different hom
	 * statements
	 */
  protected boolean check() {
    if(getChildren().isEmpty()) {
  		this.reportError("hom statement empty");
  		return false;
  	}
  	
  	if(!checkAllChildren(DeclNode.class)) {
		return false;
  	}
  	
  	DeclNode child = (DeclNode)getChild(0);
  	TypeChecker checker;
  	
  	if(child.getDeclType() instanceof NodeTypeNode) {
  		checker = new TypeChecker(NodeTypeNode.class);
  	} else {
  		checker = new TypeChecker(EdgeTypeNode.class);
  	}
  	
  	return checkAllChildren(checker);
  }
  
  public Color getNodeColor() {
  	return Color.PINK;
  }

@Override
protected boolean resolve() {
	boolean resolved = true;
	
	Resolver resolver = new DeclResolver(new Class[] {NodeDeclNode.class, EdgeDeclNode.class, ParamDeclNode.class });
	
	for(int i=0; i<children(); ++i) {
		boolean res = resolver.resolve(this, i);
		if(!res) resolved = false;
	}

	return resolved;
}
}
