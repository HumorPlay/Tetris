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

        public Board()
        {

            boardHeight = 24;
            boardWidth = 10;

            cells = new Cell[boardHeight][];

            InitFreeSpaces();
            InitBoarders();

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





    }
}
