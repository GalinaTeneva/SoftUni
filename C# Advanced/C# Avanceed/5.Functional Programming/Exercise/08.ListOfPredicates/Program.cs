using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Predicate<int>> predicates = new List<Predicate<int>>();

            int rangeEnd = int.Parse(Console.ReadLine());
            HashSet<int> dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToHashSet();

            int[] numbers = Enumerable.Range(1, rangeEnd).ToArray();

            foreach (var num in dividers)
            {
                predicates.Add(p => p % num == 0);
            }

            foreach (int num in numbers)
            {
                bool isDivisible = true;
                foreach (var predicate in predicates)
                {
                    if (!predicate(num))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    Console.Write($"{num} ");
                }
            }
        }
    }
}
