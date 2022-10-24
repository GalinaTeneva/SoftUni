using System;

namespace _7.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());

            if (boardSize < 3)
            {
                Console.WriteLine(0);
                return;
            }

            char[,] board = new char[boardSize, boardSize];

            FillTheBoard(board);

            int removedKnights = 0;
            while (true)
            {
                int mostHitsCounter = 0;
                int rowMostHits = 0;
                int colMostHits = 0;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (board[row, col] == 'K')
                        {
                            int attackedKnights = CountAttackedKnights(board, row, col);

                            if (attackedKnights > mostHitsCounter)
                            {
                                mostHitsCounter = attackedKnights;
                                rowMostHits = row;
                                colMostHits = col;
                            }
                        }
                    }
                }

                if (mostHitsCounter == 0)
                {
                    break;
                }
                else
                {
                    board[rowMostHits, colMostHits] = '0';
                    removedKnights++;
                }
            }

            Console.WriteLine(removedKnights);
        }

        private static void FillTheBoard(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
        }

        private static int CountAttackedKnights(char[,] board, int row, int col)
        {
            int attackedKnights = 0;
            if (ValidationIndex(row - 1, col - 2, board))
            {
                if (board[row - 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            if (ValidationIndex(row - 1, col + 2, board))
            {
                if (board[row - 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            if (ValidationIndex(row - 2, col + 1, board))
            {
                if (board[row - 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            if (ValidationIndex(row - 2, col - 1, board))
            {
                if (board[row - 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            if (ValidationIndex(row + 2, col - 1, board))
            {
                if (board[row + 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            if (ValidationIndex(row + 2, col + 1, board))
            {
                if (board[row + 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            if (ValidationIndex(row + 1, col - 2, board))
            {
                if (board[row + 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            if (ValidationIndex(row + 1, col + 2, board))
            {
                if (board[row + 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            return attackedKnights;
        }

        private static bool ValidationIndex(int row, int col, char[,]matrix)
        {
            return
                row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }

    }
}

