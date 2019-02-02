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
		<h1 align="center">Project info</h1>
		<?php
			for ($i=0;$i<3;$i++)
			{
				print "<br>";
			}
		?>
		<hr>
		<form accept-charset="utf-8" action="insert_project.php" method="POST">
			Name:		<input type="text" name="name">
			<br>
			Start date:	<input type="text" name="start_date_day" maxlength="2" size="1"> - <input type="text" name="start_date_month" maxlength="2" size="1"> - <input type="text" name="start_date_year" maxlength="4" size="2">
			<br>
			End date:		<input type="text" name="end_date_day" maxlength="2" size="1"> - <input type="text" name="end_date_month" maxlength="2" size="1"> - <input type="text" name="end_date_year" maxlength="4" size="2">
			<br>
			Description:<br>
			<textarea cols="100" rows="10" name="description"></textarea>
			<br>
			Path for logo:	<input type="text" name="logo_path">
			<br>
			<input type="submit" value="Submit">
			<br>
			<hr>
		</form>
		<a href="manager_page.php">Back!</a>
	</body>
</html>