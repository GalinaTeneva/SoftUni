using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TruffleHunter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> foundTruffles = new Dictionary<char, int>()
            {
                {'B', 0},
                {'S', 0},
                {'W', 0}
            };

            int size = int.Parse(Console.ReadLine());
            char[,] forest = new char[size, size];

            for (int row = 0; row < forest.GetLength(0); row++)
            {
                char[] colElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    forest[row, col] = colElements[col];
                }
            }

            int eatenTruffles = 0;

            string cmd = Console.ReadLine();
            while (cmd != "Stop the hunt")
            {
                string[] cmdTokens = cmd.Split();
                int row = int.Parse(cmdTokens[1]);
                int col = int.Parse(cmdTokens[2]);

                if (cmdTokens[0] == "Collect")
                {
                    // collect truffle
                    if (row >= 0 && row < forest.GetLength(0) & col >= 0 && col < forest.GetLength(1))
                    {
                        char cellInfo = forest[row, col];
                        switch (cellInfo)
                        {
                            case 'B':
                                foundTruffles['B']++;
                                break;
                            case 'S':
                                foundTruffles['S']++;
                                break;
                            case 'W':
                                foundTruffles['W']++;
                                break;
                            default:
                                break;
                        }

                        forest[row, col] = '-';
                    }
                }
                else
                {
                    // move boar

                    string direction = cmdTokens[3];

                    if (direction == "up")
                    {
                        int count = 0;
                        for (int r = row; r >= 0; r--)
                        {
                            if (count % 2 == 0 && char.IsLetter(forest[r, col]))
                            {
                                eatenTruffles++;
                                forest[r, col] = '-';
                            }
                            count++;
                        }
                    }
                    else if (direction == "down")
                    {
                        int count = 0;
                        for (int r = row; r < forest.GetLength(0); r++)
                        {
                            if (count % 2 == 0 && char.IsLetter(forest[r, col]))
                            {
                                eatenTruffles++;
                                forest[r, col] = '-';
                            }
                            count++;
                        }
                    }
                    else if (direction == "left")
                    {
                        int count = 0;
                        for (int c = col; c >= 0; c--)
                        {
                            if (count % 2 == 0 && char.IsLetter(forest[row, c]))
                            {
                                eatenTruffles++;
                                forest[row, c] = '-';
                            }
                            count++;
                        }
                    }
                    else if (direction == "right")
                    {
                        int count = 0;
                        for (int c = col; c < forest.GetLength(1); c++)
                        {
                            if (count % 2 == 0 && char.IsLetter(forest[row, c]))
                            {
                                eatenTruffles++;
                                forest[row, c] = '-';
                            }
                            count++;
                        }
                    }
                }

                cmd = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {foundTruffles['B']} black, {foundTruffles['S']} summer, and {foundTruffles['W']} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenTruffles} truffles.");

            for (int row = 0; row < forest.GetLength(0); row++)
            {
                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    Console.Write(forest[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
