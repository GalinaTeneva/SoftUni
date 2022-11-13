
namespace BirthdayCelebrations.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using Models;
    using Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly ICollection<ILivingCreature> creatures;

        public Engine()
        {
            this.creatures = new HashSet<ILivingCreature>();
        }

        public void Run()
        {
            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                string[] cmdTokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string guestType = cmdTokens[0];
                string nameOrModel = cmdTokens[1];

                ILivingCreature creature = null;
                if (guestType == "Citizen")
                {
                    string id = cmdTokens[3];
                    int age = int.Parse(cmdTokens[2]);
                    string birthdate = cmdTokens[4];

                    creature = new Citizen(id, nameOrModel, age, birthdate);
                }
                else if (guestType == "Pet")
                {
                    string birthdate = cmdTokens[2];

                    creature = new Pet(nameOrModel, birthdate);
                }
                else
                {
                    cmd = Console.ReadLine();
                    continue;
                }

                creatures.Add(creature);

                cmd = Console.ReadLine();
            }

            string year = Console.ReadLine();

            var selectedCreatures = creatures.Where(c => c.Birthdate.EndsWith(year));

            Console.WriteLine(string.Join(Environment.NewLine, selectedCreatures));
        }
    }
}
