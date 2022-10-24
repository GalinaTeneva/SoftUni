using System;

namespace _08.TownInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string townName = Console.ReadLine();
            uint townPopulation = uint.Parse(Console.ReadLine());
            ushort townArea = ushort.Parse(Console.ReadLine());

            Console.WriteLine($"Town {townName} has population of {townPopulation} and area {townArea} square km.");

        }
    }
}
