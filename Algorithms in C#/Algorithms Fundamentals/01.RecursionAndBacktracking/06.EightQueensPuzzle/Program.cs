using System;
using System.Collections.Generic;

namespace _06.EightQueensPuzzle
{
    internal class Program
    {
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        static void Main(string[] args)
        {
            const int BoardSize = 8;

            bool[,] board = new bool[BoardSize, BoardSize];

            PutQueen(board, 0);
        }

        private static void PutQueen(bool[,] board, int row)
        {
            if (row >= board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (CanPutQueen(row, col))
                {
                    attackedRows.Add(row);
                    attackedCols.Add(col);
                    attackedLeftDiagonals.Add(row - col);
                    attackedRightDiagonals.Add(row + col);
                    board[row, col] = true;

                    PutQueen(board, row + 1);

                    attackedRows.Remove(row);
                    attackedCols.Remove(col);
                    attackedLeftDiagonals.Remove(row - col);
                    attackedRightDiagonals.Remove(row + col);
                    board[row, col] = false;
                }
            }
        }

        private static void PrintBoard(bool[,] board)
        {
            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    if (board[r,c])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static bool CanPutQueen(int row, int col)
        {
            return !attackedRows.Contains(row) &&
                   !attackedCols.Contains(col) &&
                   !attackedLeftDiagonals.Contains(row - col) &&
                   !attackedRightDiagonals.Contains(row + col);
        }
    }
}