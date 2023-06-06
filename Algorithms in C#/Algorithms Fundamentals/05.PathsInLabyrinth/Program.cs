using System;
using System.Collections.Generic;

namespace _05.PathsInLabyrinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] labyrinth = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string elements = Console.ReadLine();

                for (int j = 0; j < elements.Length; j++)
                {
                    labyrinth[i, j] = elements[j];
                }
            }

            FindPaths(labyrinth, 0, 0, new List<string>(), string.Empty);
        }

        private static void FindPaths(char[,] labyrinth, int row, int col, List<string> directions, string direction)
        {
            if (!IsInField(labyrinth, row, col))
            {
                return;
            }

            if (labyrinth[row, col] == '*' || labyrinth[row, col] == 'x')
            {
                return;
            }

            directions.Add(direction);

            if (labyrinth[row, col] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            labyrinth[row, col] = 'x';

            FindPaths(labyrinth, row - 1, col, directions, "U"); //Up
            FindPaths(labyrinth, row + 1, col, directions, "D"); //Down
            FindPaths(labyrinth, row, col - 1, directions, "L"); //Left
            FindPaths(labyrinth, row, col + 1, directions, "R"); //Right

            labyrinth[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }

        private static bool IsInField(char[,] field, int row, int col)
        {
            if (row >= field.GetLength(0) || row < 0 || col >= field.GetLength(1) || col < 0)
            {
                return false;
            }

            return true;
        }
    }
}