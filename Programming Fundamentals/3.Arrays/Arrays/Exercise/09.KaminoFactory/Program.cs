using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequencesLength = int.Parse(Console.ReadLine());

            int[] bestSample = new int[sequencesLength];  // DNA
            string input = Console.ReadLine();

            int dnaSum = 0;    // the total sum of 1 in a DNA sequence
            int dnaCount = -1;   // the length of a sequence of 1
            int bestSampleSgtartingIndex = -1;
            int dnaSamples = 0;  // the number of the best DNA sequence

            int samples = 0;  // the counter which count the inputs with DNA sequence;

            while (input != "Clone them!")
            {
                samples++;
                int[] currentSequence = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int currentCount = 0;
                int currentStartingIndex = 0;
                int currentEndingIndex = 0;
                int currentDnaSum = 0;

                bool isCurrentDnaBetter = false;

                int count = 0;
                for (int i = 0; i < sequencesLength - 1; i++)
                {
                    if (currentSequence[i] != 1)
                    {
                        count = 0;
                        continue;
                    }

                    count++;
                    if (count > currentCount)
                    {
                        currentCount = count;
                        currentEndingIndex = i;
                    }
                }
                currentStartingIndex = currentEndingIndex - currentCount + 1;
                currentDnaSum = currentSequence.Sum();

                if (currentCount > dnaCount)
                {
                    isCurrentDnaBetter = true;
                }
                else if (currentCount == dnaCount)
                {
                    if (currentStartingIndex < bestSampleSgtartingIndex)
                    {
                        isCurrentDnaBetter = true;
                    }
                    else if (currentStartingIndex == bestSampleSgtartingIndex)
                    {
                        if (currentDnaSum > dnaSum)
                        {
                            isCurrentDnaBetter = true;
                        }
                    }
                }

                if (isCurrentDnaBetter)
                {
                    bestSample = currentSequence;
                    dnaCount = currentCount;
                    bestSampleSgtartingIndex = currentStartingIndex;
                    dnaSum = currentDnaSum;
                    dnaSamples = samples;

                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {dnaSamples} with sum: {dnaSum}.");
            Console.WriteLine($"{string.Join(" ", bestSample)}");
        }
    }
}
