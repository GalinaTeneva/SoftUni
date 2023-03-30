using Footballers.Common;
using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        [Required]
        [StringLength(ValidationConstants.TeamNameMaxLength, MinimumLength = ValidationConstants.TeamNameMinLength)]
        [RegularExpression(@"^[a-zA-z0-9\s\.\-]+$")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstants.TeamNationalityMaxLength, MinimumLength = ValidationConstants.TeamNationalityMinLength)]
        public string Nationality { get; set; } = null!;

        [Required]
        public int Trophies { get; set; }

        public int[]? Footballers { get; set; }
    }
}
