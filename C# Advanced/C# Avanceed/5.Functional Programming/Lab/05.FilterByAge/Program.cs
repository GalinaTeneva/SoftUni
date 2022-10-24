using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            Func<Person, string, int, bool> filter = (p, c, a) => c == "older" ? p.Age >= a : p.Age < a;
            Func<Person, string[], string> formatter = (p, f) =>
            {
                string str = string.Empty;

                if (f.Length == 2)
                {
                    if (f[0] == "name")
                    {
                        str = "{0} - {1}";
                    }
                    else
                    {
                        str = "{1} - {0}";
                    }
                }
                else
                {
                    if (f[0] == "name")
                    {
                        str = "{0}";
                    }
                    else
                    {
                        str = "{1}";
                    }
                }

                return string.Format(str, p.Name, p.Age);
            };

            int linesNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesNum; i++)
            {
                string[] personInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                Person currPerson = new Person(personInfo[0], int.Parse(personInfo[1]));
                people.Add(currPerson);
            }

            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(string.Join(Environment.NewLine,
                people
                .Where(p => filter(p, condition, ageThreshold))
                .Select(p => formatter(p, format))));
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age {get; set;}

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }
    }
}
