using System;

namespace _14.PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            for (int firstSym = 1; firstSym <= firstNum; firstSym++)
            {
                for (int secondSym = 1; secondSym <= firstNum; secondSym++)
                {
                    for (int thirdSym = 97; thirdSym < 97 + secondNum; thirdSym++)
                    {
                        for (int fourthSym = 97; fourthSym < 97 + secondNum; fourthSym++)
                        {
                            for (int i = 1; i <= firstNum; i++)
                            {
                                char thirdSymInChar = (char)thirdSym;
                                char fourthSymInChar = (char)fourthSym;

                                int fifthSym = 0;
                                if (i > firstSym && i > secondSym)
                                {
                                    fifthSym = i;
                                    Console.Write($"{firstSym}{secondSym}{thirdSymInChar}{fourthSymInChar}{fifthSym} ");
                                }

                            }
                        }
                    }
                }
            }
        }
    }
}
