using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] validFaces = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            char[] validSuits = new char[] { 'S', 'H', 'D', 'C' };

            List<Card> cards = new List<Card>();

            string[] inputCards = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string card in inputCards)
            {
                try
                {
                    string[] cardInfo = card.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string face = cardInfo[0];
                    char suit = char.Parse(cardInfo[1]);

                    Card currCard = CreateCard(face, suit, validFaces, validSuits);
                    cards.Add(currCard);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch(Exception)
                {
                    Console.WriteLine("Invalid card!");
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }

        static Card CreateCard(string face, char suit, string[] validFaces, char[] validSuits)
        {
            if (!validFaces.Any(f => f == face) || !validSuits.Any(s => s == suit))
            {
                throw new ArgumentException("Invalid card!");
            }

            switch (suit)
            {
                case 'S':
                    suit = '\u2660';
                    break;
                case 'H':
                    suit = '\u2665';
                    break;
                case 'D':
                    suit = '\u2666';
                    break;
                case 'C':
                    suit = '\u2663';
                    break;
            }

            return new Card(face, suit);
        }
    }

    class Card
    {
        public Card(string face, char suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face { get; set; }

        public char Suit { get; set; }

        public override string ToString()
        {
            return $"[{Face}{Suit}]";
        }
    }
}
