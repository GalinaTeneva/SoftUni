using System;

namespace _03._Stream_Of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentWord = string.Empty;
            int oLetterCounter = 0;
            int cLetterCounter = 0;
            int nLetterCounter = 0;
            string message = string.Empty;
            string input = " ";


            while ((input = Console.ReadLine()) != "End")
            {
                if (!(Char.IsLetter(input, 0)))
                {
                    continue;
                }

                if (input == "c" && cLetterCounter == 0)
                {
                    cLetterCounter++;
                    if (oLetterCounter == 1 && cLetterCounter == 1 && nLetterCounter == 1)
                    {
                        currentWord += " ";
                        oLetterCounter = 0;
                        cLetterCounter = 0;
                        nLetterCounter = 0;
                        message += currentWord;
                        currentWord = string.Empty;
                    }
                    continue;
                }
                else if (input == "o" && oLetterCounter == 0)
                {
                    oLetterCounter++;
                    if (oLetterCounter == 1 && cLetterCounter == 1 && nLetterCounter == 1)
                    {
                        currentWord += " ";
                        oLetterCounter = 0;
                        cLetterCounter = 0;
                        nLetterCounter = 0;
                        message += currentWord;
                        currentWord = string.Empty;
                    }
                    continue;
                }
                else if (input == "n" && nLetterCounter == 0)
                {
                    nLetterCounter++;
                    if (oLetterCounter == 1 && cLetterCounter == 1 && nLetterCounter == 1)
                    {
                        currentWord += " ";
                        oLetterCounter = 0;
                        cLetterCounter = 0;
                        nLetterCounter = 0;
                        message += currentWord;
                        currentWord = string.Empty;
                    }
                    continue;
                }

                currentWord += input;
            }

            Console.WriteLine(message);
        }
    }
}

