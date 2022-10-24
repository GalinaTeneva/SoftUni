using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            bool isListChanged = false;

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] command = input.Split();
                if (command[0] == "Add")
                {
                    numbers.Add(int.Parse(command[1]));
                    isListChanged = true;
                }
                else if (command[0] == "Remove")
                {
                    numbers.Remove(int.Parse(command[1]));
                    isListChanged = true;
                }
                else if (command[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(command[1]));
                    isListChanged = true;
                }
                else if (command[0] == "Insert")
                {
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    isListChanged = true;
                }
                else if (command[0] == "Contains")
                {
                    bool ifContains = numbers.Contains(int.Parse(command[1]));
                    if (ifContains)
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (command[0] == "PrintEven")
                {
                    PrintEven(numbers);
                }
                else if (command[0] == "PrintOdd")
                {
                    PrintOdd(numbers);
                }
                else if (command[0] == "GetSum")
                {
                    Console.WriteLine(GetSum(numbers));
                }
                else if (command[0] == "Filter")
                {
                    List<int> filterResult = Filter(numbers, command[1], int.Parse(command[2]));
                    Console.WriteLine(string.Join(" ", filterResult));
                }

                input = Console.ReadLine();
            }

            if (isListChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        static List<int> Filter(List<int> numbers, string condition, int number)
        {
            List<int> result = new List<int>();
            if (condition == "<")
            {
                result = numbers.FindAll(element => element < number);
            }
            else if (condition == ">")
            {
                result = numbers.FindAll(element => element > number);
            }
            else if (condition == ">=")
            {
                result = numbers.FindAll(element => element >= number);
            }
            else if (condition == "<=")
            {
                result = numbers.FindAll(element => element <= number);
            }

            return result;
        }

        static int GetSum(List<int> numbers)
        {
            int sum = 0;
            for (int currentNumIndex = 0; currentNumIndex < numbers.Count; currentNumIndex++)
            {
                sum += numbers[currentNumIndex];
            }
            return sum;
        }

        static void PrintOdd(List<int> numbers)
        {
            List<int> resultList = new List<int>();
            for (int currentNumIndex = 0; currentNumIndex < numbers.Count; currentNumIndex++)
            {
                if (numbers[currentNumIndex] % 2 != 0)
                {
                    resultList.Add(numbers[currentNumIndex]);
                }
            }

            Console.WriteLine(string.Join(" ", resultList));
        }

        static void PrintEven(List<int> numbers)
        {
            List<int> resultList = new List<int>();
            for (int currentNumIndex = 0; currentNumIndex < numbers.Count; currentNumIndex++)
            {
                if (numbers[currentNumIndex] % 2 == 0)
                {
                    resultList.Add(numbers[currentNumIndex]);
                }
            }

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
