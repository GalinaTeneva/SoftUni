using System;

namespace Deposit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double depositAmount = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine());
            
            double amountPerMonth = depositAmount * interest / 100 / 12;
            double totalMoney = depositAmount + months * amountPerMonth;
            

            Console.WriteLine(totalMoney);
        }
    }
}
