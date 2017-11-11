namespace CarDealer.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Cars;
    using Services.Interfaces;

    [Route("cars")]
    public class CarsController : Controller
    {
        private readonly ICarServices cars;

        public CarsController(ICarServices cars)
        {
            this.cars = cars;
        }

        [Route(nameof(Create))]
        public IActionResult Create() => View();

        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(CarFormModel carModel)
        {
            if (!ModelState.IsValid)
            {
                return View(carModel);
            }

            this.cars.Create(
                carModel.Make,
                carModel.Model,
                carModel.TravelledDistance);

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
    }
}
