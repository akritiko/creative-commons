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
?>

<html>
	<body>
		<h1 align="center">Programmer's page</h1>
		<hr>
		<h4 align="center">Welcome
			<?php
			echo $_SESSION['name'];
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
		<em>Task:</em>
		<br>
		<a href="programmer_tasks_page.php">View tasks</a>
		<br>
		<em>Message:</em>
		<br>
		<a href="all_programmer_messages_page.php">All</a>
		<br>
		<a href="not_read_programmer_messages_page.php">Not read</a>
		<br>
		<em>Personal info:</em>
		<br>
		<a href="programmer_info_page.php">View</a>
		<br>
		<em>------</em>
		<br>
		<a href="logout.php">Logout</a>
	</body>
</html>