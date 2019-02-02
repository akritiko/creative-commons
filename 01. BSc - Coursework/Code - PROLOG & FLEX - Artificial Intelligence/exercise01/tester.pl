/*
	TEXNHTH NOHMOSYNH
	ERGASIA 1
	KRHTIKOS APOSTOLOS
	AEM: 914
*/


/*
	Perigrafoume tin arxiki kai teliki katastasi. H arxiki katastasi 
	opos fainetai kai stin eksodo tou programmatos einai h --> bbb www.
	Me b,w apeikonizontai ta maura, aspra plakidia eno h kenh thesi 
	anaparistatai me to keno.
	H teliki katastasi (diladi h epithimiti einai h --> www bbb.

	SHMEIOSH: Kathe plakidio perigrafetai os eksis: (Position, Value).
	To Position dilonei tin thesi pou prepei na katexei to plakidio 
	ston monodiastato pinaka (p.x meta apo allagi). H Value periexei
	tin pliroforia pou kouvalaei to plakidio diladi an einai aspro (w)
	mauro (b) h to keno ( ).
*/

/*
	To programma ksekina kalontas to katigorima run/0. Emfanizei ena menou 
	sto opoio o xristis epilegei me poion algorithmo thelei na anazitisei
	ti lysi... Katopin otan o algorithmos teleiosei mporei na kanei mia 
	nea anazitisi me allon algorithmo i na termatisei to programma
*/


initial_state([ 
		(1,b),(2,b),(3,b),(4,' '),(5,w),(6,w),(7,w) 
	     ]).

goal([ 
	(1,w),(2,w),(3,w),(4,' '),(5,b),(6,b),(7,b) 
    ]).

/* 
	Orizoume ton operatos pou perigrafei tous tropous me tous opoious mporei 
	na kinithei ena plakidio. Stin sugekrimeni ylopoiisi anti na metakinoume
	ta plakidia metakinoume to keno tetragono (1,2 h 3 theseis pros ta deksia
	h ta arister, me tin ptoypothesi oti to keno den ksefeugeia apo ta oria 
	tou monodiastatou pinaka mas -7 theseon-).
*/

operator(P,FP):-
		member((X,' '),P), %VRISKEI TO KENO TETRAGONO
		move(X,X1),	%APOFASIZEI POY THA METAKINITHEI
		member((X1,T),P), %VRISKEI TO PLAKIDIO POY YPHRXE EKEI POY THA METAKINHTHEI TO KENO
		
		/*
		Antallasei theseis sto keno plakidio kai se auto me to opoio tha antikatstathei.
		*/

		replace((X1,T),(X,T),P,P1), 
		replace((X,' '),(X1,' '),P1,NP),

		/*
		Taksinomei ton pinaka pou proekypse me skopo oi allages theseon (pou exoun 
		katoxyrothei stin metavliti Position) na ginoun kai sti diataksi tou pinaka.
		Gia tin taksinomisi auti xrisimopoieitai to katigorima tis PROLOG sort/2
		*/
		
		sort(NP,FP).


/*
	To katigorima move/2 perigrafei tous tropous me tous opoious mporei na kinithei 
	to keno tetragono. Oi kiniseis pou epitrepontai einai se ena geitoniko tetragono,
	mia thesi meta apo ena geitoniko tetragono kai dyo theseis meta apo ena geitoniko
	tetragono. Auta ta tria idi ylopoiountai sto katigorima move/2 kai gia tis dyo 
	kateythinseis, diladi kai gia aristera kai gia deksia
*/

move(X,NX):-NX is X-3,NX>0. 	%KINHSH TRION TETRAGONON PISO
move(X,NX):-NX is X+2,NX=<7. 	%KINHSH DYO TETRAGONON MPROSTA
move(X,NX):-NX is X-2,NX>0. 	%KINHSH DYO TETRAGONON PISO
move(X,NX):-NX is X+3,NX=<7.	%KINHSH TRION TETRAGONON MPROSTA
move(X,NX):-NX is X-1,NX>0. 	%KINHSH ENOS TETRAGONOY PISO
move(X,NX):-NX is X+1,NX=<7. 	%KINHSH ENOS TETRAGONOU MPROSTA


/*
	To katigorima replace/4 xrisimopoieitai gia na antallaxtei to keno tetragono me
	to plakidio pou vrisketai sti thesi pou epilextike apo ti move/2
*/

replace(_,_,[],[]).
replace(Old,New,[Old|T],[New|T]):- !.
replace(Old,New,[H|T],[H|T1]):-
				replace(Old,New,T,T1).


/*
	Parakato ylopoiountai oi zitoumenes anazitiseis me tous algorithmous DFS (Depth First)
	- tyflos - kai BFS (Best First) - eyristikos -. Gia ton teleutaio de exoume 2 ylopoiiseis,
	mia pou ypologizei posa plakidia vriskontai se lathos thesi kai mia pou ypologizei poso 
	apexei to kathe kommati apo tin epithimiti (teliki) tou thesi!
*/



% YLOPOIHSH DFS GIA KLEISTO SYNOLO 
% (O ALGORITHMOS DOTHIKE ETOIMOS)


depth_first_cl([[State|Path]|_],_,[State|Path]):-
						goal(State).

depth_first_cl([[State|Path]|RestFSet],ClosedSet,Solution):-
							retract(counter(C)),
							%AYKSANEI TON COUNTER KATHE FORA POU 
							%KALEITAI TO KATHGORHMA depth_first_cl/3
							inc_counter(C,NC),
							expand(State,Path,ChildStates),
							prune(ChildStates,ClosedSet,P_ChildStates),
							append(P_ChildStates,RestFSet,NewFSet),
							depth_first_cl(NewFSet,[State|ClosedSet],Solution).

prune([],_,[]) :- !.

prune([[State|Path]|RestChilds],ClosedSet,[[State|Path]|RestPChilds]) :-
									not member(State,ClosedSet), !,
									prune(RestChilds,ClosedSet,RestPChilds).

prune([_|RestChilds],ClosedSet,RestPChilds) :-
						prune(RestChilds,ClosedSet,RestPChilds).

go_depth_first_cl(Solution) :- 
				initial_state(IS),
				depth_first_cl([[IS]],[],Solution1),
				reverse(Solution1,Solution).

expand(State,Path,Children) :-
				findall([Child,State|Path],
					operator(State,Child),
					Children).

/*
	Me to katigorima auto ekteleitai anazitisi me ton algorithmo Depth First.
*/

run_dfs:-
	asserta(counter(0)), %ARXIKOPOIEITAI O METRHTHS SE 0
	nl,write('1. Using Depth First Algorithm With Closed Set: '),nl,nl,
	go_depth_first_cl(Solution),
	print_solution(Solution),nl,
	write('Steps: '),
	retract(counter(FC)), %ANAKALEITAI H TELIKH TIMH TOY COUNTER
	write(FC),nl. 



% YLOPOIHSH BEST FIRST GIA KLEISTO SYNOLO 
% (O ALGORITHMOS TROPOPOIITHIKE KATALLILA)


go_best_first_cl(Solution):-
	initial_state(IS),
	goal(FS),
	heuristic_mismatch(IS,FS,V),
	best_first_cl([V-[IS]],Solution1,FS,[]),
	reverse(Solution1,Solution).


best_first_cl([Value-[FinalState|Path]|_],[FinalState|Path],FinalState,ClosedSet) :- !.

best_first_cl([BestPath|RestPaths],Solution,FS,ClosedSet):-
							retract(counter(C)),
							inc_counter(C,NC),
							next_states(BestPath,NewPaths,FS,ClosedSet,NClosedSet),
							append(NewPaths,RestPaths,Frontier),
							keysort(Frontier,OrderedFrontier),
							best_first_cl(OrderedFrontier,Solution,FS,NClosedSet).


next_states(V-[State|Path],[],FS,ClosedSet,ClosedSet):-
								member(State,ClosedSet), !.
					
next_states(V-[State|Path],NewPaths,FS,ClosedSet,[State|ClosedSet]):-
								findall(HV-[NewState,State|Path],
									(
									operator(State,NewState),
									heuristic_mismatch(NewState,FS,HV)
									),
								NewPaths
				     				). 
								

/*
	Heuristic_mismatch: H proti euristiki synartisi pou anazita me vasi posa 
	plakidia vriskontai se lathos thesi.
*/

heuristic_mismatch([],_,0).
heuristic_mismatch([(X,T)|R],FinalState,V) :-
				member((X,T),FinalState), !,
				heuristic_mismatch(R,FinalState,V).

heuristic_mismatch([_|R],FinalState,V) :-
				heuristic_mismatch(R,FinalState,V1),
				V is V1 + 1.


run_bfs1:-
	asserta(counter(0)), %ARXIKOPOIEITAI O METRHTHS SE 0
	nl,write('1. Using Best First Algorithm With Closed Set: '),nl,nl,
	go_best_first_cl(Solution),
	print_solution(Solution),nl,
	write('Steps: '),
	retract(counter(FC)), %ANAKALEITAI H TELIKH TIMH TOY COUNTER
	write(FC),nl. 	
	


go_best_first_cl_alter(Solution):-
	initial_state(IS),
	goal(FS),
	heuristic_distance(IS,FS,V),
	best_first_cl_alter([V-[IS]],Solution1,FS,[]),
	reverse(Solution1,Solution).

best_first_cl_alter([Value-[FinalState|Path]|_],[FinalState|Path],FinalState,ClosedSet) :- !.

best_first_cl_alter([BestPath|RestPaths],Solution,FS,ClosedSet):-
							retract(counter(C)),
							inc_counter(C,NC),
							next_states_alter(BestPath,NewPaths,FS,ClosedSet,NClosedSet),
							append(NewPaths,RestPaths,Frontier),
							keysort(Frontier,OrderedFrontier),
							best_first_cl_alter(OrderedFrontier,Solution,FS,NClosedSet).


next_states_alter(V-[State|Path],[],FS,ClosedSet,ClosedSet):-
							member(State,ClosedSet), !.
					
next_states_alter(V-[State|Path],NewPaths,FS,ClosedSet,[State|ClosedSet]):-
								findall(HV-[NewState,State|Path],
									(
									operator(State,NewState),
									heuristic_distance(NewState,FS,HV)
									),
								NewPaths
				     				). 


heuristic_distance([],_,0).
heuristic_distance([(X,T)|R],FinalState,V) :-
				member((XF,T),FinalState), !,
				Dis is abs(XF-X),
				heuristic_distance(R,FinalState,V1),
				V is Dis + V1.
			

run_bfs2:-
	asserta(counter(0)), %ARXIKOPOIEITAI O METRHTHS SE 0
	nl,write('1. Using Best First Algorithm With Closed Set2: '),nl,nl,
	go_best_first_cl_alter(Solution),
	print_solution(Solution),nl,
	write('Steps: '),
	retract(counter(FC)), %ANAKALEITAI H TELIKH TIMH TOY COUNTER
	write(FC),nl. 	

		


/*
	Ta parakato katigorimata prostethikan gia na rythmisoun ton tropo 
	emfanisis ton apotelesmaton ton algorithmon.
*/


/* 	
	To katigorima inc_counter/2 dexetai tin trexousa timi tou counter(C) kai afou tin
	auksisi eggrafei sti mnimi to gegonos counter(NC) opou NC to C auksimeno kata 1
*/


inc_counter(C, NC):-
			NC is C + 1,
			asserta(counter(NC)).



/*
	To katigorima print_solution/1 ousiastika ektyponei tin lista Solution pou exei 
	paraxthei apo ton DFS.
*/


print_solution([]):-!.
print_solution([H|T]):-
			choper(H),nl,
			print_solution(T).

/*
	To katigorima chopper/1 dexetai san orisma to ekastote Head tis listas Solution
	pou prokeitai na ektypothei apo to print_solution/1. Auto exei ti morfi mias listas 
	me stoixeia pou exoun morfi (Position, Value). Ayto pou ousiastika kanei einai na 
	krata kai telika na emfanizei monon to value pou einai kai to dedomeno pou mas
	endiaferei mias kai i thesi tou kathe plakidiou fainetai stin eksodo ksekathara
*/


choper([]):-!.
choper([(Pos,Val)|T1]):-
			write(Val),
			choper(T1).

/* 
	To katigorima run/0 apotelei tin ekkinisi tou programmatos. Dinei sto xristi ti
	dynatotita ploigisis sto programma meso enos menou pou diaxeirizetai tous 3
	tropous anazitisis.
*/


run:-
	!,nl,nl,
	clear_console,
	write('1. Search using Depth First Algorithm with closed set'),nl,nl,
	write('2. Search using Best First Algorithm with closed set'),nl,
	write('         (heuristic_mismatch function is used)'),nl,nl,
	write('3. Search using Best First Algorithm with closed set'),nl,
	write('         (heuristic_distance function is used)'),nl,nl,
	write('4. Exit'),nl,nl,
	write('Choose'),
	read(Choice),
	do_on_choice(Choice).

/*
	To katigorima do_on_choice/1 pairnei san orisma tin timi pou o xristis exei dosei
	sti metavliti Choice kai epilegei poia synartisi tha prepei na kalesei. Episeis 
	elegxei gia lanthasmeni eisodo kai epitrepei sto xristi na termatisei to programma
*/


% ME AYTHN THN EPILOGH GINETAI ANAZHTHSH ME XRHSH TOY ALGORITHMOY DEPTH FIRST GIA KLEISTO SYNOLO
do_on_choice( 1 ):-
		run_dfs,nl,
		write('Do you want to continue searching with another algorithm? '),nl,
		write('Yes (y) or No (n)? '),
		read(Confirm),
		wanna_loop(Confirm).

% ME AYTHN THN EPILOGH GINETAI ANAZHTHSH ME XRHSH TOY ALGORITHMOY BEST FIRST GIA KLEISTO SYNOLO
% XRHSIMOPOIEITAI OS EYRISTIKH SYNARTHSH H heuristic_mismatch
do_on_choice( 2 ):-
		run_bfs1,nl,
		write('Do you want to continue searching with another algorithm? '),nl,
		write('Yes (y) or No (n)? '),
		read(Confirm),
		wanna_loop(Confirm).

% ME AYTHN THN EPILOGH GINETAI ANAZHTHSH ME XRHSH TOY ALGORITHMOY BEST FIRST GIA KLEISTO SYNOLO
% XRHSIMOPOIEITAI OS EYRISTIKH SYNARTHSH H heuristic_distance
do_on_choice( 3 ):-
		run_bfs2,nl,
		write('Do you want to continue searching with another algorithm? '),nl,
		write('Yes (y) or No (n)? '),
		read(Confirm),
		wanna_loop(Confirm).

% ME AYTHN THN EPILOGH TERMATIZETAI TO PROGRAMMA
do_on_choice( 4 ):- !.

% ME AYTHN THN EPILOGH ELEGXETAI LANTHASMENH EISODOS ARITHMOY KAI EPISTREFETAI KATALLHLO MHNYMA
do_on_choice( _ ):-
		nl,write('Invalid Input, give a number between [1-4]!'),!,run.


/*
	To katigorima wanna_loop/1 rota ton xristi an thelei na synexisei me kapoio allo algorithmo
	anazitisis otan teleiosei me mia proigoumeni.
*/


wanna_loop(Confirm):-
			Confirm == 'n',!.

wanna_loop(Confirm):-
			Confirm == 'y',
			run.
		


/*
	To katigorima clear_console/0 katharizei tin consola apo proigoume apotelesmata etsi oste na 
	einai safi kai euanagnosta ta apotelesmata tis ekastote anazitisis
*/

clear_console:-
	system_menu(1,edit,select_all),
  	system_menu(1,edit,clear).





go_best_first_cl_bonus(Solution):-
	initial_state(IS),
	goal(FS),
	heuristic_bonus(IS,V),
	best_first_cl_bonus([V-[IS]],Solution1,FS,[]),
	reverse(Solution1,Solution).

best_first_cl_bonus([Value-[FinalState|Path]|_],[FinalState|Path],FinalState,ClosedSet) :- !.

best_first_cl_bonus([BestPath|RestPaths],Solution,FS,ClosedSet):-
							retract(counter(C)),
							inc_counter(C,NC),
							next_states_bonus(BestPath,NewPaths,FS,ClosedSet,NClosedSet),
							append(NewPaths,RestPaths,Frontier),
							keysort(Frontier,OrderedFrontier),
							best_first_cl_bonus(OrderedFrontier,Solution,FS,NClosedSet).


next_states_bonus(V-[State|Path],[],FS,ClosedSet,ClosedSet):-
							member(State,ClosedSet), !.
					
next_states_bonus(V-[State|Path],NewPaths,FS,ClosedSet,[State|ClosedSet]):-
								findall(HV-[NewState,State|Path],
									(
									operator(State,NewState),
									heuristic_bonus(NewState,HV)
									),
								NewPaths
				     				). 


heuristic_bonus([],0).
heuristic_bonus([(X,T)|R],V):-
				checkside(X,T,V,V1),
				heuristic_bonus(R,V1).

checkside(X,T,V,V1):-
		T == w, 
		X>4,
		V1 is V + 1. 

checkside(X,T,V,V1):-
		T == b,
		X<4,
		V1 is V + 1.

checkside(X,T,V,V1):-
		T == ' ',
		X \= 4,
		V1 is V + 1.

checkside(X,T,V,V1):-
		!.
			

run_bfs3:- 
	asserta(yo(0)),
	retract(yo(V)),
	asserta(counter(0)), %ARXIKOPOIEITAI O METRHTHS SE 0
	nl,write('5. Using Best First Algorithm With Closed Set3: '),nl,nl,
	go_best_first_cl_bonus(Solution),
	print_solution(Solution),nl,
	write('Steps: '),
	retract(counter(FC)), %ANAKALEITAI H TELIKH TIMH TOY COUNTER
	write(FC),nl. 	