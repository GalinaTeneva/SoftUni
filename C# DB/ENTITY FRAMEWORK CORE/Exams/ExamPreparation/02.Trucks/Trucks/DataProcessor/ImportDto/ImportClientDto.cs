using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Trucks.Common;
using Trucks.Data.Models;

namespace Trucks.DataProcessor.ImportDto
{
    public class ImportClientDto
    {
        [Required]
        [MinLength(ValidationConstants.ClientNameMinLength)]
        [MaxLength(ValidationConstants.ClientNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(ValidationConstants.ClientNationalityMinLength)]
        [MaxLength(ValidationConstants.ClientNationalityMaxLength)]
        public string Nationality { get; set; } = null!;

        [Required]
        public string Type { get; set; } = null!;

        [JsonProperty("Trucks")]
        public int[] TruckIds { get; set; }
    }
}
