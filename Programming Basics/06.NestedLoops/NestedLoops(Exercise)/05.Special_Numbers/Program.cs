using System;

namespace _05.Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                string currentNum = i.ToString();
                int counter = 0;

                for (int k = 0; k < 4; k++)
                {
                    char s = currentNum[k];
                    int currentDigit = int.Parse(s.ToString());

                    if (currentDigit == 0)
                    {
                        continue;
                    }

                    if (num % currentDigit == 0)
                    {
                        counter++;
                    }

                    if (counter == 4)
                    {
                        Console.Write(currentNum + " ");
                    }
                }
            }
        }
    }
}
