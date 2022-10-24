using System;
using System.Collections.Generic;

namespace _05.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputsCount = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> citiesByCountrysByContinents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < inputsCount; i++)
            {
                string[] lineTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string continent = lineTokens[0];
                string country = lineTokens[1];
                string city = lineTokens[2];

                if (!citiesByCountrysByContinents.ContainsKey(continent))
                {
                    citiesByCountrysByContinents[continent] = new Dictionary<string, List<string>>();

                }
                if (!citiesByCountrysByContinents[continent].ContainsKey(country))
                {
                    citiesByCountrysByContinents[continent][country] = new List<string>();
                }

                citiesByCountrysByContinents[continent][country].Add(city);
            }

            foreach (var kvpPair in citiesByCountrysByContinents)
            {
                Console.WriteLine($"{kvpPair.Key}:");

                foreach (var (country, cities) in citiesByCountrysByContinents[kvpPair.Key])
                {
                    Console.WriteLine($"  {country} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
