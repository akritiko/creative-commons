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
		<h1 align="center">Personal info</h1>
		<?php
			for ($i=0;$i<3;$i++)
			{
				print "<br>";
			}
		?>
		<hr>
		<form accept-charset="utf-8" action="insert_programmer.php" method="POST">
			Name:		<input type="text" name="name">
			<br>
			Surname:	<input type="text" name="surname">
			<br>
			E-mail:		<input type="text" name="e_mail_address">
			<br>
			Telephone:	<input type="text" name="telephone">
			<br>
			Username:	<input type="text" name="username">
			<br>
			Password:	<input type="password" name="password">
			<br>
			<input type="submit" value="Submit">
			<br>
			<hr>
		</form>
		<a href="manager_page.php">Back!</a>
	</body>
</html>