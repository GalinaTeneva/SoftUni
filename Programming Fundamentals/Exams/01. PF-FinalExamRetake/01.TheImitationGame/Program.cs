using System;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Decode")
            {
                string[] commandTokens = command.Split('|', StringSplitOptions.RemoveEmptyEntries);

                if (commandTokens[0] == "Move")
                {
                    int numbersOfLetters = int.Parse(commandTokens[1]);
                    encryptedMessage = Move(encryptedMessage, numbersOfLetters);
                }
                else if (commandTokens[0] == "Insert")
                {
                    int index = int.Parse(commandTokens[1]);
                    string valueToInsert = commandTokens[2];
                    encryptedMessage = encryptedMessage.Insert(index, valueToInsert);
                }
                else if (commandTokens[0] == "ChangeAll")
                {
                    string substringToChange = commandTokens[1];
                    string replacement = commandTokens[2];
                    encryptedMessage = encryptedMessage.Replace(substringToChange, replacement);
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }

        private static string Move(string encryptedMessage, int numbersOfLetters)
        {
            string substringToMove = encryptedMessage.Substring(0, numbersOfLetters);
            encryptedMessage = encryptedMessage.Insert(encryptedMessage.Length, substringToMove);
            encryptedMessage = encryptedMessage.Remove(0, numbersOfLetters);

            return encryptedMessage;
        }
    }
}
