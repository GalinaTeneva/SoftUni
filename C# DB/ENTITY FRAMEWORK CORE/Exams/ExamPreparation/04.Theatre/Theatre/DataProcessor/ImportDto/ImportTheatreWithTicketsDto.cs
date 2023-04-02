using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheatreWithTicketsDto
    {
        [Required]
        [MinLength(ValidationConstants.TheatreNameMinLength)]
        [MaxLength(ValidationConstants.TheatreNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(ValidationConstants.TheatreNumberOfHallsMinValue, ValidationConstants.TheatreNumberOfHallsMaxValue)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MinLength(ValidationConstants.TheatreDirectorNameMinLength)]
        [MaxLength(ValidationConstants.TheatreDirectorNameMaxLength)]
        public string Director { get; set; } = null!;

        [JsonProperty("Tickets")]
        public ImportTheatreTicketDto[] TicketDtos { get; set; }
    }
}
