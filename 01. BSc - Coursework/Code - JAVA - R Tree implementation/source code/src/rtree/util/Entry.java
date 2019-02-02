package rtree.util;

import java.util.Stack;

/**
 * This class represents an entry of our R-tree implementation. It can be either
 * {@link Point} or {@link Node}
 * 
 * @author Sskalist
 * 
 */
public abstract class Entry
{

	/**
	 * The id number of the entry.
	 */
	protected long entryID;

	/**
	 * A stack that holds all the unused Ids.
	 */
	private static Stack<Long> unusedEntriesStack;
	/**
	 * The entry count.
	 */
	private static long noEntries;
	/**
	 * The maximum Id that has been used
	 */
	private static long maxUsedEntryId;

	static
	{
		unusedEntriesStack = new Stack<Long>();
		noEntries = 0;
		maxUsedEntryId = 0;
	}

	/**
	 * Default constructor. Assigns {@link #entryID} by calling
	 * {@link #getNextEntryId()}
	 */
	public Entry()
	{
		this.entryID = getNextEntryId();
	}

	/**
	 * Gets the next available Id.
	 * 
	 * @return ++{@link #maxUsedEntryId} if the {@link #unusedEntriesStack} is
	 *         empty else the top of the stack.
	 */
	public static long getNextEntryId()
	{
		noEntries++;
		if (unusedEntriesStack.isEmpty()) { return ++maxUsedEntryId; }
		return unusedEntriesStack.pop();
	}

	/**
	 * Gets the id of the entry.
	 * 
	 * @return the entryID
	 */
	public long getEntryID()
	{
		return entryID;
	}

	/**
	 * Finalizes the Entry.Inserts its {@link #entryID} to the stack so it can
	 * be used later on.
	 * 
	 * @see Object#finalize()
	 */
	@Override
	protected void finalize() throws Throwable
	{
		Entry.unusedEntriesStack.push(this.entryID);
		super.finalize();

	}

}
