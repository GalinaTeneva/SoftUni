using System;

namespace _06.Easter_Decoration
{
    class Program
    {
        static void Main(string[] args)
        {
            double basketPrice = 1.50;
            double wreathPrice = 3.80;
            double chocolateBunnyPrice = 7.00;

            int customersNum = int.Parse(Console.ReadLine());
            double totalTurnover = 0;

            for (int currentCustomer = 1; currentCustomer <= customersNum; currentCustomer++)
            {
                double currentCustomerBill = 0;
                int currentCustomerItemsCounter = 0;
                while (true)
                {
                    string currentItem = Console.ReadLine();

                    if (currentItem == "Finish")
                    {
                        break;
                    }

                    switch (currentItem)
                    {
                        case "basket":
                            currentCustomerItemsCounter++;
                            currentCustomerBill += basketPrice;
                            break;
                        case "wreath":
                            currentCustomerItemsCounter++;
                            currentCustomerBill += wreathPrice;
                            break;
                        case "chocolate bunny":
                            currentCustomerItemsCounter++;
                            currentCustomerBill += chocolateBunnyPrice;
                            break;
                    }
                }

                if (currentCustomerItemsCounter % 2 == 0)
                {
                    currentCustomerBill -= currentCustomerBill * 0.2;
                }

                totalTurnover += currentCustomerBill;

                Console.WriteLine($"You purchased {currentCustomerItemsCounter} items for {currentCustomerBill:F2} leva.");
            }

            double averageBill = totalTurnover / customersNum;
            Console.WriteLine($"Average bill per client is: {averageBill:F2} leva.");
        }
    }
}
