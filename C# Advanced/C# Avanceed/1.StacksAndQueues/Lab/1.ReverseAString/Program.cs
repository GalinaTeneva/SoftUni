using System;
using System.Collections.Generic;

namespace _1.ReverseAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (char symbol in inputString)
            {
                
                stack.Push(symbol);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
