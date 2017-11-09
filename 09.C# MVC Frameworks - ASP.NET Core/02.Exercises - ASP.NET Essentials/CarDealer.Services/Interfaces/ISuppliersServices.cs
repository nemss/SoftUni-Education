namespace CarDealer.Services.Interfaces
{
    using System.Collections.Generic;

    public interface ISuppliersServices
    {
        ICollection<FilterSuppliers> AllFilteredSupplierses(bool isInporter);
    }
}
