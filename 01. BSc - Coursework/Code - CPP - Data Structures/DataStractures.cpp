#include <iostream.h>
//#include ".\Node.cpp"
//#include ".\DoubleQueue.h"
//#include ".\BinaryTree.h"
#include ".\minheap\minheap.cpp"
void main()
{
  MinHeap a;

  a.InsertNode( 15 );
  a.InsertNode( 13 );
  a.InsertNode( 12 );
  a.InsertNode( 10 );
  a.InsertNode( 9 );
  a.InsertNode( 7 );
  a.InsertNode( 5 );

  a.DeletePeek();
a.DeletePeek();
a.DeletePeek();
a.DeletePeek();
a.DeletePeek();
a.DeletePeek();
a.DeletePeek();





  cout << a.IsEmpty();
}
