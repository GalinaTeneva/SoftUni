using System;

namespace _08.Circle_Area_And_Perimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());

            double circleArea = r * r * Math.PI;
            double circlePerimeter = 2 * r * Math.PI;

            Console.WriteLine($"{circleArea:f2}");
            Console.WriteLine($"{circlePerimeter:f2}");
        }
    }
}
