
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;

/**
 * @author Apostolos Kritikos
 * 
 * Για την ορθή λειτουργία του προγράμματος απαιτείται το JDK Compliance να έχει
 * οριστεί σε 5.0. Διαφορετικά η enumeration class Category δεν θα αναγνωριστεί.
 * Οι υπάλληλοι αποθηκεύονται σε ArrayLisy. Η συγκεκριμένη δομή επιλέχθηκε γιατί
 * παρακτικά προσφέρει έναν δυναμικό πίνακα που υλοποιεί όλες τις λειτουργίες
 * μιας συνδεδεμένης λίστας. Ο εξ ορισμού χώρος που καταλαμβάνει αρχικά είναι 10
 * θέσεων. Με αυτόν τον τρόπο αποφεύγουμε την ανάγκη δημιουργίας μεθόδων
 * αυξομείωσης του μεγέθους του πίνακα αφού η κλάση ArrayList αναλαμβάνει το
 * χειρισμό αυτό.
 * 
 */

public class Main {

	public static void main(String[] args) throws IOException {

		/**
		 * Καθαρισμός των καναλιών εξόδου και σφαλμάτων
		 */
		System.out.flush();
		System.err.flush();

		/**
		 * Δηλώσεις: Η δομή ArrayList, ένας EmployeeHandler για την εισαγωγή /
		 * διαγραφή υπαλλήλων, και ένα αντικείμενο Statistics για την ενημέρωση
		 * των στατιστικών (να σημειωθεί ότι το αντικείμενο Statistics
		 * χρησιμοποιείται σαν παράμετρος στη δημιουργία ή διαγραφή υπαλλήλων.
		 */

		BufferedReader input = new BufferedReader(new InputStreamReader(
				System.in));
		ArrayList<DetailedEmployee> employees = new ArrayList<DetailedEmployee>();
		EmployeeHandler handler = new EmployeeHandler(employees);
		Statistics stats = new Statistics();

		int menuChoice;

		/**
		 * Μενού
		 */

		do {
			System.out.println();
			System.out.println("ΠΡΟΓΡΑΜΜΑ ΔΙΑΧΕΙΡΙΣΗΣ ΥΠΑΛΛΗΛΩΝ");
			System.out.println();
			System.out.println("(1) Εισαγωγή υπαλλήλου");
			System.out.println("(2) Διαγραφή υπαλλήλου");
			System.out.println("(3) Αποθήκευση πίνακα υπαλλήλων σε αρχείο");
			System.out.println("(4) Φόρτωση πίνακα υπαλλήλων από αρχείο");
			System.out.println("(5) Εμφάνιση στατιστικών");
			System.out.println("(0) Έξοδος");

			System.out.println();
			System.out
					.print("Επιλέξτε ενέργεια πληκτρολογώντας τον αντίστοιχο αριθμό: ");

			/**
			 * Αν ο χρήστης δώσει invalid χαρακτήρα το πρόγραμμα του επιστρέφει
			 * μήνυμα και πραγματοποιεί ένα loop στην είσοδο επιλογής.
			 */

			try {

				menuChoice = Integer.parseInt(input.readLine());

			} catch (NumberFormatException e) {
				menuChoice = 6;
			}

			switch (menuChoice) {
			case 0:
				System.out.println();
				System.out.println("Το πρόγραμμα τερματίστηκε!");
				break;
			case 1:
				handler.AddEmployee(stats);
				break;
			case 2:
				handler.deleteEmployee(stats);
				break;
			case 3:
				System.out.println("ΥΠΟ ΚΑΤΑΣΚΕΥΗ");
				break;
			case 4:
				System.out.println("ΥΠΟ ΚΑΤΑΣΚΕΥΗ");
				break;
			case 5:
				System.out.println();
				System.out.println("ΣΤΑΤΙΣΤΙΚΑ:");
				System.out.println();
				System.out.print("Συνολικο μισθολόγιο: ");
				System.out.print(stats.getTotalPayroll());
				System.out.println();
				
				/**
				 * Αναλαμβάνει να τυπώσει το μισθολόγιο ανα κατηγορία υπαλλήλου
				 */
				for (int i = 0; i < 3; i++) {

					System.out.print("Μισθολόγιο ");
					System.out.print(stats.getCategoryName(i));
					System.out.print(": ");
					System.out.print(stats.getCategorizedPayroll(i));
					System.out.println();
				}
				break;
			default:
				System.out.println();
				System.out.println("Η επιλογή πρέπει να είναι μεταξύ 0-5");
				break;
			}

		} while (menuChoice != 0);

	}
}