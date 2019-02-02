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
		// Υπολογίζεται ο ρυθμός με τον οποίο θα μεταφέρονται τα δεδομένα απ'
		// τον ένα ομότιμο στον άλλο. Αυτός ο ρυθμός ισούται με το μικρότερο απ'
		// τους εξής δύο: το ρυθμό ανεβάσματος του ομότιμου-πηγή και το ρυθμό
		// κατεβάσματος του ομότιμου-προορισμού.
		int processRate = this.sourcePeer.getUploadRate() > this.destinationPeer
				.getDownloadRate() ? this.destinationPeer.getDownloadRate()
				: this.sourcePeer.getUploadRate();

		// Λαμβάνοντας υπ' όψιν τον ρυθμό που υπολογίσαμε παραπάνω και το
		// μέγεθος του αρχείου υπολογίζεται ο χρόνος που θα διαρκέσει η
		// διαδικασία.
		float time = (float) this.file.getSize() / (float) processRate;
		try
		{
			// Για αυτό το χρονικό διάστημα το νήμα <<κοιμάται>>...
			sleep((long) time * this.MILISECOND);

			// και στη συνέχεια τοποθετεί το αρχείο στη βάση αρχείων του
			// ομότιμου προορισμού.
			this.destinationPeer.acquireFile(this.file);
		} // end try
		catch (InterruptedException e)
		{
			System.err.println("Σφάλμα κατά τη διάρκεια του ανεβάσματος!");
			System.exit(-1);
		} // end catch
	} // end method run
} // end class UploadingProcess
