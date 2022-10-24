using System;

namespace _09._Fuel_Tank_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double gasolinePrice = 2.22;
            double dieselPrice = 2.33;
            double gasPrice = 0.93;

            double gasolineDiscount = 0.18;
            double dieselDiscount = 0.12;
            double gasDiscount = 0.08;

            string fuelType = Console.ReadLine();
            double fuelQuantity = double.Parse(Console.ReadLine());
            string discountCartPossession = Console.ReadLine();

            double fuelPrice = 0;
            if (fuelType == "Gasoline")
            {
                fuelPrice = gasolinePrice * fuelQuantity;

                if (discountCartPossession == "Yes")
                {
                    fuelPrice -= gasolineDiscount * fuelQuantity;
                }

                if (fuelQuantity >= 20 && fuelQuantity <= 25)
                {
                    double discount = 0.08;
                    fuelPrice -= fuelPrice * discount;
                }
                else if (fuelQuantity > 25)
                {
                    double discount = 0.1;
                    fuelPrice -= fuelPrice * discount;
                }
            }
            else if (fuelType == "Diesel")
            {
                fuelPrice = dieselPrice * fuelQuantity;

                if (discountCartPossession == "Yes")
                {
                    fuelPrice -= dieselDiscount * fuelQuantity;
                }

                if (fuelQuantity >= 20 && fuelQuantity <= 25)
                {
                    double discount = 0.08;
                    fuelPrice -= fuelPrice * discount;
                }
                else if (fuelQuantity > 25)
                {
                    double discount = 0.1;
                    fuelPrice -= fuelPrice * discount;
                }
            }
            else if (fuelType == "Gas")
            {
                fuelPrice = gasPrice * fuelQuantity;

                if (discountCartPossession == "Yes")
                {
                    fuelPrice -= gasDiscount * fuelQuantity;
                }

                if (fuelQuantity >= 20 && fuelQuantity <= 25)
                {
                    double discount = 0.08;
                    fuelPrice -= fuelPrice * discount;
                }
                else if (fuelQuantity > 25)
                {
                    double discount = 0.1;
                    fuelPrice -= fuelPrice * discount;
                }
            }

            Console.WriteLine($"{fuelPrice:F2} lv.");
        }
    }
}
