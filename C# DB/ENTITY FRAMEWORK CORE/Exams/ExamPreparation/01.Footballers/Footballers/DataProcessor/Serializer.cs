namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Coaches");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCoachWithFootballersDto[]), xmlRoot);

            ExportCoachWithFootballersDto[] exportCoaches = context.Coaches
                .Where(c => c.Footballers.Count() > 0)
                .OrderByDescending(c => c.Footballers.Count)
                .ThenBy(c => c.Name)
                .Select(c => new ExportCoachWithFootballersDto()
                {
                    FootballersCount = c.Footballers.Count(),
                    CoachName = c.Name,
                    FootballerDtos = c.Footballers
                        .Select(f => new ExportCoachFootballerDto()
                        {
                            Name = f.Name,
                            Position = f.PositionType.ToString()
                        })
                        .OrderBy(f => f.Name)
                        .ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(writer, exportCoaches, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            ExportTeamFootballerDto[] teamDtos = context.Teams
                .Include(t => t.TeamsFootballers)
                .ThenInclude(tf => tf.Footballer)
                .Where(t => t.TeamsFootballers.Any(f => f.Footballer.ContractStartDate >= date))
                .Select(t => new ExportTeamFootballerDto
                {
                    FootballerName = t.Name,
                    FootballerDtos = t.TeamsFootballers
                        .Where(tf => tf.Footballer.ContractEndDate >= date)
                        .OrderByDescending(tf => tf.Footballer.ContractEndDate)
                        .ThenBy(tf => tf.Footballer.Name)
                        .Select(tf => new ExportFootballerDto
                        {
                            Name = tf.Footballer.Name,
                            ContractStartDate = tf.Footballer.ContractStartDate.ToString(),
                            ContractEndDate = tf.Footballer.ContractEndDate.ToString(),
                            BestSkillType = tf.Footballer.BestSkillType.ToString(),
                            PositionType = tf.Footballer.PositionType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(t => t.FootballerDtos.Count())
                .ThenBy(t => t.FootballerName)
                .ToArray();

            return JsonConvert.SerializeObject(teamDtos, Formatting.Indented);
        }
    }
}
