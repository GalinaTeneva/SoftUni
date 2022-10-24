using System;

namespace Food_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int chickenMenue = int.Parse(Console.ReadLine());
            int fishMenue = int.Parse(Console.ReadLine());
            int veggieMenue = int.Parse(Console.ReadLine());

            double chickenMenueCost = chickenMenue * 10.35;
            double fishMenueCost = fishMenue * 12.40;
            double veggieMenueCost = veggieMenue * 8.15;
            double dessertCost = (chickenMenueCost + fishMenueCost + veggieMenueCost) * 0.2;
            double totalCost = chickenMenueCost + fishMenueCost + veggieMenueCost + dessertCost + 2.50;

            Console.WriteLine(totalCost);
        }
    }
}
