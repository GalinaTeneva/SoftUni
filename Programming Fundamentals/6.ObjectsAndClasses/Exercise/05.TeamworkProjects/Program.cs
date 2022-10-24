using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int currTeam = 1; currTeam <= teamsCount; currTeam++)
            {
                string[] teamInfo = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);
                string teamCreator = teamInfo[0];
                string teamName = teamInfo[1];

                if (teams.Any(team => team.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(team => team.Creator == teamCreator))
                {
                    Console.WriteLine($"{teamCreator} cannot create another team!");
                }
                else
                {
                    Team team = new Team(teamCreator, teamName);
                    team.Members = new List<string>();
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {teamCreator}!");
                }
            }

            string input = Console.ReadLine();
            while (input != "end of assignment")
            {
                string[] memberInfo = input.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string memberName = memberInfo[0];
                string teamToJoin = memberInfo[1];

                if (teams.Any(team => team.Members.Contains(memberName)) || teams.Any(creator => creator.Creator == memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamToJoin}!");
                }
                else if (teams.All(team => team.Name != teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }
                else
                {
                    var team = teams.Find(team => team.Name == teamToJoin);
                    team.Members.Add(memberName);
                }

                input = Console.ReadLine();
            }
            var fullTeams = teams.Where(team => team.Members.Count > 0);
            var disbandedTeams = teams.Where(team => team.Members.Count == 0);

            foreach (var team in fullTeams.OrderByDescending(team => team.Members.Count).ThenBy(team => team.Name))
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.Creator}");
                foreach (var member in team.Members.OrderBy(team => team))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");
            if (disbandedTeams != null)
            {
                foreach (var disbanedTeam in disbandedTeams.OrderBy(team => team.Name))
                {
                    Console.WriteLine($"{disbanedTeam.Name}");
                }
            }

        }
    }

    class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

        public Team(string creator, string name)
        {
            Creator = creator;
            Name = name;
        }
    }
}
