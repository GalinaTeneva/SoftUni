namespace FastFood.Core.ViewModels.Items
{
    using System.ComponentModel.DataAnnotations;

    using FastFood.Common.EntityConfiguration;

    public class CreateItemInputModel
    {

        [StringLength(ViewModelsValidation.ItemNameMaxLength, MinimumLength = ViewModelsValidation.ItemNameMinLength)]
        public string Name { get; set; } = null!;

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
