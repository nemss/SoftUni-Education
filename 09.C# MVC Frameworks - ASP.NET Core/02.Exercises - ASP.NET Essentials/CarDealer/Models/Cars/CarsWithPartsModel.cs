namespace CarDealer.App.Models.Cars
{
    using System.Collections.Generic;
    using Parts;

    public class CarsWithPartsModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public IEnumerable<PartsModel> Parts { get; set; }
    }
}
