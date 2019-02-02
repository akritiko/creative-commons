package dbms;

import java.util.ArrayList;
import java.util.Hashtable;

import dbms.exececution.ExececutionMachine;
import dbms.parser.SQLParser;
import dbms.util.DBMSData;
import dbms.util.DiskHandler;
import dbms.util.Table;

/**
 * This class is when <code>main</code> resides.It also holds all the neccessary data
 * for the System to load,make operation,and save its state.
 *  
 * @author Skalistis Stefanos
 * 
 */

public class Main
{

	/**
	 * The file name where the data are stored.
	 */
	public static final String dbmsFilepath = "SmallDBMS.data";
	
	
	/**
	 * The parser. 
	 */
	public static SQLParser parse;
	
	/**
	 * The execution machine. 
	 */
	public static ExececutionMachine exe;
	
	/**
	 * The tables. 
	 */
	public static ArrayList<Table> tables;
	
	/**
	 * The names of the Tables. 
	 */
	public static ArrayList<String> tableNames;
	
	
	/**
	 * The correspoding table for the provided index name. 
	 */
	public static Hashtable<String, Table> indexNameToTable;
	
	
	/**
	 * The size of  the page. 
	 */
	public static final int PAGE_SIZE = 512;
	
	/**
	 * The table that is currently accessed. 
	 */
	private static Table currentTable = null;

	static
	{
		parse = new SQLParser();
		exe = new ExececutionMachine();
		readALL();
	}

	/**
	 * The main method.
	 * @param args none are taken into consideration.
	 */
	public static void main(String[] args)
	{
		 Menu c =new Menu();
		 c.showMenu();	
	}

	/**
	 * Saves the state of the DBMS.
	 */
	public static void saveAll()
	{
		DiskHandler
				.writeData(new DBMSData(tables, tableNames, indexNameToTable));
	}

	
	/**
	 * Load the state of the DBMS.
	 */
	public static void readALL()
	{
		DBMSData data = DiskHandler.loadData();
		if (data == null)
		{
			tables = new ArrayList<Table>();
			indexNameToTable = new Hashtable<String, Table>();
			tableNames = new ArrayList<String>();
		} else
		{
			tables = data.getTables();
			tableNames = data.getTableNames();
			indexNameToTable = data.getIndexNameToTable();
		}
	}

	/**
	 * Gets the currentTable
	 * @return the <code>currentTable</code> 
	 */
	public static Table getCurrentTable()
	{
		return currentTable;
	}

	/**
	 * Sets the <code>currentTable</code>
	 * @param currTable 
	 */
	public static void setCurrentTable(Table currTable)
	{
		currentTable = currTable;
	}

}
