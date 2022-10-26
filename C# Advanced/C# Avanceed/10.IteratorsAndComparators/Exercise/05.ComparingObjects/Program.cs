using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string cmd = Console.ReadLine();

            while (cmd != "END")
            {
                string[] personInfo = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(personInfo[0], int.Parse(personInfo[1]), personInfo[2]);
                people.Add(person);

                cmd = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine());
            Person personToCompare = people[index - 1];

            int matchesCount = 0;
            int diffCount = 0;
            foreach (Person person in people)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    matchesCount++;
                }
                else
                {
                    diffCount++;
                }
            }

            if (matchesCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matchesCount} {diffCount} {people.Count}");
            }
        }
    }
}
