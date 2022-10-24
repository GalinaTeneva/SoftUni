using System;

namespace _07.House_Painting
{
    class Program
    {
        static void Main(string[] args)
        {
            double greenSqMPer1Liter = 3.4;
            double redSqMPer1Liter = 4.3;
            double windowsArea = 2 * 1.5 * 1.5;
            double doorArea = 1.2 * 2;

            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double sideWallArea = x * y;
            double frontWallArea = x * x;
            double wallsArea = 2 * sideWallArea - windowsArea + 2 * frontWallArea - doorArea;

            double roofSideArea = x * y;
            double roofFrontArea = x * h / 2;
            double roofArea = 2 * roofSideArea + 2 * roofFrontArea;

            double paintForWalls = wallsArea / greenSqMPer1Liter;
            double paintForRoof = roofArea / redSqMPer1Liter;

            Console.WriteLine($"{paintForWalls:f2}");
            Console.WriteLine($"{paintForRoof:f2}");
        }
    }
}
