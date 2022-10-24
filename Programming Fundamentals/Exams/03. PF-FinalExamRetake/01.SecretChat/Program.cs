using System;
using System.Linq;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string[] currInstructionTokens = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = currInstructionTokens[0];
                if (currCommand == "Reveal")
                {
                    break;
                }
                else if (currCommand == "InsertSpace")
                {
                    int index = int.Parse(currInstructionTokens[1]);
                    message = message.Insert(index, " ");
                    Console.WriteLine(message);
                }
                else if (currCommand == "Reverse")
                {
                    string substring = currInstructionTokens[1];
                    if (message.Contains(substring))
                    {
                        int startIndex = message.IndexOf(substring);
                        message = message.Remove(startIndex, substring.Length);
                        var substringChars = substring.ToList();
                        substringChars.Reverse();
                        substring = string.Join("", substringChars);
                        message = message.Insert(message.Length, substring);
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (currCommand == "ChangeAll")
                {
                    string substring = currInstructionTokens[1];
                    string replacement = currInstructionTokens[2];
                    message = message.Replace(substring, replacement);
                    Console.WriteLine(message);
                }
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
