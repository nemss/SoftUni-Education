using System;

class Histogram
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var p1 = 0.0;
        var p2 = 0.0;
        var p3 = 0.0;
        var p4 = 0.0;
        var p5 = 0.0;
        for (int i = 0; i < n; i++)
        {
            var number = double.Parse(Console.ReadLine());
            if (number <200)
            {
                p1++;
            }
            else if (200<=number && number<=399)
            {
                p2++;
            }
            else if (400 <= number && number <= 599)
            {
                p3++;
            }
            else if (600 <= number && number <= 799)
            {
                p4++;
            }
            else if (800 <= number)
            {
                p5++;
            }           
        }
        Console.WriteLine("{0:f2}%", p1 / n * 100);
        Console.WriteLine("{0:f2}%", p2 / n * 100);
        Console.WriteLine("{0:f2}%", p3 / n * 100);
        Console.WriteLine("{0:f2}%", p4 / n * 100);
        Console.WriteLine("{0:f2}%", p5 / n * 100);
    }
}

