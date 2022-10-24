using System;

namespace _02._Bike_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            int juniorBikersNum = int.Parse(Console.ReadLine());
            int seniorBikersNum = int.Parse(Console.ReadLine());
            string routeType = Console.ReadLine();

            double juniorFee = 0;
            double seniorFee = 0;
            if (routeType == "trail")
            {
                juniorFee = 5.50;
                seniorFee = 7.00;
            }
            else if (routeType == "cross-country")
            {
                juniorFee = 8.00;
                seniorFee = 9.50;

                if ((juniorBikersNum + seniorBikersNum) >= 50)
                {
                    juniorFee -= juniorFee * 0.25;
                    seniorFee -= seniorFee * 0.25;
                }
            }
            else if (routeType == "downhill")
            {
                juniorFee = 12.25;
                seniorFee = 13.75;
            }
            else if (routeType == "road")
            {
                juniorFee = 20.00;
                seniorFee = 21.50;
            }

            double totalIncome = (juniorBikersNum * juniorFee) + (seniorBikersNum * seniorFee);
            double organizationalCosts = totalIncome * 0.05;
            double finalAmount = totalIncome - organizationalCosts;

            Console.WriteLine($"{finalAmount:F2}");
        }
    }
}
