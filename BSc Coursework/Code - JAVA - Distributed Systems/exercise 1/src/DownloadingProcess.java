public class DownloadingProcess extends Thread
{
	private final int sourceUploadRate;
	private final Peer destinationPeer;
	private final File file;
	private final int MILISECOND = 1000;

	public DownloadingProcess(final int sourceUploadRate,
			final Peer destinationPeer, final File file)
	{
		this.sourceUploadRate = sourceUploadRate;
		this.destinationPeer = destinationPeer;
		this.file = file;
	} // end method DowloadingProcess

	public void run()
	{
		int processRate = this.sourceUploadRate > this.destinationPeer
				.getDownloadRate() ? this.destinationPeer.getDownloadRate()
				: this.sourceUploadRate;
		float time = ((float) this.file.getSize()) / ((float) processRate);
		try
		{
			sleep((long) (time * this.MILISECOND));
			destinationPeer.newFileAcquired(this.file, true);
		} // end try
		catch (InterruptedException e)
		{
			System.err.println(e.toString());
			e.printStackTrace();
		} // end catch
	} // end method run
} // end class DowloadingProcess
