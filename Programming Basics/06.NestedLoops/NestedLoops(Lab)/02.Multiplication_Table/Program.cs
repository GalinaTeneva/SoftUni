﻿using System;

namespace _02.Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int multiplier1 = 1; multiplier1 <= 10; multiplier1++)
            {
                for(int multiplier2 = 1; multiplier2 <= 10; multiplier2++)
                {
                    int result = multiplier1 * multiplier2;
                    Console.WriteLine($"{multiplier1} * {multiplier2} = {result}");
                }
            }
        }
    }
}
