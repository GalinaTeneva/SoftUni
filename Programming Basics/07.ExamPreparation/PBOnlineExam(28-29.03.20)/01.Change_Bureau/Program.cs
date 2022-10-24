using System;

namespace _01.Change_Bureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcounsNum = int.Parse(Console.ReadLine());
            double yuansNum = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine());

            double yuansToDolars = yuansNum * 0.15;
            double bitcoinsToLeva = bitcounsNum * 1168;
            double dolarsToLeva = yuansToDolars * 1.76;
            double moneyInEuro = (bitcoinsToLeva + dolarsToLeva) / 1.95;

            double eurosAfterCommission = moneyInEuro - (moneyInEuro * commission / 100);
            Console.WriteLine($"{eurosAfterCommission:F2}");
        }
    }
}
