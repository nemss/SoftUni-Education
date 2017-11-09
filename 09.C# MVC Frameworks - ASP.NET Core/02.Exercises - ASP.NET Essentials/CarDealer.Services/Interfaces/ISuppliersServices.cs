namespace CarDealer.Services.Interfaces
{
    using System.Collections.Generic;
    using Models.Suppliers;

    public interface ISuppliersServices
    {
        ICollection<FilterSuppliers> AllFilteredSupplierses(bool isInporter);

        IEnumerable<SupplierModel> All();
    }
}
