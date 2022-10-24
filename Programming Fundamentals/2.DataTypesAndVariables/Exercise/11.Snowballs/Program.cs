using System;
using System.Numerics;

namespace _11.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalSnowballsNum = int.Parse(Console.ReadLine());

            BigInteger bestSnowballValue = 0;
            int bestSnowballSnow = 0;
            int bestSnowballTime = 0;
            int bestSnowballQuality = 0;
            for (int currentSnowball = 1; currentSnowball <= totalSnowballsNum; currentSnowball++)
            {
                int currentSnowballSnow = int.Parse(Console.ReadLine());
                int currentSnowballTime = int.Parse(Console.ReadLine());
                int currentSnowballQuality = int.Parse(Console.ReadLine());

                BigInteger currentSnowballValue = BigInteger.Pow((currentSnowballSnow / currentSnowballTime), currentSnowballQuality);

                if (currentSnowballValue > bestSnowballValue)
                {
                    bestSnowballValue = currentSnowballValue;
                    bestSnowballSnow = currentSnowballSnow;
                    bestSnowballTime = currentSnowballTime;
                    bestSnowballQuality = currentSnowballQuality;
                }
            }

            Console.WriteLine($"{bestSnowballSnow} : {bestSnowballTime} = {bestSnowballValue} ({bestSnowballQuality})");
        }
    }
}
