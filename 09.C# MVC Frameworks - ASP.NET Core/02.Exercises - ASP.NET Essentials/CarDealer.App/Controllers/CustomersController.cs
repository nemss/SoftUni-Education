namespace CarDealer.App.Controllers
{
    using System.Collections.Specialized;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Models.Customers;
    using Remotion.Linq.Clauses;
    using Services;
    using Services.Interfaces;

    [Route("customers")]
    public class CustomersController : Controller
    {
        private ICustomersServices customers;

        public CustomersController(ICustomersServices customers)
        {
            this.customers = customers;
        }


        [Route(nameof(Create))]
        public IActionResult Create() => this.View();

        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(CustomerForModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.customers.Create(model.Name, model.BirthDay, model.IsYoungDriver);

            return RedirectToAction(nameof(All), new { order = OrderType.Ascending.ToString() });
        }

        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id)
        {
            var customer = this.customers.ById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(new CustomerForModel
            {
                Name = customer.Name,
                BirthDay = customer.BirthDate,
                IsYoungDriver = customer.IsYoungDriver
            });
        }

        [HttpPost]
        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id, CustomerForModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customerExist = this.customers.Exists(id);

            if (!customerExist)
            {
                return NotFound();
            }

            this.customers.Edit(
                id,
                model.Name,
                model.BirthDay,
                model.IsYoungDriver);

            return RedirectToAction(nameof(All), new {order = OrderType.Ascending});
        }

        [Route("all/{order}")]
        public IActionResult All(string order)
        {
            var orderDirections = order.ToLower() == "descending"
                ? OrderType.Descending
                : OrderType.Ascending;

            var customer = customers
                .OrderedCustomers(orderDirections);

            return this.View(new AllCustomersModel
            {
                Customer = customer,
                Type = orderDirections
            });
        }

        [Route("{id}")]
        public IActionResult Details(int id)
            => this.ViewOrNotFound(this.customers.TotalSalesById(id));
    }
}
