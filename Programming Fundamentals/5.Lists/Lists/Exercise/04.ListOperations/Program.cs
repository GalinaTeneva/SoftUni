using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "End")
                {
                    break;
                }
                else if (command[0] == "Add")
                {
                    int elementToAdd = int.Parse(command[1]);
                    numbers.Add(elementToAdd);
                }
                else if (command[0] == "Insert")
                {
                    int elementToInsert = int.Parse(command[1]);
                    int indexToInsert = int.Parse(command[2]);
                    if (indexToInsert <= numbers.Count - 1 && indexToInsert >= 0)
                    {
                        numbers.Insert(indexToInsert, elementToInsert);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command[0] == "Remove")
                {
                    int indexOfElementToDelete = int.Parse(command[1]);
                    if (indexOfElementToDelete <= numbers.Count - 1 && indexOfElementToDelete >= 0)
                    {
                        numbers.RemoveAt(indexOfElementToDelete);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command[0] == "Shift")
                {
                    string directionToMove = command[1];
                    int timesToMove = int.Parse(command[2]);
                    if (directionToMove == "left")
                    {
                        numbers = ShiftListToLeft(numbers, timesToMove);
                    }
                    else if (directionToMove == "right")
                    {
                        numbers = ShiftListToRight(numbers, timesToMove);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }


        static List<int> ShiftListToLeft(List<int> numbers, int times)
        {
            for (int currentMove = 1;  currentMove <= times; currentMove++)
            {
                numbers.Add(numbers[0]);
                numbers.RemoveAt(0);
            }
            return numbers;
        }
        static List<int> ShiftListToRight(List<int> numbers, int times)
        {
            for (int currentMove = 1; currentMove <= times; currentMove++)
            {
                numbers.Insert(0, numbers[numbers.Count - 1]);
                numbers.RemoveAt(numbers.Count - 1);
            }
            return numbers;
        }
    }
}
