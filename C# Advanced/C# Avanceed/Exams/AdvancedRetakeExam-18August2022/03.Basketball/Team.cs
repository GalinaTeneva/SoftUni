using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private Dictionary<string, Player> players;

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            players = new Dictionary<string, Player>();
        }

        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }

        public int Count => players.Count;

        public string AddPlayer(Player player)
        {
            if (OpenPositions > 0)
            {
                if (String.IsNullOrEmpty(player.Name) || String.IsNullOrEmpty(player.Position))
                {
                    return "Invalid player's information.";
                }
                else if (player.Rating < 80)
                {
                    return "Invalid player's rating.";
                }
            }
            else
            {
                return "There are no more open positions.";
            }

            players.Add(player.Name, player);
            return $"Successfully added {player.Name} to the team. Remaining open positions: {--OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            if (!players.ContainsKey(name))
            {
                return false;
            }

            players.Remove(name);
            OpenPositions++;
            return true;
        }

        public int RemovePlayerByPosition(string position)
        {
            if (players.Any(p => p.Value.Position == position))
            {
                int count = 0;
                var selectedPlayers = players.Where(p => p.Value.Position == position);
                foreach (var pair in selectedPlayers)
                {
                    players.Remove(pair.Key);
                    count++;
                    OpenPositions++;
                }
                return count;
            }

            return 0;
        }

        public Player RetirePlayer(string name)
        {
            if (!players.ContainsKey(name))
            {
                return null;
            }

            Player player = players.First(p => p.Key == name).Value;
            player.Retired = true;
            
            return player;
        }

        public List<Player> AwardPlayers(int games)
        {
            return players.Where(p => p.Value.Games >= games).Select(p => p.Value).ToList();
        }

        public string Report ()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");
            foreach (var pair in players.Where(p => p.Value.Retired == false))
            {
                sb.AppendLine(pair.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
