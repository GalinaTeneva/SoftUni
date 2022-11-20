using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int catchesCounter = 0;
            while (catchesCounter != 3)
            {
                string[] commandTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (ArgumentValidation(numbers, commandTokens[1]))
                    {
                        int firstIndex = int.Parse(commandTokens[1]);

                        if (commandTokens[0] == "Replace")
                        {
                            int element = int.Parse(commandTokens[2]);

                            Replace(numbers, firstIndex, element);
                        }
                        else if (commandTokens[0] == "Print")
                        {
                            if (ArgumentValidation(numbers, commandTokens[2]))
                            {
                                int secondIndex = int.Parse(commandTokens[2]);
                                Print(numbers, firstIndex, secondIndex);
                            }
                        }
                        else if (commandTokens[0] == "Show")
                        {
                            Show(numbers, firstIndex);
                        }
                    }
                }
                catch (IndexOutOfRangeException iore)
                {
                    catchesCounter++;
                    Console.WriteLine(iore.Message);
                }
                catch (FormatException fe)
                {
                    catchesCounter++;
                    Console.WriteLine(fe.Message);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        static void Replace(int[] numbers, int index, int element)
        {
            numbers[index] = element;
        }

        static void Print(int[] numbers, int firstIndex, int secondIndex)
        {
            List<int> numbersToPrint = new List<int>();

            for (int i = firstIndex; i <= secondIndex; i++)
            {
                numbersToPrint.Add(numbers[i]);
            }

            Console.WriteLine(string.Join(", ", numbersToPrint));
        }

        static void Show(int[] numbers, int index)
        {
            Console.WriteLine(numbers[index]);
        }

        static bool ArgumentValidation(int[] array, string index)
        {
            if (FormatValidation(index))
            {
                RangeValidation(array, index);
            }

            return true;
        }

        static bool RangeValidation(int[] array, string index)
        {
            int num = int.Parse(index);

            if (num < 0 || num >= array.Length)
            {
                throw new IndexOutOfRangeException("The index does not exist!");
            }

            return true;
        }

        static bool FormatValidation(string variable)
        {
            if (!int.TryParse(variable, out int num))
            {
                throw new FormatException("The variable is not in the correct format!");
            }

            return true;
        }
    }
}
