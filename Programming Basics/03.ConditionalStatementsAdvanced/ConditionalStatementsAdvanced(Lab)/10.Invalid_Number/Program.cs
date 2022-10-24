using System;

namespace _10.Invalid_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            bool isValid = (num <= 200) && (num >= 100) || (num == 0);

            if (!isValid)
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
