namespace CarDealer.Services.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface ICarServices
    {
        ICollection<CarByMake> AllCarsByMakes(string make);

        ICollection<CarsWithPartsModel> CarWithParts(string id);
    }
}
