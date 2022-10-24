using System;

namespace _01.GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();

            int inputsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputsCount; i++)
            {
                string item = Console.ReadLine();

                box.Elements.Add(item);
            }

            Console.WriteLine(box.ToString());
        }
    }
}
