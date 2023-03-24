using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();

            //09. Import Suppliers
            //string inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //string result = ImportSuppliers(context, inputXml);

            //10. Import Parts
            string inputXml = File.ReadAllText("../../../Datasets/parts.xml");
            string result = ImportParts(context, inputXml);

            Console.WriteLine(result);
        }

        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportSupplierDto[] supplierDtos = xmlHelper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");

            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

            foreach (ImportSupplierDto supplierDto in supplierDtos)
            {
                if (string.IsNullOrEmpty(supplierDto.Name))
                {
                    continue;
                }

                //Manual mapping
                //Supplier supplier = new Supplier()
                //{
                //    Name = supplierDto.Name,
                //    IsImporter = supplierDto.IsImporter
                //};

                Supplier supplier = mapper.Map<Supplier>(supplierDto);

                validSuppliers.Add(supplier);

            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}";
        }

        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportPartDto[] partDtos = xmlHelper.Deserialize<ImportPartDto[]>(inputXml, "Parts");

            ICollection<Part> validParts = new HashSet<Part>();
            foreach (ImportPartDto partDto in partDtos)
            {
                if (string.IsNullOrEmpty(partDto.Name))
                {
                    continue;
                }

                if (!partDto.SupplierId.HasValue ||
                    !context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    continue;
                }

                Part part = mapper.Map<Part>(partDto);

                validParts.Add(part);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }
    }
}