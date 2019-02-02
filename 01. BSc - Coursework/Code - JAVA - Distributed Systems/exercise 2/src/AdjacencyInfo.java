import java.util.LinkedList;

public class AdjacencyInfo
{
	private int peerIndex;
	private LinkedList<Integer> neighbours;

	public AdjacencyInfo(final int peerIndex)
	{
		this.peerIndex = peerIndex;
		this.neighbours = new LinkedList<Integer>();
	} // end method AdjacencyInfo

	public int getPeerIndex()
	{
		return this.peerIndex;
	} // end method getPeerIndex

	public void addNeighbour(final int neighbourIndex)
	{
		this.neighbours.add(neighbourIndex);
	} // end method addNeighbour

	public int getNeighbour(final int index)
	{
		return this.neighbours.get(index);
	} // end method getNeighbour

	public int getNumOfNeighbours()
	{
		return this.neighbours.size();
	} // end method getNeighbour
} // end class AdjacencyInfo
