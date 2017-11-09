namespace CarDealer.App.Models.Suppliers
{
    using Services;
    using System.Collections.Generic;

    public class SuppliersModel
    {
        public string Type { get; set; }
        
        public IEnumerable<FilterSuppliers> Suppliers { get; set; }
    }
}
