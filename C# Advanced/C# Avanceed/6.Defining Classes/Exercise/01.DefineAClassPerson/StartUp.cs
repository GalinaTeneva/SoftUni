using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();

            person.Name = "Georgi";
            person.Age = 18;

            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");

        }
    }
}
