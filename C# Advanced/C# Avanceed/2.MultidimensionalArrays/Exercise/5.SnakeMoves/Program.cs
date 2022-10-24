using System;
using System.Linq;

namespace _5.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] stairsDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string snake = Console.ReadLine();

            char[,] stairsMatrix = new char[stairsDimensions[0], stairsDimensions[1]];

            int index = 0;
            for (int row = 0; row < stairsMatrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < stairsMatrix.GetLength(1); col++)
                    {
                        stairsMatrix[row, col] = snake[index];
                        index++;

                        if (index > snake.Length - 1)
                        {
                            index = 0;
                        }
                    }
                }
                else
                {
                    for (int col = stairsMatrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        stairsMatrix[row, col] = snake[index];
                        index++;

                        if (index > snake.Length - 1)
                        {
                            index = 0;
                        }
                    }
                }
            }

            for (int row = 0; row < stairsMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < stairsMatrix.GetLength(1); col++)
                {
                    Console.Write(stairsMatrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
