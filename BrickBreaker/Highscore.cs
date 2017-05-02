using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using BrickBreaker.Screens;
using System.Xml;

namespace BrickBreaker
{
    public class Highscore
    {
        public string name, score;

        public Highscore(string _name, string _score)
        {
            name = _name;
            score = _score;
        }

        public void saveScores (List<Highscore> _scoreList)
        {
            //Only saves the top 10 highscores
            if (_scoreList.Count > 10)
            {
                for (int i = _scoreList.Count; i > 10; i--)
                {
                    _scoreList.RemoveAt(i - 1);
                }
            }
            //Creates the xml file where highscores are saved
            XmlTextWriter writer = new XmlTextWriter("highscoreDB.xml", null);

            writer.WriteStartElement("highscoreList");

            foreach (Highscore hs in _scoreList)
            {
                //Start "highscore" element
                writer.WriteStartElement("highscore");

                //Write sub-elements
                writer.WriteElementString("name", hs.name); //This is the name aspect, not needed unless I reintroduce the name aspect of highscores
                writer.WriteElementString("score", hs.score);

                // end the "highscore" element
                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.Close();
        }
    }
}
