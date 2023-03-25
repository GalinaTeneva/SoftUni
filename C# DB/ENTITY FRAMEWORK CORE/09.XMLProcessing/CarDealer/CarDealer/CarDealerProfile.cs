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
            this.CreateMap<Supplier, ExportLocalSupplierDto>()
                .ForMember(d => d.PartsCount, o => o.MapFrom(s => s.Parts.Count));

            //Part
            this.CreateMap<ImportPartDto, Part>()
                .ForMember(d => d.SupplierId, o => o.MapFrom(s => s.SupplierId.Value));
            this.CreateMap<Part, ExportCarPartDto>();

            //Car
            this.CreateMap<ImportCarDto, Car>()
                .ForSourceMember(s => s.Parts, o => o.DoNotValidate());
            this.CreateMap<Car, ExportCarDto>();
            this.CreateMap<Car, ExportBmwCarDto>();
            this.CreateMap<Car, ExportCarWithPartsDto>()
                .ForMember(d => d.Parts, o => o.MapFrom(s => s.PartsCars.Select(pc => pc.Part).OrderByDescending(p => p.Price).ToArray()));

            //Customer
            this.CreateMap<ImportCustomerDto, Customer>()
                .ForMember(d => d.BirthDate, o => o.MapFrom(s => DateTime.Parse(s.BirthDate, CultureInfo.InvariantCulture)));

            //Sale
            this.CreateMap<ImportSaleDto, Sale>()
                .ForMember(d => d.CarId, o => o.MapFrom(s => s.CarId.Value));

        }
    }
}
