namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Coaches");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCoachDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportCoachDto[] coachDtos = (ImportCoachDto[])xmlSerializer.Deserialize(reader);

            StringBuilder sb = new StringBuilder();

            ICollection<Coach> validCoaches = new List<Coach>();
            foreach (ImportCoachDto coachDto in coachDtos)
            {
                if (!IsValid(coachDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach coach = new Coach();
                coach.Name = coachDto.Name;
                coach.Nationality = coachDto.Nationality;

                foreach (ImportFootballerDto footballerDto in coachDto.FootballerDtos)
                {
                    if (!IsValid(footballerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer footballer = new Footballer();

                    footballer.Name = footballerDto.Name;
                    footballer.ContractStartDate = DateTime.ParseExact(footballerDto.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    footballer.ContractEndDate = DateTime.ParseExact(footballerDto.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    footballer.PositionType = (PositionType)footballerDto.PositionType;
                    footballer.BestSkillType = (BestSkillType)footballerDto.BestSkillType;

                    if (footballer.ContractEndDate < footballer.ContractStartDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    coach.Footballers.Add(footballer);
                }

                validCoaches.Add(coach);

                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }

            context.Coaches.AddRange(validCoaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            ImportTeamDto[] teamDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            ICollection<Team> validTeams = new List<Team>();
            foreach (ImportTeamDto teamDto in teamDtos)
            {
                if (!IsValid(teamDto) ||
                    teamDto.Trophies <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = new Team();
                team.Name = teamDto.Name;
                team.Nationality = teamDto.Nationality;
                team.Trophies = teamDto.Trophies;

                int[] existingFootballerIds = context.Footballers.Select(f => f.Id).ToArray();

                foreach (int footballerId in teamDto.Footballers.Distinct())
                {
                    if (!existingFootballerIds.Contains(footballerId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    TeamFootballer teamFootballer = new TeamFootballer()
                    {
                        Team = team,
                        FootballerId = footballerId,
                    };

                    team.TeamsFootballers.Add(teamFootballer);
                }

                validTeams.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count()));
            }

            context.Teams.AddRange(validTeams);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
