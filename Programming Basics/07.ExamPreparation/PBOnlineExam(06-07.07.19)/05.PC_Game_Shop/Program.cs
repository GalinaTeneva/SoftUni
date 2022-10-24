using System;

namespace _05.PC_Game_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int soldGames = int.Parse(Console.ReadLine());
            double hearthstoneCounter = 0;
            double fortniteCounter = 0;
            double overwatchCounter = 0;
            double othersCounter = 0;

            for (int i = 1; i <= soldGames; i++)
            {
                string gameName = Console.ReadLine();

                if (gameName == "Hearthstone")
                {
                    hearthstoneCounter++;
                }
                else if (gameName == "Fornite")
                {
                    fortniteCounter++;
                }
                else if (gameName == "Overwatch")
                {
                    overwatchCounter++;
                }
                else
                {
                    othersCounter++;
                }
            }

            double hearthstoneSoldGamesPerc = hearthstoneCounter / soldGames * 100;
            double fortniteSoldGamesPerc = fortniteCounter / soldGames * 100;
            double overwatchSoldGamesPerc = overwatchCounter / soldGames * 100;
            double othersSoldGamesPerc = othersCounter / soldGames * 100;

            Console.WriteLine($"Hearthstone - {hearthstoneSoldGamesPerc:F2}%");
            Console.WriteLine($"Fornite - {fortniteSoldGamesPerc:F2}%");
            Console.WriteLine($"Overwatch - {overwatchSoldGamesPerc:F2}%");
            Console.WriteLine($"Others - {othersSoldGamesPerc:F2}%");
        }
    }
}