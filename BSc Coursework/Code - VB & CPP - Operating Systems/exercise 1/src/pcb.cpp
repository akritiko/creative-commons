#include "process.cpp"
#include <iostream.h>
#include "logger.h"

// ����� process control block
class pcb {
private:
    process ip;
    int remaining_time;
    int pid;
    int started;

public:
    // ����������
    pcb( int PID, process source ) {
        ip = source;
        remaining_time = ip.burst_time;
        pid = PID;
        started = -1;
    }

    // ����� ����������
    pcb() {
    }

    // ������� ��� ��������� ��� �� ���� ������ ��� �������
    // � ����� ���������� ����� ��������� ��� ����� ����������
    int Dotime( int quantity, long int current_time, Logger *lestat ) {
        //������ ��� �������� ��� ���������� �� ����������
        if ( started == -1 ) {
            started = current_time;
            cerr << pid << ": ������ ��� ����� ���� � �������� ��� ����������" << endl;
        }
        //���������� �� ���� ������ ��� ��������
        cerr << pid << ": ��������. ����������� ������:" << remaining_time << endl;
        if ( remaining_time <= quantity ) {
            remaining_time = 0;
            cerr << pid << ": ����������� ��� " << quantity << " �������� " << remaining_time << endl;
            cerr << pid << ": � ��������� ������������" << endl;
            cerr << pid << ": ������ ��������� : " << started - ip.arrival_time << endl;
            cerr << pid << ": ������ ���������� : " << current_time - started + quantity << endl;
            lestat->log( current_time - started + quantity, started - ip.arrival_time );
            return remaining_time;
        }
        remaining_time -= quantity;
        cerr << pid << ": ����������� ��� " << quantity << " �������� " << remaining_time << endl;
        return remaining_time;
    }

    // ���������� ����������� ��������� ��� �������� ���� ��� ������
    int getPID() {
        return pid;
    }

    int getArrival_time() {
        return ip.arrival_time;
    }

    int getRemaining_time() {
        return remaining_time;
    }

    int getBurst_time() {
        return ip.burst_time;
    }

    int getPriority() {
        return ip.priority;
    }
};
