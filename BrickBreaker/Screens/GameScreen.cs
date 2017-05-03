/*  Created by: Steven HL
 *  Project: Brick Breaker
 *  Date: Tuesday, April 4th
 */ 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using BrickBreaker;
using BrickBreaker.Screens;


namespace BrickBreaker.Screens
{
    public partial class GameScreen : UserControl
    {
        #region global values

        #region Stefan and Jack's values
        // Creates powerup list
        List<PowerUp> powerUps = new List<PowerUp>();
        List<PowerUp> activePowerUps = new List<PowerUp>();

        int longPaddleCounter = 0;
        bool longPaddle = false;
        bool isMagnet = false;
        int isMagnetTimer = 0;
        bool floor = false;
        int floorTimer = 0;

        Paddle floorPaddle;

        SolidBrush powerupBrush = new SolidBrush(Color.Green);
        SolidBrush floorBrush = new SolidBrush(Color.Cyan);
        #endregion

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, spaceDown, escapeDown;

        // Game values

        int lives, ticksSinceHit;

        // Paddle and Ball objects
        Paddle paddle;
        Ball ball;

        // list of all blocks
        List<Block> blocks = new List<Block>();

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);

        //list of all balls
        List<Ball> balls = new List<Ball>();

#endregion


        //checkpoint

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        public void OnStart()
        {
            //Resets score
            Form1.currentScore = 0;

            #region Stefan and Jacks Powerups
            //initiate floor paddle
            floorPaddle = new Paddle(0, this.Height - 10, this.Width, 10, 0, Color.Cyan);
            #endregion

            //set life counter
            lives = 3;

            //sets ticks since paddle hit to initialize at zero
            ticksSinceHit = 100;

            //set all button presses to false.
            leftArrowDown = downArrowDown = rightArrowDown = upArrowDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 80;
            int paddleHeight = 20;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = (this.Height - paddleHeight) - 60;
            int paddleSpeed = 8;

            //add player 1 paddle
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballX = ((this.Width / 2) - 10);
            int ballY = (this.Height - paddle.height) - 80;

            // Creates a new ball
            int xSpeed = 6;
            int ySpeed = 6;
            int ballSize = 20;
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);

            balls.Add(ball);

            // Creates blocks for generic level
            blocks.Clear();
            int x = 10;

            while (blocks.Count < 12)
            {
                x += 57;
                Block b1 = new Block(x, 10, 1, Color.White);
                blocks.Add(b1);
            }

            // start the game engine loop
            gameTimer.Enabled = true;
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
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
                case Keys.Escape:
                    escapeDown = false;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
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
                case Keys.Escape:
                    escapeDown = true;
                    manuel();
                    break;
                default:
                    break;
            }

            switch (e.KeyCode)
            {
                case Keys.A:
                    leftArrowDown = false;
                    break;
                case Keys.S:
                    downArrowDown = false;
                    break;
                case Keys.D:
                    rightArrowDown = false;
                    break;
                case Keys.W:
                    upArrowDown = false;
                    break;
                case Keys.Q:
                    spaceDown = false;
                    break;
                default:
                    break;
            }

        }

        public void manuel()
        {
            gameTimer.Enabled = false;

            DialogResult result = PauseScreen.Show("Quit the Game?", "Testing", "Yes", "No");

            switch (result)
            {
                case DialogResult.No:
                    gameTimer.Enabled = true;
                    escapeDown = false;
                    leftArrowDown = false;
                    rightArrowDown = false;
                    break;

                case DialogResult.Yes:
                    Application.Exit();
                    break;          
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Move the paddle
            if (leftArrowDown && paddle.x > 0)
            {
                paddle.Move("left");
            }
            if (rightArrowDown && paddle.x < (this.Width - paddle.width))
            {
                paddle.Move("right");
            }

            #region Stefan and Jacks PowerUps

            if (isMagnetTimer > 0 && isMagnet == true)
            {
                isMagnetTimer--;
            }
            else if (isMagnetTimer <= 0 && isMagnet == true)
            {
                isMagnet = false;
            }

            if (longPaddle == true)
            {
                longPaddleCounter++;
                if (longPaddleCounter >= 14 && paddle.width > 80)
                {
                    longPaddleCounter = 0;
                    paddle.x++;
                    paddle.width -= 2;
                }
                else if (paddle.width <= 80 && longPaddleCounter >= 14)
                {
                    longPaddleCounter = 0;
                    longPaddle = false;
                }
            }

            if (floor == true && floorTimer <= 0)
            {
                floor = false;
            }
            else if (floor == true && floorTimer > 0)
            {
                floorTimer--;
                if (ball.PaddleCollision(floorPaddle, false, false, 100) == 0)
                {
                    floorTimer = 0;
                }
            }

            // Moves powerups
            MovePowerups(powerUps);

            // Check for collision with powerups and paddle
            CollidePowerUps(paddle);
            #endregion

            // Moves balls
            foreach (Ball b in balls)
            {
                b.Move();
                
                // Check for collision with top and side walls
                b.WallCollision(this);
            }
            // Moves powerups
            MovePowerups(powerUps);

            // Check for collision with powerups and paddle
            CollidePowerUps(paddle);

            

            // Check for collision of ball with paddle, (incl. paddle movement)

            ticksSinceHit = ball.PaddleCollision(paddle, leftArrowDown, rightArrowDown, ticksSinceHit);

            foreach (Ball ba in balls)
            {

                // Check if each ball has collided with any blocks
                foreach (Block b in blocks)
                {
                    if (ba.BlockCollision(b))

                    {
                        //decreases struck block hp and removes blocks with hp 0
                        b.hp--;
                        if (b.hp == 0)
                            blocks.Remove(b);

                        Form1.currentScore += 100;

                        GeneratePowerUp(b.x, b.y);

                        if (blocks.Count == 0)
                        {
                            gameTimer.Enabled = false;

                            OnEnd();
                        }

                        break;
                    }
                }

                // Check for ball hitting bottom of screen
                if (ba.BottomCollision(this))
                {
                    if (balls.Count > 1) { balls.Remove(ba); }
                    else
                    {
                        lives--;

                        // Moves the ball back to origin
                        ba.x = ((paddle.x - (ba.size / 2)) + (paddle.width / 2));
                        ba.y = (this.Height - paddle.height) - 85;
                    }



                    if (lives == 0)
                    {
                        gameTimer.Enabled = false;

                        OnEnd();
                    }

                    break;
                }
            }

            //redraw the screen
            Refresh();
        }

        public void OnEnd()
        {
            // Goes to the game over screen
            Form form = this.FindForm();

            LoseScreen ls = new LoseScreen();

            ls.Location = new Point((form.Width - ls.Width) / 2, (form.Height - ls.Height) / 2);

            form.Controls.Add(ls);
            form.Controls.Remove(this);
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Draws paddle
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);

            // Draws blocks
            foreach (Block b in blocks)
            {
                e.Graphics.FillRectangle(blockBrush, b.x, b.y, b.width, b.height);
            }

            #region Stefan and Jacks Powerups
            // Draws Powerups
            DrawPowerups(e);

            if (floor == true)
            {
                e.Graphics.FillRectangle(floorBrush, floorPaddle.x, floorPaddle.y, floorPaddle.width, floorPaddle.height);
            }
            #endregion

            DrawPowerups(e);

            // Draws balls
            e.Graphics.FillRectangle(ballBrush, ball.x, ball.y, ball.size, ball.size);

        }

        #region Stefan and Jack's Powerup Methods
        public void GeneratePowerUp(int brickX, int brickY)
        {
            Random n = new Random();

            if (n.Next(0, 1) == 0)
            {
                PowerUp p = new PowerUp(brickX, brickY, 20, 3, n.Next(0, 7));
                powerUps.Add(p);
            }
        }

        public void MovePowerups(List<PowerUp> powerUps)
        {
            foreach (PowerUp p in powerUps)
            {
                p.Move(paddle, isMagnet);
            }
        }

        public void DrawPowerups(PaintEventArgs e)
        {
            foreach (PowerUp p in powerUps)
            {
                p.DrawPowerUp(powerupBrush, e);
            }
        }

        public void CollidePowerUps(Paddle paddle)
        {
            foreach (PowerUp p in powerUps)
            {
                if (p.Collision(paddle) == true)
                {
                    powerUps.Remove(p);
                    activePowerUps.Add(p);
                    break;
                }
            }
        }       
        #endregion
    }
}
