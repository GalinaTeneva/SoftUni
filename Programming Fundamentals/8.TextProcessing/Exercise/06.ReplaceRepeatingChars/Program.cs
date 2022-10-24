using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();

            List<char> chars =  inputText.ToList();

            for (int i = 0; i < chars.Count - 1; i++)
            {
                if (chars[i] == chars[i + 1])
                {
                    chars.RemoveAt(i);
                    i--;
                }
            }

            Console.WriteLine(string.Join("", chars));
        }
    }
}
