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
	
	$description = get_project_description($_POST['project_id']);
	
	if (!$description)
	{
		// Δεν υπάρχουν μη ανεγνωσμένα μηνυματα για τον υπεύθυνο.
		$_SESSION['message'] = 'Unable to display project description!';
		$_SESSION['reference'] = 'manager_page.php';
		$_SESSION['reference_value'] = 'Back!';
		require('notification_page.php');
		die();
	}
	
	$desc_as_array = mysql_fetch_assoc($description);
	//test code
	
	print '<html>
	<body>
		<h1 align="center">Project description</h1>
		<hr>
		<br>
		<textarea rows="10" cols="100" readonly>';
	print $desc_as_array['description'];
	 
	 print '</textarea><br><hr><a href="all_projects_page.php">Back!</a></body></html>';
?>