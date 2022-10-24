using System;

namespace _07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int tankCapacity = 255;
            byte inputsNum = byte.Parse(Console.ReadLine());

            int pouredLitters = 0;
            for (int currentInput = 1; currentInput <= inputsNum; currentInput++)
            {
                int currentLiters = int.Parse(Console.ReadLine());

                if (tankCapacity < currentLiters)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }

                tankCapacity -= currentLiters;
                pouredLitters += currentLiters;
            }
            Console.WriteLine(pouredLitters);
        }
    }
}
