using System;

namespace _02._Letters_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char startingLetter = char.Parse(Console.ReadLine());
            char endingLetter = char.Parse(Console.ReadLine());
            char skippingLetter = char.Parse(Console.ReadLine());

            int combinationsCounter = 0;
            for (int firstLetter = startingLetter; firstLetter <= endingLetter; firstLetter++)
            {
                if (firstLetter == skippingLetter)
                {
                    continue;
                }

                for (int secondLetter = startingLetter; secondLetter <= endingLetter; secondLetter++)
                {
                    if (secondLetter == skippingLetter)
                    {
                        continue;
                    }

                    for (int thirdLetter = startingLetter; thirdLetter <= endingLetter; thirdLetter++)
                    {
                        if (thirdLetter == skippingLetter)
                        {
                            continue;
                        }

                        Console.Write($"{(char)(firstLetter)}{(char)(secondLetter)}{(char)(thirdLetter)} ");
                        combinationsCounter++;
                    }
                }
            }

            Console.WriteLine(combinationsCounter);
        }
    }
}
