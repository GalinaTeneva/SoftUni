using System;

namespace _05.DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());

            string message = string.Empty;
            for (int currLine = 1; currLine <= lines; currLine++)
            {
                char currChar = char.Parse(Console.ReadLine());
                char newChar = (char)(currChar + key);
                message += newChar;
            }

            Console.Write(message);
        }
    }
}
