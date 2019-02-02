package rtree.util;

import rtree.Main;

/**
 * This class represents the Nodes of the tree.<br>
 * They can be either {@link InnerNode} or {@link LeafNode}.<br>
 * It provides basic functionality that is common between the above classes.
 * 
 * @author Sskalist
 * @see InnerNode
 * @see LeafNode
 * 
 */

public abstract class Node extends Entry
{

	/**
	 * The entries of the Node... An InnerNode has Nodes as entries; a LeafNode
	 * has Points as entries;
	 */
	protected Entry[] entries;

	/**
	 * The number of entries currently in the Node
	 */
	protected int entryCount;
	/**
	 * The minimum boundary rectangle for the entries of the Node
	 */
	protected Rectangle minimumBoundaryRectangle;

	/**
	 * The maximum entries that a Node can host. It is calculated based on
	 * {@link Main#PAGE_SIZE} and the {@link Point#DIMENSIONS}.
	 */
	public static final int MaxEntries = Main.PAGE_SIZE
			/ (Double.SIZE / 8 * Main.DIMENSIONS + Long.SIZE / 8);
	/**
	 * The minimum entries that a Node can host. Equals to {@link #MaxEntries}/2
	 */
	public static final int MinEntries = MaxEntries / 2;

	/**
	 * The default constructor. It calls the above constructor to assign the
	 * EntryId which is inherited and initializes the table of Entries with
	 * length equal to MaxEntries
	 */
	public Node()
	{
		super();
		minimumBoundaryRectangle = null;
	}

	/**
	 * Adds an entry. The way is handled lower on the class hierarchy.
	 * 
	 * @param toBeAdded
	 *            The entry to add.
	 */
	public abstract void addEntry(Entry toBeAdded);

	/**
	 * Splits the node. Alters the current and returns the new one.The way is
	 * handled lower on the class hierarchy.
	 * 
	 * @param splitGuilty
	 *            The entry that caused the node to split.
	 * @return The new Node
	 */
	public abstract Node splitNode(Entry splitGuilty);

	/**
	 * Checks whether the Node is a leaf or not.
	 * 
	 * @return True if {@link LeafNode} else false.
	 * @see LeafNode#isLeaf()
	 * @see InnerNode#isLeaf()
	 */
	public abstract boolean isLeaf();

	/**
	 * Performs the split. Removes entries from the <code>orginalNode</code>
	 * and assigns them to the <code>newNode</code><br>
	 * The split is performed according to the original Guttman's algorithm with
	 * linear cost.
	 * 
	 * @param originalNode
	 *            The Node that is full.
	 * @param newNode
	 *            The new Node that will host some of the
	 *            <code>originalNode</code> entries.
	 * @param splitGuilty
	 *            The entry that caused <code>originalNode</code> to split.
	 */
	protected static void performSplit(Node originalNode, Node newNode,
			Entry splitGuilty)
	{
		// LS1 [Pick first entry for each group] Apply algorithm pickSeeds to
		// choose
		// two entries to be the first elements of the groups. Assign each to a
		// group.

		Node.pickSeeds(originalNode, newNode, splitGuilty);

		// LS2 [Check if done] If all entries have been assigned, stop. If one
		// group has so few entries that all the rest must be assigned to it in
		// order for it to have the minimum number m, assign them and stop.

		// 2 have been already assigned by pickSeeds()
		for (int i = 2; i < Node.MaxEntries + 1; i++)
		{
			if (Node.MaxEntries + 1 - newNode.getEntryCount() == Node.MinEntries)
			{
				// Assign all remaining entries to the original node(this).
				// Just add to the MinimumBoundaryRectangle all the Entries in
				// the Node starting counting from the total assigned to it.
				for (i = i - newNode.entryCount; i < Node.MinEntries; i++)
				{
					originalNode.minimumBoundaryRectangle
							.add(originalNode.entries[i]);
				}
				break;
			}
			// ( i - newLeaf.getEntryCount()) is the number of entries assigned
			// to the original node
			if (Node.MaxEntries + 1 - (i - newNode.getEntryCount()) == Node.MinEntries)
			{
				// Assign all remaining entries to the new node.
				// Remove them from the original Node(this) and add them to the
				// new Node.
				for (i = newNode.getEntryCount(); i < Node.MinEntries; i++)
				{
					newNode.addEntry(originalNode.removeLastEntry());
				}
				break;
			}

			// LS3 [Select entry to assign] Invoke algorithm pickNext to choose
			// the
			// next entry to assign. Add it to the group whose covering
			// rectangle
			// will have to be enlarged least to accommodate it. Resolve ties
			// by adding the entry to the group with smaller area, then to the
			// the one with fewer entries, then to either. Repeat from LS2
			Node.pickNext(originalNode, newNode, i - newNode.getEntryCount());
		}
	}

	/**
	 * Guttman's pick Seeds. It picks two entries (one for each node) and
	 * assigns them.
	 * 
	 * @param originalNode
	 *            The Node that is full.
	 * @param newNode
	 *            The new Node that will host some of the
	 *            <code>originalNode</code> entries.
	 * @param splitGuilty
	 *            The entry that caused <code>originalNode</code> to split.
	 */
	private static void pickSeeds(Node originalNode, Node newNode,
			Entry splitGuilty)
	{

		// PS1 [Find extreme point along all dimensions]. Along each
		// dimension, find the point which has the highest low side,
		// and the one with the lowest high side. Record the separation.
		double maxNormalizedSeparation = 0;
		int highestLowIndex = 0;
		int lowestHighIndex = 0;

		// for the purposes of picking seeds, make the MinimumBoundaryRectangle
		// of the node to include the new rectangle as well.
		originalNode.getMinimumBoundryRectangle().add(splitGuilty);

		for (int d = 0; d < Main.DIMENSIONS; d++)
		{
			double tempHighestLow = originalNode.isLeaf() ? ((Point) splitGuilty)
					.getCoordinate(d)
					: ((Node) splitGuilty).getMinimumBoundryRectangle()
							.getMininimum(d);
			int tempHighestLowIndex = -1; // -1 indicates the new rectangle is
			// the seed

			double tempLowestHigh = originalNode.isLeaf() ? ((Point) splitGuilty)
					.getCoordinate(d)
					: ((Node) splitGuilty).getMinimumBoundryRectangle()
							.getMaximum(d);
			int tempLowestHighIndex = -1;

			for (int i = 0; i < originalNode.entryCount; i++)
			{
				double tempLow = originalNode.isLeaf() ? ((LeafNode) originalNode)
						.getEntry(i).getCoordinate(d)
						: (((InnerNode) originalNode).getEntry(i))
								.getMinimumBoundryRectangle().getMininimum(d);
				if (tempLow >= tempHighestLow)
				{
					tempHighestLow = tempLow;
					tempHighestLowIndex = i;
				}
				else
				{ // ensure that the same index cannot be both
					// lowestHigh and highestLow
					double tempHigh = originalNode.isLeaf() ? ((LeafNode) originalNode)
							.getEntry(i).getCoordinate(d)
							: (((InnerNode) originalNode).getEntry(i))
									.getMinimumBoundryRectangle().getMaximum(d);
					if (tempHigh <= tempLowestHigh)
					{
						tempLowestHigh = tempHigh;
						tempLowestHighIndex = i;
					}
				}

				// PS2 [Adjust for shape of the rectangle cluster] Normalize the
				// separations
				// by dividing by the widths of the entire set along the
				// corresponding
				// dimension
				double normalizedSeparation = (tempHighestLow - tempLowestHigh)
						/ (originalNode.minimumBoundaryRectangle.getMaximum(d) - originalNode.minimumBoundaryRectangle
								.getMininimum(d));

				// PS3 [Select the most extreme pair] Choose the pair with the
				// greatest
				// normalized separation along any dimension.
				if (normalizedSeparation > maxNormalizedSeparation)
				{
					maxNormalizedSeparation = normalizedSeparation;
					highestLowIndex = tempHighestLowIndex;
					lowestHighIndex = tempLowestHighIndex;
				}
			}
		}

		// highestLowIndex is the seed for the new node.
		if (highestLowIndex == -1)
		{
			newNode.addEntry(splitGuilty);
		}
		else
		{
			newNode.addEntry(originalNode.removeEntry(highestLowIndex));

			// move the new rectangle into the space vacated by the seed for the
			// new node
			originalNode.addEntry(splitGuilty);
		}

		// lowestHighIndex is the seed for the original node.
		if (lowestHighIndex == -1)
		{
			lowestHighIndex = highestLowIndex;
		}

		// Resetting the MinimumBoundaryRectangle...
		double minArray[] = originalNode.isLeaf() ? (((LeafNode) originalNode)
				.getEntry(lowestHighIndex).getCoordinates())
				: (((InnerNode) originalNode).getEntry(lowestHighIndex))
						.getMinimumBoundryRectangle().getMininimumArray();
		double maxArray[] = originalNode.isLeaf() ? (((LeafNode) originalNode)
				.getEntry(lowestHighIndex).getCoordinates())
				: (((InnerNode) originalNode).getEntry(lowestHighIndex))
						.getMinimumBoundryRectangle().getMaximumArray();
		originalNode.minimumBoundaryRectangle.set(minArray, maxArray);
	}

	/**
	 * Picks and assigns the next entry to be assigned to a group during a node
	 * split.
	 */
	private static void pickNext(Node originalNode, Node newNode,
			int assignedToOriginal)
	{

		// [Determine cost of putting each entry in each group] For each
		// entry not yet in a group, calculate the area increase required
		// in the covering rectangles of each group
		Double maxDifference = Double.NEGATIVE_INFINITY;
		int next = assignedToOriginal; // the next entry to be assigned
		int nextGroup = 0; // 0 states that it should remain in the original
		// Node; 1 states that it should move to the
		// newNode.

		for (int i = assignedToOriginal; i < originalNode.entryCount; i++)
		{

			// Increase of originalNode if i entry is added...
			double originalNodeIncrease = originalNode.minimumBoundaryRectangle
					.enlargement(originalNode.entries[i]);
			// Increase of newNode if i entry is added...
			double newNodeIncrease = newNode.minimumBoundaryRectangle
					.enlargement(originalNode.entries[i]);
			// Their absolute Difference
			double difference = Math
					.abs(originalNodeIncrease - newNodeIncrease);

			if (difference > maxDifference)
			{
				next = i;

				// Applying Guttman's criteria.
				if (originalNodeIncrease < newNodeIncrease)
				{
					nextGroup = 0;
				}
				else if (newNodeIncrease < originalNodeIncrease)
				{
					nextGroup = 1;
				}
				else if (originalNode.minimumBoundaryRectangle.area() < newNode.minimumBoundaryRectangle
						.area())
				{
					nextGroup = 0;
				}
				else if (newNode.minimumBoundaryRectangle.area() < originalNode.minimumBoundaryRectangle
						.area())
				{
					nextGroup = 1;
				}
				else if (newNode.entryCount < MinEntries)
				{
					nextGroup = 0;
				}
				else
				{
					nextGroup = 1;
				}
				maxDifference = difference;
			}

		}

		if (nextGroup == 0)
		{
			// alter only the minimunBoundaryRectangle
			originalNode.minimumBoundaryRectangle
					.add(originalNode.entries[next]);
		}
		else
		{
			// move to new node.
			newNode.addEntry(originalNode.removeEntry(next));
		}
	}

	/**
	 * Removes the entry at <code>index</code>.
	 * 
	 * @param index
	 *            The specified index
	 * @return If index <= {@link #entryCount} returns the removed Entry;
	 *         otherwise null.
	 */
	public Entry removeEntry(int index)
	{
		if (index > entryCount) return null;
		Entry toBeRemoved = entries[index];
		entries[index] = entries[entryCount - 1];
		entries[entryCount - 1] = toBeRemoved;
		return removeLastEntry();
	}

	/**
	 * Removes the last entry.
	 * 
	 * @return The removed entry.
	 */
	public Entry removeLastEntry()
	{
		Entry toBeRemoved = entries[entryCount - 1];
		entries[entryCount - 1] = null;
		entryCount--;
		return toBeRemoved;

	}

	/**
	 * The entry at <code>index</code>
	 * 
	 * @param index
	 *            The specified index
	 * @return If is inside of bounds, the specified entry else throws
	 *         RuntimeException
	 */
	public Entry getEntry(int index)
	{
		if (index < 0 || index > entries.length)
			throw new RuntimeException("Out of Bounds");
		return entries[index];
	}

	/**
	 * Gets The minimumBoundryRectangle.
	 * 
	 * @return the minimumBoundryRectangle
	 */
	public Rectangle getMinimumBoundryRectangle()
	{
		return minimumBoundaryRectangle;
	}

	/**
	 * Checks if the Node is Full
	 * 
	 * @return true in case is full; else false.
	 */
	public boolean isFull()
	{
		return entryCount == MaxEntries;
	}

	/**
	 * Gets the number of entries.
	 * 
	 * @return the {@link #entryCount}.
	 */
	public int getEntryCount()
	{
		return entryCount;
	}

}
