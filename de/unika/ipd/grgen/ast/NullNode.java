/**
 * @author shack
 * @version $Id$
 */
package de.unika.ipd.grgen.ast;

import java.awt.Color;
import java.util.Collection;
import java.util.Collections;

/**
 * A dummy node, that is used in the case of an error.
 */
public class NullNode extends BaseNode {
	
	static {
		setName(NullNode.class, "error node");
	}
	
	protected NullNode() {
		super();
	}
	
	/*
	 public void addChild(BaseNode n) {
	 }
	 
	 public void addChildren(BaseNode n) {
	 }
	 
	 protected boolean check() {
	 return false;
	 }
	 
	 public boolean checkChild(int child, Class cls) {
	 return false;
	 }
	 
	 public int children() {
	 return 0;
	 }
	 
	 public BaseNode getChild(int i) {
	 return BaseNode.NULL;
	 }
	 
	 public Iterator getChildren() {
	 return dummy;
	 }
	 */
	public Color getNodeColor() {
		return Color.RED;
	}
	
	public String getNodeLabel() {
		return "Error";
	}
	
	public Collection<? extends BaseNode> getWalkableChildren() {
		return Collections.EMPTY_SET;
	}
	
	public boolean isError() {
		return true;
	}
	
}
