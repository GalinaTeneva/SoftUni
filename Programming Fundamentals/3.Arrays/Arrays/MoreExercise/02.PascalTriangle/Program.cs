using System;

namespace _02.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsNum = int.Parse(Console.ReadLine());

            long[] prevArr = new long[] { 1 };

            for (int currRow = 1; currRow <= rowsNum; currRow++)
            {
                if (currRow == 1)
                {
                    Console.WriteLine("1");
                    continue;
                }

                long[] currArr = new long[currRow];
                for (int i = 0; i < currRow; i++)
                {
                    long currNum = 0;

                    if (i == 0 || i == currRow - 1)
                    {
                        currNum = 1;

                    }
                    else
                    {
                        currNum = prevArr[i - 1] + prevArr[i];
                    }

                    currArr[i] = currNum;

                    if (i == currRow - 1)
                    {
                        prevArr = currArr;
                    }
                }

                Console.WriteLine(string.Join(" ", currArr));
            }
        }
    }
}
