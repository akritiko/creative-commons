// Ορισμός 32bit ακεραίων για μάσκες
// Για καλύτερη κατανομή αλλαγή αυτών σε 64 bit υπολογιστές

typedef signed long int32;
typedef unsigned long uint32;



#define MERS_N   351
#define MERS_M   175
#define MERS_R   19
#define MERS_U   11
#define MERS_S   7
#define MERS_T   15
#define MERS_L   17
#define MERS_A   0xE4BD75F5
#define MERS_B   0x655E5280
#define MERS_C   0xFFD58000

class Mersenne {
private:
    uint32 mt[MERS_N]; // διάνυσμα κατάστασης
    int mti; // δείκτης στο mt

public:
    Mersenne( uint32 seed ) { // δημιουργός
        RandomInit( seed );
    }

    void RandomInit( uint32 seed ) {
        // νέος σπόρος
        mt[0] = seed;
        for ( mti = 1; mti < MERS_N; mti++ ) {
            mt[mti] = ( 1812433253UL * ( mt[mti - 1] ^ ( mt[mti - 1] >> 30 ) ) + mti );
        }
    }

    int IntegerRandom( int low, int high ) {
        // πειστροφή αριθμού στο πεδίο low <= x <= high

        union {
            double f; uint32 i[2];
        }
        convert;

        uint32 y; // Γένεση 32 τυχαίων bits

        if ( mti >= MERS_N ) {
            // γένεση MERS_N λέξεων σε μια κίνηση
            const uint32 LOWER_MASK = ( 1LU << MERS_R ) - 1; // κάτω MERS_R bits
            const uint32 UPPER_MASK = -1L << MERS_R; // άνω (32 - MERS_R) bits
            static const uint32 mag01[2] = {
                0, MERS_A
            };

            int kk;
            for ( kk = 0; kk < MERS_N - MERS_M; kk++ ) {
                y = ( mt[kk] & UPPER_MASK ) | ( mt[kk + 1] & LOWER_MASK );
                mt[kk] = mt[kk + MERS_M] ^ ( y >> 1 ) ^ mag01[y & 1];
            }

            for ( ; kk < MERS_N - 1; kk++ ) {
                y = ( mt[kk] & UPPER_MASK ) | ( mt[kk + 1] & LOWER_MASK );
                mt[kk] = mt[kk + ( MERS_M - MERS_N )] ^ ( y >> 1 ) ^ mag01[y & 1];
            }

            y = ( mt[MERS_N - 1] & UPPER_MASK ) | ( mt[0] & LOWER_MASK );
            mt[MERS_N - 1] = mt[MERS_M - 1] ^ ( y >> 1 ) ^ mag01[y & 1];
            mti = 0;
        }

        y = mt[mti++];

        // Προαιρετική ανάδευση [δεν βελτιώνει εγγυημένα την τυχαιότητα]
        y ^= y >> MERS_U;
        y ^= ( y << MERS_S ) & MERS_B;
        y ^= ( y << MERS_T ) & MERS_C;
        y ^= y >> MERS_L;

        convert.i[0] = y << 20;
        convert.i[1] = ( y >> 12 ) | 0x3FF00000;

        // πολλαπλασιασμός τυχαίου με το διάκενο και αποκοπή
        int r = int( ( high - low + 1 ) * ( convert.f - 1.0 ) ) + low;
        if ( r > high ) r = high;
        if ( high < low ) return 0x80000000;
        return r;
    }
};
