using System;

namespace _02.Football_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            int winningsCounter = 0;
            int lossesCounter = 0;
            int drawnCounter = 0;

            for (int match = 1; match <= 3; match++)
            {
                string matchResult = Console.ReadLine();

                char hostResultAsChar = matchResult[0];
                char guestResultAsChar = matchResult[2];

                int hostResult = int.Parse(hostResultAsChar.ToString());
                int guestResult = int.Parse(guestResultAsChar.ToString());

                if (hostResult > guestResult)
                {
                    winningsCounter++;
                }
                else if (hostResult < guestResult)
                {
                    lossesCounter++;
                }
                else
                {
                    drawnCounter++;
                }
            }

            Console.WriteLine("Team won {0} games.", winningsCounter);
            Console.WriteLine("Team lost {0} games.", lossesCounter);
            Console.WriteLine("Drawn games: {0}", drawnCounter);
        }
    }
}
