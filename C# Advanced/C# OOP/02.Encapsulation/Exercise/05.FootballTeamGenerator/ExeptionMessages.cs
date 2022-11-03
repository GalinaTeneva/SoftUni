using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public static class ExeptionMessages
    {
        public const string NameCannotBeNullORWhiteSpace = "A name should not be empty.";
        public const string InvalidStatMessage = "{0} should be between 0 and 100.";
        public const string InvalidPlayerMessage = "Player {0} is not in {1} team.";
        public const string InvalidTeam = "Team {0} does not exist.";
    }
}
