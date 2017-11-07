namespace CarDealer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Interfaces;
    using Models;

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
    }
}
