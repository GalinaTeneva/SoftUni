using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] parenthesesArr = Console.ReadLine().ToArray();

            Stack<char> parenthesesStack = new Stack<char>();

            if (parenthesesArr.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            bool areBalanced = true;

            foreach (char element in parenthesesArr)
            {
                if (element == '{' || element == '(' || element == '[')
                {
                    parenthesesStack.Push(element);
                }
                else
                {
                    char lastElement = parenthesesStack.Peek();

                    if (element == '}')
                    {
                        if (lastElement != '{')
                        {
                            areBalanced = false;
                            break;
                        }
                    }
                    else if (element == ')')
                    {
                        if (lastElement != '(')
                        {
                            areBalanced = false;
                            break;
                        }
                    }
                    else if (element == ']')
                    {
                        if (lastElement != '[')
                        {
                            areBalanced = false;
                            break;
                        }
                    }

                    parenthesesStack.Pop();
                }
            }

            string result = areBalanced ? "YES" : "NO";
            Console.WriteLine(result);
        }
    }
}
