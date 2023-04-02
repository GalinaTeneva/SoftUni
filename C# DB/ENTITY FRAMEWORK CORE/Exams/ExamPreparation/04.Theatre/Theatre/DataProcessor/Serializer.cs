namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
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
            throw new NotImplementedException();
        }
    }
}
