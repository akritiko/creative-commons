#include "SingleNode.h"

class stack //� ����� �������
{
private:
	int counter;
	single_node * peek; //������� ��� �������� �������� ��� �������

public:
	//����������
	stack(void)
	{
		counter=0;
		peek = 0;
	}
	//������� ��� ��� �������� ��� ������
	void Push(int value)
	{
		single_node * newone;
		newone = new single_node(peek,value);
		peek = newone;
		counter++;
	}
	//��������� �� �������� ��������
	void Pop()
	{
		single_node * victim;
		victim = peek;
		peek = peek->getprevious();
		delete victim;
		counter--;
	}
	//������ �� ����������� ��� ��������� ���������
	void Peek()
	{
		return peek->getvalue;
	}

	int getnofnodes()
	{
		return counter;
	}
};
