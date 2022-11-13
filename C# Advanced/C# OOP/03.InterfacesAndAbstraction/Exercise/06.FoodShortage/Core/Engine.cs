
namespace FoodShortage.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using Models;
    using Models.Interfaces;

    public class Engine : IEngine
    {
        private ICollection<IPerson> people;

        public Engine()
        {
            people = new HashSet<IPerson>();
        }

        public void Run()
        {
            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= peopleCount; i++)
            {
                string[] personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = personInfo[0];
                int age = int.Parse(personInfo[1]);
                string idOrGroup = personInfo[2];

                IPerson person = null;
                if (personInfo.Length == 4)
                {
                    string birthdate = personInfo[3];
                    person = new Citizen(personName, age, idOrGroup, birthdate);
                }
                else if (personInfo.Length == 3)
                {
                    person = new Rebel(personName, age, idOrGroup);
                }

                people.Add(person);
            }

            string name = Console.ReadLine();
            while (name != "End")
            {
                if (people.Any(p => p.Name == name))
                {
                    IPerson currPerson = people.First(p => p.Name == name);

                    currPerson.BuyFood();
                }

                name = Console.ReadLine();
            }

            Console.WriteLine(people.Sum(p => p.Food));
        }
    }
}
