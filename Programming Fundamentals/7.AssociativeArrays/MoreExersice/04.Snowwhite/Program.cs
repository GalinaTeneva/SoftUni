using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dwarfs = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "Once upon a time")
            {
                string[] dwarfData = input.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);
                string dwarfName = dwarfData[0];
                string dwarfHatColor = dwarfData[1];
                int dwarfPhysics = int.Parse(dwarfData[2]);
                string dwarfId = $"{dwarfName}:{dwarfHatColor}";

                if (!dwarfs.ContainsKey(dwarfId))
                {
                    dwarfs.Add(dwarfId, dwarfPhysics);
                }
                else
                {
                    if (dwarfs.GetValueOrDefault(dwarfId) < dwarfPhysics)
                    {
                        dwarfs[dwarfId] = dwarfPhysics;
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var dwarf in dwarfs.OrderByDescending(dwarf => dwarf.Value).ThenByDescending(dwarf => dwarfs.Where(hatColor => hatColor.Key.Split(':')[1] == dwarf.Key.Split(':')[1]).Count()))
            {
                string hatColor = dwarf.Key.Split(':')[1];
                string dwarfName = dwarf.Key.Split(':')[0];
                int dwarfPhysics = dwarf.Value;
                Console.WriteLine($"({hatColor}) {dwarfName} <-> {dwarfPhysics}");
            }
        }
    }
}
