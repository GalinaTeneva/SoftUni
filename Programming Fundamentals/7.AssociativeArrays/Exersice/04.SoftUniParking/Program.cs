using System;
using System.Collections.Generic;

namespace _04.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());
            Dictionary<string, string> parkingRegister = new Dictionary<string, string>();

            for (int currCommand = 1; currCommand <= commandsCount; currCommand++)
            {
                string[] currCommandTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string currCommandName = currCommandTokens[0];
                string currUser = currCommandTokens[1];

                if (currCommandName == "register")
                {
                    string currLicensePlateNum = currCommandTokens[2];

                    if (!parkingRegister.ContainsKey(currUser))
                    {
                        parkingRegister[currUser] = currLicensePlateNum;
                        Console.WriteLine($"{currUser} registered {currLicensePlateNum} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parkingRegister.GetValueOrDefault(currUser)}");
                    }
                }
                else if (currCommandName == "unregister")
                {
                    if (parkingRegister.ContainsKey(currUser))
                    {
                        parkingRegister.Remove(currUser);
                        Console.WriteLine($"{currUser} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {currUser} not found");
                    }
                }
            }

            foreach(KeyValuePair<string, string> currKvp in parkingRegister)
            {
                Console.WriteLine($"{currKvp.Key} => {currKvp.Value}");
            }
        }
    }
}
