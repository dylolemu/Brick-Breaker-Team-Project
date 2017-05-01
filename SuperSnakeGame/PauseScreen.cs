using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker.Screens
{
    public partial class PauseScreen : UserControl
    {
        public static int start;

        public PauseScreen()
        {
            InitializeComponent();
        }

        private void resumeButton_Click(object sender, EventArgs e)
        {
            start = 1;
            Form f = this.FindForm();
            f.Controls.Remove(this);

            GameScreen gs = new GameScreen();
            f.Controls.Add(gs);

            gs.Focus();

            gs.Location = new Point((this.Width - gs.Width) / 2, (this.Height - gs.Height) / 2);

        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
