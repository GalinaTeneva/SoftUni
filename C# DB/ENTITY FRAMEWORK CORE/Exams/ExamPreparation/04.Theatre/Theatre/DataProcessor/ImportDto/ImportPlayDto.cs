using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Theatre.Common;
using Theatre.Data.Models.Enums;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlayDto
    {
        [Required]
        [MinLength(ValidationConstants.PlayTitleMinLength)]
        [MaxLength(ValidationConstants.PlayTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        public string Duration { get; set; } = null!;

        [Required]
        [XmlElement("Raiting")]
        [Range(ValidationConstants.PlayRatingMinValue, ValidationConstants.PlayRatingMaxValue)]
        public float Rating { get; set; }

        [Required]
        public string Genre { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.PlayDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MinLength(ValidationConstants.PlayScreenwriterMinLength)]
        [MaxLength(ValidationConstants.PlayScreenwriterMaxLength)]
        public string Screenwriter { get; set; } = null!;
    }
}
