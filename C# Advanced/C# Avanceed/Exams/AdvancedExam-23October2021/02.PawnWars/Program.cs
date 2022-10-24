using System;

namespace _02.PawnWars
{
    class Program
    {
        static void Main(string[] args)
        {
            const int BoardSize = 8;

            string[,] boad = new string[BoardSize, BoardSize];

            for (int row = 0, i = 8; row < BoardSize; row++, i--)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    string letters = "abcdefgh";
                    boad[row, col] = $"{letters[col]}{i}";
                }
            }

            char[,] pawnsPositions = new char[BoardSize, BoardSize];

            int whiteRow = 0;
            int whiteCol = 0;
            int blackRow = 0;
            int blackCol = 0;

            for (int row = 0; row < BoardSize; row++)
            {
                string rowElements = Console.ReadLine();
                for (int col = 0; col < BoardSize; col++)
                {
                    pawnsPositions[row, col] = rowElements[col];

                    if (pawnsPositions[row, col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                    if (pawnsPositions[row, col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            } 

            int turnCounter = 0;
            while (true)
            {
                if (turnCounter % 2 != 0)
                {
                    // move black
                    if (IndexValidation(blackRow + 1, blackCol, pawnsPositions))
                    {
                        if (IndexValidation(blackRow + 1, blackCol - 1, pawnsPositions) && pawnsPositions[blackRow + 1, blackCol - 1] == 'w'
                            || IndexValidation(blackRow + 1, blackCol + 1, pawnsPositions) && pawnsPositions[blackRow + 1 , blackCol + 1] == 'w')
                        {
                            Console.WriteLine($"Game over! Black capture on {boad[whiteRow, whiteCol]}.");
                            break;
                        }
                        else
                        {
                            pawnsPositions[blackRow, blackCol] = '-';
                            blackRow++;
                            pawnsPositions[blackRow, blackCol] = 'b';
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {boad[blackRow, blackCol]}.");
                        break;
                    }
                }
                else
                {
                    // move white
                    if (IndexValidation(whiteRow - 1, whiteCol, pawnsPositions))
                    {
                        if (IndexValidation(whiteRow - 1, whiteCol - 1, pawnsPositions) && pawnsPositions[whiteRow - 1, whiteCol - 1] == 'b'
                            || IndexValidation(whiteRow - 1, whiteCol + 1, pawnsPositions) && pawnsPositions[whiteRow - 1, whiteCol + 1] == 'b')
                        {
                            Console.WriteLine($"Game over! White capture on {boad[blackRow, blackCol]}.");
                            break;
                        }
                        else
                        {
                            pawnsPositions[whiteRow, whiteCol] = '-';
                            whiteRow--;
                            pawnsPositions[whiteRow, whiteCol] = 'w';
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {boad[whiteRow, whiteCol]}.");
                        break;
                    }
                }

                turnCounter++;
            }
        }


        private static bool IndexValidation(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
