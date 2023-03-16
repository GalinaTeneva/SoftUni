using FastFood.Core.ViewModels.Categories;

namespace FastFood.Services.Data
{
    public interface ICategoryService
    {
        Task CreateAsynk(CreateCategoryInputModel model);

        Task<IEnumerable<CategoryAllViewModel>> GetAllAsynk();
    }
}
