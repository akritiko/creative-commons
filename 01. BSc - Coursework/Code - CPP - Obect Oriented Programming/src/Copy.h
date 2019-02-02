/* H XRHSH TOY PARAKATO BLOCK KODIKA - #ifndef ... #define ... #include ...
#endif GINETAI GIA NA APOFYGOYME SFALMATA POLLAPLHS DHLOSHS MIAS KLASHS */

#ifndef FileBook
  #define FileBook
  #include "./Book.h"
#endif

/* DEXOMAI SAN SYMVASH OTI TO MELOS MPOREI NA KRATHSEI TO H TA ANTITYPA GIA 14
TO POLY MERES */

#define MaxDayz 14

/* H KLASH Copy KLHRONOMEI APO THN KLASH Book TON KODIKO TITLOY KAI AYTO GIATI
THELOYME TA ANTITYPA NA ORIZONTAI MONOSHMANTA APO TO ZEYGARI (KODIKOS BIBLIOY,
KODIKOS ANTITYPOY). KLHRONOMONTAS LOIPON TO SYGKKRIMENO STOIXEIO THS,
KLHRONOMEI KAI OLES THS METHODOYS THS POY EINAI Public STHN KLASH Book  ( P.X:
getTitleCode() ). EPISHS KLHRODOTEI KAPOIA APO TA STOIXEIA THS
STHN KLASH Log */

class Copy : public Book
{
private:
  float _Value; //KOSTOS AGORAS
  char _ISBN[13]; //ARITHMOS EKDOSHS
  unsigned int _MembersCodeBorrowed;
  unsigned int _MembersCodeBook;
  unsigned int _CopyCode; //ARITHMOS ANTITYPOY
  Date _DOBorrow; //HMEROMHNIA DANEISMOY (DateOfBorrow)
  Date _DOReturn; //HMEROMHNIA EPISTROFHS (DateOfReturn)

public:
  //OI DHMIOYRGOI
  Copy();
  // TO TitleCode KLHRONOMEITAI GIA AYTO DE DHLONETAI
  Copy( unsigned int TitleCode, unsigned int CopyCode, float Value,
       char ISBN[] );

  //EPISTROFES TON PROSOPIKON MELON
  unsigned int getCopyCode();
  float getValue();
  char * getISBN();
  void getDOBorrow();
  void getDOReturn();

  void MemberBook( unsigned int MembersCodeBook );
  void MemberBorrow( unsigned int MembersCodeBorreowed );
  bool IsBorrowed();
  bool IsBooked();

  void Returned();
  unsigned int MemberBooked();
  unsigned int MemberBorrowed();
  //EPANAKATHORISMOS TIMON (EKTOS KLASHS) TON PROSOPIKON MELON
  Date setBorrowAndReturn( Date DOBorrow );
};
