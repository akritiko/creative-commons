

/* 
	Edo provaletai i grammatiki pou dothike se morfi block diagrammatos
*/



/*
	katigorima prolog_clause: Dexetai tin eisosdo apo to xristi kai tin metatrepei 
	eite se gegonos eite se kanona
*/

prolog_clause(FACT) --> 
			fact(FACT).

prolog_clause(RULE) --> 
			rule(RULE).


/*
	katigorima fact: edo metatrepetai (an einai dynato kati tetoio) i protasi tou
	xristi se gegonos. H morfi gegonoton pou ypostirizetai mporei na exei ena i
	dyo orismata.
*/

fact(FACT) --> 
		argument(ARG), 
		property(PROP),
		{FACT=..[PROP,ARG]}.

fact(FACT) --> 
		argument(ARG1), 
		relation(REL), 
		argument(ARG2),
		{ARG1 \= ARG2},
		{FACT=..[REL,ARG1,ARG2]}.


/*
	katigorima rule: edo metatrepetai (an einai dynato kati tetoio) i protasi tou
	xristi se kanona.
*/

rule(RULE) --> 
		head(HEAD), 
		[if], 
		body(BODY),
		{RULE=(HEAD:- BODY)}.
		

/*
	katigorima argument: trofodotei mia metavliti i ena atomo sto orisma tou 
	katigorimatos fact.
*/

argument(VARIABLE) --> 
			variable(VARIABLE).
argument(PERSON) -->
			person(PERSON).


/*
	katigorima property: epistrefei to onoma tou katigorimatos pou tha paraxthei 
	sti synexeia apo ti fact.
*/

property(NP) --> 
			verb(VERB), 
			noun_phrase(NP).


/*
	katigorima relation: epistrefei to onoma tou katigorimatos pou tha paraxthei 
	sti synexeia apo ti fact.
*/

relation(NP) --> 
			verb(VERB), 
			noun_phrase(NP), 
			proposition(PROPOSITION).

relation(NP) --> 
			verb(VERB), 
			determiner(DETERMINER), 
			noun_phrase(NP), 
			proposition(PROPOSITION).


/*
	katigorima head: epistrefei tin kefali 	tou kanona pou tha paraxthei sti synexeia
	apo to katigorima rule.
*/

head(FACT) --> 
		fact(FACT).

/*
	epistrefei to soma tou kanona (ena i perissotera gegonota) pou tha paraxthei sti 
	synexeia apo to katigorima rule.
*/

body(FACT) --> 
		fact(FACT).

body(BODY) --> 
		fact(FACT), 
		[and], 
		body(BODY2),
		{BODY=(FACT,BODY2)}.


/*	
	katigorima noun_phrase: epistrefei to onoma tou katigorimatos pou tha paraxthei 
	sti synexeia apo ti fact.	
*/


noun_phrase(NOUN) --> 
			noun(NOUN).

noun_phrase(ADJECTIVE) -->
			adjective(ADJECTIVE).


/*
	Edo ylopoioume to leksiko tou programmatos 
*/

verb(is) --> [is].
verb(has) --> [has].

determiner(the) --> [the]. 

noun(father) --> [father].
noun(mother) --> [mother].
noun(parent) --> [parent].
noun(grandparent) --> [grandparent].
noun(cousin) --> [cousin].
noun(children) --> [children].
noun(male) --> [male].
noun(female) --> [female].

adjective(married) --> [married].
adjective(sibling) --> [sibling].

variable('X') --> ['X'].
variable('Y') --> ['Y'].
variable('Z') --> ['Z'].
variable('W') --> ['W'].

person(apostolos) --> [apostolos].
person(anna) --> [anna].
person(kiriakos) --> [kiriakos].
person(katerina) --> [katerina].
person(dimitris) --> [dimitris].

proposition(of) --> [of].
proposition(to) --> [to].


