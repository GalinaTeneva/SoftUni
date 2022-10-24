using System;

namespace _04.Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int areaWithoutPaintingPercent = int.Parse(Console.ReadLine());

            int totalAreaOfWalls = 4 * (height * width);
            double areaOfWindowsAndDoors = totalAreaOfWalls * areaWithoutPaintingPercent / 100;
            double areaForPainting = Math.Floor(totalAreaOfWalls - areaOfWindowsAndDoors);


            string input;
            while ((input = Console.ReadLine()) != "Tired!")
            {
                int littersPaint = int.Parse(input);
                int currentAreaPainted = littersPaint;

                areaForPainting -= currentAreaPainted;

                if (areaForPainting <= 0)
                {
                    break;
                }
            }

            if (input == "Tired!")
            {
                Console.WriteLine("{0} quadratic m left.", areaForPainting);
            }
            else if (areaForPainting == 0)
            {
                Console.WriteLine("All walls are painted! Great job, Pesho!");
            }
            else if (areaForPainting < 0)
            {
                double littersPaintLeft = Math.Abs(areaForPainting);
                Console.WriteLine("All walls are painted and you have {0} l paint left!", littersPaintLeft);
            }
        }
    }
}
