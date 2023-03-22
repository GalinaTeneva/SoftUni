﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //01. Import Suppliers
            //string inputJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            //string result = ImportSuppliers(context, inputJson);

            //02. Import Parts
            //string inputJson = File.ReadAllText(@"../../../Datasets/parts.json");
            //string result = ImportParts(context, inputJson);

            //03. Import Cars
            //string inputJson = File.ReadAllText(@"../../../Datasets/cars.json");
            //string result = ImportCars(context, inputJson);

            //04. Import Customers
            //string inputJson = File.ReadAllText(@"../../../Datasets/customers.json");
            //string result = ImportCustomers(context, inputJson);

            //05. Import Sales
            //string inputJson = File.ReadAllText(@"../../../Datasets/sales.json");
            //string result = ImportSales(context, inputJson);

            Console.WriteLine(GetOrderedCustomers(context));
        }

        //01. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportSupplierDto[] supplierDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);

            Supplier[] suppliers = mapper.Map<Supplier[]>(supplierDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        //02. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportPartDto[] importPartsDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);

            ICollection<Part> validParts = new HashSet<Part>();
            foreach (ImportPartDto importPartDto in importPartsDtos!)
            {
                if (!context.Suppliers.Any(s => s.Id == importPartDto.SupplierId))
                {
                    continue;
                }

                Part part = mapper.Map<Part>(importPartDto);
                validParts.Add(part);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}.";
        }

        //03. Import Cars
        //public static string ImportCars(CarDealerContext context, string inputJson)
        //{
        //    IMapper mapper = CreateMapper();

        //    ImportPartCarDto[] importPartCarDtos = JsonConvert.DeserializeObject<ImportPartCarDto[]>(inputJson);
        //    ICollection<PartCar> partsCars = new HashSet<PartCar>();
        //    foreach (ImportPartCarDto importPartCarDto in importPartCarDtos)
        //    {
        //        PartCar partCar = mapper.Map<PartCar>(importPartCarDto);
        //        partsCars.Add(partCar);
        //    }

        //    ImportCarDto[] importCarDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson.);
        //    ICollection<Car> cars = new HashSet<Car>();
        //    foreach (ImportCarDto importCarDto in importCarDtos)
        //    {
        //        Car car = mapper.Map<Car>(importCarDto);
        //        cars.Add(car);
        //    }

        //    context.PartsCars.AddRange(partsCars);
        //    context.Cars.AddRange(cars);
        //    context.SaveChanges();

        //    return $"Successfully imported {cars.Count}.";
        //}


        //04. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCustomerDto[] importCustomerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);

            Customer[] customers = mapper.Map<Customer[]>(importCustomerDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        //05. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportSaleDto[] importSaleDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);

            Sale[] sales = mapper.Map<Sale[]>(importSaleDtos);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        //06. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();

            ExportOrderedCustomersDto[] customersDtos = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .AsNoTracking()
                .ProjectTo<ExportOrderedCustomersDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(customersDtos, Formatting.Indented);

            //var orderedCustomers = context.Customers
            //    .OrderBy(c => c.BirthDate)
            //    .ThenBy(c => c.IsYoungDriver)
            //    .Select(c => new
            //    {
            //        c.Name,
            //        BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
            //        c.IsYoungDriver
            //    })
            //    .AsNoTracking()
            //    .ToArray();

            //return JsonConvert.SerializeObject(orderedCustomers, Formatting.Indented);
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