using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _02.BitcoinMining
{
    public class Transaction
    {
        public string Hash { get; set; }

        public int Size { get; set; }

        public int Fees { get; set; }

        public string From { get; set; }

        public string To { get; set; }
    }

    internal class Program
    {
        public const int blockchainCapacity = 1_000_000;
        static void Main(string[] args)
        {
            int transactionsCount = int.Parse(Console.ReadLine());

            List<Transaction> transactions = new List<Transaction>();

            for (int i = 0; i < transactionsCount; i++)
            {
                string[] transactionInfo = Console.ReadLine().Split();

                transactions.Add(new Transaction
                {
                    Hash = transactionInfo[0],
                    Size = int.Parse(transactionInfo[1]),
                    Fees = int.Parse(transactionInfo[2]),
                    From = transactionInfo[3],
                    To = transactionInfo[4]
                });
            }

            int[,] dp = new int[transactionsCount + 1, blockchainCapacity + 1];
            bool[,] used = new bool[transactionsCount + 1, blockchainCapacity + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                Transaction tx = transactions[row - 1];

                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    int excluding = dp[row - 1, capacity];

                    if (capacity < tx.Size)
                    {
                        dp[row, capacity] = excluding;
                        continue;
                    }

                    int including = tx.Fees + dp[row - 1, capacity - tx.Size];

                    if (excluding < including)
                    {
                        dp[row, capacity] = including;
                        used[row, capacity] = true;
                    }
                    else
                    {
                        dp[row, capacity] = excluding;
                    }
                }
            }

            int currCapacity = blockchainCapacity;
            int totalCapacity = 0;

            List<string> usedTransactions = new List<string>();

            for (int row = dp.GetLength(0) - 1; row > 0; row--)
            {
                if (used[row,currCapacity])
                {
                    usedTransactions.Add(transactions[row - 1].Hash);
                    totalCapacity += transactions[row - 1].Size;
                    currCapacity -= transactions[row - 1].Size;
                }

                if (currCapacity == 0)
                {
                    break;
                }
            }

            Console.WriteLine($"Total Size: {totalCapacity}");
            Console.WriteLine($"Total Fees: {dp[transactionsCount, blockchainCapacity]}");
            Console.WriteLine(string.Join(Environment.NewLine, usedTransactions));
        }
    }
}