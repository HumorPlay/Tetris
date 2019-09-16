using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGB
{
    class TetrominoManager
    {

        public TetrominoManager()
        {
            InitDefaultTetrominos();
        }

        private readonly Tetromino[] defaultTetromonos = new Tetromino[7];

        private void InitDefaultTetrominos()
        {
            Tetromino tetrominoI = new Tetromino();
            tetrominoI.Kind = TetrominoKind.I;
            tetrominoI.units[0] = new Unit(0, 4);
            tetrominoI.units[1] = new Unit(1, 4);
            tetrominoI.units[2] = new Unit(2, 4);
            tetrominoI.units[3] = new Unit(3, 4);

            defaultTetromonos[0] = tetrominoI;

        }

        public Tetromino GetRandomTetromino()
        {
            return defaultTetromonos[0];

        }

    }
}
