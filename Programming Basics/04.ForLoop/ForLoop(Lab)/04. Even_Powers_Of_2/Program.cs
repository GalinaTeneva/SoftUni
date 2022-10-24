using System;

namespace _04._Even_Powers_Of_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int power = 0; power <= num; power += 2)
            {
                    Console.WriteLine(Math.Pow(2, power));
            }
        }
    }
}
