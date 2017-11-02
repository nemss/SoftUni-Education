namespace CarDealer.App
{
    using System;

    using Data;
    using Models;
    using System.Xml.Linq;
    using System.Linq;

    public class Application
    {
        public static void Main(string[] args)
        {

            
            CarDealerContext context = new CarDealerContext();
            //context.Database.Initialize(true);

            ImportData();

            //Query 1 - Cars
            //Cars(context);

            //Query 2 - Cars from make Ferrari
            //CarsFromMakeFerrari(context);

            //Query 3 - Local Suppliers
            //LocalSuppliers(context);

            //Query 4 - Cars with Their List of Parts
            //CarsWithTheirListOfParts(context);

            //Query 5 - Total Sales by Customer
            //TotalSalesByCustomers(context);

            //Query 6 - Sales with Applied Discount
            //SalesWithAppliedDiscount(context);

        }

        #region 6. Car Dealer Query and Export Data
        private static void SalesWithAppliedDiscount(CarDealerContext context)
        {
            using (context)
            {
                var allSales = context.Sales
                    .Select(s => new
                    {
                        Car = new
                        {
                            Make = s.Car.Make,
                            Model = s.Car.Model,
                            TravelledDistance = s.Car.TravelledDistance
                        },
                        CustomerName = s.Customer.Name,
                        Discount = s.Discount,
                        Price = s.Car.Parts.Sum(p => p.Price),
                        PriceWithDiscount = s.Car.Parts.Sum(p => p.Price) - (s.Car.Parts.Sum(p => p.Price) * s.Discount)
                    });

                XDocument salesDocument = new XDocument();
                XElement salesXml = new XElement("sales");

                foreach (var sale in allSales)
                {
                    XElement saleXml = new XElement("sale",
                        new XAttribute("make", sale.Car.Make),
                        new XAttribute("model", sale.Car.Model),
                        new XAttribute("travelled-distance", sale.Car.TravelledDistance),
                        new XElement("discount", sale.Discount),
                        new XElement("price", sale.Price),
                        new XElement("price-with-discount", sale.PriceWithDiscount));

                    salesXml.Add(saleXml);
                }

                salesDocument.Add(salesXml);
                salesDocument.Save("../../Export/salesWithAppliedDiscount.xml");
            }
        }

        private static void TotalSalesByCustomers(CarDealerContext context)
        {
            using (context)
            {
                var customers = context.Customers
                    .Where(c => c.Sales.Count >= 1)
                    .Select(c => new
                    {
                        Name = c.Name,
                        BoughtCars = c.Sales.Count(),
                        SpendMoney = c.Sales.Sum(s => s.Car.Parts.Sum(cp => cp.Price))
                    })
                    .OrderByDescending(c => c.SpendMoney)
                    .ThenByDescending(c => c.BoughtCars);

                XDocument customersDocument = new XDocument();
                XElement customersXml = new XElement("customers");

                foreach (var customer in customers)
                {
                    XElement customerXml = new XElement("customer",
                        new XAttribute("full-name", customer.Name),
                        new XAttribute("bought-cars", customer.BoughtCars),
                        new XAttribute("spent-mooney", customer.SpendMoney));

                    customersXml.Add(customerXml);
                }
                customersDocument.Add(customersXml);
                customersDocument.Save("../../Export/totalSalesByCustomer.xml");
            }
        }

        private static void CarsWithTheirListOfParts(CarDealerContext context)
        {
            using (context)
            {
                var cars = context.Cars
                    .Select(c => new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance,
                        Parts = c.Parts.Select(p => new
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                    });

                    XDocument carsDocument = new XDocument();
                    XElement carsXml = new XElement("suppliers");

                foreach (var car in cars)
                {
                    XElement carXml = new XElement("car",
                       new XAttribute("make", car.Make),
                       new XAttribute("model", car.Model),
                       new XAttribute("travelled-distance", car.TravelledDistance));

                    XElement partsXml = new XElement("parts");
                    foreach (var part in car.Parts)
                    {
                      XElement partXml = new XElement("part",
                            new XAttribute("name", part.Name),
                            new XAttribute("price", part.Price));
                        partsXml.Add(partXml);
                    }
                    carXml.Add(partsXml);
                    carsXml.Add(carXml);
                }
                    carsDocument.Add(carsXml);
                    carsDocument.Save("../../Export/carsWithTheirListOfParts.xml");
            }
        }

        private static void LocalSuppliers(CarDealerContext context)
        {
            using (context)
            {
                var suppliers = context.Suppliers
                    .Where(s => s.IsImporter == false)
                    .Select(s => new
                    {
                        SupplierId = s.Id,
                        Name = s.Name,
                        PartsCount = s.Parts.Count()
                    });
                XDocument suppliersDocument = new XDocument();
                XElement suppliersXml = new XElement("suppliers");

                foreach (var supplier in suppliers)
                {
                    XElement supplierXml = new XElement("supplier",
                        new XAttribute("id", supplier.SupplierId),
                        new XAttribute("name", supplier.Name),
                        new XAttribute("parts-count", supplier.PartsCount));

                    suppliersXml.Add(supplierXml);
                }

                suppliersDocument.Add(suppliersXml);
                suppliersDocument.Save("../../Export/localSuppliers.xml");

            }
        }

        private static void CarsFromMakeFerrari(CarDealerContext context)
        {
            using (context)
            {
                var cars = context.Cars
                    .Where(c => c.Make == "Ferrari")
                    .OrderBy(c => c.Model)
                    .ThenByDescending(c => c.TravelledDistance)
                    .Select(c => new
                    {
                        CarId = c.Id,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    });

                XDocument carsDocument = new XDocument();
                XElement carsXml = new XElement("cars");

                foreach (var car in cars)
                {
                    XElement carXml = new XElement("car",
                        new XAttribute("id", car.CarId),
                        new XAttribute("model", car.Model),
                        new XAttribute("travelled-distance", car.TravelledDistance));

                    carsXml.Add(carXml);

                }

                carsDocument.Add(carsXml);
                carsDocument.Save("../../Export/carsFromMakeFerari.xml");
            }
        }

        private static void Cars(CarDealerContext context)
        {
            using (context)
            {
                var allCars = context.Cars
                    .Where(c => c.TravelledDistance > 2000000)
                    .OrderBy(c => c.Make)
                    .ThenBy(c => c.Model)
                    .Select(c => new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    });
                        

                XDocument carsDocument = new XDocument();
                XElement carsXml = new XElement("cars");

                foreach (var car in allCars)
                {
                    XElement carXml = new XElement("car",
                        new XElement("make", car.Make),
                        new XElement("model", car.Model),
                        new XElement("travelled-distance", car.TravelledDistance));
                    

                    carsXml.Add(carXml);
                }

                carsDocument.Add(carsXml);
                carsDocument.Save("../../Export/cars.xml");
            }
        }
        #endregion

        #region 5. Car Dealer Import Data
        private static void ImportData()
        {
            //ImportSuppliers();
            //ImportParts();
            //ImportCars();
            //ImportCustomers();
            //ImportSales();

        }

        private static void ImportSales()
        {
            using(CarDealerContext context = new CarDealerContext())
            {
                int carsCount = context.Cars.Count();
                int customersCount = context.Customers.Count();
                Random rnd = new Random();
                for (int i = 0; i < 100; i++)
                {
                    Sale sale = new Sale()
                    {
                        CarId = rnd.Next(1, carsCount + 1),
                        CustomerId = rnd.Next(1, customersCount + 1),
                        Discount = i % 2 == 0 ? 0.05M : 0.00M
                    };
                    context.Sales.Add(sale);
                }
                context.SaveChanges();
            }
        }

        private static void ImportCustomers()
        {
            using (CarDealerContext context = new CarDealerContext())
            {
                XDocument customerDoc = XDocument.Load("../../Import/customers.xml");
                XElement customersRoot = customerDoc.Root;

                foreach (var customerElement in customersRoot.Elements())
                {
                    string name = customerElement.Attribute("name").Value;
                    DateTime dateTime = DateTime.Parse(customerElement.Element("birth-date").Value);
                    bool IsYoungDriver = bool.Parse(customerElement.Element("is-young-driver").Value);

                    Customer customer = new Customer()
                    {
                        Name = name,
                        BirthDate = dateTime,
                        IsYoungDriver = IsYoungDriver
                    };

                    context.Customers.Add(customer);
                }

                context.SaveChanges();
            }
        }

        private static void ImportCars()
        {
            using (CarDealerContext context = new CarDealerContext())
            {
                XDocument carsDoc = XDocument.Load("../../Import/cars.xml");
                XElement carsRoot = carsDoc.Root;

                foreach (XElement car in carsRoot.Elements())
                {
                    string make = car.Element("make").Value;
                    string model = car.Element("model").Value;
                    long travelledDistance = long.Parse(car.Element("travelled-distance").Value);

                    Car c = new Car()
                    {
                        Make = make,
                        Model = model,
                        TravelledDistance = travelledDistance,
                    };

                    int partsCount = context.Parts.Count();
                    for (int i = 0; i < 10  + (i % 10); i++)
                    {
                        Part p = context.Parts.Find((car.GetHashCode() + i % partsCount) + 1);
                        c.Parts.Add(p);
                    }

                    context.Cars.Add(c);
                }

                context.SaveChanges();
            }
        }

        private static void ImportParts()
        {
            using (CarDealerContext context = new CarDealerContext())
            {
                XDocument partsDoc = XDocument.Load("../../Import/parts.xml");
                XElement partsRoot = partsDoc.Root;
                Random rnd = new Random();
                int countSuppliers = context.Suppliers.Count();

                foreach (XElement part in partsRoot.Elements())
                {
                    string name = part.Attribute("name")?.Value;
                    decimal price = decimal.Parse(part.Attribute("price")?.Value);
                    int quantity = int.Parse(part.Attribute("quantity")?.Value);

                    Part p = new Part()
                    {
                        Name = name,
                        Price = price,
                        Quantity = quantity,
                        SupplierId = rnd.Next(1, countSuppliers)
                    };

                        context.Parts.Add(p); 
                }

                context.SaveChanges();
            }
        }

        private static void ImportSuppliers()
        {
            using (CarDealerContext context = new CarDealerContext())
            {
                XDocument suppliersDoc = XDocument.Load("../../Import/suppliers.xml");
                XElement suppliersRoot = suppliersDoc.Root;

                foreach (XElement supplierElement in suppliersRoot.Elements())
                {
                    string name = supplierElement.Attribute("name")?.Value;
                    bool IsImporter = bool.Parse(supplierElement.Attribute("is-importer")?.Value);
                    Supplier sup = new Supplier()
                    {
                        Name = name,
                        IsImporter = IsImporter
                    };

                    context.Suppliers.Add(sup);
                }

                context.SaveChanges();
            }
        }
        #endregion
    }
}
