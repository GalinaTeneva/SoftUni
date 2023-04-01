using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType("Creator")]
    public class ExportCreatorDto
    {
        [XmlAttribute("BoardgamesCount")]
        public int BoardgamesCount { get; set; }

        public string CreatorName { get; set; } = null!;

        [XmlArray("Boardgames")]
        public ExportCreatorBoardgameDto[] boardgameDtos { get; set; } = null!;
    }
}
