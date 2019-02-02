public class Simulation
{
	public final InitialWindow initialWindow;
	public final BasicWindow basicWindow;

	private Graph adjacencyGraph;

	private FileGenerator fileGenerator;
	private AdjacencyGenerator adjacencyGenerator;

	private RandomRequestGenerator requestGenerator;

	private Peer[] peers;

	public Simulation()
	{
		this.initialWindow = new InitialWindow();
		this.basicWindow = new BasicWindow();
		this.adjacencyGraph = null;
		this.fileGenerator = null;
		this.adjacencyGenerator = null;
		this.requestGenerator = null;
		this.peers = null;
	} // end method Simulation

	public void initialize()
	{
		this.initialWindow.setVisible(true);
	} // end method start

	public void initializationIfoCollected(final int[] numOfFiles,
			final int totalNumOfFiles)
	{
		this.peers = new Peer[numOfFiles.length];
		AdjacencyInfo relations[] = new AdjacencyInfo[this.peers.length];

		for (int i = 0; i < this.peers.length; i++)
		{
			this.peers[i] = new Peer(i, numOfFiles[i], totalNumOfFiles);
			relations[i] = new AdjacencyInfo(i);
		} // end for

		this.fileGenerator = new FileGenerator(totalNumOfFiles, this.peers);

		this.fileGenerator.distributeFilesToPeers();

		this.adjacencyGenerator = new AdjacencyGenerator(this.peers, relations);

		this.adjacencyGenerator.createAdjacencyRelations();

		this.adjacencyGraph = new Graph(relations);

		this.adjacencyGraph.setVisible(true);
	} // end method infoCollected

	public void showMainWindow()
	{
		this.basicWindow.setVisible(true);

		this.requestGenerator = new RandomRequestGenerator(this.peers,
				this.fileGenerator);

		for (int i = 0; i < this.peers.length; i++)
			peers[i].start();
	} // end method

	public void start()
	{
		this.requestGenerator.start();
	} // end method start

	@SuppressWarnings("deprecation") public void pause()
	{
		this.requestGenerator.suspend();
	} // end method pause

	@SuppressWarnings("deprecation") public void resume()
	{
		this.requestGenerator.resume();
	} // end method resume

	public void userHasRequest(final int peerId, final String fileName)
	{
		Message request = new Message(this.peers[peerId], this.peers[peerId],
				MsgType.REQUEST_FOR_FILE, fileName);

		this.peers[peerId].receiveMessage(request);
	} // end method userHasRequest

	public boolean replication50percent()
	{
		boolean result = true;
		for (int i = 0; i < this.peers.length; i++)
			result = result && this.peers[i].is50percentFull();
		return result;
	} // end method replication50percent
} // end class Simulation
