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