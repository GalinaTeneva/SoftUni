using Boardgames.Common;
using Boardgames.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class ImportBoardgameDto
    {
        [Required]
        [MinLength(ValidationConstants.BoardgameNameMinLength)]
        [MaxLength(ValidationConstants.BoardgameNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(ValidationConstants.BoardgameRatingMinValue, ValidationConstants.BoardgameRatingMaxValue)]
        public double Rating { get; set; }

        [Required]
        [Range(ValidationConstants.BoardgameYearPublishedMinValue, ValidationConstants.BoardgameYearPublishedMaxValue)]
        public int YearPublished { get; set; }

        [Required]
        public int CategoryType { get; set; }

        [Required]
        public string Mechanics { get; set; } = null!;
    }
}
