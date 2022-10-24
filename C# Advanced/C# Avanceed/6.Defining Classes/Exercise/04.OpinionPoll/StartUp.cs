using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] currPersonInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = currPersonInfo[0];
                int age = int.Parse(currPersonInfo[1]);

                Person currPerson = new Person(name, age);
                people.Add(currPerson);
            }

            List<Person> sortedPeople = people.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();
            foreach (Person person in sortedPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
