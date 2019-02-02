public class UploadingProcess extends Thread
{
	private final Peer sourcePeer;
	private final Peer destinationPeer;
	private final File file;

	private final long MILISECOND = 1000;

	public UploadingProcess(final Peer sourcePeer, final Peer destinationPeer,
			final File file)
	{
		this.sourcePeer = sourcePeer;
		this.destinationPeer = destinationPeer;
		this.file = file;
	} // end method DowloadingProcess

	@Override public void run()
	{
		// ������������ � ������ �� ��� ����� �� ������������ �� �������� ��'
		// ��� ��� ������� ���� ����. ����� � ������ ������� �� �� ��������� ��'
		// ���� ���� ���: �� ����� ����������� ��� ��������-���� ��� �� �����
		// ������������ ��� ��������-����������.
		int processRate = this.sourcePeer.getUploadRate() > this.destinationPeer
				.getDownloadRate() ? this.destinationPeer.getDownloadRate()
				: this.sourcePeer.getUploadRate();

		// ����������� ��' ���� ��� ����� ��� ����������� �������� ��� ��
		// ������� ��� ������� ������������ � ������ ��� �� ��������� �
		// ����������.
		float time = (float) this.file.getSize() / (float) processRate;
		try
		{
			// ��� ���� �� ������� �������� �� ���� <<��������>>...
			sleep((long) time * this.MILISECOND);

			// ��� ��� �������� ��������� �� ������ ��� ���� ������� ���
			// �������� ����������.
			this.destinationPeer.acquireFile(this.file);
		} // end try
		catch (InterruptedException e)
		{
			System.err.println("������ ���� �� �������� ��� �����������!");
			System.exit(-1);
		} // end catch
	} // end method run
} // end class UploadingProcess
