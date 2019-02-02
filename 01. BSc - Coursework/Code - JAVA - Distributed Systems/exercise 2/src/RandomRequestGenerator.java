import java.util.Random;

public class RandomRequestGenerator extends Thread
{
	private final Peer[] peers;
	private final FileGenerator generator;

	private final Random randomizer;

	private final long TIMEOUT = 2000;

	public RandomRequestGenerator(final Peer[] peers,
			final FileGenerator generator)
	{
		this.peers = peers;
		this.generator = generator;

		this.randomizer = new Random();
	} // end method RandomRequestGenerator

	@Override public void run()
	{
		try
		{
			while (!Main.simulator.replication50percent())
			{
				String fileName = this.generator.generateRandomFileName();

				int peerId = this.randomizer.nextInt(this.peers.length);

				Message request = new Message(this.peers[peerId],
						this.peers[peerId], MsgType.REQUEST_FOR_FILE, fileName);

				this.peers[peerId].receiveMessage(request);

				sleep(this.TIMEOUT);
			} // end while

			Main.simulator.basicWindow.normalTermination();

			for (int i = 0; i < this.peers.length; i++)
			{
				this.peers[i].printResults();
			} // end for
		} // end try
		catch (InterruptedException e)
		{
			System.err.println("Σφάλμα κατά την προσπάθεια"
					+ " δημιουργίας τυχαίου αιτήματος!");
			System.exit(-1);
		} // end catch
	} // end method run
} // end class RandomRequestGenerator
