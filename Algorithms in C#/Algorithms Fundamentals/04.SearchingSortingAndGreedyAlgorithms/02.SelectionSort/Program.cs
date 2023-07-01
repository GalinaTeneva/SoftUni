using System.Runtime.ExceptionServices;

namespace _02.SelectionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            SelectionSort(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void SelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int idxMin = i;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[idxMin] > numbers[j])
                    {
                        idxMin = j;
                    }
                }

                Swap(numbers, i, idxMin);
            }  
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            int temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}