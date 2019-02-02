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
		// � ���������� �������� ����� ������� ���������� ���� ��������� ���
		// ������� ��� ������������ ������ ��� ��������, �� ����� �� ��� �����
		// �������� ��� <<������>> ��� ��������.

		int peerIndex = 0, nextAvailable = 1;

		// � �������� ��� �� �������� �� ��������� ��� ��������
		// [1, MAX_NUM_OF_NEIGHBOURS], ������ ������� � ������ �������� �� ����
		// ����������� ��� �������.
		int numOfNeighbours = this.randomizer
				.nextInt(this.MAX_NUM_OF_NEIGHBOURS) + 1;

		// ������� � ������� �� ���� ��������� numOfNeighbours �����������
		// ���������.
		nextAvailable = this.connectToNeighbours(peerIndex, nextAvailable,
				numOfNeighbours);

		peerIndex++; // ������� ��� �� 1.

		// ��� ���� ���������� ��������� � �������� ��� �� �������� �� ���������
		// ��� �������� [1, MAX_NUM_OF_NEIGHBOURS - 1], ����� ���������� ���
		// ������� ��� ������� �� ������� �����������. �� ���� ��� ����� ��
		// ������� ������ �������� ����� MAX_NUM_OF_NEIGHBOURS. �����������: ��
		// �������� ������ ����� 2 ��� ��� 1 ��������!
		while (nextAvailable < this.peers.length)
		{
			numOfNeighbours = this.randomizer
					.nextInt(this.MAX_NUM_OF_NEIGHBOURS - 1) + 1;

			// ������� � ������� �� ���� ��������� numOfNeighbours �����������
			// ���������.
			nextAvailable = this.connectToNeighbours(peerIndex, nextAvailable,
					numOfNeighbours);

			peerIndex++;
		} // end while

		// � �������� ����������, ����� ��� ��� ��������� ��������� ��� ��
		// �������� ����� �������� ������ ��� ����� id ���� ��� ���������� ���
		// ���� ��� ��������� ��' ������ (������������ ��� ������ ��� ���
		// ���������� ��� ����� ���� ���� �������), �� ���������� ����
		// ���������� ���� �� ������ ��� �������� ����. ���� ���� �� �����
		// ����������� ���� �������.
		// ���� �������� �� ������������ ��� �������� ���������� ��� ������ ����
		// ����������� ��� ������������ ���� �� ���������� ������ �������� ���
		// �������� [0, MAX_NUM_OF_NEIGHBOURS - 2] (��� ������� ����� ��� ����
		// � ��� ��������, ��� �� ������ ������ �� ����� ��� ��������
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
				// ������� � ������� �� ���� ��������� numOfNeighbours
				// ����������� ���������.
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
