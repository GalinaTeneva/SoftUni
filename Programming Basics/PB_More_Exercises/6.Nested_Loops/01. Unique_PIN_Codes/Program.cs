using System;

namespace _01._Unique_PIN_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            byte upperEndFirstNum = byte.Parse(Console.ReadLine());
            byte upperEndSecondNum = byte.Parse(Console.ReadLine());
            byte upperEndThirdNum = byte.Parse(Console.ReadLine());

            for (int firstDigit = 2; firstDigit <= upperEndFirstNum; firstDigit += 2)
            {
                for (int secondDigit = 1; secondDigit <= upperEndSecondNum; secondDigit++)
                {
                    if (secondDigit != 2 && secondDigit != 3 && secondDigit != 5 && secondDigit != 7)
                    {
                        continue;
                    }

                    for (int thirdDigit = 2; thirdDigit <= upperEndThirdNum; thirdDigit += 2)
                    {
                        Console.WriteLine($"{firstDigit} {secondDigit} {thirdDigit}");
                    }
                }
            }
        }
    }
}
