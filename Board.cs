using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Board
    {
        // the board is always sqaure. Usually 8x8
        public int Size { get; set; }

        // 2d array of cell objects 
        public Cell[,] theGrid { get; set; }

        // constructor 
        public Board(int s)
        {
            Size = s;
            // we must initialize the array to avoid Null exception errors.
            theGrid = new Cell[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public bool isSafe(int r, int c)
        {
            if (r < 0 || r >= Size || c < 0 || c >= Size)
            {
                // Console.WriteLine("Pos " + r + ", " + c + " is NOT safe.")
                return false;
            }
            else 
            {
                // Console.WriteLine("Pos " + r + ", " + c + " is safe.")
                return true; 
            }
        }

        public void MarkNextLegalMoves(Cell currentCell, string chessPiece)
        {
            // step 1 - clear all legalMoves from previous turn
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    theGrid[r, c].LegalNextMove = false;
                }
            }

            // step 2 - find all legal moves and mark the square.
            switch (chessPiece)
            {
                case "Knight":
                    if(isSafe(currentCell.RowNumber - 1, currentCell.ColNumber + 2)) 
                    {
                        theGrid[currentCell.RowNumber - 2, currentCell.ColNumber + 1].LegalNextMove = true;
                        theGrid[currentCell.RowNumber - 2, currentCell.ColNumber + 1].LegalNextMove = true;
                        theGrid[currentCell.RowNumber - 1, currentCell.ColNumber + 2].LegalNextMove = true;
                        theGrid[currentCell.RowNumber + 1, currentCell.ColNumber + 2].LegalNextMove = true;
                        theGrid[currentCell.RowNumber - 2, currentCell.ColNumber + 1].LegalNextMove = true;
                        theGrid[currentCell.RowNumber - 2, currentCell.ColNumber - 1].LegalNextMove = true;
                        theGrid[currentCell.RowNumber - 1, currentCell.ColNumber + 2].LegalNextMove = true;
                        theGrid[currentCell.RowNumber - 1, currentCell.ColNumber + 2].LegalNextMove = true;
                    }
                   
                    break;

                case "King":
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber + 0].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 0, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 0, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber + 0].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 1].LegalNextMove = true;

                    break;

                case "Rook":
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber + 0].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 0, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 0, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber + 0].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1,  currentCell.ColNumber - 1].LegalNextMove = true;
                    break;

                case "Bishop":
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber + 0].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 0, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 0, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber + 0].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 1].LegalNextMove = true;
                    break;

                case "Queen":
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber + 0].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 0, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 0, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber + 0].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 1].LegalNextMove = true;

                    break;

                default: 
                    break;
            }
            theGrid[currentCell.RowNumber, currentCell.ColNumber].CurrentlyOccupied = true;
        }
    }
}
