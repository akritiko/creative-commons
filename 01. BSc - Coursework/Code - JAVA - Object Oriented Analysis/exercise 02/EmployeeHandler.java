import java.io.*;
import java.util.ArrayList;
import java.util.Random;

/**
 * @author Apostolos Kritikos
 * 
 * Κλάση EmployeeHandler: Αναλαμβάνει την εισαγωγή και διαγραφή υπαλλήλων από το
 * σύστημα και ενημερώνει τον πίνακα υπαλλήλων που ορίζεται στην κλάση Main.
 * Κατά σύμβαση πραγματοποιούμε τη διαγραφή υπαλλήλου με βάση τον αριθμό μητρόου
 * του.
 * 
 */

public class EmployeeHandler {

	private ArrayList<DetailedEmployee> employees;

	/**
	 * @param currentNumberOfEmployees
	 * @param currentEmployees
	 */

	public EmployeeHandler(ArrayList<DetailedEmployee> employees) {

		this.employees = employees;
	}

	public void AddEmployee(Statistics stats) throws IOException {

		Random randomizer = new Random();
		BufferedReader input = new BufferedReader(new InputStreamReader(
				System.in));
		DetailedEmployee newEmployee;

		// Δίνεται ένας τυχαίος αριθμός μεταξύ του 0 και 1000000 σαν αριθμός
		// μητρόου
		int recordNumber = randomizer.nextInt(1000000);
		String name = new String();
		String specialty = new String();
		int numberOfChildren;
		int choice;

		System.out.println();
		System.out.println("ΕΙΣΑΓΩΓΗ ΝΕΟΥ ΥΠΑΛΛΗΛΟΥ");
		System.out.println();

		System.out.print("Όνοματεπώνυμο: ");
		name = input.readLine();

		System.out.print("Ειδικότητα: ");
		specialty = input.readLine();

		System.out.println();
		System.out.print("Κατηγορία: ");
		System.out.println();
		System.out.println("Ωρομίσθιος (1)");
		System.out.println("Μισθωτός (2)");
		System.out.println("Υπεύθυνος (3)");
		System.out.println();
		System.out
				.print("Επιλέξτε κατηγορία εισάγοντας τον κατάλληλο αριθμό: ");

		/**
		 * Εδώ ελέγχεται ο τύπος που δίνεται από τον χρήστη και αν δεν είναι
		 * ικανοποιητικός επιστρέφουμε στο μενού
		 */
		try {
			choice = Integer.parseInt(input.readLine());

		} catch (NumberFormatException e) {
			return;
		}
		System.out.flush();
		System.out.print("Αριθμός τέκνων: ");

		/**
		 * Εδώ ελέγχεται ο τύπος που δίνεται από τον χρήστη και αν δεν είναι
		 * ικανοποιητικός επιστρέφουμε στο μενού
		 */
		try {
			numberOfChildren = Integer.parseInt(input.readLine());
		} catch (NumberFormatException e) {
			return;
		}

		/**
		 * Εδώ δημιουργούμε ένα αντικείμενο τύπου DetailedEmployee για να
		 * αρχικοποιηθεί με τα δεδομένα που πήραμε από τον χρήστη. Εξετάζουμε
		 * την κατηγορία και ανάλογα καλούμε τον δημιουργό με το κατάλληλο
		 * όρισμα. Επίσης ενημερώνουμε κατάλληλα και τα στατιστικά.
		 */

		switch (choice) {
		case 1:
			newEmployee = new DetailedEmployee(name, recordNumber, specialty,
					Category.TIMEWORKER, numberOfChildren);
			employees.add(newEmployee);
			/**
			 * Ενημέρωση στατιστικών
			 */
			increaseStatistics(stats, newEmployee);
			break;
		case 2:
			newEmployee = new DetailedEmployee(name, recordNumber, specialty,
					Category.WAGEWORKER, numberOfChildren);
			employees.add(newEmployee);
			/**
			 * Ενημέρωση στατιστικών
			 */
			increaseStatistics(stats, newEmployee);
			break;
		case 3:
			newEmployee = new DetailedEmployee(name, recordNumber, specialty,
					Category.SUPERVISOR, numberOfChildren);
			employees.add(newEmployee);
			/**
			 * Ενημέρωση στατιστικών
			 */
			increaseStatistics(stats, newEmployee);
			break;
		}
	}

	public void deleteEmployee(Statistics stats) throws IOException {

		BufferedReader input = new BufferedReader(new InputStreamReader(
				System.in));
		boolean wasDeleted = false;
		// Εδώ καταχωρείται ο αριθμός μητρόου του "θύματος"
		int victimsRecordNumber;

		/**
		 * Εμφάνιση των υπαλλήλων στην οθόνη για να επιλέξει ο χρήστης ποιος θα
		 * διαγραφεί.
		 */

		System.out.println();
		System.out.println("ΕΓΓΕΓΡΑΜΕΝΟΙ ΥΠΑΛΛΗΛΟΙ");
		System.out.println();
		System.out.println("ΟΝΟΜΑΤΕΠΩΝΥΜΟ" + '\t' + '\t' + "ΑΡ. ΜΗΤΡΟΟΥ");
		System.out.println();

		for (int i = 0; i < employees.size(); i++) {
			System.out.println(employees.get(i).getName() + '\t' + '\t'
					+ employees.get(i).getRecordNumber());
		}

		System.out.println();
		System.out
				.println("Επιλέξτε τον Αριθμό μητρόου του υπαλλήλου που θέλετε να διαγράψετε: ");

		/**
		 * Εδώ ελέγχεται ο τύπος που δίνεται από τον χρήστη και αν δεν είναι
		 * ικανοποιητικός επιστρέφουμε στο μενού
		 */
		try {
			victimsRecordNumber = Integer.parseInt(input.readLine());
		} catch (NumberFormatException e) {
			return;
		}

		for (int i = 0; i < employees.size(); i++) {
			if (employees.get(i).getRecordNumber() == victimsRecordNumber) {

				// Αλλάζουν τα στατιστικά κατά το δοκούν
				decreaseStatistics(stats, employees.get(i));

				employees.remove(i);

				// Η διαγραφή έγινε
				wasDeleted = true;
			}
		}
		if (!wasDeleted) {
			System.out.println();
			System.out.println("Ο υπάλληλος δεν βρέθηκε");
		} else {
			System.out.println();
			System.out.println("Ο υπάλληλος διεγράφη με επιτυχία!");
		}
	}

	/**
	 * Αύξηση των στατιστικών με βάσει τις αλλαγές που έλαβαν χώρα (εισαγωγή
	 * υπαλλήλου) και την κατηγορία αυτού
	 */

	private void increaseStatistics(Statistics stats,
			DetailedEmployee newEmployee) {
		stats.increaseCategorizedPayroll(newEmployee.getCategory(), newEmployee
				.getTotalSalary());

		stats.increaseTotalPayroll(newEmployee.getTotalSalary());

	}

	/**
	 * Μείωση των στατιστικών με βάσει τις αλλαγές που έλαβαν χώρα (διαγραφή
	 * υπαλλήλου) και την κατηγορία αυτού
	 */

	
	private void decreaseStatistics(Statistics stats,
			DetailedEmployee newEmployee) {
		stats.decreaseCategorizedPayroll(newEmployee.getCategory(), newEmployee
				.getTotalSalary());
		stats.decreaseTotalPayroll(newEmployee.getTotalSalary());
	}
}
