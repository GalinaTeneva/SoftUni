using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>(inputNums);
            
            while (true)
            {
                string[] cmd = Console.ReadLine().ToLower().Split(" ");

                if (cmd[0] == "end")
                {
                    break;
                }
                else if (cmd[0] == "add")
                {
                    int firstNum = int.Parse(cmd[1]);
                    int secondNum = int.Parse(cmd[2]);

                    numbers.Push(firstNum);
                    numbers.Push(secondNum);
                }
                else if (cmd[0] == "remove")
                {
                    int numbersCount = int.Parse(cmd[1]);

                    if (numbersCount > numbers.Count)
                    {
                        continue;
                    }
                    else
                    {
                        for (int i = 1; i <= numbersCount; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }
            }

            int stackSum = 0;

            while (numbers.Count > 0)
            {
                stackSum += numbers.Pop();
            }

            Console.WriteLine($"Sum: {stackSum}");
        }
    }
}
