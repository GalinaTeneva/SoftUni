using System;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string valueType = Console.ReadLine();

            if (valueType == "int")
            {
                int firstValue = int.Parse(Console.ReadLine());
                int secondValue = int.Parse(Console.ReadLine());

                Console.WriteLine(GetMax(firstValue, secondValue));
            }
            else if (valueType == "char")
            {
                char firstValue = char.Parse(Console.ReadLine());
                char secondValue = char.Parse(Console.ReadLine());

                Console.WriteLine(GetMax(firstValue, secondValue));
            }
            else if (valueType == "string")
            {
                string firstValue = Console.ReadLine();
                string secondValue = Console.ReadLine();

                Console.WriteLine(GetMax(firstValue, secondValue));
            }
        }

        static int GetMax(int firstValue, int secondValue)
        {
            if (firstValue > secondValue)
            {
                return firstValue;
            }

            return secondValue;
        }

        static char GetMax(char firstValue, char secondValue)
        {
            if (firstValue > secondValue)
            {
                return firstValue;
            }

            return secondValue;
        }

        static string GetMax(string firstValue, string secondValue)
        {
            int result = firstValue.CompareTo(secondValue);

            if (result > 0)
            {
                return firstValue;
            }

            return secondValue;
        }
    }
}
