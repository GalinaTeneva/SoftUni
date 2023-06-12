using System;
using System.Linq;

namespace _06.CombinationsWithRepetition
{
    internal class Program
    {
        private static int k;
        private static string[] elements;
        private static string[] combinations;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());
            
            combinations = new string[k];
            GetCombinations(0, 0);
        }

        private static void GetCombinations(int index, int start)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combinations[index] = elements[i];
                GetCombinations(index + 1, i);
            }
        }
    }
}