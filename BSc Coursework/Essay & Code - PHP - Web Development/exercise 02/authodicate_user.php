<?php
	// Έναρξη συνόδου.
	session_start();
	
	// Ζητείται το αρχείο που περιέχει τις απαραίτητες πληροφορίες για την επίτευξη της σύνδεσης με τη βάση.
	require('mysql_info.php');
	
	// Η βάση ανοίγει μια φορά κατά την εκκίνηση και χρησιμοποιείται η ίδια σύνδεση μέχρι την έξοδο από το σύστημα.
	$sql_link = mysql_connect($hostname, $mysql_username);
	if (!$sql_link)
	{
		die('<h1>Could not connect:</h1> ' . mysql_error());
	}
	mysql_select_db($data_base);

	// Υπολογίζεται το md5 του password του χρήστη.
	$md5_password = md5($_POST['password']);

	require('mysql_functions.php');
	// Ελέγχεται εάν υπάρχει αυτός ο χρήστης και καταχωρούνται τα στοιχεία του για τη σύνοδο.	
	$user_data = get_user($_POST['user_type'], $_POST['username'], $md5_password);

	if (!$user_data)
	{
		// Ο χρήστης έχει εισάγει λανθασμένα στοιχεία οπότε δεν μπορεί να συνεχίσει.
		$_SESSION['message'] = 'Incorrect username or password! Try again...';
		$_SESSION['reference'] = 'login_page.php';
		$_SESSION['reference_value'] = 'Back!';
		require('notification_page.php');
		die();
	}
	
	// Η μεταβλητή αυτή έχει διπλό ρόλο. Υποδεικνύει εάν έχει πιστοποιηθεί η ταυτότητα του χρήστη, αλλά και τον τύπο του χρήστη ('programmer' ή 'manager'), καθορίζοντας έτσι τις σελίδες στις οποίες έχει πρόσβαση.
	$_SESSION['user_type'] = $_POST['user_type'];
	// Καταγράφουμε τα στοιχεία του χρήστη στο αρχείο συνόδου.
	$_SESSION['id'] = $user_data['id'];
	$_SESSION['name'] = $user_data['name'];
	$_SESSION['surname'] = $user_data['surname'];
	$_SESSION['e_mail_address'] = $user_data['e_mail_address'];
	$_SESSION['telephone'] = $user_data['telephone'];
	$_SESSION['username'] = $user_data['username'];
	$_SESSION['md5_password'] = $user_data['md5_password'];
	
	// Ανάλογα με τον τύπο του χρήστη, εμφανίζεται η σελίδα αλληλεπίδρασης.
	if ($_POST['user_type'] == 'programmer')
	{
		require('programmer_page.php');
	}
	else // $_POST['user_type'] == 'manager'
	{
		require('manager_page.php');
	}
?>