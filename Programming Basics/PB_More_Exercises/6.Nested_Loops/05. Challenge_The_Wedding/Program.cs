using System;

namespace _05._Challenge_The_Wedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalMen = int.Parse(Console.ReadLine());
            int totalWomen = int.Parse(Console.ReadLine());
            int maxTables = int.Parse(Console.ReadLine());

            int tablesCounter = 0;
            for (int currentMan = 1; currentMan <= totalMen; currentMan++)
            {
                for (int currentWoman = 1; currentWoman <= totalWomen; currentWoman++)
                {
                    tablesCounter++;
                    if (tablesCounter <= maxTables)
                    {
                        Console.Write($"({currentMan} <-> {currentWoman}) ");
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
