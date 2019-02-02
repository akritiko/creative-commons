package rtree.util;

import java.util.Arrays;

import rtree.Main;


/**
 * This is a basic representation of a multidimensional rectangle. It consists
 * of two arrays, <code>min</code> and <code>max</code>, containing the
 * minimum and max values respectively.
 * 
 * @author Sskalist
 */
public class Rectangle
{
	/**
	 * Number of dimensions in a rectangle.
	 */
	//private int DIMENSIONS;

	/**
	 * Array containing the minimum value for each dimension
	 */
	private double[] min;

	/**
	 * Array containing the maximum value for each dimension
	 */
	private double[] max;

	/**
	 * Default Constructor.<br>
	 * Initializes the min array with the Double.POSITIVE_INFINITY value and<br>
	 * the max array with the Double.NEGATIVE_INFINITY value.
	 */
	public Rectangle()
	{
		min = new double[Main.DIMENSIONS];
		max = new double[Main.DIMENSIONS];
		for (int i = 0; i < Main.DIMENSIONS; i++)
		{
			min[i] = Double.POSITIVE_INFINITY;
			max[i] = Double.NEGATIVE_INFINITY;
		}
	}

	/**
	 * Constructor. Constructs an new Rectangle according to the passed arrays
	 * using {@link #set(double[], double[])}
	 * 
	 * @param min
	 *            array containing the minimum value for each dimension; eg {
	 *            min(x), min(y) }
	 * @param max
	 *            array containing the maximum value for each dimension; eg {
	 *            max(x), max(y) }
	 */
	public Rectangle(double[] min, double[] max)
	{
		set(min, max);
	}

	/**
	 * Sets the size of the rectangle.
	 * 
	 * @param min
	 *            Array containing the minimum value for each dimension
	 * @param max
	 *            Array containing the maximum value for each dimension
	 * @throws RuntimeException
	 *             if the length of either <b>min</b> or <b>max</b> differs
	 *             from {@link Rectangle#DIMENSIONS}
	 */
	public void set(double[] min, double[] max)
	{
		if (min.length != Main.DIMENSIONS || max.length != Main.DIMENSIONS) { throw new RuntimeException(
				"Error in Rectangle constructor: "
						+ "min and max arrays must be of length " + Main.DIMENSIONS); }
		this.min = min;
		this.max = max;
	}

	/**
	 * Return the distance between this rectangle and the passed point. If the
	 * rectangle contains the point, the distance is zero.
	 * 
	 * @param origin
	 *            Point to find the distance to
	 * 
	 * @return distance between this rectangle and the passed point.
	 */
	public double distance(Point origin)
	{
		double distanceSquared = 0;
		for (int i = 0; i < Main.DIMENSIONS; i++)
		{
			double greatestMin = Math.max(min[i], origin
					.getCoordinatesNoClone()[i]);
			double leastMax = Math.min(max[i],
					origin.getCoordinatesNoClone()[i]);
			if (greatestMin > leastMax)
			{
				distanceSquared += ((greatestMin - leastMax) * (greatestMin - leastMax));
			}
		}
		return Math.sqrt(distanceSquared);
	}

	/**
	 * Calculates the how much the rectangle will grow if the <code>entry</code>
	 * would be added. The rectangle is not altered.
	 * 
	 * @param entry
	 *            The entry that would be added
	 * @return The enlargement. In case of error returns
	 *         {@link Double#POSITIVE_INFINITY}
	 * @see #enlargement(Point)
	 * @see #enlargement(Rectangle)
	 */
	public double enlargement(Entry entry)
	{
		if (entry instanceof Point) { return this.enlargement((Point) entry); }
		if (entry instanceof Node) { return this.enlargement(((Node) entry)
				.getMinimumBoundryRectangle()); }
		// on error
		return Double.POSITIVE_INFINITY;
	}

	/**
	 * Calculate the area by which this rectangle would be enlarged if the
	 * passed point was added to it. The rectangle is not altered.
	 * 
	 * @param point
	 *            Point to be added to this rectangle, in order to compute the
	 *            enlargement.
	 */
	public double enlargement(Point point)
	{
		double enlargedArea = 1;
		double coordinates[] = point.getCoordinates();
		for (int i = 0; i < Main.DIMENSIONS; i++)
		{
			enlargedArea *= (Math.max(max[i], coordinates[i]) - Math.min(
					min[i], coordinates[i]));
		}
		return enlargedArea - this.area();
	}

	/**
	 * Calculate the area by which this rectangle would be enlarged if added to
	 * the passed rectangle. Neither rectangle is altered.
	 * 
	 * @param rectangle
	 *            Rectangle to be added to this rectangle, in order to compute
	 *            the enlaregment.
	 */
	public double enlargement(Rectangle rectangle)
	{
		double enlargedArea = 1;
		for (int i = 0; i < Main.DIMENSIONS; i++)
		{
			enlargedArea *= (Math.max(max[i], rectangle.max[i]) - Math.min(
					min[i], rectangle.min[i]));
		}
		return enlargedArea - this.area();
	}

	/**
	 * Compute the area of this rectangle.
	 * 
	 * @return The area of this rectangle
	 */
	public double area()
	{
		if (max[0] == Double.NEGATIVE_INFINITY
				&& min[0] == Double.POSITIVE_INFINITY) return 0;
		double area = 1;
		for (int i = 0; i < Main.DIMENSIONS; i++)
			area *= max[i] - min[i];
		return area;
	}

	/**
	 * Adds the entry. In case the entry is not an instance of {@link Point} or
	 * {@link Node} throws an Exception.
	 * 
	 * @param entry
	 *            The entry to be added.
	 * @see #add(Point)
	 * @see #add(Rectangle)
	 * @throws RuntimeException
	 */
	public void add(Entry entry)
	{
		if (entry instanceof Point)
		{
			this.add((Point) entry);
		}
		else if (entry instanceof Node)
		{
			this.add(((Node) entry).getMinimumBoundryRectangle());
		}
		else
			throw new RuntimeException();
	}

	/**
	 * Computes the union of this rectangle and the passed rectangle, storing
	 * the result in this rectangle.
	 * 
	 * @param rectangle
	 *            Rectangle to add to this rectangle
	 */
	private void add(Rectangle rectangle)
	{
		for (int i = 0; i < Main.DIMENSIONS; i++)
		{
			if (rectangle.min[i] < min[i])
			{
				min[i] = rectangle.min[i];
			}
			if (rectangle.max[i] > max[i])
			{
				max[i] = rectangle.max[i];
			}
		}
	}

	/**
	 * Computes the union of this rectangle and the passed point, storing the
	 * result in this rectangle.
	 * 
	 * @param toBeAdded
	 *            Rectangle to add to this rectangle
	 */
	private void add(Point toBeAdded)
	{
		double pointCoordinates[] = toBeAdded.getCoordinates();
		for (int i = 0; i < Main.DIMENSIONS; i++)
		{
			if (pointCoordinates[i] < min[i])
			{
				min[i] = pointCoordinates[i];
			}
			if (pointCoordinates[i] > max[i])
			{
				max[i] = pointCoordinates[i];
			}
		}
	}

	/**
	 * Gets the specified value of the <code>min</code> array
	 * 
	 * @param index
	 *            The index of the required value.
	 * @return The required value
	 */
	public double getMininimum(int index)
	{
		return min[index];
	}

	/**
	 * Gets the <code>min</code> array.
	 * 
	 * @return The {@link #min} array.
	 */
	public double[] getMininimumArray()
	{
		return min;
	}

	/**
	 * Gets the specified value of the <code>max</code> array
	 * 
	 * @param index
	 *            The index of the required value.
	 * @return The required value.
	 */
	public double getMaximum(int index)
	{
		return max[index];
	}

	/**
	 * Gets the <code>max</code> array.
	 * 
	 * @return The {@link #max} array.
	 */
	public double[] getMaximumArray()
	{
		return max.clone();
	}

	/**
	 * Determine whether this rectangle is equal to a given object. Equality is
	 * determined by the bounds of the rectangle.
	 * 
	 * @param obgject -
	 *            The object to compare with this rectangle.
	 */
	public boolean equals(Object obgject)
	{
		if (obgject instanceof Rectangle)
		{
			Rectangle r = (Rectangle) obgject;
			if (Arrays.equals(r.min, min) && Arrays.equals(r.max, max)) { return true; }
		}
		return false;
	}

	/**
	   * Determine whether this rectangle contains the specified rectangle
	   * 
	   * @param rectangle The rectangle that might be contained by this rectangle
	   * 
	   * @return true if this rectangle contains the passed rectangle; otherwise false
	   */
	  public boolean contains(Rectangle rectangle) {
	    for (int i = 0; i < Main.DIMENSIONS; i++) {
	      if (max[i] < rectangle.max[i] || min[i] > rectangle.min[i]) {
	        return false;
	      }
	    }
	    return true;     
	  }
	
	/**
	 * Return a string representation of this rectangle, in the form: [1.2,
	 * 3.4],[5.6, 7.8]
	 * 
	 * @return String String representation of this rectangle.
	 */
	public String toString()
	{
		return Arrays.toString(this.min) + "," + Arrays.toString(this.max);
	}
}
