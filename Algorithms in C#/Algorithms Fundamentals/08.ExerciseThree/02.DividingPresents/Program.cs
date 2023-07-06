namespace _02.DividingPresents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] presents = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var allSums = FindAllSums(presents);

            var totalSum = presents.Sum();
            int alanSum = totalSum / 2;

            while (true)
            {
                if (allSums.ContainsKey(alanSum))
                {
                    var alanPresents = FindSubset(allSums, alanSum);

                    int bobSum = totalSum - alanSum;

                    Console.WriteLine($"Difference: {bobSum - alanSum}");
                    Console.WriteLine($"Alan:{alanSum} Bob:{bobSum}");
                    Console.WriteLine($"Alan takes: {string.Join(" ", alanPresents)}");
                    Console.WriteLine("Bob takes the rest.");

                    break;
                }

                alanSum--;
            }
        }

        private static List<int> FindSubset(Dictionary<int, int> sums, int target)
        {
            var subset = new List<int>();

            while (target != 0)
            {
                int element = sums[target];

                subset.Add(element);

                target -= element;
            }

            return subset;
        }

        private static Dictionary<int, int> FindAllSums(int[] elements)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };

            foreach (int element in elements)
            {
                int[] currSums = sums.Keys.ToArray();

                foreach (int sum in currSums)
                {
                    int newSum = sum + element;

                    if (sums.ContainsKey(newSum))
                    {
                        continue;
                    }

                    sums[newSum] = element;
                }
            }

            return sums;
        }
    }
}