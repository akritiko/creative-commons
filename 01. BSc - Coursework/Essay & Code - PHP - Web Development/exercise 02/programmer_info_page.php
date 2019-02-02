<?php
	session_start();
	
	if($_SESSION['user_type'] != 'programmer')
	{
		$_SESSION['message'] = 'Unauthorized access!';
		$_SESSION['reference'] = 'login_page.php';
		$_SESSION['reference_value'] = 'Log in!';
		require('notification_page.php');
		die();
	}
	
	// Εδώ πρέπει να μπορεί να αλλάξει και το password!!!-Ζητείται το παλαιό, υπολογίζεται το md5 του, συγκρίνεται με το αποθηκευμένο md5 και μετά καταχωρείται το md5 του νέου password...
	
	
	//  test code!!
	print '<html>
	<body>
		<h1 align="center">Personal info</h1>
		<hr>
		<br>
		<table title="All messages" border="1">
			<th>ID<th>Surname<th>Name<th>E-mail<th>Telephone<th>Username
			';
	print "<tr><td>";
	echo $_SESSION['id'];
	print "</td><td>";
	echo $_SESSION['surname'];
	print "</td><td>";
	echo $_SESSION['name'];
	print "</td><td>";
	echo $_SESSION['e_mail_address'];
	print "</td><td>";
	echo $_SESSION['telephone'];
	print "</td><td>";
	echo $_SESSION['username'];
	print "</td>";
	
	print '</table><hr><a href="programmer_page.php">Back!</a></body></html>';	 
?>