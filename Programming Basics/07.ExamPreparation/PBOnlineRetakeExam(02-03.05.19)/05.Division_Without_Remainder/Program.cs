using System;

namespace _05.Division_Without_Remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            double devisionByTwoCounter = 0;
            double devisionByThreeCounter = 0;
            double devisionByFourCounter = 0;

            for (int i = 1; i <= numbers; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                if (currentNum % 2 == 0)
                {
                    devisionByTwoCounter++;
                }
                if (currentNum % 3 == 0)
                {
                    devisionByThreeCounter++;
                }
                if (currentNum % 4 == 0)
                {
                    devisionByFourCounter++;
                }
            }

            double devisionByTwoPercent = devisionByTwoCounter / numbers * 100;
            double devisionByThreePercent = devisionByThreeCounter / numbers * 100;
            double devisionByFourPercent = devisionByFourCounter / numbers * 100;

            Console.WriteLine($"{devisionByTwoPercent:F2}%");
            Console.WriteLine($"{devisionByThreePercent:F2}%");
            Console.WriteLine($"{devisionByFourPercent:F2}%");
        }
    }
}
