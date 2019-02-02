#include <stdio.h>

#define N 5 //Αριθμος κομβων του γραφου

void main()
{
  //Ορισμός του πίνακα γειτνίασης του εκαστοτε γραφου
  int PinakasGeitniasis[N] [N] =
  {
    {
      0, 1, 0, 1, 1
    },
    {
      1, 0, 1, 1, 0
    },
    {
      0, 1, 0, 1, 0
    },
    {
      1, 1, 1, 0, 0
    },
    {
      1, 0, 0, 0, 0
    }

  };

  //Πληθος μοναδων ανα στήλη
  int plithosMonadon[N - 1] =
  {
    0, 0, 0, 0
  };

  //Θεσεις μοναδων και πλήθος εμφανισεων (σειρά - στηλη - πληθος εμφ)
  int theseisMonadon[6] [3] =
  {
    {
      0, 0, 0
    },
    {
      0, 0, 0
    },
    {
      0, 0, 0
    },
    {
      0, 0, 0
    },
    {
      0, 0, 0
    },
    {
      0, 0, 0
    },
  };

  //Πίνακας όλων των ζευγνυόντων δένδρων
  int myCoords[12] [2] =
  {
    {
      0, 0
    },
    {
      0, 0
    },
    {
      0, 0
    },
    {
      0, 0
    },
    {
      0, 0
    },
    {
      0, 0
    },
    {
      0, 0
    },
    {
      0, 0
    },
    {
      0, 0
    },
    {
      0, 0
    },
    {
      0, 0
    },
    {
      0, 0
    },

  };

  //ΤΜΗΜΑ 1
  //Εύρεση πληθους ζευγνυόντων δένδρων και θέσεων μοναδων στον πίνακα γειτνίασης

  //ΤΜΗΜΑ 1

  int i = 0;
  int j = 0;
  int seires = 0;
  int stiles = 0;
  int counter = 0;
  int counter1 = 0;
  int trexousaThesiStilis = 0;
  int maxOnes = 0;
  int plithosParaviaseonOriou = -1;
  int bima = 0;
  int k = 0;
  int plithosEmfaniseon = 0;
  int pZeygnyonton = 1;
  int telikoPlithosMonadon = 0;
  int pMonadon = 0;
  int thesiTeleutaiasPollaplisStilis = 0;

  char mychar;
  int arxi = 0;
  int telos = 0;
  int whiteflag = 0;



  //Εμφανίζει τον αρχικο πίνακα γειτνιασης
  for ( i = 0; i < N; i++ )
  {
    for ( j = 0; j < N; j++ )
    {
      printf( "%d", PinakasGeitniasis[i] [j] );
      printf( ", " );
    }
    printf( "\n" );
  }
  printf( "\n" );
  printf( "Press any key..." );
  mychar = getchar();


  for ( stiles = 1; stiles < N; stiles++ )
  {
    pMonadon = 0;
    for ( seires = 0; seires < stiles; seires++ )
    {
      if ( PinakasGeitniasis[seires] [stiles] == 1 )
      {
        //πληθος μοναδων στηλης
        pMonadon++;

        //θεσεις μοναδων
        theseisMonadon[counter1] [0] = seires;
        theseisMonadon[counter1] [1] = stiles;
        counter1++;
      }
    }

    if ( pMonadon > maxOnes )
    {
      maxOnes = pMonadon;
      thesiTeleutaiasPollaplisStilis = trexousaThesiStilis;
    }


    telikoPlithosMonadon = telikoPlithosMonadon + pMonadon;
    plithosMonadon[trexousaThesiStilis] = pMonadon;
    trexousaThesiStilis++;
    //τελικο πληθος μοναδων
    pZeygnyonton = pZeygnyonton * pMonadon;
  }

  //ΤΜΗΜΑ 2
  //ΕΥΡΕΣΗ ΟΛΩΝ ΤΩΝ ΖΕΥΓΝΥΟΝΤΩΝ ΔΕΝΔΡΩΝ



  /* Προσθηκη στην τριτη στηλη του theseisMonadon του πλήθους εμφανίσεων στον MyCoords[] */
  for ( i = 0; i < N - 1; i++ )
  {
    plithosEmfaniseon = pZeygnyonton / plithosMonadon[i];
    for ( j = bima; j < plithosMonadon[i] + bima; j++ )
    {
      theseisMonadon[j] [2] = plithosEmfaniseon;
    }
    bima = bima + plithosMonadon[i];
  }

  bima = 0;

  //Για καθε στοιχέιο του πίνακα θεσεων
  for ( counter = 0; counter < telikoPlithosMonadon; counter++ )
  {

    if ( theseisMonadon[counter] [1] == thesiTeleutaiasPollaplisStilis + 1 )
    {
      counter1 = 0;
      for ( k = counter; k < telikoPlithosMonadon; k++ )
      {
        if ( theseisMonadon[k] [1] == thesiTeleutaiasPollaplisStilis + 1 )
        {
          counter1++;
        }
      }
      bima = thesiTeleutaiasPollaplisStilis + 1;
      for ( k = 0; k < counter1; k++ )
      {
        myCoords[thesiTeleutaiasPollaplisStilis] [0] = theseisMonadon[counter] [0];
        myCoords[thesiTeleutaiasPollaplisStilis] [1] = theseisMonadon[counter] [1];
        counter++;
        thesiTeleutaiasPollaplisStilis = thesiTeleutaiasPollaplisStilis + ( N - 1 );
      }
      counter--;
    }
    else
    {
      //Αν bima ξεπερνα το μεγεθος του πίνακα myCoords
      if ( bima >= ( pZeygnyonton * ( N - 1 ) ) )
      {
        //Κανε το bima -> τρεχουσα θεση - φορες που ξεπεράστηκε το μεγεθος του myCoords
        bima = counter - plithosParaviaseonOriou;
      }
      //Αλλιως
      else
      {
        plithosParaviaseonOriou++; //αύξησε τις φορές που ξεπεράστηκε το μεγεθος του myCoords
      }

      //εισαγωγή εγγραφων συνεχομενα στον πίνακα
      for ( k = 0; k < theseisMonadon[counter] [2]; k++ )
      {
        myCoords[bima] [0] = theseisMonadon[counter] [0];
        myCoords[bima] [1] = theseisMonadon[counter] [1];

        //συνθηκη αλλαγης του bimatos
        bima = bima + ( N - 1 );
      }
    }
  }

  //Εμφανίζει τα τελικα ζευγνύοντα δένδρα


  arxi = 0;
  telos = arxi + 4;
  for ( counter = 0; counter < 3; counter++ )
  {
    printf( "\n\nSpanning tree #%d.\n\n", counter + 1 );
    for ( seires = 0; seires < 5; seires++ )
    {
      for ( stiles = 0; stiles < 5; stiles++ )
      {
        whiteflag = 0;
        for ( i = arxi; i < telos; i++ )
        {


          if ( myCoords[i] [0] == seires && myCoords[i] [1] == stiles )
          {
            printf( "1, " );
            whiteflag = 1;
          }

        }
        if ( whiteflag == 0 )
        {
          printf( "0, " );
        }

      }
      printf( "\n" );

    }
    printf( "\n\nPress any key..." );
    mychar = getchar();


    arxi = arxi + 4;
    telos = arxi + 4;
  }
}


