using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            while (true)
            {
                string[] currPersonInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (currPersonInfo[0] == "End")
                {
                    break;
                }

                string currName = currPersonInfo[0];
                string currId = currPersonInfo[1];
                int currAge = int.Parse(currPersonInfo[2]);

                Person currPerson = new Person(currName, currId, currAge);
                people.Add(currPerson);
            }

            foreach (Person person in people.OrderBy(person => person.Age))
            {
                Console.WriteLine(person);
            }
        }


        class Person
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public int Age { get; set; }

            public Person(string name, string id, int age)
            {
                this.Name = name;
                this.ID = id;
                this.Age = age;
            }
            
        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
}
