namespace FastFood.Services.Data
{
    using FastFood.Core.ViewModels.Items;

    public interface IItemService
    {
        Task CreateAsync(CreateItemInputModel model);

        Task<IEnumerable<ItemsAllViewModels>> GetAllAsync();

        Task<IEnumerable<CreateItemViewModel>> GetAllAvailableCategoriesAsync();
    }
}
