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
	
	$projects = get_projects();
	
	if (!$projects)
	{
		// Δεν υπάρχουν μη ανεγνωσμένα μηνυματα για τον υπεύθυνο.
		$_SESSION['message'] = 'There are no projects to display!';
		$_SESSION['reference'] = 'manager_page.php';
		$_SESSION['reference_value'] = 'Back!';
		require('notification_page.php');
		die();
	}
	
	//test code
	
	print '<html>
	<body>
		<h1 align="center">Projects</h1>
		<hr>
		<br>
			<table border="1">
				<th>ID<th>Name<th>Start date<th>End date<th>logo
				';
	
	while ( $row = mysql_fetch_row($projects))
	{
		print '<tr>';
		foreach($row as $field)
		{
			print "<td>$field</td> ";
		}
		print '<form action="project_description_page.php" method="post"><td><input type="hidden" value="';
		echo $row[0];
		print '" name="project_id"><input type="submit" value="Description"></td></form><form action="project_tasks_page.php" method="post"><td><input type="hidden" value="';
		echo $row[0];
		print '" name="project_id"><input type="submit" value="Tasks"></td></form>';
	 }
	 
	 print '</table><hr><a href="manager_page.php">Back!</a></body></html>';
?>