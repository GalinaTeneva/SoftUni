using System;

namespace _06.Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double academyPoints = double.Parse(Console.ReadLine());
            int assessorsCount = int.Parse(Console.ReadLine());

            double actorPoints = academyPoints;
            double nominationPoints = 1250.5;

            for (int i = 0; i <= assessorsCount && actorPoints < nominationPoints; i++)
            {
                string assessorName = Console.ReadLine();
                double assessorPoints = double.Parse(Console.ReadLine());
                
                actorPoints += (assessorName.Length * assessorPoints / 2);

                if (actorPoints >= nominationPoints)
                {
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {actorPoints:f1}!");
                }
            }

            if (actorPoints < nominationPoints)
            {
                Console.WriteLine($"Sorry, {actorName} you need {(nominationPoints - actorPoints):f1} more!");
            }
        }
    }
}
