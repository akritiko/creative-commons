<?php
	// Έναρξη συνόδου.
	session_start();
	
	// Η μεταβλητή αυτή υποδεικνύει εάν η σύνοδος είναι έγκυρη.
	$_SESSION['is_valid'] = true;
	
	// Αρχείο που περιέχει τις απαραίτητες πληροφορίες για την επίτευξη της σύνδεσης με τη βάση.
	require('mysql_info.php');
	
	// Η βάση ανοίγει μια φορά κατά την εκκίνηση και χρησιμοποιείται η ίδια σύνδεση μέχρι την έξοδο από το σύστημα.
	$sql_link = mysql_connect($hostname, $mysql_username);
	if (!$sql_link)
	{
		die('<h1>Could not connect:</h1> ' . mysql_error());
	}
	
	mysql_select_db($data_base);
?>

<html>
	<body>
		<em><h1 align="center">Login form</h1></em>
		<?php
			for ($i=0; $i<9; $i++)
			{
				print '<br>';
			}
		?>
		<hr>
		<form accept-charset="utf-8" action="authodicate_user.php" method="POST">
			Manager:	<input type="radio" name="user_type" value="manager">
			<br>
			Programmer:	<input type="radio" name="user_type" value="programmer" checked>
			<br>
			<hr>
			Username:  <input type="text" name="username">
			<br>
			Password:	<input type="password" name="password">
			<br>
			<input type="submit" value="Submit">
			<br>
			<hr>
		</form>
	</body>
</html>