namespace CarDealer.Services.Models.Customers
{
    using Sales;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerTotalSalesModel
    {
        public string Name { get; set; }

        public bool IsYoungDriver { get; set; }

        public IEnumerable<SalePriceModel> BoughtCars { get; set; }

        public double? TotalMoneySpent
            => this.BoughtCars.Sum(p => p.Price * (1 - p.Discount))
               * (this.IsYoungDriver ? 0.95 : 1);
    }
}
