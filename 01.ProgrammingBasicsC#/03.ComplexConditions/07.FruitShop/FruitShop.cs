using System;

class Program
{
    static void Main()
    {
        var fruit = Console.ReadLine().ToLower();
        var day = Console.ReadLine().ToLower();
        var quantity = double.Parse(Console.ReadLine());


        if (day == "monday" || day == "tuesday" || day == "wednesday" || day == "thursday" || day == "friday")
        {
            if (fruit == "banana")
            {
                Console.WriteLine("{0:f2}", 2.50 * quantity);
            }
            else if (fruit == "apple")
            {
                Console.WriteLine("{0:f2}", 1.20 * quantity);
            }
            else if (fruit == "orange")
            {
                Console.WriteLine("{0:f2}", 0.85 * quantity);
            }
            else if (fruit == "grapefruit")
            {
                Console.WriteLine("{0:f2}", 1.45 * quantity);
            }
            else if (fruit == "kiwi")
            {
                Console.WriteLine("{0:f2}", 2.70 * quantity);
            }
            else if (fruit == "pineapple")
            {
                Console.WriteLine("{0:f2}", 5.50 * quantity);
            }
            else if (fruit == "grapes")
            {
                Console.WriteLine("{0:f2}", 3.85 * quantity);
            }
            else
            {
                Console.WriteLine("error");
            }
        }
        else if (day == "saturday" || day == "sunday")
        {
            if (fruit == "banana")
            {
                Console.WriteLine("{0:f2}", 2.70 * quantity);
            }
            else if (fruit == "apple")
            {
                Console.WriteLine("{0:f2}", 1.25 * quantity);
            }
            else if (fruit == "orange")
            {
                Console.WriteLine("{0:f2}", 0.90 * quantity);
            }
            else if (fruit == "grapefruit")
            {
                Console.WriteLine("{0:f2}", 1.60 * quantity);
            }
            else if (fruit == "kiwi")
            {
                Console.WriteLine("{0:f2}", 3.00 * quantity);
            }
            else if (fruit == "pineapple")
            {
                Console.WriteLine("{0:f2}", 5.60 * quantity);
            }
            else if (fruit == "grapes")
            {
                Console.WriteLine("{0:f2}", 4.20 * quantity);
            }
            else
            {
                Console.WriteLine("error");
            }
        }
        else
        {
            Console.WriteLine("error");
        }




    }
}
