namespace _08.SetCover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> unuverse = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToHashSet();

            int setsNum = int.Parse(Console.ReadLine());

            List<int[]> sets = new List<int[]>();

            for (int i = 0; i < setsNum; i++)
            {
                int[] currSet = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                sets.Add(currSet);
            }

            List<int[]> selectedSets = new List<int[]>();

            while (unuverse.Count > 0)
            {
                int[] set = sets
                    .OrderByDescending(s => s.Count(e => unuverse.Contains(e)))
                    .FirstOrDefault();

                selectedSets.Add(set);
                sets.Remove(set);

                foreach (int element in set)
                {
                    unuverse.Remove(element);
                }
            }

            Console.WriteLine($"Sets to take ({selectedSets.Count}):");

            foreach (int[] set in selectedSets)
            {
                Console.WriteLine(string.Join(", ", set));
            }
        }
    }
}