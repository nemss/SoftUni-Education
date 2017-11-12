namespace CarDealer.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Cars;
    using Services.Interfaces;

    [Route("cars")]
    public class CarsController : Controller
    {
        private readonly ICarServices cars;
        private readonly IPartService parts;

        public CarsController(ICarServices cars, 
            IPartService parts)
        {
            this.cars = cars;
            this.parts = parts;
        }



        [Route(nameof(Create))]
        [Authorize]
        public IActionResult Create() 
            => View(new CarFormModel
            {
                AllParts = this.GetPartsSelectItem()
            });

        [HttpPost]
        [Authorize]
        [Route(nameof(Create))]
        public IActionResult Create(CarFormModel carModel)
        {
            if (!ModelState.IsValid)
            {
                carModel.AllParts = this.GetPartsSelectItem();
                return View(carModel);
            }

            this.cars.Create(
                carModel.Make,
                carModel.Model,
                carModel.TravelledDistance,
                carModel.SelectParts);

            return RedirectToAction(nameof(All));
        }


        [HttpGet("{make}")]
        public IActionResult CarsByMakes(string make)
        {
            var result = cars
                .AllCarsByMakes(make);

            return this.View(result);
        }

        [HttpGet("{id}/parts")]
        public IActionResult Parts(string id)
        {
            var result = this.cars.CarWithParts(id);

            return this.View(result);
        }

        [HttpGet("all")]
        public IActionResult All()
            => this.View(cars.All());

        private IEnumerable<SelectListItem> GetPartsSelectItem()
        {
            return this.parts
                .AllBasic()
                .Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                });
        }
    }
}
