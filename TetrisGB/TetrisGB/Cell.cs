using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGB
{

    public enum CellKind {
        Block,
        Border,
        Tetromino,
        FreeSpace
    }


    public class Cell
    {
        public CellKind CellKind { get; private set; }

        public override string ToString()
        {
            switch(CellKind)
            {
                case CellKind.Border:
                    return "* ";
                case CellKind.FreeSpace:
                    return "  ";
               default:
                    return "  ";
            }  
        }

        public Cell (CellKind cellKind)
        {
            CellKind = cellKind;

        }
    }
}
