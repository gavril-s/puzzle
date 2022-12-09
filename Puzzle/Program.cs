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
        private static GameEndForm gameEndForm;
        private static GameStatsForm gameStatsForm;

        public static StartForm getStartForm()
        {
            if (startForm == null)
            {
                startForm = new StartForm();
            }
            return startForm;
        }

        public static GameForm getGameForm()
        {
            return gameForm;
        }

        public static GameForm getGameForm(Image img, int rows, int columns)
        {
            if (gameForm != null)
            {
                gameForm.Dispose();
            }
            gameForm = new GameForm(img, rows, columns);
            return gameForm;
        }

        public static GameEndForm getGameEndForm()
        {
            return gameEndForm;
        }

        public static GameEndForm getGameEndForm(int sec, int clicks, int pieces)
        {
            gameEndForm = new GameEndForm(sec, clicks, pieces);
            return gameEndForm;
        }

        public static GameStatsForm getGameStatsForm()
        {
            return gameStatsForm;
        }

        public static GameStatsForm getGameStatsForm(int sec, int clicks, int pieces)
        {
            gameStatsForm = new GameStatsForm(sec, clicks, pieces);
            return gameStatsForm;
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
