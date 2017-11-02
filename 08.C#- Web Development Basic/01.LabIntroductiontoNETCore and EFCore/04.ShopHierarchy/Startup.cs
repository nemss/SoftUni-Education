namespace _04.ShopHierarchy
{
    using _04.ShopHierarchy.Data;
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            using (var db = new MyDbContext())
            {
                ClearDatabase(db);
                SaveSalesmen(db);
                SaveItem(db);
                ProcessCommand(db);
                //PrintSalesMen(db);
                //PrintCustomerWithOrdersAndReviwsCount(db);
                //PrintCustomersWithOrdersAndReviewsCount(db);
                //PrintCustomerData(db);
                PrintOrdersWithMoreOneItemInDb(db);
            }
        }

        private static void PrintOrdersWithMoreOneItemInDb(MyDbContext db)
        {
            var customerId = int.Parse(Console.ReadLine());

            var customerOrder = db
                .Orders
                .Where(o => o.Id == customerId)
                .Where(o => o.Items.Count > 1)
                .Count();

            Console.WriteLine($"Orders: {customerOrder}");
        }

        private static void PrintCustomerData(MyDbContext db)
        {
            var customerId = int.Parse(Console.ReadLine());

            var customerData = db
                .Customers
                .Where(c => c.Id == customerId)
                .Select(c => new
                {
                    c.Name,
                    Orders = c.Orders.Count,
                    Reviews = c.Reviews.Count,
                    Salesman = c.Salesman.Name
                })
                .FirstOrDefault();

            Console.WriteLine($"Customer: {customerData.Name}");
            Console.WriteLine($"Orders count: {customerData.Orders}");
            Console.WriteLine($"Reviews count: {customerData.Reviews}");
            Console.WriteLine($"Salesman: {customerData.Salesman}");
        }

        private static void PrintCustomersWithOrdersAndReviewsCount(MyDbContext db)
        {
            var customerId = int.Parse(Console.ReadLine());

            var customerOrder = db
                .Customers
                .Where(c => c.Id == customerId)
                .Select(c => new
                {
                    Orders = c
                        .Orders
                        .Select(o => new
                        {
                            o.Id,
                            Items = o.Items.Count
                        })
                        .OrderBy(o => o.Id),
                    Reviews = c.Reviews.Count
                })
                .FirstOrDefault();

            foreach (var order in customerOrder.Orders)
            {
                Console.WriteLine($"order {order.Id}: {order.Items} items");
            }

            Console.WriteLine($"reviews: {customerOrder.Reviews}");
        }

        private static void SaveItem(MyDbContext db)
        {
            while (true)
            {
                var line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                var parts = line.Split(';');
                var itemName = parts[0];
                var itemPrice = decimal.Parse(parts[1]);

                db.Add(new Item
                {
                    Name = itemName,
                    Price = itemPrice
                });
            }

            db.SaveChanges();
        }

        private static void PrintCustomerWithOrdersAndReviwsCount(MyDbContext db)
        {
            var customersData = db
                .Customers
                .Select(c => new
                {
                    c.Name,
                    Orders = c.Orders.Count,
                    Reviews = c.Reviews.Count
                })
                .OrderByDescending(c => c.Orders)
                .ThenBy(c => c.Reviews)
                .ToList();

            foreach (var customer in customersData)
            {
                Console.WriteLine(customer.Name);
                Console.WriteLine($"Orders: {customer.Orders}");
                Console.WriteLine($"Reviews: {customer.Reviews}");
            }
        }

        private static void PrintSalesMen(MyDbContext db)
        {
            var salesmanData = db
                .Salesmen
                .Select(s => new
                {
                    Name = s.Name,
                    CustomerCount = s.Customers.Count
                })
                .OrderByDescending(s => s.CustomerCount)
                .ThenBy(s => s.Name)
                .ToList();

            foreach (var salesman in salesmanData)
            {
                Console.WriteLine($"{salesman.Name} - {salesman.CustomerCount} customers");
            }
        }

        private static void ProcessCommand(MyDbContext db)
        {
            while (true)
            {
                var line = Console.ReadLine();

                if (line == "END")
                {
                    break; ;
                }

                var parts = line.Split('-');
                var command = parts[0];
                var arguments = parts[1];

                switch (command)
                {
                    case "register":
                        RegisterCustomer(db, arguments);
                        break;

                    case "order":
                        SaveOrder(db, arguments);
                        break;

                    case "review":
                        SaveReview(db, arguments);
                        break;

                    default:
                        break; ;
                }
            }
        }

        private static void SaveReview(MyDbContext db, string arguments)
        {
            var parts = arguments.Split(';');
            var customerId = int.Parse(parts[0]);
            var itemId = int.Parse(parts[1]);

            db.Add(new Review
            {
                CustomerId = customerId,
                ItemId = itemId
            });

            db.SaveChanges();
        }

        private static void SaveOrder(MyDbContext db, string arguments)
        {
            var parts = arguments.Split(';');
            var customerId = int.Parse(parts[0]);

            var order = new Order { CustomerId = customerId };

            for (int i = 1; i < parts.Length; i++)
            {
                var itemId = int.Parse(parts[i]);

                order.Items.Add(new ItemOrder
                {
                    ItemId = itemId,
                });
            }

            db.Add(order);

            db.SaveChanges();
        }

        private static void RegisterCustomer(MyDbContext db, string arguments)
        {
            var parts = arguments.Split(';');
            var customerName = parts[0];
            var salesmanId = int.Parse(parts[1]);

            db.Add(new Customer
            {
                Name = customerName,
                SalesmanId = salesmanId
            });

            db.SaveChanges();
        }

        private static void SaveSalesmen(MyDbContext db)
        {
            var salesmen = Console.ReadLine().Split(';');

            foreach (var salesman in salesmen)
            {
                db.Add(new Salesman { Name = salesman });
            }

            db.SaveChanges();
        }

        private static void ClearDatabase(MyDbContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}