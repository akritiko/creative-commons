package dbms.bplus;

import java.io.Serializable;

/**
 * This class implements an abstract class of a node of a B+ Tree. This
 * is a superclass for the <code>InnerNode</code>,
 * <code>PrimaryLeaf</code> and <code>SecondaryLeaf</code> classes.
 * @see dbms.bplus.InnerNode
 * @see dbms.bplus.PrimaryLeaf
 * @see dbms.bplus.SecondaryLeaf
 */
public abstract class Node implements Serializable {
	/**
	 * The parent node.
	 */
	private InnerNode parent;

	/**
	 * The type of the node.
	 */
	private NodeType type;

	/**
	 * Creates a node with <code>type</code>.
	 */
	public Node(final NodeType type) {
		this.type = type;
		this.parent = null;
	} // end method Node

	/**
	 * Retrieves the type of the node.
	 * 
	 * @return The <code>type</code> of the <code>Node</code>.
	 */
	public NodeType getNodeType() {
		return this.type;
	} // end method getNodeType

	/**
	 * Retrieves the parent of the <code>Node</code>.
	 * @return The parent of the Node.
	 */
	public InnerNode getParent() {
		return this.parent;
	} // end method getParentNode

	/**
	 * Sets the parent of the <code>Node</code>.
	 * 
	 * @param parent 
	 *            the parent <code>Node</code>.
	 */
	public void setParent(final InnerNode parent) {
		this.parent = parent;
	} // end method setParentNode

	/**
	 * Checks if the <code>Node</code> is replete or not
	 * 
	 * @return <code>true</code> If the Node is replete and
	 *         <code>false</code> otherwise.
	 */
	public abstract boolean isReplete();
} // end class Node
