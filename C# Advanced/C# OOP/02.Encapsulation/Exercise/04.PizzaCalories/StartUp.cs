using System;

namespace _04.PizzaCalories
{
    public class StartUp
    {
        static void Main()
        {
            try
            {
                string[] pizzaTokens = Console.ReadLine().Split(" ");
                string[] doughInfo = Console.ReadLine().Split(" ");

                Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
                Pizza pizza = new Pizza(pizzaTokens[1], dough);

                while (true)
                {
                    string inputLine = Console.ReadLine();
                    if (inputLine == "END")
                    {
                        break;
                    }

                    string[] toppingInfo = inputLine.Split(" ");

                    Topping topping = new Topping(toppingInfo[1], double.Parse(toppingInfo[2]));
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }
    }
}
