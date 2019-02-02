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
		<h1 align="center">New message</h1>
		<hr>
		<br>
		<form action="reply_to_manager_message.php" method="post">
			<input type="hidden" name="man_id" value="<?php echo $_POST['manager_id'];?>">
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
		<a href="programmer_page.php">Back!</a>
	</body>
</html>