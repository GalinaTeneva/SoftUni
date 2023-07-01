using System.Collections;

namespace _07.SumOfCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coins = new Queue<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .OrderByDescending(x => x));

            int target = int.Parse(Console.ReadLine());
            Dictionary<int, int> coinsByCount = new Dictionary<int, int>();
            int totalCoins = 0;

            while (target > 0 && coins.Count > 0)
            {
                int currCoin = coins.Dequeue();
                int currCount = target / currCoin;

                if (currCount == 0)
                {
                    continue;
                }

                coinsByCount[currCoin] = currCount;
                totalCoins += currCount;

                target %= currCoin;
            }

            if (target == 0)
            {
                Console.WriteLine($"Number of coins to take: {totalCoins}");

                foreach (KeyValuePair<int, int> coin in coinsByCount)
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
            
        }
    }
}