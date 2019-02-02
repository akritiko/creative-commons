import java.util.Hashtable;
import java.util.LinkedList;
import java.util.Random;
import java.util.concurrent.LinkedBlockingQueue;

public class Peer extends Thread
{
	private final int id;
	private final int uploadRate;
	private final int downloadRate;

	private final Hashtable<String, File> fileBase;
	private final LinkedBlockingQueue<Message> messageQueue;
	private final LinkedList<Peer> neighbours;

	private int numOfFiles;
	private final int initialNumOfFiles;
	private final int totalNumOfFiles;

	private long numOfRequestsServed;
	private long numOfRequestsReceived;
	private long numOfFilesDownloaded;

	private final int TIMEOUT = 400;

	public Peer(final int id, final int initialNumOfFiles,
			final int totalNumOfFiles)
	{
		super();

		this.id = id;
		Random randomizer = new Random();
		this.downloadRate = randomizer.nextInt(16) + 10;
		this.uploadRate = randomizer.nextInt(this.downloadRate) + 5;

		this.fileBase = new Hashtable<String, File>(totalNumOfFiles + 1, 1);
		this.messageQueue = new LinkedBlockingQueue<Message>();
		this.neighbours = new LinkedList<Peer>();

		this.numOfFiles = 0;
		this.initialNumOfFiles = initialNumOfFiles;
		this.totalNumOfFiles = totalNumOfFiles;

		this.numOfRequestsServed = 0;
		this.numOfRequestsReceived = 0;
		this.numOfFilesDownloaded = 0;
	} // end method Peer

	@Override public void run()
	{
		while (!Main.simulator.replication50percent())
		{
			try
			{
				Message request = this.messageQueue.take();

				switch (request.getMessageType())
				{
				case REQUEST_FOR_FILE:
					this.searchFile(request);
					break;
				case FILE_FOUND:
					this.startDownloading(request);
					break;
				case START_UPLOADING:
					this.startUploading(request.getPreviousTransmiter(),
							request.getFileName());
					break;
				case UNABLE_TO_FIND_FILE:
					this.searchFailed(request.getFileName());
					break;
				default:
					System.err.println(this.id
							+ ": �������� ����� ��������� - "
							+ request.getMessageType());
					System.exit(-1);
				} // end switch

				sleep(this.TIMEOUT);
			} // end try
			catch (InterruptedException e)
			{
				System.err.println("������ ���� ��� ����������"
						+ " �������� ��������� ��' ��� ����!");
				System.exit(-1);
			} // end catch
		} // end while
		Main.simulator.basicWindow.writeToTxtArea(this.id, "\n@ � �������� "
				+ this.id + " ������������.");
	} // end method run

	private void searchFile(final Message request)
	{
		this.numOfRequestsReceived++;

		File file = this.fileBase.get(request.getFileName());

		if (file == null)
		{
			// �� ������ ��� ������� ��� ����...

			// ��������� ��� ������ �� ����� ������������� ��� ��������� ���
			// ��� ������ ��� �������.
			if (request.reachedRetransmitionLimit())
			{
				// ��� �� ������ ������ �� ���� ���������������, ���� ���������
				// ��� ������ ���� ������ �������� ��� �������� ������� ��
				// ������ �� ������.
				Peer destination = request.getInitialTransmiter();

				request.setMessageType(MsgType.UNABLE_TO_FIND_FILE);
				request.setPreviousTransmiter(this);

				destination.receiveMessage(request);
				return;
			} // end if

			// ���� ��� ���� ������ �� ���� �������������� ���������� �
			// ���������� ����������� ���� �������� ��� ��������, ����� ���
			// ��������� ��� ��� ������ ��������� � ��� ��� ������� ��� ���
			// ����� ����� �� ������.
			Peer previousSender = request.getPreviousTransmiter();

			request.setPreviousTransmiter(this);
			request.increaseRetransmitionCounter();

			for (int i = 0; i < this.neighbours.size(); i++)
			{
				if (this.neighbours.get(i) != request.getInitialTransmiter()
						&& this.neighbours.get(i) != previousSender)
				{
					this.neighbours.get(i).receiveMessage(request.clone());
				} // end if
			} // end for
		} // end if
		else if (file.getSize() == -1)
		{
			// �� ������ ������������� ���� ���� ������ ���������.
			if (request.hasNotBeenRetransmited())
			{
				Main.simulator.basicWindow
						.writeToTxtArea(this.id, "# �� ������ "
								+ request.getFileName() + " ����������!");
			} // end if
		} // end else if
		else
		{
			Peer destination = request.getInitialTransmiter();

			if (destination == this)
			{
				// ���� �� ���� ��������� ��������� ������ �� ����������� ������
				// ��� ����� � ���������� ����� � ����� � �������� ��� ��������
				// �� ������ ����. ������� ������� ����� ����������� ��� ������
				// ����.
				Main.simulator.basicWindow.writeToTxtArea(this.id,
						"# �� ������ " + request.getFileName() + " �������!");
				return;
			} // end if

			// �� ������ ������� ��� ����� �������, ����� ������������ �
			// ������� ����������.
			request.setMessageType(MsgType.FILE_FOUND);
			request.setPreviousTransmiter(this);

			destination.receiveMessage(request);
		} // end else
	} // end method searchFile

	private void startDownloading(final Message request)
	{
		File file = this.fileBase.get(request.getFileName());

		if (file == null)
		{
			this.numOfFilesDownloaded++;
			// ��� ���� ������ ������������ ��� ���� ��� ��������� ��� ����,
			// ���� ���� � �������� �� �������� ��� ���� ������� � ����������
			// ������������ ��� �� ��� ���������� ����������� ��� �� ������
			// ����.
			this.fileBase.put(request.getFileName(), new File("", -1));

			// ������� ������ ���� ������� ��� ������� �� ������ �� ��������� ��
			// ���������� �����������.
			Peer destination = request.getPreviousTransmiter();

			Main.simulator.basicWindow.writeToTxtArea(this.id,
					"# ������ ������������ ��� " + request.getFileName()
							+ " ��' ��� " + destination.getPeerId() + ".");

			request.setMessageType(MsgType.START_UPLOADING);
			request.setPreviousTransmiter(this);

			destination.receiveMessage(request);
		} // end if
	} // end method startDownloading

	private void startUploading(final Peer destination, final String fileName)
	{
		this.numOfRequestsServed++;

		File file = this.fileBase.get(fileName);

		// ������ � ���������� ����������� ���� ���������� ��� ������� ����
		// ������������� �������.
		UploadingProcess uploading = new UploadingProcess(this, destination,
				file.clone());

		uploading.start();

		Main.simulator.basicWindow.writeToTxtArea(this.id,
				"# ������ ����������� ��� " + fileName + " ���� "
						+ destination.getPeerId() + ".");
	} // end method startUploading

	private void searchFailed(final String fileName)
	{
		// ������� �� ������ �������� ��������� ��� ��� ������ ��� ���� ���
		// ����������.
		File file = this.fileBase.get(fileName);

		if (file == null)
		{
			Main.simulator.basicWindow.writeToTxtArea(this.id,
					"# � ��������� ��� " + fileName + " �������!");
		} // end if
	} // end method searchFailed

	public void acquireFile(final File newFile)
	{
		Main.simulator.basicWindow.writeToTxtArea(this.id, "# �� ������ "
				+ newFile.getFileName() + " ��������!");

		this.addToFileBase(newFile);
	} // end method acquireFile

	public void addToFileBase(final File newFile)
	{
		this.fileBase.put(newFile.getFileName(), newFile);
		this.numOfFiles++;

		Main.simulator.initialWindow.writeToTxtArea(this.id, newFile
				.getFileName());
	} // end method acquireFile

	public void receiveMessage(final Message newMessage)
	{
		try
		{
			this.messageQueue.put(newMessage);
		} // end try
		catch (InterruptedException e)
		{
			System.err.println("������ ���� ��� ����������"
					+ " ��������� ��������� ���� ����!");
			System.exit(-1);
		} // end catch
	} // end method receiveMessage

	public int getPeerId()
	{
		return this.id;
	} // end method getPeerId

	public int getDownloadRate()
	{
		return this.downloadRate;
	} // end method getDownloadRate

	public int getUploadRate()
	{
		return this.uploadRate;
	} // end method getUploadRate

	public int getNumOfFiles()
	{
		return this.numOfFiles;
	} // end method getNumOfFiles

	public int getInitialNumOfFiles()
	{
		return this.initialNumOfFiles;
	} // end method getInitialNumOfFiles()

	public void addNeighbour(Peer newNeighbour)
	{
		this.neighbours.add(newNeighbour);
	} // end method addNeighbour

	public boolean is50percentFull()
	{
		return this.numOfFiles > 0.5 * this.totalNumOfFiles;
	} // end method is50percentFull

	public synchronized void printResults()
	{
		System.err.println("�������� " + this.id + ":");
		System.err
				.println(" �� ����� ����������� " + this.uploadRate + " KB/s");
		System.err.println(" ��� ����� ������������ " + this.downloadRate
				+ " KB/s");
		System.err
				.println(" ����� " + this.numOfRequestsReceived + " ��������");
		System.err.println(" ����������� " + this.numOfRequestsServed
				+ " ��������");
		System.err
				.println(" �������� " + this.numOfFilesDownloaded + " ������");
		System.err
				.println(" ������ ���� " + this.initialNumOfFiles + " ������");
		System.err.println(" ��� ��������� �� " + this.numOfFiles + " ������.");
		System.err.println("---------------------------------------------");
	} // end method printResults
} // end class Peer
