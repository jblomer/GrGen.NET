package de.unika.ipd.grgen.ast;

import java.util.Collection;
import java.util.Vector;

import de.unika.ipd.grgen.ast.util.DeclarationPairResolver;
import de.unika.ipd.grgen.ast.util.Pair;

/**
 * Represents a reused single graph entity.
 *
 * This node is needed to distinguish between reused single nodes and reused
 * subpatterns.
 * After resolving in {@link GraphNode#resolveLocal()} this node should disappear.
 *
 * @author buchwald
 *
 */
public class SingleGraphEntityNode extends BaseNode
{
	IdentNode entityUnresolved;
	NodeDeclNode entityNode;
	SubpatternUsageNode entitySubpattern;

	public SingleGraphEntityNode(IdentNode ent) {
		super(ent.getCoords());
		entityUnresolved = ent;
		becomeParent(this.entityUnresolved);
    }

	@Override
	protected boolean checkLocal()
	{
		// this node should not exist after resolving
		return false;
	}

	@Override
	public Collection<? extends BaseNode> getChildren()
	{
		Vector<BaseNode> children = new Vector<BaseNode>();
		children.add(entityUnresolved);
		return children;
	}

	@Override
	public Collection<String> getChildrenNames()
	{
		Vector<String> childrenNames = new Vector<String>();
		childrenNames.add("entity");
		return childrenNames;
	}

	private static final DeclarationPairResolver<NodeDeclNode, SubpatternUsageNode> entityResolver = new DeclarationPairResolver<NodeDeclNode, SubpatternUsageNode>(NodeDeclNode.class, SubpatternUsageNode.class);

	@Override
	protected boolean resolveLocal()
	{
		Pair<NodeDeclNode, SubpatternUsageNode> pair = entityResolver.resolve(entityUnresolved, this);

		if (pair != null) {
			entityNode = pair.fst;
			entitySubpattern = pair.snd;
		}

		return entityNode != null || entitySubpattern != null;
	}

	protected SubpatternUsageNode getEntitySubpattern()
    {
	    assert isResolved();

		return entitySubpattern;
    }

	protected NodeDeclNode getEntityNode() {
		assert isResolved();

		return entityNode;
	}

}