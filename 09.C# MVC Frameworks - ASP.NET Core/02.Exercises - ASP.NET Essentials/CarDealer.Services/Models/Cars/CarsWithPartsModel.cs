namespace CarDealer.Services.Models.Cars
{
    using Parts;
    using System.Collections.Generic;

    public class CarsWithPartsModel : CarByMake
    {
        public IEnumerable<PartsModel> Parts { get; set; }
    }
}
