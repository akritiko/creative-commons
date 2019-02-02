package dbms.parser;

/**
 * This class describes every lexical unit our system can recognise
 * by assigning a regular expression to it.
 * 
 */
class SQLPatterns {
	/**
	 * The pattern for an integer number.
	 */
	public static final String INTEGER_NUMBER_PATTERN = "0|[1-9][\\p{Digit}]*";

	/**
	 * The pattern for an id.
	 */
	public static final String ID_PATTERN = "[_\\p{InGreek}\\p{Alpha}][_\\p{InGreek}\\p{Alnum}]*";

	/**
	 * The pattern for a quoted id.
	 */
	public static final String QUOTED_ID_PATTERN = "[']" + ID_PATTERN + "[']";

	/**
	 * The pattern for a delimiter.
	 */
	public static final String DELIMITER = "[\\p{Space}\\(\\)<>=,\\.;']";

	/**
	 * The pattern for a symbol.
	 */
	public static final String SYMBOL = "[\\(\\)<>=,\\.;']";

	/**
	 * The pattern for a condition symbol.
	 */
	public static final String CONDITION_SYMBOLS = "[<>=]|<=|>=";

	/**
	 * The pattern for the end of command.
	 */
	public static final String END_OF_COMMAND = "[;]";
}
