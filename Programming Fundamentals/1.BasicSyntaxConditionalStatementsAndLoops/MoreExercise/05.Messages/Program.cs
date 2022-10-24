using System;

namespace _05.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesNum = int.Parse(Console.ReadLine());

            string message = string.Empty;

            for (int i = 1; i <= linesNum; i++)
            {
                string currNum = Console.ReadLine();
                int mainDigit = int.Parse(currNum[0].ToString());

                if (mainDigit == 0)
                {
                    message += ' ';
                    continue;
                }

                int letterIndex = 0;

                if (mainDigit == 8 || mainDigit == 9)
                {
                    int ofset = (mainDigit - 2) * 3 + 1;
                    letterIndex = ofset + currNum.Length - 1;
                }
                else
                {
                    int ofset = (mainDigit - 2) * 3;
                    letterIndex = ofset + currNum.Length - 1;
                }

                char currSymbol = (char)(97 + letterIndex);
                message += currSymbol;
            }

            Console.WriteLine(message);
        }
    }
}
