using Artillery.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Shell")]
    public class ImportShellDto
    {
        [Required]
        [Range(ValidationConstants.ShellWeightMinValue, ValidationConstants.ShellWeightMaxValue)]
        public double ShellWeight { get; set; }

        [Required]
        [MinLength(ValidationConstants.ShellCalibberMinLength)]
        [MaxLength(ValidationConstants.ShellCalibberMaxLength)]
        public string Caliber { get; set; } = null!;
    }
}
