using System;

namespace _02.Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            for (int i = num1; i <= num2; i++)
            {
                string currentNum = i.ToString();

                int evenSum = 0;
                int oddSum = 0;

                for (int k = 0; k < currentNum.Length; k++)
                {
                    int currentDigit = int.Parse(currentNum[k].ToString());

                    if (k % 2 == 0)
                    {
                        evenSum += currentDigit;
                    }
                    else
                    {
                        oddSum += currentDigit;
                    }
                }

                if (evenSum == oddSum)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
