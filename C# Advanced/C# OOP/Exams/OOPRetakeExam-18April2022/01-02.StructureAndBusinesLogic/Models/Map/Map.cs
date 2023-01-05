using Heroes.Models.Contracts;

using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> heroes)
        {
            var allKnights = heroes.Where(p => p.GetType().Name == "Knight").ToList();
            var allBarbarians = heroes.Where(p => p.GetType().Name == "Barbarian").ToList();

            while (true)
            {
                foreach (IHero knight in allKnights)
                {
                    if (knight.IsAlive)
                    {
                        foreach (IHero barbarian in allBarbarians)
                        {
                            if (barbarian.IsAlive)
                            {
                                barbarian.TakeDamage(knight.Weapon.DoDamage());
                            }
                        }
                    }
                }

                if (allBarbarians.All(b => b.IsAlive == false))
                {
                    var deadKnights = allKnights.Where(k => k.IsAlive == false).ToList();
                    return $"The knights took {deadKnights.Count} casualties but won the battle.";
                }

                foreach (IHero barbarian in allBarbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        foreach (IHero knight in allKnights)
                        {
                            if (knight.IsAlive)
                            {
                                knight.TakeDamage(barbarian.Weapon.DoDamage());
                            }
                        }
                    }
                }

                if (allKnights.All(k => k.IsAlive == false))
                {
                    var deadBarbarians = allBarbarians.Where(b => b.IsAlive == false).ToList();
                    return $"The barbarians took {deadBarbarians.Count} casualties but won the battle.";
                }
            }
        }
    }
}
