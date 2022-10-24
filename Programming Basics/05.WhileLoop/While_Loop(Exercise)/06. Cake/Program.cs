using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLength = int.Parse(Console.ReadLine());

            int pieces = cakeWidth * cakeLength;

            while (pieces > 0)
            {
                string input = Console.ReadLine();

                if (input == "STOP")
                {
                    break;
                }

                pieces -= int.Parse(input);
            }

            if (pieces > 0)
            {
                Console.WriteLine($"{pieces} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need { Math.Abs(pieces)} pieces more.");
            }
        }
    }
}
