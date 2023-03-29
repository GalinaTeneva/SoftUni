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
            var coachDtos = (ImportCoachDto[])xmlSerializer.Deserialize(reader);

            StringBuilder sb = new StringBuilder();

            ICollection<Coach> validCoaches = new List<Coach>();
            foreach (ImportCoachDto coachDto in coachDtos)
            {
                //if (string.IsNullOrEmpty(coachDto.Name) ||
                //    string.IsNullOrEmpty(coachDto.Nationality))
                //{
                //    return ErrorMessage;
                //}

                Coach coach = new Coach();
                coach.Name = coachDto.Name ?? "";
                coach.Nationality = coachDto.Nationality ?? "";

                if (!IsValid(coach))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validCoaches.Add(coach);

                foreach (ImportFootballerDto footballerDto in coachDto.FootballerDtos)
                {
                    Footballer footballer = new Footballer();

                    try
                    {
                        footballer.Name = footballerDto.Name ?? "";
                        footballer.ContractStartDate = DateTime.ParseExact(footballerDto.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        footballer.ContractEndDate = DateTime.ParseExact(footballerDto.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        footballer.PositionType = (PositionType)footballerDto.PositionType;
                        footballer.BestSkillType = (BestSkillType)footballerDto.BestSkillType;

                        if (!IsValid(footballer) ||
                            footballer.ContractEndDate < footballer.ContractStartDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }
                    catch (Exception)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    coach.Footballers.Add(footballer);
                }

                sb.AppendLine(string.Format(SuccessfullyImportedTeam, coach.Name, coach.Footballers.Count));
            }

            context.Coaches.AddRange(validCoaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            ImportTeamDto[] teamDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            ICollection<Team> validTeams = new HashSet<Team>();
            foreach (ImportTeamDto teamDto in teamDtos)
            {
                Team team = new Team();
                team.Name = teamDto.Name ?? "";
                team.Nationality = teamDto.Nationality ?? "";

                if (!int.TryParse(teamDto.Trophies, out var trophiesCount) ||
                    trophiesCount <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                team.Trophies = trophiesCount;

                if (!IsValid(team))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //ICollection<Footballer> footballers = new HashSet<Footballer>();
                foreach (int footballerId in teamDto.Footballers.Distinct())
                {
                    Footballer? footballer = context.Footballers.Find(footballerId);
                    if (footballer == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //if (!team.TeamsFootballers.Any(f => f.FootballerId == footballerId))
                    //{
                    //    team.TeamsFootballers.Add(new TeamFootballer()
                    //    {
                    //        Footballer = footballer,
                    //        FootballerId = footballerId
                    //    });
                    //}
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
