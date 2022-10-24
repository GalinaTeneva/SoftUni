using System;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string command = Console.ReadLine();
            while (command != "Generate")
            {
                string[] commandTokens = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                string commandType = commandTokens[0];
                if (commandType == "Contains")
                {
                    string substring = commandTokens[1];
                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (commandType == "Flip")
                {
                    string commandTypeSpecifics = commandTokens[1];
                    int startIndex = int.Parse(commandTokens[2]);
                    int endIndex = int.Parse(commandTokens[3]);
                    string substring = activationKey.Substring(startIndex, endIndex - startIndex);

                    if (commandTypeSpecifics == "Upper")
                    {
                        string newSubstring = substring.ToUpper();
                        activationKey = activationKey.Replace(substring, newSubstring);
                    }
                    else
                    {
                        string newSubstring = substring.ToLower();
                        activationKey = activationKey.Replace(substring, newSubstring);
                    }

                    Console.WriteLine(activationKey);
                }
                else if (commandType == "Slice")
                {
                    int startIndex = int.Parse(commandTokens[1]);
                    int endIndex = int.Parse(commandTokens[2]);
                    activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(activationKey);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}

