using System;

namespace _03.Mobile_Operator
{
    class Program
    {
        static void Main(string[] args)
        {
            string contractTerm = Console.ReadLine();
            string contractType = Console.ReadLine();
            string mobileInternetOption = Console.ReadLine();
            int monthsForPayment = int.Parse(Console.ReadLine());

            double twoYearsDiscount = 0.0375;

            double monthlyFee = 0;
            double mobileInternetMonthlyFee = 0;
            if (contractTerm == "one")
            {
                switch (contractType)
                {
                    case "Small":
                        monthlyFee = 9.98;
                        break;
                    case "Middle":
                        monthlyFee = 18.99;
                        break;
                    case "Large":
                        monthlyFee = 25.98;
                        break;
                    case "ExtraLarge":
                        monthlyFee = 35.99;
                        break;
                }
            }
            else if (contractTerm == "two")
            {
                switch (contractType)
                {
                    case "Small":
                        monthlyFee = 8.58;
                        break;
                    case "Middle":
                        monthlyFee = 17.09;
                        break;
                    case "Large":
                        monthlyFee = 23.59;
                        break;
                    case "ExtraLarge":
                        monthlyFee = 31.79;
                        break;
                }
            }

            if (mobileInternetOption == "yes")
            {
                if (monthlyFee <= 10.00)
                {
                    mobileInternetMonthlyFee = 5.50;
                }
                else if (monthlyFee > 10.00 && monthlyFee <= 30.00)
                {
                    mobileInternetMonthlyFee = 4.35;
                }
                else if (monthlyFee > 30.00)
                {
                    mobileInternetMonthlyFee = 3.85;
                }

                double totalFee = (monthlyFee + mobileInternetMonthlyFee) * monthsForPayment;

                if (contractTerm == "two")
                {
                    totalFee -= totalFee * twoYearsDiscount;
                }
                Console.WriteLine($"{totalFee:F2} lv.");
            }
            else
            {
                double totalFee = monthlyFee * monthsForPayment;

                if (contractTerm == "two")
                {
                    totalFee -= totalFee * twoYearsDiscount;
                }

                Console.WriteLine($"{totalFee:F2} lv.");
            }

        }
    }
}
