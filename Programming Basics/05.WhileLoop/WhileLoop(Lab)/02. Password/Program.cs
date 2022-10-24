using System;

namespace _02._Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string pass = Console.ReadLine();

            string text = Console.ReadLine();
            while (text != pass)
            {
                text = Console.ReadLine();
            }

            Console.WriteLine($"Welcome {name}!");

            //string name = Console.ReadLine();
            //string pass = Console.ReadLine();

            //while (true)
            //{
            //    string text = Console.ReadLine();

            //    if (text == pass)
            //    {
            //        Console.WriteLine($"Welcome {name}!");
            //        break;
            //    }
            //}
        }
    }
}
