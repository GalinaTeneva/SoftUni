using System;

namespace _05.Suitcases_Load
{
    class Program
    {
        static void Main(string[] args)
        {
            double trunkVolume = double.Parse(Console.ReadLine());
            int suitcasesCounter = 0;
            int inputsCounter = 0;
            while (trunkVolume != 0)
            {
                string input = Console.ReadLine();
                inputsCounter++;

                if (input == "End")
                {
                    Console.WriteLine("Congratulations! All suitcases are loaded!");
                    break;
                }

                double currentSuitcaseVolume = double.Parse(input);

                if (inputsCounter % 3 == 0)
                {
                    currentSuitcaseVolume += currentSuitcaseVolume * 0.1;
                }

                if (currentSuitcaseVolume > trunkVolume)
                {
                    Console.WriteLine("No more space!");
                    break;
                }
                else if (currentSuitcaseVolume == trunkVolume)
                {
                    Console.WriteLine("Congratulations! All suitcases are loaded!");
                }

                suitcasesCounter++;
                trunkVolume -= currentSuitcaseVolume;
            }

            Console.WriteLine("Statistic: {0} suitcases loaded.", suitcasesCounter);
        }
    }
}
