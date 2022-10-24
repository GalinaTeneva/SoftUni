using System;

namespace _02.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            GradeInWords(grade);
        }

        static void GradeInWords(double num)
        {
            if (num >= 2.00 && num <= 2.99)
            {
                Console.WriteLine("Fail");
            }
            else if (num >= 3.00 && num <= 3.49)
            {
                Console.WriteLine("Poor");
            }
            else if (num >= 3.50 && num <= 4.49)
            {
                Console.WriteLine("Good");
            }
            else if (num >= 4.50 && num <= 5.49)
            {
                Console.WriteLine("Very good");
            }
            else if (num >= 5.50 && num <= 6.00)
            {
                Console.WriteLine("Excellent");
            }
        }
    }
}
