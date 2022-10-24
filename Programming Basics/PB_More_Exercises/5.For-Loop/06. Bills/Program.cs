using System;

namespace _06._Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int monthsNum = int.Parse(Console.ReadLine());

            double waterCostPerMonth = 20;
            double netCostPerMonth = 15;

            double totalElectricityCost = 0;
            double totalWaterCost = 0;
            double totalNetCost = 0;
            double totalOtherCosts = 0;

            for (int currentMonth = 1; currentMonth <= monthsNum; currentMonth++)
            {
                double electricityCostForCurrentMonth = double.Parse(Console.ReadLine());
                double otherCostsForCurrentMonth = (electricityCostForCurrentMonth + waterCostPerMonth + netCostPerMonth) + (electricityCostForCurrentMonth + waterCostPerMonth + netCostPerMonth) * 0.20;

                totalElectricityCost += electricityCostForCurrentMonth;
                totalWaterCost += waterCostPerMonth;
                totalNetCost += netCostPerMonth;
                totalOtherCosts += otherCostsForCurrentMonth;
            }

            Console.WriteLine($"Electricity: {totalElectricityCost:F2} lv");
            Console.WriteLine($"Water: {totalWaterCost:F2} lv");
            Console.WriteLine($"Internet: {totalNetCost:F2} lv");
            Console.WriteLine($"Other: {totalOtherCosts:F2} lv");

            double averageCost = (totalElectricityCost + totalWaterCost + totalNetCost + totalOtherCosts) / monthsNum;
            Console.WriteLine($"Average: {averageCost:F2} lv");
        }
    }
}
