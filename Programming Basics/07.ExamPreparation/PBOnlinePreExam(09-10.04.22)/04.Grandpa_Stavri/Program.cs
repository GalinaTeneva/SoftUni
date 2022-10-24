using System;

namespace _04.Grandpa_Stavri
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());

            double totalLitersRakiya = 0;
            double rakiyaDegreesSum = 0;
            for (int currentDay = 1; currentDay <= days; currentDay++)
            {
                double currentAmountRakiya = double.Parse(Console.ReadLine());
                double currentDegrees = double.Parse(Console.ReadLine());

                totalLitersRakiya += currentAmountRakiya;
                rakiyaDegreesSum += currentDegrees * currentAmountRakiya;
            }

            double finalDegrees = rakiyaDegreesSum / totalLitersRakiya;

            Console.WriteLine($"Liter: {totalLitersRakiya:F2}");
            Console.WriteLine($"Degrees: {finalDegrees:F2}");

            if (finalDegrees < 38)
            {
                Console.WriteLine("Not good, you should baking!");
            }
            else if (finalDegrees >= 38 && finalDegrees <= 42)
            {
                Console.WriteLine("Super!");
            }
            else if (finalDegrees >= 42)
            {
                Console.WriteLine("Dilution with distilled water!");
            }
        }
    }
}
