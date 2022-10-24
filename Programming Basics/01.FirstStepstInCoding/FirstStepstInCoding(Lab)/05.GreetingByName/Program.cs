using System;

namespace GreetingByName
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            Console.WriteLine($"Hello, {name}!");
            /*OR:
              Console.WriteLine("Hello, " + name + "!");
              OR:
              Console.WriteLine ("Hello, {0}!", name); -> променливата name се вмъква на мястото на 0-та.
            */
        }
    }
}
