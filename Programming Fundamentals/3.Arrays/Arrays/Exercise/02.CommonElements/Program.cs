using System;

namespace _02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split();
            string[] secondInput = Console.ReadLine().Split();

            string[] commonElements = new string[firstInput.Length];
            string result = string.Empty;
            for (int i = 0; i < firstInput.Length; i++)
            {
                for (int j = 0; j < secondInput.Length; j++)
                {
                    bool isCommon = secondInput[j] == firstInput[i];
                    if (isCommon)
                    {
                        Console.Write(secondInput[j] + " ");
                    }

                }
            }
        }
    }
}
