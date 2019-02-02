#include".\SingleNode.h"
#define Null 0



template < class T >
class SingleNode //Η κλάση κόμβος απλά συνδεδεμένης λίστας
{
private:
  T _Value;
  SingleNode * _Previous; //Δείκτης στο προηγούμενο στοιχείο

public:
  //Δημιουργός
  SingleNode( T Value, SingleNode * Previous = Null )
  {
    _Value = Value;
    _Previous = Previous;
  }

  int getValue()
  {
    return _Value;
  }

  SingleNode * getPrevious()
  {
    return _Previous;
  }
};
