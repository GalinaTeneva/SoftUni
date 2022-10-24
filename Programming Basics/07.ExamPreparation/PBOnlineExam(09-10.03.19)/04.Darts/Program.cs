using System;

namespace _04.Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();
            int playerPoints = 301;

            int successfulShotsCounter = 0;
            int unsuccessfulShotsCounter = 0;
            string input;
            while ((input = Console.ReadLine()) != "Retire")
            {
                string currentSector = input;
                int currentSectorPoints = int.Parse(Console.ReadLine());

                if (currentSector == "Single")
                {
                    if (currentSectorPoints > playerPoints)
                    {
                        unsuccessfulShotsCounter++;
                        continue;
                    }

                    playerPoints -= currentSectorPoints;
                    successfulShotsCounter++;
                }
                else if (currentSector == "Double")
                {
                    if ((currentSectorPoints * 2) > playerPoints)
                    {
                        unsuccessfulShotsCounter++;
                        continue;
                    }

                    playerPoints -= currentSectorPoints * 2;
                    successfulShotsCounter++;
                }
                else if (currentSector == "Triple")
                {
                    if ((currentSectorPoints * 3) > playerPoints)
                    {
                        unsuccessfulShotsCounter++;
                        continue;
                    }

                    playerPoints -= currentSectorPoints * 3;
                    successfulShotsCounter++;
                }

                if (playerPoints == 0)
                {
                    Console.WriteLine($"{playerName} won the leg with {successfulShotsCounter} shots.");
                    break;
                }
            }

            if (input == "Retire")
            {
                Console.WriteLine($"{playerName} retired after {unsuccessfulShotsCounter} unsuccessful shots.");
            }
        }
    }
}
