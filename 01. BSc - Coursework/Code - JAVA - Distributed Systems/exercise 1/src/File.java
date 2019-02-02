public class File
{
	private final String fileName;
	private final int fileSize; // size in Kbytes

	public File(final String fileName, final int fileSize)
	{
		this.fileName = fileName;
		this.fileSize = fileSize;
	} // end method File

	public String getFileName()
	{
		return this.fileName;
	} // end method getFileName

	public int getSize()
	{
		return this.fileSize;
	} // end method getSize
} // end class File
