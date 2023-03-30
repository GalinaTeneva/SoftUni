namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Globalization;
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
                .Where(t => t.TeamsFootballers.Any(f => f.Footballer.ContractStartDate >= date))
                .ToArray()
                .Select(t => new ExportTeamFootballerDto
                {
                    Name = t.Name,
                    FootballerDtos = t.TeamsFootballers
                        .Where(tf => tf.Footballer.ContractStartDate >= date)
                        .ToArray()
                        .OrderByDescending(tf => tf.Footballer.ContractEndDate)
                        .ThenBy(tf => tf.Footballer.Name)
                        .Select(tf => new ExportFootballerDto
                        {
                            Name = tf.Footballer.Name,
                            ContractStartDate = tf.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = tf.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = tf.Footballer.BestSkillType.ToString(),
                            PositionType = tf.Footballer.PositionType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(t => t.FootballerDtos.Length)
                .ThenBy(t => t.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teamDtos, Formatting.Indented);
        }
    }
}
