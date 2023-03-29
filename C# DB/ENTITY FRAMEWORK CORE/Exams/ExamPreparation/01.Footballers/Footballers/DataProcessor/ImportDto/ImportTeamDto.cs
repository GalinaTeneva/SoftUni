using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        //[StringLength(40, MinimumLength = 3)]
        //[Unicode]
        public string? Name { get; set; }

        //[StringLength(40, MinimumLength = 2)]
        public string? Nationality { get; set; }

        public string? Trophies { get; set; }

        public int[]? Footballers { get; set; }
    }
}
