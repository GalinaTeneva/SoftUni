using System.ComponentModel.DataAnnotations;
using Trucks.Common;

namespace Trucks.Data.Models
{
    public class Despatcher
    {
        public Despatcher()
        {
            this.Trucks = new HashSet<Truck>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.DespatcherNameMaxLength)]
        public string Name { get; set; } = null!;

        public string? Position { get; set; }

        public ICollection<Truck> Trucks { get; set; }
    }
}
