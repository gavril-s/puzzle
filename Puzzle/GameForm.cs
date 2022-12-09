using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private bool end;

        // размеры пазла
        private int cellsHorizontal;
        private int cellsVertical;

        // исходное изображение
        // и его размеры
        private Image image;
        private int ImageWidth;
        private int ImageHeight;

        // поле, на котором игрок собирает пазл
        private PictureBox[,] puzzleGrid;

        // поле, где изначально располагаются
        // перемешанные элементы
        private PictureBox[,] piecesGrid; 

        // переносимый пользователем элемент
        // (может быть null)
        // и панель, куда его следует вернуть,
        // если переместить не удалось
        private PictureBox selectedPicture;
        private Panel returnSelectedTo;

        // счётчик секунд, прошедших
        // с начала игры
        private Stopwatch stopwatch;

        // счётчик кликов, сделанных
        // пользователем
        private int clicks;

        public GameForm()
        {
            InitializeComponent();
            destroyed = false;
        }

        public GameForm(Image img, int rows, int columns)
        {
            /*
             * Конструктор игрового поля,
             * принимающий в качестве аргументов
             * изображение, которое нужно будет собрать
             * из кусочков пазла, а также количество
             * строк и столбцов в пазле.
            */

            InitializeComponent();
            destroyed = false;
            end = false;
            image = new Bitmap(img);
            cellsHorizontal = columns;
            cellsVertical = rows;

            this.AllowDrop = true;
            puzzleGridPanel.AllowDrop = true;
            piecesGridPanel.AllowDrop = true;

            puzzleGrid = new PictureBox[cellsHorizontal, cellsVertical];
            piecesGrid = new PictureBox[cellsHorizontal, cellsVertical];
            ImageWidth = puzzleGridPanel.Width;
            ImageHeight = puzzleGridPanel.Height;

            this.MouseMove += mouseMoveHandler;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            for (int row = 0; row < cellsVertical; row++)
            {
                for (int column = 0; column < cellsHorizontal; column++)
                {
                    /*
                     * Заполняем оба поля игры пустыми
                     * элементами, который представлены
                     * PictureBox'ами
                    */

                    Point location = new Point(column * (ImageWidth / cellsHorizontal), 
                                               row * (ImageHeight / cellsVertical));

                    puzzleGrid[column, row] = newPiece(location);
                    puzzleGrid[column, row].BorderStyle = BorderStyle.FixedSingle;
                    puzzleGridPanel.Controls.Add(puzzleGrid[column, row]);

                    piecesGrid[column, row] = newPiece(location);
                    piecesGridPanel.Controls.Add(piecesGrid[column, row]);
                }
            }

            // Заполняем piecesGridPanel
            // кусками нашего изображения
            fillPiecesGrid();

            // Запускаем таймер
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        private PictureBox newPiece(Point location)
        {
            /*
             * Функция, создающая пустой элемент пазла
             * (без изображения)
            */

            PictureBox piece = new PictureBox();
            piece = new PictureBox();
            piece.SizeMode = PictureBoxSizeMode.StretchImage;
            piece.Size = new Size(ImageWidth / cellsHorizontal,
                                  ImageHeight / cellsVertical);
            piece.AllowDrop = true;
            piece.Location = location;
            piece.Tag = null;

            piece.DragEnter += dragEnterHandler;
            piece.DragDrop += dragDropHandler;
            piece.MouseDown += mouseDownHandler;
            piece.MouseMove += mouseMoveHandler;

            return piece;
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
            /*
             * Заполняет piecesGridPanel
             * кусками исходного изображения
             * перемешанными в случайном
             * порядке.
            */

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
                    // Вырезаем кусок из изображения
                    Bitmap piece = new Bitmap(width, height);
                    using (Graphics gr = Graphics.FromImage(piece))
                    {
                        gr.DrawImage(image, destRect, sourceRect, GraphicsUnit.Pixel);
                    }

                    // Подбираем место для текущего куска
                    int rand_column = rand.Next(cellsHorizontal);
                    int rand_row = rand.Next(cellsVertical);  
                    while (piecesGrid[rand_column, rand_row].Image != null)
                    {
                        rand_column = rand.Next(cellsHorizontal);
                        rand_row = rand.Next(cellsVertical);
                    }

                    // Устанавливаем
                    piecesGrid[rand_column, rand_row].Image = piece;
                    piecesGrid[rand_column, rand_row].Tag = new Point(column, row);
                    // (В качестве тэга мы ставим настоящие координаты куска пазла,
                    //  то есть то место, где он на самом деле должен стоять.
                    //  Позже, с помощью этого тэга мы проверяем, собран ли пазл.)

                    sourceRect.X += width;
                }
                sourceRect.Y += height;
            }
            checkGameEnd();
        }

        private void mouseDownHandler(object sender, EventArgs e)
        {
            /*
             * Вызывается, когда
             * игрок нажимает кнопку мыши.
             * Устанавливает значение
             * selectedPicture.
            */

            if (end)
            {
                return;
            }
            clicks++;
            selectedPicture = (PictureBox)sender;
            returnSelectedTo = (piecesGridPanel.Controls.Contains(selectedPicture) ?
                                piecesGridPanel : puzzleGridPanel);
            returnSelectedTo.Controls.Remove(selectedPicture);
            selectedPicture.DoDragDrop(selectedPicture, DragDropEffects.All);
        }

        private void mouseMoveHandler(object sender, MouseEventArgs e)
        {
            /*
             * Вызывается, когда игрок перемещает
             * курсор.
             * Используется для того, чтобы отследить
             * момент, когда игрок не нажимает ни одной
             * кнопки мыши и притом returnSelectedTo (то есть
             * панель, на которую нужно вернуть перетаскиваемый
             * элемент, если перетаскивание невозможно)
             * не равен null. 
             * В этом случае нам нужно вернуть этот элемент
             * на место, так как (это будет дальше)
             * когда перетаскивание завершается успешно,
             * returnSelectedTo мы обнуляем.
            */

            if (end)
            {
                return;
            }

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
            /*
             * Вызывается, когда курсор игрока
             * входит в область, где можно
             * сбросить перетаскиваемый им 
             * элемент. Никакой глубинной
             * логики в этой функции нет.
            */

            if (end)
            {
                return;
            }
            e.Effect = DragDropEffects.All;
        }

        private void dragDropHandler(object sender, DragEventArgs e)
        {
            /*
             * Вызывается, когда игрок отпускает кнопку
             * мыши в тот момент, когда его курсор
             * находится в области, где можно сбросить
             * элемент, который он перетаскивает
             * (имеется в виду, что курсор наведён
             * на элемент, свойство которого
             * AllowDrop равно true).
             * Осуществляет сброс перетаскиваемого
             * элемента на панель, где собирается
             * пазл.
            */

            if (end)
            {
                return;
            }
            Point? nearestCell = null;
            Point selectedPictureLocation = puzzleGridPanel.PointToClient(
                System.Windows.Forms.Control.MousePosition);
           
            // Проверяет, находится ли курсор в границах панели,
            // куда нам нужно осуществить сброс
            if (selectedPictureLocation.X >= 0 &&
                selectedPictureLocation.X <= puzzleGridPanel.Width &&
                selectedPictureLocation.Y >= 0 &&
                selectedPictureLocation.Y <= puzzleGridPanel.Height)
            {
                /*
                 * Ищется ближайшая к курсору
                 * клетка панели
                */

                Point correction = new Point(
                    (ImageWidth / cellsHorizontal) / 2,
                    (ImageHeight / cellsVertical) / 2);
                selectedPictureLocation.X -= correction.X;
                selectedPictureLocation.Y -= correction.Y;

                for (int row = 0; row < cellsVertical; row++)
                {
                    for (int column = 0; column < cellsHorizontal; column++)
                    {
                        Point p = new Point(column * selectedPicture.Width,
                                            row * selectedPicture.Height);
                        if (nearestCell == null ||
                            Math.Pow(p.X - selectedPictureLocation.X, 2) +
                            Math.Pow(p.Y - selectedPictureLocation.Y, 2) <
                            Math.Pow(((Point)nearestCell).X - selectedPictureLocation.X, 2) +
                            Math.Pow(((Point)nearestCell).Y - selectedPictureLocation.Y, 2))
                        {
                            nearestCell = p;
                        }   
                    }
                }

                int x = ((Point)nearestCell).X / (ImageWidth / cellsHorizontal);
                int y = ((Point)nearestCell).Y / (ImageHeight / cellsVertical);

                if (selectedPicture.Image != null)
                {
                    /*
                     * Устанавливаем элемент
                     * на новое место
                    */

                    Image puzzleImage = puzzleGrid[x, y].Image;
                    object puzzleTag = puzzleGrid[x, y].Tag;

                    puzzleGrid[x, y].Image = new Bitmap(selectedPicture.Image);
                    puzzleGrid[x, y].Tag = selectedPicture.Tag;
                    selectedPicture.Image = (puzzleImage == null ? 
                                             null : new Bitmap(puzzleImage));
                    selectedPicture.Tag = puzzleTag;
                    returnSelectedTo.Controls.Add(selectedPicture);
                }

                // Обнуляем returnSelectedTo,
                // как было сказано ранее
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
            /*
             * Проверяет, закончилась ли игра.
             * Вызывается после каждого
             * изменения на поле
            */

            if (puzzleCompleted())
            {
                endGame();
                return true;
            }
            return false;
        }

        private bool puzzleCompleted()
        {
            /*
             * Проверяет, собран ли пазл 
            */

            for (int column = 0; column < cellsHorizontal; column++)
            {
                for (int row = 0; row < cellsVertical; row++)
                {
                    // В атрибуте Tag записано исходное положение
                    // кусочка пазла. Он задаётся в функции
                    // fillPiecesGrid

                    if (puzzleGrid[column, row] == null ||
                        puzzleGrid[column, row].Tag == null ||
                        new Point(column, row) != (Point)puzzleGrid[column, row].Tag)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void endGame()
        {
            /*
             * Вызывается, когда 
             * игра завершена.
             * Останавливает счётчик секунд 
             * и вызывает gameEndForm,
             * чтобы сообщить пользователю,
             * что он собрал пазл.
            */

            stopwatch.Stop();
            end = true;
            int seconds = (int)(stopwatch.ElapsedMilliseconds / (long)1000);
            int pieces = cellsHorizontal * cellsVertical;
            Program.getGameEndForm(seconds, clicks, pieces).Show();
        }
    }
}
