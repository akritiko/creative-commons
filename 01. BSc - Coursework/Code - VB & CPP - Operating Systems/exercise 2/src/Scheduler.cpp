#include "pcb.h"

#define CPU 0
#define DISK 1
#define PRN 2

#define QUANTUM 4
#define NULL 0
#define PRIORITIES 7
#define arrival_action Enqueue

class Scheduler
{
private:
  Simult < pcb > pq[ PRIORITIES ]; //����� ��������������
  pcb current;
  bool currentisNULL;
  pcb * immigrant;
  int _type; // ��������� �� ����� ��� scheduler
  bool do_nop;

  void Load()
  {
    //������� ��� ��� ����� �� ������� pcb ��� �� ��������� ��� current
    int i = 0;
    while ( i <= 6 )
    {
      if ( !pq[i].IsEmpty() )
      {
        current = ( pq[i].Pop() );
        currentisNULL = false;

        //������ ��������� [�������� � ������ ���]
        if ( current.Finished( _type ) )
        {
          cout << "������������ �������� ����������� pcb";
          throw;
        }
        current.Start( _type );
        do_nop = 0;
        return;
      }
      ++i;
    }
    currentisNULL = true ;
    do_nop = 1;
  }

  void UnLoad()
  {
    current.Stop();
    //�������� ��� ���� ��� ����
    if ( current.getRemaining_time( _type ) == 0 )
    {
      immigrant = & current;
      currentisNULL = true;
    }
    else //���� ��������� ������������� � �������� �� quantum
      pq[current.getPriority()].Enqueue( current );
  }

public:

  Scheduler( int type )
  {
    do_nop = 1;
    _type = type;
    currentisNULL = true;
    immigrant = 0 ;
  }

  bool AtLeastOneIsWaiting( int Starting_Priority )
  {
    //throw ; // ��������� �� nop
    if( Starting_Priority < 0 || Starting_Priority > ( PRIORITIES - 1 ) ) throw ;
    while ( Starting_Priority >= 0 )
    {
      if ( !pq[ Starting_Priority ].IsEmpty() ) return true;
      -- Starting_Priority;
    }
    return false;
  }

  void feedpcb( pcb * newpcb )
  {
    //�� ������� ��� ������ pcb ��� ���������� ����
    //�������� �� �� ��� pcb ���� ���������� �������������
    if ( !currentisNULL )
    {
      //�� ��� ���� ������������ �� current
      if ( newpcb->getPriority() > current.getPriority() ) UnLoad();
    }

    //��������� �� ��� pcb ���� ��������� ����
    pq[newpcb->getPriority()].arrival_action( * newpcb );
    do_nop = 0;
    Load();
  }

  void execute()
  {

    //�� ��� ������� ������ pcb ���� ������� ����
    if ( currentisNULL )
    {
      Load();
      //�� ��� ��������� ���� ���� �����������
      if ( do_nop )
      {
        cout << "� ����� : " << _type << " ��������" << endl;
        return;
      }
    }

    //�� ��������� ���� � ���� ��������� ���� ����
    if ( !currentisNULL )
    {
      cout << "���������� ��� ��� ���� : "
           << current.getMode()
           << " �� pcb "
           << current.getPID()
           << " . ����������� ������ ��� ���������� : "
           << current.getRemaining_time( _type )
           << endl;

      // �� ��� ���� ��������� �� ���� ��� ����
      if ( !current.Finished( _type ) )
      {
        // �� ��� ���� ��������� �� ���� ��������� ����������
        if ( current.getDone_time() <= QUANTUM ) current.Do_Time();
        else
        {
          // ��� ������� ������������
          // ���������� ���� �����
          if ( AtLeastOneIsWaiting( current.getPriority() ) )
          {
            UnLoad();
            Load();
          }
          // ����� ������� �� ����� �������� ���� ���� ��������� ��������� �� ���������� � ���� ���������
          current.Do_Time();
        }
      }
      //�� ���� ��������� �� ��� ���� ���� �������� �������������
      else
      {
        immigrant = & current;
        currentisNULL = true;
        //���� ��� ������������ ����������� �������
        Load();
        //�� ������� ���� �����������
        if ( do_nop && currentisNULL )
        {
          cout << "� ����� : " << _type << " ��������" << endl;
          return;
        }
        //������ �� ���������
        else
          current.Do_Time();
      }
    }
  }

  int getType()
  {
    return _type;
  }

  pcb * getImmigrant()
  {
    //����� ����� � ���������� �� pcb � ���������� ������� NULL
    pcb * p = immigrant;
    immigrant = NULL;
    return p;
  }

  bool Nop()
  {
    return do_nop;
  }

};
