package dbms.parser;

import java.util.ArrayList;
import java.util.Vector;

import dbms.Main;
import dbms.exececution.EnormousCharacterException;
import dbms.util.Char;


/**
 * This class implements a Parser for SQL-92.It doesn't yet support the "not equal" operator as well as the '(' & ')' that alter the priority of the operations.
 * @version 0.95
 */
public class SQLParser
{
	/**
	 * The lexical unit that was last recognized.
	 */
	private SQLTokens currentLexicalUnit;

	/**
	 * The index of the character at which the lexical unit starts.
	 */
	private int indexStartOfLexicalUnit;

	/**
	 * The index of the character at which the lexical unit ends.
	 */
	private int indexEndOfLexicalUnit;

	/**
	 * The SQL command in the form of <code>String</code>
	 */
	private String currentCommand;

	/**
	 * Contains the <code>String</code> from which the
	 * <code>currentLexicalUnit</code> has been ensued.
	 */
	private String currentLexicalString;

	/**
	 * The line of the command which the parser is currently processing.
	 */
	private int currentLine;


	/**
	 * An empty Constructor.
	 * 
	 */

	public SQLParser()
	{
		currentLexicalUnit = SQLTokens.UNKNOWN;
		indexStartOfLexicalUnit = 0;
		indexEndOfLexicalUnit = 0;
		currentCommand = "";
		currentLine = 1;
	}


	/**
	 * The parseCommands method finds the next command and calls the <code>parse</code>
	 * method to parse the command.
	 * @param BatchofCommands The String which forms the commands issued by the user or the automated batch of commands when these are entered from a file.
	 */
	public void parseCommands(String BatchofCommands)
	{
		int indexStartOfCommand, indexEndOfCommand;
		indexStartOfCommand = indexEndOfCommand = 0;
		while (indexEndOfCommand < BatchofCommands.length() - 1)
		{
			if (BatchofCommands.charAt(++indexEndOfCommand) == ';')
			{
				currentCommand = BatchofCommands.substring(indexStartOfCommand,
						++indexEndOfCommand);
				parse();
				indexStartOfCommand = indexEndOfCommand;
			}
		}
		if (!BatchofCommands.substring(indexStartOfCommand,
				BatchofCommands.length()).matches("[\\p{Space}]|"))/*
																	 * after |
																	 * the empty
																	 * string is
																	 * implied
																	 */
		{
			System.err.println("Commands must end with \'"
					+ SQLSymbols.END_OF_COMMAND
					+ "\' or with a white character!");
			System.err.println("Command \""
					+ BatchofCommands.substring(indexStartOfCommand,
							BatchofCommands.length())
					+ "\" does not meet the above requirement!");
		}
	}


	/**
	 * This method determines the next lexical unit from the <code>currentCommand</code>
	 * it tries to match it with one of the SQLReserved or SQLPatterns 
	 * our system recognises.
	 * 
	 * @return The <code>String</code> of the <code>lexicalUnit</code>. 
	 * @see SQLPatterns
	 */

	private String getNextLexicalUnit()
	{
		indexStartOfLexicalUnit = indexEndOfLexicalUnit;

		while (Character.isWhitespace(currentCommand
				.charAt(indexStartOfLexicalUnit)))
		{
			if (currentCommand.charAt(indexStartOfLexicalUnit) == '\n')
				currentLine++;
			indexEndOfLexicalUnit = ++indexStartOfLexicalUnit;
		}

		if (Character.toString(currentCommand.charAt(indexStartOfLexicalUnit))
				.matches(SQLPatterns.SYMBOL))
		{
			if (Character.toString(
					currentCommand.charAt(indexStartOfLexicalUnit)).equals(
					SQLSymbols.GREATER))
			{
				if (Character.toString(
						currentCommand.charAt(++indexEndOfLexicalUnit)).equals(
						SQLSymbols.EQUAL))
				{
					indexEndOfLexicalUnit++;
				}

			} else if (Character.toString(
					currentCommand.charAt(indexStartOfLexicalUnit)).equals(
					SQLSymbols.LESS))
			{
				if (Character.toString(
						currentCommand.charAt(++indexEndOfLexicalUnit)).equals(
						SQLSymbols.EQUAL))
				{
					indexEndOfLexicalUnit++;
				}

			} else if (Character.toString(
					currentCommand.charAt(indexStartOfLexicalUnit)).equals(
					SQLSymbols.QUOTE))
			{
				while (!Character.toString(
						currentCommand.charAt(++indexEndOfLexicalUnit)).equals(
						SQLSymbols.QUOTE))
				{
					if (indexEndOfLexicalUnit == currentCommand.length() - 1)
					{
						System.err
								.println("Line "
										+ currentLine
										+ ": Unclosed \"'\" .Please check the command!!!");
						break;
					}
				}
				indexEndOfLexicalUnit++;
			} else
				indexEndOfLexicalUnit++;

			return currentLexicalString = currentCommand.substring(
					indexStartOfLexicalUnit, indexEndOfLexicalUnit);
		}

		while (!Character
				.toString(currentCommand.charAt(indexEndOfLexicalUnit))
				.matches(SQLPatterns.DELIMITER))
		{
			if (currentCommand.charAt(indexStartOfLexicalUnit) == '\n')
				currentLine++;
			indexEndOfLexicalUnit++;
		}

		return currentLexicalString = currentCommand.substring(
				indexStartOfLexicalUnit, indexEndOfLexicalUnit);
	}

	

	/**
	 * This method matches the <code>lexicalUnit<code></code> it takes as a parameter with an SQL
	 * token this DBMS recognises. If it cannot be matched with anyone of
	 * these tokens it labels the lexical unit as unknown.
	 * 
	 * @param lexicalUnit The <code>String</code> to be recognised.
	 * @return SQLTokens The token that was recognized.
	 */

	private SQLTokens recognizeLexicalUnit(String lexicalUnit)
	{
		if (lexicalUnit.equals(String.valueOf(SQLSymbols.END_OF_COMMAND)))
			currentLexicalUnit = SQLTokens.END_OF_COMMAND;
		else if (lexicalUnit.equals(SQLSymbols.DOT))
			currentLexicalUnit = SQLTokens.DOT;
		else if (lexicalUnit.equals(SQLSymbols.COMMA))
			currentLexicalUnit = SQLTokens.COMMA;
		else if (lexicalUnit.equals(SQLSymbols.LEFT_PARENTHESIS))
			currentLexicalUnit = SQLTokens.LEFT_PARENTHESIS;
		else if (lexicalUnit.equals(SQLSymbols.RIGHT_PARENTHESIS))
			currentLexicalUnit = SQLTokens.RIGHT_PARENTHESIS;
		else if (lexicalUnit.equals(SQLSymbols.EQUAL))
			currentLexicalUnit = SQLTokens.EQUAL;
		else if (lexicalUnit.equals(SQLSymbols.GREATER))
			currentLexicalUnit = SQLTokens.GREATER;
		else if (lexicalUnit.equals(SQLSymbols.LESS))
			currentLexicalUnit = SQLTokens.LESS;
		else if (lexicalUnit.equals(SQLSymbols.GREATER_OR_EQUAL))
			currentLexicalUnit = SQLTokens.GREATER_OR_EQUAL;
		else if (lexicalUnit.equals(SQLSymbols.LESS_OR_EQUAL))
			currentLexicalUnit = SQLTokens.LESS_OR_EQUAL;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.AND.toString()))
			currentLexicalUnit = SQLTokens.AND;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.BY.toString()))
			currentLexicalUnit = SQLTokens.BY;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.CHAR.toString()))
			currentLexicalUnit = SQLTokens.CHAR;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.CREATE.toString()))
			currentLexicalUnit = SQLTokens.CREATE;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.DELETE.toString()))
			currentLexicalUnit = SQLTokens.DELETE;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.DROP.toString()))
			currentLexicalUnit = SQLTokens.DROP;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.FROM.toString()))
			currentLexicalUnit = SQLTokens.FROM;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.INDEX.toString()))
			currentLexicalUnit = SQLTokens.INDEX;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.INSERT.toString()))
			currentLexicalUnit = SQLTokens.INSERT;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.INTEGER.toString()))
			currentLexicalUnit = SQLTokens.INTEGER;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.INTERSECTION
				.toString()))
			currentLexicalUnit = SQLTokens.INTERSECTION;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.INTO.toString()))
			currentLexicalUnit = SQLTokens.INTO;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.KEY.toString()))
			currentLexicalUnit = SQLTokens.KEY;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.MINUS.toString()))
			currentLexicalUnit = SQLTokens.MINUS;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.ON.toString()))
			currentLexicalUnit = SQLTokens.ON;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.OR.toString()))
			currentLexicalUnit = SQLTokens.OR;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.ORDER.toString()))
			currentLexicalUnit = SQLTokens.ORDER;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.PRIMARY.toString()))
			currentLexicalUnit = SQLTokens.PRIMARY;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.SELECT.toString()))
			currentLexicalUnit = SQLTokens.SELECT;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.TABLE.toString()))
			currentLexicalUnit = SQLTokens.TABLE;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.UNION.toString()))
			currentLexicalUnit = SQLTokens.UNION;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.VALUES.toString()))
			currentLexicalUnit = SQLTokens.VALUES;
		else if (lexicalUnit.equalsIgnoreCase(SQLReserved.WHERE.toString()))
			currentLexicalUnit = SQLTokens.WHERE;
		else if (lexicalUnit.matches(SQLPatterns.INTEGER_NUMBER_PATTERN
				.toString()))
			currentLexicalUnit = SQLTokens.NUMBER;
		else if (lexicalUnit.matches(SQLPatterns.ID_PATTERN.toString()))
			currentLexicalUnit = SQLTokens.ID;
		else if (lexicalUnit.matches(SQLPatterns.QUOTED_ID_PATTERN.toString()))
			currentLexicalUnit = SQLTokens.QUOTED_ID;
		else
			currentLexicalUnit = SQLTokens.UNKNOWN;
		return currentLexicalUnit;
	}

	/**
	 * If a create table query has been recognised from the parse method,
	 * parseCreateTable method checks if it is correct and then makes the 
	 * ExececutionMachine to execute it. If it is not in a valid format, it
	 * returns a message that marks the error found and continues with the
	 * next query.
	 */

	private void parseCreateTable()
	{
		// CREATE TABLE emp
		// (id INTEGER,
		// name CHAR,
		// salary INTEGER,
		// PRIMARY KEY (id));

		// CREATE TABLE has been recognized
		recognizeLexicalUnit(getNextLexicalUnit());
		if (currentLexicalUnit == SQLTokens.ID)
		{
			String tableName = currentLexicalString;

			recognizeLexicalUnit(getNextLexicalUnit());
			if (currentLexicalUnit == SQLTokens.LEFT_PARENTHESIS)
			{
				boolean isFinished = false;
				Vector<Object[]> columns = new Vector<Object[]>();
				Object column[];
				while (!isFinished)
				{
					recognizeLexicalUnit(getNextLexicalUnit());
					if (currentLexicalUnit == SQLTokens.ID)
					{
						column = new Object[2];
						column[0] = currentLexicalString;
					} else if (currentLexicalUnit == SQLTokens.PRIMARY)
					{
						if (columns.size() == 0)
						{
							printError("Identifier", currentLexicalString);
							return;
						}
						isFinished = true;
						break;

					} else
					{
						printError("Identifier", currentLexicalString);
						return;
					}

					recognizeLexicalUnit(getNextLexicalUnit());
					if (currentLexicalUnit == SQLTokens.CHAR
							|| currentLexicalUnit == SQLTokens.INTEGER)
					{
						column[1] = currentLexicalUnit;
					} else
					{
						printError("\'" + SQLReserved.CHAR + "\' or \'"
								+ SQLReserved.INTEGER + "\'",
								currentLexicalString);
						return;
					}

					recognizeLexicalUnit(getNextLexicalUnit());
					if (currentLexicalUnit == SQLTokens.COMMA)
					{
						columns.add(column);
					} else
					{
						printError(SQLSymbols.COMMA, currentLexicalString);
						return;
					}
				}

				// CREATE TABLE emp
				// (id INTEGER,
				// name CHAR,
				// salary INTEGER,
				// PRIMARY

				recognizeLexicalUnit(getNextLexicalUnit());
				if (currentLexicalUnit == SQLTokens.KEY)
				{
					recognizeLexicalUnit(getNextLexicalUnit());
					if (currentLexicalUnit == SQLTokens.LEFT_PARENTHESIS)
					{

						recognizeLexicalUnit(getNextLexicalUnit());
						if (currentLexicalUnit == SQLTokens.ID)
						{
							String primaryKey = currentLexicalString;

							recognizeLexicalUnit(getNextLexicalUnit());
							if (currentLexicalUnit == SQLTokens.RIGHT_PARENTHESIS)
							{
								recognizeLexicalUnit(getNextLexicalUnit());
								if (currentLexicalUnit == SQLTokens.RIGHT_PARENTHESIS)
								{
									recognizeLexicalUnit(getNextLexicalUnit());
									if (currentLexicalUnit == SQLTokens.END_OF_COMMAND)
									{
										Main.exe.createTable(tableName, columns
												.toArray(), primaryKey);

									} else
										printError("\'"
												+ SQLSymbols.END_OF_COMMAND
												+ "\'", currentLexicalString);
								} else
									printError("\'"
											+ SQLSymbols.RIGHT_PARENTHESIS
											+ "\'", currentLexicalString);
							} else
								printError("\'" + SQLSymbols.RIGHT_PARENTHESIS
										+ "\'", currentLexicalString);

						} else
							printError("Identifier", currentLexicalString);
					} else
						printError("\'" + SQLSymbols.LEFT_PARENTHESIS + "\'",
								currentLexicalString);

				} else
					printError(SQLReserved.KEY.toString(), currentLexicalString);

			} else
				printError(SQLSymbols.LEFT_PARENTHESIS, currentLexicalString);
		} else
			printError("Identifier", currentLexicalString);
	}

	
	/**
	 * If a create index query has been recognised from the parse method, the
	 * parseCreateIndex method checks if it is correct and then makes the 
	 * ExececutionMachine to execute it. If it is not in a valid format, it
	 * returns a message that marks the error found and continues with the
	 * next query.
	 */

	private void parseCreateIndex()
	{

		// CREATE INDEX όνομαIndex ON όνομαΠίνακα ( όνομαΣτήλης )

		// CREATE INDEX has been recognized

		recognizeLexicalUnit(getNextLexicalUnit());
		if (currentLexicalUnit == SQLTokens.ID)
		{
			String indexName = currentLexicalString; // the name of the index

			recognizeLexicalUnit(getNextLexicalUnit());
			if (currentLexicalUnit == SQLTokens.ON)
			{
				// CREATE INDEX id ON has been recognized
				recognizeLexicalUnit(getNextLexicalUnit());
				if (currentLexicalUnit == SQLTokens.ID)
				{
					// CREATE INDEX id ON id has been recognized
					String tableName = currentLexicalString; // the name of
					// the table
					recognizeLexicalUnit(getNextLexicalUnit());
					if (currentLexicalUnit == SQLTokens.LEFT_PARENTHESIS)
					{
						// CREATE INDEX id ON id( has been recognized
						recognizeLexicalUnit(getNextLexicalUnit());
						if (currentLexicalUnit == SQLTokens.ID)
						{
							// CREATE INDEX id ON id(id has been recognized
							String columnName = currentLexicalString;

							recognizeLexicalUnit(getNextLexicalUnit());
							if (currentLexicalUnit == SQLTokens.RIGHT_PARENTHESIS)
							{
								// CREATE INDEX id ON id(id) has been recognized
								recognizeLexicalUnit(getNextLexicalUnit());
								if (currentLexicalUnit == SQLTokens.END_OF_COMMAND)
								{
									// CREATE INDEX id ON id(id) has been
									// recognized
									Main.exe.createIndex(indexName, tableName,
											columnName);
								} else
									printError(SQLSymbols.END_OF_COMMAND,
											currentLexicalString);
							} else
								printError(SQLSymbols.RIGHT_PARENTHESIS,
										currentLexicalString);
						} else
							printError("Identifier", currentLexicalString);
					} else
						printError(SQLSymbols.LEFT_PARENTHESIS,
								currentLexicalString);
				} else
					printError("Identifier", currentLexicalString);
			} else
				printError(SQLReserved.ON.toString(), currentLexicalString);

		} else
			printError("Identifier", currentLexicalString);

	}


	/**
	 * If a select query has been recognised from the parse method, parseSelect
	 * method checks if it is correct and then makes the 
	 * ExececutionMachine to execute it. If it is not in a valid format, it
	 * returns a message that marks the error found and continues with the
	 * next query.
	 */

	private void parseSelect()
	{
		// SELECT id, name
		// FROM emp
		// WHERE salary > 100
		// ORDER BY name;

		// SELECT has been recognized
		boolean nextSelectExists = true;
		ArrayList<SQLTokens> operationBetweenEachSelect = new ArrayList<SQLTokens>();
		ArrayList<ArrayList<String>> columnsOfEachSelect = new ArrayList<ArrayList<String>>();
		ArrayList<ArrayList<String>> tablesOfEachSelect = new ArrayList<ArrayList<String>>();
		ArrayList<ArrayList<Object[]>> conditionOfEachSelect = new ArrayList<ArrayList<Object[]>>();
		ArrayList<String> orderingColumnOfEachSelect = new ArrayList<String>();
		while (nextSelectExists)
		{
			recognizeLexicalUnit(getNextLexicalUnit());
			if (currentLexicalUnit == SQLTokens.ID)
			{
				// SELECT id has been recognized
				ArrayList<String> columns = new ArrayList<String>();
				columns.add(currentLexicalString);
				boolean isFinished = false;// if has finished with the column
				// names in the SELECT section or the tables names in the FROM
				// section
				while (!isFinished)
				{
					recognizeLexicalUnit(getNextLexicalUnit());
					if (currentLexicalUnit == SQLTokens.COMMA)
					{
						// SELECT ...id, has been recognized
						recognizeLexicalUnit(getNextLexicalUnit());
						if (currentLexicalUnit == SQLTokens.ID)
						{
							// SELECT ...id
							columns.add(currentLexicalString);
						} else
						{
							printError("Identifier", currentLexicalString);
							System.err.println("Try removing the last \',\'");
							return;
						}

					} else if (currentLexicalUnit == SQLTokens.FROM)
					{
						// SELECT ...id FROM has been recognized
						isFinished = true;
						columnsOfEachSelect.add(columns);
						continue;
					} else
					{
						printError("\'" + SQLSymbols.COMMA + "\' or "
								+ SQLReserved.FROM, currentLexicalString);
						return;
					}

					
				}
				// SELECT ...id FROM has been recognized

				recognizeLexicalUnit(getNextLexicalUnit());
				if (currentLexicalUnit == SQLTokens.ID)
				{
					// SELECT ...id FROM id has been recognized
					isFinished = false;

					ArrayList<String> tables = new ArrayList<String>();
					// operation[i] between tables[i] and table[i+1]
					// Vector<SQLTokens> operations = new Vector<SQLTokens>();

					tables.add(currentLexicalString);

					while (!isFinished)
					{
						recognizeLexicalUnit(getNextLexicalUnit());
						if (currentLexicalUnit == SQLTokens.COMMA)
						{
							// SELECT ...id FROM ...id, has been recognized or

							recognizeLexicalUnit(getNextLexicalUnit());
							if (currentLexicalUnit == SQLTokens.ID)
							{
								// SELECT ...id FROM ...id
								tables.add(currentLexicalString);
							} else
							{
								printError("Identifier", currentLexicalString);
								return;
							}

						} else if (currentLexicalUnit == SQLTokens.END_OF_COMMAND)
						{
							tablesOfEachSelect.add(tables);
							conditionOfEachSelect.add(new ArrayList<Object[]>());
							orderingColumnOfEachSelect.add("");
							Main.exe.select(operationBetweenEachSelect,
									tablesOfEachSelect, columnsOfEachSelect,
									conditionOfEachSelect,
									orderingColumnOfEachSelect);
							nextSelectExists = false;
									return;
						} else if (currentLexicalUnit == SQLTokens.WHERE
								|| currentLexicalUnit == SQLTokens.ORDER
								|| currentLexicalUnit == SQLTokens.UNION
								|| currentLexicalUnit == SQLTokens.INTERSECTION
								|| currentLexicalUnit == SQLTokens.MINUS)
						{
							// SELECT ...id FROM ...id WHERE has been recognized
							// or
							// SELECT ...id FROM ...id ORDER has been recognized
							// or
							// SELECT ...id FROM ...id UNION has been recognized
							// or
							// SELECT ...id FROM ...id INTERSECTION has been
							// recognized
							// or
							// SELECT ...id FROM ...id MINUS has been recognized

							tablesOfEachSelect.add(tables);
							isFinished = true;
						} else
						{
							printError("\'" + SQLSymbols.COMMA + "\' or \'"
									+ SQLSymbols.END_OF_COMMAND + "\' or "
									+ SQLReserved.WHERE + " or "
									+ SQLReserved.ORDER + " or "
									+ SQLTokens.UNION + " or "
									+ SQLTokens.INTERSECTION + " or "
									+ SQLTokens.MINUS, currentLexicalString);
							return;
						}

					}

					ArrayList<Object[]> conditions = new ArrayList<Object[]>();

					if (currentLexicalUnit == SQLTokens.WHERE)
					{
						// SELECT ...id FROM ...id WHERE has been recognized
						Object condition[];
						isFinished = false;

						while (!isFinished)
						{
							condition = new Object[3];
							recognizeLexicalUnit(getNextLexicalUnit());
							if (currentLexicalUnit == SQLTokens.ID)
							{
								condition[0] = currentLexicalString;
							} else
							{
								printError("Identifier", currentLexicalString);
								return;
							}

							recognizeLexicalUnit(getNextLexicalUnit());
							if (currentLexicalString
									.matches(SQLPatterns.CONDITION_SYMBOLS))
							{
								// SELECT ...id FROM ...id WHERE id
								// CONDITION_SYMBOL
								// has been recognized
								condition[1] = currentLexicalUnit;
							} else
							{
								printError(
										"\'<\' or \'>\' or \'<=\' or \'>=\'",
										currentLexicalString);
								return;
							}

							recognizeLexicalUnit(getNextLexicalUnit());
							if (currentLexicalUnit == SQLTokens.QUOTED_ID)
							{
								// SELECT ...id FROM ...id
								// WHERE id CONDITION_SYMBOL id has been
								// recognized
								try
								{
									condition[2] = new Char(
											currentLexicalString.substring(1,
													currentLexicalString
															.length() - 1));
								} catch (EnormousCharacterException e)
								{
									System.err
											.println("Error while selecting values from tables!");
									System.err
											.println("The "
													+ currentLexicalString
													+ " is too big!Please insert a shorter one!");
									System.out.println();
									return;
								}
								conditions.add(condition);
							} else if (currentLexicalUnit == SQLTokens.NUMBER)
							{
								// SELECT ...id FROM ...id WHERE id
								// CONDITION_SYMBOL Number has been recognized
								condition[2] = new Integer(currentLexicalString);
								conditions.add(condition);
							} else
							{
								printError("Quoted Identifier or Number",
										currentLexicalString);
								return;
							}

							recognizeLexicalUnit(getNextLexicalUnit());
							if (currentLexicalUnit == SQLTokens.END_OF_COMMAND)
							{
								conditionOfEachSelect.add(conditions);
								orderingColumnOfEachSelect.add("");
								Main.exe.select(operationBetweenEachSelect,
										tablesOfEachSelect,
										columnsOfEachSelect,
										conditionOfEachSelect,
										orderingColumnOfEachSelect);
								nextSelectExists = false;
								return;
							} else if (currentLexicalUnit == SQLTokens.AND
									|| currentLexicalUnit == SQLTokens.OR)
							{
								// SELECT ...id FROM ...id
								// WHERE id CONDITION_SYMBOL id AND/OR has been
								// recognized
								conditions
										.add(new Object[] { currentLexicalUnit });
								continue;
							} else if (currentLexicalUnit == SQLTokens.ORDER
									|| currentLexicalUnit == SQLTokens.UNION
									|| currentLexicalUnit == SQLTokens.INTERSECTION
									|| currentLexicalUnit == SQLTokens.MINUS)
							{
								// SELECT ...id FROM ...id
								// WHERE id CONDITION_SYMBOL id
								// ORDER has been recognized
								conditionOfEachSelect.add(conditions);
								isFinished = true;
							} else
							{
								printError("\'" + SQLSymbols.END_OF_COMMAND
										+ "\' or " + SQLReserved.ORDER + " or "
										+ SQLReserved.AND + " or "
										+ SQLReserved.OR + " or "
										+ SQLTokens.UNION + " or "
										+ SQLTokens.INTERSECTION + " or "
										+ SQLTokens.MINUS, currentLexicalString);
							}

						}
					}
					else
					{
						conditionOfEachSelect.add( new ArrayList<Object[]>() );
						
					}
					if (currentLexicalUnit == SQLTokens.ORDER)
					{
						recognizeLexicalUnit(getNextLexicalUnit());
						if (currentLexicalUnit == SQLTokens.BY)
						{
							// SELECT ...id FROM ...id
							// [WHERE ...]
							// ORDER BY has been recognized

							recognizeLexicalUnit(getNextLexicalUnit());
							if (currentLexicalUnit == SQLTokens.ID)
							{
								// SELECT ...id FROM ...id
								// [WHERE ...]
								// ORDER BY id has been recognized

								String orderingColumn = currentLexicalString;
								orderingColumnOfEachSelect
								.add(orderingColumn);
								
								recognizeLexicalUnit(getNextLexicalUnit());
								if (currentLexicalUnit == SQLTokens.END_OF_COMMAND)
								{
									Main.exe.select(operationBetweenEachSelect,
											tablesOfEachSelect,
											columnsOfEachSelect,
											conditionOfEachSelect,
											orderingColumnOfEachSelect);
									nextSelectExists = false;
									return;

								} else if (currentLexicalUnit == SQLTokens.UNION
										|| currentLexicalUnit == SQLTokens.INTERSECTION
										|| currentLexicalUnit == SQLTokens.MINUS)
								{
									// do nothing...it will be done later
								} else
								{
									printError("\'" + SQLSymbols.END_OF_COMMAND
											+ "\' or " + SQLTokens.UNION
											+ " or " + SQLTokens.INTERSECTION
											+ " or " + SQLTokens.MINUS,
											currentLexicalString);
									return;
								}
							} else
							{
								printError("Identifier", currentLexicalString);
								return;
							}

						} else
						{
							printError(SQLReserved.BY.toString(),
									currentLexicalString);
							return;
						}
					}
					else
					{
						orderingColumnOfEachSelect.add("");
					}
					if (currentLexicalUnit == SQLTokens.UNION
							|| currentLexicalUnit == SQLTokens.INTERSECTION
							|| currentLexicalUnit == SQLTokens.MINUS)
					{
						// SELECT ...id FROM ...id
						// [WHERE ...]
						// [ORDER BY id]
						// UNION or INTERSECTION or MINUS has been
						// recognized
						operationBetweenEachSelect.add(currentLexicalUnit);
						recognizeLexicalUnit(getNextLexicalUnit());
						if (currentLexicalUnit == SQLTokens.SELECT)
						{
							continue;
						} else
						{
							printError(SQLReserved.SELECT.toString(),
									currentLexicalString);
						}
					}
				} else
				{
					printError("Identifier", currentLexicalString);
					return;
				}

			} else
			{
				printError("Identifier", currentLexicalString);
				return;
			}
		}
	}

	/**
	 * If an insert query has been recognised from the parse method,
	 * parseInsertInto method checks if it is correct and then makes the 
	 * ExececutionMachine to execute it. If it is not in a valid format, it
	 * returns a message that marks the error found and continues with the
	 * next query.
	 */

	private void parseInsertInto()
	{
		// INSERT INTO όνομαΠίνακα VALUES (x, …, x);

		// INSERT INTO has been recognized

		recognizeLexicalUnit(getNextLexicalUnit());

		if (currentLexicalUnit == SQLTokens.ID)
		{
			// INSERT INTO id has been recognized
			String tableName = currentLexicalString; // the name of the table

			recognizeLexicalUnit(getNextLexicalUnit());
			if (currentLexicalUnit == SQLTokens.VALUES)
			{
				// INSERT INTO id VALUES has been recognized
				recognizeLexicalUnit(getNextLexicalUnit());
				if (currentLexicalUnit == SQLTokens.LEFT_PARENTHESIS)
				{
					// INSERT INTO id VALUES( has been recognized
					Vector<Object> values = new Vector<Object>();
					boolean isFinished = false;
					while (!isFinished)
					{
						recognizeLexicalUnit(getNextLexicalUnit());
						if (currentLexicalUnit == SQLTokens.QUOTED_ID)
						{
							// INSERT INTO id VALUES(...,id has been recognized
							try
							{
								values.add(new Char(currentLexicalString
										.substring(1, currentLexicalString
												.length() - 1)));
							} catch (EnormousCharacterException e)
							{
								System.err
										.println("Error while inserting values into table \""
												+ tableName + "\"");
								System.err
										.println("The "
												+ currentLexicalString
												+ " is too big!Please insert a shorter one!");
								System.err.println();
							}
						} else if (currentLexicalUnit == SQLTokens.NUMBER)
						{
							// INSERT INTO id VALUES(...,id has been recognized
							values.add(new Integer(currentLexicalString));
						} else
						{
							printError("Quoted Identifier or Number",
									currentLexicalString);
							return;
						}

						recognizeLexicalUnit(getNextLexicalUnit());
						if (currentLexicalUnit == SQLTokens.COMMA)
						{
							// INSERT INTO id VALUES(..., has been recognized
						} else if (currentLexicalUnit == SQLTokens.RIGHT_PARENTHESIS)
						{
							// INSERT INTO id VALUES(...) has been recognized
							if (values.size() != 0)
							{
								isFinished = true;
							} else
							{
								printError("Quoted Identifier or Number",
										currentLexicalString);
								return;
							}
						} else
						{
							printError("\'" + SQLSymbols.COMMA + "\' or "
									+ SQLSymbols.RIGHT_PARENTHESIS + "\'",
									currentLexicalString);
							return;
						}
					}

					// INSERT INTO id VALUES(...) has been recognized
					recognizeLexicalUnit(getNextLexicalUnit());
					if (currentLexicalUnit == SQLTokens.END_OF_COMMAND)
					{
						// INSERT INTO id VALUES(...); has been recognized
						Main.exe.insertInto(tableName, values.toArray());
					} else
						printError(SQLSymbols.END_OF_COMMAND,
								currentLexicalString);
				} else
					printError(SQLSymbols.LEFT_PARENTHESIS,
							currentLexicalString);
			} else
				printError(SQLReserved.VALUES.toString(), currentLexicalString);
		} else
			printError("Identifier", currentLexicalString);
	}


	/**
	 * If a delete query has been recognised from the parse method,
	 * parseDeleteFrom method checks if it is correct and then makes the 
	 * ExececutionMachine to execute it. If it is not in a valid format, it
	 * returns a message that marks the error found and continues with the
	 * next query.
	 */

	private void parseDeleteFrom()
	{
		// DELETE FROM όνομαΠίνακα WHERE συνθήκη;
		// DELETE FROM has been recognized

		recognizeLexicalUnit(getNextLexicalUnit());

		if (currentLexicalUnit == SQLTokens.ID)
		{
			// DELETE FROM id has been recognized
			String tableName = currentLexicalString; // the name of the table

			recognizeLexicalUnit(getNextLexicalUnit());
			if (currentLexicalUnit == SQLTokens.WHERE)
			{
				// DELETE FROM id WHERE has been recognized
				Object condition[] = new Object[3];

				recognizeLexicalUnit(getNextLexicalUnit());
				if (currentLexicalUnit == SQLTokens.ID)
				{
					// DELETE FROM id WHERE id has been recognized
					condition[0] = currentLexicalString;

					recognizeLexicalUnit(getNextLexicalUnit());
					if (currentLexicalString
							.matches(SQLPatterns.CONDITION_SYMBOLS))
					{
						// DELETE FROM id WHERE id CONDITION_SYMBOL has been
						// recognized
						condition[1] = currentLexicalUnit;
						recognizeLexicalUnit(getNextLexicalUnit());
						if (currentLexicalUnit == SQLTokens.QUOTED_ID)
						{
							// DELETE FROM id WHERE id CONDITION_SYMBOL id has
							// been recognized
							try
							{
								condition[2] = new Char(currentLexicalString
										.substring(1, currentLexicalString
												.length() - 1));
							} catch (EnormousCharacterException e)
							{
								System.err
										.println("Error while deleting values from table \""
												+ tableName + "\"!");
								System.err
										.println("The "
												+ currentLexicalString
												+ " is too big!Please insert a shorter one!");
								System.out.println();
								return;
							}

							recognizeLexicalUnit(getNextLexicalUnit());
							if (currentLexicalUnit == SQLTokens.END_OF_COMMAND)
							{
								Main.exe.deleteFrom(tableName, condition);
							} else
								printError(SQLSymbols.END_OF_COMMAND,
										currentLexicalString);
						} else if (currentLexicalUnit == SQLTokens.NUMBER)
						{
							condition[2] = new Integer(currentLexicalString);

							recognizeLexicalUnit(getNextLexicalUnit());
							if (currentLexicalUnit == SQLTokens.END_OF_COMMAND)
							{
								Main.exe.deleteFrom(tableName, condition);
							}
						} else
							printError("Quoted Identifier or Number",
									currentLexicalString);
					} else
						printError("\'<\' or \'>\' or \'<=\' or \'>=\'",
								currentLexicalString);
				} else
					printError("Identifier", currentLexicalString);
			} else
				printError(SQLReserved.WHERE.toString(), currentLexicalString);
		} else
			printError("Identifier", currentLexicalString);
	}



	/**
	 * If a drop index query has been recognised from the parse method,
	 * parseDropIndex method checks if it is correct and then makes the 
	 * ExececutionMachine to execute it. If it is not in a valid format, it
	 * returns a message that marks the error found and continues with the
	 * next query.	 */

	private void parseDropIndex()
	{
		// DROP INDEX όνομαIndex
		// DROP INDEX has been recognized

		recognizeLexicalUnit(getNextLexicalUnit());

		if (currentLexicalUnit == SQLTokens.ID)
		{
			String indexName = currentLexicalString; // the name of the index

			recognizeLexicalUnit(getNextLexicalUnit());
			if (currentLexicalUnit == SQLTokens.END_OF_COMMAND)
			{
				Main.exe.dropIndex(indexName);
			} else
				printError(SQLSymbols.END_OF_COMMAND, currentLexicalString);
		} else
			printError("Identifier", currentLexicalString);
	}

	/**
	 * The parse method tries to match the command that was given to her with
	 * one of the commands that our DBMS system supports. If it succeed then it
	 * calls the appropriate to check if the whole statement has the appropriate
	 * format. If the query has commands that are not supported it produces 
	 * an appropriate message to the user.
	 * 
	 */

	private void parse()
	{
		indexEndOfLexicalUnit = indexStartOfLexicalUnit = 0;

		recognizeLexicalUnit(getNextLexicalUnit());

		if (currentLexicalUnit == SQLTokens.CREATE)
		{
			// CREATE has been recognized
			recognizeLexicalUnit(getNextLexicalUnit());
			if (currentLexicalUnit == SQLTokens.TABLE)
			{
				// CREATE TABLE has been recognized
				parseCreateTable();
			} else if (currentLexicalUnit == SQLTokens.INDEX)
			{
				// CREATE INDEX has been recognized
				parseCreateIndex();
			} else
				printError(SQLReserved.TABLE + " or " + SQLReserved.INDEX,
						currentLexicalString);

		} else if (currentLexicalUnit == SQLTokens.SELECT)
		{
			// SELECT has been recognized
			parseSelect();
		} else if (currentLexicalUnit == SQLTokens.INSERT)
		{
			// INSERT has been recognized
			recognizeLexicalUnit(getNextLexicalUnit());
			if (currentLexicalUnit == SQLTokens.INTO)
			{
				// INSERT INTO has been recognized
				parseInsertInto();
			} else
				printError(SQLReserved.INTO.toString(), currentLexicalString);

		} else if (currentLexicalUnit == SQLTokens.DELETE)
		{
			// DELETE has been recognized
			recognizeLexicalUnit(getNextLexicalUnit());
			if (currentLexicalUnit == SQLTokens.FROM)
			{
				// DELETE FROM has been recognized
				parseDeleteFrom();
			} else
				printError(SQLReserved.FROM.toString(), currentLexicalString);
		} else if (currentLexicalUnit == SQLTokens.DROP)
		{
			// DROP has been recognized
			recognizeLexicalUnit(getNextLexicalUnit());
			if (currentLexicalUnit == SQLTokens.INDEX)
			{
				// DROP INDEX has been recognized
				parseDropIndex();
			} else
				printError(SQLReserved.INDEX.toString(), currentLexicalString);
		} else
		{
			System.err.println("\"" + currentLexicalString + "\""
					+ " is not a supported command!");
			System.err.println("Only the following commands are supported:\n");
			System.err.print("CREATE TABLE\nCREATE INDEX\n");
			System.err.print("DELETE FROM\nDROP INDEX\n");
			System.err.print("INSERT INTO\nSELECT\n");
		}

	}


	/**
	 * Returns a message to the user if another lexical unit's type appear where
	 * something else was expected.
	 * 
	 * @param expected The String representation of the expected lexicalUnit.
	 * @param found The String that was found.
	 */

	private void printError(String expected, String found)
	{
		System.err.println("Line " + currentLine + ": " + expected
				+ " was expected...found: \"" + found + "\" which is "
				+ currentLexicalUnit + " type!");
	}
}
