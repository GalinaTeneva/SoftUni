namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            ExportTheatreDto[] theatreDtos = context.Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .Select(t => new ExportTheatreDto
                {
                    Name = t.Name,
                    NumberOfHalls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .Where(ticket => ticket.RowNumber >= 1 && ticket.RowNumber <= 5).Sum(ticket => ticket.Price),
                    TicketDtos = t.Tickets
                        .Where(ticket => ticket.RowNumber >= 1 && ticket.RowNumber <= 5)
                        .Select(ticket => new ExportTicketDto
                        {
                            Price = ticket.Price,
                            RowNumber = ticket.RowNumber,
                        })
                        .OrderByDescending(ticket => ticket.Price)
                        .ToArray()

                })
                .OrderByDescending(t => t.NumberOfHalls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theatreDtos, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double raiting)
        {
            ExportPlayDto[] playDtos = context.Plays
                .Where(p => p.Rating <= raiting)
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .Select(p => new ExportPlayDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString(),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    actorDtos = p.Casts
                        .Where(a => a.IsMainCharacter == true)
                        .Select(a => new ExportActorDto()
                        {
                            FullName = a.FullName,
                            IsMainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .OrderByDescending(a => a.FullName)
                        .ToArray()
                })
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPlayDto[]), xmlRoot);

            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(writer, playDtos, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
