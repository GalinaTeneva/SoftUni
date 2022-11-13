
namespace MilitaryElite.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using MilitaryElite.IO.Interfaces;
    using MilitaryElite.Models;
    using MilitaryElite.Models.Enums;
    using MilitaryElite.Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICollection<ISoldier> allSoldiers;

        public Engine()
        {
            this.allSoldiers = new HashSet<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command = this.reader.ReadLine();
            while (command != "End")
            {
                string[] commandTokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string soldierType = commandTokens[0];
                int id = int.Parse(commandTokens[1]);
                string firstName = commandTokens[2];
                string lastName = commandTokens[3];

                ISoldier soldier;
                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(commandTokens[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(commandTokens[4]);

                    ICollection<IPrivate> privates = this.FindPrivates(commandTokens);

                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(commandTokens[4]);
                    string corpsText = commandTokens[5];

                    bool isCorpsValid = Enum.TryParse<Corps>(corpsText, false, out Corps corps);
                    if (!isCorpsValid)
                    {
                        command = this.reader.ReadLine();
                        continue;
                    }

                    ICollection<IRepair> repairs = CreateRepair(commandTokens);
                    soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(commandTokens[4]);
                    string corpsText = commandTokens[5];

                    bool isCorpsValid = Enum.TryParse<Corps>(corpsText, true, out Corps corps);
                    if (!isCorpsValid)
                    {
                        command = this.reader.ReadLine();
                        continue;
                    }

                    ICollection<IMission> missions = this.CreateMissions(commandTokens);
                    soldier = new Commando(id, firstName, lastName, salary, corps, missions);
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(commandTokens[4]);

                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }
                else
                {
                    command = this.reader.ReadLine();
                    continue;
                }

                this.allSoldiers.Add(soldier);

                command = this.reader.ReadLine();
            }

            foreach (ISoldier soldier in this.allSoldiers)
            {
                this.writer.WriteLine(soldier.ToString());
            }
        }

        private ICollection<IPrivate> FindPrivates(string[] commandTokens)
        {
            int[] privatesIds = commandTokens.Skip(5).Select(int.Parse).ToArray();

            ICollection<IPrivate> privates = new HashSet<IPrivate>();

            foreach (int id in privatesIds)
            {
                IPrivate currPrivate = (IPrivate)this.allSoldiers.FirstOrDefault(s => s.Id == id);

                privates.Add(currPrivate);
            }

            return privates;
        }

        private ICollection<IRepair> CreateRepair (string[] commandTokend)
        {
            ICollection<IRepair> repairs = new HashSet<IRepair>();

            string[] repairsInfo = commandTokend.Skip(6).ToArray();

            for (int i = 0; i < repairsInfo.Length; i += 2)
            {
                string partName = repairsInfo[i];
                int hoursWorked = int.Parse(repairsInfo[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);
                repairs.Add(repair);
            }

            return repairs;
        }

        private ICollection<IMission> CreateMissions (string[] commandTokens)
        {
            ICollection<IMission> missions = new HashSet<IMission>();

            string[] missionsInfo = commandTokens.Skip(6).ToArray();

            for (int i = 0; i < missionsInfo.Length; i += 2)
            {
                string codeName = missionsInfo[i];
                string StateText = missionsInfo[i + 1];

                bool isStateValid = Enum.TryParse<State>(StateText, false, out State state);
                if (!isStateValid)
                {
                    continue;
                }

                IMission mission = new Mission(codeName, state);
                missions.Add(mission);
            }

            return missions;
        }
    }
}
