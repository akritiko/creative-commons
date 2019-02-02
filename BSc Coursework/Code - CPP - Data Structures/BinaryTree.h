#define Null 0
#include ".\Node.h"
class BinaryTree
{
private:

  Node * _Root;
  Node * * TargetAndFather( int Target );
  Node * * MinAndFather( Node * SubTree );
public:

  BinaryTree( Node * Root = Null );
  bool IsEmpty();
  void Insert( int Value );
  bool Delete( int Value );
  bool LookFor( int Value );
  void Suicide();
  int getMax();
  int getMin();
  void PreOrder( Node * Root  );
  void PreOrder();
  Node * getRoot();
};
