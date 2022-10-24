using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double excursionCost = double.Parse(Console.ReadLine());
            double initialMoney = double.Parse(Console.ReadLine());

            double totalAmmount = initialMoney;
            int daysCounter = 0;
            int spendCounter = 0;

            while (totalAmmount < excursionCost && spendCounter < 5)
            {
                string operation = Console.ReadLine();
                double currentAmmount = double.Parse(Console.ReadLine());

                daysCounter++;

                if (operation == "save")
                {
                    totalAmmount += currentAmmount;
                    spendCounter = 0;
                }
                else if (operation == "spend")
                {

                    totalAmmount -= currentAmmount;

                    if (totalAmmount < 0)
                    {
                        totalAmmount = 0;
                    }

                    spendCounter++;
                }
            }

            if (spendCounter == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(daysCounter);
            }
            else
            {
                Console.WriteLine($"You saved the money for {daysCounter} days.");
            }
        }
    }
}
