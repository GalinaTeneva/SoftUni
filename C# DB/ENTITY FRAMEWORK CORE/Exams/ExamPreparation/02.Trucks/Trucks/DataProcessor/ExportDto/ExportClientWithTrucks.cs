using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Trucks.Data.Models;

namespace Trucks.DataProcessor.ExportDto
{
    public class ExportClientWithTrucks
    {
        public string Name { get; set; } = null!;

        [JsonProperty("Trucks")]
        public ExportClientTruckDto[] Trucks { get; set; }
    }
}
