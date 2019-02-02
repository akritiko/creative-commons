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
	private JScrollPane scpPeer1 = null;
	private JTextArea txtaPeer1 = null;
	private JScrollPane scpPeer2 = null;
	private JTextArea txtaPeer2 = null;
	private JScrollPane scpPeer3 = null;
	private JTextArea txtaPeer3 = null;
	private JLabel lblPeer1 = null;
	private JLabel lblPeer2 = null;
	private JLabel lblPeer3 = null;
	private JTextField txtfPeer1 = null;
	private JTextField txtfPeer2 = null;
	private JTextField txtfPeer3 = null;
	private JButton btnInitialize = null;

	private JTextArea[] txtArea;
	private JTextField[] txtField;
	private boolean[] resetTextField;
	private final int MIN_NUM_OF_FILES = 10;

	/**
	 * This is the default constructor
	 */
	public InitialWindow()
	{
		super();
		initialize();

		txtArea = new JTextArea[3];
		txtArea[0] = txtaPeer1;
		txtArea[1] = txtaPeer2;
		txtArea[2] = txtaPeer3;

		txtField = new JTextField[3];
		txtField[0] = txtfPeer1;
		txtField[1] = txtfPeer2;
		txtField[2] = txtfPeer3;

		resetTextField = new boolean[3];
		resetTextField[0] = true;
		resetTextField[1] = true;
		resetTextField[2] = true;
	}

	/**
	 * This method initializes this
	 * 
	 * @return void
	 */
	private void initialize()
	{
		this.setSize(787, 496);
		this.setResizable(false);
		this.setDefaultCloseOperation(javax.swing.JFrame.EXIT_ON_CLOSE);
		this.setContentPane(getJContentPane());
		this.setTitle("(880-914-1236)");
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
			lblPeer3 = new JLabel();
			lblPeer3.setBounds(new java.awt.Rectangle(615, 15, 46, 16));
			lblPeer3
					.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
			lblPeer3.setText("Peer 3");
			lblPeer3.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			lblPeer2 = new JLabel();
			lblPeer2.setBounds(new java.awt.Rectangle(360, 15, 46, 16));
			lblPeer2
					.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
			lblPeer2.setText("Peer 2");
			lblPeer2.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			lblPeer1 = new JLabel();
			lblPeer1.setBounds(new java.awt.Rectangle(105, 15, 46, 16));
			lblPeer1.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			lblPeer1
					.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
			lblPeer1.setText("Peer 1");
			jContentPane = new JPanel();
			jContentPane.setLayout(null);
			jContentPane.add(getScpPeer1(), null);
			jContentPane.add(getScpPeer2(), null);
			jContentPane.add(getScpPeer3(), null);
			jContentPane.add(lblPeer1, null);
			jContentPane.add(lblPeer2, null);
			jContentPane.add(lblPeer3, null);
			jContentPane.add(getTxtfPeer1(), null);
			jContentPane.add(getTxtfPeer2(), null);
			jContentPane.add(getTxtfPeer3(), null);
			jContentPane.add(getBtnInitialize(), null);
		}
		return jContentPane;
	}

	/**
	 * This method initializes scpPeer1
	 * 
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getScpPeer1()
	{
		if (scpPeer1 == null)
		{
			scpPeer1 = new JScrollPane();
			scpPeer1.setBounds(new java.awt.Rectangle(14, 30, 242, 346));
			scpPeer1.setViewportView(getTxtaPeer1());
		}
		return scpPeer1;
	}

	/**
	 * This method initializes txtaPeer1
	 * 
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getTxtaPeer1()
	{
		if (txtaPeer1 == null)
		{
			txtaPeer1 = new JTextArea();
			txtaPeer1.setLineWrap(true);
			txtaPeer1.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			txtaPeer1.setEditable(false);
		}
		return txtaPeer1;
	}

	/**
	 * This method initializes jScrollPane
	 * 
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getScpPeer2()
	{
		if (scpPeer2 == null)
		{
			scpPeer2 = new JScrollPane();
			scpPeer2.setBounds(new java.awt.Rectangle(270, 30, 241, 346));
			scpPeer2.setViewportView(getTxtaPeer2());
		}
		return scpPeer2;
	}

	/**
	 * This method initializes jTextArea
	 * 
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getTxtaPeer2()
	{
		if (txtaPeer2 == null)
		{
			txtaPeer2 = new JTextArea();
			txtaPeer2.setLineWrap(true);
			txtaPeer2.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			txtaPeer2.setEditable(false);
		}
		return txtaPeer2;
	}

	/**
	 * This method initializes jScrollPane
	 * 
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getScpPeer3()
	{
		if (scpPeer3 == null)
		{
			scpPeer3 = new JScrollPane();
			scpPeer3.setBounds(new java.awt.Rectangle(525, 30, 241, 346));
			scpPeer3.setViewportView(getTxtaPeer3());
		}
		return scpPeer3;
	}

	/**
	 * This method initializes jTextArea
	 * 
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getTxtaPeer3()
	{
		if (txtaPeer3 == null)
		{
			txtaPeer3 = new JTextArea();
			txtaPeer3.setLineWrap(true);
			txtaPeer3.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			txtaPeer3.setEditable(false);
		}
		return txtaPeer3;
	}

	/**
	 * This method initializes txtfPeer1
	 * 
	 * @return javax.swing.JTextField
	 */
	private JTextField getTxtfPeer1()
	{
		if (txtfPeer1 == null)
		{
			txtfPeer1 = new JTextField();
			txtfPeer1.setBounds(new java.awt.Rectangle(15, 390, 241, 24));
			txtfPeer1.setText("Δώστε το πλήθος των αρχείων του 1ου");
			txtfPeer1.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			txtfPeer1.addMouseListener(new java.awt.event.MouseAdapter()
			{
				public void mouseClicked(java.awt.event.MouseEvent e)
				{
					if (resetTextField[0])
					{
						txtfPeer1.setText("");
						resetTextField[0] = false;
					}
				}
			});
		}
		return txtfPeer1;
	}

	/**
	 * This method initializes jTextField
	 * 
	 * @return javax.swing.JTextField
	 */
	private JTextField getTxtfPeer2()
	{
		if (txtfPeer2 == null)
		{
			txtfPeer2 = new JTextField();
			txtfPeer2.setBounds(new java.awt.Rectangle(270, 389, 241, 23));
			txtfPeer2.setText("Δώστε το πλήθος των αρχείων του 2ου");
			txtfPeer2.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			txtfPeer2.addMouseListener(new java.awt.event.MouseAdapter()
			{
				public void mouseClicked(java.awt.event.MouseEvent e)
				{
					if (resetTextField[1])
					{
						txtfPeer2.setText("");
						resetTextField[1] = false;
					}
				}
			});
		}
		return txtfPeer2;
	}

	/**
	 * This method initializes jTextField1
	 * 
	 * @return javax.swing.JTextField
	 */
	private JTextField getTxtfPeer3()
	{
		if (txtfPeer3 == null)
		{
			txtfPeer3 = new JTextField();
			txtfPeer3.setBounds(new java.awt.Rectangle(525, 389, 241, 23));
			txtfPeer3.setText("Δώστε το πλήθος των αρχείων του 3ου");
			txtfPeer3.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			txtfPeer3.addMouseListener(new java.awt.event.MouseAdapter()
			{
				public void mouseClicked(java.awt.event.MouseEvent e)
				{
					if (resetTextField[2])
					{
						txtfPeer3.setText("");
						resetTextField[2] = false;
					}
				}
			});
		}
		return txtfPeer3;
	}

	/**
	 * This method initializes btnInitialize
	 * 
	 * @return javax.swing.JButton
	 */
	private JButton getBtnInitialize()
	{
		if (btnInitialize == null)
		{
			btnInitialize = new JButton();
			btnInitialize.setBounds(new java.awt.Rectangle(615, 420, 151, 31));
			btnInitialize.setText("ΑΡΧΙΚΟΠΟΙΗΣΗ");
			btnInitialize.addActionListener(new java.awt.event.ActionListener()
			{
				public void actionPerformed(java.awt.event.ActionEvent e)
				{
					int[] nums = new int[txtField.length];
					if (parseToInt(nums))
					{
						btnInitialize.setEnabled(false);
						Main.initializeSystem(nums);
						Main.fileGenerator.randomlySpreadFilesToPeers();
						Main.interact.setVisible(true);
						Main.simulator.startSimulation();
					}
				}
			});
		}
		return btnInitialize;
	}

	private boolean parseToInt(int[] nums)
	{
		boolean correctRegularExpression = true;
		for (int i = 0; i < txtField.length; i++)
		{
			String text = txtField[i].getText();
			// Κανονική έκφραση που εξετάζει εάν το κείμενο που δόθηκε είναι
			// ακέραιος αριθμός ή όχι
			if (text.matches("\\d*"))
			{
				try
				{
					nums[i] = Integer.parseInt(text);
					if (nums[i] < MIN_NUM_OF_FILES)
					{
						txtField[i].setText("Εισάγετε έναν ακέραιο >= "
								+ MIN_NUM_OF_FILES);
						resetTextField[i] = true;
						correctRegularExpression = false;
					}
					else
						txtField[i].setEnabled(false);
				}
				catch (NumberFormatException e)
				{
					txtField[i].setText("Εισάγετε έναν ακέραιο >= "
							+ MIN_NUM_OF_FILES);
					resetTextField[i] = true;
				}
			}
			else
			{
				txtField[i].setText("Εισάγετε έναν ακέραιο");
				correctRegularExpression = false;
				resetTextField[i] = true;
			}
		}
		return correctRegularExpression;
	}

	public void writeToTxtArea(final int index, final String fileName)
	{
		txtArea[index].append(fileName + "\n");
	}
} // @jve:decl-index=0:visual-constraint="-114,10"
