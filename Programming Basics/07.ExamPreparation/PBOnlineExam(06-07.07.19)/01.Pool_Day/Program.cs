using System;

namespace _01.Pool_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalEmployees = int.Parse(Console.ReadLine());
            double entranceFee = double.Parse(Console.ReadLine());
            double loungePrice = double.Parse(Console.ReadLine());
            double umbrellaPrice = double.Parse(Console.ReadLine());

            double totalEntranceFee = entranceFee * totalEmployees;
            double neededLounge = Math.Ceiling(totalEmployees * 0.75);
            double totalLoungePrice = loungePrice * neededLounge;
            double neededUmbrellas = Math.Ceiling((double)totalEmployees / 2);
            double totalUmbrellaPrice = umbrellaPrice * neededUmbrellas;

            double finalPrice = totalEntranceFee + totalLoungePrice + totalUmbrellaPrice;

            Console.WriteLine($"{finalPrice:F2} lv.");
        }
    }
}
