import java.util.Hashtable;
import java.util.Random;
import java.util.concurrent.LinkedBlockingQueue;

public class Peer extends Thread
{
	private final Hashtable fileBase;
	private final LinkedBlockingQueue messageQueue;

	private final String id;
	private final int uploadRate;
	private final int downloadRate;
	private static final int MINIMUM_UPLOAD_DOWNLOAD_RATE = 10;
	private static final int MAXIMUM_UPLOAD_DOWNLOAD_RATE = 25;

	private int numOfFiles;
	private final int initialNumOfFiles;

	private int numOfRequestsServed;

	private boolean userHasRequest;
	private String fileRequestedByUser;

	private final int TIMEOUT = 1000;

	public Peer(final String id, final int initialNumOfFiles,
			final int totalNumOfFiles)
	{
		super();
		this.fileBase = new Hashtable(totalNumOfFiles + 1, 1);
		this.messageQueue = new LinkedBlockingQueue();

		this.id = id;
		Random randomizer = new Random();
		this.downloadRate = Peer.MINIMUM_UPLOAD_DOWNLOAD_RATE
				+ randomizer.nextInt(Peer.MAXIMUM_UPLOAD_DOWNLOAD_RATE
						- Peer.MINIMUM_UPLOAD_DOWNLOAD_RATE);
		this.uploadRate = Peer.MINIMUM_UPLOAD_DOWNLOAD_RATE
				+ randomizer.nextInt(this.downloadRate
						- Peer.MINIMUM_UPLOAD_DOWNLOAD_RATE + 1);

		this.numOfFiles = 0;
		this.initialNumOfFiles = initialNumOfFiles;

		this.numOfRequestsServed = 0;

		this.userHasRequest = false;
		this.fileRequestedByUser = null;
	} // end method Peer

	public void run()
	{
		while (!Main.simulator.completeReplication())
		{
			if (this.userHasRequest)
			{
				this.executeSearchForFile(this.fileRequestedByUser);
				this.userHasRequest = false;
				this.fileRequestedByUser = null;
			} // end if
			else
			{
				try
				{
					sleep(this.TIMEOUT);
				} // end try
				catch (InterruptedException e)
				{
					System.err.println(e.toString());
					e.printStackTrace();
				} // end catch
				String fileName = Main.fileGenerator.generateRandomFileName();
				this.executeSearchForFile(fileName);
				// } // end if
			} // end else
			if (!messageQueue.isEmpty())
			{
				try
				{
					Message request = (Message) this.messageQueue.take();

					switch (request.getMessageType())
					{
					case MessageType.FILE_FOUND:
						this.download(request.getPeer(), request.getFileName());
						break;
					case MessageType.FILE_NOT_FOUND:
						this.suchFileDoesNotExist(request.getFileName());
						break;
					case MessageType.REQUEST_FILE:
						this.upload(request.getPeer(), request.getFileName());
						break;
					default:
						System.err.println(this.getPeerId()
								+ ": άγνωστος τύπος μηνύματος - "
								+ request.getMessageType());
						System.exit(-1);
					} // end switch
				} // end try
				catch (InterruptedException e)
				{
					System.err.println(e.toString());
					e.printStackTrace();
				} // end catch
			} // end if
		} // end while
		int peerId = Integer.parseInt(this.id) + 1;
		Main.interact.writeToTxtArea(Integer.parseInt(this.id),
				"\n@ Ο ομότιμος " + peerId + " τερματίστηκε.");
		System.err.println("Ο ομότιμος " + peerId + " εξυπηρέτησε "
				+ this.numOfRequestsServed + " αιτήματα.");
	} // end method run

	private void executeSearchForFile(final String fileName)
	{
		Main.interact.writeToTxtArea(Integer.parseInt(this.id),
				"# Αναζητείται το αρχείο " + fileName + ".");
		if (this.fileBase.containsKey(fileName))
		{
			if (!this.getFileFromFileBase(fileName).getFileName().equals(""))
				Main.interact.writeToTxtArea(Integer.parseInt(this.id),
						"# Το αρχείο " + fileName + " βρέθηκε.");
			else
				Main.interact.writeToTxtArea(Integer.parseInt(this.id),
						"# Το αρχείο " + fileName + " κατεβαίνει.");
			// Σε διαφορετική περίπτωση το αίτημα αγνοείται, διότι το αρχείο
			// κατεβαίνει εκείνη τη στιγμή.
		}
		else
		{
			// Εγγράφεται το κλειδί του αρχείου και όχι το ίδιο το αρχείο που
			// αντιστοιχεί στο όνομα αυτό. Με αυτό τον τρόπο όταν ο ομότιμος
			// κατεβάζει ένα αρχείο δεν θα δημιουργεί άλλα αιτήματα για το
			// αρχείο αυτό. Όταν το αρχείο κατεβεί θα προστεθεί κανονικά στη
			// βάση.

			this.fileBase.put(fileName, new File("", 0));

			Message request = new Message(MessageType.LOOKUP_FILE, this,
					fileName);

			Main.simulator.indexingServer.receiveRequest(request);

			Main.interact.writeToTxtArea(Integer.parseInt(this.id),
					"# Το αρχείο " + fileName + " δεν βρέθηκε.\n   Ερευνάται ο"
							+ " κεντρικός εξυπηρέτης...");
		} // end else
	} // end method

	private void download(final Peer peerToReceive, final String fileName)
	{
		Main.interact.writeToTxtArea(Integer.parseInt(this.id), "# Το αρχείο "
				+ fileName + " βρέθηκε στον ομότιμο "
				+ (Integer.parseInt(peerToReceive.getPeerId()) + 1)
				+ ".\n   Εκκινήση διαδικασίας κατεβάσματος...");
		Message messageToBeSend = new Message(MessageType.REQUEST_FILE, this,
				fileName);

		peerToReceive.receiveNewMessage(messageToBeSend);
	} // end method download

	private void suchFileDoesNotExist(final String fileName)
	{
		Main.interact.writeToTxtArea(Integer.parseInt(this.id), "# Το αρχείο "
				+ fileName + " δεν υπάρχει!");
	} // end method SuchFileDoesNotExist

	private void upload(final Peer peerToReceive, final String fileName)
	{
		File fileToBeSend = this.getFileFromFileBase(fileName);
		if (fileToBeSend == null)
		{
			/*
			 * Εάν γίνει αίτημα ανεβάσματος(-κατεβάσματος) αρχείου που δεν
			 * υπάρχει στον ομότιμο, τότε υπάρχει λανθασμένη υπόδειξη στον
			 * εξυπηρέτη δεικτοδότησης. Αυτό είναι παρενέργεια που πρέπει να
			 * τερματίσει τον προσομοιωτή, αφού κάτι τέτοιο δεν προβλέπεται κατά
			 * τη σωστή λειτουργία του.
			 */
			System.err.println("Το αρχείο " + fileName
					+ " δεν υπάρχει στον ομότιμο " + this.id);
			System.exit(-1);
		} // end if
		DownloadingProcess downloadingFile = new DownloadingProcess(
				this.uploadRate, peerToReceive, fileToBeSend);

		downloadingFile.start();

		this.numOfRequestsServed++;
	} // end method upload

	public void newFileAcquired(final File file, final boolean initialized)
	{
		if (initialized)
			Main.interact.writeToTxtArea(Integer.parseInt(this.id),
					"# Το κατέβασμα του αρχείου " + file.getFileName()
							+ "\n   ολοκληρώθηκε.");
		this.insertFileToBase(file);
		this.registerFile(file.getFileName(), initialized);
	} // end method newFileAcquired

	private void insertFileToBase(final File file)
	{
		this.numOfFiles++;
		this.fileBase.put(file.getFileName(), file);
		Main.initial.writeToTxtArea(Integer.parseInt(this.id), file
				.getFileName());
	} // end method insertFileToBase

	private void registerFile(final String fileName, final boolean initialized)
	{
		if (initialized)
			Main.interact
					.writeToTxtArea(Integer.parseInt(this.id), "# Το αρχείο "
							+ fileName + " δηλώνεται στον\n   εξυπηρέτη.");
		Message messageToBeSend = new Message(MessageType.REGISTER_FILE, this,
				fileName);

		Main.simulator.indexingServer.receiveRequest(messageToBeSend);
	} // end method registerFile

	public File getFileFromFileBase(final String fileName)
	{
		File fileToGet = (File) this.fileBase.get(fileName);
		if (fileToGet != null)
			return fileToGet;
		return null;
	} // end method getFile

	public void receiveNewMessage(final Message newMessage)
	{
		try
		{
			this.messageQueue.put(newMessage);
		} // end try
		catch (InterruptedException e)
		{
			System.err.println(e.toString());
			e.printStackTrace();
		} // end catch
	} // end method receiveNewMessage

	public void userHasRequestedFile(final String fileName)
	{
		this.userHasRequest = true;
		this.fileRequestedByUser = fileName;
	} // end method setUserHasRequest

	public String getPeerId()
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

	public boolean isFull()
	{
		return (this.numOfFiles == Main.getTotalNumOfFilesToHandle());
	} // end method isFull
} // end class Peer
