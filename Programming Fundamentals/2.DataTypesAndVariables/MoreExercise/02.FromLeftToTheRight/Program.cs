using System;

namespace _02.FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesNum = int.Parse(Console.ReadLine());

            for (int currLine = 1; currLine <= linesNum; currLine++)
            {
                string currInput = Console.ReadLine();

                int symbolsCounter = 0;
                for (int i = 0; i < currInput.Length; i++)
                {
                    char currSymbol = currInput[i];
                    symbolsCounter++;

                    if (currSymbol == ' ')
                    {
                        string leftString = currInput.Substring(0, symbolsCounter - 1);
                        string rightString = currInput.Substring(symbolsCounter);

                        long leftNum = long.Parse(leftString);
                        long rightNum = long.Parse(rightString);

                        int numsSum = 0;
                        if (leftNum > rightNum)
                        {
                            for (int j = 0; j < leftString.Length; j++)
                            {
                                if (leftString[j] == '-')
                                {
                                    continue;
                                }
                                char symbol = leftString[j];
                                int currNum = int.Parse(symbol.ToString());
                                numsSum += currNum;
                            }
                        }
                        else
                        {
                            for (int j = 0; j < rightString.Length; j++)
                            {
                                if (rightString[j] == '-')
                                {
                                    continue;
                                }
                                char symbol = rightString[j];
                                int currNum = int.Parse(symbol.ToString());
                                numsSum += currNum;
                            }
                        }

                        Console.WriteLine(numsSum);
                    }
                }
            }
        }
    }
}
