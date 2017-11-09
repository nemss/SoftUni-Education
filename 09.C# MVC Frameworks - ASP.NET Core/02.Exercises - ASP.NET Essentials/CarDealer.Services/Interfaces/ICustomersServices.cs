namespace CarDealer.Services.Interfaces
{
    using System;
    using Models.Customers;
    using System.Collections.Generic;

    public interface ICustomersServices
    {
        ICollection<OrderCustomerModel> OrderedCustomers(OrderType order);

        CustomerTotalSalesModel TotalSalesById(int id);

        void Create(string name, DateTime bithDate, bool isYoungDriver);

        void Edit(int id, string name, DateTime birthDay, bool isYoungDriver);

        bool Exists(int id);

        OrderCustomerModel ById(int id);
    }
}
