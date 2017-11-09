namespace CarDealer.App.Models.Customers
{
    using Services;
    using Services.Models.Customers;
    using System.Collections.Generic;

    public class AllCustomersModel
    {
        public IEnumerable<OrderCustomerModel> Customer { get; set; }

        public OrderType Type { get; set; }
    }
}
