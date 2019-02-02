package dbms;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintStream;

/**
 * This class creates a menu which presents to the user the options that our
 * DMBS system gives him. These are: 1 - Insert commands using the standard
 * input (keyboard). This option supports multiline input. That means that the
 * user can enter his SQL statement separated into many lines. However, in order
 * for the statement to be passed correctly to the parser, it must ends with the
 * semicolon character ';'. 2 - Load commands from a file. The statements are
 * being read from a file. 3 - Developers. It contains some information about
 * us. 0 - Exit.
 */

public class Menu
{

	/**
	 * Constructor: An empty construstor.
	 */

	public Menu()
	{

	}

	/**
	 * The basic method of this class. It shows the menu to the user.
	 */

	public void showMenu()
	{

		// Flushes the output and error channels

		System.out.flush();
		System.err.flush();

		// A quiet fancy characteristic. It is actually an ASCII banner that
		// draws the name of our small DBMS system. (Nidus DBMS)

		String[] title = {

				"00    10  0  000000   10     0  000000      0000001   000000  101    00  100000 ",
				"010   00  0  0     00 00     0 10    00     00    00  0    00 100    00  0     1",
				"0 10  00  0  0      0 00     0  00001       00     0  000000  1000  0 0  00001  ",
				"0  00 10  0  0      0 00     0     0000     00     0  0    00 00 0  0 0     0000",
				"0   0010  0  0     00 10    10 00     0     00    00  0     0 00 0 00 0 00     0",
				"0     00  0  000000    000000   0000001     0000001   000000  10  00  0  0000001" };

		BufferedReader input = new BufferedReader(new InputStreamReader(
				System.in));

		int menuChoice = 175;

		// The menu

		do
		{

			System.out.println();

			// This for loop draws our logo - ASCII banner to the screen

			for (int i = 0; i < title.length; i++)
			{
				System.out.println(title[i]);
			}

			// The choices we give to the user...

			System.out.println();
			System.out.println("1 - Insert SQL statements from the keyboard");
			System.out.println("2 - Load SQL statements from a file");
			System.out.println("3 - Who created NIDUS DBMS?");
			System.out.println();
			System.out.println("0 - Exit");
			System.out.println();
			System.out.print("Please insert the number of your choice: ");

			// If the user enter an invalid number then the system returns him
			// an appropriate message and asks him to make a choice again.

			try
			{
				try
				{
					menuChoice = Integer.parseInt(input.readLine());
				} catch (IOException e)
				{
					e.printStackTrace();
				}
			} catch (NumberFormatException e)
			{
				// If the choice that user enters is not a valid input
				// (integer), the system forces the switch case to go to the
				// default section in order to make the user to give another
				// (hopefully) valid input.
				menuChoice = 175;
			}

			switch (menuChoice)
			{
				case 0:
					Main.saveAll();
					System.out.println();
					System.out.println("The program will exit!");
				break;
				case 1:
					System.out.println();
					System.out.println();
					System.out.println();
					String singleCommand = insertCommand();
					Main.parse.parseCommands(singleCommand);
				break;
				case 2:
					System.out.println();
					System.out.println();
					System.out.println();
					System.out
							.print("Please insert the path of your SQLScript file: ");
					String path = null;
					// Gets the path that contains the SQL statements
					try
					{
						path = input.readLine();
					} catch (IOException e)
					{
						e.printStackTrace();
					}
					String sqlScript = loadCommandsFromFile(path);
		
					PrintStream stdOut = System.out;
					PrintStream stdErr = System.err;
					File outFile = new File("output.txt");
					File errFile = new File("errors.txt");
					if (!outFile.exists())
					{
						try
						{
							outFile.createNewFile();
						} catch (IOException e)
						{
							System.err.println("Error Creating output File");
						}
					}
					if (!errFile.exists())
					{
						try
						{
							errFile.createNewFile();
						} catch (IOException e)
						{
							System.err.println("Error Creating errorFile File");
						}
					}
					try
					{
						System.setErr(new PrintStream(errFile));
					} catch (FileNotFoundException e1)
					{
						System.setErr(stdErr);
					}
					try
					{
						System.setOut(new PrintStream(outFile));
					} catch (FileNotFoundException e)
					{
						System.setOut(stdOut);
					}
					Main.parse.parseCommands(sqlScript);
					System.err.close();
					System.out.close();
					System.setErr(stdErr);
					System.setOut(stdOut);
					
				break;
				case 3:
					System.out.println();
					System.out.println();
					System.out.println();
					System.out.println("NIDUS DBMS: ");
					System.out.println();
					System.out
							.println("Primitive dbms (supports only a small subset of the SQL-92 language");
					System.out
							.println("It is being implemented in the scope of an academic project for the");
					System.out
							.println("course Database Implementation, 6th Sememster of the Aristotle     ");
					System.out
							.println("Univercity of Thessaloniki, CS Department the academic year 2005-2006");
					System.out.println("from the undergraduate students:");
					System.out.println();
					System.out.println("Avgoustakis Chrisovalantis");
					System.out.println("Kritikos Apostolos");
					System.out.println("Skalistis Stefanos");
					System.out.println("Philippou Georgios");

				break;
				default:
					System.out.println();
					System.out
							.println("ERROR: Your choice must be between 0-3");
				break;
			}
		} while (menuChoice != 0);
	}

	/**
	 * Takes an SQL statement from the user (in single or multiline) and sends
	 * it to the sql parser
	 * 
	 * @return <code>String </code>
	 */

	public String insertCommand()
	{
		BufferedReader input = new BufferedReader(new InputStreamReader(
				System.in));

		String temp = null;
		boolean charFound = false;
		char endsWith;

		System.out.println("Insert your statement in single or multiple lines");
		System.out
				.println("the statement must ends with the semicolon character");
		System.out.println("(;)");
		System.out.println();

		// Shows the prompt

		System.out.print("Nidus DBMS > ");

		// We read the first line that the user inserts and ommit the space
		// characters to the beginning and end of the string

		try
		{
			temp = input.readLine();
			temp = temp.trim();
		} catch (IOException e1)
		{
			e1.printStackTrace();
		}

		// If for some reason our string remains null (as when it was
		// initialized) the program ends

		if (temp == null)
		{

			System.exit(-999);
		}

		// The endsWith variable checks if the last character of the string is
		// the semicolon...

		endsWith = temp.charAt(temp.length() - 1);

		// ... and if so, the while loop never starts (practically we know the
		// user inserted the whole statetment in one line.

		if (endsWith == ';')
		{
			charFound = true;
		}

		String finalString = temp;

		// This while loop asks for the user to enter one more line until he
		// ends his last string with the semicolon character.

		while (!charFound)
		{

			System.out.print("Nidus DBMS > ");

			// We read the first line that the user inserts and ommit the space
			// characters to the beginning and end of the string

			try
			{
				temp = input.readLine();
				temp = temp.trim();
			} catch (IOException e)
			{
				e.printStackTrace();
			}

			// The endsWith variable checks if the last character of the string
			// is the semicolon...

			endsWith = temp.charAt(temp.length() - 1);

			finalString = finalString + " " + temp;

			// ... and if so, the while loop is forced to stop (charFound
			// becomes true)

			if (endsWith == ';')
			{
				charFound = true;
			}

		}
		return finalString;
	}

	/**
	 * Takes SQL statements from a file and sends them to the sql parser
	 * 
	 * @param path
	 * @return <code>String</code>
	 */

	public String loadCommandsFromFile(String path)
	{

		// The path of the file which contains SQL statements
		File sqlScript = new File(path);
		BufferedReader fileInput = null;

		try
		{
			fileInput = new BufferedReader(new FileReader(sqlScript));
		} catch (FileNotFoundException e)
		{
			e.printStackTrace();
		}

		// Here we store the file's content after transforming it to a string.

		String finalString = "";
		String temp = null;

		// This boolean forces the while loop to end when it becomes true.

		boolean fileEnded = false;

		// If the file is empty we return after showing an appropriate message
		// to the user

		try
		{
			temp = fileInput.readLine();
			if (temp == null)
			{
				System.err
						.println("\n\n\n ERROR: The file is probably empty!!! \n\n\n");
				return "";
			}
		} catch (IOException e)
		{
			e.printStackTrace();
		}

		// This loop reads the whole file and creates a single string with its
		// content

		while (!fileEnded)
		{
			finalString = finalString + temp;

			try
			{
				temp = fileInput.readLine();
				if (temp == null)
				{
					fileEnded = true;
				}
			} catch (IOException e)
			{
				e.printStackTrace();
			}
		}

		return finalString;
	}

}
