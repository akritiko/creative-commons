import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.font.FontRenderContext;
import java.awt.font.TextLayout;
import java.awt.geom.Arc2D;
import java.awt.geom.Line2D;
import java.awt.geom.Point2D;
import java.awt.geom.Rectangle2D;
import java.util.LinkedList;

import javax.swing.JFrame;
import javax.swing.JPanel;

public class Graph extends JFrame
{
	private JPanel jContentPane = null;

	private AdjacencyInfo[] neighbours;

	/**
	 * This is the default constructor
	 */
	public Graph(AdjacencyInfo[] neighbours)
	{
		super();
		initialize();

		// Κώδικας που προσθέσαμε.
		this.neighbours = neighbours;
	}

	/**
	 * This method initializes this
	 * 
	 * @return void
	 */
	private void initialize()
	{
		this.setSize(700, 600);
		this.setResizable(false);
		this.setContentPane(getJContentPane());
		this.setTitle("Γράφος γειτνίασης");
		this.setDefaultCloseOperation(EXIT_ON_CLOSE);
		this.addKeyListener(new java.awt.event.KeyAdapter()
		{
			public void keyPressed(java.awt.event.KeyEvent e)
			{
				Main.simulator.showMainWindow();
			}
		});
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
			jContentPane = new JPanel();
			jContentPane.setLayout(null);
		}
		return jContentPane;
	}

	@Override public void paint(Graphics g)
	{
		Graphics2D graph2d = (Graphics2D) g;

		LinkedList<Point2D> points = this.findPoints();

		int sideSize = 40;

		Point2D nodeStart;
		Point2D nodeEnd;
		Arc2D circle;
		Line2D newConnection;
		FontRenderContext context = graph2d.getFontRenderContext();
		Font f = new Font("Serif", Font.BOLD, 18);
		TextLayout layout;
		Rectangle2D rec;

		// Σχεδίαση κόμβων - διασυνδέσεων.
		for (int i = 0; i < this.neighbours.length; i++)
		{
			for (int j = 0; j < this.neighbours[i].getNumOfNeighbours(); j++)
			{
				nodeStart = points.get(this.neighbours[i].getPeerIndex());
				nodeEnd = points.get(this.neighbours[i].getNeighbour(j));

				graph2d.setColor(Color.BLACK);

				circle = new Arc2D.Double(nodeStart.getX() - sideSize / 2,
						nodeStart.getY() - sideSize / 2, sideSize, sideSize, 0,
						360, Arc2D.OPEN);

				graph2d.fill(circle);

				newConnection = new Line2D.Double(nodeStart, nodeEnd);

				graph2d.draw(newConnection);

				graph2d.setColor(Color.WHITE);
				layout = new TextLayout(String.valueOf(i), f, context);
				rec = layout.getBounds();
				layout.draw(graph2d, (float) (nodeStart.getX() - rec
						.getCenterX()), (float) (nodeStart.getY() - rec
						.getCenterY()));
			}
		}
		
		graph2d.setColor(Color.BLACK);
		layout = new TextLayout("Πιέστε ENTER", f, context);
		rec = layout.getBounds();
		layout.draw(graph2d, (float) (this.getWidth() - rec.getWidth() - 4),
				(float) (this.getHeight() - rec.getHeight()));
	}

	private LinkedList<Point2D> findPoints()
	{
		// Εύρεση σημείων όπου θα σχεδιαστούν οι κόμβοι.
		LinkedList<Point2D> points = new LinkedList<Point2D>();

		Arc2D arc;
		Point2D currentPoint;
		int increment = 360 / this.neighbours.length;

		for (int degrees = 0; degrees < 360; degrees += increment / 2)
		{
			arc = new Arc2D.Double(40, 60, this.getWidth() - 100, this
					.getHeight() - 100, degrees, degrees + increment,
					Arc2D.OPEN);

			currentPoint = arc.getEndPoint();

			points.add(currentPoint);
		}
		return points;
	}
} // @jve:decl-index=0:visual-constraint="10,10"
