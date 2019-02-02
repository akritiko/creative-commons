public class Message
{
	private final Peer initialTransmiter;
	private Peer previousTransmiter;
	private int retransmitionCounter;
	private MsgType messageType;
	private final String fileName;

	public Message(final Peer initialTransmiter, final Peer previousTransmiter,
			final MsgType messageType, final String fileName)
	{
		this.initialTransmiter = initialTransmiter;
		this.previousTransmiter = previousTransmiter;
		this.retransmitionCounter = 0;
		this.messageType = messageType;
		this.fileName = fileName;
	} // end method Message

	private Message(final Peer initialTransmiter,
			final Peer previousTransmiter, final int retransmitionCounter,
			final MsgType messageType, final String fileName)
	{
		this.initialTransmiter = initialTransmiter;
		this.previousTransmiter = previousTransmiter;
		this.retransmitionCounter = retransmitionCounter;
		this.messageType = messageType;
		this.fileName = fileName;
	} // end method Message

	public boolean reachedRetransmitionLimit()
	{
		return this.retransmitionCounter == 10;
	} // end method getRetransmitionCounter

	public boolean hasNotBeenRetransmited()
	{
		return this.retransmitionCounter == 0;
	} // end method getRetransmitionCounter

	public void increaseRetransmitionCounter()
	{
		this.retransmitionCounter++;
	} // end method increaseRetransmitionCounter

	public Peer getPreviousTransmiter()
	{
		return this.previousTransmiter;
	} // end method getPreviousTransmiter

	public void setPreviousTransmiter(final Peer previousTransmiter)
	{
		this.previousTransmiter = previousTransmiter;
	} // end method setPreviousTransmiter

	public String getFileName()
	{
		return this.fileName;
	} // end method getFileName

	public Peer getInitialTransmiter()
	{
		return this.initialTransmiter;
	} // end method getInitialTransmiter

	public MsgType getMessageType()
	{
		return this.messageType;
	} // end method getMessageType

	public void setMessageType(final MsgType messageType)
	{
		this.messageType = messageType;
	} // end method setMessageType

	@Override protected Message clone()
	{
		Message clone = new Message(this.initialTransmiter,
				this.previousTransmiter, this.retransmitionCounter,
				this.messageType, this.fileName);
		return clone;
	} // end method clone
} // end class Message
