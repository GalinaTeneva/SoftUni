using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distanceBetweenTargets = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int pokedTargetsCounter = 0;
            int currentPokePower = pokePower;

            while (currentPokePower >= distanceBetweenTargets)
            {
                currentPokePower -= distanceBetweenTargets;
                pokedTargetsCounter++;

                if (currentPokePower == (pokePower / 2) && exhaustionFactor > 0)
                {
                    currentPokePower /= exhaustionFactor;
                }
            }

            Console.WriteLine(currentPokePower);
            Console.WriteLine(pokedTargetsCounter);
        }
    }
}
