using System;

namespace _01._StringManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandTokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandTokens[0] == "Translate")
                {
                    char symbolToReplace = char.Parse(commandTokens[1]);
                    char newSymbol = char.Parse(commandTokens[2]);

                    inputText = inputText.Replace(symbolToReplace, newSymbol);
                    Console.WriteLine(inputText);
                }
                else if (commandTokens[0] == "Includes")
                {
                    string substring = commandTokens[1];
                    Console.WriteLine(inputText.Contains(substring));
                }
                else if (commandTokens[0] == "Start")
                {
                    string substring = commandTokens[1];
                    Console.WriteLine(inputText.StartsWith(substring));
                }
                else if (commandTokens[0] == "Lowercase")
                {
                    inputText = inputText.ToLower();
                    Console.WriteLine(inputText);
                }
                else if (commandTokens[0] == "FindIndex")
                {
                    char symbol = char.Parse(commandTokens[1]);
                    int index = inputText.LastIndexOf(symbol);
                    Console.WriteLine(index);
                }
                else if (commandTokens[0] == "Remove")
                {
                    int startIndex = int.Parse(commandTokens[1]);
                    int count = int.Parse(commandTokens[2]);

                    inputText = inputText.Remove(startIndex, count);
                    Console.WriteLine(inputText);
                }

                command = Console.ReadLine();
            }
        }
    }
}
