
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

/**
 * @author Apostolos Kritikos
 */

/**
 * Κλάση DetailedEmployee: Κληρονομεί από την αφηρημένη κλάση employee και την
 * επεκτείνει με 3 νέα χαρακτηριστικά. Στην πράξη, κανένα από τα νέα αυτά
 * χαρακτηριστικά δεν δίνεται από τον χρήστη αλλά όλα υπολογίζονται από τα
 * χαρακτηριστικά που προσφέρει η υπερκλάση Employee. Το μόνο δεδομένο που
 * ζητέιται από τον χρήστη είναι οι εργατοώρες σε περίπτωση που η κατηγορία του
 * υπαλλήλου είναι ΩΡΟΜΙΣΘΙΟΣ.
 */

public class DetailedEmployee extends Employee {

	private double basicSalary;

	private double benefitFromChildren;

	private double totalSalary;

	/**
	 * @param name
	 * @param recordNumber
	 * @param specialty
	 * @param category
	 * @param numberOfChildren
	 * @throws IOException
	 */

	public DetailedEmployee(String name, int recordNumber, String specialty,
			Category category, int numberOfChildren) throws IOException {
		super(name, recordNumber, specialty, category, numberOfChildren);

		switch (category) {

		/**
		 * Υπολογίζονται οι επιμέρους αμοιβές καθώς και ο τελικός μισθός του
		 * υπαλλήλου ανάλολγα με την κατηγορία του.
		 */

		case (TIMEWORKER):

			int hours = 1;
			BufferedReader inputHours = new BufferedReader(
					new InputStreamReader(System.in));

			System.out
					.print("Δώστε των αριθμό ωρών που εργάστηκε ο υπάλληλος: ");

			/**
			 * Εδώ ελέγχεται ο τύπος που δίνεται από τον χρήστη και αν δεν είναι
			 * ικανοποιητικός επιστρέφουμε στο μενού
			 */
			try {
				hours = Integer.parseInt(inputHours.readLine());

			} catch (NumberFormatException e) {
				return;
			}
			this.basicSalary = hours * 5;
			double productivityBenefit = basicSalary * 0.06;
			this.benefitFromChildren = 0;
			this.totalSalary = basicSalary + productivityBenefit;
			break;
			
			/**
			 * Υπολογισμοί ανάλογα με την κατηγορία του υπαλλήλου
			 */

		case (WAGEWORKER):
			this.basicSalary = 500;
			this.benefitFromChildren = basicSalary * 0.1 * numberOfChildren;
			this.totalSalary = basicSalary + benefitFromChildren;
			break;

		case (SUPERVISOR):
			double supervisorsBenefit = 3 * basicSalary;
			this.basicSalary = 700;
			this.benefitFromChildren = basicSalary * 0.1 * numberOfChildren;
			this.totalSalary = basicSalary + benefitFromChildren
					+ supervisorsBenefit;
			break;
		}
	}

	/**
	 * @return Returns the basicSalary.
	 */
	public double getBasicSalary() {
		return basicSalary;
	}

	/**
	 * @param basicSalary
	 *            The basicSalary to set.
	 */
	public void setBasicSalary(float basicSalary) {
		this.basicSalary = basicSalary;
	}

	/**
	 * @return Returns the benefitFromChildren.
	 */
	public double getBenefitFromChildren() {
		return benefitFromChildren;
	}

	/**
	 * @param benefitFromChildren
	 *            The benefitFromChildren to set.
	 */
	public void setBenefitFromChildren(float benefitFromChildren) {
		this.benefitFromChildren = benefitFromChildren;
	}

	/**
	 * @return Returns the totalSalary.
	 */
	public double getTotalSalary() {
		return totalSalary;
	}

	/**
	 * @param totalSalary
	 *            The totalSalary to set.
	 */
	public void setTotalSalary(float totalSalary) {
		this.totalSalary = totalSalary;
	}

}
