using System;

namespace _03.Easter_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int nightsNum = int.Parse(Console.ReadLine());

            int pricePerNight = 0;
            if (destination == "France")
            {
                if (dates == "21-23")
                {
                    pricePerNight = 30;
                }
                else if (dates == "24-27")
                {
                    pricePerNight = 35;
                }
                else if (dates == "28-31")
                {
                    pricePerNight = 40;
                }
            }
            else if (destination == "Italy")
            {
                if (dates == "21-23")
                {
                    pricePerNight = 28;
                }
                else if (dates == "24-27")
                {
                    pricePerNight = 32;
                }
                else if (dates == "28-31")
                {
                    pricePerNight = 39;
                }
            }
            else if (destination == "Germany")
            {
                if (dates == "21-23")
                {
                    pricePerNight = 32;
                }
                else if (dates == "24-27")
                {
                    pricePerNight = 37;
                }
                else if (dates == "28-31")
                {
                    pricePerNight = 43;
                }
            }

            double totalCost = pricePerNight * nightsNum;

            Console.WriteLine($"Easter trip to {destination} : {totalCost:F2} leva.");
        }
    }
}
