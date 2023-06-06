using System;

namespace _03.GeneratingVectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[] arr = new int[num];

            Generate01(arr, 0);
        }

        private static void Generate01(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(string.Empty, arr));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                arr[index] = i;

                Generate01(arr, index + 1);
            }
        }
    }
}