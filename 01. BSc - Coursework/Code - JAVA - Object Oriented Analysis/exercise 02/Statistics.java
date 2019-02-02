
/**
 * @author Apostolos Kritikos
 */

/**
 * Κλάση Statistics: Κρατά στατιστικά για τους υπαλλήλους της επιχείρησης.
 */

public class Statistics {

	/**
	 * Αρχικοποιούμε τα χαρακτηριστικά με μηδέν. Δεν το κάνουμε στον δημιουργό
	 * για να αποφύγουμε τη χρήση for loop για την αρχικοποίηση του πίνακα σε
	 * μηδέν.
	 */

	private double totalPayroll = 0; // Συνολικά

	private double[] categorizedPayroll = { 0, 0, 0 }; // Ανά κατηγορία

	/**
	 * @param totalPayroll
	 * @param categorizedPayroll
	 */

	/**
	 * Κενός δημιουργός αφού στην αρχή όλα τα χαρακτηριστικά είναι μηδενικά
	 */

	public Statistics() {

	}
	
	/**
	 * Αύξηση του TotalPayroll 
	 */

	public void increaseTotalPayroll(double newPayroll) {
		this.totalPayroll = this.totalPayroll + newPayroll;
	}
	
	/**
	 * Αύξηση του TotalPayroll ανα κατηγορία
	 */

	public void increaseCategorizedPayroll(Category category, double newPayroll) {
		switch (category) {
		case TIMEWORKER:
			this.categorizedPayroll[0] = this.categorizedPayroll[0]
					+ newPayroll;
			break;
		case WAGEWORKER:
			this.categorizedPayroll[1] = this.categorizedPayroll[1]
					+ newPayroll;
			break;
		case SUPERVISOR:
			this.categorizedPayroll[2] = this.categorizedPayroll[2]
					+ newPayroll;
			break;
		}
	}

	/**
	 * Μείωση του TotalPayroll 
	 */

	
	public void decreaseTotalPayroll(double newPayroll) {
		this.totalPayroll = this.totalPayroll - newPayroll;
	}
	
	/**
	 * Αύξηση του TotalPayroll ανα κατηγορία
	 */


	public void decreaseCategorizedPayroll(Category category, double newPayroll) {
		switch (category) {
		case TIMEWORKER:
			this.categorizedPayroll[0] = this.categorizedPayroll[0]
					- newPayroll;
			break;
		case WAGEWORKER:
			this.categorizedPayroll[1] = this.categorizedPayroll[1]
					- newPayroll;
			break;
		case SUPERVISOR:
			this.categorizedPayroll[2] = this.categorizedPayroll[2]
					- newPayroll;
			break;
		}
	}
	
	/**
	 * Επιστρέφει τα ονόματα των κατηγοριών υπαλλήλων
	 */

	
	public String getCategoryName(int choice) {

		switch (choice) {
		case 0:
			return "Ωρομίσθιοι";
		case 1:
			return "Μισθωτοί";
		case 2:
			return "Υπεύθυνοι";
		default:
			return "";
		}
	}

	/**
	 * @return Returns the categorizedPayroll.
	 */
	public double getCategorizedPayroll(int choice) {
		return categorizedPayroll[choice];
	}

	/**
	 * @return Returns the totalPayroll.
	 */
	public double getTotalPayroll() {
		return totalPayroll;
	}

}
