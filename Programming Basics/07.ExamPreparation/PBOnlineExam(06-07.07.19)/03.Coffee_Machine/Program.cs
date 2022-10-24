using System;

namespace _03.Coffee_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string drinkSpecifics = Console.ReadLine();
            int drinksNum = int.Parse(Console.ReadLine());

            double drinkPrice = 0;
            switch (drink)
            {
                case "Espresso":
                    switch (drinkSpecifics)
                    {
                        case "Without":
                            drinkPrice = 0.90;
                            break;
                        case "Normal":
                            drinkPrice = 1.00;
                            break;
                        case "Extra":
                            drinkPrice = 1.20;
                            break;
                    }
                    break;
                case "Cappuccino":
                    switch (drinkSpecifics)
                    {
                        case "Without":
                            drinkPrice = 1.00;
                            break;
                        case "Normal":
                            drinkPrice = 1.20;
                            break;
                        case "Extra":
                            drinkPrice = 1.60;
                            break;
                    }
                    break;
                case "Tea":
                    switch (drinkSpecifics)
                    {
                        case "Without":
                            drinkPrice = 0.50;
                            break;
                        case "Normal":
                            drinkPrice = 0.60;
                            break;
                        case "Extra":
                            drinkPrice = 0.70;
                            break;
                    }
                    break;
            }

            double totalPrice = drinksNum * drinkPrice;

            if (drinkSpecifics == "Without")
            {
                totalPrice -= totalPrice * 0.35;
            }
            if (drink == "Espresso" && drinksNum >= 5)
            {
                totalPrice -= totalPrice * 0.25;
            }
            if (totalPrice > 15)
            {
                totalPrice -= totalPrice * 0.2;
            }

            Console.WriteLine($"You bought {drinksNum} cups of {drink} for {totalPrice:F2} lv.");
        }
    }
}
