using System;

namespace _05.Easter_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalColouredEggs = int.Parse(Console.ReadLine());

            int redEggs = 0;
            int orangeEggs = 0;
            int blueEggs = 0;
            int greenEggs = 0;
            int maxEggs = 0;
            string maxEggsColour = " ";
            for (int currentEgg = 1; currentEgg <= totalColouredEggs; currentEgg++)
            {
                string currentEggColour = Console.ReadLine();

                if (currentEggColour == "red")
                {
                    redEggs++;
                    if (redEggs > maxEggs)
                    {
                        maxEggs = redEggs;
                        maxEggsColour = "red";
                    }
                }
                else if (currentEggColour == "orange")
                {
                    orangeEggs++;
                    if (orangeEggs > maxEggs)
                    {
                        maxEggs = orangeEggs;
                        maxEggsColour = "orange";
                    }
                }
                else if (currentEggColour == "blue")
                {
                    blueEggs++;
                    if (blueEggs > maxEggs)
                    {
                        maxEggs = blueEggs;
                        maxEggsColour = "blue";
                    }
                }
                else if (currentEggColour == "green")
                {
                    greenEggs++;
                    if (greenEggs > maxEggs)
                    {
                        maxEggs = greenEggs;
                        maxEggsColour = "green";
                    }
                }
            }

            Console.WriteLine($"Red eggs: {redEggs}");
            Console.WriteLine($"Orange eggs: {orangeEggs}");
            Console.WriteLine($"Blue eggs: {blueEggs}");
            Console.WriteLine($"Green eggs: {greenEggs}");
            Console.WriteLine($"Max eggs: {maxEggs} -> {maxEggsColour}");
        }
    }
}
