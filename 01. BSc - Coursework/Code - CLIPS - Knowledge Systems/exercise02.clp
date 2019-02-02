;Κρητικός Απόστολος (914)
;Κεμετζής Γεώργιος (909)
;Συστήματα Γνώσης - Εργασία 2


;Η αφηρημένη κλάση component΄
;Ορίζει το Component με γενικό τρόπο
;id :: αναγνωριστικό (μοναδικός ακέραιος)
;terminal :: ορίζει αν ένα component είναι τερματικό (στην περίπτωσή μας τον τελευταίο αθριστή)
;suspect :: καθορίζει αν ένα εξάρτημα είναι ύποπτο ή όχι

(defclass component
	(is-a USER)
	(role abstract)
	(slot id (type INTEGER))
	(slot terminal
			(type SYMBOL) 
			(allowed-symbols yes no)
			(default no)
	)
	(slot suspect 
		(type SYMBOL) 
		(allowed-symbols yes no)
		(default no)
	)
)


;Μετρητές
;Κληρονομούν τις ιδιότητες της κλάσης component.
;Το πεδίο input ισούται με την ένδειξη του αισθητήρα.
;Το πεδίο connectsWith καθορίζει με ποιο εξάρτημα συνδέεται ο κάθε μετρητής
(defclass component1
	(is-a component)
	(role concrete)
	(slot input (type INTEGER) (default -1))
	(slot connectsWith (type INSTANCE-NAME))
)

;Eπειδή οι αθροιστές και οι πολλαπλασιαστες παρυσιάζουν παρόμοια χαρακτηριστικά, ομαδοποιούνται στην κλάση component2.
;Κληρονομούν τις ιδιότητες της κλάσης component.
;Περιλαμβάνουν πεδία για εισόδους και έξοδο.
;Το πεδίο isAdder καθορίζει αν πρόκειται για αθροιστή ή πολλαπλασιαστή.
(defclass component2
	(is-a component)
	(role concrete)
	(slot input1 (type INTEGER) (default -1))
	(slot input2 (type INTEGER) (default -1))
	(slot output (type INTEGER) (default -1))
	(slot isAdder 
			(type SYMBOL) 
			(allowed-symbols yes no)
			(default no)
	)
)



;Ορισμός components

(definstances components
	(add-1 of component2 (id 1) (isAdder yes))
	(add-2 of component2 (id 7) (isAdder yes) (terminal yes))
	(mul-1 of component2 (id 3))
	(mul-2 of component2 (id 5))
	(sen-1 of component1 (id 2)(connectsWith [add-1]))
	(sen-2 of component1 (id 4)(connectsWith [mul-1]))
	(sen-3 of component1 (id 6)(connectsWith [mul-2]))
	(output of component1 (id 8)(connectsWith [add-2]))
)


;Template κύκλων

(deftemplate cycle
	(slot cycleTime (type INTEGER))
	(slot input1 (type INTEGER))
	(slot input2 (type INTEGER))
	(slot input3 (type INTEGER))
	(slot input4 (type INTEGER))
	(slot sensor1 (type INTEGER))
	(slot sensor2 (type INTEGER))
	(slot sensor3 (type INTEGER))
	(slot output (type INTEGER))
)

;Τα γεγονότα δεδομένων ανά κύκλο

(deffacts cycles
	
	(cycle (cycleTime 1) (input1 21) (input2 28) (input3 10) (input4 25) (sensor1 10) (sensor2 24) (sensor3 26) (output 18))
	(cycle (cycleTime 2) (input1 7) (input2 25) (input3 13) (input4 15) (sensor1 0) (sensor2 0) (sensor3 3) (output 3))
	(cycle (cycleTime 3) (input1 11) (input2 17) (input3 24) (input4 31) (sensor1 22) (sensor2 6) (sensor3 8) (output 14))
	(cycle (cycleTime 4) (input1 18) (input2 11) (input3 28) (input4 21) (sensor1 4) (sensor2 12) (sensor3 12) (output 0))
	(cycle (cycleTime 5) (input1 25) (input2 24) (input3 30) (input4 10) (sensor1 18) (sensor2 16) (sensor3 12) (output 12))
	(cycle (cycleTime 6) (input1 12) (input2 19) (input3 11) (input4 19) (sensor1 8) (sensor2 24) (sensor3 17) (output 9))
	(cycle (cycleTime 7) (input1 1) (input2 31) (input3 7) (input4 22) (sensor1 2) (sensor2 0) (sensor3 26) (output 26))
	(cycle (cycleTime 8) (input1 0) (input2 31) (input3 3) (input4 23) (sensor1 0) (sensor2 0) (sensor3 0) (output 0))
	(cycle (cycleTime 9) (input1 31) (input2 1) (input3 6) (input4 8) (sensor1 30) (sensor2 30) (sensor3 0) (output 30))
	(cycle (cycleTime 10) (input1 6) (input2 4) (input3 25) (input4 12) (sensor1 12) (sensor2 31) (sensor3 12) (output 28))
)

;Κανονική λειτουργία αθροιστή

(deffunction addthem (?in1 ?in2)
	(mod (+ ?in1 ?in2) 32 )
)

;Κανονική λειτουργία πολλαπλασιαστή

(deffunction multhem (?in1 ?in2)
	(mod (* ?in1 ?in2) 32 )
)

;Συνάρτηση ενοχοποίησης εξαρτημάτων
;Αν η ένδειξη του μερητή δεν συμφωνεί με την αναμενόμενη έξοδο, 
;τότε καθίσταται ύποτος τόσο ο μετρητής, όσο και το εξάρτημα με το οποίο αυτός συνδέεται.
(deffunction create-suspects ()
	(do-for-all-instances
		((?c2 component2) (?c1 component1))
		(and (neq input1 -1) (neq input2 -1))
		(bind ?wantedID (- ?c1:id 1))
		(eq  ?wantedID ?c2:id)
		
		(and
			(bind ?trueOutput (addthem ?c2:input1 ?c2:input2))
			(neq ?c2:output ?trueOutput)
		)
		
		(send ?c2 put-suspect yes)
		(send ?c1 put-suspect yes)
	)
)


;Κανόνας αρχικοποίησης των εξαρτημάτων, σύμφωνα με τους κύκλους εκτέλεσης και τις συνδέσεις που ορίζονται από την εκφώνηση.
(defrule readCycle

	?c <- (cycle (cycleTime ?t) (input1 ?in1) (input2 ?in2) (input3 ?in3) (input4 ?in4) 
		      (sensor1 ?s1) (sensor2 ?s2) (sensor3 ?s3) (output ?out))
=>
	(set-strategy depth)
	(modify-instance [add-1]
		(input1 ?in1)
		(input2 ?in1)
		(output ?s1)
	)

	(modify-instance [mul-1]
		(input1 ?in2)
		(input2 ?s1)
		(output ?s2)
	)
	
	(modify-instance [mul-2]
		(input1 ?in3)
		(input2 ?in4)
		(output ?s3)
	)
	
	(modify-instance [add-2]
		(input1 ?s2)
		(input2 ?s3)
		(output ?out)
	)
	
	(modify-instance [output]
		(input ?out)
	)
	
	(modify-instance [sen-3]
		(input ?s3)
	)

	(modify-instance [sen-2]
		(input ?s2)
	)	

	(modify-instance [sen-1]
		(input ?s1)
	)
	
	(retract ?c)
	(assert (reachedTerminal false))
	
)

