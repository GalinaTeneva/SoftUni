using System;

namespace _04.Easter_Eggs_Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalEggsPlayer1 = int.Parse(Console.ReadLine());
            int totalEggsPlayer2 = int.Parse(Console.ReadLine());

            string winner = "";
            while ((winner = Console.ReadLine()) != "End")
            {
                if (winner == "End")
                {
                    break;
                }
                else if (winner == "one")
                {
                    totalEggsPlayer2--;
                }
                else if (winner == "two")
                {
                    totalEggsPlayer1--;
                }

                if (totalEggsPlayer1 == 0)
                {
                    Console.WriteLine($"Player one is out of eggs. Player two has {totalEggsPlayer2} eggs left.");
                    break;
                }
                else if (totalEggsPlayer2 == 0)
                {
                    Console.WriteLine($"Player two is out of eggs. Player one has {totalEggsPlayer1} eggs left.");
                    break;
                }
            }

            if (winner == "End")
            {
                Console.WriteLine($"Player one has {totalEggsPlayer1} eggs left.");
                Console.WriteLine($"Player two has {totalEggsPlayer2} eggs left.");
            }
        }
    }
}
