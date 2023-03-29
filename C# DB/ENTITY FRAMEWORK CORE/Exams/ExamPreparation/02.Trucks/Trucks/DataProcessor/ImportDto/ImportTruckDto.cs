using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Common;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportTruckDto
    {
        [XmlElement("RegistrationNumber")]
        [MaxLength(ValidationConstants.TruckRegistrationNumberLength)]
        [MinLength(ValidationConstants.TruckRegistrationNumberLength)]
        [RegularExpression(ValidationConstants.TruckRegistrationRegEx)]
        public string? RegistrationNumber { get; set; }

        [XmlElement("VinNumber")]
        [MaxLength(ValidationConstants.TruckVinNumberLength)]
        [MinLength(ValidationConstants.TruckVinNumberLength)]
        public string VinNumber { get; set; } = null!;

        [XmlElement("TankCapacity")]
        [Range(ValidationConstants.TruckTankCapacityMinValue, ValidationConstants.TruckTankCapacityMaxValue)]
        public int TankCapacity { get; set; }

        [XmlElement("CargoCapacity")]
        [Range(ValidationConstants.TruckCargoCapacityMinValue, ValidationConstants.TruckCargoCapacityMaxValue)]
        public int CargoCapacity { get; set; }

        [XmlElement("CategoryType")]
        [Range(ValidationConstants.TruckCategoryTypeMinValue, ValidationConstants.TruckCategoryTypeMaxValue)]
        public int CategoryType { get; set; }

        [XmlElement("MakeType")]
        [Range(ValidationConstants.TruckMakeTypeMinValue, ValidationConstants.TruckMakeTypeMaxValue)]
        public int MakeType { get; set; }
    }
}
