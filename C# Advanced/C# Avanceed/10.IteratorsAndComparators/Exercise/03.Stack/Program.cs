using System;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            string cmd = Console.ReadLine();

            while (cmd != "END")
            {
                string[] cmdTokens = cmd.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (cmdTokens[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else
                {
                    string[] elements = cmdTokens.Skip(1).ToArray();
                    foreach (var item in elements)
                    {
                        stack.Push(item);
                    }
                }

                cmd = Console.ReadLine();
            }

            for (int i = 1; i <= 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
