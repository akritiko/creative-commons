package rtree;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.Stack;

import rtree.util.Entry;
import rtree.util.InnerNode;
import rtree.util.LeafNode;
import rtree.util.Node;
import rtree.util.Point;
import rtree.util.Rectangle;

/**
 * A modified implementation of the R-Tree data structure. It supports Points
 * (instead of Rectangles as in Guttman's original paper). Points can be
 * inserted at any time. It also supports a Range Query based on a Point and a
 * radius and k-Nearest Neighbours Query.<br>
 * <br>
 * The Range Query is based on minDistance as described in Roussopoulos paper
 * and the methodology as described in Guttman's paper.<br>
 * The k-Nearest Neighbours Query is based on Roussopoulos paper,with a minor
 * efficiency change on calculating MinMaxDistance
 * 
 * @author Sskalist
 * 
 */
public class Rtree
{

	/**
	 * The root of the tree.<br>
	 * It is an InnerNode unless the tree is consisted only by this node;<br>
	 * In that case it's LeafNode.
	 */
	private Node root;

	/**
	 * The height of the tree.
	 */
	private int height;

	/**
	 * The number of points currently in the tree.
	 */
	private long pointCount;

	/**
	 * A stack that is used when the tree is traversed and stores the parents of
	 * each visited node.
	 * 
	 * @see Stack
	 */
	private Stack<InnerNode> parents;

	/**
	 * A stack that specifies the index that was followed, in the parent's
	 * <code>entries</code> array, in order to reach this node.
	 * 
	 * @see #parents
	 * @see Stack
	 */
	private Stack<Integer> parentEntryIndex;

	/**
	 * Constructs a R-Tree and initializes all the data structures in order for
	 * the tree to function.
	 */
	public Rtree()
	{
		pointCount = 0;
		height = 1;
		root = new LeafNode();
		parents = new Stack<InnerNode>();
		parentEntryIndex = new Stack<Integer>();
	}

	/**
	 * This is a wrapper of an entry for the Nearest Neighbour Query. It
	 * encapsulates an Entry and its distance from the origin point.
	 * 
	 * @see Entry
	 * @author Sskalist
	 */
	private class NNeighbourEntry
	{
		/**
		 * The {@link Entry} that its distance has been calculated.
		 */
		Entry entry;
		/**
		 * The Euclidian distance from the point of origin.
		 */
		double distanceFromCentre;

		/**
		 * Constructor combining the entry and its distance.
		 * 
		 * @param entry
		 *            The entry.
		 * @param distanceFromCentre
		 *            The distance from point of origin.
		 */
		public NNeighbourEntry(Entry entry, double distanceFromCentre)
		{
			this.entry = entry;
			this.distanceFromCentre = distanceFromCentre;
		}

	}

	/**
	 * This is a wrapper of an Node/Rectangle for the Nearest Neighbour Query.
	 * It encapsulates an Entry its distance and its MinMaxDistance from the
	 * origin point. <br>
	 * (The minMaxDistance is calculated according to Roussopoulos paper).
	 * 
	 * @see Entry
	 * @see NNeighbourEntry
	 * @author Sskalist
	 */
	private class NNeighbourRectangle extends NNeighbourEntry
	{
		/**
		 * The Node/Rectangle for which the two distance information are
		 * required.
		 */
		Node entry;

		/**
		 * The MinMaxDistance as described in Roussopoulos paper for the kNN
		 * queries.
		 */
		double minMaxDistance;

		/**
		 * Constructor calling <code>NNeighbourEntry(Entry, double)</code> and assigning
		 * the minMaxDistance value.
		 * 
		 * @param entry
		 * @param distanceFromCentre
		 * @param minMaxDistance
		 */
		public NNeighbourRectangle(Node entry, double distanceFromCentre,
				double minMaxDistance)
		{
			super(entry, distanceFromCentre);
			this.entry = (Node) super.entry;
			this.minMaxDistance = minMaxDistance;
		}

	}

	/**
	 * A comparator for the {@link NNeighbourEntry}. An Entry is considered
	 * prior to another whenever its distance is less than the one compared to.<br>
	 * Used for inserting and comparing in the kNN query.
	 * 
	 * @see Rtree#nearestNeighbours(Point, int)
	 * @author Sskalist
	 * 
	 */
	private class NNeighbourEntryComparator implements
			Comparator<NNeighbourEntry>
	{

		/**
		 * Overrides the {@link Comparator#compare(Object, Object)} method.
		 * Compares the two nearest neighbours.
		 * 
		 * @param nn1
		 *            The first entry to be compared.
		 * @param nn2
		 *            The second entry to be compared with the first.
		 * @return if
		 *         <code>nn1.distanceFromCentre < nn2.distanceFromCentre</code>
		 *         then -1 <br>
		 *         if
		 *         <code>nn1.distanceFromCentre < nn2.distanceFromCentre</code>
		 *         then 1 <br>
		 *         if
		 *         <code>nn1.distanceFromCentre == nn2.distanceFromCentre</code>
		 *         then 0
		 * @see Comparator#compare(Object, Object)
		 */
		@Override
		public int compare(NNeighbourEntry nn1, NNeighbourEntry nn2)
		{

			if (nn1.distanceFromCentre < nn2.distanceFromCentre) return -1;
			if (nn1.distanceFromCentre > nn2.distanceFromCentre) return 1;
			return 0;

		}

	}

	/**
	 * Implements a nearest Neighbours search from a point of origin, according
	 * to Roussopoulos paper. It applies all the pruning strategies (both
	 * downward and upward).<br>
	 * The result might have less size than <code>noNeighbours</code> in case
	 * the tree contains less Points than <code>noNeighbours</code>.
	 * 
	 * @param centre
	 *            The point of origin.
	 * @param noNeighbours
	 *            The number of the required Neighbours.
	 * @return A Point[] containing the results; null in case
	 *         <code>noNeighbours <= 0</code>.
	 */
	public Point[] nearestNeighbours(Point centre, int noNeighbours)
	{
		// If invalid noNeighbours is entered return null.
		if (noNeighbours <= 0) return null;

		// Create an default comparator for the nearest neighbour entries.
		NNeighbourEntryComparator defaultComparator = new NNeighbourEntryComparator();

		// This is the distance of the furthest nearest neighbour found until
		// now.
		double furthestNearestDistance = Double.POSITIVE_INFINITY;

		// This is the maximum MinMaxDistance among all the InnerNodes visited
		// until now.
		double maximumMinMaxDistanse = Double.POSITIVE_INFINITY;

		// A buffer for the results. Contains all the neighbours found...
		// Neighbours are added and removed during the process.
		ArrayList<NNeighbourEntry> resultBuffer = new ArrayList<NNeighbourEntry>(
				noNeighbours);

		// The active branch list as described in Roussopoulos paper. Contains
		// the NNeighbourRectangle (eg. nodes) that have passed all the pruning
		// strategies, by ascending order according to the MinMaxDistance.
		ArrayList<NNeighbourRectangle> activeBranchList = new ArrayList<NNeighbourRectangle>();

		// Create an NNeighbourRectangle (with the appropriate distances) for
		// the root and add it to the ABL.
		activeBranchList.add(new NNeighbourRectangle(root, root
				.getMinimumBoundryRectangle().distance(centre), minmaxDistance(
				root.getMinimumBoundryRectangle(), centre)));

		// The Node currently visited.
		Node visited = null;

		// While there is at least a Node to examine...
		while (!activeBranchList.isEmpty())
		{
			// Take the First Entry in the ABL...
			visited = activeBranchList.remove(0).entry;

			// If it's a leaf...
			if (visited.isLeaf())
			{
				LeafNode leaf = (LeafNode) visited;

				// Load the points
				leaf.loadPage();

				// Point holder...
				Point tempPoint;
				// ...and the minDistance of that point.
				double tempDistance;

				// For each Entry...
				for (int i = 0; i < leaf.getEntryCount(); i++)
				{
					// ...Get the Point...
					tempPoint = leaf.getEntry(i);

					// ...Calculate the minDistance...
					tempDistance = tempPoint.distance(centre);

					// Nearest Neighbour test & Pruning Strategy 2 are applied
					if (tempDistance <= furthestNearestDistance
							&& tempDistance <= maximumMinMaxDistanse)
					{
						// Create the NNeighbourEntry to host the point and it's
						// distance.
						NNeighbourEntry newNeighbour = new NNeighbourEntry(
								tempPoint, tempDistance);

						// Find where it should be placed in the result buffer..
						int insertionPoint = Collections.binarySearch(
								resultBuffer, newNeighbour, defaultComparator);
						insertionPoint = insertionPoint >= 0 ? insertionPoint
								: -insertionPoint - 1;
						// (For -insertionPoint -1 see binarySeach javadoc)

						// ...and insert it.
						resultBuffer.add(insertionPoint, newNeighbour);

						// Then eliminate the redundant Nearest neighbors.

						// Counts how many neighbours(of the furthest ones) have
						// the same distance.
						int sameDistanceCount = 0;

						// Counting & Eliminating previous Nearest neighbors...
						while (resultBuffer.size() - sameDistanceCount > noNeighbours)
						{
							// If the size - 1 element (the last) has the same
							// distance with size - sameDistanceCount - 2
							// increase the count
							// ( the -2 is -1 from the counting ([0,n-1]) and -1
							// to skip the last element )
							if (defaultComparator.compare(resultBuffer
									.get(resultBuffer.size()
											- sameDistanceCount - 2),
									resultBuffer.get(resultBuffer.size() - 1)) == 0)
							{
								sameDistanceCount++;
							}
							// Else ELIMINATE
							else
							{
								// eliminate the sameDistanceCount + 1 last
								// points ( +1 for THE LAST ONE ) so that the
								// buffer has size k (or more in the case of m
								// same last point with size k+m -1)
								for (int j = 0; j < sameDistanceCount + 1; j++)
								{
									resultBuffer
											.remove(resultBuffer.size() - 1);
								}
							}
						}
						// If the required number of neighbours have been
						// found...
						if (resultBuffer.size() >= noNeighbours)
						{
							// Update the furthestNearestDistance with the value
							// of the last element of the result buffer.
							furthestNearestDistance = resultBuffer
									.get(resultBuffer.size() - 1).distanceFromCentre;
							// And if the ABL is not empty also update the
							// maximumMinMaxDistanse.
							if (!activeBranchList.isEmpty())
								maximumMinMaxDistanse = activeBranchList
										.get(activeBranchList.size() - 1).minMaxDistance;
						}
					}
				}// end for

				// Finally release the page and restart the process.
				leaf.unloadPage();
			}
			// If it's an Inner node...
			else
			{
				InnerNode innerNode = (InnerNode) visited;

				// A Node holder to host an entry of the visited node...
				Node tempNode;
				// ...its minDistance...
				double tempMinDistance;
				// ... and its MinMaxDistance.
				double tempMinMaxDistance;

				// For each entry...
				for (int i = 0; i < innerNode.getEntryCount(); i++)
				{
					// ...Get the entry/Node...
					tempNode = innerNode.getEntry(i);
					// ...Calculate its MinMaxDistance.
					tempMinMaxDistance = minmaxDistance(tempNode
							.getMinimumBoundryRectangle(), centre);

					// apply Pruning Strategy 1: discard it...
					if (tempMinMaxDistance > maximumMinMaxDistanse)
					{
						// (if the buffer is not full then minimumMinMaxDistanse
						// = Infinity)
						continue;
					}

					// If not pruned...Calculate its MinDistance...
					tempMinDistance = tempNode.getMinimumBoundryRectangle()
							.distance(centre);

					// ...Create the NNeighbourRectangle to host the entry and
					// its distances.
					NNeighbourRectangle newNRectangle = new NNeighbourRectangle(
							tempNode, tempMinDistance, tempMinMaxDistance);

					// Then find where it should be placed inside the ABL...
					int insertionPoint = Collections.binarySearch(
							activeBranchList, newNRectangle, defaultComparator);
					insertionPoint = insertionPoint >= 0 ? insertionPoint
							: -insertionPoint - 1;
					// (For -insertionPoint -1 see binarySeach javadoc)

					// ...and insert it... (and restart the process)
					activeBranchList.add(insertionPoint, newNRectangle);
				}
			}
		}

		// Transform the result buffer to a Point[] removing the wrapper and
		// leaving the Points naked.
		Point[] result = new Point[resultBuffer.size()];
		Iterator<NNeighbourEntry> iterator = resultBuffer.iterator();
		for (int i = 0; iterator.hasNext(); i++)
		{
			result[i] = (Point) iterator.next().entry;
		}

		// Return the result.
		return result;
	}

	/**
	 * Calculates the MinMaxDistance as described to Roussopoulos paper.<br>
	 * It has linear cost (depending on the dimensions of course)
	 * 
	 * @param minimumBoundryRectangle
	 *            The rectangle to calculate the MinMaxDistance from the centre.
	 * @param centre
	 *            The point from which the distance is calculated
	 * @return The distance calculated.
	 */
	private double minmaxDistance(Rectangle minimumBoundryRectangle,
			Point centre)
	{
		// The algorithm is based on Roussopoulos paper.
		// The first Step it to calculate a Sum.
		// The second Step is to select the minimum Distance derived from the
		// above Sum.

		// This is the sum stated in his paper. Sum(1,n, (Pi - rMi)^2)
		// Where rMi = (Pi < (Si+Ti)/2) ? Si : Ti
		double sum = 0;

		// Pi Si Ti respectively.
		double pointCoordinate, rectangleMinCoordinate, rectangleMaxCoordinate;

		// This is equal to (Pi - rMi) for each iteration.
		double sumFactor;

		// Calculating the sum.
		for (int i = 0; i < Main.DIMENSIONS; i++)
		{
			pointCoordinate = centre.getCoordinate(i); // Pi
			rectangleMinCoordinate = minimumBoundryRectangle.getMininimum(i); // Si
			rectangleMaxCoordinate = minimumBoundryRectangle.getMaximum(i); // Ti
			// Calculating (Pi - rMi)
			sumFactor = pointCoordinate
					- (pointCoordinate >= (rectangleMinCoordinate + rectangleMaxCoordinate) / 2d ? rectangleMinCoordinate
							* rectangleMinCoordinate
							: rectangleMaxCoordinate * rectangleMaxCoordinate);
			// Calculating (Pi - rMi)^2 and adding it to Sum.
			sum += sumFactor * sumFactor;
		}

		// The minimum distance up until now.
		double minDistanceSquared = Double.POSITIVE_INFINITY;

		// The Distance in i-Dimension.
		double tempDistance;
		for (int i = 0; i < Main.DIMENSIONS; i++)
		{
			pointCoordinate = centre.getCoordinate(i); // Pi
			rectangleMinCoordinate = minimumBoundryRectangle.getMininimum(i); // Si
			rectangleMaxCoordinate = minimumBoundryRectangle.getMaximum(i); // Ti
			// Having done some math to alter the procedure ( check the extended
			// documentation)
			// This factor is equal to pi - (Pi + Si)^2 + (Pi +Ti)^2
			sumFactor = -(pointCoordinate + rectangleMinCoordinate)
					* (pointCoordinate + rectangleMinCoordinate)
					+ (pointCoordinate + rectangleMaxCoordinate)
					* (pointCoordinate + rectangleMaxCoordinate);
			// Calculating the distance by adding or subtracting the sum factor.
			tempDistance = sum
					+ sumFactor
					* ((pointCoordinate >= (rectangleMinCoordinate + rectangleMaxCoordinate) / 2d) ? 1
							: -1);
			// If is less than the minimum Distance so far
			if (tempDistance < minDistanceSquared)
			{
				// Update it...
				minDistanceSquared = tempDistance;
			}
		}
		return Math.sqrt(minDistanceSquared);
	}

	/**
	 * Calculates a range query.Given the point of origin and the distance finds
	 * all the points within this area.<br>
	 * 
	 * @param centre
	 *            The point of origin.
	 * @param distance
	 *            The distance.
	 * @return A Point[] containing the results. The array might have lenght ==
	 *         0 in case no results are found.
	 */
	public Point[] rangeQuery(Point centre, double distance)
	{
		// The node visited.
		Node currentlyVisited = null;

		// The results.
		LinkedList<Point> pointsFound = new LinkedList<Point>();

		// Nodes remaining to be visited.
		Stack<Node> toVisit = new Stack<Node>();

		// Starting from the root.
		toVisit.push(root);

		// Unless no Nodes are left to be visited.
		while (!toVisit.isEmpty())
		{
			// Visit the top Node.
			currentlyVisited = toVisit.pop();

			// If the MinimumBoundaryRectangle of the node is closer than the
			// specified distance...Check its Entries.
			if (currentlyVisited.getMinimumBoundryRectangle().distance(centre) <= distance)
			{
				// If the Node is a leaf.
				if (currentlyVisited.isLeaf())
				{
					// Load points from disk.
					LeafNode leaf = (LeafNode) currentlyVisited;
					leaf.loadPage();

					// For each point in the Leaf.
					for (int i = 0; i < leaf.getEntryCount(); i++)
					{
						// Check if it is within range...
						if (leaf.getEntry(i).distance(centre) <= distance)
						{
							// ...and add it to the result.
							pointsFound.add(leaf.getEntry(i));
						}
					}

					// Finally release the page.
					leaf.unloadPage();
				}
				else
				{
					// If it is an InnerNode...
					InnerNode inner = (InnerNode) currentlyVisited;

					// For each entry/node in the node...
					for (int i = 0; i < inner.getEntryCount(); i++)
					{
						// Check if it is within range based on the minimum
						// distance...
						if (inner.getEntry(i).getMinimumBoundryRectangle()
								.distance(centre) <= distance)
						{
							// ...and add that node to the nodes that must be
							// visited.
							toVisit.push(inner.getEntry(i));
						}
					}
				}
			}
		}

		// Transform the list of results to an array... if none found the array
		// has length == 0.
		return pointsFound.toArray(new Point[pointsFound.size()]);
	}

	/**
	 * Inserts a point to the Tree-Structure.<br>
	 * It invokes {@link #chooseLeaf(Point)} to find the appropriate leaf to
	 * insert to. Checks whether the leaf is full and in that case invokes
	 * {@link LeafNode#splitNode(Entry)}. Finally it propagates the changes
	 * upwards using {@link #adjustTree(Node, Node)} and if a root split has
	 * occurred, it creates a new root.(Taken from Guttman's paper)
	 * 
	 * @see #chooseLeaf(Point)
	 * @see #adjustTree(Node, Node)
	 * @see LeafNode#splitNode(Entry)
	 * 
	 * @param point
	 *            The point to be inserted
	 */
	public void insert(Point point)
	{
		// This is taken from Guttman's original paper

		// I1 [Find position for new record] Invoke ChooseLeaf to select a
		// leaf node L in which to place r
		LeafNode leaf = chooseLeaf(point);
		LeafNode newLeaf = null;

		// I2 [Add record to leaf node] If L has room for another entry,
		// install E. Otherwise invoke SplitNode to obtain L and LL containing
		// E and all the old entries of L
		if (!leaf.isFull())
		{
			// Load the page, insert and write the page back to the disk
			leaf.loadPage();
			leaf.addEntry(point);
			leaf.unloadPage();
		}
		else
		{
			// When full, split must occur.
			newLeaf = leaf.splitNode(point);
		}
		pointCount++;

		// I3 [Propagate changes upwards] Invoke AdjustTree on L, also passing
		// LL
		// if a split was performed
		Node newNode = adjustTree(leaf, newLeaf);

		// I4 [Grow tree taller] If node split propagation caused the root to
		// split, create a new root whose children are the two resulting nodes.
		if (newNode != null)
		{
			// If root was split then the new root is definitely an InnerNode.
			InnerNode newRoot = new InnerNode();

			// Add the old root & it's split part as children of the new node.
			newRoot.addEntry(this.root);
			newRoot.addEntry(newNode);
			this.root = newRoot;
			height++;
		}

	}

	/**
	 * Ascend from a leaf node L to the root, adjusting
	 * MinimumBoundaryRectangles and propagating node splits as necessary.Used
	 * by {@link #insert(Point)}<br> ( Also taken from Guttman's paper).
	 * 
	 * @param leaf
	 *            The leaf that the point was insert.
	 * @param newLeaf
	 *            The new leaf if a split has occurred;null otherwise.
	 * @return The new root if a root split occurred;else null.
	 */
	private Node adjustTree(Node leaf, Node newLeaf)
	{

		// AT1 [Initialize] Set N=L. If L was split previously, set NN to be
		// the resulting second node.
		Node n = leaf;
		Node nn = newLeaf;

		// AT2 [Check if done] If N is the root, stop
		while (n != root)
		{

			// AT3 [Adjust covering rectangle in parent entry] Let P be the
			// parent node of N, and let En be N's entry in P. Adjust EnI so
			// that it tightly encloses all entry rectangles in N.

			// Using the stack to retrieve the parent and the index.
			InnerNode parent = parents.pop();
			int entryIndex = parentEntryIndex.pop();

			// If the child's MinimumBoundaryRectangle is not contained in the
			// parent's, just add the n to the parent entry.
			if (!parent.getEntry(entryIndex).getMinimumBoundryRectangle()
					.contains((n.getMinimumBoundryRectangle())))
			{
				parent.getMinimumBoundryRectangle().add(n);
			}

			// AT4 [Propagate node split upward] If N has a partner NN resulting
			// from an earlier split, create a new entry Enn with Ennp pointing
			// to NN and Enni enclosing all rectangles in NN. Add Enn to P if
			// there is room. Otherwise, invoke splitNode to produce P and PP
			// containing Enn and all P's old entries.
			InnerNode newNode = null;
			if (nn != null)
			{
				if (parent.isFull())
				{
					newNode = parent.splitNode(nn);
				}
				else
				{
					parent.addEntry(nn);
				}
			}

			// AT5 [Move up to next level] Set N = P and set NN = PP if a split
			// occurred. Repeat from AT2
			n = parent;
			nn = newNode;

			parent = null;
			newNode = null;
		}
		return nn;
	}

	/**
	 * Chooses a leaf to add the rectangle to.Used by {@link #insert(Point)}<br> (
	 * Also taken from Guttman's paper).
	 */
	private LeafNode chooseLeaf(Point point)
	{

		// CL1 [Initialize] Set N to be the root node
		Node n = root;

		// Resets the stacks
		parents.clear();
		parentEntryIndex.clear();

		// CL2 [Leaf check] If N is a leaf, return N
		while (!n.isLeaf())
		{

			InnerNode innerNode = (InnerNode) n;

			// CL3 [Choose subtree] If N is not at the desired level, let F be
			// the entry in N whose rectangle FI needs least enlargement to
			// include EI. Resolve ties by choosing the entry with the rectangle
			// of smaller area.

			// Set the first entry's enlargement as the least.
			double leastEnlargement = innerNode.getEntry(0)
					.getMinimumBoundryRectangle().enlargement(point);
			int index = 0; // index of Node in subtree

			// For the rest...
			for (int i = 1; i < n.getEntryCount(); i++)
			{
				Rectangle candidateRectangle = innerNode.getEntry(i)
						.getMinimumBoundryRectangle();
				// Calculate it's enlargement...
				double candidateEnlargement = candidateRectangle
						.enlargement(point);
				// Check if it's less or equal with the least one.
				// If it's equal also check if the Node with the least
				// enlargement has greater area than the candidate.
				if ((candidateEnlargement < leastEnlargement)
						|| ((candidateEnlargement == leastEnlargement) && (candidateRectangle
								.area() < innerNode.getEntry(index)
								.getMinimumBoundryRectangle().area())))
				{
					// .. Then choose this Node as the most appropriate to add
					// the point to.
					index = i;
					leastEnlargement = candidateEnlargement;
				}
			}

			// Push the parent and the index of the chosen node to the stacks
			parents.push(innerNode);
			parentEntryIndex.push(index);

			// CL4 [Descend until a leaf is reached] Set N to be the child node
			// pointed to by Fp and repeat from CL2

			// Visit the selected Node
			n = innerNode.getEntry(index);
		}
		return (LeafNode) n;
	}
}
