using System;
using System.Linq;

namespace _02._Jeweler
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] whiteGold = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] yellowGold = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int craftedEarringsCounter = 0;
            int leftoverGold = 0;
            for (int i = 0; i < whiteGold.Length; i++)
            {
                int currGoldSum = whiteGold[i] + yellowGold[i];

                if (currGoldSum > 10)
                {
                    while (currGoldSum > 10)
                    {
                        yellowGold[i] -= 2;
                        currGoldSum = whiteGold[i] + yellowGold[i];
                    }
                }

                if (currGoldSum == 10)
                {
                    craftedEarringsCounter++;
                }
                else if (currGoldSum < 10)
                {
                    leftoverGold += currGoldSum;
                }
            }

            if (leftoverGold >= 10)
            {
                craftedEarringsCounter += leftoverGold / 10;
            }

            if (craftedEarringsCounter >= 7)
            {
                Console.WriteLine($"Great success, you created {craftedEarringsCounter} earrings.");
            }
            else
            {
                Console.WriteLine($"Keep trying, you need {7 - craftedEarringsCounter} more earrings.");
            }
        }
    }
}
