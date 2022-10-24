using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            double sum = 0;

            while ((input = Console.ReadLine()) != "NoMoreMoney")
            {
                double currentAmmount = double.Parse(input);
                if (currentAmmount < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                sum += currentAmmount;
                Console.WriteLine($"Increase: {currentAmmount:F2}");
            }
                Console.WriteLine($"Total: {sum:F2}");
        }
    }
}
