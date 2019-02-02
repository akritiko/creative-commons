#define Null 0

class Node
{
private:
  Node * _Left;
  Node * _Right;
  int _Data;

public:
  Node();
  Node( int Data, Node * Left = Null, Node * Right = Null );
  void setLeft( Node * Left );
  void setRight( Node * Right );
  void setData( int Data );
  Node * getLeft();
  Node * getRight();
  int getData();
};
