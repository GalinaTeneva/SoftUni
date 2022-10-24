using System;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lairSizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();

            char[,] lair = new char[lairSizes[0], lairSizes[1]];

            int playerRow = 0;
            int playerCol = 0;

            SetTheLair(lair, ref playerRow, ref playerCol);

            string commands = Console.ReadLine();


            foreach (char letter in commands)
            {
                bool hasLost = false;
                bool hasWon = false;
                int playerNewRow = playerRow;
                int playerNewCol = playerCol;

                if (letter == 'R')
                {
                    lair[playerRow, playerCol] = '.';
                    playerNewCol++;

                    if (ValidationIndex(playerRow, playerNewCol, lair))
                    {
                        if (lair[playerRow, playerNewCol] == 'B')
                        {
                            hasLost = true;
                        }
                        else
                        {
                            lair[playerRow, playerNewCol] = 'P';
                        }
                    }
                    else
                    {
                        hasWon = true;
                    }

                }
                else if (letter == 'L')
                {
                    lair[playerRow, playerCol] = '.';
                    playerNewCol--;

                    if (ValidationIndex(playerRow, playerNewCol, lair))
                    {
                        if (lair[playerRow, playerNewCol] == 'B')
                        {
                            hasLost = true;
                        }
                        else
                        {
                            lair[playerRow, playerNewCol] = 'P';
                        }
                    }
                    else
                    {
                        hasWon = true;
                    }

                }
                else if (letter == 'U')
                {
                    lair[playerRow, playerCol] = '.';
                    playerNewRow--;

                    if (ValidationIndex(playerNewRow, playerCol, lair))
                    {
                        if (lair[playerNewRow, playerCol] == 'B')
                        {
                            hasLost = true;
                        }
                        else
                        {
                            lair[playerNewRow, playerCol] = 'P';
                        }
                    }
                    else
                    {
                        hasWon = true;
                    }
                }
                else if (letter == 'D')
                {
                    lair[playerRow, playerCol] = '.';
                    playerNewRow++;

                    if (ValidationIndex(playerNewRow, playerCol, lair))
                    {
                        if (lair[playerNewRow, playerCol] == 'B')
                        {
                            hasLost = true;
                        }
                        else
                        {
                            lair[playerNewRow, playerCol] = 'P';
                        }
                    }
                    else
                    {
                        hasWon = true;
                    }
                }


                lair = BunniesSpreading(lair, ref hasLost);

                if (hasWon)
                {
                    PrintMatrix(lair);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    return;
                }

                playerRow = playerNewRow;
                playerCol = playerNewCol;

                if (hasLost)
                {
                    PrintMatrix(lair);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
                }
            }
        }


        private static void SetTheLair(char[,] lair, ref int playerRow, ref int playerCol)
        {
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                string rowInfo = Console.ReadLine();
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    lair[row, col] = rowInfo[col];

                    if (lair[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
        
        private static char[,] BunniesSpreading(char[,] lair, ref bool hasLost)
        {
            char[,] newlair = CopyLair(lair);

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'B')
                    {
                        if (ValidationIndex(row - 1, col, lair) && lair[row - 1, col] != 'B')
                        {
                            if (lair[row - 1, col] == 'P')
                            {
                                hasLost = true;
                            }

                            newlair[row - 1, col] = 'B';
                        }
                        if (ValidationIndex(row, col - 1, lair) && lair[row, col - 1] != 'B')
                        {
                            if (lair[row, col - 1] == 'P')
                            {
                                hasLost = true;
                            }

                            newlair[row, col - 1] = 'B';
                        }
                        if (ValidationIndex(row, col + 1, lair) && lair[row, col + 1] != 'B')
                        {
                            if (lair[row, col + 1] == 'P')
                            {
                                hasLost = true;
                            }

                            newlair[row, col + 1] = 'B';
                        }
                        if (ValidationIndex(row + 1, col, lair) && lair[row + 1, col] != 'B')
                        {
                            if (lair[row + 1, col] == 'P')
                            {
                                hasLost = true;
                            }

                            newlair[row + 1, col] = 'B';
                        }
                    }
                }
            }

            return newlair;
        }

        private static char[,] CopyLair(char[,] lair)
        {
            char[,] copy = new char[lair.GetLength(0), lair.GetLength(1)];

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    copy[row, col] = lair[row, col];
                }
            }

            return copy;
        }

        private static bool ValidationIndex(int row, int col, char[,] matix)
        {
            return
                row >= 0 && row < matix.GetLength(0) && col >= 0 && col < matix.GetLength(1);
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
