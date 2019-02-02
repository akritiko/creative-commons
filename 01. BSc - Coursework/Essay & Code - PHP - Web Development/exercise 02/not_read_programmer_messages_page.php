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
	
	require('mysql_functions.php');
	// Ζητούνται από τη βάση όλα τα μη ανεγνωσμένα μηνύματα που υπάρχουν καταχωρημένα για αυτόν τον προγραμματιστή. 
	$messages = get_messages_headers($_SESSION['id'], false, false);
	
	if (!$messages)
	{
		// Δεν υπάρχουν μη ανεγνωσμένα μηνυματα για τον προγραμματιστή.
		$_SESSION['message'] = 'There are no messages in your mailbox!';
		$_SESSION['reference'] = 'programmer_page.php';
		$_SESSION['reference_value'] = 'Back!';
		require('notification_page.php');
		die();
	}
	
	
	// test code!! Same as in all_programmer_messages_page.php
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
		print '<td>';
		echo $row[0];
		print '</td>';
		print '<td>';
		echo $row[1];
		print '</td>';
		print '<td>';
		echo $row[2];
		print '</td>';
		print '<td>';
		echo $row[3];
		print '</td>';
		print '<td>';
		echo $row[4];
		print '</td>';
		print '<form action="programmer_read_message_page.php" method="post"><td><input type="hidden" value="';
		echo $row[0];
		print '" name="message_id"><input type="submit" value="Read"></td></form><form action="reply_to_manager_message_page.php" method="post"><td><input type="hidden" value="';
		echo $row[5];
		print '" name="manager_id"><input type="submit" value="Reply"></td></form>';
	 }
	  print '</table><hr><a href="programmer_page.php">Back!</a></body></html>';
?>
