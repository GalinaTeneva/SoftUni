using System;

namespace _06.GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();

            int inputsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputsCount; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.Items.Add(input);
            }

            double comparisonElement = double.Parse(Console.ReadLine());

            Console.WriteLine(box.Count(comparisonElement));
        }
    }
}
