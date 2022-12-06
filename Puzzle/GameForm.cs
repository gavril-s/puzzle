using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    public partial class GameForm : Form
    {
        private bool destroyed;
        private int cellsHorizontal;
        private int cellsVertical;
        private Image image;
        private int ImageWidth;
        private int ImageHeight;
        private PictureBox[,] puzzleGrid;

        public GameForm()
        {
            InitializeComponent();
            destroyed = false;
        }

        public GameForm(Image img)
        {
            InitializeComponent();
            destroyed = false;
            image = new Bitmap(img);
            cellsHorizontal = 10;
            cellsVertical = 10;
            puzzleGrid = new PictureBox[cellsHorizontal, cellsVertical];    
            ImageWidth = puzzleGridPanel.Width;
            ImageHeight = puzzleGridPanel.Height;
            cutImage();
        }

        public bool IsDestroyed()
        {
            return destroyed;
        }

        private void onDestroy()
        {
            destroyed = true;
            Program.getStartForm().Show();
        }

        private void cutImage()
        {
            int width = image.Width / cellsHorizontal;
            int height = image.Height / cellsVertical;

            Rectangle destRect = new Rectangle(0, 0, width, height);
            Rectangle sourceRect = new Rectangle(0, 0, width, height);

            for (int row = 0; row < cellsVertical; row++)
            {
                sourceRect.X = 0;
                for (int column = 0; column < cellsVertical; column++)
                {
                    Bitmap piece = new Bitmap(width, height);
                    using (Graphics gr = Graphics.FromImage(piece))
                    {
                        gr.DrawImage(image, destRect, sourceRect, GraphicsUnit.Pixel);
                    }

                    //string filename = row.ToString("00") + column.ToString("00") + ".png";
                    //piece.Save(filename, System.Drawing.Imaging.ImageFormat.Png);

                    //Console.WriteLine(filename);

                    PictureBox piecePictureBox = new PictureBox();
                    piecePictureBox.MouseMove += imagePiece_onMove;
                    piecePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    piecePictureBox.Image = piece;
                    piecePictureBox.Size = new Size(ImageWidth / cellsHorizontal, ImageHeight / cellsVertical);
                    piecePictureBox.Location = new Point(column * piecePictureBox.Width, row * piecePictureBox.Height);
                    piecePictureBox.Tag = new Point(column * piecePictureBox.Width, row * piecePictureBox.Height);
                    puzzleGridPanel.Controls.Add(piecePictureBox);
                    puzzleGrid[column, row] = piecePictureBox;

                    sourceRect.X += width;
                }
                sourceRect.Y += height;
            }
            checkGameEnd();
        }

        private void imagePiece_onMove(object sender, EventArgs e)
        {
            Console.WriteLine("MOVE");
        }

        private bool checkGameEnd()
        {
            if (puzzleCompleted())
            {
                endGame();
                return true;
            }
            return false;
        }

        private bool puzzleCompleted()
        {
            for (int column = 0; column < cellsHorizontal; column++)
            {
                for (int row = 0; row < cellsVertical; row++)
                {
                    if (puzzleGrid[column, row] == null ||
                        puzzleGrid[column, row].Location != (Point)puzzleGrid[column, row].Tag)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void endGame()
        {
            Program.getGameEndForm().Show();
        }
    }
}
