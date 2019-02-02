package dbms.util;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.RandomAccessFile;
import java.nio.ByteBuffer;

import dbms.Main;

/**
 * This class implements a handler for the static data inside our disk.
 * It retrieves and stores the contents of our database into the appropriate
 * files.
 */
public class DiskHandler {
	/**
	 * It loads a page from the disk and returns it to a <code>Page</code>
	 * object.
	 * 
	 * @param pageNumber
	 *            The number of the page-target.
	 * @param bucketFactor
	 *            The bucket factor.
	 * @param emptyRecord
	 *            The record that will host the data that the page returned.
	 * @return The page loaded.
	 */
	public static Page loadPage(final int pageNumber, final int bucketFactor,
			final Record emptyRecord) {
		Page newPage = null;
		try {
			// Ανοίγει το αρχείο που αποθηκεύει τις σελίδες του τρέχοντα
			// καταλόγου.
			RandomAccessFile file = new RandomAccessFile(Main.getCurrentTable()
					.getName()
					+ ".pgs", "r");

			// Υπολογίζεται τη θέση της επιθυμητής σελίδας στο αρχείο...
			file.seek(pageNumber * Main.PAGE_SIZE);

			// και διαβάζεται ένα πλήθος byte ίσο με PAGE_SIZE.
			byte[] byteArray = new byte[Main.PAGE_SIZE];
			file.readFully(byteArray);

			// Αποθηκεύονται τα byte αυτά σε ένα buffer.
			ByteBuffer allData = ByteBuffer.wrap(byteArray);

			// Δομείται τη σελίδα.
			newPage = new Page(bucketFactor, allData, emptyRecord
					.getRecordSize());

			// Το αρχείο κλείνει.
			file.close();
		} // end try
		catch (FileNotFoundException e) {
			// Εάν δεν βρεθεί το αρχείο, τότε επιστρέφεται μια κενή σελίδα.
			newPage = new Page(bucketFactor, emptyRecord);
		} // end catch
		catch (IOException e) {
			System.err.println("Fatal error! Reading page <" + pageNumber
					+ "> failed!");
			System.exit(-1);
		} // end catch
		return newPage;
	} // end method loadPage

	/**
	 * It writes a page to a file on the disk.
	 * 
	 * @param page
	 *            The page which is about to be written to a file.
	 * @param pageNumber
	 *            The number that shows the index of the page.
	 */
	public static void writePage(final Page page, final int pageNumber) {
		try {
			// Ανοίγει το αρχείο που αποθηκεύει τις σελίδες του τρέχοντα
			// καταλόγου.
			RandomAccessFile file = new RandomAccessFile(Main.getCurrentTable()
					.getName()
					+ ".pgs", "rw");

			// Υπολογίζεται η θέση της επιθυμητής σελίδας στο αρχείο...
			file.seek(pageNumber * Main.PAGE_SIZE);

			// και η σελίδα γράφεται στο αρχείο ως μια σειρά από byte.
			file.write(page.toByteArray());

			// Το αρχείο κλείνει.
			file.close();
		} // end try
		catch (IOException e) {
			System.err.println("Fatal error! Writing page <" + pageNumber
					+ "> failed!");
			System.exit(-1);
		} // end catch
	} // end method writePage

	/**
	 * Retrieves the data of the database from the disk.
	 * 
	 * @return <code>DBMSData</code> object.
	 */
	public static DBMSData loadData() {
		DBMSData data = null;

		try {
			// Ανοίγει το αρχείο στο οποίο είναι αποθηκευμένα τα δεδομένα
			ObjectInputStream file = new ObjectInputStream(new FileInputStream(
					Main.dbmsFilepath));

			// Διαβάζονται τα δεδομένα.
			data = (DBMSData) file.readObject();

			// Το αρχείο κλείνει.
			file.close();
		} // end try
		catch (ClassNotFoundException e) {
			System.err.println("Can not define class <DBMSData>!");
			System.exit(-1);
		} // end catch
		catch (IOException e) {
			System.err.println("Fatal error! File <" + Main.dbmsFilepath
					+ "> not found!");
		} // end catch

		return data;
	} // end method loadData

	/**
	 * Writes the data of the database to a file into the disk.
	 * 
	 * @param data
	 *            The <code>DBMSData</code> object that contains the data as
	 *            they are.
	 */
	public static void writeData(DBMSData data) {
		try {
			// Ανοίγει το αρχείο στο οποίο θα αποθηκευτεί ο πίνακας.
			ObjectOutputStream file = new ObjectOutputStream(
					new FileOutputStream(Main.dbmsFilepath));

			// Γράφεται ο πίνακας.
			file.writeObject(data);

			// Το αρχείο κλείνει.
			file.close();
		} // end try
		catch (IOException e) {
			System.err.println("Fatal error! File <" + Main.dbmsFilepath
					+ "> could not be written!");
			System.exit(-1);
		} // end catch
	} // end method writeData
} // end class DiskHandler
