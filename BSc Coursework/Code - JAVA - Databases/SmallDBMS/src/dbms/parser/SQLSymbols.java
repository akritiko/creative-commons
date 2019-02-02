package dbms.parser;

/**
 * This class assigns all the symbols our system needs to recognise
 * and handle, with a keyword.
 */

public class SQLSymbols {
	/**
	 * The end of command symbol.
	 */
	public static final String END_OF_COMMAND = ";";

	/**
	 * The dot symbol.
	 */
	public static final String DOT = ".";

	/**
	 * The comma symbol.
	 */
	public static final String COMMA = ",";

	/**
	 * The single quote symbol.
	 */
	public static final String QUOTE = "'";

	/**
	 * The left parenthesis symbol.
	 */
	public static final String LEFT_PARENTHESIS = "(";

	/**
	 * The right parenthesis symbol.
	 */
	public static final String RIGHT_PARENTHESIS = ")";

	/**
	 * The equal symbol.
	 */
	public static final String EQUAL = "=";

	/**
	 * The greater symbol.
	 */
	public static final String GREATER = ">";

	/**
	 * The less symbol.
	 */
	public static final String LESS = "<";

	/**
	 * The greater or equal symbol.
	 */
	public static final String GREATER_OR_EQUAL = GREATER + EQUAL;

	/**
	 * The less or equal symbol.
	 */
	public static final String LESS_OR_EQUAL = LESS + EQUAL;
}
