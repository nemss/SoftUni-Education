using System;

class Volleyball
{
    static void Main()
    {
        string yearType = Console.ReadLine();
        int p = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());
        double overalPlays = h + (48 - h) * (3.0 / 4) + p * (2.0 / 3);

        if (yearType=="leap")
        {
            var leap = overalPlays + 0.15 * overalPlays;
            Console.WriteLine(Math.Floor(leap));
        }
        else if (yearType=="normal")
        {
            Console.WriteLine(Math.Floor(overalPlays));
        }
    }
}

