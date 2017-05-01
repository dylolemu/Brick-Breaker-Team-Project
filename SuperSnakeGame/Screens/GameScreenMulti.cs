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
namespace SuperSnakeGame.Screens
{
    public partial class GameScreenMulti : UserControl
    {

        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, spaceDown;


        //player2 button control keys - DO NOT CHANGE
        Boolean aKeyDown, sKeyDown, dKeyDown, wKeyDown, qKeyDown;

        // Game values
        int p1HP = 12;
        int p2HP = 12;

        // Paddle and Ball objects
        Paddle paddle, paddle2;
        Ball ball;

        // list of all blocks
        List<Block> blocks1p = new List<Block>();
        List<Block> blocks2p = new List<Block>();

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);

        #endregion

        public GameScreenMulti()
        {
            InitializeComponent();
            OnStart();
        }

        public void OnStart()
        {
            //display player hp's
            hpLabelp1.Text = "HP: " + p1HP.ToString();
            hpLabelp2.Text = "HP: " + p2HP.ToString();

            //set all button presses to false.
            leftArrowDown = downArrowDown = rightArrowDown = upArrowDown = false;

            //set player 2 button presses to false
            aKeyDown = sKeyDown = dKeyDown = wKeyDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 80;
            int paddleHeight = 20;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = (this.Height - paddleHeight) - 60;
            int paddle2X = ((this.Width / 2) - (paddleWidth / 2));
            int paddle2Y = 60;
            int paddleSpeed = 8;

            //add both paddles
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);
            paddle2 = new Paddle(paddle2X, paddle2Y, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballX = ((this.Width / 2) - 10);
            int ballY = (this.Height - paddle.height) - 80;

            // Creates a new ball
            int xSpeed = 6;
            int ySpeed = 6;
            int ballSize = 20;
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);

            // Creates blocks for generic level
            blocks1p.Clear();
            blocks2p.Clear();
            int x = 10;
            
            //blocks in this mode will always be the same
            while (blocks2p.Count < 12)
            {
                x += 57;
                Block b1 = new Block(x, 10, 1, Color.White);
                blocks2p.Add(b1);
            }
            x = 10;
            while (blocks1p.Count < 12)
            {
                
                x += 57;
                Block b2 = new Block(x, 500, 1, Color.White);
                blocks1p.Add(b2);
            }

            // start the game engine loop
            gameTimer.Enabled = true;
        }

        private void GameScreenMulti_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                default:
                    break;
            }

            //player 2 button presses
            switch (e.KeyCode)
            {
                case Keys.A:
                    aKeyDown = true;
                    break;
                case Keys.S:
                    sKeyDown = true;
                    break;
                case Keys.D:
                    dKeyDown = true;
                    break;
                case Keys.W:
                    wKeyDown = true;
                    break;
                case Keys.Q:
                    qKeyDown = true;
                    break;
                default:
                    break;
            }

        }

        private void GameScreenMulti_KeyUp(object sender, KeyEventArgs e)
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
                default:
                    break;
            }

            //added by daniel
            //player 2 releases
            switch (e.KeyCode)
            {
                case Keys.A:
                    aKeyDown = false;
                    break;
                case Keys.S:
                    sKeyDown = false;
                    break;
                case Keys.D:
                    dKeyDown = false;
                    break;
                case Keys.W:
                    wKeyDown = false;
                    break;
                case Keys.Q:
                    qKeyDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Move the paddle for p1
            if (leftArrowDown && paddle.x > 0)
            {
                paddle.Move("left");
            }
            if (rightArrowDown && paddle.x < (this.Width - paddle.width))
            {
                paddle.Move("right");
            }

            //move the paddle for p2
            if (aKeyDown && paddle2.x > 0)
            {
                paddle2.Move("left");
            }
            if (dKeyDown && paddle2.x < (this.Width - paddle2.width))
            {
                paddle2.Move("right");
            }

            // Moves ball
            ball.Move();

            // Check for collision with top and side walls
            ball.WallCollision(this);

            // Check for collision of ball with paddle, (incl. paddle movement)

            ball.PaddleCollision(paddle, leftArrowDown, rightArrowDown);
            ball.PaddleCollision(paddle2, aKeyDown, dKeyDown);

            // Check if ball has collided with any of player 1 blocks
            foreach (Block b in blocks1p)
            {
                if (ball.BlockCollision(b))
                {
                    b.hp--;
                    if (b.hp == 0)
                        blocks1p.Remove(b);
                    //reduce life of player
                    p1HP--;

                    hpLabelp1.Text = "HP: " + p1HP.ToString();
                    if (blocks1p.Count == 0 && p1HP >= 0)
                    {
                        gameTimer.Enabled = false;
                        //TODO say who won
                        OnEnd();
                    }

                    break;
                }
            }
            // Check if ball has collided with any of player 2 blocks
            foreach (Block b in blocks2p)
            {
                if (ball.BlockCollision(b))
                {
                    b.hp--;
                    if (b.hp == 0)
                        blocks2p.Remove(b);

                    p2HP--;

                    hpLabelp2.Text = "HP: " + p2HP.ToString();
                    if (blocks2p.Count == 0 && p2HP >= 0)
                    {
                        gameTimer.Enabled = false;

                        OnEnd();
                    }

                    break;
                }
            }

            // Check for ball hitting bottom of screen
            if (ball.BottomCollision(this))
            {
                // Moves the ball back to origin
                ball.ySpeed *= -1;
            }

            //redraw the screen
            Refresh();
        }

        public void OnEnd()
        {
            // Goes to the game over screen
            Form form = this.FindForm();
            MenuScreen ps = new MenuScreen();

            ps.Location = new Point((form.Width - ps.Width) / 2, (form.Height - ps.Height) / 2);

            form.Controls.Add(ps);
            form.Controls.Remove(this);
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Draws paddles
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);
            e.Graphics.FillRectangle(paddleBrush, paddle2.x, paddle2.y, paddle.width, paddle.height);

            // Draws blocks
            foreach (Block b in blocks1p)
            {
                e.Graphics.FillRectangle(blockBrush, b.x, b.y, b.width, b.height);
            }
            foreach (Block b in blocks2p)
            {
                e.Graphics.FillRectangle(blockBrush, b.x, b.y, b.width, b.height);
            }

            // Draws balls
            e.Graphics.FillRectangle(ballBrush, ball.x, ball.y, ball.size, ball.size);
        }

    }
}
