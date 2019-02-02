/* LOGIKOS & SYNARTHSIAKOS PROGRAMMATISMOS
   ERGASIA 2
   SKALISTHS STEFANOS (1024) - KRHTIKOS APOSTOLOS (914) */

/* TA DYNAMIKA KATHGORIMATA: 
	1. TO current_word, KRATAEI TH LEKSI POY EXEI EPILEKSEI O XRHSTHS.
	2. TO vocabulary, KRATAEI MIA LISTA OLON TON LEKSEON POY EXOYN FORTOTHEI KAI EISAXTHEI
	3. TO stats, KRATAEI TA STATISTIKA TOY PAIXNIDIOY POY EMFANIZONTAI STO TELOS
	4. TO word, XRHSIMOPOIEITAI PROSORINA GIA TO DIAVASMA TON LEKSEON APO ARXEIO */

:- dynamic current_word/1.
:- dynamic vocabulary/1.
:- dynamic stats/2.
:- dynamic word/2.	


/* STHN EKKINHSH TOY PROGRAMMATOS TO LEKSIKO PREPEI NA EINAI ADEIO, 
   NA MIN YPARXEI EPILEGMENH LEKSI KAI TA STATISTIKA NA EINAI MHDENISMENA */ 

vocabulary([]).
current_word([]).
stats(0,0).


% TO BASIKO MENOY OPOY O XRHSTHS EPILEGEI THN ENERGEIA POY THELEI NA EKTELESTEI. 

run:-
	!,nl,nl,
	write('1)Choose word from the current dictionary'),nl,
	write('2)Play THE HANGED-MAD'),nl,
	write('3)Insert a word to the current dictionary'),nl,
	write('4)Delete a word from the current dictionary'),nl,
	write('5)Load dictionary from file'),nl,
	write('6)Save current dictionary to file'),nl,
	write('7.Exit'),nl,nl,
	write('Choose'),
	read(Choice),
	clear_console,
	do_on_choice(Choice).


% OI DIAFORES EPILOGES TOY PROGRAMMATOS

% EPILOGH PROTH: EPILOGH LEKSHS

do_on_choice( 1 ):-
	read_vocabulary(VocList),	% ANAGNOSH TOY LEKSIKOY APO TH MNHMH
	voc_is_empty(VocList),!,	% ELEGXOS AN EINAI ADEIO
	run.				% AN EINAI, EPANAFORA STO MENOY
do_on_choice( 1 ):-
	nl,nl,
	read_vocabulary(VocList),	% SE PERIPTOSH POY DEN EINAI ADEIO
	write('Choose a word among the following '),nl,
	write('(give the corresponding number or 0 for a random from the computer)'),
	nl,nl,
	write_vocabulary(VocList),nl,	% EMFANISH TOY LEKSIKOY STHN OTHONH
	read(WordNum),			% ANAGNOSH THS EPILOGHS 
	length(VocList,VocLength),	
	which_num(WordNum,VocLength,Return),	% EPISTROFH THS SOSTHS THESHS THS LEKSHS STH LISTA
						% BASH THS PARAPANO EPILOGHS 
	take_word(Return,VocList,Word),		% EPILOGH THS LEKSHS APO TO LEKSIKO
	place_word(Word),nl,nl,			
	write('The word '),
	write(Word),
	write(' is the hidden word'),nl,nl,
	write('Press any key and then Return to continue'),
	get(S),
	clear_console,			% KATHARISMOS KONSOLAS 
	!,run.				% EPISTROFH STO BASIKO MENOY

% EPILOGH DEYTERH: ENARKSH PAIXNIDIOY

do_on_choice(2):-
	read_current_word(Word),	% ANAGNOSH THS LEKSHS APO TH MNHMH
	word_is_empty(Word),!,		% ELEGXOS AN EINAI ADEIA
	run.				% AN EINAI, EPANAFORA STO MENOY
do_on_choice(2):-
	read_current_word(Word),	% AN DEN EINAI 
	string_to_list(Word,WordList),	% METATROPH THS LEKSHS SE LISTA 
	hangedman(WordList,[],8).	% KAI ENARKSH TOY PAIXNIDIOY ME TH LISTA AYTH
					% (O PAIKTHS EXEI STH DIATHESH TOY 8 PROSPATHEIES)

% EPILOGH TRITH: EISAGOGH LEKSHS

do_on_choice(3):-
	nl,nl,
	write('Insert a correct word:'),
	read(Word),			% ANAGNOSH THS NEAS LEKSHS
	read_vocabulary(VocList),nl,	% ANAGNOSH TOY LEKSIKOY APO TH MNHMH
	not(member(Word,VocList)),!,	% ELEGXOS AN H LEKSH EINAI KATAGEGRAMENH
	retract(vocabulary(List)),	% AN OXI
	assert(vocabulary([Word|List])),% SYMPERILIPSH THS LEKSHS STH LISTA TOY LEKSIKOY
	write('The word is inserted to the dictionary.'),nl,!,
	run.				% EPISTROFH STO BASIKO MENOY
do_on_choice(3):-
	!,nl,
	write('This word already exists in the voacabulary'),!, % AN EINAI KATAGEGRAMENH
	run.							% EPISTROFH STO BASIKO MENOY

% EPILOGH TETARTH: DIAGRAFH LEKSHS

do_on_choice(4):-
	nl,write('Delete a word from the dictionary:'),
	read(Word),nl,			% ANAGNOSH THS LEKSHS PROS DIAGRAFH
	remove_word_from_voc(Word),!,	% ELEGXOS KAI AFAIRESH THS LEKSHS APO TO LEKSIKO
	write('The word is deleted from the dictionary.'), % EPIBEBAIOSH DIAGRAFHS 
	nl,nl,!,
	run.				% EPISTROFH STO BASIKO MENOY
do_on_choice(4):-
	!,nl,				% AN DEN YPARXEI EMFANISH SXETIKOY MHNYMATOS
	write('The word is not in the dictionary!'),
	nl,nl,!,
	run.				% EPISTROFH STO BASIKO MENOY

% EPILOGH PEMPTH: FORTOSH LEKSIKOY APO ARXEIO

do_on_choice(5) :-
	!, nl,
	write('Give the filename of the dictionary to be loaded:'), 
	read(File),			% ANAGNOSH TOY ONOMATOS TOY ARXEIOY
	open(File),			% ANOIGMA KAI ELEGXOS, AN YPARXEI...
	retractall(vocabulary(_) ),	% AFAIRESH TOY LEKSIKOY APO TH MNHMH 
	retractall(current_word(_) ),	% AFAIRESH THS EPILEGMENHS LEKSHS APO TH MNHMH
	assert( vocabulary([]) ),	% TOPOTHETHSH TOY ADEIOY LEKSIKOY 
	assert( current_word([]) ),	% TOPOTHETHSH THS ADEIAS LEKSHS
	repeat, 			% EPANALHPSH MESO Backtracking MEXRI TO end_of_file
	read(Word), 			% ANAGNOSH LEKSHS
	ins_word(Word), 		% EISAGOGH STO LEKSIKO 
	Word == end_of_file,		% AN H LEKSH EINAI TO end_of_file
 	!, nl,				% APOKOPH GIA TO repeat  
	write('File loaded.'), nl,	% MHNYMA EPITYXIAS 
	seen,				% KLEISIMO TOY ARXEIOY
	not(flatten_voc),!,		% EOSAGOGH OLON TON PROSORINON KATHGORHMATON word
					% STH LISTA TOY LEKSIKOY TO not XRHSIMOPOIEITAI EPEIDH
					% (TO KATHGORHMA flatten_voc PANTA APOTYGXANEI)
	run.				% EPISTROFH STO BASIKO MENOY

% EPILOGH EKTH: APOTHIKEYSH TOY LEKSIKOY SE ARXEIO  

do_on_choice( 6 ):-
	read_vocabulary(VocList),	% ANAGNOSH LEKSIKOY APO TH MNHMH	
	voc_is_empty(VocList),!,	% ELEGXOS AN EINAI ADEIO
	run.				% AN EINAI, EPANAFORA STO MENOY
do_on_choice( 6 ):-!,
	nl,nl,				% AN DEN EINAI...
	write('Give the name of the file to which the'),nl,
	write('dictionary will be saved:'),
	read(File),			% ANAGNOSH TOY ARXEIOY STO OPOIO THA APOTHIKEYTEI
	write_voc_to_file( File),!,	% EGGRAFH THS LISTAS TOY LEKSIKOY STO ARXEIO
	run.				% EPISTROFH STO BASIKO MENOY

% EPILOGH EBDOMH: EKSODOS

do_on_choice( 7 ) :-!,
	nl,nl,				% ANAGNOSH TON STATISTIKON APO TH MNHMH 
	retract( stats( Total , Wins ) ),
	Loses is Total-Wins,		% YPOLOGISMOS TON APOTYXION ME BASH TO SYNOLO 
					% KAI TIS EPITYXIES
	write('You played '),
	write( Total ),
	write('  times'),nl,
	write('Times Player2 found the hidden word :'),
	write( Wins ),nl,	
	write('Times Player2 did not find the hidden word :'),
	write( Loses ),nl,nl,
	retractall(vocabulary(_)),	% AFAIRESH APO TH MNHMH OLON TON LEKSIKON,
	retractall(current_word(_)),	% OLON TON LEKSEON
	retractall(stats(_)),		% KAI OLON TON STATISTIKON
	assert(vocabulary([])),		% MHDENISMOS THS LISTAS TOY LEKSIKOY,
	assert(current_word([])),	% THS EPILEGMENHS LEKSEOS
	assert( stats( 0 , 0 ) ),	% KAI TON STATISTIKON
	!.

% SE PETIPTOSH POY O XRHSTHS EISAGEI KATI \= APO TA PARAPANO 
% EMFANISH TOY SXETIKOY MHNYMATOS

do_on_choice(_) :- nl,write('Invalid Input'),!,run.

% GENIKA KATHGORHMATA 


/* H remove_word_from_voc DIAGRAFEI TH LEKSH Word APO TO YPARXON LEKSIKO STH MNHMH
   AFOY PROTA ELEGKSEI AN EINAI MELOS TOY. O XORISMOS GINETAI ME XRHSH THS append OPOY 
   XORIZEI TH LISTA TOY LEKSIKOY SE DYO NEES LISTES, ETSI OSTE H DEYTERH NA EXEI OS KEFALH
   TO Word KAI EPEITA SYNNENONEI TIS DYO AYTES LISTES PARALEIPONTAS TO Word */

remove_word_from_voc(Word):-
	read_vocabulary(VocList),
	member(Word,VocList),
	append(HeadList,[Word|TailList],VocList),
	append(HeadList,TailList,NewVocList),!,
	retract(vocabulary(_)),
	assert(vocabulary(NewVocList)).

/* TO flatten_voc PAIRNEI ENA ENA TA KATHGORHMATA word, APO TH MHNMH KAI TA BAZEI OLA STH
   LISTA TOY LEKSIKOY. TO flatten_voc APO TON ORISMO TOY PANTA APOTYGXANEI */

flatten_voc:- 
	retract(word(Word)),
	retract(vocabulary(List)),
	assert(vocabulary([Word|List])),
	!,flatten_voc.

% TO voc_is_empty ELEGXEI AN TO LEKSIKO EINAI KENO KAI TYPONEI TO ANALOGO MHNYMA

voc_is_empty([]):- 
	nl,nl,
	write('No vocabulary has been loaded!!'),nl,
	write('Please select one first and then select this option!'),nl,!.


% TO word_is_empty ELEGXEI AN H EPILEGMENH LEKSH EINAI KENH KAI TYPONEI TO ANALOGO MHNYMA

word_is_empty([]):-
	nl,nl,
	write('No word has been chosen!!'),nl,
	write('Please select one first and then select this option!'),nl,!.


% KATHARISMOS KONSOLAS 

clear_console:-
	system_menu(1,edit,select_all),
  	system_menu(1,edit,clear).


% AN O ARITHMOS EINAI 0 EPILOGH ENOS TYXAIOY ALLIOS EPISTROFH TOY IDIOY

which_num(0,VocLength,Return) :- !,
	Return is ip(rand(VocLength)+1),!. 

which_num(Num,VocLength,Return) :- 
	integer(Num),Num=<VocLength,!,Return=Num.

which_num(_,_,_) :- fail.


% EPISTROFH TOY N STOIXEIOY APO MIA LISTA

take_word(1,[VocHead | VocTail],VocHead) :- !.
take_word(Place,[VocHead | VocTail],Word) :- 
				Place > 0,
				NewPlace is Place - 1,
				take_word( NewPlace ,VocTail ,Word). 


% TOPOTHETHSH THS EPILEGMENHS LEKSHS META APO AFAIRESH OLON TON YPOLOIPON

place_word(Word):- 
	retractall(current_word(_)),
	assert(current_word(Word)),!.


% ANAGNOSH TOY LEKSIKOY APO TH MNHMH

read_vocabulary(VocList):-
	retract(vocabulary(VocList)),
	assert(vocabulary(VocList)),!.


% ANAGNOSH THS EPILEGMENHS LEKSHS APO TH MNHMH

read_current_word(Word) :-
	retract(current_word(Word)),
	assert(current_word(Word)),!.	


% EMFANISH TON LEKSEON THS LISTAS TOY LEKSIKOY

write_vocabulary(VocList):-
	write_words(VocList,1).


% EGGRAFH TON LEKSEON ARITHMIMENON KSEKINONTAS APO TO N

write_words([],_):-!.

write_words([HeadWord | TailWords],N):-
	write('   '),
	write(N),write('. '),
	write(HeadWord),nl,
	N1 is N + 1,
	write_words(TailWords,N1).

% EGGRAFH TOY LEKSIKOY STO ARXEIO File

write_voc_to_file(File):-
	tell(File),
	read_vocabulary(VocList),
	write_file(VocList),nl,
	write('The dictionary is saved to this file'),
	close(File),nl.

/* EGGRAFH TON LEKSEON STO REYMA EKSODOY ME TH MORFH GEGONOTON 
   KAI KLEISIMO TOY REYMATOS */

write_file([]):-!,told.
write_file( [ HeadWord|TailWords ] ):-
	write(HeadWord),
	write('. '),!,
	write_file( TailWords ).
	
% EISAGOGH THS LEKSHS STO LEKSIKO STH MNHMH
ins_word(end_of_file) :- !.
ins_word(Word) :- 
	assert( word( Word ) ).

% ELEGXOS AN YPARXEI ARXEIO File KAI ANOIGMA TOY
open(File):-
	catch(X,see(File)),
	open_aux(X).
	

open_aux(0).

open_aux(31):-
	nl,write('No such file is found!'),
	nl,!,run.

% AYKSISH TON SYNOLIKON PAIXNIDION XORIS AYKSISI TON NIKON

inc_total_stats:-
	retract(stats(Total,Wins)),
	NewTotal is Total+1,
	asserta(stats(NewTotal,Wins)),!.

% AYKSISH TON SYNOLIKON PAIXNIDION ME AYKSISI TON NIKON

inc_wins_stats:-
	retract(stats(Total,Wins)),
	NewTotal is Total+1,
	NewWins is Wins+1,asserta(stats(NewTotal,NewWins)),!.


% TO PAIXNIDI THS KREMALA

/* OTAN MIDENISTOYN OI PROSPATHEIES O PAIXTHS XANEI TIN PARTIDA.
   OTAN DEN YPARXEI TO * STIN LEKSI O PAIXTHS EXEI NIKISEI.
   SE KATHE ALLI PERIPTOSI O PAIXTHS SYNEXIZEI NA MANTEYEI EOS OTOY 
   SYMBEI ENA APO TA PARAPANO!!! */

hangedman( Word , Guesses , 0 ) :- 
				write('Sorry you lost. The hidden word was:'),nl,
				write(Word),nl,nl,
				!,
				inc_total_stats,	%AYKSISI TWN SYNOLIKWN PAIXNIDIWN
				run.			%EPISTROFH STO BASIKO MENOY

hangedman( Word , Guesses , Attempts ) :- 
				Attempts > 0,
				wordinstars( Word ,Guesses , Stars ),
				not( member( * , Stars ) ),
				nl,
				write('You FOUND it!!! Congratulations!!! '),
				write('The hidden word was:'),
				write(Word),
				!,
				inc_wins_stats,		%AYKSISI TWN SYNOLIKWN PAIXNIDIWN KAI NIKWN
				run.			%EPISTROFH STO BASIKO MENOY
  
hangedman( Word , Guesses , AttemptsLeft ) :- 
			nl,nl,
			write( 'The word is: ') , 
			wordinstars( Word ,Guesses , Stars ),
			write( Stars ),nl, 
			write( 'Letters guessed so far:	'),
			write( Guesses ),
			write('    Attempts left:'),
			write(AttemptsLeft),nl,
			write('Guess a new letter '),
			read(Letter),!,
	write_cases( Word , Guesses , AttemptsLeft , Letter ).



% DIAFORES PERIPTOSEIS MYNMHMATWN KAI ROHS ELGXOY
write_cases( Word, Guesses , AttemptsLeft , Letter ) :- 
					member(Letter,Guesses),nl,
					write('This letter  has been already guessed'),nl,nl,!,
					hangedman(Word, Guesses , AttemptsLeft ).

write_cases( Word , Guesses , AttemptsLeft , Letter ) :- 
				member(Letter,Word),!,
			hangedman( Word , [Letter|Guesses] , AttemptsLeft ),!. 
			
	
					
write_cases( Word , Guesses , AttemptsLeft , Letter ) :- 
			NewAttemptsLeft is AttemptsLeft - 1 ,!,
		hangedman( Word , [Letter|Guesses] , NewAttemptsLeft ),!.



/* 
   METATROPH MIAS LISTAS XARAKTHRON ME BASH MIA LISTA EIKASION SE MIA LISTA XARAKTHRON 
   OPOY OTAN DEN YPARXEI ENA GRAMMA THS LISTAS, STH LISTA EIKASION TOPOTHETEI TO XARAKTHRA * 
*/

wordinstars([X],TryList,[X]):-member(X,TryList).
wordinstars([X],TryList,[*]):-not( member(X,TryList) ).

wordinstars([ HeadWord | TailWord ] , TryList ,	[ HeadWord | Tail] ) :-
	member( HeadWord , TryList ) , !,
	wordinstars( TailWord , TryList , Tail ),!.

wordinstars([ HeadWord | TailWord ] , TryList ,	[ * | Tail] ) :-
	not ( member( HeadWord , TryList ) ) , 
	wordinstars( TailWord , TryList , Tail ),!.


% METATROPH MIAS LISTAS ARITHMON SE LISTA XARAKTHRON

num_to_char( [Num] , [Char] ) :- 
				name( Char , [Num] ),!.
num_to_char( [ NH | NT ] , [ CH | CT]) :- 
				name( CH, [ NH ]), 
				num_to_char( NT ,CT).


% METATROPH ENOS ALFARITHMITIKOY SE LISTA

string_to_list(Str,List ):- 
			name( Str , TmpList ),
			num_to_char( TmpList , List ).
