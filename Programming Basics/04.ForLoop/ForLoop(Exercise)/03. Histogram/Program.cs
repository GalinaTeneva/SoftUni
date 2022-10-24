using System;

namespace _03._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum1 = 0;
            int sum2 = 0;
            int sum3 = 0;
            int sum4 = 0;
            int sum5 = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 200)
                {
                    sum1++;
                }
                else if (num >= 200 && num < 400)
                {
                    sum2++;
                }
                else if (num >= 400 && num < 600)
                {
                    sum3++;
                }
                else if (num >= 600 && num < 800)
                {
                    sum4++;
                }
                else if (num >= 800)
                {
                    sum5++;
                }
            }

            double p1 = (double)sum1 / n * 100;
            double p2 = (double)sum2 / n * 100;
            double p3 = (double)sum3 / n * 100;
            double p4 = (double)sum4 / n * 100;
            double p5 = (double)sum5 / n * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}
