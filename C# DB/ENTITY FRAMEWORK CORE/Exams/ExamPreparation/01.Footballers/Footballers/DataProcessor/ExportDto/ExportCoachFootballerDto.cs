using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Footballer")]
    public class ExportCoachFootballerDto
    {
        public string Name { get; set; } = null!;

        public string Position { get; set; } = null!;
    }
}
