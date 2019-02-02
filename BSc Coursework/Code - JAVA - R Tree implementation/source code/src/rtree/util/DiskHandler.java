package rtree.util;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.nio.ByteBuffer;

import rtree.Main;

/**
 * This class implements a handler for the static data inside our disk. It
 * retrieves and stores the contents of the R-tree into the appropriate files.
 * 
 * @author Sskalist
 */
public abstract class DiskHandler
{
	/**
	 * It loads a page from the disk and returns it to a {@link Point} array.
	 * 
	 * @param pageNumber
	 *            The number of the page-target.
	 * @param maxEntries
	 *            The maximum entries.
	 * @return An maxEntries-lengthed array containing the points loaded.<br>
	 *         it has from start to entryCount -1 the points loaded and until
	 *         the end null.
	 */
	public static Point[] loadFromDisk(long pageNumber, int entryCount,
			int maxEntries)
	{
		Point loadedPoints[] = null;
		loadedPoints = new Point[maxEntries];
		byte[] byteArray = null;
		try
		{
			// Opens the file in read mode and seeks to the appropriate position
			RandomAccessFile file = new RandomAccessFile(Main.getFileName()
					+ ".pgs", "r");
			file.seek(pageNumber * Main.PAGE_SIZE);

			// Reads Page_SIZE bytes and closes the file
			byteArray = new byte[Main.PAGE_SIZE];
			file.readFully(byteArray);
			file.close();
		} // end try
		catch (FileNotFoundException e)
		{
			// return null if not found
			return null;
		} // end catch
		catch (IOException e)
		{
			System.err.println("Fatal error! Reading page <" + pageNumber
					+ "> failed!");
			System.exit(-1);
		} // end catch

		// Wraps the data in byteBuffer
		ByteBuffer allData = ByteBuffer.wrap(byteArray);

		long pointID;
		double coordinates[];

		// loads the points from file creating the necessary Point objects
		for (int i = 0; i < entryCount; i++)
		{
			pointID = allData.getLong();
			coordinates = new double[Main.DIMENSIONS];
			for (int j = 0; j < coordinates.length; j++)
			{
				coordinates[j] = allData.getDouble();
			}
			loadedPoints[i] = new Point(pointID, coordinates);
		}

		return loadedPoints;
	} // end method loadPage

	/**
	 * It writes a page to a file on the disk.
	 * 
	 * @param entries
	 *            The entries which are about to be written to the file.
	 * @param entryCount
	 *            The number of entries in the Page/Node
	 * @param pageNumber
	 *            The number that shows the index of the page.
	 */
	public static void writeToDisk(Point[] entries, int entryCount,
			long pageNumber)
	{
		ByteBuffer buffer = ByteBuffer.allocate(Main.PAGE_SIZE);
		double coordinates[] = null;
		int i;

		// Prepares the Data
		for (i = 0; i < entryCount; i++)
		{
			buffer.putLong(entries[i].getPointID());
			coordinates = entries[i].getCoordinates();
			for (int j = 0; j < Main.DIMENSIONS; j++)
				buffer.putDouble(coordinates[j]);
		}

		try
		{
			// Opens the file and seeks to the appropriate position in the file
			RandomAccessFile file = new RandomAccessFile(Main.getFileName()
					+ ".pgs", "rw");
			file.seek(pageNumber * Main.PAGE_SIZE);
			// writes the entries to the file and closes the file
			file.write(buffer.array());
			file.close();
		} // end try
		catch (IOException e)
		{
			System.err.println("Fatal error! Writing page <" + pageNumber
					+ "> failed");
			System.exit(-4);
		} // end catch
	} // end method writePage
} // end class DiskHandler
