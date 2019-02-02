%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%                                           			      %
% LOGIKOS KAI SYNARTHSIAKOS PROGRAMMATISMOS  %
% KRHTIKOS APOSTOLOS                        		      %
% AEM: 914                                  			      %
% AK.ETOS: 2005-2006			    	      %
%                                           			      %
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% 


/*
	SXOLIA SXETIKA ME TH MORFH TOY ARXEIOY POY XRHSIMOPOIEITAI:
	TO ARXEIO LEKSIKOY PERIEXEI EGGRAFES THS MORFHS 
	
		...	...	leksi1. ennoia1. leksi2. ennoia2.	...	...	...
*/



% TA DYNAMIKA KATHGORHMATA POY XRHSIMOPOIEI TO PROGRAMMA ORIZONTAI EDO


:- dynamic vocabulary/1.
:- dynamic word/1.	



% EDO ARXIKOPOIEITAI TO DYNAMIKO KATHGORHMA LEKSIKOY

vocabulary([]).


%%% TO VASIKO MENOY TOY PROGRAMMATOS 

run:-
	!,nl,nl,
	assert(counter(1)),			% ARXIKOPOIHSH TOY METRHTH
	assert(sentence([])),		% ARXIKOPOIHSH TOY KATHGORHMATOS sentence
	clear_console,			% GINETAI KATHARISMOS THS KONSOLAS
	write('1. Process a sentence.'),nl,
	write('2. Lookup a word in the dictionary.'),nl,
	write('3. Lookup a concept in the dictionary.'),nl,
	write('4. Find synonyms for a word.'),nl,
	write('5. Insert a new word into the dictionary.'),nl,
	write('6. Delete a word from the dictionary.'),nl,
	write('7. Load dictionary from file.'),nl,
	write('8. Save dictionary.'),nl,nl,
	write('0. Exit.'),nl,nl,
	write('Choose '),
	read(Choice),
	clear_console,			% GINETAI KATHARISMOS THS KONSOLAS
	do_on_choice(Choice). 		% GINETAI DIAXEIRHSH THS EPILOGHS TOY XRHSTH
	

%%% APOKRISH TOY PROGRAMMATOS STIS DIAFORES EPILOGES

%% ( 0 ) EKSODOS  APO TO PROGRAMMA

do_on_choice( 0 ) :-
		!,retractall(vocabulary(_)),	% AFAIRESH APO TH MNHMH OLON TON KATHGORHMATON LEKSIKOY
		assert(vocabulary([])),	% MHDENISMOS THS LISTAS TOY LEKSIKOY (ARXIKOPOIHSH)
		retractall(counter(_)),	% AFAIRESH OLON TON COUNTER APO TH MNHMH
		retractall(sentence(_)),	% AFAIRESH OLON TON sentence APO TH MNHMH
		write('Bye'),nl,nl.


%% ( 1 ) BOHTHOS SYGGRAFHS

do_on_choice( 1 ) :-
		read_vocabulary(VocList),	% ANAGNOSH LEKSIKOY APO TH MNHMH	
		voc_is_empty(VocList),!,	% ELEGXOS AN EINAI ADEIO
		run.			% AN EINAI, EPANAFORA STO MENOY

do_on_choice( 1 ) :-
		!,nl,
		write('Please write the sentence '),
		read(Sentence),			% ANAGNOSH THS PROTASHS APO TON XRHSTH
		name(Sentence,Slist),		% METATROPH THS PROTASHS SE LISTA XARAKTHRON
		append(Slist,[32],Koukou),		% PROSTHIKI TOY KENOY STO TELOS THS LISTAS XARAKTHRON. AYTO BOHTHA TO
						% KATHGORHMA sentence_to_list NA TERMATISEI SOSTA
		sentence_to_list(Koukou,Temp,List),!,	% METATROPH THS LISTAS XARAKTHRON SE LISTA LEKSEON (List)
		retract(mylist(List1)),		% FORTOSH THS LISTAS List APO TH MNHMH
		helper(List1).			% KLHSH TOY helper POY EMFANIZEI TA MHNYMATA KAI ALLHLEPIDRA ME TO XRHSTH


%% ( 2 ) EYRESH ENNOION

do_on_choice( 2 ) :-
		read_vocabulary(VocList),	% ANAGNOSH LEKSIKOY APO TH MNHMH	
		voc_is_empty(VocList),!,	% ELEGXOS AN EINAI ADEIO
		run.			% AN EINAI, EPANAFORA STO MENOY

do_on_choice( 2 ) :-
		!,nl,write('Insert the word '),
		read(GWord),				% ANAGNOSH THS LEKSHS
		read_vocabulary(Voclist),			% ANAGNOSH TOY LEKSIKOY
		retract(counter(C)),				% EPANAFORA TOY METRHTH APO TH MNHMH
		find_positions(Voclist,GWord,Poslist,C),!,	% EYRESH TON THESEON TON SYNONYMON LEKSEON
		correct_positions(Poslist,NewPoslist),!,	% DIORTHOSH TON THESEON POY PERIEXONTAI STHN Poslist
		write('The concepts that refer to the word are: '),nl,nl,
		Counter = 1,				% ARXIKOPOIHSH EK NEOY TOY counter
		show_words(Voclist,NewPoslist,Counter),!,	% EMFANISH TON SYNONYMON LEKSEON
		!,run.					% EPANAFORA STO MENOY


%% ( 3 ) EYRESH LEKSEON 

do_on_choice( 3 ) :-
		read_vocabulary(VocList),	% ANAGNOSH LEKSIKOY APO TH MNHMH	
		voc_is_empty(VocList),!,	% ELEGXOS AN EINAI ADEIO
		run.			% AN EINAI, EPANAFORA STO MENOY

do_on_choice( 3 ) :-
		!,nl,write('Insert the concept of this word '),
		read(GConcept),				% ANAGNOSH THS ENNOIAS
		read_vocabulary(Voclist),			% ANAGNOSH TOY LEKSIKOY
		retract(counter(C)),				% EPANAFORA TOY METRHTH APO TH MNHMH
		find_positions(Voclist,GConcept,Poslist,C),!,	% EYRESH TON THESEON TON SYNONYMON LEKSEON
		write('The words that refer to the concept are: '),nl,nl,
		Counter = 1,				
		show_words(Voclist,Poslist,Counter),!,		% EMFANISH TON SYNONYMON LEKSEON
		!,run.					% EPANAFORA STO MENOY


%% ( 4 ) EYRESH SYNONYMON

do_on_choice( 4 ) :-
		read_vocabulary(VocList),	% ANAGNOSH LEKSIKOY APO TH MNHMH	
		voc_is_empty(VocList),!,	% ELEGXOS AN EINAI ADEIO
		run.			% AN EINAI, EPANAFORA STO MENOY

do_on_choice( 4 ) :-
		!,nl,write('Insert a word '),
		read(GWord),				% ANAGNOSH THS LEKSHS
		nl,write('Insert a concept of this word '),
		read(GConcept),				% ANAGNOSH THS ENNOIAS
		read_vocabulary(Voclist),			% ANAGNOSH TOY LEKSIKOY
		retract(counter(C)),				% EPANAFORA TOY METRHTH APO TH MNHMH
		find_positions(Voclist,GConcept,Poslist,C),!,	% EYRESH TON THESEON TON SYNONYMON LEKSEON
		write('The synonyms are: '),nl,nl,
		Counter = 1,				% ARXIKOPOIHSH EK NEOY TOY counter
		show_words(Voclist,Poslist,Counter),!,		% EMFANISH TON SYNONYMON LEKSEON
		!,run.					% EPANAFORA STO MENOY


%% ( 5 ) EISAGOGH LEKSHS STO LEKSIKO

do_on_choice( 5 ):-
		nl,nl,
		write('Please type a "correct" word '),
		read(Word),				% ANAGNOSH THS NEAS LEKSHS
		write('Now give a concept for the word '),
		read(Concept),				% ANAGNOSH THS ENNOIAS THS LEKSHS
		read_vocabulary(VocList),nl,			% ANAGNOSH TOY LEKSIKOY APO TH MNHMH
		not(check_existance(Word,Concept)),		% ELEGXEI AN H LEKSH ME THN SYGKEKRIMENH ENNOIA YPARXEI STO LEKSIKO
		retract(vocabulary(List)),			% AN OXI
		assert(vocabulary( [Word|[Concept|List]] )),	% SYMPERILIPSH THS LEKSHS STH LISTA TOY LEKSIKOY
		write('The word was inserted to the dictionary. '),
		nl,!,
		run.					% EPISTROFH STO BASIKO MENOY

do_on_choice( 5 ):- 
		!,nl,
		write('This word already exists in the vocabulary '),!, % AN EINAI KATAGEGRAMENH
		run.


%% ( 6 ) DIAGRAFH LEKSHS APO TO LEKSIKO

do_on_choice( 6 ):-
		read_vocabulary(VocList),	% ANAGNOSH LEKSIKOY APO TH MNHMH	
		voc_is_empty(VocList),!,	% ELEGXOS AN EINAI ADEIO
		run.			% AN EINAI, EPANAFORA STO MENOY


do_on_choice( 6 ):-
	nl,write('Which word to delete from the dictionary '),
	read(Word),nl,				% ANAGNOSH THS LEKSHS PROS DIAGRAFH
	remove_word_from_voc(Word),!,		% ELEGXOS KAI AFAIRESH THS LEKSHS APO TO LEKSIKO
	nl,write('Which is the concept '),
	read(Concept),nl,				% ANAGNOSH THS LEKSHS PROS DIAGRAFH
	remove_word_from_voc(Concept),!,		% ELEGXOS KAI AFAIRESH THS LEKSHS APO TO LEKSIKO


	write('The word is deleted from the dictionary.'),	% EPIBEBAIOSH DIAGRAFHS 
	nl,nl,!,
	run.					% EPISTROFH STO BASIKO MENOY

do_on_choice( 6 ):-
	!,nl,					% AN DEN YPARXEI EMFANISH SXETIKOY MHNYMATOS
	write('Such word does not exist in the dictionary!'),
	nl,nl,!,
	run.					% EPISTROFH STO BASIKO MENOY


% ( 7 ) FORTOSH LEKSIKOY APO ARXEIO

do_on_choice( 7 ) :-
	!, nl,
	write('You are about to load a dictionary. All the entries tha have not'),nl,
	write('been saved in it will be lost. Do you want to proceed ( y / n ) '),
	read(Choose),
	proceed_or_not(Choose),nl,		% ENHMERONEI TON XRHSTH OTI EINAI PITHANO NA XATHOYN DEDOMENA
					% AN ANOIKSEI ENA LEKSIKO PROTOY SOSEI TYXON LEKSEIS POY EXEI HDH
					% GRAPSEI STH MNHMH
	write('Give the filename of the dictionary to be loaded: '), 
	read(File),			% ANAGNOSH TOY ONOMATOS TOY ARXEIOY
	open(File),			% ANOIGMA KAI ELEGXOS, AN YPARXEI...
	retractall(vocabulary(_) ),		% AFAIRESH TOY LEKSIKOY APO TH MNHMH 
	assert( vocabulary([]) ),		% TOPOTHETHSH TOY ADEIOY LEKSIKOY 
	repeat, 				% EPANALHPSH MESO Backtracking MEXRI TO end_of_file
	read(Word), 			% ANAGNOSH LEKSHS
	ins_word(Word), 			% EISAGOGH STO LEKSIKO 
	Word == end_of_file,		% AN H LEKSH EINAI TO end_of_file
 	!, nl,				% APOKOPH GIA TO repeat  
	write('File loaded.'), nl,		% MHNYMA EPITYXIAS 
	seen,				% KLEISIMO TOY ARXEIOY
	not(flatten_voc),!,			% EISAGOGH OLON TON PROSORINON KATHGORHMATON word
					% STH LISTA TOY LEKSIKOY TO not XRHSIMOPOIEITAI EPEIDH
					% TO KATHGORHMA flatten_voc PANTA APOTYGXANEI
	reformat_list(vocabulary(VocList)),	% ANTISTREFEI TO VocList
	run.				% EPISTROFH STO BASIKO MENOY


%% ( 8 ) APOTHIKEYSH TOY LEKSIKOY SE ARXEIO  

do_on_choice( 8 ):-
		read_vocabulary(VocList),	% ANAGNOSH LEKSIKOY APO TH MNHMH	
		voc_is_empty(VocList),!,	% ELEGXOS AN EINAI ADEIO
		run.			% AN EINAI, EPANAFORA STO MENOY

do_on_choice( 8 ):- 
		!,
		nl,nl,				% AN DEN EINAI...
		write('Give the name of the file to which the'),nl,
		write('dictionary will be saved '),
		read(File),			% ANAGNOSH TOY ARXEIOY STO OPOIO THA APOTHIKEYTEI
		write_voc_to_file( File ),!,		% EGGRAFH THS LISTAS TOY LEKSIKOY STO ARXEIO
		run.				% EPISTROFH STO BASIKO MENOY


/* 
	METATROPH PROTASHS SE LISTA LEKSEON: TO KATHGORHMA AYTO DEXETAI STHN EISODO MIA LISTA 
	XARAKTHRON (OYSIASTIKA PROKEITAI GIA THN PROTASH POY EDOSE O XRHSTHS H OPOIA ME XRHSH
	THS name METATRAPHKE SE LISTA XARAKTHRON PRIN THN KLHSH TOY PARONTOS KATHGORHMATOS).
	H LEITOYRGIA TOY GENIKA PERILAMVANEI TH ANAGNOSH XARAKTHRON KAI TOPOTHETHSH SE MIA LISTA 
	Temp EOS OTOY DIAVASOYME TO KENO (= [32]). TOTE APLA METATREPOYME THN LISTA Temp SE 
	ALFARITHMITIKO TO OPOIO KATOPIN EISAGETAI STHN LISTA List.
*/

sentence_to_list([],Temp,List):- 
				reverse(List,List1),		% ANTISTREFOYME TH LISTA GIA NA TH FEROYME STHN 
							% ARXIKH THS MORFH
				assert(mylist(List1)),	% KATAXOROYME TH LISTA LEKSEON STH MNHMH
				!.

sentence_to_list([KH|KT],Temp,List):-
				KH \== 32,			% AN EXOYME OPOIODHPOTE ALLO XARAKTHRA PLHN TOY KENOY
				H is KH,				% KRATOYME TON XARAKTHRA 
				sentence_to_list(KT,[H|Temp],List). 	% PROXOROYME OTHONTAS TON XARAKTHRA STH KEFALH THS TEMP LISTAS
sentence_to_list([KH|KT],Temp,List):-
				KH == 32,			% AN EXOYME FTASEI SE KENO (DHLADH AKOLOYTHEI KAINOYRIA LEKSH)
				reverse(Temp,RevTemp),	
				name(Koukou,RevTemp),		% METATREPOYME TH LISTA XARAKTHRON SE ALFARITHMITIKO
				sentence_to_list(KT,[],[Koukou|List]).	% KALOYME TO AYTO KATHGORHMA ME List NA PERIEXEI TH NEA LEKSH


/*
	BOHTHOS SYGGRAFHS: TO KATHGORHMA AYTO STHN PAROYSA EKDOSH DE LEITOYRGEI SOSTA. LEITOYRGEI ORTHA 
	MONON TO KOMMATI POY XRHSIMOPOIEI THN sentence_to_list/3.
*/

helper( [] ):- 
		retract(sentence(Current)),		% ANAKALEI THN PROTASH OPOS EXEI DIAMORFOTHEI OS TORA
		write('The final sentence is '),nl,nl,	
		write(Current),run,!.			% KAI THN EMFANIZEI

helper( [H2|T2] ):-
		retract(sentence(Current)),		% ANAKALEI THN PROTASH OPOS EXEI DIAMORFOTHEI OS TORA
		name(Current,CurrentString),		% TH METATREPEI SE LISTA XARAKTHRON
		read_vocabulary(VocList),		% ANAGNOSH TOY LEKSIKOY APO TH MNHMH
		not(member(H2,VocList)),		% AN H LEKSH STHN KEFALH DEN EINAI MELOS TOY LEKSIKOY
		name(H2,CharArray),				% THN KANOYME APLOS APPEND STHN MEXRI TORA
		append(CharArray,[32],CharArray2),			% PROTASH KAI STH SYNEXEIA AFOY METATREPSOYME
		append(CurrentString,CharArray2,FinalSentenceString),	% TH LISTA XARAKTHRON SE ALFARITHMITIKO KATAXOROYME
		name(FinalSentence,FinalSentenceString),		% THN NEA TREXOYSA PROTASH STH MNHMH
		assert(sentence(FinalSentence)),
		helper( T2 ).

helper( [H2|T2] ):-
		retract(counter(C)),				% EPANAFORA TOY METRHTH APO TH MNHMH
		read_vocabulary(VocList),			% ANAGNOSH TOY LEKSIKOY APO TH MNHMH
		find_positions(VocList,H2,Poslist,C),!,		% EYRESH TON THESEON TON SYNONYMON LEKSEON
		correct_positions(Poslist,NewPoslist),!,	% DIORTHOSH TON THESEON OSTE NA LAMVANOYME TIS ENNOIES
		write('Choose a concept for '),write(H2),nl,
		Counter = 1,				
		show_words(VocList,NewPoslist,Counter),!,	% EMFANISH TON SYNONYMON LEKSEON
		nl,nl,write('Your choice '),read(Choice),
		member(TheWord,NewPoslist,Choice),	% EYRESH THS THESHS THS LEKSHS
		C = 1,
		find_positions(VocList,TheWord,Poslist,C),!,	% EYRESH TON THESEON TON SYNONYMON LEKSEON
		write('The appropriate words are: '),nl,nl,
		Counter = 1,
		show_words(VocList,Poslist,Counter),!,	% EMFANISH TON SYNONYMON LEKSEON
		nl,nl,write('PIck a synonym '),read(Choice),	% ANAGNOSH EPILOGHS TOY XRHSTH
		member(TheWord,Poslist,Choice),		% EYRESH THS EPILEGMENHS LEKSHS

		
		retract(sentence(Current)),				% APO EDO KAI KATO APLA ENHMERONETAI 
		name(Current,CurrentString),				% H TREXOYSA PROTASH KAI KATAGRAFETAI 
		name(TheWord,CharArray),				% STH MNHMH...
		append(CharArray,[32],CharArray2),
		append(CurrentString,CharArray2,FinalSentenceString),
		name(FinalSentence,FinalSentenceString),
		assert(sentence(FinalSentence)),
		helper( T2 ).


/*
	 EYRESH THESEON SYNONYMON: TO KATHGORHMA AYTO DEXETAI SAN ORISMATA TO LEKSIKO POY VRISKETAI 
	STH MNHMH THN LEKSH GIA THN OPOIA PSAXNOYME KATAXORHSEIS STO LEKSIKO, MIA LISTA STHN OPOIA APOTHIKEYONTAI
	OI THESEIS TON LEKSEON POY VRETHIKAN KAI ENAN METRHTH.
	TELIKA EPISTREFETAI H LISTA TON THESEON TON SYNONYMON APO THN OPOIA ME TO member/3 MPOROUME NA ODHGHTHOYME
	ME ASFALEIA STIS EPITHIMHTES LEKSEIS.
*/

find_positions([],Goal,PosList,C):- !.
find_positions([VHead|VTail],Goal,[PH|PT],C):-
				Goal == VHead,
				PH is C - 1,
				C1 is C + 1,
				find_positions(VTail,Goal,PT,C1).

find_positions([VHead|VTail],Goal,Poslist,C):-
				Goal \== VHead,
				C1 is C + 1,
				find_positions(VTail,Goal,Poslist,C1). 


/*
	DIORTHOSH TON THESEON: EPEIDH STO ARXEIO MAS KRATOYNTAI KAI OI LEKSEIS ALLA KAI OI ENNOIES 
	ME TH MORFH POY ANAFERETAI STHN ARXH TOY EGGRAFOY PREPEI OTAN PSAXOYME  ENNOIES NA
	DIORTHONOYME TH THESH OSTE NA APOFEYGETAI H KATA LATHOS ANAGNOSH LEKSEON ANTI ENNOION.
	STHN ANAGKH AYTH MAS OTHEI KYRIOS TO KATHGORHMA find_positions/4 POY EINAI TO AMESOS PROHGOYMENO 
	AYTOY.
*/

correct_positions([],NewPoslist):- !.
correct_positions([PH|PT],[NPH|NPT]):-
				NPH is PH + 2,
				correct_positions(PT,NPT).


/*
	EMFANISH TON SYNONYMON LEKSEON: OI EGGRAFES EMFANIZONTAI ME TH MORFH
	1. Leksi01
	2. Leksi02
	.
	.
	.
*/

show_words(Voclist,[],Counter):- !.
show_words(Voclist,[PosHead|PosTail],Counter):-
			member(X,Voclist,PosHead),!, 
			write(Counter),write('. '),write(X),nl,
			Counter1 is Counter + 1,
			show_words(Voclist,PosTail,Counter1).


/*
	ELEGXOS GIA YPARKSH LEKSHS ME ENNOIA Concept STO LEKSIKO
*/

check_existance(Word,Concept):-
			member(Word,VocList,WPosition),!,
			CPosition is WPosition + 1,
			member(Concept,VocList,CPosition),!,fail.

	
/*
	ANAGNOSH TOY LEKSIKOY APO TH MNHMH
*/

read_vocabulary(VocList):-
	retract(vocabulary(VocList)),
	assert(vocabulary(VocList)),!.


/*
	TO voc_is_empty ELEGXEI AN TO LEKSIKO EINAI KENO KAI TYPONEI TO ANALOGO MHNYMA
*/

voc_is_empty([]):- 
	nl,nl,
	write('No vocabulary has been loaded or the vocabulary is empty!! '),nl,
	write('Please select one first or insert some words before selecting this option!'),nl,!.	


/*
	EGGRAFH TOY LEKSIKOY STO ARXEIO File
*/

write_voc_to_file(File):-
	tell(File),
	read_vocabulary(VocList),
	write_file(VocList),nl,
	write('The dictionary was saved to this file'),
	close(File),nl.


/* 
	H remove_word_from_voc DIAGRAFEI TH LEKSH Word APO TO YPARXON LEKSIKO STH MNHMH
	AFOY PROTA ELEGKSEI AN EINAI MELOS TOY. O XORISMOS GINETAI ME XRHSH THS append OPOY 
	XORIZEI TH LISTA TOY LEKSIKOY SE DYO NEES LISTES, ETSI OSTE H DEYTERH NA EXEI OS KEFALH
	TO Word KAI EPEITA SYNNENONEI TIS DYO AYTES LISTES PARALEIPONTAS TO Word 
*/

remove_word_from_voc(Word):-
	read_vocabulary(VocList),
	member(Word,VocList),
	append(HeadList,[Word|TailList],VocList),
	append(HeadList,TailList,NewVocList),!,
	retract(vocabulary(_)),
	assert(vocabulary(NewVocList)).


/*
	EISAGOGH THS LEKSHS POY DIAVAZOYME APO TO LEKSIKO STH MNHMH
*/

ins_word(end_of_file) :- !.
ins_word(Word) :- 
	assert( word( Word ) ).


/* 
	TO flatten_voc PAIRNEI ENA ENA TA KATHGORHMATA word, 
	APO TH MHNMH KAI TA BAZEI OLA STH LISTA TOY LEKSIKOY. 
	TO flatten_voc APO TON ORISMO TOY PANTA APOTYGXANEI 
*/

flatten_voc:- 
	retract(word(Word)),
	retract(vocabulary(List)),
	assert(vocabulary([Word|List])),
	!,flatten_voc. 


/*
	ANTISTROFH LISTAS
*/

reformat_list(vocabulary(VocList)):-
			reverse(VocList,NewVocList),
			retract(vocabulary(VocList)),
			assert(vocabulary(NewVocList)).


/*
	ELEGXOS AN YPARXEI ARXEIO File KAI ANOIGMA TOY
*/

open(File):-
	catch(X,see(File)),
	open_aux(X).
	

open_aux(0).

open_aux(31):-
	nl,write('No such file is found!'),
	nl,!,run.


/* 
	EGGRAFH TON LEKSEON STO REYMA EKSODOY ME TH MORFH GEGONOTON 
	KAI KLEISIMO TOY REYMATOS 
*/

write_file([]):-!,told.
write_file([HeadWord|TailWords]):-
	write(HeadWord),
	write('. '),!,
	write_file(TailWords).


/*
	LAMVANEI APO TON XRHSTH THN EPILOGH TOY NA SYNEXISEI H 
	NA AKYROSEI KAI ANTIDRA ANALOGOS
*/

proceed_or_not(Choose):-
			Choose == 'y'.
	
proceed_or_not(Choose):-
			Choose == 'n', run, fail.


/*
	 KATHARISMOS KONSOLAS 
*/

clear_console:-
	system_menu(1,edit,select_all),
  	system_menu(1,edit,clear). 
