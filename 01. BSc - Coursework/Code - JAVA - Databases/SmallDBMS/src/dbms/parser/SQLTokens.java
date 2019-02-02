package dbms.parser;

/**
 * This enumeration type contains the tokens that our DBMS system's parser
 * produces, when reading a file or a user's command with SQL statements and
 * recognises appropriate lexical units.
 * 
 */

public enum SQLTokens {
	AND, BY, CHAR, COMMA, CREATE, DELETE, DOT, DROP, END_OF_COMMAND, EQUAL, FROM, GREATER, GREATER_OR_EQUAL, ID, INDEX, INSERT, INTEGER, INTERSECTION, INTO, KEY, LEFT_PARENTHESIS, LESS, LESS_OR_EQUAL, MINUS, NUMBER, ON, OR, ORDER, PRIMARY, QUOTED_ID, RIGHT_PARENTHESIS, SELECT, TABLE, UNION, UNKNOWN, VALUES, WHERE;
}
