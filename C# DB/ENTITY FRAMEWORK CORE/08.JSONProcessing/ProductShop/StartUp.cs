namespace ProductShop
{
    using Newtonsoft.Json;

    using Data;
    using DTOs.Import;
    using AutoMapper;
    using ProductShop.Models;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            string inputJson = File.ReadAllText(@"../../../Datasets/users.json");

            string result = ImportUsers(context, inputJson);

            Console.WriteLine(result);
        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> validUsers = new HashSet<User>();
            foreach (ImportUserDto userDto in userDtos)
            {
                User user = mapper.Map<User>(userDto);

                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }
    }
}