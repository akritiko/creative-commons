;Systimata gnosis
;Ergasia 1
;Kemetzis Georgios (909)
;Kritikos Apostolos (914)


;Orismos tou template house
(deftemplate house

	(slot id (type INTEGER)
		  (range 1 ?VARIABLE)
	)
	(slot area (type INTEGER)
		  (range 0 ?VARIABLE)
	)
	(slot rooms (type INTEGER)
		    (range 1 ?VARIABLE)
	)
	(slot new (type SYMBOL)
		    (allowed-symbols yes no)
	)
	(slot polykatoikia_mezoneta (type SYMBOL)
			(allowed-symbols p m)
	)
	(slot parking (type SYMBOL)
			  (allowed-symbols yes no)
	)
	(slot suburb (type STRING)
	)
 	(slot price (type INTEGER)
		         (range 0 ?VARIABLE)
	)
)

;Orismos gegonoton houses
(deffacts houses
	(house (id 1) (area 95) (rooms 3) (new no) (polykatoikia_mezoneta p) (parking no) (suburb "Kalamaria") (price 190000)
	)
	(house (id 2) (area 105) (rooms 2) (new no) (polykatoikia_mezoneta m) (parking yes) (suburb "Pylaia") (price 189000)
	)
	(house (id 3) (area 111) (rooms 3) (new yes) (polykatoikia_mezoneta p) (parking yes) (suburb "Toumpa") (price 177600)
	)
	(house (id 4) (area 84) (rooms 2) (new no) (polykatoikia_mezoneta p) (parking no) (suburb "Ano Poli") (price 142800)
	)
	(house (id 5) (area 97) (rooms 2) (new yes) (polykatoikia_mezoneta m) (parking no) (suburb "Agios Paulos") (price 145500)
	)
	(house (id 6) (area 93) (rooms 2) (new yes) (polykatoikia_mezoneta p) (parking no) (suburb "Sykies") (price 120900)
	)
	(house (id 7) (area 120) (rooms 3) (new yes) (polykatoikia_mezoneta m) (parking no) (suburb "Stauroupoli") (price 144000)
	)
	(house (id 8) (area 130) (rooms 4) (new yes) (polykatoikia_mezoneta p) (parking yes) (suburb "Euosmos") (price 130000)
	)
	(house (id 9) (area 92) (rooms 2) (new no) (polykatoikia_mezoneta p) (parking no) (suburb "Menemeni") (price 128800)
	)
	(house (id 10) (area 115) (rooms 3) (new yes) (polykatoikia_mezoneta p) (parking yes) (suburb "Pylaia") (price 210000)
	)
)

;O kanonas autos eisagei ena monadiaio gegonos (nofacts). H yparksi tou gegonotos autou
;sti mnimi simainei oti den yparxei kanena spiti pou na ikanopoiei tis apaitiseis tou pelati
;opote sto simeio pou to programma kaleitai na emfanisei apotelesmata tiponei to katallilo 
;minima.
(defrule nofacts
	=>
	(assert (nofacts))
)

;O kanonas autos syllegei tis protimiseis tou xrhsth ypo morfin erotiseon kai eisagei tis
;apantiseis tou sti mnimi ypo morfin gegonoton.
(defrule get-user-answers
	=>
	;dedomenou oti stin sygkekrimeni ergasia oi pio polyplokoi kanones einai kai oi pio perioristikoi 
	;epilegoume san stratigiki epilysis autin me vasi tin polyplokotita oste oi pio polyplokoi kanones na 
	;vrethoun pio pano stin agenda kai etsi na meiosoun oso perissotero mporoun ta gegonota mas
	; prin perasoume stous aplousterous kanones. H yparksi de tis salience stous kanones pou 
	;analamvanoun na typosoun ta apotelesmata tous empodizei na diaplexthoun me autous tis epilogis
	;tou katallilou spitiou.
	(set-strategy complexity) 
	(printout t "Dose tis parakato plhrofories: " crlf)
	
	;Erotisi gia to megethos tou spitiou
	(printout t "Theleis mikro, mesaio h' megalo spiti? ")
	(bind ?size (read))
	;Elegxos gia to an i dosmeni timi einai mia ek ton "mikro" / "mesaio" / "megalo". 
	;An i eisodos den einai mia apo tis anamenomenes, i erwtisi epanalamvanetai wspou na lifthei swsti eisodos apo ton xrhsth.
	(while (and (neq ?size mikro) (neq ?size mesaio) (neq ?size megalo)) do 		
		(printout t "Theleis mikro, mesaio h' megalo spiti? ")
		(bind ?size (read))
	)
	(assert (size ?size))
	
	;Erotisi gia tin perioxi pou vrisketai to spiti
	(printout t "Se poia perioxi (anatolika/kentro/dytika)? ")
	(bind ?district (read))
	;Elegxos gia to an i dosmeni timi einai mia ek ton "anatolika" / "kentro" / "dytika".
	;An i eisodos den einai mia apo tis anamenomenes, i erwtisi epanalamvanetai wspou na lifthei swsti eisodos apo ton xrhsth.
	(while (and (neq ?district anatolika) (neq ?district kentro) (neq ?district dytika)) do 		
		(printout t "Se poia perioxi (anatolika/kentro/dytika)? ")
		(bind ?district (read))
	)
	(assert (district ?district))
	
	;Erotisi gia to an to spiti prepei na einai kainourio i oxi.
	(printout t "Theleis kainoyrio spiti (yes/no)? ")
	(bind ?age (read))
	;Elegxos gia to an i dosmeni timi einai mia ek ton "yes" / "no" kai epanalipsi mexri na dothei kapoia apodekti timi.
	;An i eisodos den einai mia apo tis anamenomenes, i erwtisi epanalamvanetai wspou na lifthei swsti eisodos apo ton xrhsth.
	(while (and (neq ?age yes) (neq ?age no)) do 		
		(printout t "Theleis kainoyrio spiti (yes/no)? ")
		(bind ?age (read))
	)
	(assert (age ?age))
	
	;Erotisi gia to an to spiti prepei na einai polykatoikia i mezoneta.
	(printout t "Polykatoikia h' mezoneta (p/m)? ")
	(bind ?type (read))
	;Elegxos gia to an i dosmeni timi einai mia ek ton "p" / "m"  kai epanalipsi mexri na dothei kapoia apodekti timi.
	;An i eisodos den einai mia apo tis anamenomenes, i erwtisi epanalamvanetai wspou na lifthei swsti eisodos apo ton xrhsth.
	(while (and (neq ?type p) (neq ?type m)) do 		
		(printout t "Polykatoikia h' mezoneta (p/m)? ")
		(bind ?type (read))
	)
	(assert (type ?type))
	
	;Erotisi gia to posa meli perilamvanei i oikogeneia
	(printout t "Posa melh exei h oikogeneia? ")
	(bind ?members (read))
	;Elegxos gia tin orthotita tis eisodou (o arithmos melwn prepei na einai akeraios kai thetikos)
	;An i eisodos den einai mia apo tis anamenomenes, i erwtisi epanalamvanetai wspou na lifthei swsti eisodos apo ton xrhsth.
	(while (or (neq (integerp ?members) TRUE) (< ?members 0) )  do 		
		(printout t "Posa melh exei h oikogeneia? ")
		(bind ?members (read))
	)
	(assert (members ?members))
	
	;Erotisi gia to an yparxei autokinito i oxi.
	(printout t "Exeis amaksi (yes/no)? ")
	(bind ?carExists (read))
	;Elegxos gia to an i dosmeni timi einai mia ek ton "yes" / "no" .
	;An i eisodos den einai mia apo tis anamenomenes, i erwtisi epanalamvanetai wspou na lifthei swsti eisodos apo ton xrhsth.
	(while (and (neq ?carExists yes) (neq ?carExists no)) do 		
		(printout t "Exeis amaksi (yes/no)? ")
		(bind ?carExists (read))
	)
	(assert (carExists ?carExists))
)

;Kanonas elegxou emvadou. Analoga me tin protimisi tou xrhsth gia mikro, mesaio i megalo spiti
;me vasi ta tetragonika pou kalyptoun tin oikogeneia tou afairountai ta gegonota houses pou den
;pliroun tis prodiagrafes autes.
(defrule checkArea "Check Area"
	
	?f <- ( house (area ?area) ) ;area: to megethos se tetragonika tou spitiou.
	(size ?size) ;size: to megethos pou zita o xristis (mikro/mesaio/megalo)
	(members ?members) ;members: ta meli tis oikogeneias
	
	=>
	
	( bind ?minArea (* ?members 25) ) ;to prwto orio, to opoio diaxwrizei ena mikro apo ena mesaio spiti (25 m^2 ana melos)
	( bind ?maxArea (* ?members 35) ) ;to deutero orio, to opoio diaxwrizei ena mesaio apo ena megalo spiti (35 m^2 ana melos)

	(if ( and (eq ?size mikro) ( >= ?area ?minArea ) ) then  
		( retract ?f) ;an o xrhsths epileksei mikro spiti ginontai oi katalliloi ypologismoi kai ta antistoixa mesaia kai megala spitia aporriptontai
	else 
		(if ( and (eq ?size mesaio) ( < ?area ?minArea ) ( > ?area ?maxArea ) ) then 
			( retract ?f) ;an o xrhsths epileksei mesaio spiti ginontai oi katalliloi ypologismoi kai ta antistoixa mikra kai megala spitia aporriptontai
		else 
			(if ( and (eq ?size megalo) ( <= ?area ?maxArea ) ) then 
				( retract ?f) ;an o xrhsths epileksei megalo spiti ginontai oi katalliloi ypologismoi kai ta antistoixa mesaia kai mikra spitia aporriptontai
			)
		)		
	)
)

;Kanonas elegxou domation. Afotou vrethei o megistos kai elaxistos arithmos domation afairountai ta spitia pou exoun 
;domatia ekso apo to diastima [minRooms,maxRooms]
(defrule checkBedrooms "Check Bedrooms"
	
	?f <- ( house (rooms ?rooms) ) ;rooms: plithos domation tou spitiou
	(members ?members) ;members: arithmos melon tis oikogeneias
	
	=>
	
	( bind ?minRooms (/ ?members 2) ) ;o elaxistos arithmos dwmatiwn (2 to poly atoma mporoun na xwresoun se ena dwmatio)
	( bind ?maxRooms (- ?members 1) ) ;o megistos arithmos dwmatiwn (einai osa ta meli tis oikogeneias meion ena)

	(if ( or ( > ?rooms ?maxRooms ) ( < ?rooms ?minRooms ) ) then 
		( retract ?f) ;an o arithmos twn dwmatiwn den vrisketai mesa sta oria pou thetontai stin ekfwnisi, to spiti aporriptetai
	)
)

;Elegxos tis perioxis. Me ena aplo if elegxoume to proastio tou kathe spitiou kai osa den anoikoun stin epithymiti 
;perioxi afairountai apo ti mnini
(defrule checkDistrict "Check District"
	
	?f <- ( house (suburb ?suburb) ) ;suburb: proastio
	(district ?district) ;district: perioxi (anatolika/kentro/dytika)
	
	=>
	
	(if ( and (eq ?district anatolika) ( neq ?suburb "Kalamaria" ) (neq ?suburb "Pylaia") (neq ?suburb "Toumpa") ) then  
		( retract ?f) ;an i epilogi tou xristi einai spiti sta anatolika, aporriptontai ola ta spitia pou den einai se ena apo ta anatolika proastia 
	else 
		(if ( and (eq ?district kentro) ( neq ?suburb "Ano Poli" ) (neq ?suburb "Agios Paulos") (neq ?suburb "Sykies") ) then 
			( retract ?f) ;an i epilogi tou xristi einai spiti sto kentro, aporriptontai ola ta spitia pou den einai se ena apo ta kentrika proastia 
		else 
			(if ( and (eq ?district dytika) ( neq ?suburb "Stauroupoli" ) (neq ?suburb "Menemeni") (neq ?suburb "Euosmos") ) then 
				( retract ?f) ;an i epilogi tou xristi einai spiti sta dytika, aporriptontai ola ta spitia pou den einai se ena apo ta dytika proastia 
			)
		)		
	)
)

;Elegxos gia to an to spiti einai polikatoikia i mezoneta
(defrule checkType "Check the type of the house"
	;oi metavlites pou xreiazontai einai o typos tou spitiou kai i eisoos tou xrhsth (p/m)
	?f <- ( house (polykatoikia_mezoneta ?polykatoikia_mezoneta) )
	(type ?type)
	
	(test (neq ?polykatoikia_mezoneta ?type)) ;sygkrisi tou typou tou spitiou me tin eisodo tou xrhsth
	
	=>
	
	( retract ?f) ;an o typos kai to input den tautizontai, to spiti aporriptetai
)

;Elegxos ilikias tou spitiou
(defrule checkAge "Check the age of the house"
	;oi metavlites pou xreiazontai einai i ilikia tou spitiou kai i eisoos tou xrhsth (yes/no)
	?f <- ( house (new ?new) )
	(age ?age)
	
	(test (neq ?age ?new)) ;sygkrisi tis ilikias tou spitiou me tin eisodo tou xrhsth
	
	=>
	
	( retract ?f) ;an i ilikia kai to input den tautizontai, to spiti aporriptetai
)

;Elegxos yparksis parking
(defrule checkAge "Check the age of the house"
	;oi metavlites pou xreiazontai einai to parking tou spitiou kai i eisoos tou xrhsth (yes/no)
	?f <- ( house (parking ?parking) )
	(carExists ?carExists)
	
	(test (neq ?parking ?carExists)) ;sygkrisi tis metavlitis parking tou spitiou me tin eisodo tou xrhsth
	
	=>
	
	( retract ?f) ;an i metavliti parking kai to input den tautizontai, to spiti aporriptetai
)

;Oi epomenoi treis kanones exoun salience -10. Auto symvainei giati prokeitai gia tous kanones pou 
;aforoun tin epistrofi ton apotelesmaton ston xristi opote prepei pasi thyseia na ektelestoun afotou 
;exoun ektelestei oloi oi alloi kanones.

;O kanonas autos elegxei an ypaxrxoun apotelesmata gia ektypwsi. An yparxoun afairei to gegonos nofacts apo ti mnimi.
;O logos gia ton opoio den sygxoneuoume ton en logo kanona me ton epomeno einai giati o parakato kanonas typonei pano
;tou enos apotelesmata ara ekteleitai pleon tis mias fores. An to retract yparxei mesa se auton ton epanalamvanomeno kanona
;tin proti fora tha afairethei to nofacts eno gia kathe epomeni tha exoume epistrofi kapoiou minimatos pou tha mas leei oti 
;i afairesi tou nofacts itan anepityxis.
(defrule checkForResults "CheckResults"
	(declare (salience -10))
	?f <- (house (id ?id) (area ?area ) (rooms ?rooms) (new ?new) (polykatoikia_mezoneta ?polykatoikia_mezoneta) (parking ?parking) (suburb ?suburb) (price ?price))
	?g <- (nofacts)
	
	=>
	(retract ?g)
)

;Kanonas ektypwsis twn apotelesmatwn
(defrule printResults "Results"
	(declare (salience -10))
	?f <- (house (id ?id) (area ?area ) (rooms ?rooms) (new ?new) (polykatoikia_mezoneta ?polykatoikia_mezoneta) (parking ?parking) (suburb ?suburb) (price ?price))
	
	=>
	(printout t crlf "Ena katallilo spiti gia sena einai to no " ?id crlf)
	(printout t "Emvadon: " ?area crlf)
	(printout t "Domatia: " ?rooms crlf)
	(if (eq ?new yes) then (printout t "Ilikia: kainourio" crlf) else (printout t "Ilikia: palio" crlf))
	(if (eq ?polykatoikia_mezoneta p) then (printout t "Typos: polykatoikia" crlf) else (printout t "Typos: mezoneta" crlf))
	(if (eq ?parking yes) then (printout t "Parking: nai" crlf) else (printout t "Parking: oxi" crlf))
	(printout t "Synoikia: " ?suburb crlf)
	(printout t "Timi: " ?price crlf crlf)
	(retract ?f) ;meta tin ektyposi to sygekrimeno gegonos afaireitai apo ti mnimi gia na mi lifthei ek neou ypopsin.
)

;Kanonas ektypwsis mi yparksis epithymitou spitiou. Efoson to nofacts synexizei na yparxei sti mnimi to systima
;symperainei oti kanena spiti den kalyptei tis proypotheseis tou xristi kai ara emfanizei to katallilo minima.
(defrule noHouses "No houses"
	(declare (salience -10))
	(nofacts)
	=>
	(printout t "Den yparxei spiti poy na symfwnei me tis prodiagrafes." crlf)
)