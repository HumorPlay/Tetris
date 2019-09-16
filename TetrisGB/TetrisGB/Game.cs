using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGB
{
    public class Game
    {
        private Board board;

        public Game()
        {
            Init();
        }

        private void Init()
        {
            Console.CursorVisible = false;
            board = new Board();
            Console.WindowWidth = 66;
            Console.WindowHeight = 32;
            board.Show();
        }

    }
}
