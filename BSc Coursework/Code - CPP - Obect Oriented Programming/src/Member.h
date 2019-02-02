/* TO MELOS MPOREI NA DANEISTEI ENA H PERISSOTERA ANTITYPA ALLA MPOREI NA
KANEI KRATHSH ENOS ANTITYPOY MONO. DEXOMASTE OTI KATA THN EPISTROFH,
EPISTREFONTAI OLA TA ANTITYPA POY EXEI DANEISTEI TO EKASTOTE MELOS (GIA NA
PETYXOYME KALYTERH PROSOMOIOSH MIAS KAI AYTH EINAI H SYNHTHISMENH POLITIKH TON
DANEISTIKON BIBLIOTHIKON) */

class Member
{
private:
  char _Name[20]; //ONOMA
  char _Surname[20]; //EPITHETO
  char _Address[40]; //DIEYTHINSI
  char _PhoneNumber[10]; //THLEFONO
  bool HasBooked;

  unsigned int _MemberCode; //KODIKOS MELOYS

public:
  //OI DHMIOYRGOI
  Member();
  Member( unsigned int _MemberCode, char _Name[], char _Surname[],
       char _Address[], char _PhoneNumber[] );

  //ENHMERONOYN GIA KRATHSEIS - DANEISMOYS
  void Book();
  void unBook();
  bool HasAlreadyBooked();

  //EPISTROFES TON PROSOPIKON MELON
  unsigned int getMemberCode();
  char * getName();
  char * getSurname();
  char * getAddress();
  char * getPhoneNumber();

  //EPANAPROSDIORISMOI TON TIMON (EKTOS KLASHS) TON PROSOPIKON MELON
  void setMemberCode( unsigned int NewCode );
  void setName( char NewName[] );
  void setSurname( char NewSurname[] );
  void setAddress( char NewAddress[] );
  void setPhoneNumber( char NewNumber[] );

};
