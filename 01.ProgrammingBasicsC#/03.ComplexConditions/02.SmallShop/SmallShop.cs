using System;

class Program
{
    static void Main()
    {
        var product = Console.ReadLine().ToLower();
        var city = Console.ReadLine().ToLower();
        var quanty = double.Parse(Console.ReadLine());


        if (city=="sofia")
        {
            if (product=="coffee")
            {
                Console.WriteLine(0.50*quanty);
            }
            else if (product=="water")
            {
                Console.WriteLine(0.80 * quanty);
            }
            else if (product == "beer")
            {
                Console.WriteLine(1.20 * quanty);
            }
            else if (product == "sweets")
            {
                Console.WriteLine(1.45 * quanty);
            }
            else if (product == "peanuts")
            {
                Console.WriteLine(1.60 * quanty);
            }
        }
        if (city=="plovdiv")
        {
            if (product == "coffee")
            {
                Console.WriteLine(0.40 * quanty);
            }
            else if (product == "water")
            {
                Console.WriteLine(0.70* quanty);
            }
            else if (product == "beer")
            {
                Console.WriteLine(1.15 * quanty);
            }
            else if (product == "sweets")
            {
                Console.WriteLine(1.30* quanty);
            }
            else if (product == "peanuts")
            {
                Console.WriteLine(1.50* quanty);
            }
        }
        if (city=="varna")
        {
            if (product == "coffee")
            {
                Console.WriteLine(0.45* quanty);
            }
            else if (product =="water")
            {
                Console.WriteLine(0.70 * quanty);
            }
            else if (product == "beer")
            {
                Console.WriteLine(1.10 * quanty);
            }
            else if (product == "sweets")
            {
                Console.WriteLine(1.35 * quanty);
            }
            else if (product == "peanuts")
            {
                Console.WriteLine(1.55 * quanty);
            }
        }
    }
}

