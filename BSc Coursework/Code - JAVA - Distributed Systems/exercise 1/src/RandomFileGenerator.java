import java.util.Random;

public class RandomFileGenerator
{
	private final Random randomizer;
	private final int numOfFilesToCreate;
	private final int numOfPeers;
	private final Peer[] peers;

	public RandomFileGenerator(final int numOfFilesToCreate, final Peer[] peers)
	{
		this.randomizer = new Random();
		this.numOfFilesToCreate = numOfFilesToCreate;
		this.peers = peers;
		this.numOfPeers = peers.length;
	} // end method RandomFileGenerator

	public File createFile(final int fileNum)
	{
		String fileName = "file" + fileNum;
		int fileSize = this.randomizer.nextInt(600);
		return new File(fileName, fileSize);
	} // end method generateFile

	public void randomlySpreadFilesToPeers()
	{
		for (int i = 0; i < numOfFilesToCreate; i++)
		{
			File file = createFile(i);
			int index = this.randomizer.nextInt(numOfPeers);
			int numOfTries = 0;
			while (numOfTries < this.numOfPeers)
				if (peers[index].getNumOfFiles() < peers[index]
						.getInitialNumOfFiles())
				{
					peers[index].newFileAcquired(file, false);
					break;
				} // end if
				else
				{
					index++;
					index = index % this.numOfPeers;
					numOfTries++;
				} // end else - while
		} // end for
	} // end method randomlySpreadFilesToPeers

	public String generateRandomFileName()
	{
		// Καθορίζεται ένα όνομα αρχείου με πιθανότητα να μην υπάρχει το
		// αντίστοιχο αρχείο 5%.
		int fileNum = this.randomizer.nextInt(this.numOfFilesToCreate
				+ (int) (this.numOfFilesToCreate * 0.05));
		return ("file" + fileNum);
	} // end method generateFileName
} // end class RandomFileGenerator
