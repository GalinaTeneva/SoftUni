using System;

namespace _03.Painting_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string eggsSize = Console.ReadLine();
            string eggsColour = Console.ReadLine();
            int batchesNum = int.Parse(Console.ReadLine());

            double batchprice = 0;
            if (eggsSize == "Large")
            {
                if (eggsColour == "Red")
                {
                    batchprice = 16;
                }
                else if (eggsColour == "Green")
                {
                    batchprice = 12;
                }
                else if (eggsColour == "Yellow")
                {
                    batchprice = 9;
                }
            }
            else if (eggsSize == "Medium")
            {
                if (eggsColour == "Red")
                {
                    batchprice = 13;
                }
                else if (eggsColour == "Green")
                {
                    batchprice = 9;
                }
                else if (eggsColour == "Yellow")
                {
                    batchprice = 7;
                }
            }
            else if (eggsSize == "Small")
            {
                if (eggsColour == "Red")
                {
                    batchprice = 9;
                }
                else if (eggsColour == "Green")
                {
                    batchprice = 8;
                }
                else if (eggsColour == "Yellow")
                {
                    batchprice = 5;
                }
            }

            double income = batchprice * batchesNum;
            double profit = income - (income * 0.35);

            Console.WriteLine($"{profit:F2} leva.");
        }
    }
}
