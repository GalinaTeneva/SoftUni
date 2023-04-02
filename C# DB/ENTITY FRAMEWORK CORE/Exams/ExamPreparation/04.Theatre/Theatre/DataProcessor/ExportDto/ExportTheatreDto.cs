using Newtonsoft.Json;

namespace Theatre.DataProcessor.ExportDto
{
    public class ExportTheatreDto
    {
        public string Name { get; set; } = null!;

        [JsonProperty("Halls")]
        public sbyte NumberOfHalls { get; set; }

        public decimal TotalIncome { get; set; }

        [JsonProperty("Tickets")]
        public ExportTicketDto[] TicketDtos { get; set; }
    }
}
