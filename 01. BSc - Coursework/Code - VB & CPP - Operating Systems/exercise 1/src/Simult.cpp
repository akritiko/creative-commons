#include "double_saran.cpp"
#include <iostream.h>
#include <string.h>
#include <fstream.h>
#include <stdlib.h>

/* �������� ����� ����������� ��������� ��� ��������� ��������� �����, �������
��� ������������ ������ �������� ��� �������� ���� ������������� ��� ����� */

/*
   RearPop <- -------------------------- -> Pop
  Rearpeek <-  .|.|double_saran<T>|.|.   <- Push
   Enqueue -> -------------------------- -> Dequeue
                                         -> Peek
*/




template < class data >
class Simult {
protected:
    double_saran < data > * _head;
    double_saran < data > * _tail;
    long int _count;

public:
    // ����������
    Simult() {
        _head = 0;
        _tail = 0;
        _count = 0;
    }

    // ���������� �� ������ ��� ������������� ���������
    long int Count() {
        return _count;
    }

    // ������ ��� ��� � ���� ����� ���� ���������
    bool const IsEmpty() {
        return _count == 0;
    }

    // ���������� �� �������� �������� ����� �� �� �������
    data Peek() {
        if ( IsEmpty() ) throw;

        return _head->Value();
    }

    // ���� ��� �������� ���� ������
    void Push( data newValue ) {
        if ( IsEmpty() ) {
            _head = new double_saran < data > ( 0, 0, newValue );//_head egine 0
            _tail = _head;
            ++_count;
            return;
        }
        //else
        _head->setNext( new double_saran < data > ( _head, 0, newValue ) );
        _head = _head->getNext();
        ++_count;
    }

    // ����� ��� �������� ��� ��� ����
    data Dequeue() {
        return this->Pop();
    }

    // ����� �� �������� ��������
    data Pop() {
        if ( IsEmpty() ) throw;

        data result = _head->Value();
        double_saran < data > * dmw = _head;
        _head = _head->getPrevious();
        --_count;
        delete dmw;
        return result;
    }

    // ��������� ��� �������� ���� ����
    void Enqueue( pcb newValue ) {
        if ( IsEmpty() ) {
            _head = new double_saran < data > ( 0 , 0, newValue );//_head egine 0
            _tail = _head;
            ++_count;
            return;
        }
        //else
        _tail->setPrevious( new double_saran < data > ( 0, _tail, newValue ) );
        _tail = _tail->getPrevious();
        ++_count;
    }

    // ����� �� ������� ��������
    data RearPop() {
        if ( IsEmpty() ) throw;

        data result = _tail->Value();
        double_saran < data > * dmw = _tail;
        // dmw ��� dead man walking
        _tail = _tail->getNext();
        --_count;
        delete dmw;
        return result;
    }

    // ���������� �� ������� �������� ����� �� �� �������
    pcb RearPeek() {
        if ( IsEmpty() ) throw;

        return _tail->Value();
    }

    // ���������� ��� ����� ����������� �������
    double_saran < data > * getNext() {
        return _head;
    }

};


