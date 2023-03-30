using Newtonsoft.Json;

namespace Footballers.DataProcessor.ExportDto
{
    public class ExportTeamFootballerDto
    {
        public string Name { get; set; } = null!;

        [JsonProperty("Footballers")]
        public ExportFootballerDto[] FootballerDtos { get; set; }
    }
}
