import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.JTextField;
import javax.swing.JTextPane;

public class BasicWindow extends JFrame
{
	private JPanel jContentPane = null;
	private JScrollPane scpPeer1 = null;
	private JTextArea txtaPeer1 = null;
	private JLabel lblUserCommand = null;
	private JTextField txtfUserCommand = null;
	private JScrollPane scpPeer2 = null;
	private JTextArea txtaPeer2 = null;
	private JScrollPane scpPeer3 = null;
	private JTextArea txtaPeer3 = null;
	private JLabel lblPeer1 = null;
	private JLabel lblPeer2 = null;
	private JLabel lblPeer3 = null;
	private JTextPane txtpInfo = null;

	private boolean resetTextField;
	private JTextArea[] txtArea;
	private JButton btnLookup = null;

	/**
	 * This is the default constructor
	 */
	public BasicWindow()
	{
		super();
		initialize();

		txtArea = new JTextArea[3];
		txtArea[0] = txtaPeer1;
		txtArea[1] = txtaPeer2;
		txtArea[2] = txtaPeer3;

		resetTextField = true;
	}

	/**
	 * This method initializes this
	 * 
	 * @return void
	 */
	private void initialize()
	{
		this.setSize(1022, 409);
		this.setLocation(new java.awt.Point(0, 300));
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
			lblPeer3.setBounds(new java.awt.Rectangle(855, 15, 46, 16));
			lblPeer3
					.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
			lblPeer3.setText("Peer 3");
			lblPeer3.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			lblPeer2 = new JLabel();
			lblPeer2.setBounds(new java.awt.Rectangle(585, 15, 47, 16));
			lblPeer2
					.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
			lblPeer2.setText("Peer 2");
			lblPeer2.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			lblPeer1 = new JLabel();
			lblPeer1.setBounds(new java.awt.Rectangle(315, 15, 46, 16));
			lblPeer1.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			lblPeer1
					.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
			lblPeer1.setText("Peer 1");
			lblUserCommand = new JLabel();
			lblUserCommand.setBounds(new java.awt.Rectangle(15, 15, 196, 16));
			lblUserCommand
					.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
			lblUserCommand.setText("Δώστε τη διαδρομή για το αρχείο");
			lblUserCommand.setFont(new java.awt.Font("Dialog",
					java.awt.Font.BOLD, 12));
			lblUserCommand
					.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
			jContentPane = new JPanel();
			jContentPane.setLayout(null);
			jContentPane.add(getScpPeer1(), null);
			jContentPane.add(lblUserCommand, null);
			jContentPane.add(getTxtfUserCommand(), null);
			jContentPane.add(getScpPeer3(), null);
			jContentPane.add(getScpPeer2(), null);
			jContentPane.add(lblPeer1, null);
			jContentPane.add(lblPeer2, null);
			jContentPane.add(lblPeer3, null);
			jContentPane.add(getTxtpInfo(), null);
			jContentPane.add(getBtnLookup(), null);
		}
		return jContentPane;
	}

	/**
	 * This method initializes jScrollPane
	 * 
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getScpPeer1()
	{
		if (scpPeer1 == null)
		{
			scpPeer1 = new JScrollPane();
			scpPeer1.setBounds(new java.awt.Rectangle(210, 30, 256, 331));
			scpPeer1.setViewportView(getTxtaPeer1());
		}
		return scpPeer1;
	}

	/**
	 * This method initializes jTextArea
	 * 
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getTxtaPeer1()
	{
		if (txtaPeer1 == null)
		{
			txtaPeer1 = new JTextArea();
			txtaPeer1.setEditable(false);
			txtaPeer1.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			txtaPeer1.setLineWrap(true);
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
			scpPeer2.setBounds(new java.awt.Rectangle(480, 30, 256, 331));
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
			txtaPeer2.setEditable(false);
			txtaPeer2.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			txtaPeer2.setLineWrap(true);
		}
		return txtaPeer2;
	}

	/**
	 * This method initializes jScrollPane1
	 * 
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getScpPeer3()
	{
		if (scpPeer3 == null)
		{
			scpPeer3 = new JScrollPane();
			scpPeer3.setBounds(new java.awt.Rectangle(750, 30, 256, 331));
			scpPeer3.setViewportView(getTxtaPeer3());
		}
		return scpPeer3;
	}

	/**
	 * This method initializes jTextArea1
	 * 
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getTxtaPeer3()
	{
		if (txtaPeer3 == null)
		{
			txtaPeer3 = new JTextArea();
			txtaPeer3.setEditable(false);
			txtaPeer3.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD,
					12));
			txtaPeer3.setLineWrap(true);
		}
		return txtaPeer3;
	}

	/**
	 * This method initializes txtfUserCommand
	 * 
	 * @return javax.swing.JTextField
	 */
	private JTextField getTxtfUserCommand()
	{
		if (txtfUserCommand == null)
		{
			txtfUserCommand = new JTextField();
			txtfUserCommand.setBounds(new java.awt.Rectangle(15, 45, 181, 27));
			txtfUserCommand.setFont(new java.awt.Font("Dialog",
					java.awt.Font.BOLD, 14));
			txtfUserCommand.addMouseListener(new java.awt.event.MouseAdapter()
			{
				public void mouseClicked(java.awt.event.MouseEvent e)
				{
					if (resetTextField)
					{
						txtfUserCommand.setText("");
						resetTextField = false;
					}
				}
			});
		}
		return txtfUserCommand;
	}

	public void writeToTxtField(final String text)
	{
		txtfUserCommand.setText(text);
		resetTextField = true;
	}

	/**
	 * This method initializes btnLookup
	 * 
	 * @return javax.swing.JButton
	 */
	private JButton getBtnLookup()
	{
		if (btnLookup == null)
		{
			btnLookup = new JButton();
			btnLookup.setBounds(new java.awt.Rectangle(90, 90, 106, 31));
			btnLookup.setSelected(true);
			btnLookup.setText("ΑΝΑΖΗΤΗΣΗ");
			btnLookup.addActionListener(new java.awt.event.ActionListener()
			{
				public void actionPerformed(java.awt.event.ActionEvent e)
				{
					String userCommand = txtfUserCommand.getText();
					userCommand = userCommand.toLowerCase();
					if (userCommand.matches("peer[1-9]\\d*/[^\\p{Space}/]+"))
					{
						String[] peerAndFileName = new String[2];
						peerAndFileName = userCommand.split("/");
						String peerId = peerAndFileName[0].substring(4,
								peerAndFileName[0].length());
						int numericPeerId = Integer.parseInt(peerId);
						numericPeerId--;
						Main.simulator.userRequest(numericPeerId + "",
								peerAndFileName[1]);
					}
					else
					{
						txtfUserCommand.setText("Λανθασμένη εντολή");
						resetTextField = true;
					}
				}
			});
		}
		return btnLookup;
	}

	/**
	 * This method initializes txtpInfo
	 * 
	 * @return javax.swing.JTextPane
	 */
	private JTextPane getTxtpInfo()
	{
		if (txtpInfo == null)
		{
			txtpInfo = new JTextPane();
			txtpInfo.setBounds(new java.awt.Rectangle(15, 285, 181, 76));
			txtpInfo.setText("Η παραπάνω διαδρομή πρέπει να είναι της μορφής: "
					+ "peer<αριθμός> / <όνομα αρχείου>");
			txtpInfo.setFont(new java.awt.Font("Dialog", java.awt.Font.BOLD
					| java.awt.Font.ITALIC, 12));
		}
		return txtpInfo;
	}

	public void writeToTxtArea(final int index, final String text)
	{
		txtArea[index].append(text + "\n");
	}
} // @jve:decl-index=0:visual-constraint="-287,10"
