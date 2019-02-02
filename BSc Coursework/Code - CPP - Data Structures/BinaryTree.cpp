#include ".\BinaryTree.h"
#include <iostream.h>
#define Son 1
#define Father 0
BinaryTree::BinaryTree( Node * Root )
{
  _Root = Root;
}

bool BinaryTree::IsEmpty()
{
  return _Root == Null;
}

Node * * BinaryTree::TargetAndFather( int Target )
{
  Node * TF[2] =
  {
    Null, _Root
  };
  while ( TF[Son]->getData() != Target )
  {

    if ( Target < TF[Son]->getData() )
    {
      if ( TF[Son]->getLeft() == Null )
        return Null; //no existance
      else
      {
        TF[Father] = TF[Son];
        TF[Son] = TF[Son]->getLeft();
      }
    }

    if ( Target > TF[Son]->getData() )
    {
      if ( TF[Son]->getRight() == Null )
        return Null; //no existance
      else
      {
        TF[Father] = TF[Son];
        TF[Son] = TF[Son]->getRight();
      }
    }
  }

  return TF;
}

Node * * BinaryTree::MinAndFather( Node * SubTree )
{
  if ( !SubTree->getLeft() ) throw;

  Node * MF[2] =
  {
    Null, SubTree
  };

  while ( MF[Son]->getLeft() )
  {
    MF[Father] = MF[Son];
    MF[Son] = MF[Son]->getLeft();
  }

  return MF;
}

void BinaryTree::Insert( int Value )
{
  Node * newNode = new Node( Value );
  if ( IsEmpty() )
  {
    _Root = newNode;
    return;
  }
  Node * Pos = _Root;

  while ( ( Value < Pos->getData() && Pos->getLeft() != Null ) || ( Value >= Pos->getData() && Pos->getRight() != Null ) )
  {
    if ( Value < Pos->getData() )
      Pos = Pos->getLeft();
    else
      Pos = Pos->getRight();


    //++;
  }

  if ( Value < Pos->getData() )
    Pos->setLeft( newNode );
  else
    Pos->setRight( newNode );

  return;
}

bool BinaryTree::Delete( int Value )
{
  Node * * Victims = TargetAndFather( Value );
  if ( !Victims ) return 0;

  if ( Victims[Son]->getLeft() == Null && Victims[Son]->getRight() == Null )
  {
    if ( Victims[Father]->getLeft() == Victims[Son] )
      Victims[Father]->setLeft( Null );
    else
      Victims[Father]->setRight( Null );
    delete( Victims[Son] );
    return true;
  }

  if ( Victims[Son]->getLeft() == Null )
  {
    if ( Victims[Father]->getLeft() == Victims[Son] )
      Victims[Father]->setLeft( Null );
    else
      Victims[Father]->setRight( Null );
    delete( Victims[Son] );
    return true;

  }

  Node * * Replacement = MinAndFather( Victims[Son]->getRight() );;

  Replacement[Father]->setLeft( Null );
//  if Victims

  /*

  if ( Victim->getLeft() == Null && Victim->getRight() == Null ) { if ( Victim == _Root ) _Root = Null;
  delete( Victim ); return 1; }

  if ( Victim->getLeft() != Null && Victim->getRight() != Null ) {

  return 1; }

  if ( Victim->getLeft() != Null ) { if ( Victim == _Root ) _Root = _Root->getLeft();
  if ( VictimFather ) VictimFather->setLeft( Victim->getLeft() ); delete Victim; return 1;

  }

  if ( Victim->getRight() != Null ) { if ( Victim == _Root ) _Root = _Root->getRight();
  if ( VictimFather ) VictimFather->setRight( Victim->getRight() ); delete Victim; return 1;

  } */
}



bool BinaryTree::LookFor( int Value )
{
  Node * Search = _Root;

  while ( Search->getData() != Value )
  {

    if ( Value < Search->getData() )
    {
      if ( Search->getLeft() == Null )
        return 0;
      else
        Search = Search->getLeft();
    }

    if ( Value > Search->getData() )
    {
      if ( Search->getRight() == Null )
        return 0;
      else
        Search = Search->getRight();
    }

  }

  return 1;
}

int BinaryTree::getMax()
{
  if ( IsEmpty() ) throw;
  Node * Max = _Root;
  while ( Max->getRight() != Null ) Max = Max->getRight();
  return Max->getData();
}

int BinaryTree::getMin()
{
  if ( IsEmpty() ) throw;
  Node * Max = _Root;
  while ( Max->getLeft() != Null ) Max = Max->getLeft();
  return Max->getData();

}

void BinaryTree::Suicide()
{
  Node * VictimFather = Null;
  Node * Victim = _Root;
  while ( _Root != Null )
  {
    if ( Victim->getLeft() != Null )
    {
      VictimFather = Victim;
      Victim = Victim->getLeft();
    }
    if ( Victim->getRight() != Null )
    {
      VictimFather = Victim;
      Victim = Victim->getRight();
    }
    if ( Victim == _Root ) _Root = Null;
    if ( Victim->getLeft() == Null && Victim->getRight() == Null )
    {
      delete( Victim );
      if ( VictimFather != Null )
      {
        if ( VictimFather->getLeft() == Victim ) VictimFather->setLeft( Null );
        else
          VictimFather->setRight( Null );
      }

      Victim = _Root;
    }
  }
}


void BinaryTree::PreOrder( Node * Root )
{
  if ( Root )
  {
    cout << Root->getData() << " ";
    PreOrder( Root->getLeft() );
    PreOrder( Root->getRight() );
  }
  return;
}

void BinaryTree::PreOrder()
{
  if ( IsEmpty() ) throw;
  PreOrder( _Root );
}

Node * BinaryTree::getRoot()
{
  return _Root;
}
