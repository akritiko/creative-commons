public class Message
{
	private final int msgType;
	private final Peer peerInfo;
	private final String filename;

	public Message(final int msgType, final Peer peerInfo, final String filename)
	{
		this.msgType = msgType;
		this.peerInfo = peerInfo;
		this.filename = filename;
	} // end method Message

	public int getMessageType()
	{
		return this.msgType;
	} // end method getMessageType

	public Peer getPeer()
	{
		return this.peerInfo;
	} // end method getPeer

	public String getFileName()
	{
		return this.filename;
	} // end method getFileName
} // end class Message

