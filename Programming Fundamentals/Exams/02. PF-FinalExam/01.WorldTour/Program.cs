using System;

namespace _01.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            while (true)
            {
                string[] currCommandTokens = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
                string currCommandType = currCommandTokens[0];

                if (currCommandType == "Travel")
                {
                    break;
                }
                else if (currCommandType == "Add Stop")
                {
                    int index = int.Parse(currCommandTokens[1]);
                    string stringToAdd = currCommandTokens[2];

                    if (index >= 0 && index < stops.Length)
                    {
                        stops = stops.Insert(index, stringToAdd);
                    }
                }
                else if (currCommandType == "Remove Stop")
                {
                    int startIndex = int.Parse(currCommandTokens[1]);
                    int endIndex = int.Parse(currCommandTokens[2]);

                    if ((startIndex >= 0 && startIndex < stops.Length) && (endIndex >= 0 && endIndex < stops.Length))
                    {
                        stops = stops.Remove(startIndex, endIndex - startIndex + 1);
                    }
                }
                else if (currCommandType == "Switch")
                {
                    string oldString = currCommandTokens[1];
                    string newString = currCommandTokens[2];

                    if (stops.Contains(oldString))
                    {
                        stops = stops.Replace(oldString, newString);
                    }
                }

                Console.WriteLine(stops);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
