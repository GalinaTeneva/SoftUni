using System;

namespace _03._Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int vineyardArea = int.Parse(Console.ReadLine());
            double grapesPerSqM = double.Parse(Console.ReadLine());
            int litersNeededVine = int.Parse(Console.ReadLine());
            int workersNum = int.Parse(Console.ReadLine());

            double areaForVinePercent = 0.4;
            double grapeForLiterVine = 2.5;
            double areaForVine = areaForVinePercent * vineyardArea;
            double grapesForVine = areaForVine * grapesPerSqM;
            double litersProducedVine = grapesForVine / grapeForLiterVine;

            if (litersProducedVine < litersNeededVine)
            {
                double vineShortge = litersNeededVine - litersProducedVine;
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(vineShortge)} liters wine needed.");
            }
            else
            {
                double vineLeft = litersProducedVine - litersNeededVine;
                double vineForWorkers = vineLeft / workersNum;
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(litersProducedVine)} liters.");
                Console.WriteLine($"{Math.Ceiling(vineLeft)} liters left -> {Math.Ceiling(vineForWorkers)} liters per person.");
            }
        }
    }
}
