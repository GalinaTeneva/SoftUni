using System;

namespace _06.Easter_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            int easterCakesNum = int.Parse(Console.ReadLine());

            int winningPoints = 0;
            string winner = "";
            for (int currentEaserCake = 1; currentEaserCake <= easterCakesNum; currentEaserCake++)
            {
                string bakerName = Console.ReadLine();
                int currentBakerPoints = 0;
                while (true)
                {
                    string input = Console.ReadLine();

                    if (input == "Stop")
                    {
                        break;
                    }

                    int currentCustomerScore = int.Parse(input);
                    currentBakerPoints += currentCustomerScore;
                }

                Console.WriteLine($"{bakerName} has {currentBakerPoints} points.");

                if (currentBakerPoints > winningPoints)
                {
                    winningPoints = currentBakerPoints;
                    winner = bakerName;
                    Console.WriteLine($"{winner} is the new number 1!");
                }

            }

            Console.WriteLine($"{winner} won competition with {winningPoints} points!");
        }
    }
}
