namespace _07.MinimumEditDistance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int replaceCost = int.Parse(Console.ReadLine());
            int insertCost = int.Parse(Console.ReadLine());
            int deleteCost = int.Parse(Console.ReadLine());

            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            int[,] dp = new int[str1.Length + 1, str2.Length + 1];

            for (int c = 1; c < dp.GetLength(1); c++)
            {
                dp[0, c] = dp[0, c - 1] + insertCost;
            }

            for (int r = 1; r < dp.GetLength(0); r++)
            {
                dp[r, 0] = dp[r - 1, 0] + deleteCost;
            }

            for (int r = 1; r < dp.GetLength(0); r++)
            {
                for (int c = 1; c < dp.GetLength(1); c++)
                {
                    if (str1[r - 1] == str2[c - 1])
                    {
                        dp[r, c] = dp[r - 1, c - 1];
                    }
                    else
                    {
                        int replace = dp[r - 1, c - 1] + replaceCost;
                        int delete = dp[r - 1, c] + deleteCost;
                        int insert = dp[r, c - 1] + insertCost;

                        dp[r, c] = Math.Min(Math.Min(replace, delete), insert);
                    }
                }
            }

            Console.WriteLine($"Minimum edit distance: {dp[str1.Length, str2.Length]}");
        }
    }
}