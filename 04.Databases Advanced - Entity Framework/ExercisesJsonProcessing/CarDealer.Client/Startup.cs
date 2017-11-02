namespace CarDealer.Client
{
    using Data;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Startup
    {
        #region Startup
        static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //context.Database.Initialize(true);
            ImportData();

            //Query 1 - Ordered Customers 
            //OrderedCustomers(context);

            //Query 2 - Cars from make Toyota
            //CarsFromMakeToyota(context);

            //Query 3 - Local Supppliers
            //LocalSuppliers(context);

            //Query 4 - Cars with Their List of Parts
            //CarsWithTheirListOfParts(context);

            //Query 5 - Total Sales by Customer
            //TotalSalesByCustomer(context);

            //Query 6 - Sales with Applied Discount
            //SalesWithAppliedDiscount(context);
        }
        #endregion

        #region 6. Car Dealer and Export Data
        private static void SalesWithAppliedDiscount(CarDealerContext context)
        {
            using (context)
            {
                var cars = context.Sales
                    .Where(s => s.Discount != 0)
                    .ToList()
                    .Select(s => new
                    {
                        car = new
                        {
                            Make = s.Car.Make,
                            Model = s.Car.Model,
                            TravalledDistance = s.Car.TravelledDistance,
                        },
                        CustomerName = s.Customer.Name,
                        Discount = s.Discount,
                        Price = s.Car.Parts.Sum(p => p.Price),
                        PriceWithDiscount = (s.Car.Parts.Sum(p => p.Price)) - (s.Car.Parts.Sum(p => p.Price) * (decimal)s.Discount)
                    });
                string json = JsonConvert.SerializeObject(cars, Formatting.Indented);
                File.WriteAllText("../../Export/salesWithAppliedDiscount.json", json);
            }
        }

        private static void TotalSalesByCustomer(CarDealerContext context)
        {
            using (context)
            {
                var customer = context.Customers
                    .Where(c => c.Sales.Count >= 1)
                    .Select(c => new
                    {
                        FullName = c.Name,
                        BoughtCars = c.Sales.Count,
                        SpendMoney = c.Sales.Sum(s => s.Car.Parts.Sum(car => car.Price))
                    })
                    .OrderByDescending(c => c.SpendMoney)
                    .ThenByDescending(c => c.BoughtCars);

                string jsonCustomer = JsonConvert.SerializeObject(customer, Formatting.Indented);
                File.WriteAllText("../../Export/totalSalesByCustomer.json", jsonCustomer);
            }
        }

        private static void CarsWithTheirListOfParts(CarDealerContext context)
        {
            using (context)
            {
                var cars = context.Cars
                    .Select(c => new
                    {
                        car = new
                        {
                            Make = c.Make,
                            Model = c.Model,
                            TravelledDistance = c.TravelledDistance,
                            parts = c.Parts.Select(p => new
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                        }
                    });
                string jsonCars = JsonConvert.SerializeObject(cars,Formatting.Indented);
                File.WriteAllText("../../Export/carsWithTheirListofParts.json", jsonCars);

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
                        Id = s.Id,
                        Name = s.Name,
                        PartsCount = s.Parts.Count
                    });

                string jsonSuppliers = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
                File.WriteAllText("../../Export/localSuppliers.json", jsonSuppliers);
            }
        }

        private static void CarsFromMakeToyota(CarDealerContext context)
        {
            using (context)
            {
                var cars = context.Cars
                    .Where(c => c.Make == "Toyota")
                    .OrderBy(c => c.Model)
                    .ThenByDescending(c => c.TravelledDistance)
                    .Select(c => new
                    {
                        c.Id,
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    });

                string jsonCars = JsonConvert.SerializeObject(cars, Formatting.Indented);
                File.WriteAllText("../../Export/carsFromMakeToyota.json", jsonCars);
            }
        }

        private static void OrderedCustomers(CarDealerContext context)
        {
            using (context)
            {
                var customers = context.Customers
                    .OrderBy(c => c.BirthDate)
                    .ThenByDescending(c => c.IsYoungDriver)
                    .Select(c => new
                    {
                        Id = c.Id,
                        Name = c.Name,
                        BirthDate = c.BirthDate,
                        IsYoungDriver = c.IsYoungDriver,
                        Sales = c.Sales.Select(s => new
                        {
                            Id = s.Id,
                            CarId = s.CarId,
                            CustomerId = s.CustomerId,
                            Discount = s.Discount
                        })
                    });


                string jsonCustomers = JsonConvert.SerializeObject(customers, Formatting.Indented);
                File.WriteAllText("../../Export/orderedCustomers.json", jsonCustomers);
            }
        }
        #endregion

        #region  5. Car Dealer Import Data
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
            using (CarDealerContext context = new CarDealerContext())
            {
                double[] discounts = new double[] { 0, 0.05, 0.10, 0.20, 0.30, 0.40, 0.50 };
                var cars = context.Cars.ToList();
                var customers = context.Customers.ToList();

                Random rnd = new Random();

                for (int i = 0; i < 60; i++)
                {
                    var car = cars[rnd.Next(cars.Count)];
                    var customer = customers[rnd.Next(customers.Count)];
                    var discount = discounts[rnd.Next(discounts.Length)];
                    if(customer.IsYoungDriver)
                    {
                        discount += 0.05;
                    }

                    Sale sale = new Sale()
                    {
                        Car = car,
                        Customer = customer,
                        Discount = discount
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
                string json = File.ReadAllText("../../Import/customers.json");
                var jsonCustomers = JsonConvert.DeserializeObject<List<Customer>>(json);

                context.Customers.AddRange(jsonCustomers);
                context.SaveChanges();
            }
        }

        private static void ImportCars()
        {
            using (CarDealerContext context = new CarDealerContext())
            {
                string json = File.ReadAllText("../../Import/cars.json");
                var jsonCars = JsonConvert.DeserializeObject<List<Car>>(json);

                Random rnd = new Random();
                var parts = context.Part.ToList();
            foreach (var c in jsonCars)
                {
                    int randomPartsBetween10And20 = rnd.Next(10, 21);
                    for (int i = 0; i < randomPartsBetween10And20; i++)
                    {
                        c.Parts.Add(parts[rnd.Next(parts.Count)]);
                    }
                }

                context.Cars.AddRange(jsonCars);
                context.SaveChanges();
            }
        }

        private static void ImportParts()
        {
            using (CarDealerContext context = new CarDealerContext())
            {
                string json = File.ReadAllText("../../Import/parts.json");
                var jsonParts = JsonConvert.DeserializeObject<List<Part>>(json);

                Random rnd = new Random();
                int countSuppliers = context.Suppliers.Count();

                foreach (var p in jsonParts)
                {
                    p.SupplierId = rnd.Next(1, countSuppliers + 1);
                }
                context.Part.AddRange(jsonParts);
                context.SaveChanges();
            }
        }

        private static void ImportSuppliers()
        {
            using (CarDealerContext context = new CarDealerContext())
            {
                string json = File.ReadAllText("../../Import/suppliers.json");
                var jsonSuppliers = JsonConvert.DeserializeObject<List<Supplier>>(json);
                context.Suppliers.AddRange(jsonSuppliers);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
