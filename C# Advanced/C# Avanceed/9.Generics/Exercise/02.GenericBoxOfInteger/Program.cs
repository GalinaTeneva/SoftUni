using System;

namespace _02.GenericBoxOfInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();

            int inputsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputsCount; i++)
            {
                int item = int.Parse(Console.ReadLine());

                box.List.Add(item);
            }

            Console.WriteLine(box.ToString());
        }
    }
}
