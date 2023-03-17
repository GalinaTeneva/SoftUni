namespace FastFood.Core.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using FastFood.Services.Data;

    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.categoryService.CreateAsynk(model);

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<CategoryAllViewModel> categories =
                await this.categoryService.GetAllAsynk();

            return this.View(categories.ToList());
        }
    }
}
