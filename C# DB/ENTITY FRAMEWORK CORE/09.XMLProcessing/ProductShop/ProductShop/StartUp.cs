using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //01.Import Users
            //string inputXml = File.ReadAllText("../../../Datasets/users.xml");
            //string result = ImportUsers(context, inputXml);

            //02. Import Products
            //string inputXml = File.ReadAllText("../../../Datasets/products.xml");
            //string result = ImportProducts(context, inputXml);

            //03. Import Categories
            //string inputXml = File.ReadAllText("../../../Datasets/categories.xml");
            //string result = ImportCategories(context, inputXml);

            //04.  Import Categories and Products
            //string inputXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            //string result = ImportCategoryProducts(context, inputXml);

            //05. Export Products In Range
            string result = GetProductsInRange(context);

            Console.WriteLine(result);
        }

        //01.Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();
            IMapper mapper = CreateMapper();

            ImportUserDto[] userDtos = xmlHelper.Deserialize<ImportUserDto[]>(inputXml, "Users");

            ICollection<User> validUsers = new HashSet<User>();
            foreach (ImportUserDto userDto in userDtos)
            {
                if (string.IsNullOrEmpty(userDto.FirstName) ||
                    string.IsNullOrEmpty(userDto.LastName))
                {
                    continue;
                }

                User user = mapper.Map<User>(userDto);
                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportProductDto[] productDtos = xmlHelper.Deserialize<ImportProductDto[]>(inputXml, "Products");

            ICollection<Product> validProducts = new HashSet<Product>();
            foreach (ImportProductDto productDto in productDtos)
            {
                if (string.IsNullOrEmpty(productDto.Name))
                {
                    continue;
                }

                Product product = mapper.Map<Product>(productDto);
                validProducts.Add(product);
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCategoryDto[] categoryDtos = xmlHelper.Deserialize<ImportCategoryDto[]>(inputXml, "Categories");

            ICollection<Category> validCategories = new HashSet<Category>();
            foreach (ImportCategoryDto categoryDto in categoryDtos)
            {
                if (string.IsNullOrEmpty(categoryDto.Name))
                {
                    continue;
                }

                Category category = mapper.Map<Category>(categoryDto);
                validCategories.Add(category);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        //04.  Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCategoryProductDto[] categoryProductDtos = xmlHelper
                .Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");

            var existingCategoryIds = context.Categories
                .Select(c => c.Id).ToArray();
            var existingProductIds = context.Products
                .Select(p => p.Id).ToArray();

            ICollection<CategoryProduct> validCategoryProducts = new HashSet<CategoryProduct>();
            foreach (ImportCategoryProductDto categoryProductDto in categoryProductDtos)
            {
                if (!existingCategoryIds.Any(id => id == categoryProductDto.CategoryId) ||
                    !existingProductIds.Any(id => id == categoryProductDto.ProductId))
                {
                    continue;
                }

                CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(categoryProductDto);
                validCategoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(validCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Count}";
        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                //.Select(p => new ExportProductsInRangeDto
                //{
                //    Name = p.Name,
                //    Price = p.Price.ToString("F2"),
                //    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                //})
                .ProjectTo<ExportProductsInRangeDto>(mapper.ConfigurationProvider)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProductsInRangeDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, products, namespaces);

            return sb.ToString().TrimEnd();
        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
        }
    }
}