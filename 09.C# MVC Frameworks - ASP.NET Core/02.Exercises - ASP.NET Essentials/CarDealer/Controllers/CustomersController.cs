namespace CarDealer.App.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Models.Customers;
    using Services.Interfaces;
    using Services.Models;

    [Route("customers")]
    public class CustomersController : Controller
    {
        private ICustomersServices customers;

        public CustomersController(ICustomersServices customers)
        {
            this.customers = customers;
        }

        [HttpGet("all/{order}")]
        public IActionResult All(string order)
        {
            var orderDirections = order.ToLower() == "descending"
                ? OrderType.Descending
                : OrderType.Ascending;

            var customer = customers
                .OrderedCustomers(orderDirections);

            return this.View(new AllCustomersModel
            {
                Customers = customer,
                OrderType = orderDirections
            });
        }

        [Route("{id}")]
        public IActionResult Details(int id)
            => this.ViewOrNotFound(this.customers.TotalSalesById(id));
    }
}
