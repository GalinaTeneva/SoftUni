using System;

namespace _05._Average_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            double sum = 0;
            for (int i = 0; i < num; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                sum += currentNum;
            }

            Console.WriteLine($"{(sum / num):F2}");
        }
    }
}
