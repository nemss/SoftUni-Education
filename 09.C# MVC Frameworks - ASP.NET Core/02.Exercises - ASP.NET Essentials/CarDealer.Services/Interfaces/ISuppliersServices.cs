namespace CarDealer.Services.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface ISuppliersServices
    {
        ICollection<FilterSuppliers> AllFilteredSupplierses(bool isInporter);
    }
}
