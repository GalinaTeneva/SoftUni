using System;
using System.Linq;

namespace _01.EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            int[] encryptedNames = new int[lines];

            for (int currLine = 0; currLine < lines; currLine++)
            {
                string currString = Console.ReadLine();

                int encryptedSymbolsSum = 0;

                for (int currIndex = 0; currIndex < currString.Length; currIndex++)
                {
                    int currSymbolCode = (int)(currString[currIndex]);

                    char currSymbolLower = char.Parse(currString[currIndex].ToString().ToLower());

                    int encryptedSymbol = 0;

                    if (currSymbolLower == 'a' || currSymbolLower == 'i' || currSymbolLower == 'o' ||
                        currSymbolLower == 'u' || currSymbolLower == 'e')
                    {
                        encryptedSymbol = currSymbolCode * currString.Length;
                    }
                    else
                    {
                        encryptedSymbol = currSymbolCode / currString.Length;
                    }

                    encryptedSymbolsSum += encryptedSymbol;
                }

                encryptedNames[currLine] = encryptedSymbolsSum;
            }

            Array.Sort(encryptedNames);

            foreach (int name in encryptedNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
