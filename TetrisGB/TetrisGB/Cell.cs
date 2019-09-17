using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGB
{

    public enum CellKind
    {
        Block,
        Border,
        Tetromino,
        FreeSpace
    }


    public class Cell
    {
        public CellKind CellKind { get; private set; }

        public bool IsblockOrBorder
        {
            get
            {
                return CellKind == CellKind.Block || CellKind == CellKind.Border;
            }
        }

        public override string ToString()
        {
            switch (CellKind)
            {
                case CellKind.Tetromino:
                    return "■ ";
                case CellKind.Border:
                    return "* ";
                case CellKind.FreeSpace:
                    return "  ";
                default:
                    return "  ";
            }
        }

        public Cell(CellKind cellKind)
        {
            CellKind = cellKind;

        }

        public void TransformToTetramino()
        {
            CellKind = CellKind.Tetromino;
        }

        public void TransformToFreeSpace()
        {
            CellKind = CellKind.FreeSpace;
        }

    }
}
