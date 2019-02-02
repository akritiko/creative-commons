#define N 3
#include "Simult.h"
#include <iostream.h>
#include "Logger.h"
#define RESOURCES 3

int Time;
Logger Log;



// κλάση process control block
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
    // δημιουργός
    pcb( int PID, int Priority, int Mode ) {
        time_created = Time;
        priority = Priority;
        mode = Mode;
        time_started = -1;
        pid = PID;
        done_time = 0;
    }

    // κενός δημιουργός
    pcb() {
    }

    //δημιουργός απο τυχαιοποιητή
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

    // προχωρά την διεργασία για το ποσό χρόνου που δίνεται
    void Do_Time() {
        // ενημέρωση στατιστικών αν αυτό είναι απαραίτητο
        if ( time_started == -1 ) {
            time_started = Time;
            Log.logResponseTime( Time - time_created );
        }
        // αν δεν υπάρχει εργασία για να γίνει τότε το pcb παύει εαυτόν

        if ( _times[mode].IsEmpty() || _times[mode].Peek() == 0 ){
            cout << "το pcb" << pid << " παύει εαυτόν" << endl ;
            Stop();
            return ;
        }
        // μείωση του χρόνου που απομένει
        _times[mode].Push( _times[mode].Pop() - 1 );
        cout << "Εκτελείται το pcb " << mode << " και απομένει "
             << getRemaining_time(mode)  << endl ;
        ++ done_time;
    }

    bool Migrate() {
        //απόρριψη του άδειου τμήματος εργασίας
        _times[mode].KillTopUnmanaged();
        //αναζήτηση της επόμενης εργασίας
        int cursor = mode + 1;
        while ( !this->Dead() && cursor < 15 ) {
            if ( this->Finished( cursor % RESOURCES ) ) _times[mode].KillTopUnmanaged();
            else {
                cout << "το pcb " << pid << " μεταπηδά απο τον πόρο " ;
                mode = cursor % RESOURCES;
                cout << " στο " << mode << endl ;
                return true;
            }
            ++cursor;
        }
        cout << "το pcb :" << pid << " υπηρέτησε επιτυχώς τους σκοπούς του" << endl;
        return false;
    }

    bool Finished( int Mode ) {
        // αν είναι άδεια η στοίβα
        if ( _times[Mode].IsEmpty() ) return true;
        // ή η κορυφαία τιμή είναι 0
        return _times[Mode].Peek() == 0;
    }

    bool Dead() {
        // αν άδειασαν όλες οι στοίβες
        for ( int i = 0; i < N; i++ ) {
            if ( !_times[i].IsEmpty() ) return 0;
        }
        Log.logReturnTime( Time - time_started );
        return 1;
    }

    void Start( int type ) {
        if ( _times[type].IsEmpty() ) cout << endl << "Επιχειρείται εκτέλεση pcb που έχει τερματίσει" << endl ;
        mode = type;
    }

    void Stop() {
        cout << "Ο πόρος : " << mode << " χρησιμοποιήθηκε απο την " << pid << " για " << done_time << endl;
        done_time = 0;
        if ( _times[mode].Peek() == 0 )
            cout << "Scheduler: " << mode << " process " << pid << " has finished " << endl; //afairei to xrono 0
    }

    // ακολουθούν συναρτήσεις προσβασης στα ιδιωτικά μέλη της κλάσης
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
