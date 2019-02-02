#include "SingleNode.cpp"

#define NULL 0



template < class T >
class Stack //� ����� �������
{
private:

  SingleNode < T > * _Tip; //������� ��� �������� �������� ��� �������

public:
  //����������
  Stack( SingleNode < T > * Tip = Null )
  {
    _Tip = Tip;
  }

  //������� ��� ��� �������� ��� ������
  void Push( T Value )
  {
    SingleNode < T > * NewOne = new SingleNode < T > ( Value, _Tip );
    _Tip = NewOne;
  }

  //��������� �� �������� ��������
  void Pop()
  {
    if ( IsEmpty() ) throw;
    SingleNode < T > * Victim;
    Victim = _Tip;
    _Tip = _Tip->getPrevious();
    delete Victim;
  }

  //������ �� ����������� ��� ��������� ���������
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
