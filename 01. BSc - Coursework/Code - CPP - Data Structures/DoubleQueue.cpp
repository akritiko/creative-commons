#include ".\DoubleQueue.h"
#define Null 0

DoubleQueue::DoubleQueue( Node * Head, Node * Tail )
{
  _Head = Head;
  _Tail = Tail;
  _Count = 0;

  Node * tmp = _Head;
  if ( tmp ) _Count++;
  while ( tmp != Tail && tmp != Null )
  {
    _Count++;
    tmp = tmp->getRight();
  }

}

bool DoubleQueue::IsEmpty()
{
  return _Count == 0;
}

bool DoubleQueue::OutofBounds( unsigned int N )
{
  return N > _Count || N < 1;
}

bool DoubleQueue::InsertNode( unsigned int TargetPlace, int Data )
{
  if ( TargetPlace == _Count + 1 ) return InsertNode( ( Node * ) Null, Data );

  if ( OutofBounds( TargetPlace ) ) return 0;

  unsigned int position;
  Node * PosNode;

  if ( TargetPlace <= _Count / 2 )
  {
    position = 1;
    PosNode = _Head;
    while ( position < TargetPlace )
    {
      PosNode = PosNode->getRight();
      position++;
    }
    return InsertNode( PosNode, Data );
  }
  //else

  if ( TargetPlace > _Count / 2 ) position = _Count;

  PosNode = _Tail;
  while ( position > TargetPlace )
  {
    PosNode = PosNode->getLeft();
    position--;
  }
  return InsertNode( PosNode, Data );
}

bool DoubleQueue::InsertNode( Node * posNode, int Data )
{

  if ( IsEmpty() )
  {
    Node * newNode = new Node( Data, _Head, _Tail );
    _Head = _Tail = newNode;
    _Count++;
    return 1;
  }


  _Count++;


  if ( posNode == _Head )
  {
    Node * newNode = new Node( Data, Null, posNode );
    _Head->setLeft( newNode );
    _Head = newNode;
    return 1;
  }
  if ( posNode == Null )
  {
    Node * newNode = new Node( Data, _Tail, Null );
    _Tail->setRight( newNode );
    _Tail = newNode;
    return 1;
  }

  Node * newNode = new Node( Data, posNode->getLeft(), posNode );
  posNode->setLeft( newNode );
  newNode->getLeft()->setRight( newNode );
  return 1;

}

int DoubleQueue::LookFor( int Target )
{

  if ( IsEmpty() )
  {
    //cout<<"NOSEARCH";
    return 0;
  }
  Node * SPosition = _Head;
  for ( unsigned int Place = 1; Place < _Count; Place++ )
  {
    if ( SPosition->getData() == Target ) return Place;
    SPosition = SPosition->getRight();
  }
  return -1;
}

void DoubleQueue::DeleteAll()
{
  for ( Node * Victim = _Head; _Count > 0; _Count-- )
  {
    _Head = _Head->getRight();
    delete( Victim );
    Victim = _Head;
  }
  _Tail = Null;

}

bool DoubleQueue::DeleteNode( unsigned int TargetPlace )
{
  if ( OutofBounds( TargetPlace ) ) throw;

  Node * PosNode;
  unsigned int position;

  if ( TargetPlace <= _Count / 2 )
  {
    position = 1;
    PosNode = _Head;
    while ( position < TargetPlace )
    {
      PosNode = PosNode->getRight();
      position++;
    }
    return DeleteNode( PosNode );
  }

  if ( TargetPlace > _Count / 2 ) position = _Count;

  PosNode = _Tail;
  while ( position > TargetPlace )
  {
    PosNode = PosNode->getLeft();
    position--;
  }
  return DeleteNode( PosNode );
}

bool DoubleQueue::DeleteNode( Node * Victim )
{
  if ( Victim == _Head )
  {
    _Head = _Head->getRight();
    _Head->setLeft( Null );
    delete( Victim );
    _Count--;
    return 1;
  }

  if ( Victim == _Tail )
  {
    _Tail = _Tail->getLeft();
    _Tail->setRight( Null );
    delete( Victim );
    _Count--;
    return 1;
  }

  Node * LeftOfVictim = Victim->getLeft();
  Node * RightOfVictim = Victim->getRight();

  LeftOfVictim->setRight( RightOfVictim );
  RightOfVictim->setLeft( LeftOfVictim );
  delete( Victim );
  _Count--;
  return 1;
}


Node * DoubleQueue::getHead()
{
  return _Head;
}

Node * DoubleQueue::getTail()
{
  return _Tail;
}

int DoubleQueue::getCount()
{
  return _Count;
}

