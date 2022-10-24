using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TilesMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] whiteTiles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] grayTiles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> whiteTilesStack = new Stack<int>(whiteTiles);
            Queue<int> grayTilesQueue = new Queue<int>(grayTiles);

            SortedDictionary<string, int> newTilesByLocation = new SortedDictionary<string, int>
            {
                ["Sink"] = 0,
                ["Oven"] = 0,
                ["Countertop"] = 0,
                ["Wall"] = 0,
                ["Floor"] = 0,
            };

            while (whiteTilesStack.Count != 0 && grayTilesQueue.Count != 0)
            {
                if (CheckTilesEquality(whiteTilesStack, grayTilesQueue))
                {
                    int newTileSum = MakeNewTile(whiteTilesStack, grayTilesQueue);
                    LocateNewTile(newTilesByLocation, newTileSum);
                }
                else
                {
                    ReorderTiles(whiteTilesStack, grayTilesQueue);
                }
            }

            Console.WriteLine(whiteTilesStack.Count == 0 ? "White tiles left: none" : $"White tiles left: {string.Join(", ", whiteTilesStack)}");
            Console.WriteLine(grayTilesQueue.Count == 0 ? "Grey tiles left: none" : $"Grey tiles left: {string.Join(", ", grayTilesQueue)}");

            foreach (var pair in newTilesByLocation.OrderByDescending(t => t.Value))
            {
                if (pair.Value > 0)
                {
                    Console.WriteLine($"{pair.Key}: {pair.Value}");
                }
            }
        }

        private static void ReorderTiles(Stack<int> whiteTilesStack, Queue<int> grayTilesQueue)
        {
            whiteTilesStack.Push((whiteTilesStack.Pop() / 2));
            grayTilesQueue.Enqueue(grayTilesQueue.Dequeue());
        }

        private static bool CheckTilesEquality(Stack<int> whiteTilesStack, Queue<int> grayTilesQueue)
        {
            if (whiteTilesStack.Peek() == grayTilesQueue.Peek())
            {
                return true;
            }

            return false;
        }

        private static int MakeNewTile(Stack<int> whiteTilesStack, Queue<int> grayTilesQueue)
        {
            int whiteTile = whiteTilesStack.Pop();
            int grayTile = grayTilesQueue.Dequeue();

            int newTileSum = 0;

            if (whiteTile == grayTile)
            {
                newTileSum = whiteTile + grayTile;
            }

            return newTileSum;
        }

        private static void LocateNewTile(SortedDictionary<string, int> newTilesByLocation, int newTileSum)
        {
            switch (newTileSum)
            {
                case 40:
                    newTilesByLocation["Sink"]++;
                    break;
                case 50:
                    newTilesByLocation["Oven"]++;
                    break;
                case 60:
                    newTilesByLocation["Countertop"]++;
                    break;
                case 70:
                    newTilesByLocation["Wall"]++;
                    break;
                default:
                    newTilesByLocation["Floor"]++;
                    break;
            }
        }
    }
}
