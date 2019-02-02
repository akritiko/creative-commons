#include <iostream.h>
#include <string.h>
#include "./Member.h"

//KENOS DHMIOYRGOS
Member::Member()
{
  HasBooked = 0;
}

//DHMIOYRGOS ME ORISMATA
Member::Member( unsigned int MemberCode, char Name[], char Surname[],
     char Address[], char PhoneNumber[] )
     {

       _MemberCode = MemberCode;
       strcpy( _Name, Name );
       strcpy( _Surname, Surname );
       strcpy( _Address, Address );
       strcpy( _PhoneNumber, PhoneNumber );
       HasBooked = 0;
}

void Member::Book()
{
  HasBooked = 1;
}

void Member::unBook()
{
  HasBooked = 0;
}

bool Member::HasAlreadyBooked()
{
  return HasBooked;
}

unsigned int Member::getMemberCode()
{
  return _MemberCode;
}

char * Member::getName()
{
  return _Name;
}

char * Member::getSurname()
{
  return _Surname;
}

char * Member::getAddress()
{
  return _Address;
}

char * Member::getPhoneNumber()
{
  return _PhoneNumber;
}

void Member::setMemberCode( unsigned NewCode )
{
  _MemberCode = NewCode;
}

void Member::setName( char NewName[] )
{
  strcpy( _Name, NewName );
}

void Member::setSurname( char NewSurname[] )
{
  strcpy( _Surname, NewSurname );
}

void Member::setAddress( char NewAddress[] )
{
  strcpy( _Address, NewAddress );
}

void Member::setPhoneNumber( char NewNumber[] )
{
  strcpy( _PhoneNumber, NewNumber );
}
