namespace CarDealer.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Parts;
    using Services.Interfaces;
    using System;
    using System.Linq;

    public class PartsController : Controller
    {
        private const int PageSize = 25;

        private readonly IPartService parts;
        private readonly ISuppliersServices suppliers;

        public PartsController(IPartService parts, ISuppliersServices suppliers)
        {
            this.parts = parts;
            this.suppliers = suppliers;
        }

        public IActionResult All(int page = 1)
            => View(new PartPageListingModel
            {
                Parts = this.parts.All(page, PageSize),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.parts.Total() / (double)PageSize)
            });

        public IActionResult Create()
            => View(new PartFormModel
            {
                Suppliers = this.suppliers.All().Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                })
            });

        [HttpPost]
        public IActionResult Create(PartFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.parts
                .Create(model.Name,
                    model.Price,
                    model.Quantity,
                    model.SupplierId);

            return this.RedirectToAction(nameof(All));
        }
    }
}
