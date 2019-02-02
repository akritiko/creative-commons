/**
 * 
 */
package dbms.exececution;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.Enumeration;
import java.util.Hashtable;
import java.util.LinkedList;
import java.util.ListIterator;

import dbms.Main;
import dbms.bplus.Reference;
import dbms.bplus.SecondaryBPlusTree;
import dbms.parser.SQLReserved;
import dbms.parser.SQLTokens;
import dbms.util.Char;
import dbms.util.Record;
import dbms.util.Table;

/**
 * This class implements a typical execution machine that executes the queries.
 * The parser(and only the parser) calls the machine's methods, after it has
 * succesfully parsed a command.
 * 
 * @author Skalistis Stefanos
 * @see dbms.parser.SQLParser
 */

// CAUTION!!! THIS CLASS IS POORLY COMMENTED DUE TO SEVERE CHANGES THAT HAPPEND
// NEAR
// THE DEADLINE...PROCCED WITH CAUTION!
public class ExececutionMachine {

	/**
	 * The maximum length of each column which is going to shown to the user.
	 * (Only usable in <code>showResults</code>.It is altered during the call
	 * of <code>select</code>).
	 */
	private int[] maxLength;

	/**
	 * Creates a secondary index, to the table specified by
	 * <code>tableName</code> over the column <code>columnName</code>, with
	 * a name specified by <code>indexName</code>
	 * 
	 * @param indexName
	 *            The name of the index.
	 * @param tableName
	 *            The name of the table which is going to be indexed.
	 * @param columnName
	 *            The name of the column to be indexed.
	 */
	public void createIndex(String indexName, String tableName,
			String columnName) {

		int tableIndex = Main.tableNames.indexOf(tableName);
		if (tableIndex == -1) {
			System.err.println("Invalid table name: \"" + tableName + "\" !");
			System.err.println("The table does not exist!");
			return;
		}
		if (Main.indexNameToTable.containsKey(indexName)) {
			System.err.println("The index name \"" + indexName
					+ "\" already exists!");
			System.err.println("Please choose another name for this index!");
			return;
		}
		Table toBeIndexed = Main.tables.get(tableIndex);
		//
		Main.setCurrentTable(toBeIndexed);
		//
		int columnIndex = toBeIndexed.indexOfColumn(columnName);
		if (columnIndex == -1) {
			System.err.println("The table \"" + tableName
					+ "\" does not contain the \"" + columnName + "\" column!");
			System.err.println("Please choose one valid column!");
			return;
		}
		if (toBeIndexed.hasIndex(columnIndex)) {
			if (toBeIndexed.getIndexOfPrimaryKey() == columnIndex) {
				System.err
						.println("The column \""
								+ columnName
								+ "\" contains the primary!You can't create index on this column");
			} else {
				System.err.println("The column \"" + columnName
						+ "\" is already indexed!");
			}
			System.err.println("Please choose one valid column!");
			return;
		}
		if (toBeIndexed.getColumnType(columnIndex) != SQLTokens.INTEGER) {
			System.err.println("The column must be of type "
					+ SQLReserved.INTEGER + "!");
			System.err.println("Please select a column with this type!");
			return;
		}

		// Creation of the secodary index.
		SecondaryBPlusTree secondaryIndex = new SecondaryBPlusTree(columnIndex,
				toBeIndexed.getPrimaryIndex(), indexName);

		Main.indexNameToTable.put(indexName, toBeIndexed);
		toBeIndexed.addSecondaryIndex(columnIndex, secondaryIndex);
		System.out.println("Index \"" + indexName
				+ "\" has been successfully created on \"" + tableName + "."
				+ columnName + "\"!");
		System.out.println();

	}

	/**
	 * Creates a table with name specified by <code>name</code> having the
	 * specified <code>columns</code>.
	 * 
	 * @param name
	 *            The name of the table to be created.
	 * @param columns
	 *            The columns with their types.
	 * @param primaryKey
	 *            The name of the column which is going to hos the primary key.
	 */
	public void createTable(String name, Object[] columns, String primaryKey) {

		/*
		 * It is not necessary to perform the condition below because the parser
		 * has alreasy caught tha mistake
		 */
		// if (columns.length < 1)
		// {
		// System.err
		// .println("Invalid number of columns.You must have at least one!");
		// return;
		// }
		// Check if the name exists
		if (Main.tableNames.contains(name)) {
			System.err.println("A table with name: \"" + name
					+ "\" already exists!");
			System.err.println("Please choose a different name");
		}
		Table newTable;
		try {
			newTable = new Table(name, columns, primaryKey);
		} catch (InvalidPrimaryKeyException e) {
			if (e.getMessage().equals(SQLTokens.INTEGER.toString())) {
				System.err
						.println("Invalid primary key in the declaration of table \""
								+ name + "\"!");
				System.err.println("The primary key must be of type "
						+ SQLTokens.INTEGER + "!");
			} else {
				System.err.println("Invalid primary key \"" + e.getMessage()
						+ "\" in the declaration of table \"" + name + "\"!");
				System.err
						.println("The primary key must be one of the column's.");
			}
			return;
		} catch (EnormousRecordException e) {
			System.err.println(e.getMessage());
			return;
		}

		Main.tables.add(newTable);
		Main.tableNames.add(name);
		System.out.println("Table \"" + name
				+ "\" has been successfully created!");

	}

	/**
	 * Deletes the values,from table with <code>tableName</code>, that
	 * satisfy the <code>condition</code>.
	 * 
	 * @param tableName
	 *            The name of the table to delete from.
	 * @param condition
	 *            The condition on which the deletion is going to be based upon.
	 */
	public void deleteFrom(String tableName, Object[] condition) {
		// do not change the '3'
		if (condition.length > 3) {
			System.err
					.println("Invalid condition!Only one condition is accepted!");
			return;
		}

		int tableIndex = Main.tableNames.indexOf(tableName);
		if (tableIndex == -1) {
			System.err.println("Invalid table name: \"" + tableName + "\" !");
			System.err.println("The table does not exist!");
			return;
		}
		Table toBeModified = Main.tables.get(tableIndex);

		String columnName = (String) condition[0];
		int columnIndex = toBeModified.indexOfColumn(columnName);
		if (columnIndex == -1) {
			System.err.println("The table \"" + tableName
					+ "\" does not contain the \"" + columnName + "\" column!");
			System.err.println("Please choose one valid column!");
			return;
		}
		if (toBeModified.getColumnType(columnIndex) == SQLTokens.CHAR) {
			if ((SQLTokens) condition[1] != SQLTokens.EQUAL) {
				System.err
						.println("Unsuported operator:For the char type only the \"=\" is supported");
				return;
			}
			if (condition[2].getClass().getSimpleName() == SQLTokens.INTEGER
					.toString()) {
				System.err.println("Error " + condition[2] + "should be of "
						+ SQLTokens.CHAR + " type!");
				return;
			}

			Main.setCurrentTable(toBeModified);
			toBeModified.deleteRecords((Char) condition[2], columnIndex);
		} else {
			if (condition[2].getClass().getSimpleName() == SQLTokens.CHAR
					.toString()) {
				System.err.println("Error " + condition[2] + "should be of "
						+ SQLTokens.INTEGER + " type!");
				return;
			}
			Main.setCurrentTable(toBeModified);
			toBeModified.deleteRecords(columnIndex, (SQLTokens) condition[1],
					(Integer) condition[2]);
		}
	}

	/**
	 * Drops the index with name <code>indexName</code>.
	 * 
	 * @param indexName
	 *            The name of the index which is going to be dropped.
	 */
	public void dropIndex(String indexName) {
		Table toBeDropedFrom = Main.indexNameToTable.get(indexName);
		//		
		Main.setCurrentTable(toBeDropedFrom);
		//		
		if (toBeDropedFrom == null) {
			System.err.println("The index \"" + indexName
					+ "\" does not exist!");
			return;
		}

		toBeDropedFrom.removeSecondaryIndex(indexName);
		Main.indexNameToTable.remove(indexName);
		System.out.println("Index \"" + indexName
				+ "\" has been successfully deleted!");
	}

	/**
	 * Inserts the values into the specified table.
	 * 
	 * @param tableName
	 *            The name of the table to insert into.
	 * @param values
	 *            The values to be inserted.
	 */
	public void insertInto(String tableName, Object[] values) {

		// Check of the table's existance
		int tableIndex = Main.tableNames.indexOf(tableName);
		if (tableIndex == -1) {
			System.err.println("Invalid table name: \"" + tableName + "\" !");
			System.err.println("The table does not exist!");
			return;
		}
		// Checking the equality of the table's and values' lentgh
		Table toInsertInto = Main.tables.get(tableIndex);
		if (toInsertInto.getNumberOfColumns() != values.length) {
			System.out
					.println("The number of values is not equal with the number of columns in table \""
							+ tableName + "\"!");
			return;
		}
		for (int i = 0; i < toInsertInto.getNumberOfColumns(); i++) {
			if (!values[i].getClass().getSimpleName().equalsIgnoreCase(
					toInsertInto.getColumnType(i).toString())) {
				System.err.println("The value \"" + values[i]
						+ "\" is not of the type "
						+ toInsertInto.getColumnType(i).toString());
				System.err.println("Try checking for mistyped values!");
				return;
			}
		}
		//
		Main.setCurrentTable(toInsertInto);
		//
		if (toInsertInto.insertRecord(new Record(values, toInsertInto
				.getFieldsSize(), toInsertInto.getIndexOfPrimaryKey())))
			System.out
					.println("The values have been succesfully inserted into \""
							+ toInsertInto.getName() + "\"!");

	}

	/**
	 * A general method for executing multiple SELECT's each one combined with
	 * the next by an operation specified by
	 * <code>operationBetweenEachSelect</code> list. For each SELECT, the
	 * tables taking part are specified by <code>tablesBetweenEachSelect</code>
	 * list.Also if conditions exists,they are specified by
	 * <code>condiotionBetweenEachSelect</code> list.Finally if an ordering
	 * column exists, it is specified by
	 * <code>orderingColumnBetweenEachSelect</code> list.
	 * 
	 * @param operationBetweenEachSelect
	 *            The operation between each select. In simple words
	 *            UNION,INTERSECTION,MINUS.
	 * @param tablesOfEachSelect
	 *            A list of tables for each SELECT(those in the FROM section).
	 * @param columnsOfEachSelect
	 *            A list of columns for each SELECT(those in the SELECT
	 *            section).
	 * @param conditionOfEachSelect
	 *            A list of conditions for each SELECT(those in the WHERE
	 *            section).If none exist then the list is empty.
	 * @param orderingColumnOfEachSelect
	 *            A list of the names of (ordering)columns for each SELECT(those
	 *            in the ORDER BY section).If there is no ORDER BY the name is
	 *            the empty String.
	 */
	public void select(ArrayList<SQLTokens> operationBetweenEachSelect,
			ArrayList<ArrayList<String>> tablesOfEachSelect,
			ArrayList<ArrayList<String>> columnsOfEachSelect,
			ArrayList<ArrayList<Object[]>> conditionOfEachSelect,
			ArrayList<String> orderingColumnOfEachSelect) {
		System.out.println();
		long startingTime = System.currentTimeMillis();

		LinkedList[] results;
		if (operationBetweenEachSelect.size() == 0) {
			Object[] condition = (conditionOfEachSelect.get(0).isEmpty() ? null
					: conditionOfEachSelect.get(0).toArray());
			results = simpleSelect(tablesOfEachSelect.get(0).toArray(),
					columnsOfEachSelect.get(0).toArray(), condition,
					orderingColumnOfEachSelect.get(0));

			if (results == null) {
				System.err
						.println("An Error was found...Executing next command!");
				return;
			}
		} else {
			Object[] condition = (conditionOfEachSelect.get(0).isEmpty() ? null
					: conditionOfEachSelect.get(0).toArray());
			LinkedList[][] intermediateResults = new LinkedList[2][];
			intermediateResults[0] = simpleSelect(tablesOfEachSelect.get(0)
					.toArray(), columnsOfEachSelect.get(0).toArray(),
					condition, orderingColumnOfEachSelect.get(0));
			if (intermediateResults[0] == null) {
				System.err
						.println("An Error was found...Executing next command!");
				return;
			}
			for (int i = 0; i < operationBetweenEachSelect.size(); i++) {
				condition = (conditionOfEachSelect.get(i + 1).isEmpty() ? null
						: conditionOfEachSelect.get(i + 1).toArray());
				intermediateResults[1] = simpleSelect(tablesOfEachSelect.get(
						i + 1).toArray(), columnsOfEachSelect.get(i + 1)
						.toArray(), condition, orderingColumnOfEachSelect
						.get(i + 1));
				if (intermediateResults[1] == null) {
					System.err
							.println("An Error was found...Executing next command!");
					return;
				}

				// Checking UNION,MINUS,INTERSECTION prerequsites.
				if (intermediateResults[0].length != 0
						&& !intermediateResults[0][0].isEmpty()
						&& intermediateResults[1].length != 0
						&& !intermediateResults[1][0].isEmpty()) {
					if (intermediateResults[0][0].size() != intermediateResults[1][0]
							.size()) {
						System.err.println("The results to be combined with "
								+ operationBetweenEachSelect.get(i)
								+ " do not have the same length.");
						System.err
								.println("This fact makes the query unresolvable.");
						return;
					}
					for (int j = 0; j < intermediateResults[0][0].size(); j++) {
						if (intermediateResults[0][0].get(j) instanceof Char) {
							if (intermediateResults[1][0].get(j) instanceof Integer) {
								System.err
										.println("The results to be combined with "
												+ operationBetweenEachSelect
														.get(i)
												+ " do not have the same type at column \""
												+ columnsOfEachSelect.get(i)
														.get(j) + "\"!");
								System.err
										.println("This fact makes the query unresolvable.");
								return;
							}
						} else {
							if (intermediateResults[1][0].get(j) instanceof Char) {
								System.err
										.println("The results to be combined with "
												+ operationBetweenEachSelect
														.get(i)
												+ " do not have the same type at column \""
												+ columnsOfEachSelect.get(i)
														.get(j) + "\"!");
								System.err
										.println("This fact makes the query unresolvable.");
								return;
							}
						}
					}
				}
				Hashtable<String, Object[]> operationHash = new Hashtable<String, Object[]>();
				int minimumIndex = Math.min(intermediateResults[0].length,
						intermediateResults[1].length);
				int indexOfMaximum = (minimumIndex != intermediateResults[0].length ? 0
						: 1);

				Object[] theDuplicate;
				String keyFromFirstResult = null;
				String keyFromSecondResult = null;
				for (int j = 0; j < minimumIndex; j++) {
					keyFromFirstResult = "";
					keyFromSecondResult = "";
					for (int k = 0; k < intermediateResults[0][j].size(); k++) {
						keyFromFirstResult += intermediateResults[0][j].get(k);
					}
					theDuplicate = operationHash.get(keyFromFirstResult);
					if (theDuplicate == null) {
						operationHash.put(keyFromFirstResult, new Object[] {
								new Integer(1), intermediateResults[0][j] });
					} else {
						if ((Integer) theDuplicate[0] == 2)
							theDuplicate[0] = 3;
					}

					for (int k = 0; k < intermediateResults[1][j].size(); k++) {
						keyFromSecondResult += intermediateResults[1][j].get(k);
					}
					theDuplicate = operationHash.get(keyFromSecondResult);
					if (theDuplicate == null) {
						operationHash.put(keyFromSecondResult, new Object[] {
								new Integer(2), intermediateResults[1][j] });
					} else {
						if ((Integer) theDuplicate[0] == 1)
							theDuplicate[0] = 3;
					}
				}

				for (int j = minimumIndex; j < intermediateResults[indexOfMaximum].length; j++) {
					keyFromFirstResult = "";
					for (int k = 0; k < intermediateResults[indexOfMaximum][j]
							.size(); k++) {
						keyFromFirstResult += intermediateResults[indexOfMaximum][j]
								.get(k);
					}
					theDuplicate = operationHash.get(keyFromFirstResult);
					if (theDuplicate == null) {
						operationHash.put(keyFromFirstResult, new Object[] {
								new Integer(indexOfMaximum + 1),
								intermediateResults[indexOfMaximum][j] });
					} else {
						if ((Integer) theDuplicate[0] == (indexOfMaximum == 0 ? 2
								: 1))
							theDuplicate[0] = 3;
					}

				}

				if ((SQLTokens) operationBetweenEachSelect.get(i) == SQLTokens.UNION) {
					Enumeration<Object[]> values = operationHash.elements();
					results = new LinkedList[operationHash.size()];
					for (int j = 0; j < operationHash.size(); j++) {
						results[j] = (LinkedList<Object>) values.nextElement()[1];
					}
					System.out.println();
					intermediateResults[0] = results;
				} else if ((SQLTokens) operationBetweenEachSelect.get(i) == SQLTokens.INTERSECTION) {
					LinkedList<LinkedList<Object>> commonValues = new LinkedList<LinkedList<Object>>();
					Enumeration<Object[]> values = operationHash.elements();
					Object[] retrievedValue;
					for (int j = 0; j < operationHash.size(); j++) {
						retrievedValue = values.nextElement();
						if ((Integer) retrievedValue[0] == 3) {
							commonValues
									.add((LinkedList<Object>) retrievedValue[1]);
						}
					}
					results = new LinkedList[commonValues.size()];
					for (int j = 0; j < results.length; j++) {
						results[j] = commonValues.get(j);
					}

					intermediateResults[0] = results;
				} else if ((SQLTokens) operationBetweenEachSelect.get(i) == SQLTokens.MINUS) {
					LinkedList<LinkedList<Object>> commonValues = new LinkedList<LinkedList<Object>>();
					Enumeration<Object[]> values = operationHash.elements();
					Object[] retrievedValue;
					for (int j = 0; j < operationHash.size(); j++) {
						retrievedValue = values.nextElement();
						if ((Integer) retrievedValue[0] == 1) {
							commonValues
									.add((LinkedList<Object>) retrievedValue[1]);
						}
					}
					results = new LinkedList[commonValues.size()];
					for (int j = 0; j < results.length; j++) {
						results[j] = commonValues.get(j);
					}

					intermediateResults[0] = results;
				}
			}
			results = intermediateResults[0];
		}
		if (results.length == 0) {
			System.out.println("No results were found!");
			System.out.println();
			return;
		} else {
			showResults(results, maxLength,
					(operationBetweenEachSelect.size() != 0 ? null
							: columnsOfEachSelect.get(0)),
					(operationBetweenEachSelect.size() != 0 ? null
							: tablesOfEachSelect.get(0)));
			System.out.println("Number of Results: " + results.length);
			System.out.println("Time: "
					+ (System.currentTimeMillis() - startingTime) / 1000.0
					+ " sec");
			System.out.println();
		}

	}

	/**
	 * Executes a simple SELECT command while making all the neccessary checks.
	 * If all the checks have passed then it updates the <code>maxLength</code>.
	 * 
	 * @param tableNames
	 *            An array of the tables that are joined(those in the FROM
	 *            section).
	 * @param columnNames
	 *            An array of columns (those in the SELECT section).
	 * @param condition
	 *            An array of conditions (those in the WHERE section).If none
	 *            exist then it is null.
	 * @param orderingColumn
	 *            The ordering column.If there is none then it is the empty
	 *            String.
	 * @return The results that where found after the execution.If an error
	 *         occurs returns <code>null</code>.
	 */

	// METHOD POORLY DOCUMENTED...THE USE OF PROJAK IS REQUIRED WHILE RREADING
	// IT.
	// PROCCED AT YOUR OWN RISK.
	// IF SOMETHINGS MAKES NO SENSE TO YOU EMAIL THE AUTHOR AT
	// sskalist@csd.auth.gr
	private LinkedList<Object>[] simpleSelect(Object[] tableNames,
			Object[] columnNames, Object[] condition, String orderingColumn) {
		final int indexOfOrderingColumn; // must be final for the Comparator

		// Checking if tables are more than 3
		if (tableNames.length > 3) {
			System.err.println("You can not have more than 3 tables");
			System.err.println();
			return null;
		}
		// Checking if sub-conditions are more than 2 (don't confuse with the
		// number below)
		if (condition != null && condition.length > 3) {
			System.err.println("You can not have more than 2 conditions");
			System.err.println();
			return null;
		}
		if (orderingColumn != "") {
			int tmpIndexOfOrderingColumn = -1;
			for (int i = 0; i < columnNames.length; i++) {
				if (columnNames[i].equals(orderingColumn)) {
					tmpIndexOfOrderingColumn = i;
					break;
				}
			}
			if (tmpIndexOfOrderingColumn == -1) {
				System.err.println("The ordering column \"" + orderingColumn
						+ "\" must be included in the " + SQLReserved.SELECT
						+ " section!");
				System.err.println();
				return null;
			}
			indexOfOrderingColumn = tmpIndexOfOrderingColumn;
		} else {
			indexOfOrderingColumn = -1;
		}

		// Formating the conditions so as to have the format:
		// Column CONDITION_SYMBOL Value
		if (condition != null) {
			for (int i = 0; i < condition.length; i += 2) {
				if (!(((Object[]) condition[i])[0] instanceof String)) {
					Object tmp = ((Object[]) condition[i])[0];
					((Object[]) condition[i])[0] = ((Object[]) condition[i])[2];
					((Object[]) condition[i])[2] = tmp;
					switch ((SQLTokens) ((Object[]) condition[i])[1]) {
					case GREATER:
						((Object[]) condition[i])[1] = SQLTokens.LESS;
						break;
					case GREATER_OR_EQUAL:
						((Object[]) condition[i])[1] = SQLTokens.LESS_OR_EQUAL;
						break;
					case LESS:
						((Object[]) condition[i])[1] = SQLTokens.GREATER;
						break;
					case LESS_OR_EQUAL:
						((Object[]) condition[i])[1] = SQLTokens.GREATER_OR_EQUAL;
						break;
					case EQUAL:
						break;
					default:
						break;

					}
				}
				if (condition.length == 3) {// TODO if accepts more than to
					// subconditions
					if ((SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.LESS
							|| (SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.LESS_OR_EQUAL) {
						if ((SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.GREATER
								|| (SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.GREATER_OR_EQUAL) {
							Object tmp = condition[0];
							condition[0] = condition[2];
							condition[2] = tmp;
						}
					} else if ((SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.EQUAL) {
						if ((SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.GREATER
								|| (SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.GREATER_OR_EQUAL
								|| (SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.LESS
								|| (SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.LESS_OR_EQUAL) {
							Object tmp = condition[0];
							condition[0] = condition[2];
							condition[2] = tmp;
						}
					}
				}
			}
		}

		// Declaration of necessery data to perform efficiently the query

		// the tables taking part in the query
		Table[] tables = new Table[tableNames.length];

		// indexOfTableForSelectColumn[i][0] gives the index in tables
		// in which columnNames[i] belongs and indexOfTableForColumn[i][1] gives
		// the
		// index of that column in the table
		int[][] indexOfTableForSelectColumn = new int[columnNames.length][2];
		int[][] indexOfTableForWhereColumn = null;
		// existIndexOnColumn[i] gives if condition[i][0]
		// has been indexed else false
		boolean[] existIndexOnColumn = null;

		// Initialization of data
		if (condition != null) {
			indexOfTableForWhereColumn = new int[condition.length / 2 + 1][2];
			existIndexOnColumn = new boolean[condition.length / 2 + 1];
			for (int i = 0; i < existIndexOnColumn.length; i++) {
				indexOfTableForWhereColumn[i][0] = -1;
				existIndexOnColumn[i] = false;
			}
		}

		for (int i = 0; i < indexOfTableForSelectColumn.length; i++)
			indexOfTableForSelectColumn[i][0] = -1;

		// Find the table;Check if it has any column in the SELECT section
		for (int i = 0, tableIndex; i < tableNames.length; i++) {
			tableIndex = Main.tableNames.indexOf(tableNames[i]);
			if (tableIndex == -1) {
				System.err.println("Invalid table name: \"" + tableNames[i]
						+ "\" !");
				System.err.println("The table does not exist!");
				System.err.println();
				return null;
			}
			tables[i] = Main.tables.get(tableIndex);

			for (int j = 0, indexOfColumn; j < columnNames.length; j++) {
				indexOfColumn = tables[i]
						.indexOfColumn((String) columnNames[j]);
				if (indexOfColumn != -1) {
					// check for double name columns!
					if (indexOfTableForSelectColumn[j][0] != -1) {
						System.err.println("Both tables \""
								+ tableNames[indexOfTableForSelectColumn[j][0]]
								+ "\" and \"" + tableNames[i]
								+ "\" have a column named \"" + columnNames[j]
								+ "\"!");
						System.err
								.println("This fact makes the query unresolvable!");
						System.err.println();
						return null;
					}
					indexOfTableForSelectColumn[j][0] = i;
					indexOfTableForSelectColumn[j][1] = indexOfColumn;
				}
			}

			// Find where column(in where-section) belongs;check if indexed.
			if (condition != null) {
				for (int j = 0, indexOfColumn; j < indexOfTableForWhereColumn.length; j++) {
					indexOfColumn = tables[i]
							.indexOfColumn((String) ((Object[]) condition[2 * j])[0]);
					if (indexOfColumn != -1) {
						if (indexOfTableForWhereColumn[j][0] != -1) {
							System.err
									.println("Both tables \""
											+ tableNames[indexOfTableForSelectColumn[j][0]]
											+ "\" and \""
											+ tableNames[i]
											+ "\" have a column named \""
											+ (String) ((Object[]) condition[2 * j])[0]
											+ "\"!");
							System.err
									.println("This fact makes the query unresolvable!");
							System.err.println();
							return null;
						}
						indexOfTableForWhereColumn[j][0] = i;
						indexOfTableForWhereColumn[j][1] = indexOfColumn;
						existIndexOnColumn[j] = tables[i]
								.hasIndex(indexOfColumn);

					}
				}
			}
		}

		// Checking existance of column
		for (int j = 0; j < indexOfTableForSelectColumn.length; j++) {
			if (indexOfTableForSelectColumn[j][0] == -1) {
				System.err.println("The table(s) do not contain the \""
						+ columnNames[j] + "\" column!");
				System.err.println("Please choose one valid column!");
				System.err.println();
				return null;
			}
		}

		if (condition != null) {
			// Checking existance of column
			for (int j = 0; j < indexOfTableForWhereColumn.length; j++) {
				if (indexOfTableForWhereColumn[j][0] == -1) {
					System.err.println("The table(s) do not contain the \""
							+ ((Object[]) condition[j])[0] + "\" column!");
					System.err.println("Please choose one valid column!");
					System.err.println();
					return null;
				}
			}
			// TODO if it is going to accept more than 2 condition this must be
			// changed
			for (int i = 1; i < condition.length; i += 2) {
				if (condition[i] == SQLTokens.OR) {
					if (indexOfTableForWhereColumn[i - 1] != indexOfTableForWhereColumn[i]) {
						System.err
								.println("The conditions using "
										+ SQLTokens.OR
										+ " can not have columns belonging to different tables");
						System.err.println("Columns \""
								+ ((Object[]) condition[i - 1])[0]
								+ "\" and \""
								+ ((Object[]) condition[i + 1])[0]
								+ "\" belong to different tables");
						System.err.println("Please choose valid columns!");
						System.err.println();
						return null;
					}
				}
			}
		}
		LinkedList[] intermediateResults = new LinkedList[tableNames.length];

		// TODO this must change if bigger condition comes
		if (condition != null) {
			for (int i = 0; i < indexOfTableForWhereColumn.length; i++) {
				if (tables[indexOfTableForWhereColumn[i][0]]
						.getColumnType(indexOfTableForWhereColumn[i][1]) == SQLTokens.CHAR) {
					if ((SQLTokens) ((Object[]) condition[2 * i])[1] != SQLTokens.EQUAL) {
						System.err
								.println("Unsuported operator:For the char type only the \"=\" is supported");
						System.err.println();
						return null;
					}
					if (((Object[]) condition[2 * i])[2] instanceof Integer) {
						System.err.println("Error "
								+ ((Object[]) condition[2 * i])[2]
								+ "should be of " + SQLTokens.CHAR + " type!");
						System.err.println();
						return null;
					}
				} else {
					if (((Object[]) condition[2 * i])[2] instanceof Char) {
						System.err.println("Error "
								+ ((Object[]) condition[2 * i])[2]
								+ "should be of " + SQLTokens.INTEGER
								+ " type!");
						System.err.println();
						return null;
					}
				}
			}

			// if one condition
			if (condition.length == 1) {
				// if the column is of type CHAR
				if (tables[indexOfTableForWhereColumn[0][0]]
						.getColumnType(indexOfTableForWhereColumn[0][1]) == SQLTokens.CHAR) {
					Main
							.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
					intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
							.find((Char) ((Object[]) condition[0])[2],
									indexOfTableForWhereColumn[0][1]);
				} else
				// column of type integer
				{

					Main
							.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
					intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
							.find(indexOfTableForWhereColumn[0][1],
									(SQLTokens) ((Object[]) condition[0])[1],
									(Integer) ((Object[]) condition[0])[2]);
				}
			} else
			// condition has 2 subconditions
			{
				// if the conditions are combined with "OR"
				if ((SQLTokens) ((Object[]) condition[1])[0] == SQLTokens.OR) {
					if (indexOfTableForWhereColumn[0][1] == indexOfTableForWhereColumn[1][1])
					// on the same column
					{
						// if the column is of type char
						if (((Object[]) condition[0])[2] instanceof Char) {
							// get the intermediate results for the first
							// condition
							Main
									.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
							intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
									.find((Char) ((Object[]) condition[0])[2],
											indexOfTableForWhereColumn[0][1]);
							// if the condition returns any result
							if (intermediateResults[indexOfTableForWhereColumn[0][0]] != null) {
								// add to the existing results the results from
								// the second condition
								try {
									intermediateResults[indexOfTableForWhereColumn[0][0]]
											.addAll(tables[indexOfTableForWhereColumn[0][0]]
													.find(
															(Char) ((Object[]) condition[2])[2],
															indexOfTableForWhereColumn[0][1]));
								} catch (NullPointerException e) {
									// no results from the second condition
								}
							} else
								// no results from the first condition
								// get the results from the second condition
								intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
										.find(
												(Char) ((Object[]) condition[2])[2],
												indexOfTableForWhereColumn[0][1]);
							// if the columns are of type integer
						} else if (((Object[]) condition[0])[2] instanceof Integer) {
							// if the first condition has ">" or ">=" operator
							if ((SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.GREATER
									|| (SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.GREATER_OR_EQUAL) {
								// if the second condition has ">" or ">="
								// operator
								if ((SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.GREATER
										|| (SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.GREATER_OR_EQUAL) {
									int minValue;
									SQLTokens operator;

									// getting the minimum value and the
									// operator applied to that value
									if (((Integer) ((Object[]) condition[0])[2])
											.equals((Integer) ((Object[]) condition[2])[2])) {
										minValue = (Integer) ((Object[]) condition[0])[2];
										if ((SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.GREATER_OR_EQUAL
												|| (SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.GREATER_OR_EQUAL)
											operator = SQLTokens.GREATER_OR_EQUAL;
										else
											operator = SQLTokens.GREATER;
									} else if ((Integer) ((Object[]) condition[0])[2] < (Integer) ((Object[]) condition[2])[2]) {
										minValue = (Integer) ((Object[]) condition[0])[2];
										operator = (SQLTokens) ((Object[]) condition[0])[1];
									} else {
										minValue = (Integer) ((Object[]) condition[2])[2];
										operator = (SQLTokens) ((Object[]) condition[2])[1];
									}

									// get the intermediate results
									Main
											.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
									intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
											.find(
													indexOfTableForWhereColumn[0][1],
													operator, minValue);
								}
								// if the second condition has "<" or "<="
								// operator
								else if ((SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.LESS
										|| (SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.LESS_OR_EQUAL) {
									// transforming the ">=" to ">" and "<=" to
									// "<"
									if ((SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.GREATER_OR_EQUAL) {
										((Object[]) condition[0])[1] = SQLTokens.GREATER;
										((Object[]) condition[0])[2] = ((Integer) ((Object[]) condition[0])[2]) - 1;
									}
									if ((SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.LESS_OR_EQUAL) {
										((Object[]) condition[2])[1] = SQLTokens.LESS;
										((Object[]) condition[2])[2] = ((Integer) ((Object[]) condition[2])[2]) + 1;
									}

									// Condition: column > value1 or column <
									// value2

									// if value1 < value2 then the whole table
									// must be taken.
									if ((Integer) ((Object[]) condition[0])[2] < (Integer) ((Object[]) condition[2])[2]) {
										intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
												.getAll();
									}// else must take from beggining to
									// value2 and from value1 to end.
									else if (((Integer) ((Object[]) condition[0])[2])
											.equals((Integer) ((Object[]) condition[2])[2])
											|| (Integer) ((Object[]) condition[0])[2] > (Integer) ((Object[]) condition[2])[2]) {
										Main
												.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);

										// get the results from the first
										// condition
										intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
												.find(
														indexOfTableForWhereColumn[0][1],
														(SQLTokens) ((Object[]) condition[0])[1],
														(Integer) ((Object[]) condition[0])[2]);
										// if some exist
										if (intermediateResults[indexOfTableForWhereColumn[0][0]] != null) {
											// try to add the results from the
											// second condition
											try {
												intermediateResults[indexOfTableForWhereColumn[0][0]]
														.addAll(tables[indexOfTableForWhereColumn[0][0]]
																.find(
																		indexOfTableForWhereColumn[0][1],
																		(SQLTokens) ((Object[]) condition[2])[1],
																		(Integer) ((Object[]) condition[2])[2]));
											} catch (NullPointerException e) {
												// no results from the second
												// condition
											}
										} // else no results exist so get the
										// results from the second condition
										else
											intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
													.find(
															indexOfTableForWhereColumn[0][1],
															(SQLTokens) ((Object[]) condition[2])[1],
															(Integer) ((Object[]) condition[2])[2]);
									}
								}// if the second condition has "=" operator
								else {
									// transforming the ">=" to ">"
									if ((SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.GREATER_OR_EQUAL) {
										((Object[]) condition[0])[1] = SQLTokens.GREATER;
										((Object[]) condition[0])[2] = ((Integer) ((Object[]) condition[0])[2]) - 1;
									}

									// Condition: column > value1 or column =
									// value2

									// if value1 < value2 the subcondition
									// column = value2 can be omitted
									if ((Integer) ((Object[]) condition[0])[2] < (Integer) ((Object[]) condition[2])[2]
											|| ((Integer) ((Object[]) condition[0])[2])
													.equals((Integer) ((Object[]) condition[2])[2])) {
										// if value1 = value2 then the condition
										// can become column > value -1
										if (((Integer) ((Object[]) condition[0])[2])
												.equals((Integer) ((Object[]) condition[2])[2])) {
											((Object[]) condition[0])[2] = ((Integer) ((Object[]) condition[0])[2]) - 1;
										}
										Main
												.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
										intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
												.find(
														indexOfTableForWhereColumn[0][1],
														(SQLTokens) ((Object[]) condition[0])[1],
														(Integer) ((Object[]) condition[0])[2]);
									} else {
										Main
												.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
										intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
												.find(
														indexOfTableForWhereColumn[0][1],
														(SQLTokens) ((Object[]) condition[0])[1],
														(Integer) ((Object[]) condition[0])[2]);
										if (intermediateResults[indexOfTableForWhereColumn[0][0]] != null) {
											try {
												intermediateResults[indexOfTableForWhereColumn[0][0]]
														.addAll(tables[indexOfTableForWhereColumn[0][0]]
																.find(
																		indexOfTableForWhereColumn[0][1],
																		(SQLTokens) ((Object[]) condition[2])[1],
																		(Integer) ((Object[]) condition[2])[2]));
											} catch (NullPointerException e) {
												// no results from the second
												// condition
											}
										} else
											intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
													.find(
															indexOfTableForWhereColumn[0][1],
															(SQLTokens) ((Object[]) condition[2])[1],
															(Integer) ((Object[]) condition[2])[2]);

									}
								}

							} else if ((SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.LESS
									|| (SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.LESS_OR_EQUAL) {
								if ((SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.LESS
										|| (SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.LESS_OR_EQUAL) {
									int maxValue;
									SQLTokens operator;
									if ((Integer) ((Object[]) condition[0])[2] > (Integer) ((Object[]) condition[2])[2]) {
										maxValue = (Integer) ((Object[]) condition[0])[2];
										operator = (SQLTokens) ((Object[]) condition[0])[1];
									} else {
										maxValue = (Integer) ((Object[]) condition[2])[2];
										operator = (SQLTokens) ((Object[]) condition[2])[1];
									}
									intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
											.find(
													indexOfTableForWhereColumn[0][1],
													operator, maxValue);
								} else {
									if ((SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.LESS_OR_EQUAL) {
										((Object[]) condition[0])[1] = SQLTokens.LESS;
										((Object[]) condition[0])[2] = ((Integer) ((Object[]) condition[0])[2]) + 1;
									}

									if ((Integer) ((Object[]) condition[0])[2] > (Integer) ((Object[]) condition[2])[2]
											|| ((Integer) ((Object[]) condition[0])[2])
													.equals((Integer) ((Object[]) condition[2])[2])) {
										if (((Integer) ((Object[]) condition[0])[2])
												.equals((Integer) ((Object[]) condition[2])[2])) {
											((Object[]) condition[0])[2] = ((Integer) ((Object[]) condition[0])[2]) + 1;
										}
										Main
												.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
										intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
												.find(
														indexOfTableForWhereColumn[0][1],
														(SQLTokens) ((Object[]) condition[0])[1],
														(Integer) ((Object[]) condition[0])[2]);
									} else {
										Main
												.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
										intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
												.find(
														indexOfTableForWhereColumn[0][1],
														(SQLTokens) ((Object[]) condition[0])[1],
														(Integer) ((Object[]) condition[0])[2]);
										if (intermediateResults[indexOfTableForWhereColumn[0][0]] != null) {
											try {
												intermediateResults[indexOfTableForWhereColumn[0][0]]
														.addAll(tables[indexOfTableForWhereColumn[0][0]]
																.find(
																		indexOfTableForWhereColumn[0][1],
																		(SQLTokens) ((Object[]) condition[2])[1],
																		(Integer) ((Object[]) condition[2])[2]));
											} catch (NullPointerException e) {
												// no results from the second
												// condition
											}
										} else
											intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
													.find(
															indexOfTableForWhereColumn[0][1],
															(SQLTokens) ((Object[]) condition[2])[1],
															(Integer) ((Object[]) condition[2])[2]);

									}
								}

							} else if ((SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.EQUAL) {
								if ((SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.EQUAL) {
									if (((Integer) ((Object[]) condition[0])[2])
											.equals((Integer) ((Object[]) condition[2])[2])) {
										intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
												.find(
														indexOfTableForWhereColumn[0][1],
														(SQLTokens) ((Object[]) condition[0])[1],
														(Integer) ((Object[]) condition[0])[2]);
									} else {
										Main
												.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
										intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
												.find(
														indexOfTableForWhereColumn[0][1],
														(SQLTokens) ((Object[]) condition[0])[1],
														(Integer) ((Object[]) condition[0])[2]);
										if (intermediateResults[indexOfTableForWhereColumn[0][0]] != null) {
											try {
												intermediateResults[indexOfTableForWhereColumn[0][0]]
														.addAll(tables[indexOfTableForWhereColumn[0][0]]
																.find(
																		indexOfTableForWhereColumn[0][1],
																		(SQLTokens) ((Object[]) condition[2])[1],
																		(Integer) ((Object[]) condition[2])[2]));
											} catch (NullPointerException e) {
												// no results from the second
												// condition
											}
										} else
											intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
													.find(
															indexOfTableForWhereColumn[0][1],
															(SQLTokens) ((Object[]) condition[2])[1],
															(Integer) ((Object[]) condition[2])[2]);
									}
								}
							}
						}

					} else
					// different columns
					{
						// ekteloume diadoxika
						LinkedList<Record> resultsFromFirstCondition = null;
						LinkedList<Record> resultsFromSecondCondition = null;
						Main
								.setCurrentTable(tables[indexOfTableForWhereColumn[1][0]]);
						if (((Object[]) condition[2])[2] instanceof Char) {
							resultsFromSecondCondition = tables[indexOfTableForWhereColumn[1][0]]
									.find((Char) ((Object[]) condition[2])[2],
											indexOfTableForWhereColumn[1][1]);
						} else if (((Object[]) condition[2])[2] instanceof Integer) {
							resultsFromSecondCondition = tables[indexOfTableForWhereColumn[1][0]]
									.find(
											indexOfTableForWhereColumn[1][1],
											(SQLTokens) ((Object[]) condition[2])[1],
											(Integer) ((Object[]) condition[2])[2]);
						}

						ListIterator doublesRemovalIterator = resultsFromSecondCondition
								.listIterator();
						Main
								.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
						if (((Object[]) condition[0])[2] instanceof Char) {
							resultsFromFirstCondition = tables[indexOfTableForWhereColumn[0][0]]
									.find((Char) ((Object[]) condition[0])[2],
											indexOfTableForWhereColumn[0][1]);
							while (doublesRemovalIterator.hasNext()) {
								if (((Char) ((Record) doublesRemovalIterator
										.next())
										.getKey(indexOfTableForWhereColumn[0][1]))
										.equals((Char) ((Object[]) condition[0])[2])) {
									doublesRemovalIterator.remove();
								}
							}
						} else if (((Object[]) condition[0])[2] instanceof Integer) {
							resultsFromFirstCondition = tables[indexOfTableForWhereColumn[0][0]]
									.find(
											indexOfTableForWhereColumn[0][1],
											(SQLTokens) ((Object[]) condition[0])[1],
											(Integer) ((Object[]) condition[0])[2]);
							while (doublesRemovalIterator.hasNext()) {
								switch ((SQLTokens) ((Object[]) condition[0])[1]) {
								case GREATER:
									if ((Integer) ((Record) doublesRemovalIterator
											.next())
											.getKey(indexOfTableForWhereColumn[0][1]) > (Integer) ((Object[]) condition[0])[2]) {
										doublesRemovalIterator.remove();
									}
									break;
								case GREATER_OR_EQUAL:
									if ((Integer) ((Record) doublesRemovalIterator
											.next())
											.getKey(indexOfTableForWhereColumn[0][1]) >= (Integer) ((Object[]) condition[0])[2]) {
										doublesRemovalIterator.remove();
									}
									break;
								case LESS:
									if ((Integer) ((Record) doublesRemovalIterator
											.next())
											.getKey(indexOfTableForWhereColumn[0][1]) < (Integer) ((Object[]) condition[0])[2]) {
										doublesRemovalIterator.remove();
									}
									break;
								case LESS_OR_EQUAL:
									if ((Integer) ((Record) doublesRemovalIterator
											.next())
											.getKey(indexOfTableForWhereColumn[0][1]) <= (Integer) ((Object[]) condition[0])[2]) {
										doublesRemovalIterator.remove();
									}
									break;
								case EQUAL:
									if (((Integer) ((Record) doublesRemovalIterator
											.next())
											.getKey(indexOfTableForWhereColumn[0][1]))
											.equals((Integer) ((Object[]) condition[0])[2])) {
										doublesRemovalIterator.remove();
									}
									break;
								default:
									break;
								}

							}
						}
						if (resultsFromFirstCondition != null) {
							if (resultsFromSecondCondition != null) {
								if (!resultsFromFirstCondition
										.addAll(resultsFromSecondCondition)) {
									System.err
											.println("Fatal error adding two lists....Exiting!");
									System.exit(-666);
								}

							}
							intermediateResults[indexOfTableForWhereColumn[0][0]] = resultsFromFirstCondition;
						} else
							intermediateResults[indexOfTableForWhereColumn[0][0]] = resultsFromSecondCondition;
					}
				} else
				// The subconditions are combined with "AND"
				{
					// same table
					if (indexOfTableForWhereColumn[0][0] == indexOfTableForWhereColumn[1][0]) {
						// same column
						if (indexOfTableForWhereColumn[0][1] == indexOfTableForWhereColumn[1][1]) {
							// Condition: Column Operator1 Value1 AND Column
							// Operator2 Value2
							// if the column is of type Char
							if (((Object[]) condition[0])[2] instanceof Char) {
								if (((Char) ((Object[]) condition[0])[2])
										.equals((Char) ((Object[]) condition[2])[2])) {
									// get the intermediate results for the
									// first condition
									Main
											.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
									intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
											.find(
													(Char) ((Object[]) condition[0])[2],
													indexOfTableForWhereColumn[0][1]);
								} else {
									if (intermediateResults[indexOfTableForWhereColumn[0][0]] == null) {
										intermediateResults[indexOfTableForWhereColumn[0][0]] = new LinkedList<Object>();
									}
								}
								// if Value1 != Value2 -> no results
							}// if the column is of type Integer
							else if (((Object[]) condition[0])[2] instanceof Integer) {
								// if the first condition has ">" or ">="
								// operator
								if ((SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.GREATER
										|| (SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.GREATER_OR_EQUAL) {
									// if the second condition has ">" or ">="
									// operator
									if ((SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.GREATER
											|| (SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.GREATER_OR_EQUAL) {
										int maxValue;
										SQLTokens operator;

										if (((Integer) ((Object[]) condition[0])[2])
												.equals((Integer) ((Object[]) condition[2])[2])) {
											maxValue = (Integer) ((Object[]) condition[0])[2];
											if ((SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.GREATER_OR_EQUAL
													&& (SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.GREATER_OR_EQUAL)
												operator = SQLTokens.GREATER_OR_EQUAL;
											else
												operator = SQLTokens.GREATER;
										} else if ((Integer) ((Object[]) condition[0])[2] > (Integer) ((Object[]) condition[2])[2]) {
											maxValue = (Integer) ((Object[]) condition[0])[2];
											operator = (SQLTokens) ((Object[]) condition[0])[1];
										} else {
											maxValue = (Integer) ((Object[]) condition[2])[2];
											operator = (SQLTokens) ((Object[]) condition[2])[1];
										}

										// get the intermediate results
										Main
												.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
										intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
												.find(
														indexOfTableForWhereColumn[0][1],
														operator, maxValue);
									}
									// if the second condition has "<" or "<="
									// operator
									else if ((SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.LESS
											|| (SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.LESS_OR_EQUAL) {
										if ((Integer) ((Object[]) condition[0])[2] > (Integer) ((Object[]) condition[2])[2]) {
											if (intermediateResults[indexOfTableForWhereColumn[0][0]] == null) {
												intermediateResults[indexOfTableForWhereColumn[0][0]] = new LinkedList<Object>();
											}
										} else if (((Integer) ((Object[]) condition[0])[2])
												.equals((Integer) ((Object[]) condition[2])[2])) {
											if ((SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.GREATER_OR_EQUAL
													&& (SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.LESS_OR_EQUAL) {
												// get the intermediate results
												Main
														.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
												intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
														.find(
																indexOfTableForWhereColumn[0][1],
																SQLTokens.EQUAL,
																(Integer) ((Object[]) condition[0])[2]);
											} else {
												// else no results exist
												if (intermediateResults[indexOfTableForWhereColumn[0][0]] == null) {
													intermediateResults[indexOfTableForWhereColumn[0][0]] = new LinkedList<Object>();
												}
											}
										}

										else if ((Integer) ((Object[]) condition[0])[2] < (Integer) ((Object[]) condition[2])[2]) {
											if ((SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.GREATER_OR_EQUAL) {
												((Object[]) condition[0])[2] = (Integer) ((Object[]) condition[0])[2] - 1;
											}
											if ((SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.LESS_OR_EQUAL) {
												((Object[]) condition[2])[2] = (Integer) ((Object[]) condition[2])[2] + 1;
											}
											Main
													.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
											intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
													.findRange(
															indexOfTableForWhereColumn[0][1],
															(Integer) ((Object[]) condition[0])[2],
															(Integer) ((Object[]) condition[2])[2]);
										}
									}// if the second condition has "="
									// operator
									else if ((SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.EQUAL) {
										if ((Integer) ((Object[]) condition[0])[2] < (Integer) ((Object[]) condition[2])[2]) {
											Main
													.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
											intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
													.find(
															indexOfTableForWhereColumn[0][1],
															(SQLTokens) ((Object[]) condition[2])[1],
															(Integer) ((Object[]) condition[2])[2]);
										} else {// else no results exist
											if (intermediateResults[indexOfTableForWhereColumn[0][0]] == null) {
												intermediateResults[indexOfTableForWhereColumn[0][0]] = new LinkedList<Object>();
											}
										}

									}
								}
								// if the first condition has "<" or "<="
								else if ((SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.LESS
										|| (SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.LESS_OR_EQUAL) {
									// if the second condition has "<" or "<="
									if ((SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.LESS
											|| (SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.LESS_OR_EQUAL) {
										int minValue;
										SQLTokens operator;

										if (((Integer) ((Object[]) condition[0])[2])
												.equals((Integer) ((Object[]) condition[2])[2])) {
											minValue = (Integer) ((Object[]) condition[0])[2];
											if ((SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.LESS_OR_EQUAL
													&& (SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.LESS_OR_EQUAL)
												operator = SQLTokens.LESS_OR_EQUAL;
											else
												operator = SQLTokens.LESS;
										} else if ((Integer) ((Object[]) condition[0])[2] < (Integer) ((Object[]) condition[2])[2]) {
											minValue = (Integer) ((Object[]) condition[0])[2];
											operator = (SQLTokens) ((Object[]) condition[0])[1];
										} else {
											minValue = (Integer) ((Object[]) condition[2])[2];
											operator = (SQLTokens) ((Object[]) condition[2])[1];
										}

										// get the intermediate results
										Main
												.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
										intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
												.find(
														indexOfTableForWhereColumn[0][1],
														operator, minValue);

									}// if the second condition has "="
									else if ((SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.EQUAL) {
										if ((Integer) ((Object[]) condition[0])[2] > (Integer) ((Object[]) condition[2])[2]) {
											Main
													.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
											intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
													.find(
															indexOfTableForWhereColumn[0][1],
															(SQLTokens) ((Object[]) condition[2])[1],
															(Integer) ((Object[]) condition[2])[2]);
										} else {
											// else no results exist
											if (intermediateResults[indexOfTableForWhereColumn[0][0]] == null) {
												intermediateResults[indexOfTableForWhereColumn[0][0]] = new LinkedList<Object>();
											}
										}
									}
									// if the first condition has "="
								} else if ((SQLTokens) ((Object[]) condition[0])[1] == SQLTokens.EQUAL) {
									if ((SQLTokens) ((Object[]) condition[2])[1] == SQLTokens.EQUAL) {
										if (((Integer) ((Object[]) condition[0])[2])
												.equals((Integer) ((Object[]) condition[0])[2])) {
											Main
													.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
											intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
													.find(
															indexOfTableForWhereColumn[0][1],
															(SQLTokens) ((Object[]) condition[0])[1],
															(Integer) ((Object[]) condition[0])[2]);
										} else {
											Main
													.setCurrentTable(tables[indexOfTableForWhereColumn[1][0]]);
											intermediateResults[indexOfTableForWhereColumn[1][0]]
													.addAll(tables[indexOfTableForWhereColumn[1][0]]
															.find(
																	indexOfTableForWhereColumn[1][1],
																	(SQLTokens) ((Object[]) condition[2])[1],
																	(Integer) ((Object[]) condition[2])[2]));
										}
									}
								}
							}
						} else
						// different column
						{

							LinkedList<Record> resultsFromFirstCondition = null;
							LinkedList<Record> resultsFromSecondCondition = null;
							Main
									.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
							if (((Object[]) condition[0])[2] instanceof Char) {
								resultsFromFirstCondition = tables[indexOfTableForWhereColumn[0][0]]
										.find(
												(Char) ((Object[]) condition[0])[2],
												indexOfTableForWhereColumn[0][1]);
							} else if (((Object[]) condition[0])[2] instanceof Integer) {
								resultsFromFirstCondition = tables[indexOfTableForWhereColumn[0][0]]
										.find(
												indexOfTableForWhereColumn[0][1],
												(SQLTokens) ((Object[]) condition[0])[1],
												(Integer) ((Object[]) condition[0])[2]);
							}
							Main
									.setCurrentTable(tables[indexOfTableForWhereColumn[1][0]]);
							if (((Object[]) condition[2])[2] instanceof Char) {
								resultsFromSecondCondition = tables[indexOfTableForWhereColumn[1][0]]
										.find(
												(Char) ((Object[]) condition[2])[2],
												indexOfTableForWhereColumn[1][1]);
							} else if (((Object[]) condition[2])[2] instanceof Integer) {
								resultsFromSecondCondition = tables[indexOfTableForWhereColumn[1][0]]
										.find(
												indexOfTableForWhereColumn[1][1],
												(SQLTokens) ((Object[]) condition[2])[1],
												(Integer) ((Object[]) condition[2])[2]);
							}
							if (resultsFromFirstCondition == null
									|| resultsFromSecondCondition == null) {
								return new LinkedList[0];
							} else {
								resultsFromFirstCondition
										.retainAll(resultsFromSecondCondition);
								intermediateResults[indexOfTableForWhereColumn[0][0]] = resultsFromFirstCondition;
							}

						}

						// filling the empty tables
						for (int i = 0; i < intermediateResults.length; i++) {
							if (intermediateResults[i] == null) {
								Main.setCurrentTable(tables[i]);
								intermediateResults[i] = tables[i].getAll();
							}
						}

					} else
					// different table
					{
						// the first condition
						Main
								.setCurrentTable(tables[indexOfTableForWhereColumn[0][0]]);
						if (((Object[]) condition[0])[2] instanceof Char) {
							intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
									.find((Char) ((Object[]) condition[0])[2],
											indexOfTableForWhereColumn[0][1]);
						} else if (((Object[]) condition[0])[2] instanceof Integer) {
							intermediateResults[indexOfTableForWhereColumn[0][0]] = tables[indexOfTableForWhereColumn[0][0]]
									.find(
											indexOfTableForWhereColumn[0][1],
											(SQLTokens) ((Object[]) condition[0])[1],
											(Integer) ((Object[]) condition[0])[2]);
						}
						// the second condition
						Main
								.setCurrentTable(tables[indexOfTableForWhereColumn[1][0]]);
						if (((Object[]) condition[2])[2] instanceof Char) {
							intermediateResults[indexOfTableForWhereColumn[1][0]] = tables[indexOfTableForWhereColumn[1][0]]
									.find((Char) ((Object[]) condition[2])[2],
											indexOfTableForWhereColumn[1][1]);
						} else if (((Object[]) condition[2])[2] instanceof Integer) {
							intermediateResults[indexOfTableForWhereColumn[1][0]] = tables[indexOfTableForWhereColumn[1][0]]
									.find(
											indexOfTableForWhereColumn[1][1],
											(SQLTokens) ((Object[]) condition[2])[1],
											(Integer) ((Object[]) condition[2])[2]);
						}
					}
				}
			}
		}// no condition exists
		else {
			for (int i = 0; i < tables.length; i++) {
				Main.setCurrentTable(tables[i]);
				intermediateResults[i] = tables[i].getAll();
			}
		}

		// deteriorate results
		LinkedList[][] results = new LinkedList[tables.length][];
		for (int i = 0; i < results.length; i++) {
			results[i] = new LinkedList[intermediateResults[i].size()];
		}

		maxLength = new int[indexOfTableForSelectColumn.length];
		for (int i = 0; i < indexOfTableForSelectColumn.length; i++) {
			for (int j = 0; j < intermediateResults[indexOfTableForSelectColumn[i][0]]
					.size(); j++) {
				if (results[indexOfTableForSelectColumn[i][0]][j] == null)
					results[indexOfTableForSelectColumn[i][0]][j] = new LinkedList<Object>();
				Object key = ((Record) intermediateResults[indexOfTableForSelectColumn[i][0]]
						.get(j)).getKey(indexOfTableForSelectColumn[i][1]);
				maxLength[i] = Math.max(maxLength[i], key.toString().length());
				results[indexOfTableForSelectColumn[i][0]][j].addLast(key);
			}

		}
		// filling the gaps
		for (int i = 0; i < results.length; i++) {
			if (results[i].length != 0 && results[i][0] == null) {
				for (int j = 0; j < results[i].length; j++) {
					results[i][j] = new LinkedList<Object>();
				}
			}

		}
		// Clearing memory
		intermediateResults = null;
		System.gc();

		for (int i = 0; i < tables.length - 1; i++) {
			// join if more than one table
			LinkedList[] joinResults = new LinkedList[results[i].length
					* results[i + 1].length];
			for (int j = 0; j < results[i].length; j++) {
				for (int k = 0; k < results[i + 1].length; k++) {
					joinResults[j * results[i + 1].length + k] = (LinkedList) results[i][j]
							.clone();
					joinResults[j * results[i + 1].length + k]
							.addAll(results[i + 1][k]);
				}
			}
			results[i + 1] = joinResults;
		}

		if (orderingColumn != "") {
			Arrays.sort((LinkedList[]) results[tables.length - 1],
					new Comparator<LinkedList>() {
						public int compare(LinkedList list1, LinkedList list2) {
							if (list1.get(indexOfOrderingColumn) instanceof Char) {
								return ((Char) list1.get(indexOfOrderingColumn))
										.compareTo((Char) list2
												.get(indexOfOrderingColumn));
							} else if (list1.get(indexOfOrderingColumn) instanceof Integer) {
								return ((Integer) list1
										.get(indexOfOrderingColumn))
										.compareTo((Integer) list2
												.get(indexOfOrderingColumn));
							} else {
								System.err
										.println("Error during ordering proccess...Invalid Type!");
								System.err
										.println("The resultss will not be properly ordered!");
								return 0;
							}

						}
					});
		}

		return results[tables.length - 1];
	}

	/**
	 * Shows the results to the output.
	 * 
	 * @param results
	 *            The results to be shown.
	 * @param maxLenghts
	 *            The maximum length(in characters) of each column.
	 */
	public void showResults(LinkedList[] results, int maxLenghts[],
			ArrayList<String> columnNames, ArrayList<String> tableNames) {
		if (columnNames != null) {
			System.out.print("Results from Table"
					+ (tableNames.size() == 1 ? ": " : "s: "));
			for (int i = 0; i < tableNames.size(); i++) {
				System.out.print(tableNames.get(i) + " ");
			}
			System.out.println();
			System.out.println();

			for (int i = 0; i < columnNames.size(); i++) {
				maxLenghts[i] = Math.max(maxLenghts[i], columnNames.get(i)
						.length());
				System.out.format("%-" + maxLenghts[i] + "s|", columnNames
						.get(i));
			}
			System.out.println();
			for (int i = 0; i < columnNames.size(); i++) {
				for (int j = 0; j < maxLenghts[i]; j++) {
					System.out.print('-');
				}
				System.out.print('-');
			}
			System.out.println();
		}
		Object[][] shown = new Object[results.length][];
		for (int i = 0; i < results.length; i++) {
			shown[i] = results[i].toArray();
		}
		for (int i = 0; i < shown.length; i++) {
			for (int j = 0; j < shown[i].length; j++) {
				System.out.format("%-"
						+ (maxLenghts == null || j > maxLenghts.length
								|| maxLenghts[j] == 0 ? 20 : maxLenghts[j])
						+ "s|", shown[i][j]);
			}
			System.out.println();
		}
		for (int i = 0; i < results[0].size(); i++) {
			for (int j = 0; j < maxLenghts[i]; j++) {
				System.out.print('-');
			}
			System.out.print('-');
		}
		System.out.println();

	}

	/**
	 * Updates the secondary indexes whenever there is a change in the data due
	 * to a call of <code>deleteFrom(...)</code> or
	 * <code>insertedInto(...)/code> 
	 * @param recordsMoved The records that changed position in the disk.
	 * @param oldReferenceList The old position.
	 * @param newReferenceList Their current position.
	 */
	public void updateSecondaryIndexes(final LinkedList<Record> recordsMoved,
			final LinkedList<Reference> oldReferenceList,
			final LinkedList<Reference> newReferenceList) {
		Table table = Main.getCurrentTable();

		for (int i = 0; i < table.getNumberOfColumns(); i++) {
			if (table.getSecondaryIndex(i) != null) {
				table.getSecondaryIndex(i).updateReferences(recordsMoved,
						oldReferenceList, newReferenceList);
			}
		}
	}
}
