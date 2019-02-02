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
	$message = get_message($_POST['message_id'], false);
	
	if (!$message)
	{
		$_SESSION['message'] = 'Unable to read message!';
		$_SESSION['reference'] = 'all_programmer_messages_page.php';
		$_SESSION['reference_value'] = 'Back!';
		require('notification_page.php');
		die();
	}
	
	$message_as_array = mysql_fetch_row($message);
	
	//test code
	
	print '<html>
	<body>
		<h1 align="center">Message</h1>
		<hr>
		<br>
		<textarea rows="10" cols="100" readonly>';
	print $message_as_array[0];
	print '</textarea><br>';
	print '<hr><a href="all_programmer_messages_page.php">Back!</a></body></html>';
?>