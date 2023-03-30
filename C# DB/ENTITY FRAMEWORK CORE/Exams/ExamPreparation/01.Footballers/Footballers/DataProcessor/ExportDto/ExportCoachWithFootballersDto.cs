using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Coach")]
    public class ExportCoachWithFootballersDto
    {
        [XmlAttribute("FootballersCount")]
        public int FootballersCount { get; set; }

        public string CoachName { get; set; } = null!;

        [XmlArray("Footballers")]
        public ExportCoachFootballerDto[] FootballerDtos { get; set; }
    }
}
