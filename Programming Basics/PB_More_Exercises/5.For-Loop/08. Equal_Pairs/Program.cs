using System;

namespace _08._Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalPairsNum = int.Parse(Console.ReadLine());

            int evenPairsCounter = 0;
            int previousPairSum = 0;
            int maxDiff = 0;
            for (int currentPair = 1; currentPair <= totalPairsNum; currentPair++)
            {
                int firstNum = int.Parse(Console.ReadLine());
                int secondNum = int.Parse(Console.ReadLine());

                int currentPairSum = firstNum + secondNum;

                if (previousPairSum == currentPairSum)
                {
                    evenPairsCounter++;
                }
                else
                {
                    maxDiff = currentPairSum - previousPairSum;
                }

                previousPairSum = currentPairSum;
            }

            if (evenPairsCounter == --totalPairsNum)
            {
                Console.WriteLine($"Yes, value={previousPairSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={Math.Abs(maxDiff)}");
            }
        }
    }
}
