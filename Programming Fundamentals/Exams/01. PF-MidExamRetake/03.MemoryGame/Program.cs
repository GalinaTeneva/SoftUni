using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string commandInput = Console.ReadLine();

            int movesCounter = 0;
            while (commandInput != "end")
            {
                int[] indexesToCheck = commandInput.Split().Select(int.Parse).ToArray();
                int firstIndex = indexesToCheck[0];
                int secondIndex = indexesToCheck[1];

                movesCounter++;
                bool AreValid = IndexesValidation(firstIndex, secondIndex, elements, movesCounter);

                if (AreValid)
                {
                    if (elements[firstIndex] == elements[secondIndex])
                    {
                        string elementToRemove = elements[firstIndex];
                        Console.WriteLine($"Congrats! You have found matching elements - {elements[indexesToCheck[0]]}!");
                        elements.Remove(elementToRemove);
                        elements.Remove(elementToRemove);
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }
                }

                if (elements.Count == 0)
                {
                    Console.WriteLine($"You have won in {movesCounter} turns!");
                    return;
                }

                commandInput = Console.ReadLine();
            }

            if (elements.Count != 0)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", elements));
            }
        }

        private static bool IndexesValidation(int firstIndex, int secondIndex, List<string> elements, int turns)
        {
            bool AreValid = (firstIndex != secondIndex)
                            && (firstIndex >= 0 && firstIndex < elements.Count)
                            && (secondIndex >= 0 && secondIndex < elements.Count);
            if (!AreValid)
            {
                int insertIndex = elements.Count / 2;
                string newElement = "-" + turns.ToString() + "a";
                elements.Insert(insertIndex, newElement);
                elements.Insert(insertIndex + 1, newElement);

                Console.WriteLine("Invalid input! Adding additional elements to the board");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
