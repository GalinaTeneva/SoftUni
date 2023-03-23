using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Globalization;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Supplier
            this.CreateMap<ImportSupplierDto, Supplier>();
            this.CreateMap<Supplier, ExportLocalSuppliersDto>()
                .ForMember(d => d.PartsCount, o => o.MapFrom(s => s.Parts.Count));

            //Part
            this.CreateMap<ImportPartDto, Part>();

            //Car
            this.CreateMap<Car, ExportCarsFromMakeToyotaDto>();

            //Customer
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<Customer, ExportOrderedCustomersDto>()
                .ForMember(d => d.BirthDate, o => o.MapFrom(s => s.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));
            this.CreateMap<Customer, ExportTotalSalesByCustomerDto>()
                .ForMember(d => d.FullName, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.BoughtCars, o => o.MapFrom(s => s.Sales.Count));

            //Sale
            this.CreateMap<ImportSaleDto, Sale>();
        }
    }
}
