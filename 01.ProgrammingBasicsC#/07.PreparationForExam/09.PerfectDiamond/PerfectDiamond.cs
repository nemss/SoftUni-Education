using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        Console.WriteLine(new string(' ',n-1)+"*");
        for (int i = 1; i < n; i++)
        {
            Console.Write(new string(' ',n-1-i));
            for (int cow = 0; cow < i; cow++)
            {
                Console.Write("*-");
            }
            Console.Write("*");
            Console.WriteLine();
        }
        for (int i = n - 2; i > 0; i--)
        {
            Console.Write(new string(' ',n-i-1));
            for (int cow = 0; cow < i; cow++)
            {
                Console.Write("*-");
            }
            Console.Write("*");
            Console.WriteLine();
        }
        if (n != 1)
        {
            Console.WriteLine(new string(' ', n - 1) + "*");
        }
    }
}