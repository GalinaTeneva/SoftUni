using Artillery.Data.Models.Enums;
using Artillery.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Artillery.Common;
using Newtonsoft.Json;

namespace Artillery.DataProcessor.ImportDto
{
    public class ImportGunWithCountriesDto
    {
        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        [Range(ValidationConstants.GunWeightMinValue, ValidationConstants.GunWeightMaxValue)]
        public int GunWeight { get; set; }

        [Required]
        [Range(ValidationConstants.GunBarrelLengthMinValue, ValidationConstants.GunBarrelLengthMaxValue)]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Required]
        [Range(ValidationConstants.GunRangeMinValue, ValidationConstants.GunRangeMaxValue)]
        public int Range { get; set; }

        [Required]
        public string GunType { get; set; }

        [Required]
        public int ShellId { get; set; }

        [JsonProperty("Countries")]
        public ICollection<ImportGunCountriesDto> CountriesDto { get; set; }
    }
}
