using System;

namespace _07.Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double sumOfCoins = 0;
            while (input != "Start")
            {
                double currentCoin = double.Parse(input);
                bool isValidCoin = currentCoin == 0.1 || currentCoin == 0.2 || currentCoin == 0.5 ||
                                   currentCoin == 1.00 || currentCoin == 2.00;

                if (isValidCoin)
                {
                    sumOfCoins += currentCoin;
                }
                else
                {
                    Console.WriteLine("Cannot accept {0}", currentCoin);
                }

                input = Console.ReadLine();
            }
            double productPrice = 0;
            while ((input = Console.ReadLine()) != "End")
            {
                string currentProduct = input;

                switch (currentProduct)
                {
                    case "Nuts": productPrice = 2.00; break;
                    case "Water": productPrice = 0.70; break;
                    case "Crisps": productPrice = 1.50; break;
                    case "Soda": productPrice = 0.80; break;
                    case "Coke": productPrice = 1.00; break;
                    default: Console.WriteLine("Invalid product"); break;
                }

                if (sumOfCoins >= productPrice && productPrice > 0)
                {
                    Console.WriteLine("Purchased {0}", currentProduct.ToLower());
                    sumOfCoins -= productPrice;
                }
                else if (sumOfCoins < productPrice && productPrice > 0)
                {
                    Console.WriteLine("Sorry, not enough money");
                    continue;
                }
            }

            Console.WriteLine("Change: {0:F2}", sumOfCoins);
        }
    }
}
