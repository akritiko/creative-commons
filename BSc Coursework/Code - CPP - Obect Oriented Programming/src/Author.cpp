#include <string.h>
#include "./Author.h"

//KENOS DHMIOYRGOS
Author::Author()
{

}

//DHMIOYRGOS ME ORISMATA
Author::Author( unsigned int AuthorCode, char Name[], char Surname[] )
{
  _AuthorCode = AuthorCode;
  strcpy(_Name, Name);
  strcpy(_Surname, Surname);
}

unsigned int Author::getAuthorCode()
{
  return _AuthorCode;
}

char * Author::getName()
{
  return _Name;
}

char * Author::getSurname()
{
  return _Surname;
}

void Author::setAuthorCode( unsigned int RepairedCode)
{
  _AuthorCode = RepairedCode;
}

void Author::setName( char RepairedName[] )
{
  strcpy(_Name,RepairedName);
}

void Author::setSurname( char RepairedSurname[] )
{
  strcpy(_Surname,RepairedSurname);
}


