using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker.Screens
{

    public partial class PauseScreen : Form
    {
        public PauseScreen()
        {
            InitializeComponent();
        }

        static PauseScreen pause;
        static public DialogResult result;

        public static DialogResult Show(string Text, string Caption, string btnYes, string btnNo)
        {
            pause = new PauseScreen();
            pause.titleLabel.Text = Text;
            pause.yesButton.Text = btnYes;
            pause.noButton.Text = btnNo;
            pause.ShowDialog();
            return result;
        }

        private void yesButton_Click_1(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            this.Close();
        }

        private void noButton_Click_1(object sender, EventArgs e)
        {
            result = DialogResult.No;
            this.Close();

        }
    }
}
