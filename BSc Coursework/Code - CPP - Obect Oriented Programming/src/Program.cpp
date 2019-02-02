#include <fstream.h>
#include "./IOHandler.cpp"

/* H MAIN DIAXEIRIZETAI TO KENTRIKO MENOY. EXEI DHLOTHEI SE AYTH ENA
ANTIKEIMENO TYPOY IOHANDLER TO OPOIO KAI DIAXEIRIZETAI OLES TIS EPILOGES TOY
KENTRIKOY MENOY*/

main()
{
  char choice;
  IOHandler Library;
  clrscr();
  do
  {
    cout << "Main Menu" << endl;
    cout << "---------" << endl;
    cout << "1.Insert Book" << endl;
    cout << "2.Insert Copy" << endl;
    cout << "3.Insert Member" << endl;
    cout << "4.Delete Book" << endl;
    cout << "5.Delete Copy" << endl;
    cout << "6.Borrow Book" << endl;
    cout << "7.Return Book" << endl;
    cout << "8.Exit" << endl;
    cout << "Choose (1 - 8): ";
    choice = getche();
    cout << endl << endl;

    switch ( choice )
    {
      case '1':
        Library.InsertBook();
        clrscr();
      break;
      case '2':
        Library.InsertCopy();
        clrscr();
      break;
      case '3':
        Library.InsertMember();
        clrscr();
      break;
      case '4':
        clrscr();
        unsigned int TitleCode;
        cout << endl << endl
             << "Give us the Title of the book you wish to remove: ";
        Library.DeleteAllCopies( TitleCode );
      break;
      case '5':
        clrscr();
        unsigned int CopyCode;
        cout << endl << endl
             << "Give us the Title of the book you wish to remove: ";
        cout << endl << "Give us the Copy Code: ";
        Library.DeleteCopy( TitleCode, CopyCode );
      break;
      case '6':
        Library.BorrowBook();
        clrscr();
      break;
      case '7':
        Library.ReturnBook();
        clrscr();
      break;
      case '8':
      break;
      default:
        clrscr();
        cout << endl << "Wrong Input!!!Please choose a number between 1 and 5 "
             << endl << endl;
    }
  }
  while ( choice != '8' );
}

