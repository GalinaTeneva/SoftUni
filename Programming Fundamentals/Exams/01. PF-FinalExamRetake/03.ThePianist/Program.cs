using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Piece> pieces = new List<Piece>();
            int initialPiecessCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= initialPiecessCount; i++)
            {
                string[] currPieceTokens = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string currPieceName = currPieceTokens[0];
                string currPieceComposer = currPieceTokens[1];
                string currPieceKey = currPieceTokens[2];

                Piece currPiece = new Piece(currPieceName, currPieceComposer, currPieceKey);
                pieces.Add(currPiece);
            }

            while (true)
            {
                string[] currCommandTokens = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string currCommandType = currCommandTokens[0];

                if (currCommandType == "Stop")
                {
                    break;
                }

                string pieceName = currCommandTokens[1];
                if (currCommandType == "Add")
                {
                    bool contains = pieces.Any(p => p.Name == pieceName);
                    if (!contains)
                    {
                        string pieceComposer = currCommandTokens[2];
                        string pieceKey = currCommandTokens[3];
                        pieces.Add(new Piece (pieceName, pieceComposer, pieceKey));
                        Console.WriteLine($"{pieceName} by {pieceComposer} in {pieceKey} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{pieceName} is already in the collection!");
                    }
                }
                else if (currCommandType == "Remove")
                {
                    bool contains = pieces.Any(p => p.Name == pieceName);
                    if (contains)
                    {
                        pieces.RemoveAll(p => p.Name == pieceName);
                        Console.WriteLine($"Successfully removed {pieceName}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }
                else if (currCommandType == "ChangeKey")
                {
                    bool contains = pieces.Any(p => p.Name == pieceName);

                    if (contains)
                    {
                        string newKey = currCommandTokens[2];
                        Piece piece = pieces.Find(p => p.Name == pieceName);
                        piece.Key = newKey;

                        Console.WriteLine($"Changed the key of {piece.Name} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }
            }

            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Name} -> Composer: {piece.Composer}, Key: {piece.Key}");
            }
        }
    }
    class Piece
    {
        public string Name { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }

        public Piece (string name, string composer, string key)
        {
            Name = name;
            Composer = composer;
            Key = key;
        }
    }
}
