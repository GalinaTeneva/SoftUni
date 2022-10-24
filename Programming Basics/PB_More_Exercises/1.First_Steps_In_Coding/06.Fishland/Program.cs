using System;

namespace _06.Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            double mackerelPrice = double.Parse(Console.ReadLine());
            double spratPrice = double.Parse(Console.ReadLine());
            double beltedBonitoKilos = double.Parse(Console.ReadLine());
            double scadKilos = double.Parse(Console.ReadLine());
            double musselKilos = double.Parse(Console.ReadLine());

            double beltedBonitoPrice = mackerelPrice * 0.6 + mackerelPrice;
            double scadPrice = spratPrice * 0.8 + spratPrice;
            double musselPrice = 7.50;

            double totalCost = beltedBonitoKilos * beltedBonitoPrice + scadKilos * scadPrice + musselKilos * musselPrice;

            Console.WriteLine($"{totalCost:F2}");
        }
    }
}
