namespace CarDealer.Services.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface ICustomersServices
    {
        ICollection<OrderCustomerModel> OrderedCustomers(OrderType order);
    }
}
