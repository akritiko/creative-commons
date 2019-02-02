#include "SingleNode.h"

class stack //Η κλάση στοίβας
{
private:
	int counter;
	single_node * peek; //Δείκτης στο κορυφαίο στοιχείο της στοίβας

public:
	//Δημιουργός
	stack(void)
	{
		counter=0;
		peek = 0;
	}
	//Εισάγει ένα νέο στοιχείο στη στοίβα
	void Push(int value)
	{
		single_node * newone;
		newone = new single_node(peek,value);
		peek = newone;
		counter++;
	}
	//Διαγράφει το κορυφαίο στοιχείο
	void Pop()
	{
		single_node * victim;
		victim = peek;
		peek = peek->getprevious();
		delete victim;
		counter--;
	}
	//Βλέπει το περιεχόμενο του κορυφαίου στοιχείου
	void Peek()
	{
		return peek->getvalue;
	}

	int getnofnodes()
	{
		return counter;
	}
};
