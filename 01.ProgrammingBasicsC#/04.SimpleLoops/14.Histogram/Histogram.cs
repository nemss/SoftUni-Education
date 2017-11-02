using System;

class Histogram
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var p1 = 0.00;
        var p2 = 0.00;
        var p3 = 0.00;
        var p4 = 0.00;
        var p5 = 0.00;

        for (int i = 0; i < n; i++)
        {
            var number = int.Parse(Console.ReadLine());

            if (number<200)
            {
                p1++;
            }
            if (200<=number && number<400)
            {
                p2++;
            }
            if (400<=number && number<600)
            {
                p3++;
            }
            if (600<=number && number<800)
            {
                p4++;
            }
            if (800<=number)
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

