namespace FastFood.Core.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using FastFood.Common.EntityConfiguration;

    public class CreateCategoryInputModel
    {
        [StringLength(ViewModelsValidation.CategoryNameMaxLength, MinimumLength = ViewModelsValidation.CategoryNameMinLength)]
        public string CategoryName { get; set; }
    }
}
