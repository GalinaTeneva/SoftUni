using FastFood.Common.EntityConfiguration;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.ViewModels.Categories
{
    public class CreateCategoryInputModel
    {
        [StringLength(ViewModelsValidation.CategoryNameMaxLength,MinimumLength = ViewModelsValidation.CategoryNameMinLength)]
        public string CategoryName { get; set; }
    }
}
