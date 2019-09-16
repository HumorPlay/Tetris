using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGB
{
    class Tetromino
    {
        public TetrominoKind Kind { get; set; }
        public Unit[] units = new Unit[4];


    }
    public enum TetrominoKind { I, O, T, J, L, S, Z }

    public struct Unit
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Unit (int row, int column)
        {
            Row = row;
            Column = column;

        }

    }
}
