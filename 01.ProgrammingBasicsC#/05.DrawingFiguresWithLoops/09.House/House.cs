using System;

class House
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var stars = 1;
        var padding= (n - stars) / 2;
        if (n % 2 == 0)
        {
            stars++;
        }
        for (int i = 0; i < (n + 1) / 2; i++)
        {
        Console.Write(new string('-', padding-i));
        Console.Write(new string('*', stars));
        Console.WriteLine(new string('-', padding-i));
        stars = stars + 2;
        }
        for (int i = 0; i < n/2; i++)
        {
            Console.Write("|"+new string('*', n-2)+"|");
            Console.WriteLine();
        }
    }
}

