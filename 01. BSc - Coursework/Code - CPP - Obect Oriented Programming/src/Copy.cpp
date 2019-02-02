#include "./Copy.h"

//KENOS DHMIOYRGOS
Copy::Copy()
{
  _MembersCodeBorrowed = 0;
}

//DHMIOYRGOS ME ORISMATA
Copy::Copy( unsigned int TitleCode, unsigned int CopyCode,
     float Value, char ISBN[] )
     {
       _TitleCode = TitleCode;
       _CopyCode = CopyCode;
       _Value = Value;
       strcpy( _ISBN, ISBN );

       _DOBorrow.setDefaultDate();
       _DOReturn.setDefaultDate();

       _MembersCodeBorrowed = 0;
       _MembersCodeBook = 0;
}

unsigned int Copy::getCopyCode()
{
  return _CopyCode;
}

float Copy::getValue()
{
  return _Value;
}

char * Copy::getISBN()
{
  return _ISBN;
}

void Copy::getDOBorrow()
{
  _DOBorrow.getDate();
}

void Copy::getDOReturn()
{
  _DOReturn.getDate();
}

/* H SYNARTHSH AYTH DEXETAI SAN ORISMA MIA HMEROMHNIA (ANTIKEIMENO TYPOY DATE)
KAI THN KATHISTA HMEROMHNIA DANEISMOY ENO AYTOMATA YPOLOGIZEI KAI THN
HMEROMHNIA EPISTROFHS (KATA SYMVASH META APO 14 MERES). H KLASH Date
DHMIOYRGHTHIKE KATA BASHN GIA NA EKSYPHRETEI AYTH THN KLASH */
Date Copy::setBorrowAndReturn( Date DOBorrow )
{
  _DOBorrow = DOBorrow;
  Date Temp( DOBorrow.getDay() + 14, DOBorrow.getMonth(), DOBorrow.getYear() );
  _DOReturn = Temp;
  return _DOReturn;
}

void Copy::MemberBorrow( unsigned int MembersCodeBorrowed )
{
  _MembersCodeBorrowed = MembersCodeBorrowed;
}

void Copy::MemberBook( unsigned int MembersCodeBook )
{
  _MembersCodeBook = MembersCodeBook;
}

bool Copy::IsBooked()
{
  return _MembersCodeBook != 0;
}

bool Copy::IsBorrowed()
{
  return _MembersCodeBorrowed != 0;
}

unsigned int Copy::MemberBooked()
{
  return _MembersCodeBook;
}

unsigned int Copy::MemberBorrowed()
{
  return _MembersCodeBorrowed;
}

void Copy::Returned()
{
  _DOBorrow.setDefaultDate();
  _DOReturn.setDefaultDate();
  _MembersCodeBorrowed = 0;
}
