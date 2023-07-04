namespace _01.Fibonacci
{
    internal class Program
    {
        private static Dictionary<int, long> memo;

        static void Main(string[] args)
        {
            memo = new Dictionary<int, long>();

            int num = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcFib(num));
        }

        private static long CalcFib(int num)
        {
            if (memo.ContainsKey(num))
            {
                return memo[num];
            }

            if (num < 2)
            {
                return num;
            }

            long reult = CalcFib(num - 1) + CalcFib(num - 2);
            memo[num] = reult;
            return reult;
        }
    }
}