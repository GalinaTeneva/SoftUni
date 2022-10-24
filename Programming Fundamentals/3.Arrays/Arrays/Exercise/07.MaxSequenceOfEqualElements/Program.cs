using System;
using System.Linq;

namespace _07.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int longestSequence = 1;
            int longestSequenseNumber = 0;

            int currentSequenceLenght = 1;
            for (int j = 0; j < numbers.Length - 1; j++)
            {
                if (numbers[j] == numbers[j + 1])
                {
                    currentSequenceLenght++;
                    if (currentSequenceLenght > longestSequence)
                    {
                        longestSequence = currentSequenceLenght;
                        longestSequenseNumber = numbers[j];
                    }
                }
                else
                {
                    currentSequenceLenght = 1;
                }
            }

            for (int i = 0; i < longestSequence; i++)
            {
                Console.Write(longestSequenseNumber + " ");
            }
        }
    }
}
