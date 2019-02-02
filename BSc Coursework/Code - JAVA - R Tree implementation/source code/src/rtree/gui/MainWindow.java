/**
 *
 */
package rtree.gui;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Point;
import java.awt.Rectangle;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

import javax.swing.BorderFactory;
import javax.swing.JButton;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JRadioButton;
import javax.swing.JScrollPane;
import javax.swing.JTabbedPane;
import javax.swing.JTextArea;
import javax.swing.JTextField;
import javax.swing.border.BevelBorder;
import javax.swing.border.TitledBorder;

import rtree.Main;

/**
 * @author Apostolos Kritikos
 *
 */
public class MainWindow extends JFrame {

	private static final long serialVersionUID = 1L;

	private JPanel jContentPane = null;

	private JTabbedPane tbpQueries = null;

	private JPanel pnlRangeQ = null;

	private JPanel pnlNeighboursQ = null;

	private JPanel pnlOptions = null;

	private JLabel lblPathText = null;

	private JTextField txtfPath = null;

	private JButton cmdOpenFile = null;

	private JFileChooser myFileChooser = new JFileChooser();

	private JPanel pnlSearch = null;

	private JLabel lblRange = null;

	private JRadioButton rdbArea = null;

	private JRadioButton rdbNeighbours = null;

	private JLabel lblParameters = null;

	private JLabel lblPoint = null;

	private JTextField txtfPoint = null;

	private JLabel lblJoker = null;

	private JTextField txtfJoker = null;

	private JButton cmdExit = null;

	private JScrollPane scpLog = null;

	private JTextArea txtaLog = null;

	private JPanel pnlLog = null;

	private JPanel pnlInitialPoints = null;

	private JTextArea txtaInitPoints = null;

	private JScrollPane scpInitPoints = null;

	private JScrollPane scpInfo = null;

	private JTextArea txtaInfo = null;

	private JButton cmdExecute = null;

	private int numberOfDimensions;

	private JScrollPane scpNeighbours = null;

	private JTextArea txtaNeighbours = null;

	private JScrollPane scpRange = null;

	private JTextArea txtaRange = null;

	/**
	 * This is the default constructor
	 */
	public MainWindow() {
		super();
		initialize();
	}

	/**
	 * This method initializes this
	 *
	 * @return void
	 */
	private void initialize() {
		this.setSize(748, 533);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setContentPane(getJContentPane());
		this.setTitle("Happy R Tree Friends");
	}

	/**
	 * This method initializes jContentPane
	 *
	 * @return javax.swing.JPanel
	 */
	private JPanel getJContentPane() {
		if (jContentPane == null) {
			jContentPane = new JPanel();
			jContentPane.setLayout(null);
			jContentPane.setBackground(new Color(168, 197, 203));
			jContentPane.add(getTbpQueries(), null);
			jContentPane.add(getPnlOptions(), null);
			jContentPane.add(getPnlSearch(), null);
			jContentPane.add(getPnlInitialPoints(), null);
		}
		return jContentPane;
	}

	/**
	 * This method initializes tbpQueries
	 *
	 * @return javax.swing.JTabbedPane
	 */
	private JTabbedPane getTbpQueries() {
		if (tbpQueries == null) {
			tbpQueries = new JTabbedPane();
			tbpQueries.setBounds(new Rectangle(344, 242, 383, 250));
			tbpQueries.setBackground(new Color(113, 167, 173));
			tbpQueries.addTab("Περιοχή", null, getPnlRangeQ(), null);
			tbpQueries.addTab("Πλησιέστεροι γείτονες", null,
					getPnlNeighboursQ(), null);
			tbpQueries.addTab("Συμβάντα", null, getPnlLog(), null);
		}
		return tbpQueries;
	}

	/**
	 * This method initializes pnlRangeQ
	 *
	 * @return javax.swing.JPanel
	 */
	private JPanel getPnlRangeQ() {
		if (pnlRangeQ == null) {
			GridBagConstraints gridBagConstraints2 = new GridBagConstraints();
			gridBagConstraints2.fill = GridBagConstraints.BOTH;
			gridBagConstraints2.gridy = 0;
			gridBagConstraints2.weightx = 1.0;
			gridBagConstraints2.weighty = 1.0;
			gridBagConstraints2.gridx = 0;
			pnlRangeQ = new JPanel();
			pnlRangeQ.setLayout(new GridBagLayout());
			pnlRangeQ.setBackground(new Color(113, 167, 173));
			pnlRangeQ.add(getScpRange(), gridBagConstraints2);
		}
		return pnlRangeQ;
	}

	/**
	 * This method initializes pnlNeighboursQ
	 *
	 * @return javax.swing.JPanel
	 */
	private JPanel getPnlNeighboursQ() {
		if (pnlNeighboursQ == null) {
			GridBagConstraints gridBagConstraints1 = new GridBagConstraints();
			gridBagConstraints1.fill = GridBagConstraints.BOTH;
			gridBagConstraints1.gridy = 0;
			gridBagConstraints1.weightx = 1.0;
			gridBagConstraints1.weighty = 1.0;
			gridBagConstraints1.gridx = 0;
			pnlNeighboursQ = new JPanel();
			pnlNeighboursQ.setLayout(new GridBagLayout());
			pnlNeighboursQ.setBackground(new Color(113, 167, 173));
			pnlNeighboursQ.add(getScpNeighbours(), gridBagConstraints1);
		}
		return pnlNeighboursQ;
	}

	/**
	 * This method initializes pnlOptions
	 *
	 * @return javax.swing.JPanel
	 */
	private JPanel getPnlOptions() {
		if (pnlOptions == null) {
			lblPathText = new JLabel();
			lblPathText.setText("Επιλέξτε το αρχείο εισόδου:");
			lblPathText.setBounds(new Rectangle(6, 6, 320, 24));
			pnlOptions = new JPanel();
			pnlOptions.setLayout(null);
			pnlOptions.setBounds(new Rectangle(7, 9, 331, 60));
			pnlOptions.setBorder(BorderFactory
					.createBevelBorder(BevelBorder.RAISED));
			pnlOptions.setBackground(new Color(113, 167, 173));
			pnlOptions.add(lblPathText, null);
			pnlOptions.add(getTxtfPath(), null);
			pnlOptions.add(getCmdOpenFile(), null);
		}
		return pnlOptions;
	}

	/**
	 * This method initializes txtfPath
	 *
	 * @return javax.swing.JTextField
	 */
	private JTextField getTxtfPath() {
		if (txtfPath == null) {
			txtfPath = new JTextField();
			txtfPath.setBounds(new Rectangle(6, 27, 280, 23));
			txtfPath.setEditable(false);
		}
		return txtfPath;
	}

	/**
	 * This method initializes cmdOpenFile
	 *
	 * @return javax.swing.JButton
	 */
	private JButton getCmdOpenFile() {
		if (cmdOpenFile == null) {
			cmdOpenFile = new JButton();
			cmdOpenFile.setBounds(new Rectangle(289, 28, 27, 23));
			cmdOpenFile.setText("...");
			cmdOpenFile.addActionListener(new ActionListener() {

				public void actionPerformed(ActionEvent e) {
					if (e.getSource() == cmdOpenFile) {
						int returnVal = myFileChooser
								.showOpenDialog(MainWindow.this);

						if (returnVal == JFileChooser.APPROVE_OPTION) {
							txtfPath.setForeground(Color.GREEN);
							txtfPath.setText(myFileChooser.getSelectedFile()
									.getPath());
							readDataFromFileAndInitialize(myFileChooser
									.getSelectedFile().getPath());
						} else {
							txtfPath.setForeground(Color.RED);
							txtfPath.setText("Δεν έχει επιλεγεί αρχείο!");

						}
					}

				}
			});

		}
		return cmdOpenFile;
	}

	/**
	 * This method initializes pnlSearch
	 *
	 * @return javax.swing.JPanel
	 */
	private JPanel getPnlSearch() {
		if (pnlSearch == null) {
			lblJoker = new JLabel();
			lblJoker.setBounds(new Rectangle(20, 161, 100, 24));
			lblJoker.setEnabled(false);
			lblJoker.setText("Απόσταση:");
			lblJoker.setVisible(false);
			lblPoint = new JLabel();
			lblPoint.setBounds(new Rectangle(20, 130, 100, 24));
			lblPoint.setText("Σημείο Αναφοράς:");
			lblPoint.setEnabled(false);
			lblPoint.setVisible(false);
			lblParameters = new JLabel();
			lblParameters.setText("Παράμετροι ερωτήματος:");
			lblParameters.setBounds(new Rectangle(7, 100, 318, 20));
			lblParameters.setEnabled(false);
			lblParameters.setVisible(false);
			lblRange = new JLabel();
			lblRange.setText("Ερώτημα:");
			lblRange.setBounds(new Rectangle(7, 6, 318, 20));
			pnlSearch = new JPanel();
			pnlSearch.setLayout(null);
			pnlSearch.setBackground(new Color(113, 167, 173));
			pnlSearch.setSize(new Dimension(331, 419));
			pnlSearch.setLocation(new Point(6, 73));
			pnlSearch.setBorder(BorderFactory
					.createBevelBorder(BevelBorder.RAISED));
			pnlSearch.add(lblRange, null);
			pnlSearch.add(getRdbArea(), null);
			pnlSearch.add(getRdbNeighbours(), null);
			pnlSearch.add(lblParameters, null);
			pnlSearch.add(lblPoint, null);
			pnlSearch.add(getTxtfPoint(), null);
			pnlSearch.add(lblJoker, null);
			pnlSearch.add(getTxtfJoker(), null);
			pnlSearch.add(getCmdExit(), null);
			pnlSearch.add(getScpInfo(), null);
			pnlSearch.add(getCmdExecute(), null);
		}
		return pnlSearch;
	}

	/**
	 * This method initializes rdbArea
	 *
	 * @return javax.swing.JRadioButton
	 */
	private JRadioButton getRdbArea() {
		if (rdbArea == null) {
			rdbArea = new JRadioButton();
			rdbArea.setBounds(new Rectangle(9, 36, 316, 22));
			rdbArea.setText("περιοχής");
			rdbArea.setOpaque(false);
			rdbArea.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					if (rdbArea.isSelected()) {
						lblParameters.setEnabled(true);
						lblParameters.setVisible(true);

						lblPoint.setVisible(true);
						lblPoint.setEnabled(true);
						txtfPoint.setVisible(true);
						txtfPoint.setEnabled(true);

						lblJoker.setEnabled(true);
						lblJoker.setVisible(true);
						lblJoker.setText("Απόσταση:");
						txtfJoker.setEnabled(true);
						txtfJoker.setVisible(true);

						rdbNeighbours.setSelected(false);

						scpInfo.setVisible(true);
						txtaInfo
								.setText("Το σημείο αναφοράς θα πρέπει να συμφωνεί σε διαστάσεις με το αρχικό σετ δεδομένων και να είναι γραμμένο στη μορφή d1 d2 d3 ... dn δηλαδή κάθε διάσταση να χωρίζεται από την επόμενη με έναν κενό χαρακτήρα.\n\nΗ απόσταση θα πρέπει να δίνεται σε μορφή double (> 0) (π.χ. 3.2).");

						cmdExecute.setVisible(true);

					}
				}
			});
		}
		return rdbArea;
	}

	/**
	 * This method initializes rdbNeighbours
	 *
	 * @return javax.swing.JRadioButton
	 */
	private JRadioButton getRdbNeighbours() {
		if (rdbNeighbours == null) {
			rdbNeighbours = new JRadioButton();
			rdbNeighbours.setOpaque(false);
			rdbNeighbours.setBounds(new Rectangle(9, 59, 316, 22));
			rdbNeighbours.setText("πλησιέστερων γειτόνων");
			rdbNeighbours
					.addActionListener(new java.awt.event.ActionListener() {
						public void actionPerformed(java.awt.event.ActionEvent e) {
							if (rdbNeighbours.isSelected()) {
								lblParameters.setEnabled(true);
								lblParameters.setVisible(true);

								lblPoint.setVisible(true);
								lblPoint.setEnabled(true);
								txtfPoint.setVisible(true);
								txtfPoint.setEnabled(true);

								lblJoker.setEnabled(true);
								lblJoker.setVisible(true);
								lblJoker.setText("Αρ. Γειτόνων:");
								txtfJoker.setEnabled(true);
								txtfJoker.setVisible(true);

								rdbArea.setSelected(false);

								scpInfo.setVisible(true);
								txtaInfo
										.setText("Το σημείο αναφοράς θα πρέπει να συμφωνεί σε διαστάσεις με το αρχικό σετ δεδομένων και να είναι γραμμένο στη μορφή d1 d2 d3 ... dn δηλαδή κάθε διάσταση να χωρίζεται από την επόμενη με έναν κενό χαρακτήρα.\n\nΟ αριθμός γειτόνων θα πρέπει να δηλώνεται με έναν ακέραιο (>0, π.χ. 10).");

								cmdExecute.setVisible(true);

							}
						}
					});
		}
		return rdbNeighbours;
	}

	/**
	 * This method initializes txtfPoint
	 *
	 * @return javax.swing.JTextField
	 */
	private JTextField getTxtfPoint() {
		if (txtfPoint == null) {
			txtfPoint = new JTextField();
			txtfPoint.setBounds(new Rectangle(128, 130, 194, 23));
			txtfPoint.setEnabled(false);
			txtfPoint.setVisible(false);
		}
		return txtfPoint;
	}

	/**
	 * This method initializes txtfJoker
	 *
	 * @return javax.swing.JTextField
	 */
	private JTextField getTxtfJoker() {
		if (txtfJoker == null) {
			txtfJoker = new JTextField();
			txtfJoker.setEnabled(false);
			txtfJoker.setBounds(new Rectangle(128, 160, 194, 23));
			txtfJoker.setVisible(false);
		}
		return txtfJoker;
	}

	/**
	 * This method initializes cmdExit
	 *
	 * @return javax.swing.JButton
	 */
	private JButton getCmdExit() {
		if (cmdExit == null) {
			cmdExit = new JButton();
			cmdExit.setText("Έξοδος");
			cmdExit.setBounds(new Rectangle(229, 388, 91, 24));
			cmdExit.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					if (e.getSource() == cmdExit) {
						System.exit(0);
					}
				}
			});
		}
		return cmdExit;
	}

	private void readDataFromFileAndInitialize(String path) {

		txtaLog.setText("Αρχείο εισόδου...\n\n");
		BufferedReader fileInput = null;
		String errors = "";

		try {
			fileInput = new BufferedReader(new FileReader(new File(path)));
		} catch (FileNotFoundException e) {
			errors = "ΘΑΝΑΣΙΜΟ ΣΦΑΛΜΑ: Το αρχείο δε βρέθηκε.";
			txtaLog.append(errors);
			txtfPath.setForeground(Color.RED);
			txtfPath.setText("Η διαδρομή αρχείο είναι λανθασμένη.");
			return;
		}

		// Here we store the file's content (line by line) after transforming it
		// to a string.

		String temp = "";

		// This boolean forces the while loop to end when it becomes true.

		boolean fileEnded = false;
		int lineNumber = 1;
		// If the file is empty we return after showing an appropriate message
		// to the user

		try {
			temp = fileInput.readLine();

			if (temp == null) {
				errors = "ΘΑΝΑΣΙΜΟ ΣΦΑΛΜΑ: Πιθανώς άδειο αρχείο.";
				txtaLog.append(errors);
				return;
			}
			lineNumber++;
		} catch (IOException e) {
			e.printStackTrace();
		}

		// ID is not a dimension
		numberOfDimensions = temp.split("[ \t\r\f]+").length - 1;
		Main.DIMENSIONS = numberOfDimensions-1; //cause ID is not a Dimension 
		// This loop reads until first line of data is read.

		try {

			temp = fileInput.readLine();
			if (temp == null) {
				errors = "ΣΦΑΛΜΑ: Το αρχείο δεν περιέχει έγκυρα δεδομένα.\n";
				txtaLog.append(errors);
			}
			lineNumber++;
		} catch (IOException e) {
			e.printStackTrace();
		}

		String[] dataInLine;
		String initialDatasetString = "";

		while (!fileEnded) {
			try {

				temp = fileInput.readLine();
				if (temp == null) {
					fileEnded = true;
					continue;
				}
				lineNumber++;
			} catch (IOException e) {
				e.printStackTrace();
			}

			dataInLine = temp.split("[ \t\r\f]+");

			if (dataInLine.length != (numberOfDimensions + 1)) { // bcoz ID
				// is
				// included
				// in the
				// line

				errors = "ΣΦΑΛΜΑ (γραμμή "
						+ (lineNumber - 1)
						+ "η): Οι διαστάσεις δε συμφωνούν με την πρότυπη γραμμή.\n";
				txtaLog.append(errors);
				continue;
			}

			double[] pointData = new double[dataInLine.length-1];
			long ID = 0;
			Integer curNumber;

			try {
				for (int i = 0; i < dataInLine.length; i++) {

					curNumber = Integer.parseInt(dataInLine[i]);

					if (i == 0) {
						ID = curNumber;

					} else {
						pointData[i-1] = curNumber;

					}
				}
			} catch (NumberFormatException e) {
				errors = "ΣΦΑΛΜΑ (γραμμή " + (lineNumber - 1)
						+ "η):  Κάποιο στοιχείο δεν είναι έγκυρος αριθμός.\n";
				txtaLog.append(errors);
				continue;
			}

			rtree.util.Point newPoint = new rtree.util.Point(ID, pointData);

			sendPointToRTree(newPoint);

			initialDatasetString += newPoint.toString() + "\n";

		}
		if (errors == "") {

			txtaLog
					.setText(txtaLog.getText()
							+ "\n"
							+ "Η ανάγνωση του αρχείου πραγματοποιήθηκε χωρίς σφάλματα.\n\n");

		}
		txtaInitPoints.setText("Αρχικό σετ δεδομένων:\n\n"
				+ initialDatasetString);
		cmdOpenFile.setEnabled(false);
	}

	/**
	 * This method initializes scpLog
	 *
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getScpLog() {
		if (scpLog == null) {
			scpLog = new JScrollPane();
			scpLog.setOpaque(false);
			scpLog.setBackground(new Color(113, 167, 173));
			scpLog.setViewportView(getTxtaLog());
			scpLog.setAutoscrolls(true);
		}
		return scpLog;
	}

	/**
	 * This method initializes txtaLog
	 *
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getTxtaLog() {
		if (txtaLog == null) {
			txtaLog = new JTextArea();
			txtaLog.setLineWrap(true);
			txtaLog.setText("Αρχείο εισόδου...\n");
			txtaLog.setFont(new Font("Dialog", Font.BOLD, 12));
			txtaLog.setBackground(new Color(113, 167, 173));
			txtaLog.setEditable(false);
			txtaLog.setOpaque(true);
		}
		return txtaLog;
	}

	/**
	 * This method initializes pnlLog
	 *
	 * @return javax.swing.JPanel
	 */
	private JPanel getPnlLog() {
		if (pnlLog == null) {
			GridBagConstraints gridBagConstraints = new GridBagConstraints();
			gridBagConstraints.fill = GridBagConstraints.BOTH;
			gridBagConstraints.gridy = -1;
			gridBagConstraints.weightx = 1.0;
			gridBagConstraints.weighty = 1.0;
			gridBagConstraints.gridx = -1;
			pnlLog = new JPanel();
			pnlLog.setLayout(new GridBagLayout());
			pnlLog.add(getScpLog(), gridBagConstraints);
		}
		return pnlLog;
	}

	private void sendPointToRTree(rtree.util.Point newPoint) {
		Main.myTree.insert(newPoint);
	}

	private void regionQueryManipulation(double region, rtree.util.Point aPoint) {

		rtree.util.Point[] results = Main.myTree.rangeQuery(aPoint, region);
		printoutResults(results, "range");

	}

	private void neighbourQueryManipulation(int neighbours,
			rtree.util.Point aPoint) {

		rtree.util.Point[] results = Main.myTree.nearestNeighbours(aPoint,
				neighbours);
		printoutResults(results, "neighbours");
	}

	private void printoutResults(rtree.util.Point [] theResults,String typeOfQuery)
	{
		String output = "";
		if(typeOfQuery.equals("range"))
		{
			if(theResults.length == 0)
			{
				txtaRange.setText("Δεν βρέθηκαν σημεία που να ικανοποιούν το ερώτημα");
			}
			else
			{
				for (int i = 0; i < theResults.length; i++) {
					output+=theResults[i].toString() + "\n";
				}
				txtaRange.setText(output);
			}
		}
		else
		{
			if(theResults.length == 0)
			{
			txtaNeighbours.setText("Δεν βρέθηκαν σημεία που να ικανοποιούν το ερώτημα");
			}
			else
			{
				for (int i = 0; i < theResults.length; i++) {
					output+=theResults[i].toString() + "\n";
				}
				txtaNeighbours.setText(output);
			}
		}
	}

	/**
	 * This method initializes pnlInitialPoints
	 *
	 * @return javax.swing.JPanel
	 */
	private JPanel getPnlInitialPoints() {
		if (pnlInitialPoints == null) {
			pnlInitialPoints = new JPanel();
			pnlInitialPoints.setLayout(null);
			pnlInitialPoints.setBackground(new Color(113, 167, 173));
			pnlInitialPoints.setBounds(new Rectangle(347, 11, 379, 224));
			pnlInitialPoints.setBorder(BorderFactory
					.createBevelBorder(BevelBorder.RAISED));
			pnlInitialPoints.add(getScpInitPoints(), null);
		}
		return pnlInitialPoints;
	}

	/**
	 * This method initializes txtaInitPoints
	 *
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getTxtaInitPoints() {
		if (txtaInitPoints == null) {
			txtaInitPoints = new JTextArea();
			txtaInitPoints.setFont(new Font("Dialog", Font.BOLD, 12));
			txtaInitPoints.setOpaque(true);
			txtaInitPoints.setText("Αρχικά σημεία\n");
			txtaInitPoints.setLineWrap(true);
			txtaInitPoints.setEnabled(true);
			txtaInitPoints.setEditable(false);
			txtaInitPoints.setBackground(new Color(113, 167, 173));
		}
		return txtaInitPoints;
	}

	/**
	 * This method initializes scpInitPoints
	 *
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getScpInitPoints() {
		if (scpInitPoints == null) {
			scpInitPoints = new JScrollPane();
			scpInitPoints.setBounds(new Rectangle(5, 7, 369, 213));
			scpInitPoints.setViewportView(getTxtaInitPoints());
		}
		return scpInitPoints;
	}

	/**
	 * This method initializes scpInfo
	 *
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getScpInfo() {
		if (scpInfo == null) {
			scpInfo = new JScrollPane();
			scpInfo.setBounds(new Rectangle(8, 229, 313, 153));
			scpInfo.setViewportView(getTxtaInfo());
			scpInfo.setBackground(new Color(113, 167, 173));
			scpInfo.setVisible(false);
		}
		return scpInfo;
	}

	/**
	 * This method initializes txtaInfo
	 *
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getTxtaInfo() {
		if (txtaInfo == null) {
			txtaInfo = new JTextArea();
			txtaInfo.setBackground(new Color(113, 167, 173));
			txtaInfo.setEditable(false);
			txtaInfo
					.setBorder(BorderFactory
							.createTitledBorder(
									null,
									"\u03a0\u03bb\u03b7\u03c1\u03bf\u03c6\u03bf\u03c1\u03af\u03b5\u03c2",
									TitledBorder.DEFAULT_JUSTIFICATION,
									TitledBorder.DEFAULT_POSITION, new Font(
											"Dialog", Font.BOLD, 12),
									new Color(51, 51, 51)));
			txtaInfo.setLineWrap(true);
		}
		return txtaInfo;
	}

	/**
	 * This method initializes cmdExecute
	 *
	 * @return javax.swing.JButton
	 */
	private JButton getCmdExecute() {
		if (cmdExecute == null) {
			cmdExecute = new JButton();
			cmdExecute.setText("Εκτέλεση");
			cmdExecute.setSize(new Dimension(91, 24));
			cmdExecute.setLocation(new Point(229, 199));
			cmdExecute.setVisible(false);
			cmdExecute.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					if (rdbArea.isSelected()) {
						double range = 0.0;
						try {
							range = Double.parseDouble(txtfJoker.getText());
						} catch (NumberFormatException e1) {
							txtfJoker.setText("εισάγετε έναν double > 0!");
							txtaLog
									.append("\n\nΜη αποδεκτή τιμή απόστασης για ερώτημα περιοχής.");

							return;
						}
						if (range <= 0.0) {
							txtfJoker.setText("εισάγετε έναν double > 0!");
							txtaLog
									.append("\n\nΜη αποδεκτή τιμή απόστασης για ερώτημα περιοχής.");
							return;
						} else {

							String temp = txtfPoint.getText();
							String[] dataInLine = temp.split("[ \t\r\f]+");

							if (dataInLine.length != numberOfDimensions) {
								txtaLog
										.append("\n\nΛάθος στις διαστάσεις του σημείου αναφοράς.");
								txtfPoint
										.setText("Λάθος σημείο αναφοράς, ξαναπροσπαθήστε.");
								return;
							}

							double[] pointData = new double[dataInLine.length];
							Integer curNumber;

							try {
								for (int i = 0; i < dataInLine.length; i++) {

									curNumber = Integer.parseInt(dataInLine[i]);

									pointData[i] = curNumber;
									i++;
								}
							} catch (NumberFormatException e1) {
								txtaLog.append("\n\nΜη έγκυρος αριθμός.");
								txtfPoint
										.setText("Λάθος σημείο αναφοράς, ξαναπροσπαθήστε.");
								return;
							}

							rtree.util.Point newPoint = new rtree.util.Point(
									pointData);

							regionQueryManipulation(range, newPoint);
						}
					} else {
						int neighbours = 0;
						try {
							neighbours = Integer.parseInt(txtfJoker.getText());
						} catch (NumberFormatException e1) {
							txtfJoker.setText("εισάγετε έναν int > 0!");
							txtaLog
									.append("\n\nΜη αποδεκτός αριθμός γειτόνων για ερώτημα γειτνίασης.");

							return;
						}
						if (neighbours <= 0) {
							txtfJoker.setText("εισάγετε έναν int > 0!");
							txtaLog
									.append("\n\nΜη αποδεκτός αριθμός γειτόνων για ερώτημα γειτνίασης.");
							return;
						} else {
							String temp = txtfPoint.getText();
							String[] dataInLine = temp.split("[ \t\r\f]+");

							if (dataInLine.length != numberOfDimensions) {
								txtaLog
										.append("\n\nΛάθος στις διαστάσεις του σημείου αναφοράς.");
								txtfPoint
										.setText("Λάθος σημείο αναφοράς, ξαναπροσπαθήστε.");
								return;
							}

							double[] pointData = new double[dataInLine.length];
							Integer curNumber;

							try {
								for (int i = 0; i < dataInLine.length; i++) {

									curNumber = Integer.parseInt(dataInLine[i]);

									pointData[i] = curNumber;
									i++;
								}
							} catch (NumberFormatException e1) {
								txtaLog.append("\n\nΜη έγκυρος αριθμός.");
								txtfPoint
										.setText("Λάθος σημείο αναφοράς, ξαναπροσπαθήστε.");
								return;
							}

							rtree.util.Point newPoint = new rtree.util.Point(
									pointData);

							neighbourQueryManipulation(neighbours, newPoint);
						}
					}
				}
			});
		}
		return cmdExecute;
	}

	/**
	 * This method initializes scpNeighbours
	 *
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getScpNeighbours() {
		if (scpNeighbours == null) {
			scpNeighbours = new JScrollPane();
			scpNeighbours.setBackground(new Color(113, 167, 173));
			scpNeighbours.setViewportView(getTxtaNeighbours());
		}
		return scpNeighbours;
	}

	/**
	 * This method initializes txtaNeighbours
	 *
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getTxtaNeighbours() {
		if (txtaNeighbours == null) {
			txtaNeighbours = new JTextArea();
			txtaNeighbours.setBackground(new Color(113, 167, 173));
			txtaNeighbours.setEditable(false);
		}
		return txtaNeighbours;
	}

	/**
	 * This method initializes scpRange
	 *
	 * @return javax.swing.JScrollPane
	 */
	private JScrollPane getScpRange() {
		if (scpRange == null) {
			scpRange = new JScrollPane();
			scpRange.setViewportView(getTxtaRange());
		}
		return scpRange;
	}

	/**
	 * This method initializes txtaRange
	 *
	 * @return javax.swing.JTextArea
	 */
	private JTextArea getTxtaRange() {
		if (txtaRange == null) {
			txtaRange = new JTextArea();
			txtaRange.setEditable(false);
			txtaRange.setBackground(new Color(113, 167, 173));
		}
		return txtaRange;
	}

} // @jve:decl-index=0:visual-constraint="10,10"
