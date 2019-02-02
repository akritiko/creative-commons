import java.util.Random;

public class FileGenerator
{
	private final Random randomizer;
	private final int numOfFilesToCreate;
	private final int numOfPeers;
	private final Peer[] peers;

	public FileGenerator(final int numOfFilesToCreate, final Peer[] peers)
	{
		this.randomizer = new Random();
		this.numOfFilesToCreate = numOfFilesToCreate;
		this.peers = peers;
		this.numOfPeers = peers.length;
	} // end method FileGenerator

	private File createFile(final int fileNumber)
	{
		String fileName = "file" + fileNumber;
		int fileSize = this.randomizer.nextInt(600) + 1;

		return new File(fileName, fileSize);
	} // end method createFile

	public void distributeFilesToPeers()
	{
		for (int i = 0; i < this.numOfFilesToCreate; i++)
		{
			File file = createFile(i);

			int index = this.randomizer.nextInt(numOfPeers);
			int numOfTries = 0;
			while (numOfTries < this.numOfPeers)
			{
				if (this.peers[index].getNumOfFiles() < this.peers[index]
						.getInitialNumOfFiles())
				{
					this.peers[index].addToFileBase(file);
					break;
				} // end if

				index++;
				index = index % this.numOfPeers;
				numOfTries++;
			} // end while
		} // end for
	} // end method distributeFilesToPeers

	public String generateRandomFileName()
	{
		// Καθορίζεται ένα όνομα αρχείου με πιθανότητα 2% να μην υπάρχει το
		// αντίστοιχο αρχείο.
		int fileNumber = this.randomizer.nextInt(this.numOfFilesToCreate
				+ (int) (this.numOfFilesToCreate * 0.02));

		return ("file" + fileNumber);
	} // end method generateRandomFileName
} // end class FileGenerator
