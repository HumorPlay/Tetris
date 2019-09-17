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
            for (int i = 0; i < boardHeight - 1; i++)
            {
                cells[i] = new Cell[boardWidth];
                for (int j = 1; j < boardWidth - 1; j++)
                    cells[i][j] = new Cell(CellKind.FreeSpace);
            }
        }


        private void InitBoarders()
        {
            cells[boardHeight - 1] = new Cell[boardWidth];
            for (int i = 0; i < boardHeight; i++)
            {
                cells[i][0] = new Cell(CellKind.Border);
                cells[i][boardWidth - 1] = new Cell(CellKind.Border);
            }
            for (int i = 0; i < boardWidth; i++)
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

        public override string ToString()
        {
            Show();
            return String.Empty;
        }

        private void AddTetraminoToBoard()
        {
            foreach (Unit i in currentTetramino.units)
                cells[i.Row][i.Column].TransformToTetramino();

        }

        public void MoveTetromino(MoveDirection direction)
        {

            HideTetromino();
            switch (direction)
            {

                case MoveDirection.Down:
                    if (!CanMoveDown(1))
                        PlaceTetramino(instantly: false);
                    else
                    {
                        for (int i = 0; i < currentTetramino.units.Length; i++)
                            currentTetramino.units[i].Row += 1;
                    }
                    break;
                case MoveDirection.InstantlyDown:
                    PlaceTetramino(instantly: true);
                    break;
                case MoveDirection.Right:
                case MoveDirection.Left:
                    bool right = direction == MoveDirection.Right;
                    int offset = right ? 1 : -1;

                    if (ClashWithBloskOrBorders(currentTetramino, offset))
                        break;

                    for (int i = 0; i < currentTetramino.units.Length; i++)
                        currentTetramino.units[i].Column = currentTetramino.units[i].Column + offset;
                    break;
                case MoveDirection.Rotate:
                    if (currentTetramino.Kind == TetrominoKind.O)
                        break;
                    Tetromino rotated = manager.Rotate(currentTetramino);

                    if (!ClashWithBloskOrBorders(rotated))
                        currentTetramino = rotated;
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
            foreach (Unit i in tetromino.units)
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
        private bool CanMoveDown(int step)
        {
            foreach (Unit i in currentTetramino.units)
            {
                if (cells[i.Row + step][i.Column].IsblockOrBorder)
                    return false;
            }
            return true;
        }
        private void PlaceTetramino(bool instantly)
        {
            if (instantly)
                MoveDownInstantly();

            foreach (Unit i in currentTetramino.units)
                cells[i.Row][i.Column].TransformToBlock();

            if (EndGame())
            {
                Game.EndGame();
                return;
            }

            RemoveBlocks();
            currentTetramino = manager.GetRandomTetromino();
        }

        public void MoveDownInstantly()
        {
            int step = 0;

            while (true)
            {
                if (!CanMoveDown(step + 1))
                {
                    for (int i = 0; i < currentTetramino.units.Length; i++)
                        currentTetramino.units[i].Row = currentTetramino.units[i].Row + step;
                    break;

                }
                step++;

            }
        }
        private bool EndGame()
        {

            foreach (Cell cell in cells[4])
            {
                if (cell.CellKind == CellKind.Block)
                    return true;
            }
            return false;
        }
        private void RemoveBlocks()
        {
            for (int i = 0; i < boardHeight - 1; i++)
            {
                if (HasFreeSpace(cells[i]))
                    continue;


                for (int j = 1; j < boardWidth - 1; j++)
                {
                    cells[i][j] = new Cell(CellKind.FreeSpace);
                }

                for (int j = i - 1; j > 0; j--)
                {
                    for (int k = 1; k < boardWidth - 1; k++)
                    {
                        CellKind kind = cells[j][k].CellKind;
                        if (kind == CellKind.FreeSpace)
                            continue;

                        Cell cell = cells[j][k];
                        cells[j][k] = new Cell(CellKind.FreeSpace);
                        cells[j + 1][k] = cell;

                    }
                }
            }

        }
        private bool HasFreeSpace(Cell[] cellRow)
        {
            foreach (Cell cell in cellRow)
            {
                if (cell.CellKind == CellKind.FreeSpace)
                    return true;
            }
            return false;
        }
    }
}
