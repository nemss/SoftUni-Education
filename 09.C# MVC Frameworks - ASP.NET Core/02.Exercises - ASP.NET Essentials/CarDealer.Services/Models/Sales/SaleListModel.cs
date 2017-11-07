namespace CarDealer.Services.Models.Sales
{
    public class SaleListModel : SalePriceModel
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public bool IsYoungDriver { get; set; }

        public double? DiscountPrice => this.Price * (1 -(this.Discount + (this.IsYoungDriver ? 0.05 : 0)));
    }
}
