using Newtonsoft.Json;

namespace Footballers.DataProcessor.ExportDto
{
    public class ExportTeamFootballerDto
    {
        public string FootballerName { get; set; } = null!;

        [JsonProperty("Footballers")]
        public ExportFootballerDto[] FootballerDtos { get; set; }
    }
}
