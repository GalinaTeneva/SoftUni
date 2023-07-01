namespace _06.MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] sorted = MergeSort(numbers);

            Console.WriteLine(string.Join(" ", sorted));
        }

        private static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                return numbers;
            }

            int[] left = numbers.Take(numbers.Length / 2).ToArray();
            int[] right = numbers.Skip(numbers.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int[] merged = new int[left.Length + right.Length];

            int mergedIdx = 0;
            int leftIdx = 0;
            int rightIdx = 0;

            while (leftIdx < left.Length && rightIdx < right.Length)
            {
                if (left[leftIdx] < right[rightIdx])
                {
                    merged[mergedIdx++] = left[leftIdx++];
                }
                else
                {
                    merged[mergedIdx++] = right[rightIdx++];
                }
            }

            for (int i = leftIdx; i < left.Length; i++)
            {
                merged[mergedIdx++] = left[i];
            }

            for (int i = rightIdx; i < right.Length; i++)
            {
                merged[mergedIdx++] = right[i];
            }

            return merged;
        }
    }
}