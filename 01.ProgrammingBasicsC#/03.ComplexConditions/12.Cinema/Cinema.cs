using System;

class Program
{
    static void Main()
    {
        var projects = Console.ReadLine().ToLower();
        var redove = int.Parse(Console.ReadLine());
        var koloni = int.Parse(Console.ReadLine());
        double price = 0.0;

        if (projects=="premiere")
        {
            price = 12.00;
        }
        else if (projects=="normal")
        {
            price = 7.50;
        }
        else if (projects=="discount")
        {
            price = 5.00;
        }
        Console.WriteLine("{0:f2} leva", price * redove * koloni);
    }
}

