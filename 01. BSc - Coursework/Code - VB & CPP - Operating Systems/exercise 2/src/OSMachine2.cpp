#include <iostream.h>
#include "GenPCB.cpp"

#define CPU 0
#define DISK 1
#define PRN 2

#define N 3
#define TotalTicks 5


Scheduler S[] = {
    Scheduler( CPU ), Scheduler( DISK ), Scheduler( PRN )
};

/*void ScanforImmigrants() { int cursor = 0; while ( cursor < 3 ) {

pcb * immigrant = S[cursor].getImmigrant(); if ( immigrant != NULL ) HandleApplicant( immigrant ); } }*/

bool AllSchedulersAreEmpty() {
    int cursor = 0;
    while ( cursor < 3 ) {
        if ( !S[cursor].Nop() ) return false;
        ++cursor;
    }
    return true;
}

void AllSchedulersExecute() {
    int cursor = 0;
    while ( cursor < 3 ) {
        S[cursor].execute();
        ++cursor;
    }
}

void HandleApplicant( pcb * applicant ) {
    if ( !applicant->Migrate() ) return /* delete applicant */;
    //αλλιώς
    S[applicant->getMode()].feedpcb( applicant );
}

int PID_Pool = 0;

int main() {
    pcb * f = 0 ;

    while ( Time < TotalTicks || !AllSchedulersAreEmpty() ) {
        // Γένεση νέου pcb {
        if ( Time < TotalTicks )
            f = Generatepcb( PID_Pool , 0.8, 1, 3, 0, 10 );
        else
            f = 0;
        if ( f != 0 ) {
            PID_Pool ++ ;
            HandleApplicant( f );
            cout << "εισήχθη νέο pcb " << f->getPID() << endl ;
            f = 0 ;
        }
        // }

        cout << "Χρόνος : " << Time << endl;

        // Διαχείρηση μεταναστών {
        int device = 0;
        while ( device < 3 ) {
            pcb * mig = S[device].getImmigrant();
            if ( mig != NULL ) {
                HandleApplicant( mig );
            }
            ++device;
        }
        // }

        AllSchedulersExecute();
        Time ++ ;
    }

    Log.publish() ;
    std::cout << "Φυσιολογικός τερματισμός στο χρόνο : " << Time ;
}



