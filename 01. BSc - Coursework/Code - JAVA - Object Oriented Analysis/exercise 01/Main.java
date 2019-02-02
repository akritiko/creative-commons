
public class Main {

	public static void main(String[] args) {
		
		/*
		 * Εκτελούμε καθαρισμό του buffer εξόδου στην οθόνη ώστε να
		 * αποφύθγουμε πιθανές απώλειες στοιχείων κατά την εμφάνιση 
		 * στην οθόνη.
		 */
		
		System.out.flush();
		
		//Δημιουργία ενός αντικειμένου τύπου ArrayHandler 50 θέσεων
		ArrayHandler myExample = new ArrayHandler(50);
		
		//Παραγωγή των τυχαίων αριθμών
		myExample.generateMyNumbers();
		
		System.out.println();
		System.out.println("Elements before bubbleSort!");
		System.out.println("-------- ------ -----------");
		//Εκτύπωση δεδομένων πριν την ταξινόμηση
		myExample.printElements(1,50);
		
		//Ταξινόμηση με bubbleSort
		myExample.bubbleSort();
		
		System.out.println();
		System.out.println("Elements after bubbleSort!");
		System.out.println("-------- ----- -----------");
		//Εκτύπωση δεδομένων μετά την ταξινόμηση
		System.out.println();
		myExample.printElements(1,50);		

	}

}
