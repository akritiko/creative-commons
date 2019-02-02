;Systimata gnosis
;Ergasia 1
;Kemetzis Georgios (909)
;Kritikos Apostolos (914)


;orismos tou template appartment
(deftemplate appartment

	(slot address (type STRING)
	)
	(slot rooms (type INTEGER)
		    (range 1 ?VARIABLE)
	)
	(slot floor (type INTEGER)
		    (range 0 ?VARIABLE)
	)
	(slot area (type INTEGER)
		  (range 0 ?VARIABLE)
	)
	(slot rent (type NUMBER)
			  (range 1 ?VARIABLE)
	)
	(slot gardenArea (type INTEGER)
			  (range 0 ?VARIABLE)
	)
	(slot hasElevator (type SYMBOL)
			  (allowed-symbols yes no)
	)
 	(slot isInCenter (type SYMBOL)
		         (allowed-symbols yes no)
	)
	(slot petsAllowed (type SYMBOL)
			  (allowed-symbols yes no)
	)
)

;Orismos gegonoton appartments
(deffacts appartments
	(appartment (address "Vasileos Georgiou 35") (rooms 1) (floor 1) (area 50) (rent 300) (gardenArea 0) (hasElevator no) (isInCenter yes) (petsAllowed yes) 
	)
	(appartment (address "Aggelaki 7") (rooms 2) (floor 0) (area 45) (rent 335) (gardenArea 0) (hasElevator no) (isInCenter yes) (petsAllowed yes) 
	)
	(appartment (address "Kifisias 10") (rooms 2) (floor 2) (area 65) (rent 350) (gardenArea 0) (hasElevator no) (isInCenter no) (petsAllowed yes) 
	)
	(appartment (address "Plastira 72") (rooms 2) (floor 1) (area 55) (rent 330) (gardenArea 15) (hasElevator yes) (isInCenter no) (petsAllowed no) 
	)
	(appartment (address "Tsimiski 97") (rooms 3) (floor 0) (area 55) (rent 350) (gardenArea 15) (hasElevator no) (isInCenter yes) (petsAllowed yes) 
	)
	(appartment (address "Politexneiou 19") (rooms 2) (floor 3) (area 60) (rent 370) (gardenArea 0) (hasElevator no) (isInCenter yes) (petsAllowed no) 
	)
	(appartment (address "Ermou 22") (rooms 3) (floor 1) (area 65) (rent 375) (gardenArea 0) (hasElevator no) (isInCenter yes) (petsAllowed yes) 
	)
)

(defrule nofacts
	=>
	(assert (nofacts))

)

(defrule get-user-answer 
	=>
	(set-strategy depth) ;Oste oi kanones na ektelountai me proteraiotita vathous
	(printout t "Dose tis parakato plhrofories: " crlf)
	(printout t "Elaxisto emvadon: ")
	(bind ?area (read))
		;Elegxos an to emvado einai megalytero tou midenos 
		(while (or (stringp ?area) (symbolp ?area) (< ?area 0))  do 		
			(printout t "Elaxisto emvadon: ")
			(bind ?area (read))
		)
	(assert (area ?area))
	
	(printout t "Elaxista ypnodomatia: ")
	(bind ?rooms (read))
		;Elegxos an ta elaxista ypnodomatia einai perissotera tou midenos 
		(while (or (stringp ?rooms) (symbolp ?rooms) (< ?rooms 0))  do 		
			(printout t "Elaxista ypnodomatia: ")
			(bind ?rooms (read))
		)
	(assert (rooms ?rooms))
	
	(printout t "Theleis na epitrepontai katoikidia? (yes/no) ")
	(bind ?petsAllowed (read))
		;Elegxos an epitrepontai katoikidia 
		(while (and (neq ?petsAllowed yes) (neq ?petsAllowed no)) do 		
			(printout t "Theleis na epitrepontai katoikidia? (yes/no) ")
			(bind ?petsAllowed (read))
		)
	(assert (petsAllowed ?petsAllowed))
	
	(printout t "Apo poion orofo kai pano prepei na yparxei anelkysthras? ")
	(bind ?elevator (read))
		;Elegxos apo poion orofo kai pano prepei na yparxei anelkistiras
		(while (or (stringp ?elevator) (symbolp ?elevator) (< ?elevator 0))  do 		
			(printout t "Apo poion orofo kai pano prepei na yparxei anelkysthras? ")
			(bind ?elevator (read))
		)
	(assert (elevator ?elevator))	
		
	(printout t "Poio einai to megisto enoikio poy mporeis na plhroseis? ")
	(bind ?rent (read))
		;Elegxos an to megisto enoikio einai megalytero tou midenos 
		(while (or (stringp ?rent) (symbolp ?rent) (< ?rent 0))  do 		
			(printout t "Poio einai to megisto enoikio poy mporeis na plhroseis? ")
			(bind ?rent (read))
		)
	(assert (rent ?rent))
	
	(printout t "Posa tha edines gia ena diamerisma sto kentro ths polhs? ")
	(bind ?centerrent (read))
		;Elegxos an to megisto enoikio gia to kentro einai megalytero tou midenos 
		(while (or (stringp ?centerrent) (symbolp ?centerrent) (< ?centerrent 0))  do 		
			(printout t "Posa tha edines gia ena diamerisma sto kentro ths polhs? ")
			(bind ?centerrent (read))
		)
	(assert (centerrent ?centerrent))
	
	(printout t "Posa tha edines gia ena diamerisma sta proastia ths polhs? ")
	(bind ?suburbrent (read))
		;Elegxos an to megisto enoikio  gia ta proastia einai megalytero tou midenos 
		(while (or (stringp ?suburbrent) (symbolp ?suburbrent) (< ?suburbrent 0))  do 		
			(printout t "Posa tha edines gia ena diamerisma sta proastia ths polhs? ")
			(bind ?suburbrent (read))
		)
	(assert (suburbrent ?suburbrent))
	
	(printout t "Posa tha edines gia kathe tetragoniko diamerismatos pano apo to elaxisto? ")
	(bind ?rentpersqm (read))
		;Elegxos an i timi einai megalyteri tou midenos 
		(while (or (stringp ?rentpersqm) (symbolp ?rentpersqm) (< ?rentpersqm 0))  do 		
			(printout t "Posa tha edines gia kathe tetragoniko diamerismatos pano apo to elaxisto? ")
			(bind ?rentpersqm (read))
		)
	(assert (rentpersqm ?rentpersqm))
	
	(printout t "Posa tha edines gia kathe tetragoniko khpoy? ")
	(bind ?rentpersqmg (read))
		;Elegxos an i timi einai megalyteri tou midenos 
		(while (or (stringp ?rentpersqmg) (symbolp ?rentpersqmg) (< ?rentpersqmg 0))  do 		
			(printout t "Posa tha edines gia kathe tetragoniko khpoy? " crlf)
			(bind ?rentpersqmg (read))
		)
	(assert (rentpersqmg ?rentpersqmg))
)

;Elegxei an to fact plirei to dedomeno kai an oxi to kanei retract apo ti mnimi
(defrule emvado "emvado"

   ?f <- (appartment (area ?currentArea))
   (area ?area)
   (test (< ?currentArea ?area))
      =>
	(retract ?f)
)

;Elegxei an to fact plirei to dedomeno kai an oxi to kanei retract apo ti mnimi
(defrule rooms "rooms"

   ?f <- (appartment (rooms ?currentRooms))
   (rooms ?rooms)
   (test (< ?currentRooms ?rooms))
      =>
	(retract ?f)
)

;Elegxei an to fact plirei to dedomeno kai an oxi to kanei retract apo ti mnimi
(defrule elevator "elevator"

   ?f <- (appartment (floor ?currentFloor) (hasElevator no))
   (elevator ?elevator)
   (test (> ?currentFloor ?elevator))
      =>
	(retract ?f)
)

;Elegxei an to fact plirei to dedomeno kai an oxi to kanei retract apo ti mnimi
(defrule pets "pets"

   ?f <- (appartment (petsAllowed ?currentPetsAllowed))
   (petsAllowed ?petsAllowed)
   (test (neq ?currentPetsAllowed ?petsAllowed))
      =>
	(retract ?f)
)

;Elegxei an to fact plirei to dedomeno kai an oxi to kanei retract apo ti mnimi
(defrule rent "rent"

   ?f <- (appartment (rent ?currentRent))
   (rent ?rent)
   (test (> ?currentRent ?rent))
      =>
	(retract ?f)
)

;Elegxei an to fact plirei to dedomeno kai an oxi to kanei retract apo ti mnimi
(defrule centerRent "centerRent"

   ?f <- (appartment (area ?currentArea) (rent ?currentRent) (gardenArea ?currentGardenArea) (isInCenter ?currentIsInCenter) )
   (area ?area)
   (rent ?rent)
   (centerrent ?centerrent)
   (rentpersqm ?rentpersqm)
   (rentpersqmg ?rentpersqmg)
   (test (eq ?currentIsInCenter yes))
   (or (test (> ?currentRent (+ ?centerrent (* (- ?currentArea ?area) ?rentpersqm )  (* ?currentGardenArea ?rentpersqmg)   )))
   (test (< ?rent ?currentRent))
   ) 
      =>
        (retract ?f)
)

;Elegxei an to fact plirei to dedomeno kai an oxi to kanei retract apo ti mnimi
(defrule suburbRent "suburbRent"

   ?f <- (appartment (area ?currentArea) (rent ?currentRent)(gardenArea ?currentGardenArea) (isInCenter ?currentIsInCenter) )
   (area ?area)
   (rent ?rent)
   (suburbrent ?suburbrent)
   (rentpersqm ?rentpersqm)
   (rentpersqmg ?rentpersqmg)
   (test (eq ?currentIsInCenter no))
   (or (test (> ?currentRent (+ ?suburbrent (* (- ?currentArea ?area) ?rentpersqm )  (* ?currentGardenArea ?rentpersqmg)   )))
   (test (< ?rent ?currentRent))
   )
      =>
	(retract ?f)
	
)

(defrule apotelesmata

	=>
	(assert (apotelesmata))

)

(defrule printthem "hgjkgj"
	
	(apotelesmata)
	?f <- (appartment (address ?curAddress) (rooms ?curRooms) (floor ?curFloor) (area ?curArea) (rent ?curRent) (gardenArea ?curGardenArea) (hasElevator ?curHasElevator) (isInCenter ?curIsInCenter) (petsAllowed ?curPetsAllowed))
	=>
	(retract nofacts)
	(printout t crlf "Katallilo spiti sti dieuthinsi: " ?curAddress crlf)
	(printout t "Ypnodomatia: " ?curRooms crlf)
	(printout t "Orofos: " ?curFloor crlf)
	(printout t "Emvadon: " ?curArea crlf)
	(printout t "Enoikio: " ?curRent crlf)
	(printout t "Emvadon kipou: " ?curGardenArea crlf)
	(printout t "Anelkistiras: " ?curHasElevator crlf)
	(printout t "Einai sto kentro tis polis? " ?curIsInCenter crlf)
	(printout t "Epitrepontai katoikidia? " ?curPetsAllowed crlf crlf)
	
)

(defrule epilogi

	=>
	(assert (epilogi))

)

(defrule select "fdfs"
   
   (epilogi)
   ?f1 <- (appartment (address ?curAddress1) (rent ?curRent1) (gardenArea ?curgArea1) (area ?curArea1))
   ?f2 <- (appartment (address ?curAddress2 &~ ?curAddress1) (rent ?curRent2) (gardenArea ?curgArea2) (area ?curArea2))
     =>
   (if (> ?curRent1 ?curRent2) then (retract ?f1)
    else (if (< ?curRent1 ?curRent2) then (retract ?f2)
          else (if (> ?curgArea1 ?curgArea2) then (retract ?f2)
                else (if (< ?curgArea1 ?curgArea2) then (retract ?f1)
                      else (if (> ?curArea1 ?curArea2) then (retract ?f2)
                            else (if (< ?curArea1 ?curArea2) then (retract ?f1)
                                  ) 
                            )
                      )
                )
          )
    )
    
)

(defrule suggestnotexist "123"
	(epilogi)
	(nofacts)
	=>
	(printout t "Den yparxei proteinomeno diamerisma!" crlf) 
	
)

(defrule suggestexists "vgsdgfsf"
	(epilogi)
	?f <- (appartment (address ?curAddress))
	=>
	(printout t "Proteino na enoikiaseis to diamerisma sti dieuthinsi: " ?curAddress crlf) 
	
)
; (clear)



