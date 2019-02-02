/* KRITIKOS APOSTOLOS  */
/*     AEM: 914       */
/*   	EKSAMHNO B'    */
/*    ERGASIA 1     */


#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <conio.h>
#include <sys/stat.h>


/* DILWNETAI H DOMH PELATIS */
struct pelatis
{
   int pel_code; 		  	/* EINAI O MONADIKOS KWDIKOS PELATI 							 */
   char surname[25];    /* EPITHETO TOY PELATI (KATA SYMVASI 25 XARAKTHRES) 		 */
	char name[25];       /* ONOMA TOY PELATI (KATA SYMVASI 25 XARAKTHRES) 			 */
   char address[50];    /* DIEYTHINSI TOY PELATI (KATA SYMVASI 50 XARAKTHRES) 	 */
   char tel[20];        /* THLEFONO TOY PELATI (KATA SYMVASI 20 XARAKTHRES) 		 */
   char id[20];         /* AR. TAYTOTHTAS TOY PELATI (KATA SYMVASI 20 XARAKTHRES) */
	int mov; 				/* KWDIKOS THS TAINIAS POY EXEI STHN KATOXH TOY O PELATIS */
	int quantity; 			/* ARITHMOS SYNOLIKWN ENOIIASEWN POY EXEI KANEI O PELATIS */
};


/* DILWNETAI H DOMH TAINIA */
struct tainia
{
	int mov_code;		/* EINAI O MONADIKOS KWDIKOS TAINIAS  						    */
	char title[50];   /* TITLOS THS TAINIAS (KATA SYMVASI 50 XARAKTHRES) 	    */
   int category; 		/* KATHGORIA TAINIAS (PAIRNEI TIMES 0, 1, 2  			    */
   int checkout; 		/* ARITHMOS SYNOLIKWN ENOIKIASEWN THS TAINIAS	   		 */
   int custom; 		/* KWDIKOS TOY PELATI POY EXEI STHN KATOXH TOY THN TAINIA */
};


/* SYNARTHSH swap: ENALLASEI TA STOIXEIA *(pel)[i], *(pel)[j]
   (XRHSIMOPOIEITAI APO TIS SYNARTHSEIS alphabetic_sort,
   pelcode_sort, goodpel_sort GIA TA KSINOMHSH TWN PELATWN
   ME BASI KAPOIA STANDART STOIXEIA                           */

void swap(pelatis *pel[],int i,int j)
{
	pelatis temp;

	temp=(*pel)[i];
	(*pel)[i]=(*pel)[j];
	(*pel)[j]=temp;
}


/* SYNARTHSH aphabetic_sort: TAKSINOMHSH TOY PINAKA DOMWN pel[i] SE
ALPHAVITIKH SEIRA (ME VASH TO pel[i].surname). GINETAI XRHSH
TOY ALGORITHMOY THS qsort */

void alphabetic_sort(pelatis ** pel,int left,int right)
{
	int i,last;                          /* XRHSIMOPOIEITAI O ALGORITHMOS */
                                        /* THS qsort ME 1o ORISMA TON 	 */
   if (left>= right) return;            /* PINAKA DOMWN pel[i] 			 */

	swap(pel,left,(left+right)/2);
	last = left;

	for (i=left+1; i<=right;i++)
	{                 				  /* SYGRISH TWN EPITHETWN GIA TAKSINOMHSH */
		if(strcmp((*pel)[i].surname,(*pel)[left].surname)< 0)
		{
			swap(pel,++last,i);
			continue;
		}
	}
	swap(pel,left,last);
	alphabetic_sort(pel,left,last-1);
	alphabetic_sort(pel,last+1,right);

}


/* SYNARTHSH pelcode_sort: TAKSINOMHSH TOY PINAKA DOMWN pel[i] SE
AYKSOUSA SEIRA KWDIKWN (ME VASH TO pel[i].pel_code). GINETAI XRHSH
TOY ALGORITHMOY THS qsort */

void pelcode_sort(pelatis ** pel,int left,int right)
{
	int i,last;   								/* XRHSIMOPOIEITAI O ALGORITHMOS */
                                       /* THS qsort ME 1o ORISMA TON    */
	if (left>= right) return;           /* PINAKA DOMWN pel[i]           */

	swap(pel,left,(left+right)/2);
	last = left;

	for (i=left+1; i<=right;i++)
	{                        /* SYGRISH TWN MONADIKWN KWDIKWN GIA TAKSINOMHSH */
		if((*pel)[i].pel_code < (*pel)[left].pel_code)
		{
			swap(pel,++last,i);
			continue;
		}
	}
	swap(pel,left,last);
	pelcode_sort(pel,left,last-1);
	pelcode_sort(pel,last+1,right);
}


/* SYNARTHSH goodpel_sort: TAKSINOMHSH TOY PINAKA DOMWN pel[i] SE
AYKSOUSA SEIRA KWDIKWN (ME VASH TO pel[i].quantity). GINETAI XRHSH
TOY ALGORITHMOY THS qsort */

void goodpel_sort(pelatis ** pel,int left,int right)
{
	int i,last;                           /* XRHSIMOPOIEITAI O ALGORITHMOS */
                                         /* THS qsort ME 1o ORISMA TON    */
	if (left>= right) return;             /* PINAKA DOMWN pel[i]           */

	swap(pel,left,(left+right)/2);
	last = left;

	for (i=left+1; i<=right;i++)
	{                        /* SYGRISH TOY ARITHMOY SYNOLIKWN ENOIKIASEWN */
                            /*              GIA TAKSINOMHSH               */
		if((*pel)[i].quantity > (*pel)[left].quantity)
		{
			swap(pel,++last,i);
			continue;
		}
	}
	swap(pel,left,last);
	goodpel_sort(pel,left,last-1);
	goodpel_sort(pel,last+1,right);

}


/* SYNARTHSH print_pel: EMFANIZEI TA DEDOMENA TOY EKASTOTE EPILEGMENOY PELATI */

void print_pel(pelatis pel)
{
	printf("1.Customer No: %d\n",pel.pel_code);
	printf("2.Surname: %s\n",pel.surname);
	printf("3.Name: %s\n",pel.name);
	printf("4.Address: %s\n",pel.address);
	printf("5.Tel: %s\n",pel.tel);
	printf("6.Id No: %s\n",pel.id);
	printf("7.Movie: %d\n",pel.mov);
	printf("8.TOTAL movies checked out: %d\n\n",pel.quantity);
}


/* SYNARTHSH esc_enter: EMFANIZEI TA EPOMENA 2 DEDOMENA (paketa dedomenon).
   EPISTREFEI 1 AN O XRHSTHS PATHSE TO <esc> KAI 0 AN O XRHSTHS PATHSE <enter> */

int esc_enter(void)
{
	char c; 	/* METAVLITH XARAKTHRA H OPOIA ELEGXEI SE SYNDIASMO ME THN getch() */
            /*            AN O XRHSTHS EPELEKSE <esc> H <enter>                */
	do
	{
	printf("PRESS <ENTER> TO DISPLAY NEXT 2 CUSTOMERS OR HIT <ESC> TO ABORT: ");
	fflush(stdin);
	c=getch();              		/* 27 - KWDIKOS ASCII TOY ESC   	*/
	}while(c!=27 && c!=13);       /* 13 - KWDIKOS ASCII TOY ENTER */

	if(c==27)              /* ELEGXEI AN O XRHSTHS PATHSE <ENTER> H <ESC> */
	{
		printf("<ESC>\n");
		return 1;
	}

	printf("<ENTER>\n");
	return 0;
}


/* SYNARTHSH new_mov: EISAGEI NEES TAINIES STON PINAKA DOMWN tain[i] */

void new_mov(tainia ** tain, int *nofmov) /* nofmov: ARITHMOS SYNOLIKWN TAINIWN */
{                                         /* POY EINAI KATAXWRHMENES STO ARXEIO */
														/*                         mbase.dat  */

	FILE *fp; 										/* DEIKTHS fp TYPOY FILE */

	char c;   			/* XARAKTHRAS POY ELEGXEI AN O XRHSTHS PATHSE Y(es) H N(o) */

	tainia temp; 	  /* temp PROSWRINH METAVLHTH POY KRATAEI TA DEDOMENA TAINIAS
   							POY EXEI DWSEI O XRHSTHS */

	/* ZHTAEI APO TO SRHSTH TA SEOIXEIA THS NEAS TAINIAS */
	printf("\nGive me the movie profile: \n");

	temp.mov_code=*nofmov+1; /* APOFEUGETAI H PRWTH TAINIA NA PAREI THN TIMH 0 */
	printf("\n1. Title: ");  /* DHLADH OI KWDIKOI TAINIWN THA ARXIZOYN APO 1   */
	fflush(stdin);
	gets(temp.title);
	do
	{
		printf("\n2. Category [0 (1day), 1 (3days), 2 (7days)]: ");
		scanf("%d",&temp.category);
		printf("\n");
		if(temp.category<0 || temp.category>2)
		{
			printf("Category must be between [0-2]!\n");
		}
	}while(temp.category<0 || temp.category>2);

	temp.custom=0;
	temp.checkout=0;

	/* EPIVEVAIWSH EGGRAFHS APO TO XRHSTH AN PATHSEI Y(es) KAI AKYRWSH
		AN PATHSEI N(o) */
	do
	{
		fflush(stdin);
		printf("Submit this movie (Y/N)? ");
		c = getchar();
		if ( (c!='y') && (c!='Y') && (c!='n') && (c!='N'))
		{
			printf("\nYou must choose Y (yes) or N (no)!\n");
		}
	}
	while((c!='y') && (c!='Y') && (c!='n') && (c!='N'));

	if((c=='n') || (c=='N'))
	{
		printf("Procedure aborted by user\n");
		return;
	}

	/* EGGRAFH TIS KAINOYRIAS TAINIAS STO ARXEIO mbase.c */
	fp=fopen("mbase.dat","ab");
	if(fp!=NULL)
		{
			if((fwrite(&temp,sizeof(struct tainia),1,fp))==1);
			printf("Movie was successfuly inserted. ");
			printf("It has been given number: %d\n",temp.mov_code);
		}
	fclose(fp);

	/* AYKSANEI TO NOFMOV OPOU THA XRHSIMOPOIITHEI SAN MONADIKOS KWDIKOS
		TIS EPOMENHS KAINOURIAS TAINIAS */
	(*nofmov)++;

	/* realloc TOY PINAKA DOMWN tain[i] STON OPOIO KTRATOYNTAI OLES OI TAINIES
   	WSTE NA XWRAEI TON KAINOYRIO PINAKA POY PROEKYPSE KAI EINAI MEGALYTEROS */
	*tain=(tainia*)realloc(*tain,sizeof(struct tainia)**nofmov);

	/* ANTIGRAFH TWN STOIXEIWN TIS NEAS TAINIAS APO THN PROSWRINH METAVLITH TEMP
   	STON PINAKA DOMWN tain[i] */
	(*tain)[(*nofmov)-1]=temp;
}


/* SYNARTHSH new_pel: EISAGEI NEOYS PELATES STON PINAKA DOMWN pel[i] */

void new_pel(pelatis ** pel, int *nofpel)
{                               /* nofpel: ARITHMOS SYNOLIKWN PELATWN */
                                /* POY EINAI KATAXWRHMENOI STO ARXEIO */
                                /*                          base.dat  */

	FILE *fp; /* DEIKTHS fp TYPOY FILE */

	int i,max=0,flag=0; /* TO i EINAI METRHTHS, TO max XRHSIMOPOIEITAI GIA NA
                       	  TSEKAREI POIOS EINAI O TELEYTAIOS KATAGEGRAMENOS
                       	  KWDIKOS PELATI WSTE NA DWSEI TON AMESWS EPOMENO
                          STON NEO PELATI, TO flag ELEGXEI AN O PELATIS YPARXEI */

	char c;  		/* XARAKTHRAS POY ELEGXEI AN O XRHSTHS PATHSE Y(es) H N(o) */

	pelatis temp; /* temp PROSWRINH METAVLHTH POY KRATAEI
                 TA DEDOMENA TAINIAS POY EXEI DWSEI O XRHSTHS */

	/* ZHTAEI APO TO XRHSTH TA STOIXEIA TOY NEOY PELATI */
	printf("\nGive me the customer profile: \n");

	/* ELEGXOS GIA TON MEGALYTERO KWDIKO POU YPARXEI WSTE AN EXOYN DIAGRAFEI
		KAPOIOI PELATES NA MHN DOTHEI O IDIOS KWDIKOS SE 2 PELATES */
	for(i=0;i<*nofpel;i++)
	{
		if(max<(*pel)[i].pel_code)
		{
			max=(*pel)[i].pel_code;
		}
	}
	max++;
	temp.pel_code=max; /* APOFEYGETAI NA DOTHEI STON PRWTO PELATI O KWDIKOS 0 */

	printf("\n1. Surname: ");
	fflush(stdin);
	gets(temp.surname);
	printf("\n2. Name: ");
	gets(temp.name);
	printf("\n3. Address: ");
	gets(temp.address);
	printf("\n4. Tel: ");
	gets(temp.tel);
	printf("\n5. ID No: ");
	gets(temp.id);

	temp.mov=0;
	temp.quantity=0;

	for(i=0;i<*nofpel;i++)      /* ELEGXOS AN O PELATIS YPARXEI HDH */
	{
		if(strcmp((*pel)[i].id,temp.id)==0)
		{
			printf("The customer id already inserted");
			flag=1;
		}
	}

	if(flag==0)        /* AN DEN YPARXEI ... flag=0 */
	{
		do		/* EPIVEVAIWSH EGGRAFHS APO TO XRHSTH ME Y(es) H AKYRWSH ME N(o) */
		{
			fflush(stdin);
			printf("Submit the customer (Y/N)? ");
			c = getchar();
			if ( (c!='y') && (c!='Y') && (c!='n') && (c!='N'))
			{
				printf("\nYou must choose Y (yes) or N (no)!\n");
			}
		}
		while((c!='y') && (c!='Y') && (c!='n') && (c!='N'));

		if((c=='n') || (c=='N'))
      {
      	printf("Procedure aborted by user\n");
      	return;
      }

      fp=fopen("base.dat","ab");  /* EGGRAFH TOY PELATI STO ARXEIO base.dat */
		if(fp!=NULL)
      {
      	if((fwrite(&temp,sizeof(struct pelatis),1,fp))==1);
         printf("Customer was successfuly inserted. ");
         printf("Unique customer number: %d\n",temp.pel_code);
      }
      fclose(fp);

      /* AYKSANEI TO NOFPEL POU THA XRHSIMOPOIEITHEI SAN MONADIKOS KWDIKOS
      	TOY EPOMENOY NEOY PELATI */
      (*nofpel)++;

      /* realloc TOY PINAKA DOMWN STON OPOIO KRATOYNTAI OLOI OI PELATES
      	WSTE NA XWRAEI TON KAINOYRIO PINAKA POY PROEKYPSE KAI EINAI
         MEGALYTEROS */
      *pel=(pelatis*)realloc(*pel,sizeof(pelatis)**nofpel);

      /* ANTIGRAFH TWN STOIXEIWN TOY NEOY PELATI STON PINAKA DOMWN */
      (*pel)[(*nofpel)-1]=temp;
   }
}


/* SYNARTHSH del_pel: DIAGRAFEI PELATES APO TON PINAKA DOMWN pel[i] */

void del_pel(pelatis ** pel,int *nofpel) /* nofpel: ARITHMOS PELATWN POY   */
{                                        /* EINAI EGEGRAMENOI STO base.dat */
	FILE *fp;
	int i,delcode;  /* TO i EINAI METRHTHS, ENW TO delcode EINAI O KWDIKOS POY
   						 THA DWSEI O XRHSTHS GIA NA DIAGRAFEI O PELATIS POY
                      EPITHYMEI */

	printf("Give the code of the customer you wish to delete: ");
	fflush(stdin);
	scanf("%d",&delcode);

	for(i=0;(*pel)[i].pel_code!=delcode && i<*nofpel;i++);

												 /* ELEGXOS AN O PELATIS YPARXEI */
	if((*pel)[i].pel_code!=delcode)
	{
		printf("\nThe customer was not found\n\n");
		return;
	}

	if((*pel)[i].mov!=0)
	{                        /* ELEGXOS AN O PELATIS EXEI TAINIA STIN KATOXI TOY
										KAI AN EXEI APISTREFEI STH main() */
		printf("\nThe customer has a movie and can not be deleted\n\n");
		return;
	}

	for(;i<*nofpel;i++)  /* METATHESI OLWN TWN STOIXEIWN TOY PINAKA KATA MIA
								THESI EPANW KAI AFINEI TO TELEYTAIO STOIXEIO KENO */
	{
		(*pel)[i-1] = (*pel)[i];
	}

	if((fp=fopen("temp.dat","wb"))==NULL)  /* DHMIOYRGIA TEMPORARY ARXEIOY */
	{
		printf("The temporary file could not be created\n\n");
		return;
	}

						/* EGGRAFH TOY ANADIATAGMENOY PINAKA STO ARXEIO. GRAFONTAI OLA
							TA STOIXEIA MEXRI KAI TO PROTELEYTAIO ((*nofpel)-1). */

	if(fwrite(*pel,sizeof(pelatis),(*nofpel)-1,fp)!= (*nofpel)-1)
	{
		printf("The file is innaccesible\n\n");
		return;
	}
	fclose(fp);

	if (remove("base.dat")!=0)
	{
		printf("Deleting proccess stopped\n\n");
		return;
	}

	if (rename("temp.dat","base.dat")!=0)
	{
		printf("Deleting proccess stopped\n");
		printf("If the file named base.c doesn not exist\n");
		printf("rename the temp.dat to base.dat\n\n");
		return;
	}

	/* MEIWNEI TO nofpel GIA NA XRHSIMOPOIEITHEI GIA THN realloc */
	(*nofpel)--;

	/* realloc TOY PINAKA DOMWN POY KRATOYNTAI OI PELATES */
	*pel=(pelatis*)realloc(*pel,sizeof(pelatis)**nofpel);

	printf("\nCustomer successfully deleted\n\n");
}


/* SYNARTHSH find_pel: KANEI EYRESH PELATWN ME VASI KAPOIA KRITIRIA. EPITHETO
	(*pel)[i].surname, MONADIKOS KWDIKOS (*pel)[i].pel_code, THLEFWNO (*pel)[i].tel */

void find_pel(pelatis ** pel,int *nofpel)
{
	int i,j,choice;	/* OI METAVLITES i,j EINAI METRRHTES ENW H choice ELEGXEI
								TO KRITIRIO ME TO OPOIO THA PSAKSEI H SYNARTHSH TON PELATI */
	pelatis temp;  /* PROSWRINH METAVLITH TYPOY pelatis */


	do               /* PROSDIORISMOS KRITIRIOU ANAZHTHSHS */
	{
		printf("Find by: 1 - Surname, 2 - Customer No, 3 - Tel. Number: ");
		fflush(stdin);
		scanf("%d",&choice);
		if(choice!=1 && choice!=2 && choice!=3)
		{
			printf("\nYour choice must be 1, 2 or 3\n\n"); /* ELEGXOS AKYROY DEDOMENOY */
		}
	}while(choice!=1 && choice!=2 && choice !=3);


	switch(choice)
	{
		case 1:                       /* KRITIRIO: EPITHETO */
			printf("\nGive me the customers surname: ");
			fflush(stdin);
			gets(temp.surname);
			for(i=0,j=0;i<*nofpel;i++)
			{
				if(strcmp((*pel)[i].surname,temp.surname)==0)
				{
					print_pel((*pel)[i]);
					j++;
				}
				if(j%2==0 && j!=0 && esc_enter()==1) return;
											/* PAIRNEI TIS PRWTES 2 TO POLY EGGRAFES (j%2) KAI */
											/* ANALOGWS ME TO AN O XRHSTHS PATHSEI <enter>    */
											/* H <esc> PROXWRAEI STIS EPOMENES H STAMATAEI   */
			}
								/* AN j==0 DEN YPARXEI PELATIS */
			if(j==0) printf("\nThe requested customer was not found\n\n");
			break;

		case 2: 							/* KRITIRIO - MONADIKOS KWDIKOS PELATI */
			printf("\nGive me the customers unique number: ");
			fflush(stdin);
			scanf("%d",&temp.pel_code);
			for(i=0;i<*nofpel;i++)               /* EDW EINAI DEDOMENO OTI MONO
																MIA EGGRAFH THA VRETHEI OPOTE
															DEN XREIAZETAI KLISH THS esc_enter */
			{
				if((*pel)[i].pel_code==temp.pel_code)
				{
					print_pel((*pel)[i]);
					return;
				}
			}
			printf("\nThe requested customer was not found\n\n");
			break;

		case 3: 							/* KRITIRIO - PHONE NUMBER */
			printf("\nGive me the customers phone number: ");
			fflush(stdin);
			gets(temp.tel);
			for(j=0,i=0;i<*nofpel;i++)
			{
				if(strcmp((*pel)[i].tel,temp.tel)==0)
				{
					print_pel((*pel)[i]);
					j++;
				}
				if(j%2==0 && j!=0 && esc_enter()==1) return;
											/* PAIRNEI TIS PRWTES 2 TO POLY EGGRAFES (j%2) KAI */
											/* ANALOGWS ME TO AN O XRHSTHS PATHSEI <enter>    */
											/* H <esc> PROXWRAEI STIS EPOMENES H STAMATAEI   */
			}
			if(j==0) printf("\nThe requested customer was not found\n\n");
			break;

		default: /* ELEGXOS AKYROY DEDOMENOY */
				printf("\nYour choice must be between [1-3] \n\n");
				break;
	}
}


/* SYNARTHSH find_mov: EYRESH TAINIWN ME VASI TON KWDIKO THS TAINIAS */

void find_mov(pelatis ** pel, tainia ** tain,int *nofmov,int *nofpel)
{
	int i,j,findcode; /* TA i,j EINAI METRTHTES ENW TO findcode APOTELEI TON KWDIKO
								THS TAINIAS POY EPITHIMOYME NA VROUME */

	printf("Give me the movie number: ");
	fflush(stdin);
	scanf("%d",&findcode);
									  /* VRISKEI THN TAINIA */
	for(i=0;i<*nofmov;i++)
	{
		if ((*tain)[i].mov_code==findcode)
		{
			printf("\nTitle: %s\n",(*tain)[i].title);
			printf("Category: %d\n",(*tain)[i].category);
			printf("Customer: ");
			if ((*tain)[i].custom!=0)     /* ELEGXEI AN EINAI XREWMENH SE PELATI */
			{
				printf("%d ",(*tain)[i].custom);
				for(j=0;j<*nofpel && (*pel)[j].mov!=(*tain)[i].mov_code;j++);
																		/* AN EINAI ...*/
				printf("(%s,%s)",(*pel)[j].surname,(*pel)[j].name);
			}
			else
			{      									/* AN DEN EINAI */
				printf("<Non charged>");
			}
			printf("\nNumber of checkouts: %d",(*tain)[i].checkout);
			printf("\n");
			return;
		}
	}           /* AN DEN VREI TAINIA ME TETOIO KWDIKO */
	printf("\nThe requested movie was not found\n\n");
}



/* SYNARTHSH mod_pel: ZHTAEI APO TO XRHSTH PLHROFORIA SXETIKA ME TO PIO STOIXEIO
	TOY PELATI NA TROPOPOIHSEI KAI KATOPIN TROPOPOIEWI TO STOIXEIO AYTO. ENHMERWNEI TO
	ARXEIO KAI TON PINAKA DOMWN pel[i] */

void mod_pel(pelatis ** pel,int *nofpel)
{
	FILE *fptemp;   /* H *fptemp EINAI METAVLITH TYPOY FILE GIA PROSPELASH ARXEIWN */
	int i,flag=0,choice,modcode;  /* H i EINAI METRHTHS H choice DIAXEIRIZETAI TO MENOY  */
											/* EPILOGWN, H modcode PAIRNEI TON KWDIKO PELATH PROS  */
											/* TROPOPOIHSH, ENW H flag ELEGXEI AN O XRHSTH YPARXEI */
	pelatis temp; /* PROSWRINH METAVLITH TYPOY pelatis */

	printf("Give me the customer's unique number: ");
	fflush(stdin);
	scanf("%d",&modcode);

	if((fptemp=fopen("temp.dat","wb"))==NULL)  /* ELEGXOS AN TO ARXEIO ANOIGEI */
	{
		printf("\nCould not open temporary file\n");
		return;
	}

	for(i=0;i<*nofpel;i++)   /* EYRESH TOY PELATH PROS TROPOPOIHSH STOIXEIWN */
	{
		if((*pel)[i].pel_code==modcode)
		{
			printf("The user you want to modify is: %d\n",(*pel)[i].pel_code);
			printf("Surname: %s, Name: % s\n",(*pel)[i].surname,(*pel)[i].name);
			temp=(*pel)[i];
			flag=1;  /* OTAN TO flag GINEI O XRHSTHS YPARXEI */
		}
	}
	if(flag==0) /* AN flag EINAI O XRHSTHS DEN VRETHIKE */
	{
		printf("\nThe user was not found");
		return;
	}

	do
	{             /* ELEGXOS STOIXEIOU POY THELOYME NA TROPOPOIHSOYME
							AN DWTHEI 0, H DIADIKASIA STAMATA */
		printf("\n1. Surname, 2. Name, 3. Address, 4. Tel, 5. Id, 0. Abord\n");
		printf("Epilekste to stoixeio pou thelete na tropopoiisete: ");
		scanf("%d",&choice);

		switch(choice)
		{                    /* TROPOPOIHSH EPITHETOY */
			case 1:
				printf("\nGive me the right Surname: ");
				fflush(stdin);
				gets(temp.surname);
				break;
									/* TROPOPOIHSH ONOMATOS */
			case 2:
				printf("\nGive me me the right Name: ");
				fflush(stdin);
				gets(temp.name);
				break;
									/* TROPOPOIHSH DIEUTHYNSHS */
			case 3:
				printf("\nGive me the right Address: ");
				fflush(stdin);
				gets(temp.address);
				break;
									/* TROPOPOIHSH THLEFWNOY */
			case 4:
				printf("\Give me the right Tel: ");
				fflush(stdin);
				gets(temp.tel);
				break;
									/* TROPOPOIHSH AR. TAYTOTHTAS */
			case 5:
				printf("\Give me the right Id No: ");
				fflush(stdin);
				gets(temp.id);
				break;
								  /* APOTREPEI THN EMFANISH TOY MHNYMATOS DEFAULT
									 AN O XRHSTHS PLIKTROLOGHSEI 0 */
			case 0:
				printf("\nProcedure aborted by user\n");
				break;
									/* ELEGXOS AKYROY DEDOMENOY */
			default:
				printf("Your choice must be between [1-5]\n");
				break;
		}
	}while(choice!=0);

	(*pel)[i-1]=temp;

	/* EGGRAFI TOY temp.dat ARXEIOY ME TA TROPOPOIIMENA STOIXEIA TOY PELATI */
	if((fwrite(*pel,sizeof(pelatis),*nofpel,fptemp))!=*nofpel)
	{
		printf("ERROR WRITING FILE!");
		return;
	}
	fclose(fptemp);
								/* ANANEWSH TOY ARXEIOY base.dat */

	/* remove TOY ARXEIOY base.dat */
	if (remove("base.dat")!=0)
	{
		printf("Deleting proccess stopped\n\n");
		return;
	}

	/* rename TOY temp.c SE base.c - ANANEWSI */
	if (rename("temp.dat","base.dat")!=0)
	{
		printf("Deleting proccess stopped\n");
		printf("If the file named base.c doesn not exist\n");
		printf("rename the temp.dat to base.dat\n\n");
		return;
	}
}


/* check_in : "KSEXREWNEI" MIA TAINIA APO TON PELATI KAI GRAFEI
	TIS ANTOISTIXES PLIROFORIES STA ANTOISTIXA ARXEIA */

void check_in(pelatis ** pel,tainia ** tain,int nofpel,int nofmov)
{
	FILE *fp_tmp;        /* DEIKTHS GIA TO PROSWRINO ARXEIO*/
	char c;       			/* XARAKTHRAS POY ELEGXEI AN O XRHSTHS PATHSE Y(es) H N(o) */
	int i, j, check;     /* OI i,j EINAI METRHTES KAI H check KRATA TON ARITHMO
									TOY PELATH */
	pelatis ptemp;
	tainia temp;

	if (nofmov==0)    /* ELEGXEI AN YPARXOYN TAINIES KATAXWRHMENES */
	{
		printf("There are no movies at the moment...Please insert at least one\n\n");
		return;
	}

	if (nofpel==0)   /* ELEGXEI AN YPARXOYN PWELATES KATAXWRHMENOI */
	{
		printf("There are no customers at the moment...Please insert at least one\n\n");
		return;
	}

	printf("Give me the movies's No : ");
	scanf("%d",&check);

	for (i=0;i<nofmov && (*tain)[i].mov_code!=check;i++);  /* ANAZITISH TAINIAS 	  */
																			 /* BASEI TOY ARITMOY TIS */
	if((*tain)[i].mov_code!=check)
	{                                  /* ELEGXOS AN H TAINIA DEN YPARXEI */
		printf("\nThe movie was not found\n\n");
		return;
	}

	if( (*tain)[i].custom==0)         /* ELEGXOS AN H TAINIA EINAI NOIKIASMENH */
	{
		printf("\nThe movie is already CHECKED IN\n\n");
		return;
	}

											/*EYRESI TOY PELATI STON OPOION EINAI NOIKIASMENH */
	for (j=0;j<nofpel && (*pel)[j].pel_code!=(*tain)[i].custom ;j++) ;


	printf("\nMovie title: %s\n",(*tain)[i].title);
	printf("Category: %d\n",(*tain)[i].category);
	printf("Customer: ");
	printf("%d (%s,%s)",(*tain)[i].custom,(*pel)[j].surname,(*pel)[j].name);
	printf("\nNumber of checkouts: %d\n",(*tain)[i].checkout);

	do     /* EPIVEVAIWSH EGGRAFHS APO TO XRHSTH ME Y(es) H AKYRWSH ME N(o) */
	{
		fflush(stdin);
		printf("\nCheck in? (Y/N)");
		c = getchar();
		if ( (c!='y') && (c!='Y') && (c!='n') && (c!='N'))
		{
			printf("\nWrong choice!!\n");
		}
	}
	while((c!='y') && (c!='Y') && (c!='n') && (c!='N'));


	if((c=='n') || (c=='N')) return;

	temp=(*tain)[i];   /* APOTHIKEUYEI TA STOIXEIA THS TAINIAS SE MIA PROSWRINH METAVLITH */
	ptemp=(*pel)[j];   /* APOTHIKEUYEI TA STOIXEIA TOY PELATH SE MIA PROSWRINH METAVLITH */

	(*tain)[i].custom = 0;
	(*pel)[j].mov = 0;

	if ((fp_tmp=fopen("mbase.tmp","wb"))==NULL) return;

	if(fwrite(*tain,sizeof(tainia),nofmov,fp_tmp)!= nofmov ) /* ANANEWSH TOY ARXEIOY mbase.dat */
	{
		printf("The file is innaccesible\n\n");
		return;
	}

   	if (remove("mbase.dat")!=0)
	{
		printf("Error in the deleting proccess!!\nDeleting proccess stopped\n");
		printf("If the file named base.dat doesn not exist\n");
		printf("rename the base.bak to base.dat\n\n");
		return;
	}

	if (rename("mbase.tmp","mbase.dat")!=0)
	{
		printf("Error in the deleting proccess!!\nDeleting proccess stopped\n");
		printf("If the file named base.dat doesn not exist\n");
		printf("rename the base.bak to base.dat\n\n");
		return;
	}
	fclose(fp_tmp);


	if ((fp_tmp=fopen("base.tmp","wb"))==NULL) return;

	if(fwrite(*pel,sizeof(pelatis),nofpel,fp_tmp)!= nofpel) /* ANANEWSH TOY ARXEIOY base.dat */
	{
		printf("The file is innaccesible\n\n");
		(*tain)[i]=temp;
		(*pel)[j]=ptemp;
		return;
	}

	if (remove("base.dat")!=0)
	{
		printf("Error in the deleting proccess!!\nDeleting proccess stopped\n");
		printf("If the file named mbase.dat doesn not exist\n");
		printf("rename the mbase.tmp to mbase.dat\n\n");
		return;
	}

	if (rename("base.tmp","base.dat")!=0)
	{
		printf("Error in the deleting proccess!!\nDeleting proccess stopped\n");
		printf("If the file named mbase.dat doesn not exist\n");
		printf("rename the mbase.tmp to mbase.dat\n\n");
		return;
	}
	fclose(fp_tmp);

	printf("\nMovie successfully checked in\n\n");
}


/* check_out : "xreonei" se pelati mia tainia kai grafei
	tis antoistixes plirofories sta antoistixa arxeia */

void check_out(pelatis ** pel,tainia *tain[],int nofpel,int nofmov)
{
	FILE *fp_tmp;   /* DEIKTHS GIA TO PROSWRINO ARXEIO*/

	int i,j,cus_check,mov_check; /* OI i,j EINAI METRHTES,H cus_check KRATA TON ARITHMO
											TOY PELATH KAI H mov_check KRATA TON ARITHMO THS TAINIAS */

	pelatis ptemp;  /* PROSWRINH METAVLITH TYPOY pelatis */
	tainia temp;    /* PROSWRINH METAVLITH TYPOY tainia */

	printf("Give me the movies No: ");
	scanf("%d",&mov_check);
									  /* VRISKEI THN TAINIA */
	for (i=0;i<nofmov && (*tain)[i].mov_code!=mov_check;i++);

	if((*tain)[i].mov_code!=mov_check)  /* ELEGXOS GIA TO AN YPARXEI H TAINIA */
	{
		printf("\nThe movie was not found\n\n");
		return;
	}
											  /* EKTYPWSH TWN STOIXEIWN THS TAINIAS */
	printf("\nMovie title: %s\n",(*tain)[i].title);
	printf("Category: %d\n",(*tain)[i].category);
	printf("Customer: ");
	if( (*tain)[i].custom!=0)
	{               /* ELEGXOS AN H TAINIA EINAI XREWMENH SE KAPOION PELATI
								KAI EMFANISH ANTISTOIXOY MHNYMATOS  AN EINAI */
		for(j=0;j<nofpel && (*pel)[j].pel_code!=(*tain)[i].custom;j++);
		printf("%d (%s,%s)",(*tain)[i].custom,(*pel)[j].surname,(*pel)[j].name);
	}
	printf("\nNumber of checkouts: %d\n",(*tain)[i].checkout);

	if( (*tain)[i].custom!=0)
	{
		printf("\nMOVIE IS ALREADY CHECKED OUT BY ANOTHER CUSTOMER!\n\n");
		return;
	}           /* AN DEN EINAI ZHTAEI KWDIKO PELATH STON OPOIO THELOYME NA XREWTHEI */
	printf("\nMOVIE IS IN. Give me the customer's No : ");
	scanf("%d",&cus_check);
									/* EYRESH TOY PELATH */
	for (j=0;j<nofpel && (*pel)[j].pel_code!=cus_check;j++);

	if((*pel)[j].pel_code!=cus_check) /* ELEGXOS AN O PELATHS YPARXEI */
	{
		printf("\nThe customer was not found\n\n");
		return;
	}

	if((*pel)[j].mov!=0)  /* ELEGXOS AN O PELATHS EXEI ALLH TAINIA STHN KATOXH */
	{
		printf("\nThe customer has already one movie in his possesion\n\n");
		return;
	}

	temp=(*tain)[i]; /* KRATAEI TA STOIXEIA THS TAINIAS SE MIA PROSWRINH METAVLHTH temp */
	ptemp=(*pel)[j]; /* KRATAEI TA STOIXEIA TOY PELATH SE MIA PROSWRINH METAVLHTH ptemp */

	(*tain)[i].checkout++;  /* AYKSHSH TWN CHECKOUT KATA 1 */
	(*tain)[i].custom=(*pel)[j].pel_code; /* KATAXWRHSH TOY KWDIKOY PELATH
													STO .custom THS TAINIAS */

	(*pel)[j].quantity++; /* AYKSHSH TWN TAINIWN POY EXEI O PELATHS STHN KATOXH TOY KATA 1 */
	(*pel)[j].mov=(*tain)[i].mov_code; /* KATAXWRHSH TOY KWDIKOY TAINIAS STO .mov
														TOY PELATH */

	if ((fp_tmp=fopen("base.tmp","wb"))==NULL) return;

								/* EGGGRAFH TOY ANANEWMENOY PINAKA DOMWN STO ARXEIO base.dat */

	if(fwrite(*pel,sizeof(pelatis),nofpel,fp_tmp)!= nofpel)
	{
		printf("The file is innaccesible\n\n");
		(*tain)[i]=temp;
		(*pel)[j]=ptemp;
		return;
	}

	if (remove("base.dat")!=0)
	{
		printf("Error in the deleting proccess!!\nDeleting proccess stopped\n");
		printf("If the file named base.dat doesn not exist\n");
		printf("rename the base.tmp to base.dat\n\n");

		return;
	}

	if (rename("base.tmp","base.dat")!=0)
	{
		printf("Error in the deleting proccess!!\nDeleting proccess stopped\n");
		printf("If the file named base.dat doesn not exist\n");
		printf("rename the base.tmp to base.dat\n\n");

		return;
	}
	fclose(fp_tmp);

	if((fp_tmp=fopen("mbase.tmp","wb"))==NULL) return;

					/* EGGGRAFH TOY ANANEWMENOY PINAKA DOMWN STO ARXEIO mbase.dat */

	if(fwrite(*tain,sizeof(tainia),nofmov,fp_tmp)!= nofmov)
	{
		printf("The file is innaccesible\n\n");
		(*tain)[i]=temp;
		(*pel)[j]=ptemp;
		return;
	}

	fclose(fp_tmp);

	if (remove("mbase.dat")!=0)
	{
		printf("Error in the deleting proccess!!\nDeleting proccess stopped\n");
		printf("If the file named mbase.dat doesn not exist\n");
		printf("rename the mbase.tmp to mbase.dat\n\n");
		return;
	}

	if (rename("mbase.tmp","mbase.dat")!=0)
	{
		printf("Error in the deleting proccess!!\nDeleting proccess stopped\n");
		printf("If the file named mbase.dat doesn not exist\n");
		printf("rename the mbase.tmp to mbase.dat\n\n");
		return;
	}

	printf("\nMovie has been charged to: %s %s\n\n",(*pel)[j].surname,(*pel)[j].name);
}


void main()
{
	FILE *fp; /* DEIKTHS GIA TA ARXEIA base.dat, mbase */
	int i,nofpel,nofmov; /* TO i EINAI METRHTHS, TO nofpel EINAI O ARITHMOS PELATWN
									KAI TO nofmov EINAI O ARITHMOS TAINIWN */
	int choice;  	/* TO choice DIAXEIRIZETAI TO MENOY */
	struct stat stat_p; /* stat_p EINAI METAVLHTH TYPOU stat. MESW AYTHS
								YPOLOGIZETAI TO MEGETHOS TOY ARXEIOY */

	/* YPOLOGISMOS TOY nofpel APO TO ARXEIO base.dat */
	if ((-1 == stat("base.dat",&stat_p))||(stat_p.st_size==0))
	{
		printf("Error occoured attempting to open file!\n");
		exit(0);
	}
	nofpel=(int)(stat_p.st_size)/(sizeof(struct pelatis));
	
	/* YPOLOGISMOS TOY nofmov APO TO ARXEIO mbase.dat */
	if ((-1 == stat("mbase.dat",&stat_p))||(stat_p.st_size==0))
	{
		printf("Error occoured attempting to open file\n");
		exit(0);
	}
	nofmov=(int)(stat_p.st_size)/(sizeof(struct tainia));

	/* DHLWSH TWN PINAKWN DOMWN pel[] KAI tain[] */
	pelatis * pel;
	pel=(pelatis*)malloc(sizeof(struct pelatis)*(nofpel));

	tainia * tain;
	tain=(tainia*)malloc(sizeof(struct tainia)*(nofmov));

	/* GEMISMA TWN PINAKWN DOMWN pel[] KAI tain[] APOTO ARXEIO */
	fp=fopen("base.dat","rb");
	fread(pel,sizeof(struct pelatis),nofpel,fp);
	fclose(fp);

	fp=fopen("mbase.dat","rb");
	fread(tain,sizeof(struct tainia),nofmov,fp);
	fclose(fp);

	do  /* LOOP POY DIAXEIRIZETAI THN EMFAMISH TOY MENOY */
	{
		/* EMFANISH TOY MENOY EPILOGWN */
		printf("\nMain Menu\n");
		printf("=========\n");
		printf("1 - Insert customer\n");
		printf("2 - Insert movie\n");
		printf("3 - Display customers\n");
		printf("4 - Find customer\n");
		printf("5 - Find movie\n");
		printf("6 - Delete customer\n");
		printf("7 - Check in movie (epistrofi)\n");
		printf("8 - Check out movie (daneismos)\n");
		printf("9 - Change customer profile\n");
		printf("0 - Exit Program\n\n");

		printf("Choose [0-9]: ");
		fflush(stdin);
		scanf("%d",&choice);

		switch(choice)
		{
			case 1:
								/* KALEI TH SYNARTHSH EISAGWGHS NEOY PELATI */
				new_pel(&pel,&nofpel);
				break;
			case 2:
								/* KALEI TH SYNARTHSH EISAGWGHS NEAS TAINIAS */
				new_mov(&tain,&nofmov);
				break;
								/* KALEI THN ANTISTOIXH SYNARTHSH TAKSINOMHSHS
									ANALOGA ME TO STOIXEIO TOY MENOY POY EPILEXTHIKE */
			case 3:
				do
				{
					printf("1-Alphabetical order, 2-Customer No order, 3 - Best customer order? \n");
					fflush(stdin);
					scanf("%d",&choice);
					printf("\n");
					if(choice<1 || choice>3) printf("WRONG INPUT, GIVE A NUMBER BETWEN 1-3!\n\n");
				}while(choice<1 || choice>3);
				if(choice == 1) alphabetic_sort(&pel,0,nofpel-1);
				if(choice == 2) pelcode_sort(&pel,0,nofpel-1);
				if(choice == 3) goodpel_sort(&pel,0,nofpel-1);
				/*emphanisi olwn ton pelatwn opws exoyn taksinomithei*/
				for(i=0;i<nofpel;i++)
				{
					print_pel(pel[i]);
					if(i%2==1 && i!=nofpel-1 && esc_enter()==1) break;
				}
				printf("PRESS ANY KEY TO RETURN TO MAIN MENU\n\n");
				getch();
				break;
			case 4:
								/* KALEI TH SYNARTHSH EYRESHS PELATH */
				find_pel(&pel,&nofpel);
				break;
			case 5:
								/* KALEI TH SYNARTHSH EYRESHS TAINIAS */
				find_mov(&pel,&tain,&nofmov,&nofpel);
				break;
			case 6:
								/* KALEI TH SYNARTHSH DIAGRAFHS PELATH */
				del_pel(&pel,&nofpel);
				break;
			case 7:
								/* KALEI TH SYNARTHSH KSEXREWSHS TAINIAS */
				check_in(&pel,&tain,nofpel,nofmov);
				break;
			case 8:
								/* KALEI TH SYNARTHSH XREWSHS TAINIAS */
				check_out(&pel,&tain,nofpel,nofmov);
				break;
			case 9:
								/* KALEI TH SYNARTHSH TROPOPOIHSHS PELATH */
				mod_pel(&pel,&nofpel);
				break;
			case 0: /* APOTREPEI THN EMFANISH TOY MHNYMATOS default
							AN O XRHSTHS PLHKTROLOGHSEI 0 */
				break;
			default: /* ELEGXOS AKYROY DEDOMENOY */
				printf("Your choice must be between [0-9]\n");
				break;
      }
	}while(choice!=0);
   printf("Bye Bye!");
}
