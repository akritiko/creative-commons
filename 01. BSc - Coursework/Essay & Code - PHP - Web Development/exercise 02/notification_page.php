<?php
	session_start();
?>

<head>
	<body>
		<hr>
		<h1 align="center">
			<?php
				echo $_SESSION['message'];
			?>
		</h1>
		<hr>
		<h4 align="center">
			<em>
				<a href="
					<?php
						echo $_SESSION['reference'];
					?>
					">
					<?php
						echo $_SESSION['reference_value'];
						unset($_SESSION['message']);
						unset($_SESSION['reference']);
						unset($_SESSION['reference_value']);
					?>
				</a>
			</em>
		</h4>
		<hr>
	</body>
</head>