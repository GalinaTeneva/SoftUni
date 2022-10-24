using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            List<string> validUsernames = new List<string>();


            foreach (string username in usernames)
            {

                if (username.Length >= 3 && username.Length <= 16)
                {
                    bool isValidUsername = true;

                    for (int i = 0; i < username.Length; i++)
                    {
                        if (!(char.IsLetterOrDigit(username[i]) || username[i] == '-' || username[i] == '_'))
                        {
                            isValidUsername = false;
                            break;
                        }
                    }

                    if (isValidUsername)
                    {
                        validUsernames.Add(username);
                    }
                }
            }

            foreach (string username in validUsernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
