package rtree;

import java.io.File;

import rtree.gui.MainWindow;

/**
 * 
 */

/**
 * @author Sskalist
 * 
 */
public class Main
{

	public static final int PAGE_SIZE = 1024;
	public static int DIMENSIONS;

	static
	{
		deleteFile();
	}

	/**
	 * @param args
	 */
	public static void main(String[] args)
	{ 
		MainWindow a = new MainWindow();
		a.setVisible(true);
	}

	public static void deleteFile()
	{
		File file = new File(getFileName() + ".pgs");
		file.delete();
	}

	public final static Rtree myTree = new Rtree();
	
	public static String getFileName()
	{

		return "./ourRtree";
	}

}
