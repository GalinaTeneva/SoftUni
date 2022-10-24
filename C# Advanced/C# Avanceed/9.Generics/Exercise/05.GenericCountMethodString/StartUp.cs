using System;

namespace _05.GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();

            int inputsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputsCount; i++)
            {
                string input = Console.ReadLine();
                box.List.Add(input);
            }

            string comparisonElement = Console.ReadLine();

            Console.WriteLine(box.Count(comparisonElement));
        }
    }
}
