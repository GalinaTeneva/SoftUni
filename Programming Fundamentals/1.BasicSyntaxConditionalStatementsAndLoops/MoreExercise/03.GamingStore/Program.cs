using System;

namespace _03.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());

            string currGame = Console.ReadLine();

            double moneySpend = 0;
            double currGamePrice = 0;
            while (currGame != "Game Time")
            {
                bool isGameValid = currGame == "OutFall 4" ||
                                    currGame == "CS: OG" ||
                                    currGame == "Zplinter Zell" ||
                                    currGame == "Honored 2" ||
                                    currGame == "RoverWatch" ||
                                    currGame == "RoverWatch Origins Edition";

                if (isGameValid)
                {
                    switch (currGame)
                    {
                        case "OutFall 4":
                        case "RoverWatch Origins Edition":
                            currGamePrice = 39.99;
                            break;
                        case "CS: OG":
                            currGamePrice = 15.99;
                            break;
                        case "Zplinter Zell":
                            currGamePrice = 19.99;
                            break;
                        case "Honored 2":
                            currGamePrice = 59.99;
                            break;
                        case "RoverWatch":
                            currGamePrice = 29.99;
                            break;
                    }

                    if (balance - moneySpend < currGamePrice)
                    {
                        Console.WriteLine("Too Expensive");
                        currGame = Console.ReadLine();
                        continue;
                    }

                    moneySpend += currGamePrice;
                    Console.WriteLine($"Bought {currGame}");

                    if (balance - moneySpend < 0)
                    {
                        Console.WriteLine("Out of money!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }

                currGame = Console.ReadLine();
            }

            if (currGame == "Game Time")
            {
                if (balance - moneySpend <= 0)
                {
                    Console.WriteLine("Out of money!");
                }
                else
                {
                    Console.WriteLine($"Total spent: ${moneySpend:F2}. Remaining: ${balance - moneySpend:F2}");
                }
            }

        }
    }
}

