#include "TribleNode.cpp"

#define Null 0

class MinHeap
{
private:
  TripleNode * _Root;
  unsigned int _NFP; //NFP: Επόμενη καινή θέση στον σωρό ελαχίστων

  void SwapElements( TripleNode * First, TripleNode * Last );
  int BinaryReverse( int Number );
  TripleNode * ValueOrganizerDownwards( TripleNode * Father );
  TripleNode * ValueOrganizerUpwards( TripleNode * Start );
  TripleNode * WalkPath( int Path );

public:
  MinHeap( TripleNode * Root = Null, unsigned int NFP = 1 );
  void InsertNode( int Value );
  void DeletePeek();
  int ReadPeek( void );
  bool IsEmpty( void );

};



MinHeap::MinHeap( TripleNode * Root, unsigned int NFP )
{
  _Root = Root;
  _NFP = NFP;
}

void MinHeap::InsertNode( int Value )
{
  TripleNode * Father = WalkPath( BinaryReverse( _NFP ) );
  TripleNode * Newbie = new TripleNode( Value, Null, Null, Father );
  if ( !_Root )
  {
    _Root = Newbie;
    _NFP++;
    return;
  }
  if ( _NFP % 2 ) Father->setRight( Newbie );
  else
    Father->setLeft( Newbie );
  _NFP++;

  while ( Newbie = ValueOrganizerUpwards( Newbie ) );
}

void MinHeap::DeletePeek()
{
  if ( IsEmpty() ) throw;

  if ( _NFP == 2 )
  {
    delete _Root;
    _Root = Null;
    return;
  }

  TripleNode * Victim = WalkPath( BinaryReverse( _NFP - 1 ) );
  SwapElements( Victim, _Root );
  if ( (_NFP - 1) % 2 ) Victim->getFather()->setRight( Null );
  else
    Victim->getFather()->setLeft( Null );

  delete Victim;

  Victim = _Root;
  while ( Victim = ValueOrganizerDownwards( Victim ) );
  _NFP--;
}


int MinHeap::BinaryReverse( int Number )
{
  int MagicNumber = 0;

  while ( Number )
  {
    MagicNumber = MagicNumber << 1;
    MagicNumber = MagicNumber | ( Number & 1 );
    Number = Number >> 1;

  }

  return MagicNumber;
}

TripleNode * MinHeap::WalkPath( int Path )
{

  if ( IsEmpty() ) return Null;

  TripleNode * Result = _Root;
  //panta to prwto tha einai assos poy paraleipetai


  while ( Path || Result->getLeft() )
  {
    Path = Path >> 1;
    if ( Path & 1 )
    {
      if ( !Result->getRight() ) return Result;
      Result = Result->getRight();
      continue;
    }
    if ( !Result->getLeft() ) return Result;
    Result = Result->getLeft();
  }
  return Result;
}


void MinHeap::SwapElements( TripleNode * First, TripleNode * Last )
{
  if ( !( First || Last ) ) return;

  int Swapper = First->getValue();
  First->setValue( Last->getValue() );
  Last->setValue( Swapper );
}

TripleNode * MinHeap::ValueOrganizerDownwards( TripleNode * Father )
{
  if ( !Father->getLeft() ) return Null;
  // to rught an den yparxei to left den nooeitai

  TripleNode * LeftChild = Father->getLeft();
  TripleNode * RightChild = Father->getRight();

  if ( !Father->getRight() )
  {
    if ( Father->getValue() > LeftChild->getValue() )
    {
      SwapElements( Father, LeftChild );
      return LeftChild;
    }

    return Null;
  }

  if ( Father->getValue() > LeftChild->getValue() || Father->getValue() > RightChild->getValue() )
  {
    if ( LeftChild->getValue() > RightChild->getValue() )
    {
      SwapElements( Father, RightChild );
      return RightChild;
    }
    else
    {
      SwapElements( Father, LeftChild );
      return LeftChild;
    }
  }

  return Null;
}

TripleNode * MinHeap::ValueOrganizerUpwards( TripleNode * Start )
{
  if ( !Start->getFather() ) return Null;

  if ( Start->getValue() < Start->getFather()->getValue() )
  {
    SwapElements( Start, Start->getFather() );
    return Start->getFather();
  }
  return Null;
}


int MinHeap::ReadPeek()
{
  return _Root->getValue();
}


bool MinHeap::IsEmpty()
{
  return _Root == Null;
}



