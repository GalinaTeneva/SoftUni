namespace _01.Trains
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] arrivals = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .OrderBy(a => a)
                .ToArray();

            double[] departures = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .OrderBy(d => d)
                .ToArray();

            Console.WriteLine(FindMinPlatforms(arrivals, departures));
        }

        private static int FindMinPlatforms(double[] arrivals, double[] departures)
        {
            int totalPlatforms = 0;
            int platforms = 0;

            int arrivalIdx = 0;
            int departureIdx = 0;

            while (arrivalIdx < arrivals.Length)
            {
                if (arrivals[arrivalIdx] < departures[departureIdx])
                {
                    platforms++;
                    arrivalIdx++;
                    totalPlatforms = Math.Max(totalPlatforms, platforms);
                }
                else
                {
                    platforms--;
                    departureIdx++;
                }
            }

            return totalPlatforms;
        }
    }
}