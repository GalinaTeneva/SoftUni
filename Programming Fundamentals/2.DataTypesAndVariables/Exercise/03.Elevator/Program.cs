using System;

namespace _03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleForLifting = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());

            int cources = (int)Math.Ceiling(peopleForLifting / (double)elevatorCapacity);
            Console.WriteLine(cources);
        }
    }
}
