namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Countries");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCountryDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportCountryDto[] countryDtos = (ImportCountryDto[])xmlSerializer.Deserialize(reader);

            StringBuilder sb = new StringBuilder();
            ICollection<Country> validCountries = new List<Country>();

            foreach (ImportCountryDto countryDto in countryDtos)
            {
                if (!IsValid(countryDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Country country = new Country()
                {
                    CountryName = countryDto.CountryName,
                    ArmySize = countryDto.ArmySize
                };

                validCountries.Add(country);
                sb.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(validCountries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Manufacturers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportManufacturerDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportManufacturerDto[] manufacturerDtos = (ImportManufacturerDto[])xmlSerializer.Deserialize(reader);

            StringBuilder sb = new StringBuilder();
            ICollection<Manufacturer> validManufacturers = new List<Manufacturer>();

            foreach (ImportManufacturerDto manufacturerDto in manufacturerDtos)
            {
                if (!IsValid(manufacturerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (validManufacturers.Any(m => m.ManufacturerName == manufacturerDto.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Manufacturer manufacturer = new Manufacturer()
                {
                    ManufacturerName = manufacturerDto.ManufacturerName,
                    Founded = manufacturerDto.Founded,
                };

                validManufacturers.Add(manufacturer);

                string[] foundedTokens = manufacturer.Founded.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string countryName = foundedTokens[foundedTokens.Length - 1];
                string townName = foundedTokens[foundedTokens.Length - 2];
                string foundedPlace = string.Concat(townName, ", ", countryName);

                sb.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, foundedPlace));
            }

            context.Manufacturers.AddRange(validManufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Shells");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportShellDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportShellDto[] shellDtos = (ImportShellDto[])xmlSerializer.Deserialize(reader);

            StringBuilder sb = new StringBuilder();
            ICollection<Shell> validShells = new List<Shell>();

            foreach (ImportShellDto shellDto in shellDtos)
            {
                if (!IsValid(shellDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Shell shell = new Shell()
                {
                    ShellWeight = shellDto.ShellWeight,
                    Caliber = shellDto.Caliber,
                };

                validShells.Add(shell);

                sb.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(validShells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            ImportGunWithCountriesDto[] gunDtos = JsonConvert.DeserializeObject<ImportGunWithCountriesDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            ICollection<Gun> validGuns = new List<Gun>();

            string[] validGunTypes = new string[] { "Howitzer", "Mortar", "FieldGun", "AntiAircraftGun", "MountainGun", "AntiTankGun" };

            foreach (ImportGunWithCountriesDto gunDto in gunDtos)
            {
                if (!IsValid(gunDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!validGunTypes.Contains(gunDto.GunType))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Gun gun = new Gun()
                {
                    ManufacturerId = gunDto.ManufacturerId,
                    GunWeight = gunDto.GunWeight,
                    BarrelLength = gunDto.BarrelLength,
                    NumberBuild = gunDto.NumberBuild,
                    Range = gunDto.Range,
                    GunType = (GunType)Enum.Parse(typeof(GunType), gunDto.GunType),
                    ShellId = gunDto.ShellId
                };

                foreach (ImportGunCountriesDto countryDto in gunDto.CountriesDto)
                {
                    CountryGun countryGun = new CountryGun()
                    {
                        CountryId = countryDto.Id,
                    };

                    gun.CountriesGuns.Add(countryGun);
                }

                validGuns.Add(gun);
                sb.AppendLine(string.Format(SuccessfulImportGun, gunDto.GunType, gunDto.GunWeight, gunDto.BarrelLength));
            }

            context.Guns.AddRange(validGuns);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}