using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        private Team()
        {
            players = new List<Player>();
        }

        public Team(string name)
            : this()
        {
            Name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExeptionMessages.NameCannotBeNullORWhiteSpace);
                }
                name = value;
            }
        }

        public double Rating => players.Count > 0 ? (int)Math.Round(players.Average(p => p.Level), 0) : 0;

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player player = players.FirstOrDefault(p => p.Name == name);
            if (player == null)
            {
                throw new InvalidOperationException(string.Format(ExeptionMessages.InvalidPlayerMessage, name, Name));
            }
            players.Remove(player);
        }
    }
}
