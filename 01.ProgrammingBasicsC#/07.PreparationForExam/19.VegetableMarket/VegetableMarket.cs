using System;

class VegetableMarket
{
    static void Main()
    {
        var priceVegetable = double.Parse(Console.ReadLine());
        var priceFruit = double.Parse(Console.ReadLine());
        var allKiloVegetable = double.Parse(Console.ReadLine());
        var allKiloFruit = double.Parse(Console.ReadLine());

        var allVegetable = priceVegetable * allKiloVegetable;
        var allFruit = priceFruit * allKiloFruit;
        var allInMarket = allVegetable + allFruit;
        var sumInEuro = allInMarket / 1.94;

        Console.WriteLine(sumInEuro);
    }
}

