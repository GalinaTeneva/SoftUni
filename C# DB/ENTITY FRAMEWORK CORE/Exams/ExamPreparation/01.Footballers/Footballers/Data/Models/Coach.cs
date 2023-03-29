using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
    public class Coach
    {
        public Coach()
        {
            this.Footballers = new List<Footballer>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string Nationality { get; set; } = null!;

        public ICollection<Footballer> Footballers { get; set; }
    }
}
