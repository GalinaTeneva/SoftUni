using System;
using System.Text;

namespace _07_RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repeatingTimes = int.Parse(Console.ReadLine());

            string result = RepeatingString(input, repeatingTimes);
            Console.WriteLine(result);
        }

        static string RepeatingString(string originalString, int repeatingTimes)
        {
            StringBuilder result = new StringBuilder();

            for (int currentRepeating = 1; currentRepeating <= repeatingTimes; currentRepeating++)
            {
                result.Append(originalString);
            }

            return result.ToString();
        }
    }
}
