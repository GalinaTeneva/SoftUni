using System;

namespace _08.SecretDoor_sLock
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstDigitUpperNum = int.Parse(Console.ReadLine());
            int secondDigitUpperNum = int.Parse(Console.ReadLine());
            int thirdDigitUpperNum = int.Parse(Console.ReadLine());

            for (int firstDigit = 1; firstDigit <= firstDigitUpperNum; firstDigit++)
            {
                if (firstDigit % 2 != 0)
                {
                    continue;
                }

                for (int secondDigit = 2; secondDigit <= secondDigitUpperNum; secondDigit++)
                {
                    bool isPrime = true;
                    for (int currentNum = 2; currentNum < secondDigit; currentNum++)
                    {
                        if (secondDigit % currentNum == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (!isPrime)
                    {
                        continue;
                    }

                    for (int thirdDigit = 1; thirdDigit <= thirdDigitUpperNum; thirdDigit++)
                    {
                        if (thirdDigit % 2 != 0)
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"{firstDigit} {secondDigit} {thirdDigit}");
                        }
                    }
                }
            }
        }
    }
}
