namespace CarDealer.Services.Implementations
{
    using Data;
    using Interfaces;
    using Models.Cars;
    using Models.Parts;
    using System.Collections.Generic;
    using System.Linq;

    public class CarServices : ICarServices
    {
        private readonly CarDealerDbContext db;

        public CarServices(CarDealerDbContext db)
        {
            this.db = db;
        }

        public ICollection<CarByMake> AllCarsByMakes(string makes)
            => this.db
                .Cars
                .Where(c => c.Make.ToLower() == makes.ToLower())
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new CarByMake
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

        public ICollection<CarByMake> All()
            => this.db
                .Cars
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new CarByMake
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();


        public ICollection<CarsWithPartsModel> CarWithParts(string id)
            => this.db
                .Cars
                .Where(c => c.Id.ToString() == id)
                .Select(c => new CarsWithPartsModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    Parts = c.Parts.Select(p => new PartsModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                })
                .ToList();
    }
}
