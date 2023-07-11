using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace _01.WordSearcher
{
    internal class Program
    {
        public static string[,] matrix;
        public static bool[,] visited;

        public static StringBuilder sb;
        public static HashSet<string> combinations;

        public static List<string> wordsToFind;
        public static HashSet<string> foundWords;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = GenerateGrid(rows, cols);

            wordsToFind = Console.ReadLine()
                .Split()
                .OrderBy(x => x.Length)
                .ToList();

            visited = new bool[rows, cols];
            foundWords = new HashSet<string>();

            sb = new StringBuilder();
            combinations = new HashSet<string>();

            int row = 0;
            int col = 0;

            DFS(row, col);

            foreach (string word in wordsToFind)
            {
                foreach (string comb in combinations)
                {
                    if (comb.Contains(word))
                    {
                        foundWords.Add(word);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, foundWords));
        }

        private static void DFS(int row, int col)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            visited[row, col] = true;

            sb.Append(matrix[row, col]);
            string str = sb.ToString();

            if (str.Length >= wordsToFind[0].Length)
            {
                combinations.Add(str);
            }

            //foreach (string word in wordsToFind)
            //{
            //    if (str.Contains(word) && !foundWords.Contains(word))
            //    {
            //        foundWords.Add(word);
            //    }
            //}

            DFS(row + 1, col);
            DFS(row, col + 1);
            DFS(row + 1, col + 1);
            DFS(row + 1, col - 1);
            DFS(row, col - 1);
            DFS(row - 1, col - 1);
            DFS(row - 1, col);
            DFS(row - 1, col + 1);

            visited[row, col] = false;

            sb.Clear();
        }

        private static string[,] GenerateGrid(int rows, int cols)
        {
            var matrix = new string[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                string currLine = Console.ReadLine();

                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = currLine[c].ToString();
                }
            }

            return matrix;
        }
    }
}