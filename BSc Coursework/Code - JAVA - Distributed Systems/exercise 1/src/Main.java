public class Main
{
	public static DistributedSystem simulator;
	public static InitialWindow initial;
	public static BasicWindow interact;
	public static RandomFileGenerator fileGenerator;

	private static int totalNumOfFilesToHandle;

	public static void main(String[] args)
	{
		initial = new InitialWindow();
		interact = new BasicWindow();
		initial.setVisible(true);
	} // end method main

	public static void initializeSystem(final int[] peerNumOfFiles)
	{
		int totalNumOfFiles = 0;
		for (int i = 0; i < peerNumOfFiles.length; i++)
			totalNumOfFiles += peerNumOfFiles[i];
		simulator = new DistributedSystem(peerNumOfFiles, totalNumOfFiles);
		totalNumOfFilesToHandle = totalNumOfFiles;
	} // end method initializeSystem

	public static int getTotalNumOfFilesToHandle()
	{
		return totalNumOfFilesToHandle;
	} // end method getTotalNumOfFilesToHandle
} // end class
