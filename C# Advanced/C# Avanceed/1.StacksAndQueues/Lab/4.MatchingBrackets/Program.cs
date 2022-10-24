using System;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> indexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexes.Push(i);
                }
                else if (input[i] == ')')
                {
                    int openningIndex = indexes.Pop();
                    int cosingIndex = i;

                    Console.WriteLine(input.Substring(openningIndex, cosingIndex - openningIndex + 1));
                }
            }
        }
    }
}
