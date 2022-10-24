using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int sumOfRemovedNums = 0;
            while (numbers.Count != 0)
            {
                int indexToRemove = int.Parse(Console.ReadLine());

                if (indexToRemove < 0)
                {
                    indexToRemove = 0;
                    numbers.Insert(1, numbers[numbers.Count - 1]);

                }
                else if (indexToRemove > numbers.Count - 1)
                {
                    numbers.Insert(numbers.Count - 1, numbers[0]);
                    indexToRemove = numbers.Count - 1;
                }

                int removedNum = numbers[indexToRemove];
                sumOfRemovedNums += removedNum;
                numbers.RemoveAt(indexToRemove);

                for (int currNum = 0; currNum < numbers.Count; currNum++)
                {
                    if (numbers[currNum] > removedNum)
                    {
                        numbers[currNum] -= removedNum;
                    }
                    else if (numbers[currNum] <= removedNum)
                    {
                        numbers[currNum] += removedNum;
                    }
                }
            }

            Console.WriteLine(sumOfRemovedNums);
        }
    }
}
