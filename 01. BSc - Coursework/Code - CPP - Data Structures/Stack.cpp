#include "SingleNode.cpp"

#define NULL 0



template < class T >
class Stack //Η κλάση στοίβας
{
private:

  SingleNode < T > * _Tip; //Δείκτης στο κορυφαίο στοιχείο της στοίβας

public:
  //Δημιουργός
  Stack( SingleNode < T > * Tip = Null )
  {
    _Tip = Tip;
  }

  //Εισάγει ένα νέο στοιχείο στη στοίβα
  void Push( T Value )
  {
    SingleNode < T > * NewOne = new SingleNode < T > ( Value, _Tip );
    _Tip = NewOne;
  }

  //Διαγράφει το κορυφαίο στοιχείο
  void Pop()
  {
    if ( IsEmpty() ) throw;
    SingleNode < T > * Victim;
    Victim = _Tip;
    _Tip = _Tip->getPrevious();
    delete Victim;
  }

  //Βλέπει το περιεχόμενο του κορυφαίου στοιχείου
  T Peek()
  {
    if ( IsEmpty() ) throw;
    return _Tip->getValue();
  }

  bool IsEmpty()
  {
    return _Tip == Null;
  }
};
