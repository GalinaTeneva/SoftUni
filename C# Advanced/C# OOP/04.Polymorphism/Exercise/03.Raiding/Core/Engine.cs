
namespace Raiding.Core
{
    using System;
    using System.Collections.Generic;

    using Interfaces;
    using Factories.Interfaces;
    using IO.Interfaces;
    using Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IHeroFactory heroFactory;

        private readonly ICollection<IBaseHero> heroes;

        public Engine()
        {
            heroes = new HashSet<IBaseHero>();
        }

        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = heroFactory;
        }

        public void Run()
        {
            int heroesCount = int.Parse(reader.ReadLine());

            while (heroes.Count < heroesCount)
            {
                IBaseHero hero = null;

                try
                {
                    string heroName = reader.ReadLine();
                    string heroType = reader.ReadLine();

                    hero = heroFactory.CreateHero(heroName, heroType);
                    heroes.Add(hero);
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
                catch (Exception)
                {
                    throw;
                }

            }

            int bossPower = int.Parse(reader.ReadLine());

            int heroesPowerSum = 0;
            foreach (IBaseHero hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
                heroesPowerSum += hero.Power;
            }

            if (heroesPowerSum >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }
    }
}
