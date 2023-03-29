using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ExportDto
{
    public class ExportClientTruckDto
    {
        [JsonProperty("TruckRegistrationNumber")]
        public string? RegistrationNumber { get; set; }

        [Required]
        public string VinNumber { get; set; } = null!;

        public int TankCapacity { get; set; }

        public int CargoCapacity { get; set; }

        public string CategoryType { get; set; } = null!;

        public string MakeType { get; set; } = null!;
    }
}
