using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[] commandTokens = Console.ReadLine().Split();

            while (commandTokens[0] != "end")
            {

                if (commandTokens[0] == "swap")
                {
                    int firstIndex = int.Parse(commandTokens[1]);
                    int secondIndex = int.Parse(commandTokens[2]);
                    SwapNumbers(numbers, firstIndex, secondIndex);
                }
                else if (commandTokens[0] == "multiply")
                {
                    int firstIndex = int.Parse(commandTokens[1]);
                    int secondIndex = int.Parse(commandTokens[2]);
                    MultiplyNumber(numbers, firstIndex, secondIndex);
                }
                else if (commandTokens[0] == "decrease")
                {
                    DecreaseElements(numbers);
                }

                commandTokens = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void DecreaseElements(int[] numbers)
        {
            for (int currEllement = 0; currEllement < numbers.Length; currEllement++)
            {
                numbers[currEllement]--;
            }
        }

        private static void MultiplyNumber(int[] numbers, int firstIndex, int secondIndex)
        {
            int firstElement = numbers[firstIndex];
            int secondElement = numbers[secondIndex];
            numbers[firstIndex] = firstElement * secondElement;
        }

        private static void SwapNumbers(int[] numbers, int firstIndex, int secondIndex)
        {
            int firstElement = numbers[firstIndex];
            int secondElement = numbers[secondIndex];

            numbers[firstIndex] = secondElement;
            numbers[secondIndex] = firstElement;
        }
    }
}
