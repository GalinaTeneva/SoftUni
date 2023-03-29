using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class ImportCoachDto
    {
        [StringLength(40, MinimumLength = 3)]
        public string? Name { get; set; }

        public string? Nationality { get; set; }

        [XmlArray("Footballers")]
        [XmlArrayItem("Footballer")]
        public ImportFootballerDto[] FootballerDtos { get; set; }
    }
}
