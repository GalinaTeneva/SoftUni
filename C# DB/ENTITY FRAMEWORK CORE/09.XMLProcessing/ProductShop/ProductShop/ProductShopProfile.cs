using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //User
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<User, ExportUserDto>();

            //Product
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<Product, ExportProductsInRangeDto>()
                .ForMember(d => d.Buyer, o => o.MapFrom(s => String.Format("{0} {1}", s.Buyer!.FirstName, s.Buyer.LastName)));

            //Category
            this.CreateMap<ImportCategoryDto, Category>();

            //CategoryProduct
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
