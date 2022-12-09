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
    public partial class GameEndForm : Form
    {
        private int seconds;
        private int clicks;
        private int pieces;
        bool destroyed = false;
        
        public GameEndForm(int seconds, int clicks, int pieces)
        {
            InitializeComponent();
            this.seconds = seconds;
            this.clicks = clicks;
            this.pieces = pieces;

            statsButton.Click += statsButton_onClick;
            newGameButton.Click += newGameButton_onClick;
        }

        public bool IsDestroyed()
        {
            return destroyed;
        }

        private void onDestroy()
        {
            destroyed = true;
            Program.getGameForm().Close();
        }

        private void statsButton_onClick(object sender, EventArgs e)
        {
            Program.getGameStatsForm(seconds, clicks, pieces).Show();
        }

        private void newGameButton_onClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
