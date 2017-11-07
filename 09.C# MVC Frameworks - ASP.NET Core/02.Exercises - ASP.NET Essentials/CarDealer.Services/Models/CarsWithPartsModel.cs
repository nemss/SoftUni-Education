namespace CarDealer.Services.Models
{
    using System.Collections.Generic;

    public class CarsWithPartsModel : CarByMake
    {
        public IEnumerable<PartsModel> Parts { get; set; }
    }
}
