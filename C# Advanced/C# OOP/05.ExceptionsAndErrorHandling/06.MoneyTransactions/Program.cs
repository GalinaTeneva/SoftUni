using System;
using System.Collections.Generic;

namespace MoneyTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accounts = new Dictionary<int, double>();

            string[] accountsInfos = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            AddAccountsToCollection(accounts, accountsInfos);

            string command = Console.ReadLine();
            while (command != "End")
            {
                try
                {
                    string[] commandTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    AccountManipulation(accounts, commandTokens);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (KeyNotFoundException knfe)
                {
                    Console.WriteLine(knfe.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

                command = Console.ReadLine();
            }
        }

        static void AccountManipulation(Dictionary<int, double> accounts, string[] commandTokens)
        {
            string operation = commandTokens[0];

            int accountName = int.Parse(commandTokens[1]);

            if (AccountValidation(accounts, accountName))
            {
                double accountAmount = accounts[accountName];
                double sum = double.Parse(commandTokens[2]);

                if (operation == "Deposit")
                {
                    accounts[accountName] = accountAmount + sum;
                }
                else if (operation == "Withdraw")
                {
                    if (sum > accountAmount)
                    {
                        throw new ArgumentException("Insufficient balance!");
                    }
                    accounts[accountName] = accountAmount - sum;
                }
                else
                {
                    throw new ArgumentException("Invalid command!");
                }
            }

            Console.WriteLine($"Account {accountName} has new balance: {accounts[accountName]:F2}");
        }

        static bool AccountValidation(Dictionary<int, double> accounts, int accountName)
        {
            if (!accounts.ContainsKey(accountName))
            {
                throw new KeyNotFoundException("Invalid account!");
            }

            return true;
        }

        static void AddAccountsToCollection(Dictionary<int, double> accounts, string[] accountsInfos)
        {
            for (int i = 0; i < accountsInfos.Length; i++)
            {
                string[] currAccountInfo = accountsInfos[i].Split('-', StringSplitOptions.RemoveEmptyEntries);

                int accountName = int.Parse(currAccountInfo[0]);
                double accountBalance = double.Parse(currAccountInfo[1]);

                accounts.Add(accountName, accountBalance);
            }
        }
    }
}
