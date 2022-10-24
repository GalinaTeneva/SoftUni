using System;

namespace _06.Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int roomsPerFloor = int.Parse(Console.ReadLine());

            for (int i = floors; i > 0; i--)
            {
                for (int k = 0; k < roomsPerFloor; k++)
                {
                    if (i == floors)
                    {
                        Console.Write($"L{i}{k} ");
                        continue;
                    }
                    if (i % 2 == 0)
                    {
                        Console.Write($"O{i}{k} ");
                    }
                    else
                    {
                        Console.Write($"A{i}{k} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
