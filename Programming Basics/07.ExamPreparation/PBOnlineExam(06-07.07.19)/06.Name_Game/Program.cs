using System;

namespace _06.Name_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int bestScore = 0;
            string bestPlayer = null;

            while (true)
            {
                string currentPlayerName = Console.ReadLine();

                if (currentPlayerName == "Stop")
                {
                    break;
                }

                int currentPlayerPoints = 0;

                for (int i = 0; i < currentPlayerName.Length; i++)
                {
                    int num = int.Parse(Console.ReadLine());
                    char currentLetter = currentPlayerName[i];

                    if (num == ((int)currentLetter))
                    {
                        currentPlayerPoints += 10;
                    }
                    else
                    {
                        currentPlayerPoints += 2;
                    }
                }

                if (currentPlayerPoints >= bestScore)
                {
                    bestScore = currentPlayerPoints;
                    bestPlayer = currentPlayerName;
                }
            }
            Console.WriteLine("The winner is {0} with {1} points!", bestPlayer, bestScore);
        }
    }
}
