using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer.DTOs.Import
{
    public class ImportCarDto
    {
        public ImportCarDto()
        {
            this.PartsCars = new List<ImportPartCarDto>();
        }

        [JsonProperty("make")]
        public string Make { get; set; } = null!;

        [JsonProperty("model")]
        public string Model { get; set; } = null!;

        [JsonProperty("traveledDistance")]
        public long TravelledDistance { get; set; }

        public ICollection<ImportPartCarDto> PartsCars { get; set; }
    }
}
