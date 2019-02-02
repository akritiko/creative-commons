#include "SHeap.cpp"
#define priorities 7
#define arrival_action Push

class Scheduler {
private:
    SHeap < pcb > pending;
    Simult < pcb > pq[priorities]; //����� ��������������
    pcb current;
    long int time;
    int _quantum;
    bool do_nop;
    //����������
    Logger lestat;
    int sum_of_return_times;
    int sum_of_response_times;
    int count_of_return_times;
    int count_of_response_times;


    //������� ��� ��� ����� �� ������� pcb ��� �� ��������� ��� current
    void putnextpcb() {
        int i = 0;
        while ( i < priorities ) {
            if ( !pq[i].IsEmpty() ) {
                current = pq[i].Pop();
                do_nop = 0;
                return;
            }
            ++i;
        }
        //�� ��� ������� ������ ���� ���������� ������ ��������� �������
        do_nop = 1;
    }

    //�������� �� �� �������� �������� ��� ������������ ���������� ���
    //������ �� ��� ��������� ������� ��������� [�� ���� quantum]
    int lookforinterruptors() {
        int result = time + _quantum;
        double_saran < pcb > * cursor = pending.getNext();
        pcb cursorcontent = cursor->Value();

        int i = 0;
        while ( i < pending.Count() - 1 /* && cursorcontent.getArrival_time() < time + _quantum */ ) {
            if ( cursorcontent.getArrival_time() < result && cursorcontent.getPriority() <= current.getPriority() )
                result = cursorcontent.getArrival_time();
            cursor = cursor->getPrevious();
            cursorcontent = cursor->Value();
            ++i;
        }
        return result - time;
    }

    void arrangepending() {
        //����������� ��� ������� ��� ������������ ����������
        while ( ( !pending.IsEmpty() ) && pending.Peek().getArrival_time() <= time ) {
            int slot = pending.Peek().getPriority();
            pcb stub = pending.Pop();
            pq[slot].arrival_action( stub );
        }
    }

public:
    Scheduler( int quantum ) {
        _quantum = quantum;
        time = 0;
        do_nop = 1;
    }

    void feedpcb( pcb newpcb ) {
        pending.Push( newpcb );
    }

    void execute() {
        goto skippushback;
    again:
        if ( !current.getRemaining_time() <= 0 ) pq[current.getPriority()].Enqueue( current );
    skippushback:
        arrangepending();
        putnextpcb();
        /* % �� � ����� ���������� ��� ���������� �������� ���� ��� ��� ����������
        ���� �� ��������� ��� �� ����������� ��� ��������� ���� ��������������
        % �� � ����������� ������� ������� ���� �� ����� ��� ��������
        ������������ ��� �������� ���� ���������� ������������� ����
        ���������� ���� �������� ����������� ������ ���� �� ��� �������
        �������� ��� ��� �������� ������ ��� ��� ����� ��� �������� �������� */
        // ������ ��� ��������� ��� ���� ����� ������ <= time + quantum ���
        // ������������� ���������� ��� ����� ��� ���������
        int allowed = 0;
        if ( pending.IsEmpty() ) allowed = 1000;
        else
            allowed = lookforinterruptors();

        if ( !do_nop ) {
            if ( allowed < current.getRemaining_time() ) dotime( allowed );
            else
                dotime( current.getRemaining_time() );
        }
        else {
            cerr << time << " �������" << endl;
            time += 1;
        }
        if ( pending.IsEmpty() && do_nop ) {
            lestat.publish();
            cerr << endl << "�� ���������� ������������� . ���������";
            return;
        }
        goto again;
    }

    void dotime( int timetodo ) {
        if ( timetodo > _quantum ) {
            Logger hex;
            current.Dotime( _quantum, time, & lestat );
            time += _quantum;
        }
        else {

            current.Dotime( timetodo, time, & lestat );
            time += timetodo;
        }
        cerr << "������ : " << time << endl;
    }

};
