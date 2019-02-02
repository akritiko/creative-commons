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
		<h1 align="center">New message</h1>
		<hr>
		<br>
		<form action="new_manager_message.php" method="post">
			Prog id: <input type="text" size="1" name="prog_id">
			<br>
			Subject: <input type="text" name="subject">
			<br>
			<em>
				<u>Message</u>
			</em>
			<br>
			<textarea cols="100" rows="10" name="message"></textarea>
			<br>
			<input type="submit" value="Submit">
			<hr>
		</form>
		<a href="manager_page.php">Back!</a>
	</body>
</html>