using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class StartUp
    {
        static void Main()
        {
            List<Team> teams = new List<Team>();

            while (true)
            {
                try
                {
                    string[] commandTokens = Console.ReadLine().Split(";");
                    if (commandTokens[0] == "END")
                    {
                        break;
                    }

                    string teamName = commandTokens[1];

                    if (commandTokens[0] == "Team")
                    {
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    else if (commandTokens[0] == "Add")
                    {
                        Team team = teams.FirstOrDefault(t => t.Name == teamName);

                        if (team == null)
                        {
                            throw new InvalidOperationException(string.Format(ExeptionMessages.InvalidTeam, teamName));
                        }

                        string playerName = commandTokens[2];
                        int endurance = int.Parse(commandTokens[3]);
                        int sprint = int.Parse(commandTokens[4]);
                        int dribble = int.Parse(commandTokens[5]);
                        int passing = int.Parse(commandTokens[6]);
                        int shooting = int.Parse(commandTokens[7]);

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        team.AddPlayer(player);
                    }
                    else if (commandTokens[0] == "Remove")
                    {
                        string playerName = commandTokens[2];

                        Team team = teams.FirstOrDefault(t => t.Name == teamName);
                        if (team == null)
                        {
                            throw new InvalidOperationException(string.Format(ExeptionMessages.InvalidTeam, teamName));
                        }

                        team.RemovePlayer(playerName);
                    }
                    else if (commandTokens[0] == "Rating")
                    {
                        Team team = teams.FirstOrDefault(t => t.Name == teamName);
                        if (team == null)
                        {
                            throw new InvalidOperationException(string.Format(ExeptionMessages.InvalidTeam, teamName));
                        }

                        Console.WriteLine($"{team.Name} - {team.Rating}");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch(InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }
    }
}
