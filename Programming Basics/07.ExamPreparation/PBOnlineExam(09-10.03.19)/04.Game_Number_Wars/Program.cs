using System;

namespace _04.Game_Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string player1 = Console.ReadLine();
            string player2 = Console.ReadLine();

            int player1Points = 0;
            int player2Points = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End of game")
                {
                    Console.WriteLine($"{player1} has {player1Points} points");
                    Console.WriteLine($"{player2} has {player2Points} points");
                    break;
                }

                int player1CurrentCard = int.Parse(input);
                int player2CurrentCard = int.Parse(Console.ReadLine());

                if (player1CurrentCard > player2CurrentCard)
                {
                    player1Points += player1CurrentCard - player2CurrentCard;
                }
                else if (player2CurrentCard > player1CurrentCard)
                {
                    player2Points += player2CurrentCard - player1CurrentCard;
                }
                else if (player2CurrentCard == player1CurrentCard)
                {
                    bool isNumberWars = true;
                    int player1WarCard = int.Parse(Console.ReadLine());
                    int player2WarCard = int.Parse(Console.ReadLine());

                    string winner = " ";
                    int winnerPoints = 0;
                    if (player1WarCard > player2WarCard)
                    {
                        winner = player1;
                        winnerPoints = player1Points;
                    }
                    else
                    {
                        winner = player2;
                        winnerPoints = player2Points;
                    }

                    if (isNumberWars)
                    {
                        Console.WriteLine("Number wars!");
                        Console.WriteLine($"{winner} is winner with {winnerPoints} points");
                        break;
                    }
                }
            }
        }
    }
}
