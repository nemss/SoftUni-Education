namespace CarDealer.Services.Implementations
{
    using Data;
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class SuppliersServices : ISuppliersServices
    {
        private readonly CarDealerDbContext db;

        public SuppliersServices(CarDealerDbContext db)
        {
            this.db = db;
        }

        public ICollection<FilterSuppliers> AllFilteredSupplierses(bool isInporter)
            => this.db
                .Suppliers
                .Select(s => new FilterSuppliers
                {
                    Id = s.Id,
                    Name = s.Name,
                    NumberOfParts = s.Parts.Count
                })
                .ToList();
    }
}
