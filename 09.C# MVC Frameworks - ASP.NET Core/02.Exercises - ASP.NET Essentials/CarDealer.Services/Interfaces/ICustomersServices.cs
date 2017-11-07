namespace CarDealer.Services.Interfaces
{
    using Models;
    using Models.Customers;
    using System.Collections.Generic;

    public interface ICustomersServices
    {
        ICollection<OrderCustomerModel> OrderedCustomers(OrderType order);

        CustomerTotalSalesModel TotalSalesById(int id);
    }
}
