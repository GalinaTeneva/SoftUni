using System;

namespace _01.SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double numOne = double.Parse(Console.ReadLine());
            double numTwo = double.Parse(Console.ReadLine());
            double numThree = double.Parse(Console.ReadLine());

            double biggestNum = 0;
            double middleNum = 0;
            double smallestNum = 0;

            biggestNum = Math.Max(numOne, numTwo);
            smallestNum = Math.Min(numOne, numTwo);

            if (numThree >= smallestNum)
            {
                middleNum = Math.Min(biggestNum, numThree); 
                biggestNum = Math.Max(biggestNum, numThree);
            }

            if (numThree < smallestNum)
            {
                middleNum = Math.Max(smallestNum, numThree);
                smallestNum = Math.Min(smallestNum, numThree);
            }

            Console.WriteLine(biggestNum);
            Console.WriteLine(middleNum);
            Console.WriteLine(smallestNum);
        }
    }
}
