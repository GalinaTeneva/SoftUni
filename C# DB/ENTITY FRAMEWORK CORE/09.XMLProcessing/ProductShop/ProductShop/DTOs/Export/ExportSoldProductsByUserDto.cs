using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("User")]
    public class ExportSoldProductsByUserDto
    {
        [XmlElement(ElementName ="firstName", Order = 1)]
        public string UserFirstName { get; set; } = null!;

        [XmlElement(ElementName ="lastName", Order = 2)]
        public string UserLastName { get; set;} = null!;

        [XmlArray(ElementName ="soldProducts", Order = 3)]
        public ExportProductsDto[] ProductsSold = null!;
    }
}
