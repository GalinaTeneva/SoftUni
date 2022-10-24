using System;

namespace _04.Easter_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggsQuantity = int.Parse(Console.ReadLine());

            int soldEggsNum = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Close")
                {
                    Console.WriteLine("Store is closed!");
                    Console.WriteLine($"{soldEggsNum} eggs sold.");
                    break;
                }

                int eggsCurrentNum = int.Parse(Console.ReadLine());

                if (command == "Buy")
                {
                    if (eggsCurrentNum > eggsQuantity)
                    {
                        Console.WriteLine("Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {eggsQuantity}.");
                        break;
                    }
                    eggsQuantity -= eggsCurrentNum;
                    soldEggsNum += eggsCurrentNum;
                }
                else if (command == "Fill")
                {
                    eggsQuantity += eggsCurrentNum;
                }
            }
        }
    }
}
