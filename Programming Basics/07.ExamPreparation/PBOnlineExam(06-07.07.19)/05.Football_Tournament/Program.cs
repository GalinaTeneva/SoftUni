using System;

namespace _05.Football_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            int matches = int.Parse(Console.ReadLine());


            int points = 0;
            int winningsCounter = 0;
            int drawnCounter = 0;
            int lossesCounter = 0;
            for (int currentMatch = 1; currentMatch <= matches; currentMatch++)
            {
                char result = char.Parse(Console.ReadLine());

                switch (result)
                {
                    case 'W':
                        points += 3;
                        winningsCounter++;
                        break;
                    case 'D':
                        points += 1;
                        drawnCounter++;
                        break;
                    case 'L':
                        lossesCounter++;
                        break;
                }
            }

            if (matches == 0)
            {
                Console.WriteLine("{0} hasn't played any games during this season.", teamName);
            }
            else
            {
                Console.WriteLine("{0} has won {1} points during this season.", teamName, points);
                Console.WriteLine("Total stats:");
                Console.WriteLine("## W: {0}", winningsCounter);
                Console.WriteLine("## D: {0}", drawnCounter);
                Console.WriteLine("## L: {0}", lossesCounter);

                double wonGamesPercent = (double)winningsCounter / matches * 100;
                Console.WriteLine($"Win rate: {wonGamesPercent:F2}%");
            }
        }
    }
}
