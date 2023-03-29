using Footballers.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class ImportFootballerDto
    {
        //[XmlElement("")]
        [StringLength(40, MinimumLength = 2)]
        public string? Name { get; set; }

        //[XmlElement("")]
        public string? ContractStartDate { get; set; }

        //[XmlElement("")]
        public string? ContractEndDate { get; set; }

        //[XmlElement("")]
        public int BestSkillType { get; set; }

        //[XmlElement("")]
        public int PositionType { get; set; }
    }
}
