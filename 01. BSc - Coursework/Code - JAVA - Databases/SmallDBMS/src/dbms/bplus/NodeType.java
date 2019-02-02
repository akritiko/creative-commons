package dbms.bplus;

/**
 * Enumeration of the types that a B+ Tree's nodes can have.
 */

public enum NodeType
{
	/**
	 * The node is an inner node
	 */
	INNER_NODE, 
	/**
	 * The node is leaf to a B+ tree that serves as a primary index
	 */
	PRIMARY_LEAF, 
	/**
	 * The node is leaf to a B+ tree that serves as a secondary index
	 */
	SECONDARY_LEAF;
} // end enum NodeType
