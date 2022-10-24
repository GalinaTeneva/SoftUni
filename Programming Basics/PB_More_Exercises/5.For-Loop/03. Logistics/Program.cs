using System;

namespace _03._Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            double pricePerToneForBus = 200;
            double pricePerToneForTruck = 175;
            double pricePerToneForTrain = 120;

            int loadsNum = int.Parse(Console.ReadLine());

            double totalPrice = 0;
            double totalWeightByBus = 0;
            double totalWeightByTruck = 0;
            double totalWeightByTrain = 0;
            for (int currentLoad = 1; currentLoad <= loadsNum; currentLoad++)
            {
                int weightOfCurrentLoad = int.Parse(Console.ReadLine());

                if (weightOfCurrentLoad <= 3)
                {
                    totalPrice += weightOfCurrentLoad * pricePerToneForBus;
                    totalWeightByBus += weightOfCurrentLoad;

                }
                else if (weightOfCurrentLoad >= 4 && weightOfCurrentLoad <= 11)
                {
                    totalPrice += weightOfCurrentLoad * pricePerToneForTruck;
                    totalWeightByTruck += weightOfCurrentLoad;
                }
                else if (weightOfCurrentLoad >= 12)
                {
                    totalPrice += weightOfCurrentLoad * pricePerToneForTrain;
                    totalWeightByTrain += weightOfCurrentLoad;
                }
            }

            double totalWeight = totalWeightByBus + totalWeightByTruck + totalWeightByTrain;
            double averagePricePerTone = totalPrice / totalWeight;

            Console.WriteLine($"{averagePricePerTone:F2}");
            Console.WriteLine($"{(totalWeightByBus / totalWeight * 100):F2}%");
            Console.WriteLine($"{(totalWeightByTruck / totalWeight * 100):F2}%");
            Console.WriteLine($"{(totalWeightByTrain / totalWeight * 100):F2}%");
        }
    }
}
