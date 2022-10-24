using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> kids = new Queue<string>(Console.ReadLine().Split().ToArray());
            int tossesNum = int.Parse(Console.ReadLine());

            while (kids.Count != 1)
            {
                for (int i = 1; i < tossesNum; i++)
                {
                    string currKid = kids.Dequeue();
                    kids.Enqueue(currKid);
                }

                Console.WriteLine($"Removed {kids.Dequeue()}");
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
