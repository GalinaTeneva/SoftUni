using System;

namespace _05._Game_Of_Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int gameTurns = int.Parse(Console.ReadLine());

            double result = 0;
            int betweenZeroAndNineCounter = 0;
            int betweenTenAndNineteenCounter = 0;
            int betweenTwentyAndTwentynineCounter = 0;
            int betweenThirtyAndThirtynineCounter = 0;
            int betweenFourtyAndFiftyCounter = 0;
            int invalidNumsCounter = 0;

            for (int currentTurn = 1; currentTurn <= gameTurns; currentTurn++)
            {
                int currentNum = int.Parse(Console.ReadLine());

                if (currentNum >= 0 && currentNum <= 9)
                {
                    result += currentNum * 0.2;
                    betweenZeroAndNineCounter++;
                }
                else if (currentNum >= 10 && currentNum <= 19)
                {
                    result += currentNum * 0.3;
                    betweenTenAndNineteenCounter++;
                }
                else if (currentNum >= 20 && currentNum <= 29)
                {
                    result += currentNum * 0.4;
                    betweenTwentyAndTwentynineCounter++;
                }
                else if (currentNum >= 30 && currentNum <= 39)
                {
                    result += 50;
                    betweenThirtyAndThirtynineCounter++;
                }
                else if (currentNum >= 40 && currentNum <= 50)
                {
                    result += 100;
                    betweenFourtyAndFiftyCounter++;
                }
                else if (currentNum < 0 || currentNum > 50)
                {
                    result /= 2;
                    invalidNumsCounter++;
                }
            }

            Console.WriteLine($"{result:F2}");
            Console.WriteLine($"From 0 to 9: {(betweenZeroAndNineCounter / (double)gameTurns * 100):F2}%");
            Console.WriteLine($"From 10 to 19: {(betweenTenAndNineteenCounter / (double)gameTurns * 100):F2}%");
            Console.WriteLine($"From 20 to 29: {(betweenTwentyAndTwentynineCounter/ (double)gameTurns * 100):F2}%");
            Console.WriteLine($"From 30 to 39: {(betweenThirtyAndThirtynineCounter/ (double)gameTurns * 100):F2}%");
            Console.WriteLine($"From 40 to 50: {(betweenFourtyAndFiftyCounter/ (double)gameTurns * 100):F2}%");
            Console.WriteLine($"Invalid numbers: {(invalidNumsCounter/ (double)gameTurns * 100):F2}%");
        }
    }
}
