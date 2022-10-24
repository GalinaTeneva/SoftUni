using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] setsLengths = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            HashSet<int> firstSet = new HashSet<int>(setsLengths[0]);
            HashSet<int> secondSet = new HashSet<int>(setsLengths[0]);

            for (int i = 0; i < setsLengths[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                firstSet.Add(num);
            }

            for (int i = 0; i < setsLengths[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                secondSet.Add(num);
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(' ', firstSet));
        }
    }
}
