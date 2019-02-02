package rtree.util;

/**
 * The representation of an InnerNode inside an R-Tree.<br>
 * It has InnerNodes or LeafNodes as entries. It supports all the basic
 * functionality of a Node. Some of it is implemented in {@link Node}'s level.<br>
 * Among these Add/Remove an entry & split the node.
 * 
 * @author Sskalist
 * 
 */
public class InnerNode extends Node
{

	/**
	 * Constructor. Calls the {@link Node#Node()} and initializes the
	 * {@link Node#entries} array.
	 */
	public InnerNode()
	{
		super();
		entries = new Node[MaxEntries];
	}

	/**
	 * Adds the specified entry.
	 * 
	 * @param toBeAdded
	 *            The entry to add.
	 * @see Node#addEntry(Entry)
	 */
	@Override
	public void addEntry(Entry toBeAdded)
	{
		if (minimumBoundaryRectangle == null)
			minimumBoundaryRectangle = new Rectangle();

		entries[entryCount++] = toBeAdded;
		minimumBoundaryRectangle.add(toBeAdded);

	}

	// @Override
	/**
	 * Gets the specified entry.
	 * 
	 * @return The specified Node-entry.
	 * @see Node#getEntry(int)
	 */
	public Node getEntry(int index)
	{
		return (Node) super.getEntry(index);
	}

	/**
	 * Splits this innerNode.
	 * 
	 * @param splitGuilty
	 *            The entry that caused the split.
	 * @return The new InnerNode created.
	 * @see Node#splitNode(rtree.util.Entry)
	 * @see Node#performSplit(Node, Node, Entry)
	 */
	@Override
	public InnerNode splitNode(Entry splitGuilty)
	{
		InnerNode newInner = new InnerNode();
		Node.performSplit(this, newInner, splitGuilty);
		return newInner;
	}

	/**
	 * Because it's not a leaf it always returns false.
	 * 
	 * @return false.
	 * @see rtree.util.Node#isLeaf()
	 */
	@Override
	public boolean isLeaf()
	{
		return false;
	}

}
