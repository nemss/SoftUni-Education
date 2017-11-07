namespace CarDealer.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Customers;
    using Services.Interfaces;
    using Services.Models;

    public class CustomersController : Controller
    {
        private ICustomersServices customers;

        public CustomersController(ICustomersServices customers)
        {
            this.customers = customers;
        }

        [HttpGet("customers/all/{order}")]
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
    }
}
