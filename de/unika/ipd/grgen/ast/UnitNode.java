/**
 * @author shack
 * @version $Id$
 */
package de.unika.ipd.grgen.ast;

import de.unika.ipd.grgen.ast.util.*;

import de.unika.ipd.grgen.ir.Action;
import de.unika.ipd.grgen.ir.IR;
import de.unika.ipd.grgen.ir.Ident;
import de.unika.ipd.grgen.ir.Model;
import de.unika.ipd.grgen.ir.Unit;
import java.util.Iterator;

/**
 * The main node of the text. It is the root of the ast.
 */
public class UnitNode extends DeclNode {
	
	protected static final TypeNode mainType = new TypeNode() { };
	
	static {
		setName(UnitNode.class, "unit declaration");
		setName(mainType.getClass(), "unit type");
	}
	
	/** The index of the model child. */
	private static final int MODELS = 2;
	
	/** Index of the decl collect node in the children. */
	private static final int DECLS = 3;
	
	/** Names of the children */
	private static String[] childrenNames = {
		"ident", "type", "models", "delcs"
	};
	
	/** Contains the classes of all valid types which can be declared */
	private static Class[] validTypes = {
		TestDeclNode.class, RuleDeclNode.class
	};
	
	/** checker for this node */
	private static final Checker modelChecker =
		new CollectChecker(new SimpleChecker(ModelNode.class));

	/** checker for this node */
	private static final Checker declChecker =
		new CollectChecker(new MultChecker(validTypes));
	
	private static final Resolver declResolver =
		new CollectResolver(new DeclResolver(validTypes));
	
	/**
	 * The filename for this main node.
	 */
	private String filename;
	
	public UnitNode(IdentNode id, String filename) {
		super(id, mainType);
		this.filename = filename;
		setChildrenNames(childrenNames);
		addResolver(DECLS, declResolver);
	}
	
	/**
	 * The main node has an ident node and a collect node with
	 * - group declarations
	 * - edge class decls
	 * - node class decls
	 * as child.
	 * @see de.unika.ipd.grgen.ast.BaseNode#check()
	 */
	protected boolean check() {
		return checkChild(MODELS, modelChecker) && checkChild(DECLS, declChecker);
	}
	
	/**
	 * Get the IR unit node for this ast node.
	 * @return The Unit for this ast node.
	 */
	public Unit getUnit() {
		return (Unit) checkIR(Unit.class);
	}
	
	/**
	 * Construct the ir object for this ast node.
	 * For a main node, this is a unit.
	 * @see de.unika.ipd.grgen.ast.BaseNode#constructIR()
	 */
	protected IR constructIR() {
		Ident id = (Ident) getChild(IDENT).checkIR(Ident.class);
		Unit res = new Unit(id, filename);
		
		for(Iterator<BaseNode> it = getChild(MODELS).getChildren(); it.hasNext();) {
			Model model = ((ModelNode) it.next()).getModel();
			res.addModel(model);
		}

		for(Iterator<BaseNode> it = getChild(DECLS).getChildren(); it.hasNext();) {
			Action act = ((ActionDeclNode) it.next()).getAction();
			res.addAction(act);
		}

		return res;
	}
	
}
