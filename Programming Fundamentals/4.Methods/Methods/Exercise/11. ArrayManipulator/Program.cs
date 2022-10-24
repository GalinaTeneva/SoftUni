using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "exchange")
                {
                    int splitIndex = int.Parse(command[1]);
                    numbers = ExchangeNumbers(numbers, splitIndex);
                }
                else if (command[0] == "max" || command[0] == "min")
                {
                    FindMinMaxNumber(numbers, command[0], command[1]);
                }
                else
                {
                    int count = int.Parse(command[1]);
                    FindEvenOrOddNumbers(numbers, command[0], count, command[2]);
                }


                command = Console.ReadLine().Split();
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        private static void FindEvenOrOddNumbers(int[] numbers, string position, int countNumbers, string evenOrOdd)
        {
            if (countNumbers > numbers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            if (countNumbers == 0)
            {
                Console.WriteLine($"[]");
                return;
            }

            int resultOddOrEven = 0;
            if (evenOrOdd == "odd")
            {
                resultOddOrEven = 1;
            }

            int count = 0;
            List<int> nums = new List<int>();

            if (position == "first")
            {
                foreach (int number in numbers)
                {
                    if (number % 2 == resultOddOrEven)
                    {
                        count++;
                        nums.Add(number);
                    }
                    if (count == countNumbers)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int currentIndex = numbers.Length - 1; currentIndex >= 0; currentIndex--)
                {
                    if (numbers[currentIndex] % 2 == resultOddOrEven)
                    {
                        count++;
                        nums.Add(numbers[currentIndex]);
                    }
                    if (count == countNumbers)
                    {
                        break;
                    }
                }
                nums.Reverse();
            }
            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }

        private static void FindMinMaxNumber(int[] numbers, string minOrMax, string oddOrEven)
        {
            int minNumber = int.MaxValue;
            int maxNumber = int.MinValue;
            int maxOrMinNumIndex = -1;
            int resultOddOrEven = 0;

            if (oddOrEven == "odd")
            {
                resultOddOrEven = 1;
            }

            for (int currentIndex = 0; currentIndex < numbers.Length; currentIndex++)
            {
                if (numbers[currentIndex] % 2 == resultOddOrEven)
                {
                    if (minOrMax == "min" && minNumber >= numbers[currentIndex])
                    {
                        minNumber = numbers[currentIndex];
                        maxOrMinNumIndex = currentIndex;
                    }
                    else if (minOrMax == "max" && maxNumber <= numbers[currentIndex])
                    {
                        maxNumber = numbers[currentIndex];
                        maxOrMinNumIndex = currentIndex;
                    }
                }
            }

            Console.WriteLine(maxOrMinNumIndex > -1 ? maxOrMinNumIndex.ToString() : "No matches");
        }

        private static int[] ExchangeNumbers(int[] numbers, int splitIndex)
        {
            if (splitIndex < 0 || splitIndex > numbers.Length - 1)
            {
                Console.WriteLine("Invalid index");
                return numbers;
            }

            int[] exchanchedNumbers = new int[numbers.Length];
            int exchanchedArrayInex = 0;

            for (int i = splitIndex + 1; i <= numbers.Length - 1; i++)
            {
                exchanchedNumbers[exchanchedArrayInex] = numbers[i];
                exchanchedArrayInex++;
            }

            for (int i = 0; i <= splitIndex; i++)
            {
                exchanchedNumbers[exchanchedArrayInex] = numbers[i];
                exchanchedArrayInex++;
            }

            return exchanchedNumbers;
        }
    }
}
