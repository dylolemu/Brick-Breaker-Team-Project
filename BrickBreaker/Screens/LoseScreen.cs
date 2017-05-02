using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker 
{
    public partial class LoseScreen : UserControl
    {
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, spaceDown;
        int index1, index2, index3, selected;
        int x1, y1, x2, y2, x3, y3;

        public LoseScreen()
        {
            InitializeComponent();
        }

        private void OnStart()
        {
            x1 = this.Width / 2;
            y1 = y2 = y3 = this.Height / 2 - 50;
            x2 = x1 + 50;           
            x3 = x2 + 50;
        }

        private void LoseScreen_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 72);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Lime);

            switch (index1)
            {
                case 0:
                    formGraphics.DrawString("A", drawFont, drawBrush, x1, y1);
                    break;
                case 1:
                    formGraphics.DrawString("B", drawFont, drawBrush, x1, y1);
                    break;
                case 2:
                    formGraphics.DrawString("C", drawFont, drawBrush, x1, y1);
                    break;
                case 3:
                    formGraphics.DrawString("D", drawFont, drawBrush, x1, y1);
                    break;
                case 4:
                    formGraphics.DrawString("E", drawFont, drawBrush, x1, y1);
                    break;
                case 5:
                    formGraphics.DrawString("F", drawFont, drawBrush, x1, y1);
                    break;
                case 6:
                    formGraphics.DrawString("G", drawFont, drawBrush, x1, y1);
                    break;
                case 7:
                    formGraphics.DrawString("H", drawFont, drawBrush, x1, y1);
                    break;
                case 8:
                    formGraphics.DrawString("I", drawFont, drawBrush, x1, y1);
                    break;
                case 9:
                    formGraphics.DrawString("J", drawFont, drawBrush, x1, y1);
                    break;
                case 10:
                    formGraphics.DrawString("K", drawFont, drawBrush, x1, y1);
                    break;
                case 11:
                    formGraphics.DrawString("L", drawFont, drawBrush, x1, y1);
                    break;
                case 12:
                    formGraphics.DrawString("M", drawFont, drawBrush, x1, y1);
                    break;
                case 13:
                    formGraphics.DrawString("N", drawFont, drawBrush, x1, y1);
                    break;
                case 14:
                    formGraphics.DrawString("O", drawFont, drawBrush, x1, y1);
                    break;
                case 15:
                    formGraphics.DrawString("P", drawFont, drawBrush, x1, y1);
                    break;
                case 16:
                    formGraphics.DrawString("Q", drawFont, drawBrush, x1, y1);
                    break;
                case 17:
                    formGraphics.DrawString("R", drawFont, drawBrush, x1, y1);
                    break;
                case 18:
                    formGraphics.DrawString("S", drawFont, drawBrush, x1, y1);
                    break;
                case 19:
                    formGraphics.DrawString("T", drawFont, drawBrush, x1, y1);
                    break;
                case 20:
                    formGraphics.DrawString("U", drawFont, drawBrush, x1, y1);
                    break;
                case 21:
                    formGraphics.DrawString("V", drawFont, drawBrush, x1, y1);
                    break;
                case 22:
                    formGraphics.DrawString("W", drawFont, drawBrush, x1, y1);
                    break;
                case 23:
                    formGraphics.DrawString("X", drawFont, drawBrush, x1, y1);
                    break;
                case 24:
                    formGraphics.DrawString("Y", drawFont, drawBrush, x1, y1);
                    break;
                case 25:
                    formGraphics.DrawString("Z", drawFont, drawBrush, x1, y1);
                    break;
            }

            switch (index2)
            {
                case 0:
                    formGraphics.DrawString("A", drawFont, drawBrush, x2, y2);
                    break;
                case 1:
                    formGraphics.DrawString("B", drawFont, drawBrush, x2, y2);
                    break;
                case 2:
                    formGraphics.DrawString("C", drawFont, drawBrush, x2, y2);
                    break;
                case 3:
                    formGraphics.DrawString("D", drawFont, drawBrush, x2, y2);
                    break;
                case 4:
                    formGraphics.DrawString("E", drawFont, drawBrush, x2, y2);
                    break;
                case 5:
                    formGraphics.DrawString("F", drawFont, drawBrush, x2, y2);
                    break;
                case 6:
                    formGraphics.DrawString("G", drawFont, drawBrush, x2, y2);
                    break;
                case 7:
                    formGraphics.DrawString("H", drawFont, drawBrush, x2, y2);
                    break;
                case 8:
                    formGraphics.DrawString("I", drawFont, drawBrush, x2, y2);
                    break;
                case 9:
                    formGraphics.DrawString("J", drawFont, drawBrush, x2, y2);
                    break;
                case 10:
                    formGraphics.DrawString("K", drawFont, drawBrush, x2, y2);
                    break;
                case 11:
                    formGraphics.DrawString("L", drawFont, drawBrush, x2, y2);
                    break;
                case 12:
                    formGraphics.DrawString("M", drawFont, drawBrush, x2, y2);
                    break;
                case 13:
                    formGraphics.DrawString("N", drawFont, drawBrush, x2, y2);
                    break;
                case 14:
                    formGraphics.DrawString("O", drawFont, drawBrush, x2, y2);
                    break;
                case 15:
                    formGraphics.DrawString("P", drawFont, drawBrush, x2, y2);
                    break;
                case 16:
                    formGraphics.DrawString("Q", drawFont, drawBrush, x2, y2);
                    break;
                case 17:
                    formGraphics.DrawString("R", drawFont, drawBrush, x2, y2);
                    break;
                case 18:
                    formGraphics.DrawString("S", drawFont, drawBrush, x2, y2);
                    break;
                case 19:
                    formGraphics.DrawString("T", drawFont, drawBrush, x2, y2);
                    break;
                case 20:
                    formGraphics.DrawString("U", drawFont, drawBrush, x2, y2);
                    break;
                case 21:
                    formGraphics.DrawString("V", drawFont, drawBrush, x2, y2);
                    break;
                case 22:
                    formGraphics.DrawString("W", drawFont, drawBrush, x2, y2);
                    break;
                case 23:
                    formGraphics.DrawString("X", drawFont, drawBrush, x2, y2);
                    break;
                case 24:
                    formGraphics.DrawString("Y", drawFont, drawBrush, x2, y2);
                    break;
                case 25:
                    formGraphics.DrawString("Z", drawFont, drawBrush, x2, y2);
                    break;
            }

            switch (index3)
            {
                case 0:
                    formGraphics.DrawString("A", drawFont, drawBrush, x3, y3);
                    break;
                case 1:
                    formGraphics.DrawString("B", drawFont, drawBrush, x3, y3);
                    break;
                case 2:
                    formGraphics.DrawString("C", drawFont, drawBrush, x3, y3);
                    break;
                case 3:
                    formGraphics.DrawString("D", drawFont, drawBrush, x3, y3);
                    break;
                case 4:
                    formGraphics.DrawString("E", drawFont, drawBrush, x3, y3);
                    break;
                case 5:
                    formGraphics.DrawString("F", drawFont, drawBrush, x3, y3);
                    break;
                case 6:
                    formGraphics.DrawString("G", drawFont, drawBrush, x3, y3);
                    break;
                case 7:
                    formGraphics.DrawString("H", drawFont, drawBrush, x3, y3);
                    break;
                case 8:
                    formGraphics.DrawString("I", drawFont, drawBrush, x3, y3);
                    break;
                case 9:
                    formGraphics.DrawString("J", drawFont, drawBrush, x3, y3);
                    break;
                case 10:
                    formGraphics.DrawString("K", drawFont, drawBrush, x3, y3);
                    break;
                case 11:
                    formGraphics.DrawString("L", drawFont, drawBrush, x3, y3);
                    break;
                case 12:
                    formGraphics.DrawString("M", drawFont, drawBrush, x3, y3);
                    break;
                case 13:
                    formGraphics.DrawString("N", drawFont, drawBrush, x3, y3);
                    break;
                case 14:
                    formGraphics.DrawString("O", drawFont, drawBrush, x3, y3);
                    break;
                case 15:
                    formGraphics.DrawString("P", drawFont, drawBrush, x3, y3);
                    break;
                case 16:
                    formGraphics.DrawString("Q", drawFont, drawBrush, x3, y3);
                    break;
                case 17:
                    formGraphics.DrawString("R", drawFont, drawBrush, x3, y3);
                    break;
                case 18:
                    formGraphics.DrawString("S", drawFont, drawBrush, x3, y3);
                    break;
                case 19:
                    formGraphics.DrawString("T", drawFont, drawBrush, x3, y3);
                    break;
                case 20:
                    formGraphics.DrawString("U", drawFont, drawBrush, x3, y3);
                    break;
                case 21:
                    formGraphics.DrawString("V", drawFont, drawBrush, x3, y3);
                    break;
                case 22:
                    formGraphics.DrawString("W", drawFont, drawBrush, x3, y3);
                    break;
                case 23:
                    formGraphics.DrawString("X", drawFont, drawBrush, x3, y3);
                    break;
                case 24:
                    formGraphics.DrawString("Y", drawFont, drawBrush, x3, y3);
                    break;
                case 25:
                    formGraphics.DrawString("Z", drawFont, drawBrush, x3, y3);
                    break;
            }
        }

        private void LoseScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
                default:
                    break;
            }
        }

        private void LoseScreen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
                default:
                    break;
            }

            if (rightArrowDown == true && selected < 2)
            {
                selected++;
            }

            if (leftArrowDown == true && selected > 0)
            {
                selected--;
            }

            switch (selected)
            {
                case 0:
                    if (upArrowDown == true && index1 < 25)
                    {
                        index1++;
                    }

                    if (downArrowDown == true && index1 > 0)
                    {
                        index1--;
                    }
                    break;

                case 1:
                    if (upArrowDown == true && index2 < 25)
                    {
                        index2++;
                    }

                    if (downArrowDown == true && index2 > 0)
                    {
                        index2--;
                    }
                    break;

                case 2:
                    if (upArrowDown == true && index3 < 25)
                    {
                        index3++;
                    }

                    if (downArrowDown == true && index3 > 0)
                    {
                        index3--;
                    }
                    break;
            }

            Refresh();
        }
    }
}
