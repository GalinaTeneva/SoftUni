using System;

namespace _04._Transport_Price
{
    class Program
    {
        static void Main(string[] args)
        {
            double taxiInitialPrice = 0.70;
            double taxiDayPrice = 0.79;
            double taxiNightPrice = 0.90;

            double busPrice = 0.09;
            double trainPrice = 0.06;

            int distance = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine();

            double tripPrice = 0;

            if (distance >= 100)
            {
                tripPrice = distance * trainPrice;
            }
            else if (distance >= 20 && distance < 100)
            {
                tripPrice = distance * busPrice;
            }
            else if (distance < 20 && dayOrNight == "day")
            {
                tripPrice = distance * taxiDayPrice + taxiInitialPrice;
            }
            else if (distance < 20 && dayOrNight == "night")
            {
                tripPrice = distance * taxiNightPrice + taxiInitialPrice;
            }

            Console.WriteLine($"{tripPrice:F2}");
        }
    }
}
