using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    public partial class StartForm : Form
    {
        private bool destroyed;
        private int ImageWidth;
        private int ImageHeight;

        public StartForm()
        {
            InitializeComponent();
            destroyed = false; 
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            imageBox.AllowDrop = true;
            selectImageButton.Click += selectImageButton_onClick;
            runGameButton.Click += runGameButton_onClick;
            ImageWidth = imageBox.Width;
            ImageHeight = imageBox.Height;
        }

        public bool IsDestoyed()
        {
            return destroyed;
        }

        private void onDestroy()
        {
            destroyed = true;
        }

        private void selectImageButton_onClick(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                imageBox.SizeMode = PictureBoxSizeMode.Zoom;
                imageBox.Image = new Bitmap(open.FileName);
                imageBox.Size = new Size(ImageWidth, ImageHeight);
            }
        }

        private void runGameButton_onClick(object sender, EventArgs e)
        {
            if (imageBox.Image == null)
            {
                return;
            }

            int? rows = getIntFromTextBox(rowsTextBox);
            int? columns = getIntFromTextBox(columnsTextBox);
            
            if (rows == null || columns == null ||
                (int)rows == 0 || (int)columns == 0)
            {
                return;
            }

            Program.getGameForm(imageBox.Image, (int)rows, (int)columns).Show();
            this.Hide();
        }

        private int? getIntFromTextBox(TextBox tx)
        {
            if (tx == null || tx.Text == "")
            {
                return null;
            }

            try
            {
                int res = int.Parse(tx.Text);
                return res;
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
