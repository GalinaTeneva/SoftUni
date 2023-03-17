namespace FastFood.Services.Data
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Microsoft.EntityFrameworkCore;

    using FastFood.Core.ViewModels.Categories;
    using FastFood.Data;
    using FastFood.Models;

    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public CategoryService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task CreateAsynk(CreateCategoryInputModel inputModel)
        {
            Category category = this.mapper.Map<Category>(inputModel);

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryAllViewModel>> GetAllAsynk()
            => await this.context.Categories
            .ProjectTo<CategoryAllViewModel>(this.mapper.ConfigurationProvider)
            .ToArrayAsync();
    }
}
