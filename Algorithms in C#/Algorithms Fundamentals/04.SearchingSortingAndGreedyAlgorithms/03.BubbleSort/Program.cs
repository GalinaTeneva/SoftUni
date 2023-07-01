namespace _03.BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            BubbleSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void BubbleSort(int[] numbers)
        {
            bool isSorted = false;
            int sortedCount = 0;

            while (!isSorted)
            {
                isSorted = true;

                for (int secondIdx = 1; secondIdx < numbers.Length - sortedCount; secondIdx++)
                {
                    int firstIdx = secondIdx - 1;

                    if (numbers[secondIdx] < numbers[firstIdx])
                    {
                        Swap(numbers, firstIdx, secondIdx);

                        isSorted = false;
                    }
                }

                sortedCount++;
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