namespace _06.ConnectingCables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var positions = Enumerable.Range(1, numbers.Length).ToArray();

            var dp = new int[numbers.Length + 1, numbers.Length + 1];

            for (int r = 1; r < dp.GetLength(0); r++)
            {
                for (int c = 1; c < dp.GetLength(1); c++)
                {
                    if (numbers[r - 1] == positions[c - 1])
                    {
                        dp[r, c] = dp[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        dp[r, c] = Math.Max(dp[r - 1, c], dp[r, c - 1]);
                    }
                }
            }

            Console.WriteLine($"Maximum pairs connected: {dp[numbers.Length, numbers.Length]}");
        }
    }
}