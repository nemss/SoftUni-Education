namespace CarDealer.App.Models.Suppliers
{
    using System.Collections.Generic;
    using Services.Models;

    public class SuppliersModel
    {
        public string Type { get; set; }

        public ICollection<FilterSuppliers> Suppliers { get; set; }
    }
}
