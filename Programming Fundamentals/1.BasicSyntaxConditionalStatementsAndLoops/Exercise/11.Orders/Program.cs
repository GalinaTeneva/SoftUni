using System;

namespace _11.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int ordersNum = int.Parse(Console.ReadLine());

            double sumOfAllOrders = 0;
            for (int currentOrder = 1; currentOrder <= ordersNum; currentOrder++)
            {
                double currentPricePerCapsule = double.Parse(Console.ReadLine());
                int currentDays = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());

                double currentOrderPrice = (currentDays * capsulesCount) * currentPricePerCapsule;
                sumOfAllOrders += currentOrderPrice;

                Console.WriteLine($"The price for the coffee is: ${currentOrderPrice:F2}");
            }

            Console.WriteLine($"Total: ${sumOfAllOrders:F2}");
        }
    }
}
