using System;

namespace _11._HappyCatParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hoursPerDay = int.Parse(Console.ReadLine());

            double totalPrice = 0;
            for (int currDay = 1; currDay <= days; currDay++)
            {
                double currDayPrice = 0;
                for (int currHour = 1; currHour <= hoursPerDay; currHour++)
                {
                    double pricePerHour = 0;
                    if (currDay % 2 == 0 && currHour % 2 != 0)
                    {
                        pricePerHour = 2.50;
                    }
                    else if (currDay % 2 != 0 && currHour % 2 == 0)
                    {
                        pricePerHour = 1.25;
                    }
                    else
                    {
                        pricePerHour = 1.00;
                    }

                    currDayPrice += pricePerHour;
                }

                totalPrice += currDayPrice;
                Console.WriteLine($"Day: {currDay} - {currDayPrice:F2} leva");
            }

            Console.WriteLine($"Total: {totalPrice:F2} leva");
        }
    }
}
