using System;

namespace _01.Fruit_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberriesPrice = double.Parse(Console.ReadLine());
            double quantityOfBananas = double.Parse(Console.ReadLine());
            double quantityOfOranges = double.Parse(Console.ReadLine());
            double quantityOfRaspberries = double.Parse(Console.ReadLine());
            double quantityOfStrawberrirs = double.Parse(Console.ReadLine());

            double raspberriesPrice = strawberriesPrice / 2;
            double orangesPrice = raspberriesPrice - raspberriesPrice * 0.4;
            double bananasPrice = raspberriesPrice - raspberriesPrice * 0.8;

            double strawberriesCost = strawberriesPrice * quantityOfStrawberrirs;
            double bananasCost = quantityOfBananas * bananasPrice;
            double orangesCost = quantityOfOranges * orangesPrice;
            double raspberriesCost = raspberriesPrice * quantityOfRaspberries;

            double totalCost = strawberriesCost + bananasCost + orangesCost + raspberriesCost;
            Console.WriteLine($"{totalCost:F2}");
        }
    }
}
