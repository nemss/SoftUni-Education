namespace SimpleFactory.CoffeeShop
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var macchiato = CoffeeFactory.GetCoffee(CoffeeType.Macchiato);
            var regularCoffee = CoffeeFactory.GetCoffee(CoffeeType.Regular);
            Console.WriteLine($"Macchiato - Milk content: {macchiato.MilkContent} ml, Coffee content: {macchiato.CoffeeContent} ml");
            Console.WriteLine($"Regular coffee - Milk content: {regularCoffee.MilkContent} ml, Coffee content: {regularCoffee.CoffeeContent} ml");
        }
    }
}