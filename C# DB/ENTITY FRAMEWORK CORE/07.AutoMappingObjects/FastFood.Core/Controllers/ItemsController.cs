﻿namespace FastFood.Core.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using FastFood.Services.Data;

    using ViewModels.Items;

    public class ItemsController : Controller
    {
        private readonly IItemService itemService;

        public ItemsController(IItemService itemService)
        {
           this.itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<CreateItemViewModel> availableCategories = await this.itemService.GetAllAvailableCategoriesAsync();

            return View(availableCategories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.itemService.CreateAsync(model);

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<ItemsAllViewModels> items = await this.itemService.GetAllAsync();

            return View(items.ToList());
        }
    }
}
