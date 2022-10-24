using System;

namespace Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {

            int annuelFee = int.Parse(Console.ReadLine());

            double sneakersCost = annuelFee - annuelFee * 0.4;
            double clothesCost = sneakersCost - sneakersCost * 0.2;
            double ballCost = clothesCost / 4;
            double accessoryCost = ballCost / 5;

            double totalCost = annuelFee + sneakersCost + clothesCost + ballCost + accessoryCost;

            Console.WriteLine(totalCost);
        }
    }
}
