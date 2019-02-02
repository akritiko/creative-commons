public class DistributedSystem
{
	public final CentralServer indexingServer;
	private Peer[] peer;

	public DistributedSystem(final int[] numOfFilesInPeers,
			final int totalNumOfFiles)
	{
		this.indexingServer = new CentralServer(totalNumOfFiles);
		this.peer = new Peer[numOfFilesInPeers.length];
		for (int i = 0; i < this.peer.length; i++)
			this.peer[i] = new Peer("" + i, numOfFilesInPeers[i],
					totalNumOfFiles);
		Main.fileGenerator = new RandomFileGenerator(totalNumOfFiles, this.peer);
	} // end method DestributedSystem

	public boolean completeReplication()
	{
		boolean result = true;
		for (int i = 0; i < this.peer.length; i++)
			result = result && this.peer[i].isFull();
		return result;
	} // end method completeReplication

	public void startSimulation()
	{
		this.indexingServer.start();
		for (int i = 0; i < this.peer.length; i++)
			peer[i].start();
	} // end method startSimulation

	public void userRequest(final String peerId, final String fileName)
	{
		Peer sourcePeer = Main.simulator.matchPeer(peerId);
		if (sourcePeer != null)
			sourcePeer.userHasRequestedFile(fileName);
		else
			Main.interact.writeToTxtField("’γνωστος ομότιμος <"
					+ (Integer.parseInt(peerId) + 1) + ">");
	} // end method userRequest

	public Peer matchPeer(final String peerId)
	{
		Peer peer = null;
		for (int i = 0; i < this.peer.length; i++)
			if ((this.peer[i].getPeerId()).equals(peerId))
				peer = this.peer[i];
		return peer;
	} // end method matchPeer
} // end class DestributedSystem

