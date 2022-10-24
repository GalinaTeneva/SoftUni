using System;

namespace _05.Training_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            int wInCm = Convert.ToInt32 (w * 100);
            int hInCm = Convert.ToInt32 (h * 100);

            int hOfCorridorCm = 100;
            int losstWorkingSpace = 3;

            int desksPerRow = (hInCm - hOfCorridorCm) / 70;
            int numRows = wInCm / 120;

           int numberOfWorkingSpaces = desksPerRow * numRows - losstWorkingSpace;

           Console.WriteLine(numberOfWorkingSpaces);

        }
    }
}
