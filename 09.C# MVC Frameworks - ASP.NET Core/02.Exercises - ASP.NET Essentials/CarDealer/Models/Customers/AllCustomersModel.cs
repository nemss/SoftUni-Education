namespace CarDealer.App.Models.Customers
{
    using System.Collections.Generic;
    using Services.Models;

    public class AllCustomersModel
    {
        public IEnumerable<OrderCustomerModel> Customers { get; set; }

        public OrderType OrderType { get; set; }
    }
}
