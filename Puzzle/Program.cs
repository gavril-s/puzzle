using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    internal static class Program
    {
        private static StartForm startForm;
        private static GameForm gameForm;

        public static StartForm getStartForm()
        {
            if (startForm == null)
            {
                startForm = new StartForm();
            }
            return startForm;
        }

        public static GameForm getGameForm(Image img=null)
        {
            if (img != null)
            {
                gameForm = new GameForm(img);
            }

            if (gameForm == null || gameForm.IsDestroyed())
            {
                gameForm = new GameForm();
            }

            return gameForm;
        }

        public static GameEndForm getGameEndForm()
        {
            return new GameEndForm();
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            startForm = getStartForm();
            Application.Run(startForm);
        }
    }
}
