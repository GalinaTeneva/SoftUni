using Footballers.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.TeamsFootballers = new List<TeamFootballer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.TeamNameMaxLength)]
        [RegularExpression(@"^[a-zA-z0-9\s\.\-]+$")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(40, MinimumLength = 2)]
        [MaxLength(ValidationConstants.TeamNationalityMaxLength)]
        public string Nationality { get; set; } = null!;

        public int Trophies { get; set; }

        public ICollection<TeamFootballer> TeamsFootballers { get; set; } = null!;
    }
}
