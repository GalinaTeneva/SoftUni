using System;

namespace _06.The_Most_Powerful_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            string mostPowerfulWord = " ";
            int mostPowerfulWordValue = 0;
            string currentWord;
            while ((currentWord = Console.ReadLine()) != "End of words")
            {
                //string currentWord = Console.ReadLine();

                //if (currentWord == "End of words")
                //{
                //    break;
                //}

                double sum = 0;
                for (int i = 0; i < currentWord.Length; i++)
                {
                    char currentLeter = currentWord[i];

                    int currentLetterValue = (int)currentLeter;
                    sum += currentLetterValue;
                }

                char firstLetterSymbol = currentWord[0];
                switch (firstLetterSymbol)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                    case 'y':
                    case 'A':
                    case 'E':
                    case 'I':
                    case 'O':
                    case 'U':
                    case 'Y':
                        sum *= currentWord.Length;
                        break;
                    default:
                        sum /= currentWord.Length;
                        break;
                }

                if (sum > mostPowerfulWordValue)
                {
                    mostPowerfulWordValue = (int)Math.Floor(sum);
                    mostPowerfulWord = currentWord;
                }
            }

            Console.WriteLine("The most powerful word is {0} - {1}", mostPowerfulWord, mostPowerfulWordValue);
        }
    }
}
