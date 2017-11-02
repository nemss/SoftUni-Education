using System;

class DivisionWithoutResidue
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var p1 = 0.0;
        var p2 = 0.0;
        var p3 = 0.0;
        for (int i = 1; i <= n; i++)
        {
            var number = int.Parse(Console.ReadLine());

            if (number % 2 == 0)
            {
                p1++;
            }
            if (number % 3 == 0)
            {
                p2++;
            }
            if (number % 4 == 0)
            {
                p3++;
            }
        }
        Console.WriteLine("{0:f2}%", p1 / n * 100);
        Console.WriteLine("{0:f2}%", p2 / n * 100);
        Console.WriteLine("{0:f2}%", p3 / n * 100);
    }
}

