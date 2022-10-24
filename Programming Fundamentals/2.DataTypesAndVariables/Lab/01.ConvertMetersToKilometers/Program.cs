using System;

namespace _01.ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int distanceInMeters = int.Parse(Console.ReadLine());

            double distanceInKilometers = distanceInMeters / 1000.00;
            Console.WriteLine($"{distanceInKilometers:F2}");
        }
    }
}
