using System;

namespace _01._Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            int botlesNum = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int detergentQuantity = botlesNum * 750;

            int dishesCounter = 0;
            int potscounter = 0;
            int washingCyclesCounter = 0;
            int leftoverDetergent = detergentQuantity;
            while (input != "End")
            {
                int itemsForWashing = int.Parse(input);
                washingCyclesCounter++;

                if (washingCyclesCounter % 3 == 0)
                {
                    potscounter += itemsForWashing;
                    leftoverDetergent -= itemsForWashing * 15;
                }
                else
                {
                    dishesCounter += itemsForWashing;
                    leftoverDetergent -= itemsForWashing * 5;
                }

                if (leftoverDetergent < 0)
                {
                    Console.WriteLine($"Not enough detergent, {Math.Abs(leftoverDetergent)} ml. more necessary!");
                    break;
                }

                input = Console.ReadLine();
            }

            if (input == "End")
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{dishesCounter} dishes and {potscounter} pots were washed.");
                Console.WriteLine($"Leftover detergent {leftoverDetergent} ml.");
            }
        }
    }
}
