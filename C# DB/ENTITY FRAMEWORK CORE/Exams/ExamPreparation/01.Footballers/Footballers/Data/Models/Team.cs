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

        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-z0-9\s\.\-]+$")]
        [Unicode]
        public string Name { get; set; } = null!;

        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; } = null!;

        public int Trophies { get; set; }

        public ICollection<TeamFootballer> TeamsFootballers { get; set; } = null!;
    }
}
