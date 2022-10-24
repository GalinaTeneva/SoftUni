using System;

namespace _07._Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int spaceWidth = int.Parse(Console.ReadLine());
            int spaceLength = int.Parse(Console.ReadLine());
            int spaceHeight = int.Parse(Console.ReadLine());

            int freeSpace = spaceHeight * spaceLength * spaceWidth;

            while (freeSpace > 0)
            {
                string input = Console.ReadLine();
                
                if (input == "Done")
                {
                    break;
                }

                freeSpace -= int.Parse(input);
            }

            if (freeSpace > 0)
            {
                Console.WriteLine($"{freeSpace} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(freeSpace)} Cubic meters more.");
            }
        }
    }
}
