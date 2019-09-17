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

            Tetromino tetrominoO = new Tetromino();
            tetrominoO.Kind = TetrominoKind.O;
            tetrominoO.units[0] = new Unit(0, 4);
            tetrominoO.units[1] = new Unit(1, 4);
            tetrominoO.units[2] = new Unit(0, 5);
            tetrominoO.units[3] = new Unit(1, 5);
            defaultTetromonos[1] = tetrominoO;

            Tetromino tetrominoT = new Tetromino();
            tetrominoT.Kind = TetrominoKind.T;
            tetrominoT.units[0] = new Unit(0, 4);
            tetrominoT.units[1] = new Unit(1, 4);
            tetrominoT.units[2] = new Unit(0, 5);
            tetrominoT.units[3] = new Unit(0, 3);
            defaultTetromonos[2] = tetrominoT;

            Tetromino tetrominoZ = new Tetromino();
            tetrominoZ.Kind = TetrominoKind.Z;
            tetrominoZ.units[0] = new Unit(0, 4);
            tetrominoZ.units[1] = new Unit(1, 4);
            tetrominoZ.units[2] = new Unit(0, 3);
            tetrominoZ.units[3] = new Unit(1, 5);
            defaultTetromonos[3] = tetrominoZ;

            Tetromino tetrominoS = new Tetromino();
            tetrominoS.Kind = TetrominoKind.S;
            tetrominoS.units[0] = new Unit(0, 4);
            tetrominoS.units[1] = new Unit(1, 4);
            tetrominoS.units[2] = new Unit(1, 3);
            tetrominoS.units[3] = new Unit(0, 5);
            defaultTetromonos[4] = tetrominoS;

            Tetromino tetrominoJ = new Tetromino();
            tetrominoJ.Kind = TetrominoKind.J;
            tetrominoJ.units[0] = new Unit(0, 4);
            tetrominoJ.units[1] = new Unit(1, 5);
            tetrominoJ.units[2] = new Unit(0, 5);
            tetrominoJ.units[3] = new Unit(0, 3);
            defaultTetromonos[5] = tetrominoJ;

            Tetromino tetrominoL = new Tetromino();
            tetrominoL.Kind = TetrominoKind.L;
            tetrominoL.units[0] = new Unit(0, 4);
            tetrominoL.units[1] = new Unit(1, 3);
            tetrominoL.units[2] = new Unit(0, 5);
            tetrominoL.units[3] = new Unit(0, 3);
            defaultTetromonos[6] = tetrominoL;
        }

        public Tetromino GetRandomTetromino()
        {
            return defaultTetromonos[3];

        }

    }
}
