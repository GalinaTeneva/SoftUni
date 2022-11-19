using System;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            try
            {
                CalculateSquareRoot(num);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }

        static void CalculateSquareRoot(int num)
        {
            if (num < 0)
            {
                throw new ArgumentException("Invalid number.");
            }

            Console.WriteLine(Math.Sqrt(num));
        }
    }
}
