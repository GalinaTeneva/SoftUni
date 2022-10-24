using System;

namespace _01._Back_To_The_Past
{
    class Program
    {
        static void Main(string[] args)
        {
            double inheritance = double.Parse(Console.ReadLine());
            int endingYear = int.Parse(Console.ReadLine());

            int startingYear = 1800;
            int currentAge = 18;

            double totalMoneySpend = 0;
            for (int currentYear = startingYear; currentYear <= endingYear; currentYear++)
            {
                if (currentYear % 2 == 0)
                {
                    totalMoneySpend += 12000;
                }
                else
                {
                    totalMoneySpend += 12000 + (50 * currentAge);
                }

                currentAge++;
            }

            if (totalMoneySpend <= inheritance)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {(inheritance - totalMoneySpend):F2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {(totalMoneySpend - inheritance):F2} dollars to survive.");
            }
        }
    }
}
