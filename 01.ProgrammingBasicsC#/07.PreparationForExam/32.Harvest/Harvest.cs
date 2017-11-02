using System;

class Harvest
{
    static void Main()
    {
        var vineYard = int.Parse(Console.ReadLine());
        var vine = double.Parse(Console.ReadLine());
        var wine = int.Parse(Console.ReadLine());
        var workers = int.Parse(Console.ReadLine());

        var allVine = vineYard * vine;
        var allWine = 0.4 * allVine / 2.5;

        if (allWine>=wine)
        {
            Console.WriteLine("Good harvest this year! Total wine: {0} liters.",Math.Floor(allWine));
            Console.WriteLine("{0} liters left -> {1} liters per person.", Math.Ceiling(allWine-wine), Math.Ceiling((allWine-wine)/workers));
        }
        else
        {
            Console.WriteLine("It will be a tough winter! More {0} liters wine needed.", Math.Floor(wine-allWine));
        }
    }
}

