using System;

namespace _08.Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstLineTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string town = string.Empty;
            if (firstLineTokens.Length == 5)
            {
                town = $"{firstLineTokens[3]} {firstLineTokens[4]}";
            }
            else
            {
                town = firstLineTokens[3];
            }

            Threeuple<string, string, string> threeupleOne = new Threeuple<string, string, string>
            {
                ItemOne = $"{firstLineTokens[0]} {firstLineTokens[1]}",
                ItemTwo = firstLineTokens[2],
                ItemThree = town
            };

            Console.WriteLine(threeupleOne);


            string[] secondLineTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Threeuple<string, int, bool> threeupleTwo = new Threeuple<string, int, bool>
            {
                ItemOne = secondLineTokens[0],
                ItemTwo = int.Parse(secondLineTokens[1]),
                ItemThree = (secondLineTokens[2] == "drunk")
            };

            Console.WriteLine(threeupleTwo);


            string[] thirdLineTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Threeuple<string, double, string> threeupleThree = new Threeuple<string, double, string>
            {
                ItemOne = thirdLineTokens[0],
                ItemTwo = double.Parse(thirdLineTokens[1]),
                ItemThree = thirdLineTokens[2]
            };

            Console.WriteLine(threeupleThree);
        }
    }
}
