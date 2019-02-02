#include "Simult.cpp"
#include <iostream.h>

/*
% για υπέρβαση
    RearPop <- -------------------------- -> Pop
   Rearpeek <-  .|.|double_saran<T>|.|.   <- Push%
   Enqueue% -> -------------------------- -> Dequeue
                                          -> Peek
*/


template < class data >
class SHeap : public Simult < data > {
public:
    SHeap() {

    }

    void Push( data newValue ) {
        if ( IsEmpty() || newValue.getArrival_time() < _head->Value().getArrival_time() ) {
            Simult < data >::Push( newValue );
            return;
        }
        double_saran < data > * cursor = _head;
        for ( int i = 0; i < _count; ++i ) {
            if ( newValue.getArrival_time() < cursor->Value().getArrival_time() ) {
                double_saran < data > * previous = cursor->getNext();
                double_saran < data > * stub = new double_saran < data > ( cursor, cursor->getNext(), newValue );
                if ( previous != NULL ) previous->setPrevious( stub );
                cursor->setNext( stub );
                ++_count;
                return;
            }
            cursor = cursor->getPrevious();
        }
        Simult < data >::Enqueue( newValue );
    }

    void Enqueue( pcb newValue ) {
        this->Push( newValue );
    }

};
