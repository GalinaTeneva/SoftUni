using System;

namespace _01.ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double totalPrice = 0;
            double totalPriceWithTax = 0;
            while (input != "special" && input != "regular")
            {
                double currPartPriceWithoutTax = double.Parse(input);

                if (currPartPriceWithoutTax < 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                    totalPrice += currPartPriceWithoutTax;
                }

                input = Console.ReadLine();
            }

            double taxes = totalPrice * 0.2;
            totalPriceWithTax += totalPrice + taxes;

            if (input == "special")
            {
                totalPriceWithTax -= totalPriceWithTax * 0.1;
            }

            if (totalPriceWithTax <= 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                string receipt = $"Congratulations you've just bought a new computer!\n" +
                    $"Price without taxes: {totalPrice:F2}$\n" +
                    $"Taxes: {taxes:F2}$\n" +
                    $"-----------\n" +
                    $"Total price: {totalPriceWithTax:F2}$";
                Console.WriteLine(receipt);
            }

        }
    }
}
