namespace CarDealer.Services.Models.Sales
{
    using Cars;

    public class SaleDetailsModel : SaleListModel
    {
        public CarByMake Car { get; set; }
    }
}
