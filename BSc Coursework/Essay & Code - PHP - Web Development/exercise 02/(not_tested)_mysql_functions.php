<?php


	/**
	 * Enter description here...
	 *
	 * @param unknown_type $id
	 * @param unknown_type $user_type
	 * @return unknown
	 */
	
	function set_message_read($message_id, $sender_is_manager)
	{
		if ($sender_is_manager)
		{
			$table = 'programmers_messages';
		}
		else // $user_type == manager
		{
			$table = 'managers_messages';
		}
		
		$sql_query = "UPDATE $table SET read = '1' WHERE id = $message_id;";
		$sql_link = get_data_base_connection();
		$result = mysql_query($sql_query, $sql_link);

		if (!$result)
		{
			die("<h1>QUERY FAILED:</h1><br>$sql_query");
		}

		// Εάν επιστραφεί αποτέλεσμα, τότε υπάρχει χρήστης με αυτό το username.
		if (mysql_affected_rows($result) != 0)
		{
			return false;
		}
		return true;
	}
/**
	 * Enter description here...
	 *
	 * @param unknown_type $id
	 * @return unknown
	 */
	
	function delete_programmer($id)
	{
		// Αναζητείται ο προγραμματιστής με το διδόμενο id.
		$sql_query = "DELETE FROM programmer WHERE id = '$id';";
		$sql_link = get_data_base_connection();
		$result = mysql_query($sql_query, $sql_link);

		if (!$result)
		{
			die("<h1>QUERY FAILED:</h1><br>$sql_query");
		}

		// Ελέγχεται εάν έχει πραγματοποιηθεί η διαγραφή.
		if (mysql_affected_rows() == 0)
		{
			return false;
		}
		return true;
	}

/**
	 * Enter description here...
	 *
	 * @param unknown_type $id
	 * @param unknown_type $name
	 * @param unknown_type $surname
	 * @param unknown_type $e_mail_address
	 * @param unknown_type $telephone
	 * @param unknown_type $md5_password
	 * @return unknown
	 */
	
	function update_programmer($id, $name, $surname, $e_mail_address, $telephone, $md5_password)
	{
		// ΔΕΝ ΕΠΙΤΡΕΠΕΤΑΙ Η ΑΛΛΑΓΗ ΤΟΥ username ΚΑΙ ΤΟΥ id!!!
		
		$sql_query = "UPDATE programmer SET name = $name, surname = $surname, e_mail_address = $e_mail_address, $telephone = $telephone, $md5_password = $md5_password WHERE id = $id;";
		$sql_link = get_data_base_connection();
		$result = mysql_query($sql_query, $sql_link);

		if (!$result)
		{
			die("<h1>QUERY FAILED:</h1><br>$sql_query");
		}

		// Εάν επιστραφεί αποτέλεσμα, τότε υπάρχει χρήστης με αυτό το username.
		if (mysql_affected_rows($result) != 0)
		{
			return false;
		}
		return true;
	}
?>