import java.util.Hashtable;
import java.util.LinkedList;
import java.util.concurrent.LinkedBlockingQueue;

public class CentralServer extends Thread
{
	private final Hashtable indexingBase;
	private final LinkedBlockingQueue requestQueue;

	public CentralServer(final int totalNumOfFiles)
	{
		super();
		this.indexingBase = new Hashtable(totalNumOfFiles + 1, 1);
		this.requestQueue = new LinkedBlockingQueue();
	} // end method CentralServer

	public void run()
	{
		while (!Main.simulator.completeReplication())
		{
			try
			{
				Message request = (Message) this.requestQueue.take();
				switch (request.getMessageType())
				{
				case MessageType.LOOKUP_FILE:
					this.lookup(request);
					break;
				case MessageType.REGISTER_FILE:
					this.register(request);
					break;
				default:
					System.err
							.println("Εξυπηρέτης: άγνωστος τύπος μηνύματος - "
									+ request.getMessageType());
					System.exit(-1);
				} // end switch
			} // end try
			catch (InterruptedException e)
			{
				System.err.println(e.toString());
				e.printStackTrace();
			} // end catch
		} // end while
	} // end method run

	private void lookup(final Message request)
	{
		Peer sourcePeer = this.searchForTheBest(request.getFileName());
		int typeOfReply;
		if (sourcePeer != null)
			typeOfReply = MessageType.FILE_FOUND;
		else
			typeOfReply = MessageType.FILE_NOT_FOUND;
		Message messageToBeSend = new Message(typeOfReply, sourcePeer, request
				.getFileName());

		(request.getPeer()).receiveNewMessage(messageToBeSend);
	} // end method lookup

	private Peer searchForTheBest(final String fileName)
	{
		LinkedList listOfPeers = (LinkedList) this.indexingBase.get(fileName);
		if (listOfPeers != null)
		{
			Peer bestPeer = (Peer) listOfPeers.getFirst();
			for (int i = 1; i < listOfPeers.size(); i++)
			{
				Peer tempPeer = (Peer) listOfPeers.get(i);
				if (tempPeer.getUploadRate() > bestPeer.getUploadRate())
					bestPeer = tempPeer;
			} // end for
			return bestPeer;
		} // end if
		return null;
	} // end method searchForTheBest

	private void register(final Message request)
	{
		String fileName = request.getFileName();

		LinkedList listOfPeers = (LinkedList) this.indexingBase.get(fileName);

		if (listOfPeers == null)
		{
			listOfPeers = new LinkedList();
			listOfPeers.add(request.getPeer());

			this.indexingBase.put(fileName, listOfPeers);
		} // end if
		else
			listOfPeers.add(request.getPeer());
	} // end method register

	public void receiveRequest(final Message newRequest)
	{
		try
		{
			this.requestQueue.put(newRequest);
		} // end try
		catch (InterruptedException e)
		{
			System.err.println(e.toString());
			e.printStackTrace();
		} // end catch
	} // end method receiveRequest
} // end class CentralServer
