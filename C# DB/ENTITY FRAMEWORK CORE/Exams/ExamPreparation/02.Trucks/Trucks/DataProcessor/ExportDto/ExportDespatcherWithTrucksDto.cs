using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Despatcher")]
    public class ExportDespatcherWithTrucksDto
    {
        [XmlAttribute()]
        public int TrucksCount { get; set; }

        public string DespatcherName { get; set; } = null!;

        [XmlArray("Trucks")]
        public ExportDespatcherTruckDto[] Trucks { get; set; }
    }
}
