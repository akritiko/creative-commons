#include ".\Node.h"
#define Null 0
Node::Node()
{
}

Node::Node( int Data, Node * Left, Node * Right )
{
  _Left = Left;
  _Right = Right;
  _Data = Data;

}


void Node::setLeft( Node * Left )
{
  _Left = Left;
}

void Node::setRight( Node * Right )
{
  _Right = Right;
}

void Node::setData( int Data )
{
  _Data = Data;
}

Node * Node::getLeft()
{
  return _Left;
}

Node * Node::getRight()
{
  return _Right;
}

int Node::getData()
{
  return _Data;
}




