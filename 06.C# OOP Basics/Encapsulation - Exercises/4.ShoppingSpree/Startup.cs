namespace _4.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var people = new List<Person>();
            var products = new List<Product>();
            try
            {
                var allPeople = Console.ReadLine();
                var allPeopleTokens = allPeople.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var token in allPeopleTokens)
                {
                    var info = token.Split(new char[] {'='}, StringSplitOptions.RemoveEmptyEntries);
                    var name = info[0];
                    var money = decimal.Parse(info[1]);

                    people.Add(new Person(name, money));

                }

                var allProducts = Console.ReadLine().Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var product in allProducts)
                {
                    var info = product.Split(new char[] {'='}, StringSplitOptions.RemoveEmptyEntries);
                    var nameProduct = info[0];
                    var costProduct = decimal.Parse(info[1]);

                    products.Add(new Product(nameProduct, costProduct));

                }

                string inputLine;
                while (!(inputLine = Console.ReadLine()).Equals("END"))
                {
                    var tokens = inputLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    var personName = tokens[0];
                    var productName = tokens[1];

                    var person = people.FirstOrDefault(p => p.Name == personName);
                    var product = products.FirstOrDefault(p => p.Name == productName);

                    person.ByProduct(product);
                }

                foreach (var person in people)
                {
                    if (person.Products.Count > 0)
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products.Select(p => p.Name))}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

