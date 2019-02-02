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
	
	send_new_message($_SESSION['id'], $_POST['prog_id'], $_POST['subject'], $_POST['message'], false);
		
	$_SESSION['message'] = 'Message succesfully send!';
	$_SESSION['reference'] = 'manager_page.php';
	$_SESSION['reference_value'] = 'OK!';
	require('notification_page.php');
	die();
?>