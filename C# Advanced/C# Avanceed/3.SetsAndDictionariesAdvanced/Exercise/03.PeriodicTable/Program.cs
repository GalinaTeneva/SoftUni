using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            SortedSet<string> compounds = new SortedSet<string>();

            for (int i = 0; i < linesCount; i++)
            {
                string[] currCompounds = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                compounds.UnionWith(currCompounds);
            }

            Console.WriteLine(string.Join(' ', compounds));
        }
    }
}
