<?php
	session_start();
	
	if($_SESSION['user_type'] != 'manager')
	{
		$_SESSION['message'] = 'Unauthorized access!';
		$_SESSION['reference'] = 'login_page.php';
		$_SESSION['reference_value'] = 'Log in!';
		require('notification_page.php');
		die();
	}
	
	require('mysql_functions.php');
	
	$programmers = get_programmers();
	
	if (!$programmers)
	{
		$_SESSION['message'] = 'No programmers found!';
		$_SESSION['reference'] = 'manager_page.php';
		$_SESSION['reference_value'] = 'Back!';
		require('notification_page.php');
		die();
	}
	
	
	// test code!!
	print '<html>
	<body>
		<h1 align="center">Your messages</h1>
		<hr>
		<br>
		<table title="All messages" border="1">
			<th>ID<th>Surname<th>Name<th>E-mail<th>Telephone<th>Username
			';
	
	while ( $row = mysql_fetch_row($programmers))
	{
		print '<tr>';
		foreach($row as $field)
		{
			print "<td>$field</td> ";
		}
		print '<td><a href="null">Edit</a></td><td><a href="null">Delete</a></td></tr>';
	 }
	  print '</table><hr><a href="manager_page.php">Back!</a></body></html>';	 
?>