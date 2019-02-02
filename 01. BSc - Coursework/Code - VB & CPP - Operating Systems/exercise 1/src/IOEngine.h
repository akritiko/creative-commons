#include <string.h>
#include <fstream.h>

// κλάση αναγνώστης αρχείων πηγής
class IOEngine {
private:
    ifstream reader;
    ofstream writer;
    bool _eof_flag;

public:
    //αρχικοποίηση των ρευμάτων
    IOEngine() {
        reader.open( "proc.db" );
        if ( reader.bad() ) {
            cerr << "Απέτυχε η ανάγνωση του proc.db";
            throw;
        }
        _eof_flag = 0;
        return;
    }

    //επιστρέφει την επόμενη διεργασία απο το αρχείο
    //υπογραφή διεργασίας:
    //int pid|long int arrival_time|long int burst_time|int priority
    process deSerializeProcess() {
        process result;
        char buffer[20];

        reader.getline( buffer, 21, '|' );
        result.arrival_time = atol( buffer );
        reader.getline( buffer, 21, '|' );
        result.burst_time = atol( buffer );
        reader.getline( buffer, 21, '|' );
        result.priority = atoi( buffer );

        if ( result.arrival_time == 0 && result.burst_time == 0 && result.priority == 0 ) _eof_flag = 1;

        return result;
    }

    bool eof(){
        return _eof_flag ;
    }

};

