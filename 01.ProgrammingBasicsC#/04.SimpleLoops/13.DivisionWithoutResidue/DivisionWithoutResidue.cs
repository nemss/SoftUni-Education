using System;

class DivisionWithoutResidue
{
    static void Main()
    {

        var n = int.Parse(Console.ReadLine());
        double p1 = 0.00;
        double p2 = 0.00;
        double p3 = 0.00;

        for (int i = 0; i < n; i++)
        {
            var number = int.Parse(Console.ReadLine());

            if (number % 2==0)
            {
                p1++;
            }
            if (number % 3==0)
            {
                p2++;
            }
            if (number % 4==0)
            {
                p3++;
            }
        }
        Console.WriteLine("{0:f2}%", p1/ n * 100);
        Console.WriteLine("{0:f2}%", p2/ n * 100);
        Console.WriteLine("{0:f2}%", p3/ n * 100);

    }  
}

