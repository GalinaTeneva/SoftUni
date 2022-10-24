using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int cmds = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            Stack<string> textStack = new Stack<string>();
            textStack.Push(string.Empty);

            for (int i = 1; i <= cmds; i++)
            {
                string[] cmdArg = Console.ReadLine().Split();

                if (cmdArg[0] == "1")
                {
                    sb.Append(cmdArg[1]);
                    textStack.Push(sb.ToString());
                }
                else if (cmdArg[0] == "2")
                {
                    int elementsToRemove = int.Parse(cmdArg[1]);
                    sb.Remove(sb.Length - elementsToRemove, elementsToRemove);
                    textStack.Push(sb.ToString());
                }
                else if (cmdArg[0] == "3")
                {
                    int index = int.Parse(cmdArg[1]);
                    Console.WriteLine(sb[index - 1]);
                }
                else if (cmdArg[0] == "4")
                {
                    textStack.Pop();
                    sb.Clear();
                    sb.Append(textStack.Peek());
                }
            }
        }
    }
}
