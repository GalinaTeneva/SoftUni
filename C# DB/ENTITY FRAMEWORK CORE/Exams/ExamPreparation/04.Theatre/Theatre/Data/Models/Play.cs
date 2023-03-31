using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Theatre.Common;
using Theatre.Data.Models.Enums;

namespace Theatre.Data.Models
{
    public class Play
    {
        public Play()
        {
            this.Casts = new HashSet<Cast>();
            this.Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PlayTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [Column("Duration", TypeName = "BIGINT")]
        public TimeSpan Duration { get; set; }

        [Required]
        [Column("Rating", TypeName = "FLOAT")]
        public float Rating { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PlayDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.PlayScreenwriterMaxLength)]
        public string Screenwriter { get; set; } = null!;

        public ICollection<Cast> Casts { get; set; }

        public ICollection<Ticket> Tickets { get; set;}
    }
}
