using System;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string password = string.Empty;
            for (int i = username.Length - 1; i >= 0; i--)
            {
                char currentLetter = username[i];
                password += currentLetter;
            }

            int inputsCounter = 0;
            while (true)
            {
                string input = Console.ReadLine();

                if (input == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else
                {
                    inputsCounter++;

                    if (inputsCounter == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        break;
                    }

                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
        }
    }
}
