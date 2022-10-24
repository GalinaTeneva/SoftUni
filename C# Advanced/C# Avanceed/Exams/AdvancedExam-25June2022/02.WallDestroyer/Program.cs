using System;
using System.Linq;

namespace _02.WallDestroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int wallSize = int.Parse(Console.ReadLine());

            char[,] wall = new char[wallSize, wallSize];

            CreateMatrix(wall);

            int workerRow = 0;
            int workerCol = 0;

            FindInitialPosition(wall, ref workerCol, ref workerRow);

            int holesCount = 1;
            int rodsCount = 0;
            bool isElectrocuted = false;

            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                if (cmd == "up")
                {
                    if (ValidationIndex(workerRow - 1, workerCol, wall))
                    {
                        if (wall[workerRow - 1, workerCol] == 'R')
                        {
                            rodsCount++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (wall[workerRow - 1, workerCol] == 'C')
                        {
                            wall[workerRow, workerCol] = '*';
                            wall[workerRow - 1, workerCol] = 'E';
                            isElectrocuted = true;
                            holesCount++;
                            break;
                        }
                        else if (wall[workerRow - 1, workerCol] == '*')
                        {
                            wall[workerRow, workerCol] = '*';
                            workerRow--;
                            wall[workerRow, workerCol] = 'V';
                            Console.WriteLine($"The wall is already destroyed at position [{workerRow}, {workerCol}]!");
                        }
                        else if (wall[workerRow - 1, workerCol] == '-')
                        {
                            wall[workerRow, workerCol] = '*';
                            holesCount++;
                            workerRow--;
                            wall[workerRow, workerCol] = 'V';
                        }
                    }
                }
                else if (cmd == "down")
                {
                    if (ValidationIndex(workerRow + 1, workerCol, wall))
                    {
                        if (wall[workerRow + 1, workerCol] == 'R')
                        {
                            rodsCount++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (wall[workerRow + 1, workerCol] == 'C')
                        {
                            wall[workerRow, workerCol] = '*';
                            wall[workerRow + 1, workerCol] = 'E';
                            isElectrocuted = true;
                            holesCount++;
                            break;
                        }
                        else if (wall[workerRow + 1, workerCol] == '*')
                        {
                            wall[workerRow, workerCol] = '*';
                            workerRow++;
                            wall[workerRow, workerCol] = 'V';
                            Console.WriteLine($"The wall is already destroyed at position [{workerRow}, {workerCol}]!");
                        }
                        else if (wall[workerRow + 1, workerCol] == '-')
                        {
                            wall[workerRow, workerCol] = '*';
                            holesCount++;
                            workerRow++;
                            wall[workerRow, workerCol] = 'V';
                        }
                    }
                }
                else if (cmd == "left")
                {
                    if (ValidationIndex(workerRow, workerCol - 1, wall))
                    {
                        if (wall[workerRow, workerCol - 1] == 'R')
                        {
                            rodsCount++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (wall[workerRow, workerCol - 1] == 'C')
                        {
                            wall[workerRow, workerCol] = '*';
                            wall[workerRow, workerCol - 1] = 'E';
                            isElectrocuted = true;
                            holesCount++;
                            break;
                        }
                        else if (wall[workerRow, workerCol - 1] == '*')
                        {
                            wall[workerRow, workerCol] = '*';
                            workerCol--;
                            wall[workerRow, workerCol] = 'V';
                            Console.WriteLine($"The wall is already destroyed at position [{workerRow}, {workerCol}]!");
                        }
                        else if (wall[workerRow, workerCol - 1] == '-')
                        {
                            wall[workerRow, workerCol] = '*';
                            holesCount++;
                            workerCol--;
                            wall[workerRow, workerCol] = 'V';
                        }
                    }
                }
                else if (cmd == "right")
                {
                    if (ValidationIndex(workerRow, workerCol + 1, wall))
                    {
                        if (wall[workerRow, workerCol + 1] == 'R')
                        {
                            rodsCount++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (wall[workerRow, workerCol + 1] == 'C')
                        {
                            wall[workerRow, workerCol] = '*';
                            wall[workerRow, workerCol + 1] = 'E';
                            isElectrocuted = true;
                            holesCount++;
                            break;
                        }
                        else if (wall[workerRow, workerCol + 1] == '*')
                        {
                            wall[workerRow, workerCol] = '*';
                            workerCol++;
                            wall[workerRow, workerCol] = 'V';
                            Console.WriteLine($"The wall is already destroyed at position [{workerRow}, {workerCol}]!");
                        }
                        else if (wall[workerRow, workerCol + 1] == '-')
                        {
                            wall[workerRow, workerCol] = '*';
                            holesCount++;
                            workerCol++;
                            wall[workerRow, workerCol] = 'V';
                        }
                    }
                }

                cmd = Console.ReadLine();
            }

            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holesCount} hole(s) and he hit only {rodsCount} rod(s).");
            }

            PrintMatrix(wall);
        }

        private static void PrintMatrix(char[,] matrix)
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

        private static bool ValidationIndex(int row, int col, char[,] matix)
        {
            return
                row >= 0 && row < matix.GetLength(0) && col >= 0 && col < matix.GetLength(1);
        }

        private static void FindInitialPosition(char[,] matrix, ref int workerCol, ref int workerRow)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'V')
                    {
                        workerRow = row;
                        workerCol = col;
                    }
                }
            }
        }

        private static void CreateMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowElements = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }
        }
    }
}
