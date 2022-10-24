using System;

namespace _12._TheSongOfTheWheels
{
    class Program
    {
        static void Main(string[] args)
        {
            int controlNum = int.Parse(Console.ReadLine());

            int numbersCounter = 0;
            string password = " ";
            for (int a = 1; a <= 9; a++)
            {
                for (int b = 2; b <= 9; b++)
                {
                    for (int c = 2; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            if (a < b && c > d)
                            {
                                int currResult = a * b + c * d;
                                if (currResult == controlNum)
                                {
                                    numbersCounter++;
                                    Console.Write($"{a}{b}{c}{d} ");

                                    if (numbersCounter == 4)
                                    {
                                        password = $"{a}{b}{c}{d}";
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (numbersCounter != 0)
            {
                Console.WriteLine();
            }

            if (password != " ")
            {
                Console.WriteLine($"Password: {password}");
            }
            else
            {
                Console.WriteLine("No!");
            }
        }
    }
}
