using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class PowerUp
    {
        public int xCoord, yCoord, fallSpeed, type;
        public bool active;

        /// <summary>
        /// PowerUp object
        /// </summary>
        /// <param name="_xCoord">X coordinate of the powerup</param>
        /// <param name="_yCoord">Y coordinate of the powerup</param>
        /// <param name="_fallSpeed">falling speed of the powerup</param>
        /// <param name="_type">Type of Powerup (0 = magnet, 1 = long paddle, 2 = multiball, 3 = floor shield, 4 = extra life, 5 = double points, 6 = strong ball)</param>
        public PowerUp(int _xCoord, int _yCoord, int _fallSpeed, int _type)
        {
            xCoord = _xCoord;
            yCoord = _yCoord;
            fallSpeed = _fallSpeed;
            type = _type;
            active = false;
        }
        
        public void Move(Paddle paddle)
        {
            yCoord += fallSpeed;

            if (active == true && type == 0)
            {
                int n = xCoord - paddle.x;

                if (n > 0)
                {
                    xCoord--;
                }
                else if (n < 0)
                {
                    xCoord++;
                }
            }
        }

        public void DrawPowerUp(System.Drawing.SolidBrush s, System.Windows.Forms.PaintEventArgs e)
        {
            switch (type)
            {
                case 0:
                    s.Color = System.Drawing.Color.Gray;
                    break;
                case 1:
                    s.Color = System.Drawing.Color.Lime;
                    break;
                case 2:
                    s.Color = System.Drawing.Color.White;
                    break;
                case 3:
                    s.Color = System.Drawing.Color.Cyan;
                    break;
                case 4:
                    s.Color = System.Drawing.Color.Red;
                    break;
                case 5:
                    s.Color = System.Drawing.Color.Yellow;
                    break;
                case 6:
                    s.Color = System.Drawing.Color.Orange;
                    break;
                default:
                    s.Color = System.Drawing.Color.White;
                    break;
            }

            e.Graphics.FillRectangle(s, xCoord, yCoord, 20, 20);
        }

        public bool Collision(Paddle paddle)
        {
            System.Drawing.Rectangle rect1 = new System.Drawing.Rectangle(xCoord, yCoord, 20, 20);
            System.Drawing.Rectangle rect2 = new System.Drawing.Rectangle(paddle.x, paddle.y, paddle.width, paddle.height);
            
            if (rect1.IntersectsWith(rect2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
