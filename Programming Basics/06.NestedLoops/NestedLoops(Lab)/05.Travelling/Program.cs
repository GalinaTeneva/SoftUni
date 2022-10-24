using System;

namespace _05.Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination;
            while ((destination = Console.ReadLine()) != "End")
            {
                double minBudget = double.Parse(Console.ReadLine());
                double savedMoney = 0;

                while (savedMoney < minBudget)
                {
                    savedMoney += double.Parse(Console.ReadLine());
                }

                Console.WriteLine("Going to {0}!", destination);
            }
        }
    }
}
