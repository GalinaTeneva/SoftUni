using System;
using System.Linq;

namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladybugsField = new int[fieldSize];

            int[] occupiedIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < occupiedIndexes.Length; i++)
            {
                int currentIndex = occupiedIndexes[i];

                if (currentIndex >= 0 && currentIndex < fieldSize)
                {
                    ladybugsField[currentIndex] = 1;
                }
            }

            string[] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {
                bool isFirstLadybug = true;
                int currentIndex = int.Parse(command[0]);

                while (currentIndex >= 0 && currentIndex < fieldSize && ladybugsField[currentIndex] != 0)
                {
                    if (isFirstLadybug)
                    {
                        ladybugsField[currentIndex] = 0;
                        isFirstLadybug = false;
                    }

                    string direction = command[1];
                    int flightLenght = int.Parse(command[2]);

                    if (direction == "left")
                    {
                        currentIndex -= flightLenght;
                        if (currentIndex >= 0 && currentIndex < fieldSize)
                        {
                            if (ladybugsField[currentIndex] == 0)
                            {
                                ladybugsField[currentIndex] = 1;
                                break;
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        currentIndex += flightLenght;
                        if (currentIndex >= 0 && currentIndex < fieldSize)
                        {
                            if (ladybugsField[currentIndex] == 0)
                            {
                                ladybugsField[currentIndex] = 1;
                                break;
                            }
                        }
                    }
                }
                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", ladybugsField));
        }
    }
}
