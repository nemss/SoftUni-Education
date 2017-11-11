namespace CarDealer.Services.Interfaces
{
    using Models.Parts;
    using System.Collections.Generic;

    public interface IPartService
    {
        IEnumerable<PartListingModel> All(int page = 1, int pageSize = 10);

        void Create(string name, double? price, int quantity, int supplierId);

        void Delete(int id);

        void Edit(int id, double? modelPrice, int modelQuantity);

        PartDetailsModel ById(int id);

        int Total();
    }
}
