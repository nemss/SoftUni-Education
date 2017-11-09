namespace CarDealer.App.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Models.Parts;
    using Services.Interfaces;

    public class PartsController : Controller
    {
        private const int PageSize = 25;

        private readonly IPartService parts;

        public PartsController(IPartService parts)
        {
            this.parts = parts;
        }

        public IActionResult All(int page = 1)
            => View(new PartPageListingModel
            {
                Parts = this.parts.All(page, PageSize),
                CurrentPage = (int)Math.Ceiling(this.parts.Total() / (double)PageSize)
            });
    }
}
