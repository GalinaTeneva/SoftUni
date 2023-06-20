using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SchoolTeams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] girls = Console.ReadLine().Split(", ");
            string[] boys = Console.ReadLine().Split(", ");

            string[] girlsCombinations = new string[3];
            List<string[]> allGirlsCombs = new List<string[]>();

            GenCombinations(0, 0, girls, girlsCombinations, allGirlsCombs);

            string[] boysCombinations = new string[2];
            List<string[]> allBoysCombs = new List<string[]>();

            GenCombinations(0, 0, boys, boysCombinations, allBoysCombs);

            PrintFinalCombinations(allGirlsCombs, allBoysCombs);
        }

        private static void PrintFinalCombinations(List<string[]> allGirlsCombs, List<string[]> allBoysCombs)
        {
            foreach (var girlsComb in allGirlsCombs)
            {
                foreach (var boysComb in allBoysCombs)
                {
                    Console.WriteLine($"{string.Join(", ", girlsComb)}, {string.Join(", ", boysComb)}");
                }
            }
        }

        private static void GenCombinations(int idx, int start, string[] elements, string[] combination, List<string[]> combs)
        {
            if (idx >= combination.Length)
            {
                combs.Add(combination.ToArray());
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combination[idx] = elements[i];
                GenCombinations(idx + 1, i + 1, elements, combination, combs);
            }
        }
    }
}