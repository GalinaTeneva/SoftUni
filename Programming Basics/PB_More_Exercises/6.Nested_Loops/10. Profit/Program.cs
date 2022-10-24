using System;

namespace _10._Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int oneLvCoinsCount = int.Parse(Console.ReadLine());
            int twoLvCoinsCount = int.Parse(Console.ReadLine());
            int fiveLvCoinsCount = int.Parse(Console.ReadLine());
            int amount = int.Parse(Console.ReadLine());

            for (int i = 0; i <= oneLvCoinsCount; i++)
            {
                for (int j = 0; j <= twoLvCoinsCount; j++)
                {
                    for (int k = 0; k <= fiveLvCoinsCount; k++)
                    {
                        int currSum = (i * 1) + (j * 2) + (k * 5);
                        if (currSum == amount)
                        {
                            Console.WriteLine($"{i} * 1 lv. + {j} * 2 lv. + {k} * 5 lv. = {amount} lv.");
                        }
                    }
                }
            }
        }
    }
}
