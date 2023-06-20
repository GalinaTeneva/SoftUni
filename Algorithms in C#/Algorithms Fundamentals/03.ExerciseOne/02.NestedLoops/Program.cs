using System;

namespace _02.NestedLoops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[] elements = new int[num];

            OrderElements(elements, 0);
        }

        private static void OrderElements(int[] elements, int idx)
        {
            if (idx >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            for (int i = 1; i <= elements.Length; i++)
            {
                elements[idx] = i;
                OrderElements(elements, idx + 1);
            }
        }
    }
}