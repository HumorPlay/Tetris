using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGB
{
    public class Board
    {
        private readonly Cell[][] cells;

        private readonly int boardHeight;
        private readonly int boardWidth;

        private Tetromino currentTetramino;
        private readonly TetrominoManager manager;

        public Board()
        {

            boardHeight = 24;
            boardWidth = 10;

            cells = new Cell[boardHeight][];

            InitFreeSpaces();
            InitBoarders();

            manager = new TetrominoManager();
            currentTetramino = manager.GetRandomTetromino();

            AddTetraminoToBoard();

        }

        private void InitFreeSpaces()
        {
            for (int i = 0; i < boardHeight-1; i++)
            {
                cells[i] = new Cell[boardWidth];
                for(int j =1; j < boardWidth-1; j++)                
                    cells[i][j] = new Cell(CellKind.FreeSpace);                
            }
        }


        private void InitBoarders()
        {
            cells[boardHeight-1] = new Cell[boardWidth];
            for(int i=0; i < boardHeight; i++)
            {
                cells[i][0] = new Cell(CellKind.Border);
                cells[i][boardWidth - 1] = new Cell(CellKind.Border);
            }
            for (int i=0; i < boardWidth; i++)            
                cells[boardHeight - 1][i] = new Cell(CellKind.Border);        

        }

        public void Show()
        {
            for (int i = 0; i < boardHeight; i++)
            {
                Console.SetCursorPosition(0, i);

                for (int j = 0; j < boardWidth; j++)
                    Console.Write(cells[i][j]);             

            }

        }

        private void AddTetraminoToBoard()
        {
            foreach (Unit i in currentTetramino.units)
                cells[i.Row][i.Column].TransformToTetramino();

        }

        public void MoveTetromino(MoveDirection direction)
        {

            HideTetromino();
            switch(direction)
            {
                case MoveDirection.Right:
                case MoveDirection.Left:
                    bool right = direction == MoveDirection.Right;
                    int offset = right ? 1 : -1;

                    if (ClashWithBloskOrBorders(currentTetramino, offset))
                        break;

                    for (int i = 0; i < currentTetramino.units.Length; i++)
                        currentTetramino.units[i].Column = currentTetramino.units[i].Column + offset;
                    break;
            }
            AddTetraminoToBoard();
        }

        private void HideTetromino()
        {
            foreach (Unit i in currentTetramino.units)
                cells[i.Row][i.Column].TransformToFreeSpace();
        }

        private bool ClashWithBloskOrBorders(Tetromino tetromino, int offset = 0)
        {
            foreach(Unit i in tetromino.units)
            {
                if (i.Column + offset < 0)
                    return true;
                if (i.Column + offset > 9)
                    return true;
                if (cells[i.Row][i.Column + offset].IsblockOrBorder)
                    return true;
            }
            return false;
        }
    }
}
