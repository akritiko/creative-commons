package rtree.util;

import java.util.Arrays;

import rtree.Main;

/**
 * @author Sskalist
 * 
 */
public class Point extends Entry
{
	/**
	 * Number of dimensions in a point.
	 */
	//private final static int DIMENSIONS = Main.DIMENSIONS;

	/**
	 * An array containing the coordinate for each of the {@link #DIMENSIONS}
	 */
	private double[] coordinates;

	/**
	 * The pointID. If not specified it is assigned the value of
	 * {@link Entry#entryID}
	 */
	private long pointID;

	/**
	 * Constructs a point with the given coordinates having {@link #pointID}
	 * equal to {@link Entry#entryID}.
	 * 
	 * @param coordinates
	 *            The coordinates of the point.
	 */
	public Point(double[] coordinates)
	{
		super();
		this.coordinates = coordinates;
		this.pointID = this.entryID;
	}

	/**
	 * Constructs a point with the given coordinates and the given pointID.
	 * 
	 * @param pointID
	 *            The desired pointID.
	 * @param coordinates
	 *            The coordinates of the point.
	 */
	public Point(long pointID, double[] coordinates)
	{
		super();
		this.pointID = pointID;
		this.coordinates = coordinates;
	}

	/**
	 * Clones the {@link #coordinates}
	 * 
	 * @return A clone of the coordinates
	 */
	public double[] getCoordinates()
	{
		return this.coordinates.clone();
	}

	/**
	 * Gets the coordinate at the specified index.
	 * 
	 * @param index
	 * @return The coordinate at index.
	 */
	public double getCoordinate(int index)
	{
		return this.coordinates[index];
	}

	/**
	 * Gets the {@link Point#coordinates} array without cloning it.
	 * 
	 * @return the coordinates
	 */
	public double[] getCoordinatesNoClone()
	{
		return this.coordinates;
	}

	/**
	 * Gets the id of the point.
	 * 
	 * @return the {@link #pointID}
	 */
	public long getPointID()
	{
		return this.pointID;
	}

	/**
	 * Calculates the Euclidian Distance between this {@link Point} and the
	 * {@link Point} passes as parameter.
	 * 
	 * @param from
	 *            The end-point.
	 * @return The Euclidian Distance.
	 */
	public double distance(Point from)
	{
		double squaredDistance = 0;
		for (int i = 0; i < Main.DIMENSIONS; i++)
		{
			squaredDistance += (this.coordinates[i] - from.coordinates[i])
					* (this.coordinates[i] - from.coordinates[i]);
		}
		return Math.sqrt(squaredDistance);
	}

	/**
	 * Creates a string containing the {@link #pointID} and using
	 * {@link Arrays#toString(double[])} to transform the {@link #coordinates}
	 * array.The String representation is in the form:<br><br>
	 * PointID:10 Coordinates:[1.2,3.4]
	 * 
	 * @return A String representation of the point.
	 * @see Arrays#toString(double[])
	 */
	@Override
	public String toString()
	{
		return "PointID:" + this.pointID + " Coordinates:"
				+ Arrays.toString(this.coordinates);
	}
}
