using System;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());

            int[] groupsOfPeople = new int[numberOfWagons];
            int peopleInTotal = 0;

            for (int currentWagon = 0; currentWagon < numberOfWagons; currentWagon++)
            {
                groupsOfPeople[currentWagon] = int.Parse(Console.ReadLine());
                peopleInTotal += groupsOfPeople[currentWagon];
            }

            string result = string.Join(" ", groupsOfPeople);
            Console.WriteLine(result);
            Console.WriteLine(peopleInTotal);
        }
    }
}
