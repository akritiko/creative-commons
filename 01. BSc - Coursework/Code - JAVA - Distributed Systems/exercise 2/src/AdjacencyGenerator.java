import java.util.Random;

public class AdjacencyGenerator
{
	private final int MAX_NUM_OF_NEIGHBOURS = 3;

	private Random randomizer;

	private final Peer[] peers;
	private final AdjacencyInfo[] adjacencyInfo;

	public AdjacencyGenerator(final Peer[] peers,
			final AdjacencyInfo[] adjacencyInfo)
	{
		this.randomizer = new Random();
		this.peers = peers;
		this.adjacencyInfo = adjacencyInfo;
	} // end method AdjacencyGenerator

	public void createAdjacencyRelations()
	{
		// Ο αλγόριθμος παρακάτω κάνει κάποιες υπερβάσεις στον καθορισμό του
		// πλήθους των διασυνδέσεων μεταξύ των ομοτίμων, με σκοπό να μην γίνει
		// διάσπαση του <<δάσους>> των ομοτίμων.

		int peerIndex = 0, nextAvailable = 1;

		// Ο ακέραιος που θα παραχθεί θα βρίσκεται στο διάστημα
		// [1, MAX_NUM_OF_NEIGHBOURS], επειδή θέλουμε ο πρώτος ομότιμος να έχει
		// τουλάχιστον μια σύνδεση.
		int numOfNeighbours = this.randomizer
				.nextInt(this.MAX_NUM_OF_NEIGHBOURS) + 1;

		// Γίνεται η σύνδεση με τους επόνενους numOfNeighbours διαθέσιμους
		// ομότιμους.
		nextAvailable = this.connectToNeighbours(peerIndex, nextAvailable,
				numOfNeighbours);

		peerIndex++; // Γίνεται ίσο με 1.

		// Για τους υπόλοιπους ομότιμους ο ακέραιος που θα παραχθεί θα βρίσκεται
		// στο διάστημα [1, MAX_NUM_OF_NEIGHBOURS - 1], διότι γνωρίζουμε ότι
		// υπάρχει μια σύνδεση με κάποιον προηγούμενο. Με αυτό τον τρόπο το
		// μέγιστο πλήθος γειτόνων είναι MAX_NUM_OF_NEIGHBOURS. ΠΑΡΕΝΕΡΓΕΙΑ: Το
		// ελάχιστο πλήθος είναι 2 και όχι 1 γείτονας!
		while (nextAvailable < this.peers.length)
		{
			numOfNeighbours = this.randomizer
					.nextInt(this.MAX_NUM_OF_NEIGHBOURS - 1) + 1;

			// Γίνεται η σύνδεση με τους επόνενους numOfNeighbours διαθέσιμους
			// ομότιμους.
			nextAvailable = this.connectToNeighbours(peerIndex, nextAvailable,
					numOfNeighbours);

			peerIndex++;
		} // end while

		// Η παραπάνω διαδικασία, εκτός από μια τετριμένη περίπτωση που οι
		// ομότιμοι έχουν γείτονες αυτούς που έχουν id κατά ένα μεγαλύτερο και
		// κατά ένα μικρότερο απ' αυτούς (εξαιρουμένων του πρώτου και του
		// τελευταίου που έχουν μόνο έναν γείτονα), θα σταματήσει πριν
		// καθορίσουν όλοι το πλήθος των γειτόνων τους. Όμως όλοι θα έχουν
		// τουλάχιστον έναν γείτονα.
		// Έτσι μπορούμε να επαναλάβουμε την παραπάνω διαδικασία για αυτούς τους
		// τελευταίους και επιτρέποντας τους να καθορίσουν πλήθος γειτόνων στο
		// διάστημα [0, MAX_NUM_OF_NEIGHBOURS - 2] (μην ξεχνάμε έχουν ήδη έναν
		// ή δυο γείτονες, άρα το τελικό πλήθος θα είναι στο διάστημα
		// [1, MAX_NUM_OF_NEIGHBOURS]).

		nextAvailable = peerIndex + 1;

		while (nextAvailable < this.peers.length)
		{
			numOfNeighbours = this.randomizer
					.nextInt(this.MAX_NUM_OF_NEIGHBOURS - 1);

			if (numOfNeighbours == 0)
			{
				nextAvailable++;
			} // end if
			else
			{
				// Γίνεται η σύνδεση με τους επόνενους numOfNeighbours
				// διαθέσιμους ομότιμους.
				nextAvailable = this.connectToNeighbours(peerIndex,
						nextAvailable, numOfNeighbours);
			} // end else

			peerIndex++;
		} // end while
	} // end method createAdjacencyRelations

	private int connectToNeighbours(final int peerIndex, int nextAvailable,
			final int numOfNeighbours)
	{
		for (int i = 0; i < numOfNeighbours
				&& nextAvailable < this.peers.length; i++)
		{
			this.peers[peerIndex].addNeighbour(this.peers[nextAvailable]);
			this.peers[nextAvailable].addNeighbour(this.peers[peerIndex]);

			this.adjacencyInfo[peerIndex].addNeighbour(nextAvailable);
			this.adjacencyInfo[nextAvailable].addNeighbour(peerIndex);

			nextAvailable++;
		} // end for
		return nextAvailable;
	} // end method connectToNeighbours
} // end class AdjacencyGenerator
