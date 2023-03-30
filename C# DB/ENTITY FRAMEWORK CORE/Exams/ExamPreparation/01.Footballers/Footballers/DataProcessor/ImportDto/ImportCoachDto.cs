using Footballers.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class ImportCoachDto
    {
        [Required]
        [StringLength(ValidationConstants.CoachNameMaxLength, MinimumLength = ValidationConstants.CoachNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string Nationality { get; set; } = null!;

        [XmlArray("Footballers")]
        public ImportFootballerDto[] FootballerDtos { get; set; }
    }
}
