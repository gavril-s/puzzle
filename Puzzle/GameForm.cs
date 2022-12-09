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
        private PictureBox[,] piecesGrid;
        private PictureBox selectedPicture;
        private Panel returnSelectedTo;

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
            cellsHorizontal = 2;
            cellsVertical = 2;

            this.AllowDrop = true;
            puzzleGridPanel.AllowDrop = true;
            piecesGridPanel.AllowDrop = true;

            puzzleGrid = new PictureBox[cellsHorizontal, cellsVertical];
            piecesGrid = new PictureBox[cellsHorizontal, cellsVertical];
            ImageWidth = puzzleGridPanel.Width;
            ImageHeight = puzzleGridPanel.Height;

            this.MouseMove += mouseMoveHandler;

            for (int row = 0; row < cellsHorizontal; row++)
            {
                for (int column = 0; column < cellsVertical; column++)
                {
                    Point location = new Point(column * (ImageWidth / cellsHorizontal), 
                                               row * (ImageHeight / cellsVertical));

                    puzzleGrid[column, row] = newPiece(location);
                    puzzleGridPanel.Controls.Add(puzzleGrid[column, row]);

                    piecesGrid[column, row] = newPiece(location);
                    piecesGridPanel.Controls.Add(piecesGrid[column, row]);
                }
            }

            fillPiecesGrid();
        }

        private PictureBox newPiece(Point location)
        {
            PictureBox piece = new PictureBox();
            piece = new PictureBox();
            piece.SizeMode = PictureBoxSizeMode.StretchImage;
            piece.Size = new Size(ImageWidth / cellsHorizontal, ImageHeight / cellsVertical);
            piece.AllowDrop = true;
            piece.Location = location;
            piece.Tag = null;

            piece.DragEnter += dragEnterHandler;
            piece.DragDrop += dragDropHandler;
            piece.MouseDown += mouseDownHandler;
            piece.MouseMove += mouseMoveHandler;

            return piece;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = puzzleGridPanel.CreateGraphics();
            base.OnPaint(pe);
            for (int x = 0; x < puzzleGridPanel.Width; x += (ImageWidth / cellsVertical))
            {
                g.DrawLine(Pens.Black, x, 0, x, puzzleGridPanel.Height);
            }

            for (int y = 0; y < puzzleGridPanel.Height; y += (ImageHeight / cellsVertical))
            {
                g.DrawLine(Pens.Black, 0, y, puzzleGridPanel.Width, y);
            }
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

        private void fillPiecesGrid()
        {
            int width = image.Width / cellsHorizontal;
            int height = image.Height / cellsVertical;

            Rectangle destRect = new Rectangle(0, 0, width, height);
            Rectangle sourceRect = new Rectangle(0, 0, width, height);

            Random rand = new Random();

            for (int row = 0; row < cellsVertical; row++)
            {
                sourceRect.X = 0;
                for (int column = 0; column < cellsHorizontal; column++)
                {
                    Bitmap piece = new Bitmap(width, height);
                    using (Graphics gr = Graphics.FromImage(piece))
                    {
                        gr.DrawImage(image, destRect, sourceRect, GraphicsUnit.Pixel);
                    }

                    
                    int rand_column = rand.Next(cellsHorizontal);
                    int rand_row = rand.Next(cellsVertical);  
                    while (piecesGrid[rand_column, rand_row].Image != null)
                    {
                        rand_column = rand.Next(cellsHorizontal);
                        rand_row = rand.Next(cellsVertical);
                    }

                    piecesGrid[rand_column, rand_row].Image = piece;
                    piecesGrid[rand_column, rand_row].Tag = new Point(column * width, row * height);

                    sourceRect.X += width;
                }
                sourceRect.Y += height;
            }
            checkGameEnd();
        }

        private void mouseDownHandler(object sender, EventArgs e)
        {
            selectedPicture = (PictureBox)sender;
            returnSelectedTo = (piecesGridPanel.Controls.Contains(selectedPicture) ? piecesGridPanel : puzzleGridPanel);
            returnSelectedTo.Controls.Remove(selectedPicture);
            selectedPicture.DoDragDrop(selectedPicture, DragDropEffects.All);
        }

        private void mouseMoveHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.None && selectedPicture != null)
            {
                if (returnSelectedTo != null)
                {
                    returnSelectedTo.Controls.Add(selectedPicture);
                    
                }
                selectedPicture = null;
            }
        }

        private void dragEnterHandler(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void dragDropHandler(object sender, DragEventArgs e)
        {
            Point? nearestCell = null;

            Point selectedPictureLocation = puzzleGridPanel.PointToClient(System.Windows.Forms.Control.MousePosition);
            Point correction = new Point((ImageWidth / cellsHorizontal) / 2, (ImageHeight / cellsVertical) / 2);
            selectedPictureLocation.X -= correction.X;
            selectedPictureLocation.Y -= correction.Y;

            if (selectedPictureLocation.X >= 0 && selectedPictureLocation.X <= puzzleGridPanel.Width &&
                selectedPictureLocation.Y >= 0 && selectedPictureLocation.Y <= puzzleGridPanel.Height)
            {
                for (int row = 0; row < cellsHorizontal; row++)
                {
                    for (int column = 0; column < cellsVertical; column++)
                    {
                        Point p = new Point(column * selectedPicture.Width, row * selectedPicture.Height);
                        if (nearestCell == null ||
                            Math.Pow(p.X - selectedPictureLocation.X, 2) + Math.Pow(p.Y - selectedPictureLocation.Y, 2) <
                            Math.Pow(((Point)nearestCell).X - selectedPictureLocation.X, 2) + Math.Pow(((Point)nearestCell).Y - selectedPictureLocation.Y, 2))
                        {
                            nearestCell = p;
                        }   
                    }
                }

                int x = ((Point)nearestCell).X / (ImageWidth / cellsHorizontal);
                int y = ((Point)nearestCell).Y / (ImageHeight / cellsVertical);

                if (selectedPicture.Image != null)
                {
                    Image puzzleImage = puzzleGrid[x, y].Image;
                    puzzleGrid[x, y].Image = new Bitmap(selectedPicture.Image);
                    puzzleGrid[x, y].Tag = selectedPicture.Tag;
                    selectedPicture.Image = (puzzleImage == null ? null : new Bitmap(puzzleImage));
                    selectedPicture.Tag = (puzzleImage == null ? null : puzzleImage.Tag);
                    returnSelectedTo.Controls.Add(selectedPicture);
                }
                returnSelectedTo = null;
            }
            else
            {
                returnSelectedTo.Controls.Add(selectedPicture);
            }

            checkGameEnd();
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
                        puzzleGrid[column, row].Tag == null ||
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
