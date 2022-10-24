using System;

namespace _06.Vet_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hoursPerDay = int.Parse(Console.ReadLine());

            double feePerHour = 0;
            double totalFee = 0;
            for (int currentDay = 1; currentDay <= days; currentDay++)
            {
                double currentDayFee = 0;
                for (int currentHour = 1; currentHour <= hoursPerDay; currentHour++)
                {
                    if (currentDay % 2 == 0 && currentHour % 2 != 0)
                    {
                        feePerHour = 2.50;
                    }
                    else if (currentDay % 2 != 0 && currentHour % 2 == 0)
                    {
                        feePerHour = 1.25;
                    }
                    else
                    {
                        feePerHour = 1.00;
                    }

                    currentDayFee += feePerHour;
                }
                Console.WriteLine($"Day: {currentDay} - {currentDayFee:F2} leva");

                totalFee += currentDayFee;
            }

            Console.WriteLine($"Total: {totalFee:F2} leva");
        }
    }
}
