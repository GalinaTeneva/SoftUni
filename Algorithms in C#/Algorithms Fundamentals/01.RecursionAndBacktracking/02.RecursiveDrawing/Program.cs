using System;

namespace _02.RecursiveDrawing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            DrawFigure(num);
        }

        private static void DrawFigure(int num)
        {
            if (num == 0)
            {
                return;
            }

            string line = new string('*', num);
            Console.WriteLine(line);

            DrawFigure(num - 1);

            string newLine = new string('#', num);
            Console.WriteLine(newLine);
        }
    }
}