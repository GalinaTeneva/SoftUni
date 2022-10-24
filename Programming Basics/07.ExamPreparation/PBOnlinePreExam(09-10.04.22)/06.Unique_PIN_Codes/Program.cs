using System;

namespace _06.Unique_PIN_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumUpperLimit = int.Parse(Console.ReadLine());
            int secondNumUpperLimit = int.Parse(Console.ReadLine());
            int thirdNumUpperLimit = int.Parse(Console.ReadLine());

            for (int x = 1; x <= firstNumUpperLimit; x++)
            {
                if (x % 2 != 0)
                {
                    continue;
                }

                for (int y = 1; y <= secondNumUpperLimit; y++)
                {
                    bool isPrime = true;

                    for (int i = 2; i < y; i++)
                    {
                        if (y % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (!isPrime)
                    {
                        continue;
                    }

                    for (int z = 1; z <= thirdNumUpperLimit; z++)
                    {
                        if (z % 2 != 0)
                        {
                            continue;
                        }

                        Console.WriteLine($"{x} {y} {z}");
                    }
                }
            }

            //for (int x = 1; x <= firstNumUpperLimit; x++)
            //{
            //    if (x % 2 != 0)
            //    {
            //        continue;
            //    }

            //    for (int y = 1; y <= secondNumUpperLimit; y++)
            //    {
            //        if (y != 2 && y != 3 && y != 5 && y != 7)
            //        {
            //            continue;
            //        }

            //        for (int z = 1; z <= thirdNumUpperLimit; z++)
            //        {
            //            if (z % 2 != 0)
            //            {
            //                continue;
            //            }

            //            Console.WriteLine($"{x} {y} {z}");
            //        }
            //    }
            //}
        }
    }
}
