namespace _03.LongestCommonSubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            int[,] lcs = new int[str1.Length + 1, str2.Length + 1];


            for (int r = 1; r < lcs.GetLength(0); r++)
            {
                for (int c = 1; c < lcs.GetLength(1); c++)
                {
                    if (str1[r - 1] == str2[c - 1])
                    {
                        lcs[r, c] = lcs[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        lcs[r, c] = Math.Max(lcs[r, c - 1], lcs[r - 1, c]);
                    }
                }
            }

            Console.WriteLine(lcs[str1.Length, str2.Length]);
        }
    }
}