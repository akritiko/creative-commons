#include "./IOHandler.h"

void IOHandler::ReadBooks()
{


  fstream file; //METAVLHTH DIAXEIRISHS ARXEIOY
  unsigned int i; //METRHTHS GIA TA for loops

  /* DHMIOYRGIA TOY PINAKA VIVLION APO TO ANTISTOIXO ARXEIO */

  //EPIXEIROYME NA ANOIKSOYME TO ARXEIO
  file.open( "Books.file", ios::in | ios::binary );

  if ( !file ) //AN DEN YPARXEI
  {
    cout << "Unable to locate 'Books.file'." << endl << endl;
  }
  else //ALLIOS YPOLOGIZETAI TO PLHTHOS TON EGGRAFON - VIVLION (NOFBooks)
  {
    file.seekg( 0, ios::end );
    _NOFBooks = file.tellg() / sizeof( Book );
    if ( _NOFBooks == 0 ) //AN TO ARXEIO EINAI KENO
    {
      //ENHMERONEI TON XRHSTH OTI DEN YPARXOYN EGGRAFES
      cout << "There are no books inserted!" << endl << endl;
    }
    else //ALLIOS FTIAXNEI ENAN PINAKA ME TA VIVLIA POY PERIEXEI TO ARXEIO
    {
      //KANOYME TON DEIKTH Books NA DEIXNEI SE ENA NEO PINAKA MEGETHOYS [_NOFBooks]
      Book * Books = new Book[_NOFBooks];
      //DHLONOYME MIA PROSORINH METAVLHTH TYPOY Book
      Book Temp;
      //KSEKINOYME NA PSAXNOYME APO THN ARXH TOY ARXEIO Books.file
      file.seekg( 0 );
      /* TO PARAKATO LOOP DIAVAZEI MIA - MIA TIS EGGRAFES APO TO ARXEIO
      KAI TIS KATAXOREI STON PINAKA POY DEIXNEI O PROSORINOS DEIKTHS Books.
      OTAN TELEIOSEI TO ARXEIO KLEINEI KAI KANOYME TON DEIKTH _Books
      (POY EINAI KAI PROSOPIKO MELOS THS KLASHS) NA DEIXNEI EKEI POY
      DEIXNEI O Books */
      for ( i = 0; i < _NOFBooks; i++ )
      {
        file.read( ( char * ) & Temp, sizeof( Book ) );
        Books[i] = Temp;
      }
      file.close();
      _Books = Books;
    }
    file.close();
  }
}

void IOHandler::ReadCopies()
{
  fstream file; //METAVLHTH DIAXEIRISHS ARXEIOY
  unsigned int i; //METRHTHS GIA TA for loops

  /* DHMIOYRGIA TOY PINAKA VIVLION APO TO ANTISTOIXO ARXEIO */

  //EPIXEIROYME NA ANOIKSOYME TO ARXEIO
  file.open( "Copies.file", ios::in | ios::binary );

  if ( !file ) //AN DEN YPARXEI
  {
    cout << "Unable to locate 'Copies.file'. " << endl << endl;
  }
  else //ALLIOS YPOLOGIZETAI TO PLHTHOS TON EGGRAFON - ANTITYPON
  {
    file.seekg( 0, ios::end );
    _NOFCopies = file.tellg() / sizeof( Copy );
    if ( _NOFCopies == 0 ) //AN TO ARXEIO EINAI KENO
    {
      //ENHMERONEI TON XRHSTH OTI DEN YPARXOYN EGGRAFES
      cout << "There are no copies inserted!" << endl << endl;
    }
    else //ALLIOS FTIAXNEI ENAN PINAKA ME TA ANTITYPA POY PERIEXEI TO ARXEIO
    {
      //KANOYME TON DEIKTH Copies NA DEIXNEI SE ENA NEO PINAKA MEGETHOYS [_NOFCopies]
      Copy * Copies = new Copy[_NOFCopies];
      //DHLONOYME MIA PROSORINH METAVLHTH TYPOY Copy
      Copy Temp;
      //KSEKINOYME NA PSAXNOYME APO THN ARXH TOY ARXEIOY Copies.file
      file.seekg( 0 );
      /* TO PARAKATO LOOP DIAVAZEI MIA - MIA TIS EGGRAFES APO TO ARXEIO
      KAI TIS KATAXOREI STON PINAKA POY DEIXNEI O PROSORINOS DEIKTHS Copies.
      OTAN TELEIOSEI TO ARXEIO KLEINEI KAI KANOYME TON DEIKTH _Copies
      (POY EINAI KAI PROSOPIKO MELOS THS KLASHS) NA DEIXNEI EKEI POY
      DEIXNEI O Copies */
      for ( i = 0; i < _NOFCopies; i++ )
      {
        file.read( ( char * ) & Temp, sizeof( Copy ) );
        Copies[i] = Temp;
      }
      file.close();
      _Copies = Copies;
    }
    file.close();
  }
}

void IOHandler::ReadAuthors()
{
  fstream file; //METAVLHTH DIAXEIRISHS ARXEIOY
  unsigned int i; //METRHTHS GIA TA for loops


  /* DHMIOYRGIA TOY PINAKA SYGGRAFEON APO TO ANTISTOIXO ARXEIO */

  //EPIXEIROYME NA ANOIKSOYME TO ARXEIO
  file.open( "Authors.file", ios::in | ios::binary );

  if ( !file ) //AN DEN YPARXEI
  {
    cout << "Unable to locate 'Authors.file'." << endl << endl;
  }
  else //ALLIOS YPOLOGIZETAI TO PLHTHOS TON EGGRAFON - SYGGRAFEON (NOFAuthors)
  {
    file.seekg( 0, ios::end );
    _NOFAuthors = file.tellg() / sizeof( Author );
    if ( _NOFAuthors == 0 ) //AN TO ARXEIO EINAI KENO
    {
      //ENHMERONEI TON XRHSTH OTI DEN YPARXOYN EGGRAFES
      cout << "There are no authors inserted!" << endl << endl;
    }
    else //ALLIOS FTIAXNEI ENAN PINAKA ME TOYS SYGGRAFEIS POY PERIEXEI TO ARXEIO
    {
      //KANOYME TON DEIKTH Authors NA DEIXNEI SE ENA NEO PINAKA MEGETHOYS [_NOFAauthors]
      Author * Authors = new Author[_NOFAuthors];
      //DHLONOYME MIA PROSORINH METAVLHTH TYPOY Author
      Author Temp;
      //KSEKINOYME NA PSAXNOYME APO THN ARXH TOY ARXEIO Authors.file
      file.seekg( 0 );
      /* TO PARAKATO LOOP DIAVAZEI MIA - MIA TIS EGGRAFES APO TO ARXEIO
      KAI TIS KATAXOREI STON PINAKA POY DEIXNEI O PROSORINOS DEIKTHS Authors.
      OTAN TELEIOSEI TO ARXEIO KLEINEI KAI KANOYME TON DEIKTH _Authors
      (POY EINAI KAI PROSOPIKO MELOS THS KLASHS) NA DEIXNEI EKEI POY
      DEIXNEI O Authors */
      for ( i = 0; i < _NOFAuthors; i++ )
      {
        file.read( ( char * ) & Temp, sizeof( Author ) );
        Authors[i] = Temp;
      }
      file.close();
      _Authors = Authors;
    }
    file.close();
  }
}

void IOHandler::ReadMembers()
{
  fstream file; //METAVLHTH DIAXEIRISHS ARXEIOY
  unsigned int i; //METRHTHS GIA TA for loops

  /* DHMIOYRGIA TOY PINAKA VIVLION APO TO ANTISTOIXO ARXEIO */

  //EPIXEIROYME NA ANOIKSOYME TO ARXEIO
  file.open( "Members.file", ios::in | ios::binary );

  if ( !file ) //AN DEN YPARXEI
  {
    cout << "Unable to locate 'Members.file'. " << endl << endl;
  }
  else //ALLIOS YPOLOGIZETAI TO PLHTHOS TON EGGRAFON - MELON (NOFMembers)
  {
    file.seekg( 0, ios::end );
    _NOFMembers = file.tellg() / sizeof( Member );
    if ( _NOFMembers == 0 ) //AN TO ARXEIO EINAI KENO
    {
      //ENHMERONEI TON XRHSTH OTI DEN YPARXOYN EGGRAFES
      cout << "There are no Members inserted!" << endl << endl;
    }
    else //ALLIOS FTIAXNEI ENAN PINAKA ME TA MELH POY PERIEXEI TO ARXEIO
    {
      //KANOYME TON DEIKTH Members NA DEIXNEI SE ENA NEO PINAKA MEGETHOYS [_NOFMembers]
      Member * Members = new Member[_NOFMembers];
      //DHLONOYME MIA PROSORINH METAVLHTH TYPOY Member
      Member Temp;
      //KSEKINOYME NA PSAXNOYME APO THN ARXH TOY ARXEIO Members.file
      file.seekg( 0 );
      /* TO PARAKATO LOOP DIAVAZEI MIA - MIA TIS EGGRAFES APO TO ARXEIO
      KAI TIS KATAXOREI STON PINAKA POY DEIXNEI O PROSORINOS DEIKTHS Members.
      OTAN TELEIOSEI TO ARXEIO KLEINEI KAI KANOYME TON DEIKTH _Members
      (POY EINAI KAI PROSOPIKO MELOS THS KLASHS) NA DEIXNEI EKEI POY
      DEIXNEI O Members */
      for ( i = 0; i < _NOFMembers; i++ )
      {
        file.read( ( char * ) & Temp, sizeof( Member ) );
        Members[i] = Temp;
      }
      file.close();
      _Members = Members;
    }
    file.close();
  }
}

//O DHMIOYRGOS
IOHandler::IOHandler()
{
  _Books = 0; //PINAKAS ANTIKEIMENON TYPOY Âook
  _NOFBooks = 0; //KRATA TON ARITHMO TON VIVLION POY EXOYN EISAXTHEI STO ARXEIO Books.file
  _Copies = 0; //PINAKAS ANTIKEIMENON TYPOY Copy
  _NOFCopies = 0; //KRATA TON ARITHMO TON ANTITYPON POY EXOYN EISAXTHEI STO ARXEIO Copies.file
  _Authors = 0; //PINAKAS ANTIKEIMENON TYPOY Author
  _NOFAuthors = 0; //KRATA TON ARITHMO TON SYGGRAFEON POY EXOYN EISAXTHEI STO ARXEIO Authors.file
  _Members = 0; //PINAKAS ANTIKEIMENON TYPOY Âook
  _NOFMembers = 0; //KRATA TON ARITHMO TON MELON POY EXOYN EISAXTHEI STO ARXEIO Members.file
  //  _Logs = 0; //PINAKAS ANTIKEIMENON TYPOY Log
  //  _NOFLogs = 0; //KRATA TON ARITHMO TON VIVLION POY EXOYN EISAXTHEI STO ARXEIO Logs.file

  ReadBooks();
  ReadCopies();
  ReadAuthors();
  ReadMembers();
}


void IOHandler::InsertBook()
{
  fstream file; //DIAXEIRISTHS ARXEIOY
  unsigned int i; //METRHTES

  unsigned int TitleCode; //KODIKOS TITLOY
  char Title[100]; //TITLOS VIVLIOY
  unsigned int CurrentNOFAuthors; //TREXON ARITHMOS SYGGRAFEON

  //PINAKAS SYGGRAFEON KAI PROSORINES METAVLITES GIA SYLLOGH STOIXEION
  unsigned int AuthorCode;
  char Name[30];
  char Surname[30];

  char Description[300]; //PERIGRAFH VIVLIOY
  char PublishingFirm[30]; //EKDOTIKOS OIKOS

  //PROSORINES METAVLITES GIA SYLLOGH STOIXEION HMEROMHNIAS
  unsigned int Day;
  Months Month;
  unsigned int Year;

  //SYLLOGH STOIXEION APO TO XRHSTH
  cout << endl << endl << "BOOK INFORMATIONS";
  //O KODIKOS VIVLIOY EISAGETAI AYTOMATA GIATI 2 VIVLIA DEN MPOROYN NA EXOYN TON IDIO
  TitleCode = _NOFBooks + 1;
  cout << endl << endl << "This Book will be assigned the CODE: " << TitleCode;
  cout << endl << endl << "Please Give us: ";
  cout << endl << "------ ---- --";
  cout << endl << "The NAME of the Book: ";
  fflush( stdin );
  cin.getline( Title, 100 );
  cout << endl << "The DESCRIPTION of the Book: ";
  fflush( stdin );
  cin.getline( Description, 300 );
  cout << endl << "The NAME of the PUBLISHING FIRM: ";
  fflush( stdin );
  cin.getline( PublishingFirm, 30 );
  cout << endl << "The DATE OF PUBLISH: ";
  cout << endl << "Year: ";
  cin >> Year;
  cout << endl << "Month: ";
  unsigned int j;
  cin >> j;

  //Loop METATROPHS AKERAIOY SE Month
  i = 1;
  Month = Jan;
  while ( i != j )
  {
    i++;
    Month++;
  }

  cout << endl << "Day: ";
  cin >> Day;

  Date DOPublish( Day, Month, Year ); //DHMIOYRGIA ANTIKEIMENOY Date

  cout << endl << "The NUMBER of the AUTHORS that worked for the Book: ";
  cin >> CurrentNOFAuthors;
  //KANOYME TON DEIKTH Authors NA DEIXNEI SE ENA NEO PINAKA MEGETHOYS [NOFAuthors]
  Author * Authors = new Author[CurrentNOFAuthors];
  file.open( "Authors.file", ios::out | ios::app | ios::binary );
  /* DHLONETAI H METAVLHTH POY THA KRATAEI TON KODIKO TOY EPOMENOY SYGGRAFEA
  KAI ARXIKOPOIEITAI ME THN TIMH TOY PLHTHOYS TON SYGGRAFEON POY EXOYN
  EISAXTHEI OS TORA */
  int NextAuthor = _NOFAuthors;
  //EISAGOGH TON STOIXEION TON SYGGRAFEON STON PINAKA
  for ( i = 0; i < CurrentNOFAuthors; i++ )
  {
    //TO NextAuthor PERIEXEI TORA TO SOSTO KODIKO TOY EPOMENOY SYGGRAFEA POY THA EISAXTHEI
    NextAuthor++;
    cout << endl << endl << "AUTHOR INFORMATION:";
    //O KODIKOS SYGGRAFEA EISAGETAI AYTOMATA
    cout << endl << endl << "This Author will be assigned the CODE: "
         << NextAuthor;
    //ZHTOYME TIS YPOLOIPES PLHROFORIES APO TON XRHSTH
    cout << endl << endl << "Please Give us: " << endl;
    cout << "------ ---- --" << endl;
    cout << endl << "The NAME of the Author: ";
    fflush( stdin );
    cin >> Name;
    cout << endl << "The SURNAME of the Author: ";
    fflush( stdin );
    cin >> Surname;
    //KATASKEYAZOYME ENA PROSORINO ANTIKEIMENO TYPOY Author ME TIS PLHROFORIES AYTES
    Author Temp( NextAuthor, Name, Surname );
    //TO KATAXOROYME STON PROSORINO PINAKA Authors
    Authors[i] = Temp;
    //KATAXOROYME TO NEO ANTIKEIMENO - SYGGRAFEA STO ARXEIO
    file.write( ( char * ) & Temp, sizeof( Author ) );
  }
  //KLEINOYME TO ARXEIO
  file.close();

  /* PREPEI NA ALLAKSOYME TON PINAKA _Authors OSTE NA PERIEXEI KAI THN NEA (H
  TIS NEES EGGRAFES. */

  //ARXIKA YPOLOGIZOYME TO MEGETHOYS POY THA PREPEI NA EXEI O TELIKOS MAS PINAKAS
  unsigned int NewSize = _NOFAuthors + CurrentNOFAuthors;
  /* KAI KANOYME ENAN PROSORINO DEIKTH SE PINAKA ANTIKEIMENON TYPOY Author NA
  DEIXNEI SE ENAN NEO PINAKA MEGETHOUS [NewSize] */
  Author * AuthorsAtLast = new Author[NewSize];

  /* ME AYTO TO LOOP KATAXOROYME STON PINAKA AuthorsAtLast TOYS SYGGRAFEIS POY
  EIXAME PRIN THN KATAXORHSH TON NEON */
  i = 0;
  while ( i != _NOFAuthors )
  {
    AuthorsAtLast[i] = _Authors[i];
    i++;
  }

  /* ME AYTO TO LOOP KATAXOROYME TOYS NEOYS (H TON NEO SYGGRAFEA) */
  i = 0;
  while ( i != CurrentNOFAuthors )
  {
    /* KSEKINAME NA KATAXOROUME APO TH THESH _NOFAuthors GIATI H ARITHMISH TOY
    PINAKA KSEKINAEI APO TO 0 */
    AuthorsAtLast[_NOFAuthors] = Authors[i];
    _NOFAuthors++;
    i++;
  }

  /* ENHMERONOYME TA PROSOPIKO MELH THS KLASHS KANONTAS TO _Authors NA
  DEIXNEI EKEI POY DEIXNEI O DEIKTHS AuthorsAtLast KAI KATAXORONTAS STO
  _NOFAuthors THN TIMH NewSize  */
  _Authors = AuthorsAtLast;
  _NOFAuthors = NewSize;

  //DHMIOYRGOYME ENA PROSORINO ANTIKEIMENO TYPOY Book
  Book Temp( TitleCode, Title, CurrentNOFAuthors, Authors, Description,
       PublishingFirm, DOPublish );

  //TO EGGRAFOYME STO ANTISTOIXO ARXEIO
  file.open( "Books.file", ios::out | ios::app | ios::binary );
  file.write( ( char * ) & Temp, sizeof( Book ) );
  file.close();

  //PREPEI NA ALLAKSOYME TON PINAKA _Books OSTE NA PERIEXEI KAI THN NEA EGGRAFH.

  //VRISKOYME TO MEGETHOS TOY NEOY PINAKA PROSTHETONTAS 1 STO PALIO MEGETHOS
  NewSize = ++_NOFBooks;
  /* KANOYME ENA PROSORINO DEIKTH SE PINAKA ANTIKEIMENON TYPOY Book NA DEIXNEI
  SE ENAN NEO PINAKA ME TO EPITHIMITO NEO MEGETHOS */
  Book * Books = new Book[NewSize];

  /* STH SYNEXEIA ENHMERONOYME TON NEO PINAKA TOPOTHETONTAS SE AYTON PALIES
  KAI NEES EGGRAFES */

  /* MEIONOYME TO NEO MEGETHOS KATA 1 GIA NA MPOROUME NA XEIRISTOYME TIS
  THESEIS TOY PINAKA POY KSEKINOYN APO 0 */
  NewSize--;

  //EISAGOYME ME TO PARAKATO LOOP TIS PALIES EGGRAFES
  for ( i = 0; i < NewSize; i++ )
  {
    Books[i] = _Books[i];
  }
  /* KAI TELOS EISAGOYME THN KAINOYRIA EGGRAFH STHN TELEYTAIA THESH TOY PINAKA
  (H TELEYTAIA EGGRAFH EISAGETAI EKTOS TOY LOOP GIATI SE PERIPTOSH POY  O
  PINAKAS EINAI KENOS KAI ARXISEI TORA H EISAGOGH STOIXEION TO PROGRAMMA DEN
  THA KATAFEREI NA EISERTHEI STO LOOP AFOU TO NewSize THA EINAI 0 KAI
  ARA ISO ME TO i*/
  Books[NewSize] = Temp;

  //ENHMERONETAI TO PROSOPIKO MELOS THS KLASHS IOHANDLER
  _Books = Books;
}

void IOHandler::InsertCopy()
{
  fstream file; //DIAXEIRISTHS ARXEIOY
  unsigned int i, maxCode = 1; //METRHTES

  unsigned int TitleCode; //KODIKOS TITLOY (POIOY VIVLIOY DHLADH APOTELEI ANTITYPO)
  unsigned int CopyCode; //KODIKOS ANTITYPOY
  float Value; //KOSTOS
  char ISBN[30]; //ARITHMOS ISBN

  //SYLLOGH STOIXEION APOTO XRHSTH
  cout << endl << endl << "COPY INFORMATIONS";
  cout << endl << endl << "Please Give us: ";
  cout << endl << "------ ---- --";
  /* O KODIKOS TITLOY ANAFERETAI STO VIVLIO TOY OPOIOY EINAI ANTITYPO TO
  PARON. ETSI DEN EINAI STANDARD KAI DEN MPOROYME NA TON BROYME AYTOMATA */
  cout << endl << endl << "The CODE of the Book of which this is a COPY: ";
  cin >> TitleCode;
  /* O KODIKOS ANTITYPOY APO THN ALLH EINAI MONADIKOS GIA TA ANTITYPA KAI THN
  SYGKEKRIMENH YLOPOIHSH APOTELEI AYKSONTA ARITHMO TON ANTITYPON POY ANHKOYN
  STO IDIO BIBLIO. ETSI TO PARAKATO LOOP PSAXNEI TO PLHTHOS TON ANTITYPON POY
  EXOYN KODIKO TITLOY TON TitleCode KAI AYKSANEI TON Counter (O OPOIOS
  ARXIKOPOIEITAI ME 1 GIA THN PERIPTOSH POY MILOYME GIA TO
  MONADIKO ANTITYPO) */
  for ( i = 0; i < _NOFCopies; i++ )
  {
    if ( _Copies[i].getTitleCode() == TitleCode
         && _Copies[i].getCopyCode() > maxCode )
           maxCode = _Copies[i].getCopyCode();
  }
  cout << endl << endl << "This Copy will be assigned COPY CODE: " << maxCode;
  CopyCode = maxCode + 1;
  //PAIRNOUME TA YPOLOIPA STOIXEIA APO TON XRHSTH
  cout << endl << endl << "Give the VALUE of this Copy: ";
  cin >> Value;
  cout << endl << "Give the ISBN CODE: ";
  fflush( stdin );
  cin >> ISBN;
  //DHMIOYRGOYME ENA PROSORINO ANTIKEIMENO ME TA PARAPANO STOIXEIA
  Copy Temp( TitleCode, CopyCode, Value, ISBN );
  //EGGRAFOYME TO ANTIKEIMENO AYTO STO KATALLHLO ARXEIO
  file.open( "Copies.file", ios::out | ios::app | ios::binary );
  file.write( ( char * ) & Temp, sizeof( Copy ) );
  file.close();

  //PREPEI NA ALLAKSOYME TON PINAKA _Copies OSTE NA PERIEXEI KAI THN NEA EGGRAFH

  //ARXIKA YPOLOGIZOYME TO NEO MEGETHOS AUKSANONTAS KATA 1 TO PALIO MEGETHOS
  unsigned int NewSize = ++_NOFCopies;
  //DHMIOYRGOUME ENA DEIKTH SE PINAKA ANTIKEIMENON TYPOY Copy MEGETHOUS NewSize
  Copy * Copies = new Copy[NewSize];

  /* STH SYNEXEIA ENHMERONOYME TON NEO PINAKA TOPOTHETONTAS SE AYTON PALIES
  KAI NEES EGGRAFES */

  /* MEIONOYME TO NEO MEGETHOS KATA 1 GIA NA MPOROUME NA XEIRISTOYME TIS
  THESEIS TOY PINAKA POY KSEKINOYN APO 0 */
  NewSize--;
  //EISAGOYME ME TO PARAKATO LOOP TIS PALIES EGGRAFES
  for ( i = 0; i < NewSize; i++ )
  {
    Copies[i] = _Copies[i];
  }
  /* KAI TELOS EISAGOYME THN KAINOYRIA EGGRAFH STHN TELEYTAIA THESH TOY PINAKA
  (H TELEYTAIA EGGRAFH EISAGETAI EKTOS TOY LOOP GIATI SE PERIPTOSH POY  O
  PINAKAS EINAI KENOS KAI ARXISEI TORA H EISAGOGH STOIXEION TO PROGRAMMA DEN
  THA KATAFEREI NA EISERTHEI STO LOOP AFOU TO NewSize THA EINAI 0 KAI
  ARA ISO ME TO i*/
  Copies[NewSize] = Temp;
  //ENHMERONETAI TO PROSOPIKO MELOS THS KLASHS IOHANDLER
  _Copies = Copies;
}

void IOHandler::InsertMember()
{
  fstream file; //DIAXEIRISTHS ARXEIOY
  unsigned int i; //METRHTES

  unsigned int MemberCode; //KODIKOS MELOYS
  char Name[30]; //ONOMA
  char Surname[30]; //EPITHETO
  char Address[50]; //DIEYTHYNSH
  char PhoneNumber[30]; //THLEFONO

  /* O KODIKOS MELOYS EISAGETAI AYTOMATA THA EINAI OSO TO TREXON PLHTHOS TON
  MELON + 1. AYTOS O ARITHMOS THA APOTELEI EPISHS KAI TO NEO MEGETHOS TOY
  PINAKA POY THA PEREPEI NA ENHMEROSOUME META THN EISAGOGH TOY NEOY MELOYS */
  MemberCode = _NOFMembers + 1;
  //SYLLEGOUME TA APARAITHTA STOIXEIA APO TON XRHSTH
  cout << endl << endl << "MEMBER INFORMATIONS";
  cout << endl << endl << "This Member will be assigned the CODE: "
       << MemberCode;
  cout << endl << endl << "Please Give us: " << endl;
  cout << "------ ---- --" << endl;
  cout << endl << "The NAME of the Member: ";
  fflush( stdin );
  cin >> Name;
  cout << endl << "The SURNAME of the Member: ";
  fflush( stdin );
  cin >> Surname;
  cout << endl << "The ADDRESS of the Member: ";
  fflush( stdin );
  cin.getline( Address, 50 );
  cout << endl << "The PHONE NUMBER of the Member: ";
  fflush( stdin );
  cin >> PhoneNumber;

  /* DHMIOYRGOUME ENAN PROSORINO DEIKTH SE ANTIKEIMENA TYPOY MEMBER KAI TON
  KANOYME NA DEIXNEI SE ENA NEO PINAKA MEGETHOUS MemberCode */
  Member * Members = new Member[MemberCode];

  //DHMIOYRGOUME ENA PROSORINO ANTIKEIMENO TYPOY Member ME TA PARAPANO STOIXEIA
  Member Temp( MemberCode, Name, Surname, Address, PhoneNumber );

  //GRAFOUME TO NEO ANTIKEIMENO STO ARXEIO
  file.open( "Members.file", ios::out | ios::app | ios::binary );
  file.write( ( char * ) & Temp, sizeof( Member ) );
  file.close();

  //GRAFOUME ME TO PARAKATO LOOP STON NEO PINAKA Members OLES TIS PALIES EGGRAFES
  for ( i = 0; i < _NOFMembers; i++ )
  {
    Members[i] = _Members[i];
  }
  //EISAGOUME KAI THN KAINOURIA STHN TELEUTAIA THESH
  Members[_NOFMembers++] = Temp;
  //ENHMERONOUME TO PROSOPIKO MELOS THS IOHANDLER
  _Members = Members;

}

void IOHandler::DeleteAllCopies( unsigned int TitleCode )
{
  fstream file;
  unsigned int i = 0; //METRHTHS
  unsigned int VictimsCode; //KODIKOS ANTITYPOY PROS DIAGRAFH
  /* TO PARAKATO LOOP PSAXNEI GIA ANTITYPA ME KODIKO TITLOY AYTON TOY
  ORISMATOS KAI TA DIAGRAFEI ENA ENA XRHSIMOPOIONTAS THN DELETE COPY */
  for ( i = 0; i < _NOFCopies; i++ )
  {
    if ( _Copies[i].getTitleCode() == TitleCode )
    {
      VictimsCode = _Copies[i].getCopyCode();
      DeleteCopy( TitleCode, VictimsCode );
    }
  }
  /* TO LOOP AYTO VRISKEI KAI DIAGRAFEI TO VIVLIO APO TON PINAKA _Books
  (AFOTOY EXOYN DIAGRAFEI PRIN OLA TOY TA ANTITYPA) */
  for ( i = 0; i < _NOFBooks; i++ )
  {
    if ( _Books[i].getTitleCode() == TitleCode ) break;
  }
  if ( i == _NOFBooks && _Books[i].getTitleCode() != TitleCode )
  {
    cout << endl << "The book does not exist !!!" << endl;
    return;
  }
  //DHMIOYRGEI TO KATALLHLA PLEON DIAMORFOMENO PINAKA
  Book * Books = new Book[_NOFBooks - 1];
  _Books[i] = _Books[_NOFBooks - 1];
  _NOFBooks--;
  //KAI TOY APOTHETEI TIS SOSTES PLHROFORIES
  for ( i = 0; i < _NOFBooks; i++ )
  {
    Books[i] = _Books[i];
  }
  delete[] _Books;
  _Books = Books;
  //KATOPIN EGGRAFEI TO KAINOYRIO SOSTO ARXEIO
  file.open( "Books.file", ios::out | ios::binary | ios::trunc );
  file.write( ( char * ) _Books, sizeof( Book ) * _NOFBooks );
  file.close();
}

void IOHandler::DeleteCopy( unsigned int TitleCode, unsigned int VictimsCode )
{
  /* TO i APOTELEI TO GNOSTO METRHTH TON LOOPS ENO TO Position KRATAEI TH
  THESH TOY PROS DIAGRAFH STOIXEIOY */
  unsigned int i, j, Position = -1;
  fstream file; //DIAXEIRISTHS ARXEIOY
  //VRISKEI TH THESH TOY PROS DIAGRAFH STOIXEIOY STON PINAKA _Copies[]
  for ( i = 0; i < _NOFCopies; i++ )
  {
    if ( ( _Copies[i].getTitleCode() == TitleCode )
         && ( _Copies[i].getCopyCode() == VictimsCode ) ) Position = i;
  }

  //AN DEN YPARXEI TO STOIXEIO PROS DIAGRAFH TYPONEI ANTISTOIXO MHNYMA KAI EPISTREFEI
  if ( Position == -1 )
  {
    cout << "The element you try to delete does not exist";
    return;
  }

  //TO NEO MEGETHOS TOY PINAKA THA EINAI KATA 1 MIKROTERO
  unsigned int NewSize = _NOFCopies - 1;
  //PROSORINOS DEIKTHS SE PINAKA ANTIKEIMENON TYPOY Copy MEGETHOUS NewSize
  Copy * Copies = new Copy[NewSize];
  //EGGRAFH TON STOIXEION PRIN AYTOY POY PROKEITAI NA DIAGRAFEI
  for ( i = 0; i < Position; i++ )
  {
    Copies[i] = _Copies[i];
  }
  //EGGRAFH TON STOIXEION POY VRISKONTAI META APO TO PROS DIAGRAFH
  Position++;
  for ( j = Position; j < _NOFCopies; j++ )
  {
    Copies[i] = _Copies[j];
    i++;
  }
  //ENHMEROSH TON PROSOPIKON MELON THS KLASHS IOHANDLER
  delete[] _Copies;
  _Copies = Copies;
  _NOFCopies--;

  //EGGRAFH TOY KAINOYRIOY PINAKA STO ARXEIO
  file.open( "Copies.file", ios::out | ios::trunc | ios::binary );

  file.write( ( char * ) _Copies, _NOFCopies * sizeof( Copy ) );

  file.close();
}

void IOHandler::BorrowBook()
{
  fstream file; //DIAXEIRISTHS ARXEIOY
  unsigned int i, j; //METRHTHS

  unsigned int Year;
  Months Month;
  unsigned int Day;

  unsigned int CopyCode; //PROSORINH METSVLITH GIA TON KODIKO ANTITYPOY
  unsigned int MemberCode;
  unsigned int TitleCode;
  Date DOBorrow;
  DOBorrow.setDefaultDate();

  //SYLLEGOUME TA APARAITHTA STOIXEIA APO TON XRHSTH
  cout << endl << endl << "BORROW INFORMATIONS";
  cout << endl << endl << "Please Give us: " << endl;
  cout << "------ ---- --" << endl;
  cout << endl << "The CODE of the Member: ";
  fflush( stdin );
  cin >> MemberCode;
  cout << endl << "The CODE of the Book: ";
  fflush( stdin );
  cin >> TitleCode;


  /* TO PARAKATO LOOP PSAXNEI NA VREI DIATHESIMA ANTITYPA ME KODIKO
  TITLOY TON DOSMENO. MOLIS VREI TO PROTO DIATHESIMO STAMATA */
  for ( i = 0; i < _NOFCopies; i++ )
  {
    if ( ( _Copies[i].getTitleCode() == TitleCode )
         && ( !_Copies[i].IsBorrowed() )
         && ( ( !_Copies[i].IsBooked() )
         || _Copies[i].MemberBooked() == MemberCode ) )
         {
           CopyCode = _Copies[i].getCopyCode();
           if ( _Copies[i].IsBooked() )
           {
             _Copies[i].MemberBook( 0 );
             for ( i = 0; i < _NOFMembers; i++ )
             {
               if ( _Members[i].getMemberCode() == MemberCode )
                 _Members[i].unBook();
             }
           }
           //
           _Copies[i].MemberBorrow( MemberCode );
           break;
    }
  }
  if ( i == _NOFCopies )
  {
    char choice;
    cout << endl << endl << "No copy of ( " << TitleCode
         << " ) Title code is availiable";
    cout << endl << endl << "Do you wish to book it (y/n): ";
    choice = getche();
    if ( choice == 'y' || choice == 'Y' ) BookBook( TitleCode, MemberCode );
    return;
  }
  cout << endl << endl << "You will borrow the Copy with code: " << CopyCode;


  cout << endl << endl << "Finally give the date: ";

  cout << endl << endl << "Year: ";
  cin >> Year;
  cout << endl << "Month: ";
  cin >> j;

  //Loop METATROPHS AKERAIOY SE Month
  i = 1;
  Month = Jan;
  while ( i != j )
  {
    i++;
    Month++;
  }

  cout << endl << "Day: ";
  cin >> Day;

  DOBorrow = Date( Day, Month, Year );

  //DHMIOYRGOUME TO ANTIKEIMENO LOG ME TA PARAPANO STOIXEIA
  file.open( "Copies.file", ios::out | ios::binary | ios::trunc );
  file.write( ( char * ) _Copies, sizeof( Copy ) * _NOFCopies );
  file.close();

}

void IOHandler::BookBook( unsigned int TitleCode, unsigned int MemberCode )
{
  fstream file; //DIAXEIRISTHS ARXEIOY
  unsigned int i, j; //METRHTES
  //PSAXNEI STON PINAKA MELON GIA TO MELOS POY DEXETAI SAN ORISMA
  for ( i = 0; i < _NOFMembers; i++ )
  {
    //AN TO MELOS VRETHEI
    if ( _Members[i].getMemberCode() == MemberCode )
    {
      //AN TO MELOS AYTO EXEI HDH KANEI KRATHSH (DEN MPOREI DEYTERH)
      if ( _Members[i].HasAlreadyBooked() )
      {
        //TYPONEI TO SOSTO MHNYMA
        cout << endl << endl << "You alteady have booked a book";
        return;
      }
      //TO NOIKIAZEI (ENERGOPOIEI MIA BOOL METAVLHTH)
      _Members[i].Book();
      break;
    }
  }
  //PSAXNEI TO EPOMENO ELEYTHERO ANTITYPO ME TITLE CODE AYTO TOY ORISMATOS
  for ( i = 0; i < _NOFCopies; i++ )
  {
    if ( _Copies[i].getTitleCode() == TitleCode )
    {
      //MOLIS TO VREI TO NOIKIAZEI (ALLAZEI TO ANTISTOIXO DEDOMENO STO ANTITYPO
      _Copies[i].MemberBook( MemberCode );
      cout << endl << "Succesful booking" << endl;
      //EGGRAFH TO ALLAGMENO PLEON PINAKA STO ARXEIO
      file.open( "Copies.file", ios::out | ios::binary | ios::trunc );
      file.write( ( char * ) _Copies, sizeof( Copy ) * _NOFCopies );
      file.close();
      return;
    }
  }
}


void IOHandler::ReturnBook()
{
  unsigned int TitleCode; //KODIKOS TITLOY
  unsigned int CopyCode; //KODIKOS ANTITYPOY
  unsigned int MemberCode; //MEMBER CODE
  unsigned int i, j; //METRHTES
  fstream file; //DIAXEIRISTHS ARXEIOY

  //SYLLEGOUME TA APARAITHTA STOIXEIA APO TON XRHSTH
  cout << endl << endl << "BORROW INFORMATIONS";
  cout << endl << endl << "Please Give us: " << endl;
  cout << "------ ---- --" << endl;
  cout << endl << "Give the Title Code: ";
  cin >> TitleCode;
  cout << endl << "Give the Copy Code: ";
  cin >> CopyCode;
  cout << endl << "Give the member Code: ";
  cin >> MemberCode;

  //PSAXNEI TO MELOS ME TON DOTHENTA KODIKO MELOYS
  for ( i = 0; i < _NOFMembers; i++ )
  {
    if ( _Members[i].getMemberCode() == MemberCode ) break;
  }
  //AN DEN TO VREI ENHMERONEI TO XRHSTH + EPISTREFEI
  if ( i == _NOFMembers && _Members[i].getMemberCode() != MemberCode )
  {
    cout << endl << endl << "The member was not found!! " << endl << endl;
    return;
  }
  //AN TO VREI PSAXNEI NA VREI POY STON PINAKA EINAI TO ANTITYPO
  for ( j = 0; j < _NOFCopies; j++ )
  {
    if ( _Copies[j].getTitleCode() == TitleCode
         && _Copies[j].getCopyCode() == CopyCode )break;
  }
  /* AN EIMASTE STO TELEYTAIO STOIXEIO TOY PINAKA KAI DEN EINAI TO EPITHIMITO
  ANTITYPO EKTYPONETAI SXETIKO MHNYMA */
  if ( j == _NOFCopies
       && ( _Copies[j].getTitleCode() != TitleCode
       || _Copies[j].getCopyCode() != CopyCode ) )
       {
         cout << endl << endl << "The copy was not found!! " << endl << endl;
         return;
  }
  //ELEGXEI AN TO ANTITYPO ONTOS DANEISTIKE STO MELOS AYTO
  if ( _Copies[j].MemberBorrowed() != MemberCode )
  {
    cout << endl << endl << "The copy was not borrowed to this member!! "
         << endl << endl;
    return;
  }
  //EPISTROFH TOY ANTITYPOY
  _Copies[j].Returned();
  //AN EINAI KRATHMENO EIDOPOIHSH TOY ENDIAFEROMENOY
  if ( _Copies[j].IsBooked() )
  {
    cout << endl << "Please tell the member with "
         << _Copies[j].MemberBooked() << "code to come and get his Copy";
  }
  //EGGRAFH TON ALLAGON STO ANTISTOIXO ARXEIO
  file.open( "Copies.file", ios::out | ios::binary | ios::trunc );
  file.write( ( char * ) _Copies, sizeof( Copy ) * _NOFCopies );
  file.close();

}


void IOHandler::Search()
{
  char choice;
  unsigned int TitleCode, CopyCode, MemberCode;
  cout << endl << "SEARCH INFORMATION";
  cout << endl << endl << "Choose Between 1 and 2: ";
  cout << endl << "------ ------- - --- -- ";
  cout << endl << endl;
  do
  {
    cout << "1.Search for a copy." << endl;
    cout << "2.Search for a member." << endl;
    cout << "3.Exit" << endl;

    choice = getche();

    switch ( choice )
    {
      case '1':
        cout << endl << "Please give as the Title Code: ";
        cin >> TitleCode;
        cout << endl << "Please give us the Copy Code: ";
        cin >> CopyCode;
        SearchCopy( TitleCode, CopyCode );
      break;
      case '2':
        cout << endl << "Please give us the Member Code: ";
        cin >> CopyCode;
        SearchMember( MemberCode );
      break;
      case '3':
      break;
      default:
        clrscr();
        cout << endl << "Wrong Input!!!Please choose a number between 1 and 2 "
             << endl << endl;
    }
  }
  while ( choice != '3' );
}


void IOHandler::SearchCopy( unsigned int TitleCode, unsigned int CopyCode )
{
  //PSAXNEI TO EPITHYMHTO ANTITYPO
  for ( unsigned int i = 0; i < _NOFCopies; i++ )
  {
    //AN TO VREI
    if ( _Copies[i].getTitleCode() == TitleCode
         && _Copies[i].getCopyCode() == CopyCode )
         {
           //AN DEN EINAI NOIKIASMENO H KRATHMENO TYPONEI ANTISTOIXO MHNYMA
           if ( !_Copies[i].MemberBorrowed() && !_Copies[i].IsBooked() )
           {
             cout << endl << "The book is free" << endl;
             return;
           }
           //AN EINAI DANEISMENO
           if ( _Copies[i].MemberBorrowed() )
           {
             cout << endl << "The book is borrowed to "
                  << _Copies[i].MemberBorrowed() << endl;
           }
           //AN EINAI KRATHMENO
           if ( _Copies[i].IsBooked() )
           {
             cout << endl << " The book is booked to "
                  << _Copies[i].MemberBooked() << endl;
           }

           return;
    }
  }
  cout << endl << "The book was not found " << endl;
}

void IOHandler::SearchMember( unsigned int MemberCode )
{
  //PSAXNEI TO ANTITYPO POY EXEI PLHROFORIA GIA TO MELOS POY MAS ENDIAFEREI
  for ( unsigned int i = 0; i < _NOFCopies; i++ )
  {
    //EPISTROFH TON PLHROFORION (AN TIS VREI)
    if ( _Copies[i].MemberBorrowed() == MemberCode )
    {
      cout << endl << "The Member has borrowed the Title with title code "
           << _Copies[i].getTitleCode() << " and with copy code "
           << _Copies[i].getCopyCode();
    }
    if ( _Copies[i].MemberBooked() == MemberCode )
    {
      cout << " The Member has booked the Book with Title Code "
           << _Copies[i].getTitleCode() << " and with Copy Code "
           << _Copies[i].getCopyCode();

    }
  }
}
