package dbms.util;

import java.nio.ByteBuffer;
import java.util.LinkedList;

import dbms.Main;

/**
 * Describes the page class as it is declared in our DBMS system. A page is the set
 * of records that a leaf (primary or secondary) contains.
 */
public class Page {
	/**
	 * The list of records.
	 */
	private LinkedList<Record> records;

	/**
	 * The index of the next record that will be put into the page.
	 */
	private int indexOfNextRecordToBeFilled;

	/**
	 * The bucket factor.
	 */
	private final int bucketFactor;

	/**
	 * Creates a page that contains the maximum number of empty records it can hold.
	 * 
	 * @param bucketFactor
	 *            The bucket factor.
	 * @param emptyRecord
	 *            An empty record.
	 */
	public Page(final int bucketFactor, final Record emptyRecord) {
		this.records = new LinkedList<Record>();
		for (int i = 0; i < bucketFactor; i++) {
			this.records.add(i, emptyRecord);
		} // end for
		this.indexOfNextRecordToBeFilled = 0;
		this.bucketFactor = bucketFactor;
	} // end method Page

	/**
	 * 
	 * @param bucketFactor
	 *            The bucket factor.
	 * @param buffer
	 *            The <code>ByteBuffer</code>.
	 * @param recordSize
	 *            The record size.
	 */
	public Page(final int bucketFactor, final ByteBuffer buffer,
			final int recordSize) {
		this.records = new LinkedList<Record>();

		byte[] byteArray = new byte[recordSize];
		ByteBuffer byteBuffer;

		for (int i = 0; i < bucketFactor; i++) {
			buffer.get(byteArray);
			byteBuffer = ByteBuffer.wrap(byteArray);

			this.records.add(new Record(byteBuffer));
		} // end for
		this.indexOfNextRecordToBeFilled = buffer.getInt();
		this.bucketFactor = buffer.getInt();
	} // end method Page

	/**
	 * Retrieves the record with index <code>index</code>.
	 * 
	 * @param index
	 *            The index of the record.
	 * @return The desired record.
	 */
	public Record getRecord(final int index) {
		return this.records.get(index);
	} // end method getRecord

	/**
	 * Inserts a record to the page.
	 * 
	 * @param newRecord
	 *            The new record.
	 * @return An <code>Object[3]</code> that contains information
	 *         about the record inserted.
	 */
	public Object[] insertRecord(final Record newRecord) {
		Object[] insertionInfo = new Object[3];
		insertionInfo[0] = true;

		int i;
		for (i = 0; i < this.records.size(); i++) {
			if (this.records.get(i).isDead()) {
				this.records.set(i, newRecord);
				this.indexOfNextRecordToBeFilled++;
				break;
			} // end if
			else if (newRecord.getPrimaryKey() < this.records.get(i)
					.getPrimaryKey()) {
				this.records.add(i, newRecord);
				this.indexOfNextRecordToBeFilled++;

				// Εάν γίνει εισαγωγή τότε είναι σίγουρο ότι θα προκληθεί
				// υπερχείλιση. Εάν το τελευταίο στοιχείο είναι <<νεκρό>>, τότε
				// αφαιρείται.
				if (this.records.get(this.bucketFactor).isDead()) {
					this.records.removeLast();
				} // end if
				break;
			} // end else if
			else if (newRecord.getPrimaryKey() == this.records.get(i)
					.getPrimaryKey()) {
				insertionInfo[0] = false;
				break;
			} // end else if
		} // end for

		// Όταν ισχύει η συνθήκη αυτή, τότε είτε πρόκειται για την πρώτη εγγραφή
		// στη σελίδα είτε για την εγγραφή με τη μεγαλύτερη τιμή.
		if (i == this.records.size()) {
			this.records.add(newRecord);
			this.indexOfNextRecordToBeFilled++;
		} // end if
		insertionInfo[2] = i;
		return insertionInfo;
	} // end method insertRecord

	/**
	 * Inserts the new record to the last position of the page.
	 * 
	 * @param newRecord
	 *            The new record.
	 */
	public void setRecordLast(final Record newRecord) {
		this.records.set(this.indexOfNextRecordToBeFilled, newRecord);
		this.indexOfNextRecordToBeFilled++;
	} // end method setRecordLast

	/**
	 * Deletes a record from the page. It actually makes the record a "dead"
	 * record and puts it last in the page. It does not remove the object
	 * itself.
	 * 
	 * @param index
	 *            The index of the record-target.
	 */
	public void deleteRecord(final int index) {
		// Κατά την διαγραφή η εγγραφή <<σκοτώνεται>> και στη συνέχεια
		// τοποθετείται στο τέλος. Έτσι διατηρείται η διάταξη των εγγραφών.
		this.records.get(index).killRecord();
		this.records.addLast(this.records.remove(index));
		this.indexOfNextRecordToBeFilled--;
	} // end method deleteRecord

	/**
	 * Deletes a record from the page. It actually removes the object itself (on
	 * the contrary of the <code>delete</code> method.
	 * 
	 * @param index
	 *            The index of the record-target.
	 * @return The record that was removed.
	 */

	public Record removeRecord(final int index) {
		this.indexOfNextRecordToBeFilled--;
		return this.records.remove(index);
	} // end method removeRecord

	/**
	 * Retrieves the page length.
	 * 
	 * @return The page length.
	 */
	public int getPageLength() {
		return this.indexOfNextRecordToBeFilled;
	} // end method getPageLength

	/**
	 * Checks if the page is replete.
	 * 
	 * @return <code>true</code> if the page is replete and <code>false</code>
	 *         otherwise.
	 */
	public boolean isReplete() {
		return this.indexOfNextRecordToBeFilled > this.bucketFactor;
	} // end method isReplete

	/**
	 * Converts the page to a byte array.
	 * 
	 * @return the byte array
	 */
	public byte[] toByteArray() {
		ByteBuffer buffer = ByteBuffer.allocate(Main.PAGE_SIZE);

		for (int i = 0; i < this.records.size(); i++) {
			buffer.put(this.records.get(i).toByteArray());
		} // end for
		buffer.putInt(this.indexOfNextRecordToBeFilled);
		buffer.putInt(this.bucketFactor);

		return buffer.array();
	} // end method toByteBuffer

	/**
	 * Returns the usable size of a page.
	 * 
	 * @param pageSize
	 *            The page size.
	 * @return The usable size
	 */
	public static int getUtilePageSize(final int pageSize) {
		return pageSize - 8;
	} // end method getUtilePageSize
} // end class Page
