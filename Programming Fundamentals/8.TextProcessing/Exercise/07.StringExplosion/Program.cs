using System;
using System.Text;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            int explosionPower = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '>')
                {
                    explosionPower += int.Parse(line[i + 1].ToString());
                    sb.Append(line[i]);
                }
                else if (explosionPower == 0)
                {
                    sb.Append(line[i]);
                }
                else
                {
                    explosionPower--;
                }
            }

            Console.WriteLine(sb);
        }
    }
}
