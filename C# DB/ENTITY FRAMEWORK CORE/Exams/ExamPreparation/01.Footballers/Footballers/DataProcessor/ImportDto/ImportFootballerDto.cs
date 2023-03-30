using Footballers.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class ImportFootballerDto
    {
        [Required]
        [StringLength(ValidationConstants.FootballerNameMaxLength, MinimumLength = ValidationConstants.FootballerNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string ContractStartDate { get; set; } = null!;

        [Required]
        public string ContractEndDate { get; set; } = null!;

        [Required]
        public int BestSkillType { get; set; }

        [Required]
        public int PositionType { get; set; }
    }
}
