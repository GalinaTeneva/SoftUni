namespace FastFood.Services.Data
{
    using FastFood.Core.ViewModels.Categories;

    public interface ICategoryService
    {
        Task CreateAsynk(CreateCategoryInputModel model);

        Task<IEnumerable<CategoryAllViewModel>> GetAllAsynk();
    }
}
