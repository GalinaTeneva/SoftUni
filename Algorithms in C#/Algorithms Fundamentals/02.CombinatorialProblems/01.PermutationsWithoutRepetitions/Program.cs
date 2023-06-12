using System;
using System.Linq;

namespace _01.PermutationsWithoutRepetitions
{
    internal class Program
    {
        private static string[] elements;
        private static string[] permutations;
        private static bool[] usedElements;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(" ");
            permutations = new string[elements.Length];
            usedElements = new bool[elements.Length];

            GeneratePermutations(0);
        }

        private static void GeneratePermutations(int index)
        {
            if (index >= permutations.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!usedElements[i])
                {
                    usedElements[i] = true;
                    permutations[index] = elements[i];

                    GeneratePermutations(index + 1);
                    usedElements[i] = false;
                }
            }
        }
    }
}