namespace CarDealer.Services.Implementations
{
    using Data;
    using Interfaces;
    using Models;
    using Models.Customers;
    using Models.Sales;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomersServices : ICustomersServices
    {
        private readonly CarDealerDbContext db;

        public CustomersServices(CarDealerDbContext db)
        {
            this.db = db;
        }

        public ICollection<OrderCustomerModel> OrderedCustomers(OrderType order)
        {
            var custommerQuery = this.db.Customers.AsQueryable();

            switch (order)
            {
                case OrderType.Ascending:
                    custommerQuery = custommerQuery.OrderBy(c => c.BirthDate).ThenBy(x=> x.Name);
                    break;
                case OrderType.Descending:
                    custommerQuery = custommerQuery.OrderByDescending(c => c.BirthDate).ThenBy(x => x.Name);
                    break;
                    default:
                    throw new InvalidOperationException($"Invalid operation {order}");
            }

            return custommerQuery
                .Select(x => new OrderCustomerModel
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();
        }

        public CustomerTotalSalesModel TotalSalesById(int id)
            => this.db
                .Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerTotalSalesModel
                {
                    Name = c.Name,
                    IsYoungDriver = c.IsYoungDriver,
                    BoughtCars = c.Sales.Select(s => new SalePriceModel
                    {
                        Price = s.Car.Parts.Sum(p => p.Part.Price),
                        Discount = s.Discount
                    })
                })
                .FirstOrDefault();
    }
}
