namespace CarDealer.Services.Implementations
{
    using Data;
    using Interfaces;
    using Models.Customers;
    using Models.Sales;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;

    public class CustomersServices : ICustomersServices
    {
        private readonly CarDealerDbContext db;

        public CustomersServices(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, DateTime bithDate, bool isYoungDriver)
        {
            var customer = new Customer
            {
                Name = name,
                BirthDate = bithDate,
                IsYoungDriver = isYoungDriver
            };

            this.db.Add(customer);
            this.db.SaveChanges();
        }

        public bool Exists(int id)
            => this.db.Customers.Any(c => c.Id == id);

        public OrderCustomerModel ById(int id)
            => this.db
                .Customers
                .Where(c => c.Id == id)
                .Select(c => new OrderCustomerModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .FirstOrDefault();

        public void Edit(int id, string name, DateTime birthDay, bool isYoungDriver)
        {
            var existingCustomers = this.db.Customers.Find(id);

            if (existingCustomers == null)
            {
                return;
            }

            existingCustomers.Name = name;
            existingCustomers.BirthDate = birthDay;
            existingCustomers.IsYoungDriver = isYoungDriver;

            this.db.SaveChanges();
        }

        public ICollection<OrderCustomerModel> OrderedCustomers(OrderType order)
        {
            var custommerQuery = this.db.Customers.AsQueryable();

            switch (order)
            {
                case OrderType.Ascending:
                    custommerQuery = custommerQuery.OrderBy(c => c.BirthDate).ThenBy(x => x.Name);
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
                    Id = x.Id,
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
