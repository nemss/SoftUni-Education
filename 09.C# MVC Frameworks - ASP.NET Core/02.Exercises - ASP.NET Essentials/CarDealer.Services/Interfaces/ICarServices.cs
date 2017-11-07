namespace CarDealer.Services.Interfaces
{
    using Models.Cars;
    using System.Collections.Generic;

    public interface ICarServices
    {
        ICollection<CarByMake> AllCarsByMakes(string make);

        ICollection<CarsWithPartsModel> CarWithParts(string id);
    }
}
