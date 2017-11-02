using System;

class MetricConverter
{
    static void Main()
    {
        var number = double.Parse(Console.ReadLine());
        var input = Console.ReadLine().ToLower();
        var output = Console.ReadLine().ToLower();
        

        if (input=="km")
        {
            number = number / 0.001;
        }
        else if (input=="ft")
        {
            number = number / 3.2808399;
        }
        else if (input == "yd")
        {
            number = number / 1.0936133;
        }
        else if (input == "mm")
        {
            number = number / 1000;
        }
        else if (input == "cm")
        {
            number = number / 100;
        }
        else if (input == "mi")
        {
            number = number / 0.000621371192;
        }
        else if (input == "in")
        {
            number = number / 39.3700787;
        }

        if (output == "km")
        {
            number = number * 0.001;
        }
        else if (output == "ft")
        {
            number = number * 3.2808399;
        }
        else if (output == "yd")
        {
            number = number * 1.0936133;
        }
        else if (output == "mm")
        {
            number = number * 1000;
        }
        else if (output == "cm")
        {
            number = number * 100;
        }
        else if (output == "mi")
        {
            number = number * 0.000621371192;
        }
        else if (output == "in")
        {
            number = number * 39.3700787;
        }
        
        Console.WriteLine(number+" "+output);



    }
}

