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

	$result = insert_project($_POST['name'], $_POST['start_date_day'], $_POST['start_date_month'], $_POST['start_date_year'], $_POST['end_date_day'], $_POST['end_date_month'], $_POST['end_date_year'], $_POST['description'], $_POST['logo_path']);
		
	if (!$result)
	{
		$_SESSION['message'] = 'Invalid date. Date must have the format dd-mm-yyyy...';
		$_SESSION['reference'] = 'insert_project_page.php';
		$_SESSION['reference_value'] = 'Back!';
		require('notification_page.php');
		die();
	}
	
	$name = $_POST['name'];
	
	$_SESSION['message'] = "The project < $name > was successfully inserted!";
	$_SESSION['reference'] = 'manager_page.php';
	$_SESSION['reference_value'] = 'OK!';
	require('notification_page.php');
	die();
?>