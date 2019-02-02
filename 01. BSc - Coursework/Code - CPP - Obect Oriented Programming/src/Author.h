
class Author //H KLASH Author
{
private:
  unsigned int _AuthorCode; //KODIKOS SYGGRAFEA
  char _Name[20]; //ONOMA
  char _Surname[20]; //EPITHETO

public:
  //OI DHMIOYRGOI
  Author();
  Author( unsigned int AuthorCode, char Name[], char Surname[] );

  //EPISTROFES PROSOPIKON MELON
  unsigned int getAuthorCode();
  char * getName();
  char * getSurname();

  //APODOSH NEON TIMON STA PROSOPIKA MELH
  void setAuthorCode( unsigned int RepairedCode);
  void setName( char RepairedName[] );
  void setSurname( char RepairedSurname[] );
};
