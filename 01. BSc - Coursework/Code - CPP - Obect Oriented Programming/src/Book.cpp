#include "./Book.h"

//O KENOS DHMIOYRGOS
Book::Book()
{

}

//DHMIOYRGOS ME ORISMATA
Book::Book( unsigned int TitleCode, char Title[], unsigned int NOFAuthors,
     Author * Authors, char Description[], char PublishingFirm[],
     Date DOPublish )
     {
       _TitleCode = TitleCode;
       strcpy( _Title, Title );
       _NOFAuthors = NOFAuthors;
       strcpy( _Description, Description );
       strcpy( _PublishingFirm, PublishingFirm );
       _DOPublish = DOPublish;
      //GEMIZEI TON PINAKA _Authors
       unsigned int i;
       for ( i = 0; i < NOFAuthors; i++ )
       {
         _Authors[i] = Authors[i];
       }
}

unsigned int Book::getTitleCode()
{
  return _TitleCode;
}

char * Book::getTitle()
{
  return _Title;
}

unsigned int Book::getNOFAuthors()
{
  return _NOFAuthors;
}

//EPITREFEI TOYS SYGGRAFEIS TOY VIVLIOY SE MORFH:
//NAME(1) SURNAME(1),
//NAME(2) SURNAME(2),
//... ... ...
//NAME(_NOFAuthors) SURNAME(_NOFAuthors)
void Book::getAuthors()
{
  unsigned int i;
  cout << "Authors: " << endl;

  for ( i = 0; i < _NOFAuthors; i++ )
  {
    cout << _Authors[i].getSurname() << " " << _Authors[i].getName();
    if ( ++i != _NOFAuthors )
    {
      cout << ", " << endl;
      i--;
    }
  }
}

char * Book::getDescription()
{
  return _Description;
}

char * Book::getPublishingFirm()
{
  return _PublishingFirm;
}

void Book::getDOPublish()
{
  _DOPublish.getDate();
}
