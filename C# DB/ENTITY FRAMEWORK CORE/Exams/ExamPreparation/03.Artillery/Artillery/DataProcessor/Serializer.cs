
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var searchedGunType = (GunType)Enum.Parse(typeof(GunType), "AntiAircraftGun");

            ExportShellWithGunsDto[] shellDtos = context.Shells
                .Include(s => s.Guns)
                .Where(s => s.ShellWeight > shellWeight)
                .Select(s => new ExportShellWithGunsDto
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns
                        .Where(g => g.GunType == searchedGunType)
                        .Select(g => new ExportShellGunDto
                        {
                            GunType = g.GunType.ToString(),
                            GunWeight = g.GunWeight,
                            BarrelLength = g.BarrelLength,
                            Range = g.Range >= 3000 ? "Long-range" : "Regular range",
                        })
                        .OrderByDescending(g => g.GunWeight)
                        .ToArray()
                })
                .OrderBy(s => s.ShellWeight)
                .ToArray();

            return JsonConvert.SerializeObject(shellDtos, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Guns");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportGunWithCountriesDto[]), xmlRoot);

            ExportGunWithCountriesDto[] gunDtos = context.Guns
                .Include(g => g.Manufacturer)
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .OrderBy(g => g.BarrelLength)
                .Select(g => new ExportGunWithCountriesDto
                {
                    ManufacturerName = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight,
                    BarrelLength = g.BarrelLength,
                    Range = g.Range,
                    CountriesDto = g.CountriesGuns
                        .Where(gc => gc.Country.ArmySize > 4_500_000)
                        .OrderBy(gc => gc.Country.ArmySize)
                        .Select(gc => new ExportGunCountryDto
                        {
                            CountryName = gc.Country.CountryName,
                            ArmySize = gc.Country.ArmySize
                        })
                        .ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(writer, gunDtos, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
