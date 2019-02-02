import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.JTextField;
import javax.swing.SwingConstants;

public class BasicWindow extends JFrame
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
	private JScrollPane jScrollPane5 = null;
	private JTextArea jTextArea5 = null;
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
	private JButton jButton = null;

	private JTextArea[] txtAreas;
	private JTextField jTextField = null;
	private JLabel jLabel11 = null;
	private JButton jButton1 = null;
	private JButton jButton2 = null;

	/**
	 * This is the default constructor
	 */
	public BasicWindow()
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
		this.setTitle("Εποπτεία συστήματος");
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
			jLabel11 = new JLabel();
			jLabel11.setBounds(new java.awt.Rectangle(30, 630, 91, 16));
			jLabel11.setHorizontalTextPosition(SwingConstants.TRAILING);
			jLabel11.setText("Αίτημα χρήστη");
			jLabel11.setHorizontalAlignment(SwingConstants.CENTER);
			jLabel9 = new JLabel();
			jLabel9.setBounds(new java.awt.Rectangle(855, 315, 61, 16));
			jLabel9
					.setHorizontalTextPosition(javax.swing.SwingConstants.TRAILING);
			jLabel9.setText("Ομότιμος 9");
			jLabel9.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			jLabel8 = new JLabel();
			jLabel8.setBounds(new java.awt.Rectangle(660, 315, 61, 16));
			jLabel8
					.setHorizontalTextPosition(javax.swing.SwingConstants.TRAILING);
			jLabel8.setText("Ομότιμος 8");
			jLabel8.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			jLabel7 = new JLabel();
			jLabel7.setBounds(new java.awt.Rectangle(465, 315, 61, 16));
			jLabel7
					.setHorizontalTextPosition(javax.swing.SwingConstants.TRAILING);
			jLabel7.setText("Ομότιμος 7");
			jLabel7.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			jLabel6 = new JLabel();
			jLabel6.setBounds(new java.awt.Rectangle(270, 315, 61, 16));
			jLabel6
					.setHorizontalTextPosition(javax.swing.SwingConstants.TRAILING);
			jLabel6.setText("Ομότιμος 6");
			jLabel6.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			jLabel5 = new JLabel();
			jLabel5.setBounds(new java.awt.Rectangle(75, 315, 61, 16));
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
			jContentPane.add(getJScrollPane5(), null);
			jContentPane.add(jLabel5, null);
			jContentPane.add(getJScrollPane6(), null);
			jContentPane.add(getJScrollPane7(), null);
			jContentPane.add(getJScrollPane8(), null);
			jContentPane.add(getJScrollPane9(), null);
			jContentPane.add(jLabel6, null);
			jContentPane.add(jLabel7, null);
			jContentPane.add(jLabel8, null);
			jContentPane.add(jLabel9, null);
			jContentPane.add(getJButton(), null);
			jContentPane.add(jLabel11, null);
			jContentPane.add(getJTextField(), null);
			jContentPane.add(getJButton1(), null);
			jContentPane.add(getJButton2(), null);
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
			jScrollPane.setBounds(new java.awt.Rectangle(15, 45, 181, 256));
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
			jScrollPane1.setBounds(new java.awt.Rectangle(210, 45, 181, 256));
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
			jScrollPane2.setBounds(new java.awt.Rectangle(405, 45, 181, 256));
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
			jScrollPane3.setBounds(new java.awt.Rectangle(600, 45, 181, 256));
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
			jScrollPane4.setBounds(new java.awt.Rectangle(795, 45, 181, 256));
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
	 * This method initializes jScrollPane5
	 * 
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getJScrollPane5()
	{
		if (jScrollPane5 == null)
		{
			jScrollPane5 = new JScrollPane();
			jScrollPane5.setLocation(new java.awt.Point(15, 345));
			jScrollPane5.setSize(new java.awt.Dimension(181, 256));
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
	 * This method initializes jScrollPane6
	 * 
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getJScrollPane6()
	{
		if (jScrollPane6 == null)
		{
			jScrollPane6 = new JScrollPane();
			jScrollPane6.setBounds(new java.awt.Rectangle(210, 345, 181, 256));
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
			jScrollPane7.setBounds(new java.awt.Rectangle(405, 345, 181, 256));
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
			jScrollPane8.setBounds(new java.awt.Rectangle(600, 345, 181, 256));
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
			jScrollPane9.setBounds(new java.awt.Rectangle(795, 345, 181, 256));
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
	 * This method initializes jButton
	 * 
	 * @return javax.swing.JButton
	 */
	private JButton getJButton()
	{
		if (jButton == null)
		{
			jButton = new JButton();
			jButton.setBounds(new java.awt.Rectangle(270, 660, 166, 31));
			jButton.setEnabled(true);
			jButton.setText("ΑΝΑΖΗΤΗΣΗ");
			jButton.addActionListener(new java.awt.event.ActionListener()
			{
				public void actionPerformed(java.awt.event.ActionEvent e)
				{
					createUserRequest();
				}
			});
		}
		return jButton;
	}

	public void createUserRequest()
	{
		String userCommand = jTextField.getText();
		userCommand = userCommand.toLowerCase();
		if (userCommand.matches("peer\\d*\\s*/\\s*[^\\p{Space}/]+"))
		{
			String[] peerNameAndFileName = userCommand.split("/");

			String peerId = new String(peerNameAndFileName[0].substring(4,
					peerNameAndFileName[0].length()));
			peerId = peerId.trim();

			final int numericPeerId = Integer.parseInt(peerId);

			if (numericPeerId >= txtAreas.length)
			{
				jTextField.setText("Ο ομότιμος " + numericPeerId
						+ " δεν υπάρχει!");
				return;
			}

			String fileName = new String(peerNameAndFileName[1]);
			fileName = fileName.trim();

			Main.simulator.userHasRequest(numericPeerId, fileName);
		}
		else
		{
			jTextField.setText("Λανθασμένη σύνταξη εντολής!");
		}
	}

	public void writeToTxtArea(int i, String text)
	{
		this.txtAreas[i].append(text + "\n");
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
			jTextField.setBounds(new java.awt.Rectangle(15, 660, 241, 31));
			jTextField.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					14));
			jTextField.addActionListener(new java.awt.event.ActionListener()
			{
				public void actionPerformed(java.awt.event.ActionEvent e)
				{
					createUserRequest();
				}
			});
		}
		return jTextField;
	}

	/**
	 * This method initializes jButton1
	 * 
	 * @return javax.swing.JButton
	 */
	private JButton getJButton1()
	{
		if (jButton1 == null)
		{
			jButton1 = new JButton();
			jButton1.setBounds(new java.awt.Rectangle(450, 660, 166, 31));
			jButton1.setText("ΑΥΤΟΜΑΤΑ ΑΙΤΗΜΑΤΑ");
			jButton1.addActionListener(new java.awt.event.ActionListener()
			{
				public void actionPerformed(java.awt.event.ActionEvent e)
				{
					autoGenPressed();
				}
			});
		}
		return jButton1;
	}

	public void autoGenPressed()
	{
		if (jButton1.getText().equals("ΠΑΥΣΗ"))
		{
			Main.simulator.pause();
			jButton1.setText("ΣΥΝΕΧΕΙΑ");
		}
		else if (jButton1.getText().equals("ΣΥΝΕΧΕΙΑ"))
		{
			Main.simulator.resume();
			jButton1.setText("ΠΑΥΣΗ");
		}
		else
		{
			Main.simulator.start();
			jButton1.setText("ΠΑΥΣΗ");
		}
	}

	/**
	 * This method initializes jButton2
	 * 
	 * @return javax.swing.JButton
	 */
	private JButton getJButton2()
	{
		if (jButton2 == null)
		{
			jButton2 = new JButton();
			jButton2.setBounds(new java.awt.Rectangle(810, 645, 151, 46));
			jButton2.setBackground(new java.awt.Color(228, 10, 10));
			jButton2.setText("ΤΕΡΜΑΤΙΣΜΟΣ");
			jButton2.setVisible(false);
			jButton2.addActionListener(new java.awt.event.ActionListener()
			{
				public void actionPerformed(java.awt.event.ActionEvent e)
				{
					System.exit(0);
				}
			});
		}
		return jButton2;
	}

	public void normalTermination()
	{
		jButton2.setVisible(true);
	}
} // @jve:decl-index=0:visual-constraint="10,10"
