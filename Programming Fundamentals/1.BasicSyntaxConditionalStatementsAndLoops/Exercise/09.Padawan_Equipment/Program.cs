using System;

namespace _09.Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double pricePerLightsaber = double.Parse(Console.ReadLine());
            double pricePerRobe = double.Parse(Console.ReadLine());
            double pricePerBelt = double.Parse(Console.ReadLine());

            double spareLightsabers = Math.Ceiling(countOfStudents + (countOfStudents * 0.1));
            double totalForLightsabers = spareLightsabers * pricePerLightsaber;
            double totalForRobes = countOfStudents * pricePerRobe;
            double freeBelts = Math.Floor(countOfStudents / 6.00);
            double totalForBelts = (countOfStudents - freeBelts) * pricePerBelt;

            double totalCost = totalForLightsabers + totalForRobes + totalForBelts;

            if (totalCost <= budget)
            {
                Console.WriteLine($"The money is enough - it would cost {totalCost:F2}lv.");
            }
            else
            {
                double diff = totalCost - budget;
                Console.WriteLine($"John will need {diff:F2}lv more.");
            }

        }
    }
}
