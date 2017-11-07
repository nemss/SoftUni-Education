namespace CarDealer.App.Models.Customers
{
    using Services.Models;
    using Services.Models.Customers;
    using System.Collections.Generic;

    public class AllCustomersModel
    {
        public IEnumerable<OrderCustomerModel> Customers { get; set; }

        public OrderType OrderType { get; set; }
    }
}
