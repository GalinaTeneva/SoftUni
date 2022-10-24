using System;

namespace _07.SafePasswordsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int indexXMaxValue = int.Parse(Console.ReadLine());
            int indexYMaxValue = int.Parse(Console.ReadLine());
            int maxPasswords = int.Parse(Console.ReadLine());

            int passwordsCounter = 0;
            int currentIndexA = 35;
            int currentIndexB = 64;
           
            for (int currentIndexX = 1; currentIndexX <= indexXMaxValue; currentIndexX++)
            {
                for (int currentIndexY = 1; currentIndexY <= indexYMaxValue; currentIndexY++)
                {
                    if (passwordsCounter < maxPasswords)
                    {
                        Console.Write($"{(char)currentIndexA}{(char)currentIndexB}{currentIndexX}{currentIndexY}{(char)currentIndexB}{(char)currentIndexA}|");
                        passwordsCounter++;
                    }
                    else
                    {
                        return;
                    }

                    currentIndexA++;
                    currentIndexB++;

                    if (currentIndexA >55)
                    {
                        currentIndexA = 35;
                    }
                    if (currentIndexB > 96)
                    {
                        currentIndexB = 64;
                    }
                }
            }
        }
    }
}
