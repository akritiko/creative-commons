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
			// ������� �� ������ ��� ���������� ��� ������� ��� ��������
			// ���������.
			RandomAccessFile file = new RandomAccessFile(Main.getCurrentTable()
					.getName()
					+ ".pgs", "r");

			// ������������ �� ���� ��� ���������� ������� ��� ������...
			file.seek(pageNumber * Main.PAGE_SIZE);

			// ��� ���������� ��� ������ byte ��� �� PAGE_SIZE.
			byte[] byteArray = new byte[Main.PAGE_SIZE];
			file.readFully(byteArray);

			// ������������� �� byte ���� �� ��� buffer.
			ByteBuffer allData = ByteBuffer.wrap(byteArray);

			// �������� �� ������.
			newPage = new Page(bucketFactor, allData, emptyRecord
					.getRecordSize());

			// �� ������ �������.
			file.close();
		} // end try
		catch (FileNotFoundException e) {
			// ��� ��� ������ �� ������, ���� ������������ ��� ���� ������.
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
			// ������� �� ������ ��� ���������� ��� ������� ��� ��������
			// ���������.
			RandomAccessFile file = new RandomAccessFile(Main.getCurrentTable()
					.getName()
					+ ".pgs", "rw");

			// ������������ � ���� ��� ���������� ������� ��� ������...
			file.seek(pageNumber * Main.PAGE_SIZE);

			// ��� � ������ �������� ��� ������ �� ��� ����� ��� byte.
			file.write(page.toByteArray());

			// �� ������ �������.
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
			// ������� �� ������ ��� ����� ����� ������������ �� ��������
			ObjectInputStream file = new ObjectInputStream(new FileInputStream(
					Main.dbmsFilepath));

			// ����������� �� ��������.
			data = (DBMSData) file.readObject();

			// �� ������ �������.
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
			// ������� �� ������ ��� ����� �� ����������� � �������.
			ObjectOutputStream file = new ObjectOutputStream(
					new FileOutputStream(Main.dbmsFilepath));

			// �������� � �������.
			file.writeObject(data);

			// �� ������ �������.
			file.close();
		} // end try
		catch (IOException e) {
			System.err.println("Fatal error! File <" + Main.dbmsFilepath
					+ "> could not be written!");
			System.exit(-1);
		} // end catch
	} // end method writeData
} // end class DiskHandler
