using System;

namespace _08._Fuel_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double fuelInTank = double.Parse(Console.ReadLine());
            int minFuel = 25;

            if (fuelType == "Diesel")
            {
                if (fuelInTank >= minFuel)
                {
                    Console.WriteLine($"You have enough diesel.");
                }
                else
                {
                    Console.WriteLine($"Fill your tank with diesel!");
                }
            }
            else if (fuelType == "Gasoline")
            {
                if (fuelInTank >= minFuel)
                {
                    Console.WriteLine($"You have enough gasoline.");
                }
                else
                {
                    Console.WriteLine($"Fill your tank with gasoline!");
                }
            }
            else if (fuelType == "Gas")
            {
                if (fuelInTank >= minFuel)
                {
                    Console.WriteLine($"You have enough gas.");
                }
                else
                {
                    Console.WriteLine($"Fill your tank with gas!");
                }
            }
            else
            {
                Console.WriteLine("Invalid fuel!");
            }

        }
    }
}
