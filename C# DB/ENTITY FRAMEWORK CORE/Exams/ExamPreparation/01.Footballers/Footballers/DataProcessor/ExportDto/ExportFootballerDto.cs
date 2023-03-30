using Footballers.Data.Models.Enums;
using Newtonsoft.Json;

namespace Footballers.DataProcessor.ExportDto
{
    public class ExportFootballerDto
    {
        [JsonProperty("FootballerName")]
        public string Name { get; set; } = null!;

        public string ContractStartDate { get; set; } = null!;

        public string ContractEndDate { get; set; } = null!;

        public string BestSkillType { get; set; } = null!;

        public string PositionType { get; set; } = null!;

    }
}
