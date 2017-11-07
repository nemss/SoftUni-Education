namespace CarDealer.Services.Models.Cars
{
    using System.Collections.Generic;

    public class CarsWithPartsModel : CarByMake
    {
        public IEnumerable<PartsModel> Parts { get; set; }
    }
}
