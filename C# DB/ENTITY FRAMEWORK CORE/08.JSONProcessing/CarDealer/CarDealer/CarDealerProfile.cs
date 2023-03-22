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

            //Part
            this.CreateMap<ImportPartDto, Part>();

            //Car
            this.CreateMap<ImportCarDto, Car>()
                .ForMember(d => d.PartsCars, o => o.MapFrom(s => s.PartsId));
            this.CreateMap<Car, ExportCarsFromMakeToyotaDto>();

            //PartsCars
            this.CreateMap<ImportPartCarDto, PartCar>();

            //Customer
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<Customer, ExportOrderedCustomersDto>()
                .ForMember(d => d.BirthDate, o => o.MapFrom(s => s.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));

            //Sale
            this.CreateMap<ImportSaleDto, Sale>();
        }
    }
}
