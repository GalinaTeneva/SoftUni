namespace _01.BinomialCoefficients
{
    internal class Program
    {
        private static Dictionary<string, long> cache;

        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            cache = new Dictionary<string, long>();

            Console.WriteLine(GetBinom(row, col));

        }

        private static long GetBinom(int row, int col)
        {
            if (col == 0 || col == row)
            {
                return 1;
            }

            string key = $"{row}-{col}";

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            long result = GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);
            cache[key] = result;

            return result;
        }
    }
}