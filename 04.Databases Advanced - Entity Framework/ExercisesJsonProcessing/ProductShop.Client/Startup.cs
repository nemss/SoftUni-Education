namespace ProductShop.Client
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
            ProductShopContext context = new ProductShopContext();

           //context.Database.Initialize(true);

            ImportData();

            //Query 1 - ProductsInRange
            //ProductsInRange(context);

            //Query 2 - SuccessfullySoldProducts
            //SuccessfullySoldProducts(context);

            //Query 3 - CategoriesByProductsCount
            //CategoriesByProductsCount(context);

            //Query 4 - Users and Products
            //UserrsAndProducts(context);
        }
        #endregion

        #region 3.Query and Export Data
        private static void UserrsAndProducts(ProductShopContext context)
        {
            using (context)
            {
                var usersAndProducts = context.Users
                    .Where(u => u.ProductsSold.Count != 0)
                    .OrderByDescending(u => u.ProductsSold.Count)
                    .ThenBy(u => u.LastName)
                    .Select(u => new
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age,
                        SoldProducts = new
                        {
                            Cuunt = u.ProductsSold.Count,
                            Products = u.ProductsSold.Select(p => new
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                        }
                    });
                string jsonUser = JsonConvert.SerializeObject(new { UserCount = usersAndProducts.Count(), User = usersAndProducts}, Formatting.Indented);
                File.WriteAllText("../../Export/usersAndProducts.json", jsonUser);
            }
        }

        private static void CategoriesByProductsCount(ProductShopContext context)
        {
            using (context) 
            {
                var categories = context.Categories
                    .OrderBy(c => c.Name)
                    .Select(c => new
                    {
                        CategoryName = c.Name ?? "",
                        ProductCount = c.Products.Count,
                        AveragePrice = c.Products.Average(p => p.Price),
                        TotalRevenue = c.Products.Sum(p => p.Price)
                    });

                string jsonCategories = JsonConvert.SerializeObject(categories, Formatting.Indented);
                File.WriteAllText("../../Export/categoriesByProductsCount.json", jsonCategories);
            }
        }

        private static void SuccessfullySoldProducts(ProductShopContext context)
        {
            using (context)
            {
                var user = context.Users
                    .Where(u => u.ProductsSold.Count(p => p.Buyer != null) >= 1)
                    .OrderBy(p => p.FirstName)
                    .ThenBy(p => p.LastName)
                    .Select(p => new
                    {
                        FistName = p.FirstName,
                        LastName = p.LastName,
                        soldProducts = p.ProductsSold.Select(pro => new
                        {
                            ProductName = pro.Name,
                            ProductPrice = pro.Price,
                            BuyerFirstName = pro.Buyer.FirstName,
                            BuyerLastName = pro.Buyer.LastName
                        })
                    });

                string jsonUser = JsonConvert.SerializeObject(user, Formatting.Indented);
                File.WriteAllText("../../Export/successfullySoldProducts.json", jsonUser);
            }
        }

        private static void ProductsInRange(ProductShopContext context)
        {
            using (context)
            {
                var productsInRange = context.Products
                    .Where(p => p.Price >= 500 && p.Price <= 1000)
                    .OrderBy(p => p.Price)
                    .Select(p => new
                    {
                        Name = p.Name,
                        Price = p.Price,
                        SallerName = p.Seller.FirstName?? "" + " " + p.Seller.LastName 
                    });

                string jsonProducts = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);
                File.WriteAllText("../../Export/productInRange.json", jsonProducts);

            }
        }
        #endregion

        #region 2.Import Data
        private static void ImportData()
        {
            //ImportUsers();
            //ImportProducts();
            //ImportCategories();
        }

        private static void ImportCategories()
        {
            using (ProductShopContext context = new ProductShopContext())
            {
                string json = File.ReadAllText("../../Import/categories.json");
                var jsonCategories = JsonConvert.DeserializeObject<List<Category>>(json);

                int numebr = 0;
                int CountOfProducts = context.Products.Count();
                foreach (var c in jsonCategories)
                {
                    int categoryProductsCount = numebr % 3;
                    for (int i = 0; i < categoryProductsCount; i++)
                    {
                        c.Products.Add(context.Products.Find((numebr % CountOfProducts) + 1));
                    }

                    numebr++;
                }
                context.Categories.AddRange(jsonCategories);
                context.SaveChanges();
            }
        }

        private static void ImportProducts()
        {
            using (ProductShopContext context = new ProductShopContext())
            {
                string json = File.ReadAllText("../../Import/products.json");
                var jsonProducts = JsonConvert.DeserializeObject<List<Product>>(json);

                int number = 0;
                int userCount = context.Users.Count();
                foreach (var p in jsonProducts)
                {
                    p.SellerId = (number % userCount) + 1;
                    if(number % 3 != 0)
                    {
                        p.BuyerId = (number * 2 % userCount) + 1;
                    }
                    number++;
                }

                context.Products.AddRange(jsonProducts);
                context.SaveChanges();
            }
        }

        private static void ImportUsers()
        {
            using (ProductShopContext context = new ProductShopContext())
            {
                string json = File.ReadAllText("../../Import/users.json");
                var jsonUsers = JsonConvert.DeserializeObject<List<User>>(json);
                context.Users.AddRange(jsonUsers);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
