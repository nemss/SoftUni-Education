namespace ProductsShop
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    using Data;

    using Model;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using System.IO;

    public class Application
    {
        public static void Main(string[] args)
        {
            
            ProductShopContext context = new ProductShopContext();
            //context.Database.Initialize(true);

            ImportData();

            //Query 1 - Products In Range 
            //ProductInRange(context);

            //Query 2 - Sold Products
            //SoldProducts(context);

            //Query 3 - Categories By Products Count
            //CategoriesByProductsCount(context);

            //Query 4 - Users and Products
            //UsersAndProducts(context);
        }

        #region 4. Query and Export Data
        private static void UsersAndProducts(ProductShopContext context)
        {
            using (context)
            {

                var users = context.Users
                    .Where(u => u.ProductsSold.Count > 0)
                    .OrderByDescending(u => u.ProductsSold.Count)
                        .ThenBy(u => u.LastName)
                        .Select(u => new
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Age = u.Age,
                            SoldProducts = new
                            {
                                Count = u.ProductsSold.Count(),
                                Products = u.ProductsSold.Select(p => new
                                {
                                    name = p.Name,
                                    price = p.Price,
                                })
                            }
                        }).ToList();

                var xml = new XElement("users",
                    new XAttribute("count", users.Count),
                    users.Select(u =>
                        new XElement("user",
                        u.FirstName == null ? null : new XAttribute("fist-name", u.FirstName),
                        new XAttribute("last-name", u.LastName),
                        new XAttribute("age", u.Age),
                        new XElement("sold-products",
                        new XAttribute("count", u.SoldProducts.Count),
                        u.SoldProducts.Products.Select(s =>
                        new XElement("product",
                        new XAttribute("name", s.name),
                        new XAttribute("price", s.price)))))));
                XDocument usersDocumnet = new XDocument();
                usersDocumnet.Add(xml);
                usersDocumnet.Save("../../Export/usersAndProducts.xml");
                      
                    
                    

                //XDocument usersDocument = new XDocument();
                //XElement usersXml = new XElement("users",
                //    new XAttribute("count", users.Count()));

                //foreach (var u in users)
                //{
                //    XElement userXml = new XElement("user",
                //        new XAttribute("first-name", u.FirstName??" "),
                //        new XAttribute("last-name", u.LastName),
                //        new XAttribute("age", u.Age));

                //    if (int.Parse(userXml.Attribute("age").Value) == 0)
                //    {
                //        userXml.Attribute("age").Remove();
                //    }

                //    if (userXml.Attribute("first-name").Value == string.Empty)
                //    {
                //        userXml.Attribute("first-name").Remove();
                //    }

                //    XElement productsSoldXml = new XElement("sold-products",
                //        new XAttribute("count", u.SoldProducts.Count));

                //    foreach (var p in u.SoldProducts.Products)
                //    {
                //        XElement productSoldXml = new XElement("product",
                //            new XAttribute("name", p.name),
                //            new XAttribute("price", p.price));

                //        productsSoldXml.Add(productSoldXml);
                //    }
                //    userXml.Add(productsSoldXml);
                //    usersXml.Add(usersXml);
                //}

                //usersDocument.Add(usersXml);
                //usersDocument.Save("../../Export/usersAndProducts.xml");
               
            }
        }

        private static void CategoriesByProductsCount(ProductShopContext context)
        {
            using (context)
            {
                var categories = context.Categories
                    .OrderBy(c=> c.Products.Count())
                    .Select(c => new
                    {
                        CategoryName = c.Name,
                        ProductsCount = c.Products.Count(),
                        AveragePrice = c.Products.Average(p => p.Price),
                        TotalRevenue = c.Products.Sum(p => p.Price)                       
                    });

                XDocument categoriesDocument = new XDocument();
                XElement categoriesXml = new XElement("categories");

                foreach (var c in categories)
                {
                    XElement categoryXml = new XElement("category",
                        new XAttribute("name", c.CategoryName),
                        new XElement("product-count", c.ProductsCount),
                        new XElement("average-price", c.AveragePrice),
                        new XElement("total-revenue", c.TotalRevenue));

                    categoriesXml.Add(categoryXml);
                }

                categoriesDocument.Add(categoriesXml);
                categoriesDocument.Save("../../Export/categoriesByProductsCount.xml");
            }
        }

        private static void SoldProducts(ProductShopContext context)
        {
            using (context)
            {
                var allUsers = context.Users
                    .Where(u => u.ProductsSold.Count() >= 1)
                    .Select(u => new
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        SoldProducts = u.ProductsSold.Select(s => new
                        {
                            Name = s.Name,
                            Price = s.Price
                        })
                    });

                XDocument usersDocument = new XDocument();
                XElement usersXml = new XElement("users");

                foreach (var u in allUsers)
                {
                    XElement userXml = new XElement("user",
                        new XAttribute("first-name", u.FirstName ?? ""),
                        new XAttribute("last-name",u.LastName));

                    XElement productsSoldXml = new XElement("sold-products");
                    foreach (var s in u.SoldProducts)
                    {
                        XElement productSoldXml = new XElement("product",
                            new XElement("name", s.Name),
                            new XElement("price", s.Price));

                        productsSoldXml.Add(productSoldXml);
                    }
                    userXml.Add(productsSoldXml);
                    usersXml.Add(userXml);
                }

                usersDocument.Add(usersXml);
                usersDocument.Save("../../Export/soldProducts.xml");
            }
        }

        private static void ProductInRange(ProductShopContext context)
        {
            using(context)
            {
                var allProducts = context.Products
                    .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.BuyerId != null)
                    .Select(p => new
                    {
                        Name = p.Name,
                        Price = p.Price,
                        BuyerName = p.Buyer.FirstName + " " + p.Buyer.LastName 
                    });

                XDocument productsDocument = new XDocument();
                XElement productsXml = new XElement("products");

                foreach (var p in allProducts)
                {
                    XElement productXml = new XElement("product",
                        new XAttribute("name", p.Name),
                        new XAttribute("price", p.Price),
                        new XAttribute("buyer", p.BuyerName));

                    productsXml.Add(productXml);
                }

                productsDocument.Add(productsXml);
                productsDocument.Save("../../Export/productsInRange.xml");
            }
        }
        #endregion

        #region 3. Import Date
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
                XDocument categoriesDocument = XDocument.Load("../../Import/categories.xml");
                XElement categoriesRoot = categoriesDocument.Root;

                int countProducts = context.Products.Count();
                var products = context.Products.ToList();
                Random rnd = new Random();

                foreach (var category in categoriesRoot.Elements())
                {
                    string name = category.Element("name")?.Value;

                    Category c = new Category()
                    {
                        Name = name
                    };

                    for (int i = 0; i < countProducts / 3; i++)
                    {
                        Product product = context.Products.Find(rnd.Next(1, countProducts + 1));
                        c.Products.Add(product);
                    }
                    context.Categories.Add(c);
                }

                context.SaveChanges();
            }
        }

        private static void ImportProducts()
        {
            using (ProductShopContext context = new ProductShopContext())
            {
                XDocument productsDocuments = XDocument.Load("../../Import/products.xml");
                XElement productsRoot = productsDocuments.Root;

                Random rnd = new Random();
                int userCount = context.Users.Count();

                foreach (var product in productsRoot.Elements())
                {
                    string name = product.Element("name")?.Value;
                    decimal price = decimal.Parse(product.Element("price").Value);
                    double shouldHaveBuyerId = rnd.NextDouble();
                    Product p = new Product()
                    {
                        Name = name,
                        Price = price,
                        SelledId = rnd.Next(1, userCount + 1)
                    };
                    if (shouldHaveBuyerId <= 0.8)
                    {
                        p.BuyerId = rnd.Next(1, userCount + 1);
                    }
                    context.Products.Add(p);
                }
                context.SaveChanges();
            }
        }

        private static void ImportUsers()
        {
            using (ProductShopContext context = new ProductShopContext())
            {
                XDocument usersDocument = XDocument.Load("../../Import/users.xml");
                XElement usersRoot = usersDocument.Root;

                foreach (var user in usersRoot.Elements())
                {
                    string firstName = user.Attribute("first-name")?.Value;
                    string lastName = user.Attribute("last-name")?.Value;
                    int age = user.Attribute("age") != null ? int.Parse(user.Attribute("age").Value) : 0;

                    User u = new User()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age
                    };

                    context.Users.Add(u);
                }

                context.SaveChanges();
            }
        }
        #endregion
    }
}
