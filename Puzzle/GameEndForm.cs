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
        bool destroyed = false;
        public GameEndForm()
        {
            InitializeComponent();
        }

        public bool IsDestroyed()
        {
            return destroyed;
        }

        private void onDestroy()
        {
            Program.getGameForm().Close();
            destroyed = true;
        }
    }
}
