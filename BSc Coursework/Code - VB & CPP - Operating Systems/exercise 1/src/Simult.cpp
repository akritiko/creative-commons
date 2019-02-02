#include "double_saran.cpp"
#include <iostream.h>
#include <string.h>
#include <fstream.h>
#include <stdlib.h>

/* ευέλικτη κλάση αποθήκευσης δεδομένων που συνδιάζει υπηρεσίες ουράς, στοίβας
και δισυνδετικής λίστας υλοποιεί τις διεπαφές όπως περιγράφονται στο σχήμα */

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
    // δημιουργός
    Simult() {
        _head = 0;
        _tail = 0;
        _count = 0;
    }

    // επιστρέφει το πλήθος των αποθηκευμένων στοιχείων
    long int Count() {
        return _count;
    }

    // απαντά στο εάν η δομή είναι κενή στοιχείων
    bool const IsEmpty() {
        return _count == 0;
    }

    // επιστρέφει το κορυφαίο στοιχείο χωρις να το αφαιρεί
    data Peek() {
        if ( IsEmpty() ) throw;

        return _head->Value();
    }

    // ωθεί ενα στοιχείο στην κορυφή
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

    // τραβά ένα στοιχείο απο την ουρά
    data Dequeue() {
        return this->Pop();
    }

    // τραβά το κορυφαίο στοιχείο
    data Pop() {
        if ( IsEmpty() ) throw;

        data result = _head->Value();
        double_saran < data > * dmw = _head;
        _head = _head->getPrevious();
        --_count;
        delete dmw;
        return result;
    }

    // τοποθετεί ενα στοιχείο στην ουρά
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

    // τραβά το ουριαίο στοιχείο
    data RearPop() {
        if ( IsEmpty() ) throw;

        data result = _tail->Value();
        double_saran < data > * dmw = _tail;
        // dmw για dead man walking
        _tail = _tail->getNext();
        --_count;
        delete dmw;
        return result;
    }

    // επιστρέφει το ουριαίο στοιχείο χωρίς να το αφαιρεί
    pcb RearPeek() {
        if ( IsEmpty() ) throw;

        return _tail->Value();
    }

    // επιστρέφει την κλάση περιτύλιγμα κεφαλής
    double_saran < data > * getNext() {
        return _head;
    }

};


