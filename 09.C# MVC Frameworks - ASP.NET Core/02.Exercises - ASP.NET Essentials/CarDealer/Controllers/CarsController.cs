namespace CarDealer.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;

    public class CarsController : Controller
    {
        private readonly ICarServices cars;

        public CarsController(ICarServices cars)
        {
            this.cars = cars;
        }

        [HttpGet("/cars/{make}")]
        public IActionResult CarsByMakes(string make)
        {
            var result = cars
                .AllCarsByMakes(make);

            return this.View(result);
        }

        [HttpGet("/cars/{id}/parts")]
        public IActionResult Parts(string id)
        {
            var result = this.cars.CarWithParts(id);

            return this.View(result);
        }
    }
}
