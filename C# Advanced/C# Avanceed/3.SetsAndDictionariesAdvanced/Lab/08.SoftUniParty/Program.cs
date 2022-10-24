using System;
using System.Collections.Generic;

namespace _08.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();

            string input = Console.ReadLine();
            while (true)
            {
                if (input == "PARTY")
                {
                    input = Console.ReadLine();
                    break;
                }

                if (IsGuestValid(input))
                {
                    guests.Add(input);
                }
                else
                {
                    continue;
                }

                input = Console.ReadLine();
            }

            while (input != "END")
            {
                if (IsGuestValid(input))
                {
                    guests.Remove(input);
                }
                else
                {
                    continue;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(guests.Count);

            List<string> regGuests = new List<string>();
            foreach (string guest in guests)
            {
                if (char.IsDigit(guest[0]))
                {
                    Console.WriteLine(guest);
                }
                else
                {
                    regGuests.Add(guest);
                }
            }

            foreach (string guest in regGuests)
            {
                Console.WriteLine(guest);
            }
        }

        private static bool IsGuestValid(string input)
        {
            return input.Length == 8;
        }
    }
}
