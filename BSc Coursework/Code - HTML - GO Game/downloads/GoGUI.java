

import java.awt.*;
import java.awt.event.*;
import java.applet.Applet;
import javax.swing.*;


public class GoGUI extends Applet  implements ActionListener{


    private int currentImage;
    private JLabel lImage;
    private ImageIcon iTexted ;

    private JPanel pPrevious ;
    private JPanel pNext;

    private final int IMAGE_START =1;
    private final int IMAGE_END =78;

    private void imageLoad()   // loads current Image
    {
        iTexted = new ImageIcon("../../applet_images/" + currentImage + ".jpg") ;
        lImage.setIcon(iTexted);
    }




    public GoGUI(){}

    public void init()
    {

        currentImage=IMAGE_START;

        this.setSize(800,600);

        // the side panel
        JPanel pSide = new JPanel(new GridLayout(10,1) );
        pSide.setBackground(Color.WHITE);
        // its buttons
        JButton bRules = new JButton("Κανόνες");
        JButton bStrategy = new JButton("Στρατιγική");
        JButton bIndexA = new JButton("Παράρτημα Α");
        JButton bReference = new JButton("Αναφορές");
        JButton bAbout = new JButton("About");
        // adding the buttons to the side panel
        pSide.add(bRules);
        pSide.add(bStrategy);
        pSide.add(bIndexA);
        pSide.add(bReference);
        pSide.add(bAbout);
        // and setting tha action listener
        bRules.addActionListener(this);
        bStrategy.addActionListener(this);
        bIndexA.addActionListener(this);
        bReference.addActionListener(this);
        bAbout.addActionListener(this);

        // adding the side panel to the left side of the main panel
        this.add(pSide,BorderLayout.WEST) ;

        // the buttons panel
        JPanel pButtons = new JPanel(new GridLayout(1,3) );
        JPanel helper =  new JPanel(new GridLayout(1,1) );    //used to centre
        helper.setBackground(Color.WHITE);
        pButtons.add(helper) ;
        // the button next
        JButton bNext = new JButton("  Επόμενο   >>");
        // it's panel
        pNext = new JPanel(new FlowLayout() );
        pNext.add(bNext);
        pNext.setBackground(Color.WHITE );
        // adding the listener
        bNext.addActionListener(this);



         // the button previous
        JButton bPrevious = new JButton("<< Προηγούμενο");
        // it's panel
        pPrevious = new JPanel(new FlowLayout() );
        pPrevious.add(bPrevious);
        pPrevious.setBackground(Color.WHITE);
        //in the beggining it should not be visible(there is no previous)
        pPrevious.setVisible(false);
        // adding the listener
        bPrevious.addActionListener(this);

        //adding the buttons to the buttons panel
        pButtons.add(pPrevious);
        pButtons.add(pNext);
        pButtons.setBackground(Color.WHITE );



        // an label
        lImage = new JLabel();
        imageLoad();    //loading the image to the above label


        //adding the imaage label in the center of the main panel
        this.add(lImage,BorderLayout .CENTER);
        //and the buttons to the bottom

        this.add(pButtons,BorderLayout.SOUTH ) ;

        pButtons.doLayout();

        this.setBackground(Color.WHITE);
        this.setVisible(true);
    }


    //checks if button previous shoud be off in case we depart from the beggining
    private void visibilityLeaveStartCheck()
    {
       if (currentImage == IMAGE_START  ) pPrevious.setVisible(true);

    }

    // the opposite of above
    private void visibilityLeaveEndCheck()
    {
         if (currentImage == IMAGE_END  ) pNext.setVisible(true);

    }

    //checks if button previous shoud be off in case we arrive from the beggining
    private void visibilityArriveStartCheck()
    {
       if (currentImage == IMAGE_START  ) pPrevious.setVisible(false);

    }

    // the opposite of above
    private void visibilityArriveEndCheck()
    {
         if (currentImage == IMAGE_END  ) pNext.setVisible(false);

    }

    // the actions handling
    public void actionPerformed(ActionEvent e) {

        if (e.getActionCommand().equals("  Επόμενο   >>") )
        {
            visibilityLeaveStartCheck();
            currentImage++;
            visibilityArriveEndCheck();

            imageLoad();
        }

        else if( e.getActionCommand().equals("<< Προηγούμενο" ) )
        {
            visibilityLeaveEndCheck();
            currentImage-- ;
            visibilityArriveStartCheck();

            imageLoad();
        }
        else if( e.getActionCommand().equals("Κανόνες" ) )
        {
            visibilityLeaveStartCheck();
            visibilityLeaveEndCheck();
            currentImage = 3;


           imageLoad();
        }
        else if( e.getActionCommand().equals("Στρατιγική" ) )
        {
            visibilityLeaveStartCheck();
            visibilityLeaveEndCheck();
            currentImage = 40;


           imageLoad();
        }
        else if( e.getActionCommand().equals("Παράρτημα Α") )
        {

            visibilityLeaveStartCheck();
            visibilityLeaveEndCheck();
            currentImage = 74;


            imageLoad();
        }
        else if( e.getActionCommand().equals("Αναφορές" ) )
        {

            visibilityLeaveStartCheck();
            visibilityLeaveEndCheck();
            currentImage = 77;


            imageLoad();
        }
        else if( e.getActionCommand().equals("About" ) )
        {
            pPrevious.setVisible(true);
            pNext.setVisible(false);
            currentImage = 78;

            imageLoad();
        }

        this.doLayout(); //in the end relayour beacause images differ

    }


}

