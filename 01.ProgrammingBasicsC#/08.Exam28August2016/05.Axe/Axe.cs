using System;

class Axe
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var dashes = n * 3;
        var dashes2 = n - 1;
        Console.WriteLine("{0}**{1}", new string('-', n*3), new string('-', (n*2)-2));

        for (int i = 1; i < n; i++)
        {
            Console.WriteLine("{0}*{1}*{2}", new string('-', n * 3), new string('-', i), new string('-', (n * 2) - 2 - i));
        }
        for (int i = 0; i < n/2; i++)
        {
            Console.WriteLine("{0}*{1}*{1}", new string('*', n * 3), new string('-', n - 1));
        }
        for (int i = 0; i < n/2-1; i++)
        {
            Console.WriteLine("{0}*{1}*{2}", new string('-', dashes), new string('-', dashes2), new string('-', (n - 1)-i));
            dashes --;
            dashes2 += 2;
        }
        if (n%2==0)
        {
            Console.WriteLine("{0}*{1}*{2}", new string('-', dashes), new string('*', (n * 2)-3), new string('-', n / 2));
        }
        else
        {
            Console.WriteLine("{0}*{1}*{2}", new string('-', dashes ), new string('*', (n * 2)-4), new string('-', (n / 2)+1));
        }
    }
}

