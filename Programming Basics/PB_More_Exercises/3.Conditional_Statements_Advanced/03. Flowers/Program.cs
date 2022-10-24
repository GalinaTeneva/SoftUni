using System;

namespace _03._Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            double LayOutPrice = 2.00;

            int chrysanthemumNum = int.Parse(Console.ReadLine());
            int roseNum = int.Parse(Console.ReadLine());
            int tulipNum = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string isHoliday = Console.ReadLine();

            double chrysanthemumPrice = 0;
            double rosePrice = 0;
            double tulipPrice = 0;

            if (season == "Spring" || season == "Summer")
            {
                chrysanthemumPrice = 2.00;
                rosePrice = 4.10;
                tulipPrice = 2.50;

                if (isHoliday == "Y")
                {
                    chrysanthemumPrice += chrysanthemumPrice * 0.15;
                    rosePrice += rosePrice * 0.15;
                    tulipPrice += tulipPrice * 0.15;
                }
            }
            else if (season == "Autumn" || season == "Winter")
            {
                chrysanthemumPrice = 3.75;
                rosePrice = 4.50;
                tulipPrice = 4.15;

                if (isHoliday == "Y")
                {
                    chrysanthemumPrice += chrysanthemumPrice * 0.15;
                    rosePrice += rosePrice * 0.15;
                    tulipPrice += tulipPrice * 0.15;
                }
            }

            double totalCost = chrysanthemumNum * chrysanthemumPrice + roseNum * rosePrice + tulipNum * tulipPrice;

            if (season == "Spring" && tulipNum > 7)
            {
                double discount = 0.05;
                totalCost -= totalCost * discount;
            }
            if (season == "Winter" && roseNum >= 10)
            {
                double discount = 0.10;
                totalCost -= totalCost * discount;
            }
            if ((chrysanthemumNum + roseNum + tulipNum) > 20)
            {
                double discount = 0.20;
                totalCost -= totalCost * discount;
            }

            double finalCost = totalCost + LayOutPrice;
            Console.WriteLine($"{finalCost:F2}");
        }
    }
}
