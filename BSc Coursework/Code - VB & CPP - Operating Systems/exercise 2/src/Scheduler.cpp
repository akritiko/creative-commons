#include "pcb.h"

#define CPU 0
#define DISK 1
#define PRN 2

#define QUANTUM 4
#define NULL 0
#define PRIORITIES 7
#define arrival_action Enqueue

class Scheduler
{
private:
  Simult < pcb > pq[ PRIORITIES ]; //ουρές προτεραιότητας
  pcb current;
  bool currentisNULL;
  pcb * immigrant;
  int _type; // καθοριζει το ειδος του scheduler
  bool do_nop;

  void Load()
  {
    //παίρνει απο τις ουρές το επόμενο pcb και το τοποθετεί στο current
    int i = 0;
    while ( i <= 6 )
    {
      if ( !pq[i].IsEmpty() )
      {
        current = ( pq[i].Pop() );
        currentisNULL = false;

        //Μελέτη σφάλματος [τελείωσε ο χρόνος του]
        if ( current.Finished( _type ) )
        {
          cout << "Επιχειρήθηκε εκτέλεση τελειωμένου pcb";
          throw;
        }
        current.Start( _type );
        do_nop = 0;
        return;
      }
      ++i;
    }
    currentisNULL = true ;
    do_nop = 1;
  }

  void UnLoad()
  {
    current.Stop();
    //τελείωσε απο αυτό τον πόρο
    if ( current.getRemaining_time( _type ) == 0 )
    {
      immigrant = & current;
      currentisNULL = true;
    }
    else //ήρθε υψηλότερη προτεραιότητα ή τελείωσε το quantum
      pq[current.getPriority()].Enqueue( current );
  }

public:

  Scheduler( int type )
  {
    do_nop = 1;
    _type = type;
    currentisNULL = true;
    immigrant = 0 ;
  }

  bool AtLeastOneIsWaiting( int Starting_Priority )
  {
    //throw ; // αμφισημία με nop
    if( Starting_Priority < 0 || Starting_Priority > ( PRIORITIES - 1 ) ) throw ;
    while ( Starting_Priority >= 0 )
    {
      if ( !pq[ Starting_Priority ].IsEmpty() ) return true;
      -- Starting_Priority;
    }
    return false;
  }

  void feedpcb( pcb * newpcb )
  {
    //άν υπάρχει ήδη κάποιο pcb που εκτελείται τότε
    //εξετάζει αν το νέο pcb έχει μεγαλύτερη προτεραιότητα
    if ( !currentisNULL )
    {
      //αν ναι τότε αποκαθηλώνει το current
      if ( newpcb->getPriority() > current.getPriority() ) UnLoad();
    }

    //τοποθετεί το νέο pcb στην κατάλληλη ουρά
    pq[newpcb->getPriority()].arrival_action( * newpcb );
    do_nop = 0;
    Load();
  }

  void execute()
  {

    //αν δεν υπάρχει τρέχον pcb τότε φόρτωση ενός
    if ( currentisNULL )
    {
      Load();
      //αν δεν φορτώθηκε κάτι τότε περιμένουμε
      if ( do_nop )
      {
        cout << "Ο πόρος : " << _type << " αναμένει" << endl;
        return;
      }
    }

    //αν φορτώθηκε κάτι ή ηταν φορτωμένο πρίν τότε
    if ( !currentisNULL )
    {
      cout << "Εκτελειται απο τον πόρο : "
           << current.getMode()
           << " το pcb "
           << current.getPID()
           << " . Εναπομέινας χρόνος για ολοκλήρωση : "
           << current.getRemaining_time( _type )
           << endl;

      // αν δεν έχει τελειώσει με αυτό τον πόρο
      if ( !current.Finished( _type ) )
      {
        // αν δεν έχει ξεπεράσει το όριο εκτέλεσης εκτελείται
        if ( current.getDone_time() <= QUANTUM ) current.Do_Time();
        else
        {
          // και υπάρχει ανταγωνιστής
          // επιστρέφει στις ουρές
          if ( AtLeastOneIsWaiting( current.getPriority() ) )
          {
            UnLoad();
            Load();
          }
          // είναι ασφαλές να γίνει εκτέλεση αφου στην χειρότερη περίπτωση θα επιστρέψει η ίδια διεργασία
          current.Do_Time();
        }
      }
      //άν έχει τελειώσει με τον πόρο αυτό αιτείται μετανάστευσης
      else
      {
        immigrant = & current;
        currentisNULL = true;
        //μετά την μετανάστευση επιχειρούμε φόρτωση
        Load();
        //αν απέτυχε τότε περιμένουμε
        if ( do_nop && currentisNULL )
        {
          cout << "Ο πόρος : " << _type << " αναμένει" << endl;
          return;
        }
        //αλλιώς το εκτελούμε
        else
          current.Do_Time();
      }
    }
  }

  int getType()
  {
    return _type;
  }

  pcb * getImmigrant()
  {
    //Μόλις πάρει ο αναγνώστης το pcb ο μετανάστης γίνεται NULL
    pcb * p = immigrant;
    immigrant = NULL;
    return p;
  }

  bool Nop()
  {
    return do_nop;
  }

};
