<?php
	session_start();
	
	// Εδώ δεν χρειάζεται να ελέγξω εάν ο χρήστης έχει πιστοποιηθεί.
	
	require('mysql_functions.php');
	// Κλείνει η σύνδεση με τη βάση.
	$sql_link = get_data_base_connection();
	mysql_close($sql_link);
	
	// Καταστρέφεται το αρχείο συνοδου.
	session_destroy();
	
	// Επιστροφή στη σελίδα υποδοχής.
	require('index.html');
?>