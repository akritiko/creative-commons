import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.JTextField;

public class InitialWindow extends JFrame
{
	private JPanel jContentPane = null;
	private JScrollPane jScrollPane = null;
	private JTextArea jTextArea = null;
	private JLabel jLabel = null;
	private JScrollPane jScrollPane1 = null;
	private JTextArea jTextArea1 = null;
	private JLabel jLabel1 = null;
	private JScrollPane jScrollPane2 = null;
	private JTextArea jTextArea2 = null;
	private JLabel jLabel2 = null;
	private JScrollPane jScrollPane3 = null;
	private JTextArea jTextArea3 = null;
	private JLabel jLabel3 = null;
	private JScrollPane jScrollPane4 = null;
	private JTextArea jTextArea4 = null;
	private JLabel jLabel4 = null;
	private JTextField jTextField = null;
	private JTextField jTextField1 = null;
	private JTextField jTextField2 = null;
	private JTextField jTextField3 = null;
	private JTextField jTextField4 = null;
	private JScrollPane jScrollPane5 = null;
	private JTextArea jTextArea5 = null;
	private JTextField jTextField5 = null;
	private JLabel jLabel5 = null;
	private JScrollPane jScrollPane6 = null;
	private JTextArea jTextArea6 = null;
	private JScrollPane jScrollPane7 = null;
	private JTextArea jTextArea7 = null;
	private JScrollPane jScrollPane8 = null;
	private JTextArea jTextArea8 = null;
	private JScrollPane jScrollPane9 = null;
	private JTextArea jTextArea9 = null;
	private JLabel jLabel6 = null;
	private JLabel jLabel7 = null;
	private JLabel jLabel8 = null;
	private JLabel jLabel9 = null;
	private JTextField jTextField6 = null;
	private JTextField jTextField7 = null;
	private JTextField jTextField8 = null;
	private JTextField jTextField9 = null;
	private JButton jButton = null;
	private JLabel jLabel10 = null;

	private JTextArea[] txtAreas;
	private JTextField[] txtFields;
	private final int MIN_NUM_OF_FILES = 10;

	/**
	 * This is the default constructor
	 */
	public InitialWindow()
	{
		super();
		initialize();

		// Κώδικας που προσθέσαμε.
		txtAreas = new JTextArea[10];
		txtAreas[0] = jTextArea;
		txtAreas[1] = jTextArea1;
		txtAreas[2] = jTextArea2;
		txtAreas[3] = jTextArea3;
		txtAreas[4] = jTextArea4;
		txtAreas[5] = jTextArea5;
		txtAreas[6] = jTextArea6;
		txtAreas[7] = jTextArea7;
		txtAreas[8] = jTextArea8;
		txtAreas[9] = jTextArea9;

		txtFields = new JTextField[10];
		txtFields[0] = jTextField;
		txtFields[1] = jTextField1;
		txtFields[2] = jTextField2;
		txtFields[3] = jTextField3;
		txtFields[4] = jTextField4;
		txtFields[5] = jTextField5;
		txtFields[6] = jTextField6;
		txtFields[7] = jTextField7;
		txtFields[8] = jTextField8;
		txtFields[9] = jTextField9;
	}

	/**
	 * This method initializes this
	 * 
	 * @return void
	 */
	private void initialize()
	{
		this.setSize(1000, 739);
		this.setMinimumSize(new java.awt.Dimension(1000, 739));
		this.setPreferredSize(new java.awt.Dimension(1000, 739));
		this.setMaximumSize(new java.awt.Dimension(1024, 768));
		this.setResizable(false);
		this.setDefaultCloseOperation(javax.swing.JFrame.EXIT_ON_CLOSE);
		this.setContentPane(getJContentPane());
		this.setTitle("Κατανομή αρχείων");
	}

	/**
	 * This method initializes jContentPane
	 * 
	 * @return javax.swing.JPanel
	 */
	private JPanel getJContentPane()
	{
		if (jContentPane == null)
		{
			jLabel10 = new JLabel();
			jLabel10.setBounds(new java.awt.Rectangle(15, 675, 376, 16));
			jLabel10
					.setText("* Στα παραπάνω πεδία εισάγετε έναν ακέραιο μεγαλύτερο του 10");
			jLabel9 = new JLabel();
			jLabel9.setBounds(new java.awt.Rectangle(855, 330, 61, 16));
			jLabel9
					.setHorizontalTextPosition(javax.swing.SwingConstants.TRAILING);
			jLabel9.setText("Ομότιμος 9");
			jLabel9.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			jLabel8 = new JLabel();
			jLabel8.setBounds(new java.awt.Rectangle(660, 330, 61, 16));
			jLabel8
					.setHorizontalTextPosition(javax.swing.SwingConstants.TRAILING);
			jLabel8.setText("Ομότιμος 8");
			jLabel8.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			jLabel7 = new JLabel();
			jLabel7.setBounds(new java.awt.Rectangle(465, 330, 61, 16));
			jLabel7
					.setHorizontalTextPosition(javax.swing.SwingConstants.TRAILING);
			jLabel7.setText("Ομότιμος 7");
			jLabel7.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			jLabel6 = new JLabel();
			jLabel6.setBounds(new java.awt.Rectangle(270, 330, 61, 16));
			jLabel6
					.setHorizontalTextPosition(javax.swing.SwingConstants.TRAILING);
			jLabel6.setText("Ομότιμος 6");
			jLabel6.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			jLabel5 = new JLabel();
			jLabel5.setBounds(new java.awt.Rectangle(75, 330, 61, 16));
			jLabel5
					.setHorizontalTextPosition(javax.swing.SwingConstants.TRAILING);
			jLabel5.setText("Ομότιμος 5");
			jLabel5.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			jLabel4 = new JLabel();
			jLabel4.setBounds(new java.awt.Rectangle(855, 15, 61, 16));
			jLabel4
					.setHorizontalTextPosition(javax.swing.SwingConstants.TRAILING);
			jLabel4.setText("Ομότιμος 4");
			jLabel4.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			jLabel3 = new JLabel();
			jLabel3.setBounds(new java.awt.Rectangle(660, 15, 61, 16));
			jLabel3
					.setHorizontalTextPosition(javax.swing.SwingConstants.TRAILING);
			jLabel3.setText("Ομότιμος 3");
			jLabel3.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			jLabel2 = new JLabel();
			jLabel2.setBounds(new java.awt.Rectangle(465, 15, 61, 16));
			jLabel2
					.setHorizontalTextPosition(javax.swing.SwingConstants.TRAILING);
			jLabel2.setText("Ομότιμος 2");
			jLabel2.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			jLabel1 = new JLabel();
			jLabel1.setBounds(new java.awt.Rectangle(270, 15, 61, 16));
			jLabel1
					.setHorizontalTextPosition(javax.swing.SwingConstants.TRAILING);
			jLabel1.setText("Ομότιμος 1");
			jLabel1.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			jLabel = new JLabel();
			jLabel.setBounds(new java.awt.Rectangle(75, 15, 61, 16));
			jLabel
					.setHorizontalTextPosition(javax.swing.SwingConstants.TRAILING);
			jLabel.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			jLabel.setText("Ομότιμος 0");
			jContentPane = new JPanel();
			jContentPane.setLayout(null);
			jContentPane.setFont(new java.awt.Font("Dialog",
					java.awt.Font.BOLD, 12));
			jContentPane.add(getJScrollPane(), null);
			jContentPane.add(jLabel, null);
			jContentPane.add(getJScrollPane1(), null);
			jContentPane.add(jLabel1, null);
			jContentPane.add(getJScrollPane2(), null);
			jContentPane.add(jLabel2, null);
			jContentPane.add(getJScrollPane3(), null);
			jContentPane.add(jLabel3, null);
			jContentPane.add(getJScrollPane4(), null);
			jContentPane.add(jLabel4, null);
			jContentPane.add(getJTextField(), null);
			jContentPane.add(getJTextField1(), null);
			jContentPane.add(getJTextField2(), null);
			jContentPane.add(getJTextField3(), null);
			jContentPane.add(getJTextField4(), null);
			jContentPane.add(getJScrollPane5(), null);
			jContentPane.add(getJTextField5(), null);
			jContentPane.add(jLabel5, null);
			jContentPane.add(getJScrollPane6(), null);
			jContentPane.add(getJScrollPane7(), null);
			jContentPane.add(getJScrollPane8(), null);
			jContentPane.add(getJScrollPane9(), null);
			jContentPane.add(jLabel6, null);
			jContentPane.add(jLabel7, null);
			jContentPane.add(jLabel8, null);
			jContentPane.add(jLabel9, null);
			jContentPane.add(getJTextField6(), null);
			jContentPane.add(getJTextField7(), null);
			jContentPane.add(getJTextField8(), null);
			jContentPane.add(getJTextField9(), null);
			jContentPane.add(getJButton(), null);
			jContentPane.add(jLabel10, null);
		}
		return jContentPane;
	}

	/**
	 * This method initializes jScrollPane
	 * 
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getJScrollPane()
	{
		if (jScrollPane == null)
		{
			jScrollPane = new JScrollPane();
			jScrollPane.setBounds(new java.awt.Rectangle(15, 45, 181, 226));
			jScrollPane.setViewportView(getJTextArea());
		}
		return jScrollPane;
	}

	/**
	 * This method initializes jTextArea
	 * 
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getJTextArea()
	{
		if (jTextArea == null)
		{
			jTextArea = new JTextArea();
			jTextArea.setEditable(false);
			jTextArea.setWrapStyleWord(true);
			jTextArea.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			jTextArea.setLineWrap(true);
			jTextArea.setText("");
		}
		return jTextArea;
	}

	/**
	 * This method initializes jScrollPane1
	 * 
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getJScrollPane1()
	{
		if (jScrollPane1 == null)
		{
			jScrollPane1 = new JScrollPane();
			jScrollPane1.setBounds(new java.awt.Rectangle(210, 45, 181, 226));
			jScrollPane1.setViewportView(getJTextArea1());
		}
		return jScrollPane1;
	}

	/**
	 * This method initializes jTextArea1
	 * 
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getJTextArea1()
	{
		if (jTextArea1 == null)
		{
			jTextArea1 = new JTextArea();
			jTextArea1.setEditable(false);
			jTextArea1.setWrapStyleWord(true);
			jTextArea1.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			jTextArea1.setLineWrap(true);
			jTextArea1.setText("");
		}
		return jTextArea1;
	}

	/**
	 * This method initializes jScrollPane2
	 * 
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getJScrollPane2()
	{
		if (jScrollPane2 == null)
		{
			jScrollPane2 = new JScrollPane();
			jScrollPane2.setBounds(new java.awt.Rectangle(405, 45, 181, 226));
			jScrollPane2.setViewportView(getJTextArea2());
		}
		return jScrollPane2;
	}

	/**
	 * This method initializes jTextArea2
	 * 
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getJTextArea2()
	{
		if (jTextArea2 == null)
		{
			jTextArea2 = new JTextArea();
			jTextArea2.setEditable(false);
			jTextArea2.setWrapStyleWord(true);
			jTextArea2.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			jTextArea2.setLineWrap(true);
			jTextArea2.setText("");
		}
		return jTextArea2;
	}

	/**
	 * This method initializes jScrollPane3
	 * 
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getJScrollPane3()
	{
		if (jScrollPane3 == null)
		{
			jScrollPane3 = new JScrollPane();
			jScrollPane3.setBounds(new java.awt.Rectangle(600, 45, 181, 226));
			jScrollPane3.setViewportView(getJTextArea3());
		}
		return jScrollPane3;
	}

	/**
	 * This method initializes jTextArea3
	 * 
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getJTextArea3()
	{
		if (jTextArea3 == null)
		{
			jTextArea3 = new JTextArea();
			jTextArea3.setEditable(false);
			jTextArea3.setWrapStyleWord(true);
			jTextArea3.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			jTextArea3.setLineWrap(true);
			jTextArea3.setText("");
		}
		return jTextArea3;
	}

	/**
	 * This method initializes jScrollPane4
	 * 
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getJScrollPane4()
	{
		if (jScrollPane4 == null)
		{
			jScrollPane4 = new JScrollPane();
			jScrollPane4.setBounds(new java.awt.Rectangle(795, 45, 181, 226));
			jScrollPane4.setViewportView(getJTextArea4());
		}
		return jScrollPane4;
	}

	/**
	 * This method initializes jTextArea4
	 * 
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getJTextArea4()
	{
		if (jTextArea4 == null)
		{
			jTextArea4 = new JTextArea();
			jTextArea4.setEditable(false);
			jTextArea4.setWrapStyleWord(true);
			jTextArea4.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			jTextArea4.setLineWrap(true);
			jTextArea4.setText("");
		}
		return jTextArea4;
	}

	/**
	 * This method initializes jTextField
	 * 
	 * @return javax.swing.JTextField
	 */
	private JTextField getJTextField()
	{
		if (jTextField == null)
		{
			jTextField = new JTextField();
			jTextField.setBounds(new java.awt.Rectangle(45, 285, 121, 31));
			jTextField.setFont(new java.awt.Font("Dialog", java.awt.Font.PLAIN,
					12));
		}
		return jTextField;
	}

	/**
	 * This method initializes jTextField1
	 * 
	 * @return javax.swing.JTextField
	 */
	private JTextField getJTextField1()
	{
		if (jTextField1 == null)
		{
			jTextField1 = new JTextField();
			jTextField1.setBounds(new java.awt.Rectangle(240, 285, 121, 31));
			jTextField1.setFont(new java.awt.Font("Dialog",
					java.awt.Font.PLAIN, 12));
		}
		return jTextField1;
	}

	/**
	 * This method initializes jTextField2
	 * 
	 * @return javax.swing.JTextField
	 */
	private JTextField getJTextField2()
	{
		if (jTextField2 == null)
		{
			jTextField2 = new JTextField();
			jTextField2.setBounds(new java.awt.Rectangle(435, 285, 121, 31));
			jTextField2.setFont(new java.awt.Font("Dialog",
					java.awt.Font.PLAIN, 12));
		}
		return jTextField2;
	}

	/**
	 * This method initializes jTextField3
	 * 
	 * @return javax.swing.JTextField
	 */
	private JTextField getJTextField3()
	{
		if (jTextField3 == null)
		{
			jTextField3 = new JTextField();
			jTextField3.setBounds(new java.awt.Rectangle(630, 285, 121, 31));
			jTextField3.setFont(new java.awt.Font("Dialog",
					java.awt.Font.PLAIN, 12));
		}
		return jTextField3;
	}

	/**
	 * This method initializes jTextField4
	 * 
	 * @return javax.swing.JTextField
	 */
	private JTextField getJTextField4()
	{
		if (jTextField4 == null)
		{
			jTextField4 = new JTextField();
			jTextField4.setBounds(new java.awt.Rectangle(825, 285, 121, 31));
			jTextField4.setFont(new java.awt.Font("Dialog",
					java.awt.Font.PLAIN, 12));
		}
		return jTextField4;
	}

	/**
	 * This method initializes jScrollPane5
	 * 
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getJScrollPane5()
	{
		if (jScrollPane5 == null)
		{
			jScrollPane5 = new JScrollPane();
			jScrollPane5.setLocation(new java.awt.Point(15, 360));
			jScrollPane5.setSize(new java.awt.Dimension(181, 226));
			jScrollPane5.setViewportView(getJTextArea5());
		}
		return jScrollPane5;
	}

	/**
	 * This method initializes jTextArea5
	 * 
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getJTextArea5()
	{
		if (jTextArea5 == null)
		{
			jTextArea5 = new JTextArea();
			jTextArea5.setEditable(false);
			jTextArea5.setWrapStyleWord(true);
			jTextArea5.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			jTextArea5.setLineWrap(true);
			jTextArea5.setText("");
		}
		return jTextArea5;
	}

	/**
	 * This method initializes jTextField5
	 * 
	 * @return javax.swing.JTextField
	 */
	private JTextField getJTextField5()
	{
		if (jTextField5 == null)
		{
			jTextField5 = new JTextField();
			jTextField5.setBounds(new java.awt.Rectangle(45, 600, 121, 31));
			jTextField5.setFont(new java.awt.Font("Dialog",
					java.awt.Font.PLAIN, 12));
		}
		return jTextField5;
	}

	/**
	 * This method initializes jScrollPane6
	 * 
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getJScrollPane6()
	{
		if (jScrollPane6 == null)
		{
			jScrollPane6 = new JScrollPane();
			jScrollPane6.setBounds(new java.awt.Rectangle(210, 360, 181, 226));
			jScrollPane6.setViewportView(getJTextArea6());
		}
		return jScrollPane6;
	}

	/**
	 * This method initializes jTextArea6
	 * 
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getJTextArea6()
	{
		if (jTextArea6 == null)
		{
			jTextArea6 = new JTextArea();
			jTextArea6.setEditable(false);
			jTextArea6.setWrapStyleWord(true);
			jTextArea6.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			jTextArea6.setLineWrap(true);
			jTextArea6.setText("");
		}
		return jTextArea6;
	}

	/**
	 * This method initializes jScrollPane7
	 * 
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getJScrollPane7()
	{
		if (jScrollPane7 == null)
		{
			jScrollPane7 = new JScrollPane();
			jScrollPane7.setBounds(new java.awt.Rectangle(405, 360, 181, 226));
			jScrollPane7.setViewportView(getJTextArea7());
		}
		return jScrollPane7;
	}

	/**
	 * This method initializes jTextArea7
	 * 
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getJTextArea7()
	{
		if (jTextArea7 == null)
		{
			jTextArea7 = new JTextArea();
			jTextArea7.setEditable(false);
			jTextArea7.setWrapStyleWord(true);
			jTextArea7.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			jTextArea7.setLineWrap(true);
			jTextArea7.setText("");
		}
		return jTextArea7;
	}

	/**
	 * This method initializes jScrollPane8
	 * 
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getJScrollPane8()
	{
		if (jScrollPane8 == null)
		{
			jScrollPane8 = new JScrollPane();
			jScrollPane8.setBounds(new java.awt.Rectangle(600, 360, 181, 226));
			jScrollPane8.setViewportView(getJTextArea8());
		}
		return jScrollPane8;
	}

	/**
	 * This method initializes jTextArea8
	 * 
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getJTextArea8()
	{
		if (jTextArea8 == null)
		{
			jTextArea8 = new JTextArea();
			jTextArea8.setEditable(false);
			jTextArea8.setWrapStyleWord(true);
			jTextArea8.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			jTextArea8.setLineWrap(true);
			jTextArea8.setText("");
		}
		return jTextArea8;
	}

	/**
	 * This method initializes jScrollPane9
	 * 
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getJScrollPane9()
	{
		if (jScrollPane9 == null)
		{
			jScrollPane9 = new JScrollPane();
			jScrollPane9.setBounds(new java.awt.Rectangle(795, 360, 181, 226));
			jScrollPane9.setViewportView(getJTextArea9());
		}
		return jScrollPane9;
	}

	/**
	 * This method initializes jTextArea9
	 * 
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getJTextArea9()
	{
		if (jTextArea9 == null)
		{
			jTextArea9 = new JTextArea();
			jTextArea9.setEditable(false);
			jTextArea9.setWrapStyleWord(true);
			jTextArea9.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			jTextArea9.setLineWrap(true);
			jTextArea9.setText("");
		}
		return jTextArea9;
	}

	/**
	 * This method initializes jTextField6
	 * 
	 * @return javax.swing.JTextField
	 */
	private JTextField getJTextField6()
	{
		if (jTextField6 == null)
		{
			jTextField6 = new JTextField();
			jTextField6.setBounds(new java.awt.Rectangle(240, 600, 121, 31));
			jTextField6.setFont(new java.awt.Font("Dialog",
					java.awt.Font.PLAIN, 12));
			jTextField6.setText("");
		}
		return jTextField6;
	}

	/**
	 * This method initializes jTextField7
	 * 
	 * @return javax.swing.JTextField
	 */
	private JTextField getJTextField7()
	{
		if (jTextField7 == null)
		{
			jTextField7 = new JTextField();
			jTextField7.setBounds(new java.awt.Rectangle(435, 600, 121, 31));
			jTextField7.setFont(new java.awt.Font("Dialog",
					java.awt.Font.PLAIN, 12));
		}
		return jTextField7;
	}

	/**
	 * This method initializes jTextField8
	 * 
	 * @return javax.swing.JTextField
	 */
	private JTextField getJTextField8()
	{
		if (jTextField8 == null)
		{
			jTextField8 = new JTextField();
			jTextField8.setBounds(new java.awt.Rectangle(630, 600, 121, 31));
			jTextField8.setFont(new java.awt.Font("Dialog",
					java.awt.Font.PLAIN, 12));
		}
		return jTextField8;
	}

	/**
	 * This method initializes jTextField9
	 * 
	 * @return javax.swing.JTextField
	 */
	private JTextField getJTextField9()
	{
		if (jTextField9 == null)
		{
			jTextField9 = new JTextField();
			jTextField9.setBounds(new java.awt.Rectangle(825, 600, 121, 31));
			jTextField9.setFont(new java.awt.Font("Dialog",
					java.awt.Font.PLAIN, 12));
		}
		return jTextField9;
	}

	/**
	 * This method initializes jButton
	 * 
	 * @return javax.swing.JButton
	 */
	private JButton getJButton()
	{
		if (jButton == null)
		{
			jButton = new JButton();
			jButton.setBounds(new java.awt.Rectangle(810, 660, 151, 31));
			jButton.setText("ΑΡΧΙΚΟΠΟΙΗΣΗ");
			jButton.addActionListener(new java.awt.event.ActionListener()
			{
				public void actionPerformed(java.awt.event.ActionEvent e)
				{
					checkValidation();
				}
			});
		}
		return jButton;
	}

	public void checkValidation()
	{
		int[] numOfFilesArray = new int[txtFields.length];
		int totalNumOfFiles = parseToIntegers(numOfFilesArray);
		if (totalNumOfFiles > 0)
		{
			jButton.setEnabled(false);

			for (int i = 0; i < txtFields.length; i++)
			{
				txtFields[i].setEnabled(false);
			}

			Main.simulator.initializationIfoCollected(numOfFilesArray,
					totalNumOfFiles);
		}
	}

	private int parseToIntegers(int[] numOfFilesArray)
	{
		int totalNumOfFiles = 0;
		for (int i = 0; i < txtFields.length; i++)
		{
			String text = txtFields[i].getText();
			try
			{
				numOfFilesArray[i] = Integer.parseInt(text);
				if (numOfFilesArray[i] < MIN_NUM_OF_FILES)
				{
					txtFields[i].setText("Λάθος!");
					return 0;
				}
				totalNumOfFiles += numOfFilesArray[i];
			}
			catch (NumberFormatException e)
			{
				txtFields[i].setText("Λάθος!");
				return 0;
			}
		}
		return totalNumOfFiles;
	}

	public void writeToTxtArea(int i, String text)
	{
		this.txtAreas[i].append(text + "\n");
	}
} // @jve:decl-index=0:visual-constraint="10,10"
