using System;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            const byte WorkersConsumptionPerDay = 26;
            const byte FinalWorkersConsumption = 26;
            const byte LossOfSpicesPerDay = 10;

            int startingSpicesNum = int.Parse(Console.ReadLine());

            int currentSpicesNum = startingSpicesNum;
            int daysCounter = 0;
            int totalSpicesExtracted = 0;
            while (currentSpicesNum >= 100)
            {
                daysCounter++;
                totalSpicesExtracted += (currentSpicesNum - WorkersConsumptionPerDay);
                currentSpicesNum -= LossOfSpicesPerDay;

                if (currentSpicesNum < 100)
                {
                    totalSpicesExtracted -= FinalWorkersConsumption;
                }
            }

            Console.WriteLine(daysCounter);
            Console.WriteLine(totalSpicesExtracted);

        }
    }
}
