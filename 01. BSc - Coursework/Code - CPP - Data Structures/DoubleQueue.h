#include ".\Node.h"
#define Null 0
class DoubleQueue
{
private:

  Node * _Head;
  Node * _Tail;
  unsigned int _Count;
  bool InsertNode( Node * PosNode, int Data );
  bool DeleteNode( Node * Victim );
public:

  DoubleQueue( Node * Head = Null, Node * Tail = Null );
  bool IsEmpty();
  bool OutofBounds( unsigned int Target );
  bool InsertNode( unsigned int TargetPlace, int Data );
  int LookFor( int Target );
  bool DeleteNode( unsigned int TargetPlace );
  void DeleteAll();

  Node * getHead();
  Node * getTail();
  int getCount();

};
