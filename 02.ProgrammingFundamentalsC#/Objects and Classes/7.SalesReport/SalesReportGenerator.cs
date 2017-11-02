using System;
using System.Collections.Generic;
using System.Linq;

class Sales

{
    static void Main()
   {
        var n = int.Parse(Console.ReadLine());
        var sales = new List<Sale>();
        for (int i = 0; i < n; i++)
        {
            var sale = ReadSale();
            sales.Add(sale);
        }

        var towns = sales.Select(s => s.Town).OrderBy(t => t).Distinct().ToList();

        foreach (var t in towns)
        {
            var salesForT = sales.Where(s => s.Town == t).Sum(s => s.Price * s.Quantity);
            Console.WriteLine("{0} -> {1:f2}",t ,salesForT);
        }
   }

     static Sale ReadSale()
    {
        var tokens = Console.ReadLine().Split(' ');
        var town = tokens[0];
        var product = tokens[1];
        var price = decimal.Parse(tokens[2]);
        var quantity = decimal.Parse(tokens[3]);
        var sale = new Sale
        {
            Town = town,
            Product = product,
            Price = price,
            Quantity = quantity
        };
        return sale;
    }

    class Sale
    {
        public string Town { get; set; }

        public string Product { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }


    }

}

