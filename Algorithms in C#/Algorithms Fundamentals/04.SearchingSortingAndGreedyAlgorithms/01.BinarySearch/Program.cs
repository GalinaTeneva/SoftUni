namespace _01.BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine()
                .Split()
                .Select(e => int.Parse(e))
                .ToArray();

            int elementToSearch = int.Parse(Console.ReadLine());

            int elementIndex = BinarySearch(elements, elementToSearch);
            Console.WriteLine(elementIndex);
        }

        private static int BinarySearch(int[] elements, int elementToSearch)
        {
            int left = 0;
            int right = elements.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (elements[mid] == elementToSearch)
                {
                    return mid;
                }
                else if (elements[mid] > elementToSearch)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1;
        }
    }
}