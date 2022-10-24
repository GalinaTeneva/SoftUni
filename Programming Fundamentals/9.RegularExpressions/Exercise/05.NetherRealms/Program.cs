using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _05.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] demonsArr = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string healthPattern = @"[^\+\-\*\/\.0-9]";
            string damageDigitsPattern = @"-?\d+\.?\d*";

            List<Demon> demonsList = new List<Demon>();

            foreach (string demon in demonsArr)
            {
                MatchCollection healthSymbols = Regex.Matches(demon, healthPattern);

                string healthString = string.Join("", healthSymbols);

                int currDemonHealth = 0;
                foreach (char symbol in healthString)
                {
                    currDemonHealth += symbol;
                }

                int multiplicationSymbolsCount = demon.Count(s => s == '*');
                int divisionSymbolsCount = demon.Count(s => s == '/');

                double currDemonDamage = 0;
                MatchCollection digits = Regex.Matches(demon, damageDigitsPattern);
                foreach (Match match in digits)
                {
                    currDemonDamage += double.Parse(match.ToString());
                }

                for (int i = 1; i <= multiplicationSymbolsCount; i++)
                {
                    currDemonDamage *= 2;
                }
                for (int i = 1; i <= divisionSymbolsCount; i++)
                {
                    currDemonDamage /= 2;
                }

                Demon currDemon = new Demon(demon, currDemonHealth, currDemonDamage);
                demonsList.Add(currDemon);
            }

            List<Demon> sortedDemonsList = demonsList.OrderBy(demon => demon.Name).ToList();
            foreach (var demon in sortedDemonsList)
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:F2} damage");
            }

        }
    }

    class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }

        public Demon(string name, int health, double damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
    }
}
