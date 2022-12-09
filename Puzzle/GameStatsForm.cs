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
    public partial class GameStatsForm : Form
    {
        private const string secondsPrefix = "Время (в секундах): ";
        private const string clicksPrefix = "Количество кликов: ";
        private const string piecesPrefix = "Количество элементов в пазле: ";
        private bool destroyed = false;

        public GameStatsForm(int seconds, int clicks, int pieces)
        {
            InitializeComponent();
            secondsLabel.Text = secondsPrefix + seconds.ToString();
            clicksLabel.Text = clicksPrefix + clicks.ToString();
            piecesLabel.Text = piecesPrefix + pieces.ToString();
        }

        public bool IsDestroyed()
        {
            return destroyed;
        }

        private void onDestroy()
        {
            destroyed = true;
        }
    }
}
