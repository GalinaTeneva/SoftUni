using System;
using System.Collections.Generic;

namespace _03._HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int heroesNum = int.Parse(Console.ReadLine());
            List<Hero> heroes = new List<Hero>();

            for (int currHero = 1; currHero <= heroesNum; currHero++)
            {
                string[] currHeroInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = currHeroInfo[0];
                int hitPoints = int.Parse(currHeroInfo[1]);
                int manaPoints = int.Parse(currHeroInfo[2]);

                heroes.Add(new Hero(name, hitPoints, manaPoints));
            }

            while (true)
            {
                string[] currCommand = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string commandType = currCommand[0];
                if (commandType == "End")
                {
                    break;
                }

                string heroName = currCommand[1];
                Hero currHero = heroes.Find(h => h.Name == heroName);

                if (commandType == "CastSpell")
                {
                    int manaPointsNeeded = int.Parse(currCommand[2]);
                    string spellName = currCommand[3];
                    if (currHero.ManaPoints >= manaPointsNeeded)
                    {
                        currHero.ManaPoints -= manaPointsNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {currHero.ManaPoints} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (commandType == "TakeDamage")
                {
                    int damage = int.Parse(currCommand[2]);
                    string attacker = currCommand[3];
                    currHero.HitPoints -= damage;

                    if (currHero.HitPoints > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {currHero.HitPoints} HP left!");
                    }
                    else
                    {
                        heroes.Remove(currHero);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                }
                else if (commandType == "Recharge")
                {
                    int amount = int.Parse(currCommand[2]);
                    int oldManaPoints = currHero.ManaPoints;
                    currHero.ManaPoints += amount;
                    if (currHero.ManaPoints > 200)
                    {
                        currHero.ManaPoints = 200;
                    }

                    Console.WriteLine($"{heroName} recharged for {currHero.ManaPoints - oldManaPoints} MP!");
                }
                else if (commandType == "Heal")
                {
                    int amount = int.Parse(currCommand[2]);
                    int oldHitPoints = currHero.HitPoints;
                    currHero.HitPoints += amount;
                    if (currHero.HitPoints > 100)
                    {
                        currHero.HitPoints = 100;
                    }
                    Console.WriteLine($"{heroName} healed for {currHero.HitPoints - oldHitPoints} HP!");
                }
            }

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.Name);
                Console.WriteLine($"  HP: {hero.HitPoints}");
                Console.WriteLine($"  MP: {hero.ManaPoints}");
            }
        }
    }
    class Hero
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int ManaPoints { get; set; }

        public Hero(string name, int hitPoints, int manaPoints)
        {
            Name = name;
            HitPoints = hitPoints;
            ManaPoints = manaPoints;
        }
    }
}
