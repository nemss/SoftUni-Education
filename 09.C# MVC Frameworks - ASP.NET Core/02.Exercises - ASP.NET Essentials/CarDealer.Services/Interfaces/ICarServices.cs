namespace CarDealer.Services.Interfaces
{
    using Models.Cars;
    using System.Collections.Generic;

    public interface ICarServices
    {
        ICollection<CarByMake> AllCarsByMakes(string make);

        ICollection<CarByMake> All();

        void Create(string make, string model, long travelledDistance);

        ICollection<CarsWithPartsModel> CarWithParts(string id);
        
    }
}
