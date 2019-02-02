#include "Scheduler.cpp"
#include "mersenne.h"

Mersenne m( 60 );

pcb * Generatepcb( int PID, float Chance, int Low_Count, int High_Count,
     int Low_Duration, int High_Duration )
     {
         int Degree = RESOURCES ;
       Simult < int > * Result = new Simult < int > [RESOURCES];
       int Mode = m.IntegerRandom( 0, RESOURCES - 1 ) ;
       if ( Chance * 100 > m.IntegerRandom( 0, 98 ) )
       {
         while ( Degree > 0 )
         {
           int elements = m.IntegerRandom( Low_Count, High_Count );
           while ( elements > 0 )
           {
             ( Result + Degree - 1 )->Push( m.IntegerRandom( Low_Duration, High_Duration ) );
             --elements;
           }
           --Degree;
         }
         // Θεωρούμε οτι πρώτα περνούν απο ενα πόρο , το ποιός είναι αυτός είναι τετριμμένο πρόβλημμα
         return new pcb( PID, 1, Mode, Result );
       }
       else
         return NULL;
}
