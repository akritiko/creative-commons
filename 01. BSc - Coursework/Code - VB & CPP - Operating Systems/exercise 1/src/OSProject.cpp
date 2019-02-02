// OSProject.cpp : Σημείο εκκίνησης της εφαρμογής

#include <iostream.h>
#include "Scheduler.cpp"
#include "IOEngine.h"
#define quantum 1

IOEngine * lio ;

int main() {
    int processcounter = 0;
    lio = new IOEngine();
    Scheduler harvester( quantum );
    pcb * new_process;

    new_process = new pcb( ++processcounter, lio->deSerializeProcess() );
    if ( lio->eof() ) exit( 0 );
    harvester.feedpcb( * new_process );
getnext:
    new_process = new pcb( ++processcounter, lio->deSerializeProcess() );
    if ( !lio->eof() ) {
        harvester.feedpcb( * new_process );
        goto getnext;
    }

    harvester.execute();
    return 0;
}



