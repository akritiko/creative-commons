package rtree.util;

/**
 * The representation of an LeafNode inside an R-Tree.<br>
 * It has Points as entries. It supports all the basic functionality of a Node.
 * Some of it is implemented in {@link Node}'s level.<br>
 * Among these Add/Remove an entry & split the node.
 * 
 * @author Sskalist
 * 
 */
public class LeafNode extends Node
{

	/**
	 * Keeps track of how many pages have been created.
	 */
	private static long pageCount;

	/**
	 * The number of the page assigned to the this LeafNode.
	 */
	private long pageNumber;

	/**
	 * States whether the page is loaded or not.
	 */
	private boolean pageLoaded;
	/**
	 * States whether the page has changed or not.
	 */
	private boolean pageChanged;

	static
	{
		// Initialize the pageCount
		pageCount = 0;
	}

	/**
	 * Constructor. Calls the {@link Node#Node()} and initializes the
	 * {@link Node#entries} array. Also assigns a page number to the leaf and
	 * allocates the necessary space to the disk.
	 */
	public LeafNode()
	{
		super();
		entries = new Point[MaxEntries];
		pageNumber = pageCount++;
		pageLoaded = false;
		DiskHandler.writeToDisk((Point[]) entries, entryCount, pageNumber);
	}

	/**
	 * Adds an entry to the leaf.<br>
	 * The page must be loaded! Otherwise a runtime error is thrown.
	 * 
	 * @param toBeAdded
	 *            The entry to add.
	 * @see Node#addEntry(Entry)
	 */
	@Override
	public void addEntry(Entry toBeAdded)
	{
		if (!isPageLoaded())
			throw new RuntimeException("Page '" + pageNumber
					+ "' is not loaded while adding entry:" + toBeAdded);
		if (minimumBoundaryRectangle == null)
			minimumBoundaryRectangle = new Rectangle();

		entries[entryCount++] = toBeAdded;
		minimumBoundaryRectangle.add(toBeAdded);

		this.pageChanged = true;

	}

	/**
	 * Splits a leafNode. Alters the current leaf and return the newly created.
	 * 
	 * @param splitGuilty The entry that causes the leaf to split.
	 * @return The leafNode created.
	 */
	@Override
	public LeafNode splitNode(Entry splitGuilty)
	{
		// create the new leaf
		LeafNode newLeaf = new LeafNode();
		// Load the page
		this.loadPage();
		// Don't need to actually load an empty page!!
		newLeaf.pageLoaded = true;

		// Perform the split
		Node.performSplit(this, newLeaf, splitGuilty);

		// Both leaves have changed.
		// This must be done in order unload to work properly
		this.pageChanged = true;
		newLeaf.pageChanged = true;

		// Write both pages to disk.
		this.unloadPage();
		newLeaf.unloadPage();

		// Return the new leaf reference
		return newLeaf;
	}

	/**
	 * Removes the last entry.<br>
	 * The page must be loaded! Otherwise a runtime error is thrown.
	 * 
	 * @return The removed entry.
	 * @see rtree.util.Node#removeLastEntry()
	 */
	@Override
	public Entry removeLastEntry()
	{
		if (!isPageLoaded())
			throw new RuntimeException("Page '" + pageNumber
					+ "' is not loaded while trying to remove last entry.");
		return super.removeLastEntry();
	}

	/**
	 * Loads page of this leaf.
	 */
	public void loadPage()
	{
		// If it is already loaded do nothing.
		if (isPageLoaded()) return;

		// Else load it and set the pageLoaded property true.
		entries = DiskHandler.loadFromDisk(this.pageNumber, this.entryCount,
				Node.MaxEntries);
		pageLoaded = true;
	}

	/**
	 * Unloads the page. If it hasn't changed or it isn't loaded it has no
	 * effect.
	 */
	public void unloadPage()
	{
		// If it is not loaded do nothing
		if (!isPageLoaded()) return;

		// If the page has changed write it do disk.
		if (pageChanged)
		{
			DiskHandler.writeToDisk((Point[]) entries, entryCount, pageNumber);
		}

		// Discard all data and reset the properties.
		entries = null;
		pageLoaded = false;
		pageChanged = false;
	}

	/**
	 * Check whether the page is loaded or not.
	 * 
	 * @return {@link #pageLoaded}
	 */
	private boolean isPageLoaded()
	{
		return pageLoaded;
	}

	/**
	 * Gets the entry at the specified index.<br>
	 * The page must be loaded! Otherwise a runtime error is thrown.
	 * 
	 * @param index
	 *            The index of the required entry.
	 * @return the specified entry.
	 * @see rtree.util.Node#getEntry(int)
	 */
	@Override
	public Point getEntry(int index)
	{
		if (!isPageLoaded())
			throw new RuntimeException("Page '" + pageNumber
					+ "' is not loaded while trying to get entry at index:"
					+ index + ".");
		return (Point) super.getEntry(index);
	}

	/**
	 * Because it's a leaf it always returns true.
	 * 
	 * @return true.
	 * @see rtree.util.Node#isLeaf()
	 */
	public boolean isLeaf()
	{
		return true;
	}
}
