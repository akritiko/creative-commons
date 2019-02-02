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
	
	$result = insert_programmer($_POST['name'], $_POST['surname'], $_POST['e_mail_address'], $_POST['telephone'], $_POST['username'], $_POST['password']);
	
	$username = $_POST['username'];
	
	if (!$result)
	{
		$_SESSION['message'] = "The username < $username > already exists!<br> Please choose another one...";
		$_SESSION['reference'] = 'insert_programmer_page.php';
		$_SESSION['reference_value'] = 'Back!';
		require('notification_page.php');
		die();
	}
	
	$_SESSION['message'] = "The user < $username > was successfully inserted!";
	$_SESSION['reference'] = 'manager_page.php';
	$_SESSION['reference_value'] = 'OK!';
	require('notification_page.php');
	die();
?>