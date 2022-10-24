using System;

namespace Fishtank
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double volume = lenght * width * height;
            double water = volume - volume * percent / 100;
            double waterInLiter = water * 0.001;
            
            Console.WriteLine(waterInLiter);
        }
    }
}
