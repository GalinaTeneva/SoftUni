using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType("Boardgame")]
    public class ExportCreatorBoardgameDto
    {
        public string BoardgameName { get; set; } = null!;

        public int BoardgameYearPublished { get; set; }
    }
}
