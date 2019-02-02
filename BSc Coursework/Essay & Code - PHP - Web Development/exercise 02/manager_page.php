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
?>

<html>
	<body>
		<h1 align="center">Manager's page</h1>
		<hr>
		<h4 align="center">Welcome
			<?php
			$name = $_SESSION['name'];
			print " $name";
			?>
		!</h4>
		<hr>
		<?php	
		for ($i=0;$i<3;$i++)
		{
			print "<br>";
		}
		?>
		<hr>
		<br>
		<em>Project:</em>
		<br>
		<a href="insert_project_page.php">New</a>
		<br>
		<a href="all_projects_page.php">All</a>
		<br>
		<em>Task:</em>
		<br>
		<a href="new_task_page.php">New</a>
		<br>
		<a href="assign_task_page.php">Assign</a>
		<br>
		<em>Programmer:</em>
		<br>
		<a href="insert_programmer_page.php">New</a>
		<br>
		<a href="all_programmers_page.php">All</a>
		<br>
		<em>Message:</em>
		<br>		
		<a href="new_manager_message_page.php">New</a>
		<br>
		<a href="all_manager_messages_page.php">All</a>
		<br>
		<a href="not_read_manager_messages_page.php">Not read</a>
		<br>
		<em>------</em>
		<br>
		<a href="logout.php">Logout</a>
	</body>
</html>