namespace CarDealer.App.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;

    [Route("sales")]
    public class SalesController : Controller
    {
        private readonly ISaleService sales;

        public SalesController(ISaleService sale)
        {
            this.sales = sale;
        }

        [Route("")]
        public IActionResult All()
            => View(this.sales.All());

        [Route("{id}")]
        public IActionResult Details(int id)
            => this.ViewOrNotFound(this.sales.Details(id));
    }
}
