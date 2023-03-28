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

            this.CreateMap<Product, ExportProductsDto>();
            this.CreateMap<User, ExportSoldProductsByUserDto>()
                .ForMember(d => d.UserFirstName, o => o.MapFrom(s => s.FirstName))
                .ForMember(d => d.UserLastName, o => o.MapFrom(s => s.LastName))
                .ForMember(d => d.ProductsSold, o => o.MapFrom(s => s.ProductsSold.ToArray()));

            //Product
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<Product, ExportProductsInRangeDto>()
                .ForMember(d => d.Buyer, o => o.MapFrom(s => String.Format("{0} {1}", s.Buyer!.FirstName, s.Buyer.LastName)));

            //Category
            this.CreateMap<ImportCategoryDto, Category>();
            this.CreateMap<Category, ExportCategoriesByProductDto>()
                .ForMember(d => d.ProductsCount, o => o.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(d => d.AveragePrice, o => o.MapFrom(s => s.CategoryProducts.Average(cp => cp.Product.Price)))
                .ForMember(d => d.TotalRevenue, o => o.MapFrom(s => s.CategoryProducts.Sum(cp => cp.Product.Price)));

            //CategoryProduct
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();

        }
    }
}
