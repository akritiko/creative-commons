#include "process.cpp"
#include <iostream.h>
#include "logger.h"

// κλάση process control block
class pcb {
private:
    process ip;
    int remaining_time;
    int pid;
    int started;

public:
    // δημιουργός
    pcb( int PID, process source ) {
        ip = source;
        remaining_time = ip.burst_time;
        pid = PID;
        started = -1;
    }

    // κενός δημιουργός
    pcb() {
    }

    // προχωρά την διεργασία για το ποσό χρόνου που δίνεται
    // η τρίτη παράμετρος είναι συνάρτηση που κρατά στατιστικά
    int Dotime( int quantity, long int current_time, Logger *lestat ) {
        //ξεκινά την εκτέλεση της διεργασίας άν χρειάζεται
        if ( started == -1 ) {
            started = current_time;
            cerr << pid << ": Ξεκινά για πρώτη φορά η εκτέλεσή της διεργασίας" << endl;
        }
        //επιστρέφει το ποσό χρόνου που απομένει
        cerr << pid << ": Εκτέλεση. Εναπομείνας χρόνος:" << remaining_time << endl;
        if ( remaining_time <= quantity ) {
            remaining_time = 0;
            cerr << pid << ": Εκτελέστηκε για " << quantity << " απομένει " << remaining_time << endl;
            cerr << pid << ": Η διεργασία ολοκληρώθηκε" << endl;
            cerr << pid << ": Χρόνος απόκρισης : " << started - ip.arrival_time << endl;
            cerr << pid << ": Χρόνος επιστροφής : " << current_time - started + quantity << endl;
            lestat->log( current_time - started + quantity, started - ip.arrival_time );
            return remaining_time;
        }
        remaining_time -= quantity;
        cerr << pid << ": Εκτελέστηκε για " << quantity << " απομένει " << remaining_time << endl;
        return remaining_time;
    }

    // ακολουθούν συναρτήσεις προσβασης στα ιδιωτικά μέλη της κλάσης
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
