using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string emojiPattern = @"(:{2}|\*{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string digitsPattern = @"\d";
            List<Match> coolEmojis = new List<Match>();

            MatchCollection digits = Regex.Matches(text, digitsPattern);
            BigInteger coolThreshold = 1;
            foreach (Match digit in digits)
            {
                coolThreshold *= int.Parse(digit.ToString());
            }

            MatchCollection emojis = Regex.Matches(text, emojiPattern);
            foreach (Match emoji in emojis)
            {
                string currEmojiText = emoji.Groups["emoji"].ToString();
                int currEmojiColness = 0;
                foreach (char letter in currEmojiText)
                {
                    currEmojiColness += letter;
                }

                if (currEmojiColness >= coolThreshold)
                {
                    coolEmojis.Add(emoji);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");
            foreach (var validEmoji in coolEmojis)
            {
                Console.WriteLine(validEmoji);
            }
        }
    }
}
