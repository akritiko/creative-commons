/* H XRHSH TOY PARAKATO BLOCK KODIKA - #ifndef ... #define ... #include ...
#endif GINETAI GIA NA APOFYGOYME SFALMATA POLLAPLHS DHLOSHS MIAS KLASHS */

#ifndef FileAuthor
  #define FileAuthor
  #include "./Author.h"
#endif
#ifndef FileDate
  #define FileDate
  #include "./Date.h"
#endif

class Book //H KLASH Book
{
protected:
  unsigned int _TitleCode; //KODIKOS TITLOY POY THA KLHRODOTHTHEI STHN KLASH Copy

private:
  unsigned int _NOFAuthors; //PLHTHOS SYGGRAFEON
  Author _Authors[10]; //PINAKAS SYGGRAFEON
  Date _DOPublish; //HMEROMHNIA EKDOSHS (Date of publish)

  char _Title[50]; //TITLOS VIVLIOY (KATA SYMVASH MEXRI 50 XARAKTHRES)
  char _Description[300]; //PERIGRAFH (KATA SYMVASH MEXRI 50 XARAKTHRES)
  char _PublishingFirm[30]; //EKDOTIKOS OIKOS (KATA SYMVASH MEXRI 50 XARAKTHRES)

public:
  //OI DHMIOYRGOI
  Book();
  Book( unsigned int TitleCode, char * Title, unsigned int NOFAuthors,
       Author * Authors, char * Description, char * PublishingFirm,
       Date DOPublish );
  //EPISTROFES PROSOPIKON MELON
  unsigned int getTitleCode();
  char * getTitle();
  unsigned int getNOFAuthors();
  char * getDescription();
  char * getPublishingFirm();
  void getDOPublish();
  void getAuthors();
};
