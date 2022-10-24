using System;

namespace _02.RallyRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string carNum = Console.ReadLine();

            string[,] matrix = new string[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] colElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            int carRow = 0;
            int carCol = 0;
            int passedDistance = 0;

            string direction = Console.ReadLine();
            while (direction != "End")
            {
                if (direction == "up")
                {
                    if (matrix[carRow - 1, carCol] == "T")
                    {
                        matrix[carRow - 1, carCol] = ".";
                        MoveToSpecialLocation(matrix, ref carRow, ref carCol, ref passedDistance);
                        matrix[carRow, carCol] = ".";
                        direction = Console.ReadLine();
                        continue;
                    }
                    else if (matrix[carRow - 1, carCol] == "F")
                    {
                        matrix[carRow - 1, carCol] = "C";
                        passedDistance += 10;
                        break;
                    }

                    carRow--;
                }
                else if (direction == "down")
                {
                    if (matrix[carRow + 1, carCol] == "T")
                    {
                        matrix[carRow + 1, carCol] = ".";
                        MoveToSpecialLocation(matrix, ref carRow, ref carCol, ref passedDistance);
                        matrix[carRow, carCol] = ".";
                        direction = Console.ReadLine();
                        continue;
                    }
                    else if (matrix[carRow + 1, carCol] == "F")
                    {
                        matrix[carRow + 1, carCol] = "C";
                        passedDistance += 10;
                        break;
                    }

                    carRow++;
                }
                else if (direction == "left")
                {
                    if (matrix[carRow, carCol - 1] == "T")
                    {
                        matrix[carRow, carCol - 1] = ".";
                        MoveToSpecialLocation(matrix, ref carRow, ref carCol, ref passedDistance);
                        matrix[carRow, carCol] = ".";
                        direction = Console.ReadLine();
                        continue;
                    }
                    else if (matrix[carRow, carCol - 1] == "F")
                    {
                        matrix[carRow, carCol - 1] = "C";
                        passedDistance += 10;
                        break;
                    }

                    carCol--;
                }
                else if (direction == "right")
                {
                    if (matrix[carRow, carCol + 1] == "T")
                    {
                        matrix[carRow, carCol + 1] = ".";
                        MoveToSpecialLocation(matrix, ref carRow, ref carCol, ref passedDistance);
                        matrix[carRow, carCol] = ".";
                        direction = Console.ReadLine();
                        continue;
                    }
                    else if (matrix[carRow, carCol + 1] == "F")
                    {
                        matrix[carRow, carCol + 1] = "C";
                        passedDistance += 10;
                        break;
                    }

                    carCol++;
                }

                passedDistance += 10;
                direction = Console.ReadLine();
            }

            if (direction == "End")
            {
                matrix[carRow, carCol] = "C";
                Console.WriteLine($"Racing car {carNum} DNF.");
            }
            else
            {
                Console.WriteLine($"Racing car {carNum} finished the stage!");
            }

            Console.WriteLine($"Distance covered {passedDistance} km.");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void MoveToSpecialLocation(string[,] matrix, ref int carRow, ref int carCol, ref int distance)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "T")
                    {
                        carRow = row;
                        carCol = col;
                        distance += 30;
                        return;
                    }
                }
            }
        }
    }
}
