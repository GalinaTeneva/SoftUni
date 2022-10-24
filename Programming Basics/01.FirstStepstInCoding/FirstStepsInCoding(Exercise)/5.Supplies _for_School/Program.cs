using System;

namespace Supplies__for_School
{
    class Program
    {
        static void Main(string[] args)
        {
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            int boardCleaner = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double totalPrice = pens * 5.80 + markers * 7.20 + boardCleaner * 1.20;
            double priceWithDiscount = totalPrice - totalPrice * discount / 100;

            Console.WriteLine(priceWithDiscount);
        }
    }
}
