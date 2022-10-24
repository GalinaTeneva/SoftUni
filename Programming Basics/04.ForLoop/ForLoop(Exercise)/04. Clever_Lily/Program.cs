using System;

namespace _04._Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int years = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            int pricePerToy = int.Parse(Console.ReadLine());

            int toyCount = 0;
            double moneyPerBirthday = 10;
            double sumMoney = 0;
            int moneyForBrother = 0;

            for (int i = 1; i <= years; i++)
            {
                if (i % 2 == 0)
                {
                    sumMoney += moneyPerBirthday;
                    moneyPerBirthday += 10;
                    moneyForBrother++;
                }
                else
                {
                    toyCount++;
                }
            }

            sumMoney += (toyCount * pricePerToy - moneyForBrother);
            if (sumMoney >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {(sumMoney - washingMachinePrice):f2}");
            }
            else
            {
                Console.WriteLine($"No! {(washingMachinePrice - sumMoney):f2}");
            }
        }
    }
}
