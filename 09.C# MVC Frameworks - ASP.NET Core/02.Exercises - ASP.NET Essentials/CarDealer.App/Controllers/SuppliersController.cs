namespace CarDealer.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Suppliers;
    using Services.Interfaces;

    public class SuppliersController : Controller
    {
        private readonly ISuppliersServices suppliers;

        public SuppliersController(ISuppliersServices suppliers)
        {
            this.suppliers = suppliers;
        }

        public IActionResult Local()
            => View("Suppliers", this.GetSuppliers(true));

        public IActionResult Importers()
            => View("Suppliers", this.GetSuppliers(false));

        private SuppliersModel GetSuppliers(bool importers)
        {
            var type = importers ? "Importrs" : "Local";

            var suppliers = this.suppliers.AllFilteredSupplierses(importers);

            return new SuppliersModel
            {
                Type = type,
                Suppliers = suppliers
            };
        }
    }
}
