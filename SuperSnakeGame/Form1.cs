
//Copy of brick breaker game
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrickBreaker.Screens;
using System.Xml;

/// <summary>
///  Long paddle 
///  More balls
///  Backup floor
///  additional life
///  double point
///  magnet
/// strongball
/// another comment   
/// another comment again
/// </summary>
namespace BrickBreaker
{
    public partial class Form1 : Form
    {
        // add a global value here
        public static List<Highscore> highscoreList = new List<Highscore>();
        public static int currentScore;
        // add a new comment
        
        //test comment

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start the program centred on the Menu Screen
            MenuScreen ps = new MenuScreen();
            this.Controls.Add(ps);
            
            ps.Location = new Point((this.Width - ps.Width) / 2, (this.Height - ps.Height) /2);
            //loadHighscores();
        }

        private void loadHighscores() //method for loading any saved highscores in the highscoreDB xml file
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("highscoreDB.xml");

            XmlNode parent;
            parent = doc.DocumentElement;
            foreach (XmlNode child in parent.ChildNodes)
            {
                Highscore hs = new Highscore(null, null);
                foreach (XmlNode grandChild in child.ChildNodes)
                {
                    if (grandChild.Name == "name")
                    {
                        hs.name = grandChild.InnerText;
                    }
                    if (grandChild.Name == "score")
                    {
                        hs.score = grandChild.InnerText;
                        //scores.Add(Convert.ToInt16(child.InnerText));
                    }
                }
                highscoreList.Add(hs);
            }
        }
    }
}
