<?php

	/**
	 * Enter description here...
	 *
	 * @return unknown
	 */

	function get_data_base_connection()
	{
		// Αρχείο που περιέχει τις απαραίτητες πληροφορίες για την επίτευξη της σύνδεσης με τη βάση.
		require('mysql_info.php');
		
		// Η σύνδεση με την SQL δεν εχει κλείσει, οπότε χρησιμοποιούμε τη συνάρτηση mysql_pconnect για να ανακτήσουμε την ήδη ανοικτή σύνδεση.
		$sql_link = mysql_pconnect($hostname, $mysql_username);
		if (!$sql_link)
		{
			die('<h1>Could not connect:</h1> ' . mysql_error());
		}
		
		mysql_select_db($data_base);
		
		return $sql_link;
	}

	/**
	 * Enter description here...
	 *
	 * @param unknown_type $table
	 * @param unknown_type $username
	 * @param unknown_type $md5_password
	 * @return unknown
	 */
	
	function get_user($table, $username, $md5_password)
	{
		// Αναζητείται ο προγραμματιστής με τα διδόμενα username και md5_password.
		$sql_query = "SELECT * FROM $table WHERE username = '$username' and md5_password = '$md5_password';";
		$sql_link = get_data_base_connection();
		$user_data = mysql_query($sql_query, $sql_link);

		if (!$user_data)
		{
			die("<h1>QUERY FAILED:</h1><br>$sql_query");
		}

		// Εάν δεν επιστραφεί αποτέλεσμα, τότε δεν υπάρχει χρήστης με αυτά τα στοιχεία.
		if (mysql_num_rows($user_data) == 0)
		{
			return false;
		}
		
		// Γνωρίζουμε με σιγουριά ότι υπάρχει μόνο ένας χρήστης με αυτά τα στοιχεία.
		$array = mysql_fetch_assoc($user_data);

		mysql_free_result($user_data);
		
		// Η εισαγωγή έχει επιτύχει, οπότε επιστρέφεται ολόκληρη η εγγραφή με τα στοιχεία του χρήστη.
		return $array;
	}
	
	/**
	 * Enter description here...
	 *
	 * @param unknown_type $name
	 * @param unknown_type $start_date_day
	 * @param unknown_type $start_date_month
	 * @param unknown_type $start_date_year
	 * @param unknown_type $end_date_day
	 * @param unknown_type $end_date_month
	 * @param unknown_type $end_date_year
	 * @param unknown_type $description
	 * @param unknown_type $logo_path
	 * @return unknown
	 */
	
	function insert_project($name, $start_date_day, $start_date_month, $start_date_year, $end_date_day, $end_date_month, $end_date_year, $description, $logo_path)
	{	
		// Ελέγχεται η εγκυρότητα των διδομένων ημερομηνιών.
		if (!checkdate($start_date_month, $start_date_day, $start_date_year))
		{
			return false;
		}
		
		if (!checkdate($end_date_month, $end_date_day, $end_date_year))
		{
			return false;
		}
		
		$start_date = "$start_date_day-$start_date_month-$start_date_year";
		$end_date = "$end_date_day-$end_date_month-$end_date_year";
		$sql_query = "INSERT INTO project VALUES(null, '$name', '$start_date', '$end_date', '$description', '$logo_path');";
		$sql_link = get_data_base_connection();
		$result = mysql_query($sql_query, $sql_link);
		
		if(!$result)
		{
			die("<h1>QUERY FAILED:</h1><br>$sql_query");
		}
		return true;
	}
	
	/**
	 * Enter description here...
	 *
	 * @param unknown_type $name
	 * @param unknown_type $surname
	 * @param unknown_type $e_mail_address
	 * @param unknown_type $telephone
	 * @param unknown_type $username
	 * @param unknown_type $password
	 * @return unknown
	 */
	
	function insert_programmer($name, $surname, $e_mail_address, $telephone, $username, $password)
	{
		// Ελέγχεται εάν υπάρχει άλλος προγραμματιστής με το ίδιο username.
		$sql_query = "SELECT * FROM programmer WHERE username = '$username';";
		$sql_link = get_data_base_connection();
		$result = mysql_query($sql_query, $sql_link);

		if (!$result)
		{
			die("<h1>QUERY FAILED:</h1><br>$sql_query");
		}

		// Εάν επιστραφεί αποτέλεσμα, τότε υπάρχει χρήστης με αυτό το username.
		if (mysql_num_rows($result) != 0)
		{
			return false;
		}

		// Το username είναι μοναδικό οπότε μπορεί να γίνει η εισαγωγή στη βάση.

		// Στη βάση θα εισαχθεί το παράγωγο του αλγορίθμου md5 στο password και όχι το ίδιο το password (λειτουργεί σαν κρυπτογράφηση).
		$password_md5 = md5($password);

		$sql_query = "INSERT INTO programmer VALUES(null, '$name', '$surname', '$e_mail_address', '$telephone', '$username', '$password_md5');";
		$result = mysql_query($sql_query, $sql_link);

		if(!$result)
		{
			die("<h1>QUERY FAILED:</h1><br>$sql_query");
		}
		return true;
	}
	
	/**
	 * Enter description here...
	 *
	 * @param unknown_type $sender_id
	 * @param unknown_type $receiver_id
	 * @param unknown_type $subject
	 * @param unknown_type $message
	 * @param unknown_type $timestamp
	 * @param unknown_type $is_manager
	 */
	
	function send_new_message($sender_id, $receiver_id, $subject, $message,$receiver_is_manager)
	{
		// Ανάλογα με τον τύπο του παραλήπτη επιλέγεται και ο πίνακας στον οποίο θα εισαχθεί το μήνυμα.
		if ($receiver_is_manager)
		{
			$target_table = 'managers_messages';
		}
		else
		{
			$target_table = 'programmers_messages';
		}
		
		$timestamp = time();
		
		$sql_query = "INSERT INTO $target_table VALUES(null, $sender_id, $receiver_id, '$subject', '$message', $timestamp, 0);";
		$sql_link = get_data_base_connection();
		$result = mysql_query($sql_query, $sql_link);
		
		if(!$result)
		{
			die("<h1>QUERY FAILED:</h1><br>$sql_query");
		}
	}
	
	/**
	 * Enter description here...
	 *
	 * @param unknown_type $user_id
	 * @param unknown_type $return_read_messages
	 * @param unknown_type $user_is_manager
	 * @return unknown
	 */
	
	function get_messages_headers($user_id, $return_read_messages, $user_is_manager)
	{
		// Ανάλογα με το εάν ο χρήστης είναι υπεύθυνος ή όχι, επιλέγεται και ο πίνακας από στον οποίο θα αναζητηθούν τα μηνύματα.
		if ($user_is_manager)
		{
			$query = "SELECT tt.id, st.username, tt.subject, tt.send_time, tt.read, st.id FROM managers_messages as tt, programmer as st WHERE tt.man_id = $user_id AND tt.prog_id = st.id";
		}
		else
		{
			$query = "SELECT tt.id, st.username, tt.subject, tt.send_time, tt.read, st.id FROM programmers_messages as tt, manager as st WHERE tt.prog_id = $user_id AND tt.man_id = st.id";
		}
		
		if (!$return_read_messages)
		{
			// Έτσι επιστρέφονται μόνο τα μη ανεγνωσμένα μηνύματα.
			$sql_query = "$query" . " AND tt.read = 0;";
		}
		else
		{
			// Έτσι επιστρέφονται όλα τα μηνύματα.
			$sql_query = "$query" . ";";
		}
		
		$sql_link = get_data_base_connection();
		$headers = mysql_query($sql_query, $sql_link);

		if (!$headers)
		{
			die("<h1>QUERY FAILED:</h1><br>$sql_query");
		}

		// Ελέγχεται εάν έχει επιστραφεί αποτέλεσμα.
		if (mysql_num_rows($headers) == 0)
		{
			return false;
		}
		
		return $headers;
	}
	
	/**
	 * Enter description here...
	 *
	 * @param unknown_type $user_id
	 * @param unknown_type $user_is_manager
	 * @return unknown
	 */
	
	function get_message($message_id, $user_is_manager)
	{
		// Ανάλογα με το εάν ο χρήστης είναι υπεύθυνος ή όχι, επιλέγεται και ο πίνακας από στον οποίο θα αναζητηθεί το μήνυμα.
		if ($user_is_manager)
		{
			$target_table = 'managers_messages';
		}
		else
		{
			$target_table = 'programmers_messages';
		}
		
		$sql_query = "SELECT message FROM $target_table WHERE id = $message_id";
		$sql_link = get_data_base_connection();
		$message = mysql_query($sql_query, $sql_link);

		if (!$message)
		{
			die("<h1>QUERY FAILED:</h1><br>$sql_query");
		}

		// Ελέγχεται εάν έχει επιστραφεί αποτέλεσμα.
		if (mysql_num_rows($message) == 0)
		{
			return false;
		}
		return $message;
	}
	
	
	/**
	 * Enter description here...
	 *
	 * @return unknown
	 */
	
	function get_projects()
	{
		// Δεν επιστρέφεται το description.
		$sql_query = "SELECT id, name, start_date, end_date, logo_path FROM project;";
		$sql_link = get_data_base_connection();
		$projects = mysql_query($sql_query, $sql_link);

		if (!$projects)
		{
			die("<h1>QUERY FAILED:</h1><br>$sql_query");
		}

		if (mysql_num_rows($projects) == 0)
		{
			return false;
		}
		return $projects;
	}
	
	/**
	 * Enter description here...
	 *
	 * @param unknown_type $id
	 * @return unknown
	 */
	
	function get_project_description($id)
	{
		$sql_query = "SELECT description FROM project WHERE id = $id;";
		$sql_link = get_data_base_connection();
		$project_description = mysql_query($sql_query, $sql_link);

		if (!$project_description)
		{
			die("<h1>QUERY FAILED:</h1><br>$sql_query");
		}

		if (mysql_num_rows($project_description) == 0)
		{
			return false;
		}
		return $project_description;
	}
	
	/**
	 * Enter description here...
	 *
	 * @param unknown_type $project_id
	 * @return unknown
	 */
	
	function get_project_tasks($project_id)
	{
		$sql_query = "SELECT ta.id, ta.title, p.username, ta.hours_spent, ta.acomplished FROM task_assignment as ta, programmer as p WHERE ta.proj_id = $project_id AND ta.prog_id = p.id;";
		$sql_link = get_data_base_connection();
		$tasks = mysql_query($sql_query, $sql_link);

		if (!$tasks)
		{
			die("<h1>QUERY FAILED:</h1><br>$sql_query");
		}

		if (mysql_num_rows($tasks) == 0)
		{
			return false;
		}
		return $tasks;
	}
	
	/**
	 * Enter description here...
	 *
	 * @param unknown_type $id
	 * @return unknown
	 */
	
	function get_programmers()
	{
		// Δεν επιστρέφεται το md5_password.
		$sql_query = "SELECT id, surname, name, e_mail_address, telephone, username FROM programmer";
		
		$sql_link = get_data_base_connection();
		$programmers = mysql_query($sql_query, $sql_link);

		if (!$programmers)
		{
			die("<h1>QUERY FAILED:</h1><br>$sql_query");
		}

		if (mysql_num_rows($programmers) == 0)
		{
			return false;
		}
		return $programmers;
	}
	
	/**
	 * Enter description here...
	 *
	 * @param unknown_type $programmer_id
	 * @return unknown
	 */
	
	function get_programmer_tasks($programmer_id)
	{
		$sql_query = "SELECT ta.id, ta.title, p.name, ta.hours_spent, ta.acomplished FROM task_assignment as ta, project as p WHERE ta.prog_id = $programmer_id AND ta.proj_id = p.id;";
		$sql_link = get_data_base_connection();
		$tasks = mysql_query($sql_query, $sql_link);

		if (!$tasks)
		{
			die("<h1>QUERY FAILED:</h1><br>$sql_query");
		}

		if (mysql_num_rows($tasks) == 0)
		{
			return false;
		}
		return $tasks;
	}
?>