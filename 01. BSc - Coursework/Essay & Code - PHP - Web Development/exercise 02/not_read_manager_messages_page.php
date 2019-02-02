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
	// Ζητούνται από τη βάση όλα τα μη ανεγνωσμένα μηνύματα που υπάρχουν καταχωρημένα για αυτόν τον υπεύθυνο. 
	$messages = get_messages_headers($_SESSION['id'], false, true);
	
	if (!$messages)
	{
		// Δεν υπάρχουν μη ανεγνωσμένα μηνυματα για τον υπεύθυνο.
		$_SESSION['message'] = 'There are no messages in your mailbox!';
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
			<th>Message ID<th>Sender<th>Subject<th>Send time<th>Read
			';
	
	while ( $row = mysql_fetch_row($messages))
	{
		print '<tr>';
		foreach($row as $field)
		{
			print "<td>$field</td> ";
		}
		print '<td><a href="null">Read</a></td><td><a href="null">Reply</a></td></tr>';
	 }
	print '</table><hr><a href="manager_page.php">Back!</a></body></html>';	 
?>
