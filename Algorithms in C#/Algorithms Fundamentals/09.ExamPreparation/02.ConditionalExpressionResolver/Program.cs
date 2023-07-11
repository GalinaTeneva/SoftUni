namespace _02.ConditionalExpressionResolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] expression = Console.ReadLine()
                .Split()
                .Select(x => x[0])
                .ToArray();

            Console.WriteLine(ParseExpression(expression, 0));
        }

        private static int ParseExpression(char[] expression, int idx)
        {
            if (char.IsDigit(expression[idx]))
            {
                return expression[idx] - '0';
            }

            if (expression[idx] == 't')
            {
                return ParseExpression(expression, idx + 2);
            }

            int foundConditions = 0;

            for (int i = idx + 2; i < expression.Length; i++)
            {
                int currSymbol = expression[i];

                if (currSymbol == '?')
                {
                    foundConditions++;
                }
                else if (currSymbol == ':')
                {
                    foundConditions--;

                    if (foundConditions < 0)
                    {
                        ParseExpression(expression, i + 1);
                    }
                }
            }

            throw new InvalidOperationException();
        }
    }
}