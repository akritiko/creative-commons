import java.util.Random;

public class ArrayHandler { //Η κλάση που δημιουργεί και διαχειρίζεται τον πίνακα

	private int [] myArray;
	
	public ArrayHandler(int numberOfElements) //Δημιουργός
	{
		//Αρχικοποίηση του πίνακα μέγεθος numberOfElements.
		myArray = new int [numberOfElements];
		
	}
	
	public void generateMyNumbers() //Μέθοδος παραγωγής ψευδοτυχαίων αριθμων
	{
		int i;
		
		/* 
		 * Χρησιμοποιείται η κλάση Random που βρίσκεται στο πακέτο 
		 * πυρήνα java.util για την παραγωγή των ψευδοτυχαίων αριθμών
		 * (κατά σύμβαση ακεραίων).
		 */
		
		Random myRandomizer = new Random();
		
		for (i = 0; i < this.myArray.length; i++) //Ανάθεση των τιμών στον πίνακα
		{
			this.myArray[i] = myRandomizer.nextInt();
		}
	}
	
	public void bubbleSort() //Μέθοδος ταξινόμησης με χρήση του αλγορίθμου bubbleSort
	{
		int i,j;
		
		for (i = 0; i < this.myArray.length - 1; i++)
			for (j = 0; j < this.myArray.length - 1 - i; j++)
				if (this.myArray[j + 1] < this.myArray[j])
				{
					int temp = this.myArray[j];
					this.myArray[j] = this.myArray[j + 1];
					this.myArray[j + 1] = temp;
				} 
	} 
	
	/*
	 * Εκτύπωση των στοιχείων στην οθόνη. Για την καλύτερη και ευτκολότερη εποπτεία
	 * τα στοιχεία εμφανίζονται κατακόρυφα. Αν και η java μετρά σαν πρώτη θέση του
	 * πίνακα τη μηδενική η συνάρτηση προσαρμόζει τα όρια ώστε ο χρήστης να μπορεί 
	 * να θεωρεί το 1 σαν αρχή του πίνακα χωρίς πρόβλημα.
	 */
	
	public void printElements(int i, int j) 
	{
		int k;
		
		for (k = i-1;k<j;k++)
		{
			System.out.println(this.myArray[k] + ",");
		}		
	}

}
