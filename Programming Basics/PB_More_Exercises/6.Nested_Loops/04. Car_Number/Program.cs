using System;

namespace _04._Car_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            byte startNum = byte.Parse(Console.ReadLine());
            byte endNum = byte.Parse(Console.ReadLine());

            for (int firstDigit = startNum; firstDigit <= endNum; firstDigit++)
            {
                for (int secondDigit = startNum; secondDigit <= endNum; secondDigit++)
                {
                    for (int thirdDigit = startNum; thirdDigit <= endNum; thirdDigit++)
                    {
                        for (int fourthDigit = startNum; fourthDigit <= endNum; fourthDigit++)
                        {
                            if ((firstDigit % 2 == 0 && fourthDigit % 2 != 0) || (firstDigit % 2 != 0 && fourthDigit % 2 == 0))
                            {
                                if (firstDigit > fourthDigit)
                                {
                                    if ((secondDigit + thirdDigit) % 2 == 0)
                                    {
                                        Console.Write($"{firstDigit}{secondDigit}{thirdDigit}{fourthDigit} ");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
