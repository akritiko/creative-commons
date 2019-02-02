#define N 3
#include "Simult.h"
#include <iostream.h>
#include "Logger.h"
#define RESOURCES 3

int Time;
Logger Log;



// ����� process control block
class pcb {
private:
    Simult < int > _times[N];
    //lg
    int time_created;
    int time_started;
    //
    int done_time;
    int pid;
    int mode;
    int priority;

public:
    // ����������
    pcb( int PID, int Priority, int Mode ) {
        time_created = Time;
        priority = Priority;
        mode = Mode;
        time_started = -1;
        pid = PID;
        done_time = 0;
    }

    // ����� ����������
    pcb() {
    }

    //���������� ��� ������������
    pcb( int PID, int Priority, int Mode, Simult < int > * Times ) {
        int all = N - 1;
        while ( all >= 0 ) {
            this->_times[all] = * ( Times + all );
            --all;
        }
        time_created = Time;
        time_started = -1;
        pid = PID;
        done_time = 0;
        mode = Mode;
        priority = Priority;
    }

    // ������� ��� ��������� ��� �� ���� ������ ��� �������
    void Do_Time() {
        // ��������� ����������� �� ���� ����� ����������
        if ( time_started == -1 ) {
            time_started = Time;
            Log.logResponseTime( Time - time_created );
        }
        // �� ��� ������� ������� ��� �� ����� ���� �� pcb ����� ������

        if ( _times[mode].IsEmpty() || _times[mode].Peek() == 0 ){
            cout << "�� pcb" << pid << " ����� ������" << endl ;
            Stop();
            return ;
        }
        // ������ ��� ������ ��� ��������
        _times[mode].Push( _times[mode].Pop() - 1 );
        cout << "���������� �� pcb " << mode << " ��� �������� "
             << getRemaining_time(mode)  << endl ;
        ++ done_time;
    }

    bool Migrate() {
        //�������� ��� ������ �������� ��������
        _times[mode].KillTopUnmanaged();
        //��������� ��� �������� ��������
        int cursor = mode + 1;
        while ( !this->Dead() && cursor < 15 ) {
            if ( this->Finished( cursor % RESOURCES ) ) _times[mode].KillTopUnmanaged();
            else {
                cout << "�� pcb " << pid << " �������� ��� ��� ���� " ;
                mode = cursor % RESOURCES;
                cout << " ��� " << mode << endl ;
                return true;
            }
            ++cursor;
        }
        cout << "�� pcb :" << pid << " ��������� �������� ���� ������� ���" << endl;
        return false;
    }

    bool Finished( int Mode ) {
        // �� ����� ����� � ������
        if ( _times[Mode].IsEmpty() ) return true;
        // � � �������� ���� ����� 0
        return _times[Mode].Peek() == 0;
    }

    bool Dead() {
        // �� �������� ���� �� �������
        for ( int i = 0; i < N; i++ ) {
            if ( !_times[i].IsEmpty() ) return 0;
        }
        Log.logReturnTime( Time - time_started );
        return 1;
    }

    void Start( int type ) {
        if ( _times[type].IsEmpty() ) cout << endl << "������������ �������� pcb ��� ���� ����������" << endl ;
        mode = type;
    }

    void Stop() {
        cout << "� ����� : " << mode << " ��������������� ��� ��� " << pid << " ��� " << done_time << endl;
        done_time = 0;
        if ( _times[mode].Peek() == 0 )
            cout << "Scheduler: " << mode << " process " << pid << " has finished " << endl; //afairei to xrono 0
    }

    // ���������� ����������� ��������� ��� �������� ���� ��� ������
    int getPID() {
        return pid;
    }

    int getRemaining_time( int type ) {
        return _times[type].Peek();
    }

    int getDone_time() {
        return done_time;
    }

    int getMode() {
        return mode;
    }

    void setMode( int newmode ) {
        mode = newmode;
    }

    int getPriority() {
        return priority;
    }

};
