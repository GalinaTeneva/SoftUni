using System;

namespace Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int paintThinner = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double moneyForSupplies = (nylon + 2) * 1.50 + (paint + paint * 0.1) * 14.50 + paintThinner * 5.00 + 0.40;
            double moneyForPainters = moneyForSupplies * 0.3 * hours;
            double totalCost = moneyForSupplies + moneyForPainters;

            Console.WriteLine(totalCost);
        }
    }
}
