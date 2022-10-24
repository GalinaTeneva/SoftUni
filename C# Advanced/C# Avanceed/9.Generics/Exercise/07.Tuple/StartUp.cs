using System;

namespace _07.Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstLineTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = $"{firstLineTokens[0]} {firstLineTokens[1]}";
            Tuple<string, string> tupleOne = new Tuple<string, string>(name, firstLineTokens[2]);

            Console.WriteLine(tupleOne);


            string[] secondLineTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, int> tupleTwo = new Tuple<string, int>(secondLineTokens[0], int.Parse(secondLineTokens[1]));
            Console.WriteLine(tupleTwo);


            string[] thirdLineTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Tuple<int, double> tupleThree = new Tuple<int, double>(int.Parse(thirdLineTokens[0]), double.Parse(thirdLineTokens[1]));
            Console.WriteLine(tupleThree);
        }
    }
}
