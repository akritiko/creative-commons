

/**
 * @author Apostolos Kritikos
 * 
 */
public abstract class Employee {

	/**
	 * Κλάση Employee (abstract): Περιγφράφη την οντότητα του υπαλλήλου και περιέχει τα
	 * βασικά στοιχεία αυτού. Κατα σύμβαση θεωρούμε ότι το name αντιστοιχεί στο
	 * ονοματεπώνυμο. Αυτό συμβαίνει γιατί αφενός η παρούσα άσκηση δεν απαιτεί
	 * χρήση του ονόματος και επωνύμου ξεχωριστά και αφετέρου η μοναδικότητα του
	 * εκάστοτε υπαλλήλου εξασφαλίζεται από τον αριθμό μητρόου. Ο recordNumber
	 * αποτελεί το αναγνωριστικό του υπαλλήλου. Η specialty αναφέρεται στην
	 * ειδικότητα του υπαλλήλου. Η category αποτελεί την κατηγορία στην οποία
	 * ανήκει ο υπάλληλος και είναι τύπου category (μια κλάση enumeration).
	 * Τέλος το numberOfChildren αφορά το αριθμό παιδιών του υπαλλήλου.
	 */

	private String name;

	private int recordNumber;

	private String specialty;

	private Category category;

	private int numberOfChildren;

	/**
	 * @param name
	 * @param recordNumber
	 * @param specialty
	 * @param category
	 * @param numberOfChildren
	 */
	
	public Employee(String name, int recordNumber, String specialty,
			Category category, int numberOfChildren) {

		this.name = name;
		this.recordNumber = recordNumber;
		this.specialty = specialty;
		this.category = category;
		this.numberOfChildren = numberOfChildren;
	}

	/**
	 * @return Returns the recordNumber.
	 */
	public int getRecordNumber() {
		return recordNumber;
	}

	/**
	 * @param recordNumber
	 *            The recordNumber to set.
	 */
	public void setRecordNumber(int recordNumber) {
		this.recordNumber = recordNumber;
	}

	/**
	 * @return Returns the category.
	 */
	public Category getCategory() {
		return category;
	}

	/**
	 * @param category
	 *            The category to set.
	 */
	public void setCategory(Category category) {
		this.category = category;
	}

	/**
	 * @return Returns the name.
	 */
	public String getName() {
		return name;
	}

	/**
	 * @param name
	 *            The name to set.
	 */
	public void setName(String name) {
		this.name = name;
	}

	/**
	 * @return Returns the numberOfChildren.
	 */
	public int getNumberOfChildren() {
		return numberOfChildren;
	}

	/**
	 * @param numberOfChildren
	 *            The numberOfChildren to set.
	 */
	public void setNumberOfChildren(int numberOfChildren) {
		this.numberOfChildren = numberOfChildren;
	}

	/**
	 * @return Returns the specialty.
	 */
	public String getSpecialty() {
		return specialty;
	}

	/**
	 * @param specialty
	 *            The specialty to set.
	 */
	public void setSpecialty(String specialty) {
		this.specialty = specialty;
	}
}
