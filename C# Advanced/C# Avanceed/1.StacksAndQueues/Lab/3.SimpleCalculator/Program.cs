using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputTokens = Console.ReadLine().Split(" ").Reverse().ToArray();
            Stack<string> tokens = new Stack<string>(inputTokens);

            int result = int.Parse(tokens.Pop());

            while (tokens.Count > 0)
            {
                char operationSymbol = char.Parse(tokens.Pop());
                int currNum = int.Parse(tokens.Pop());

                switch (operationSymbol)
                {
                    case '+':
                        result += currNum;
                        break;
                    case '-':
                        result -= currNum;
                        break;
                }
            }

            Console.WriteLine(result);
        }
    }
}
