using System;

class Program
{
    static void Main()
    {
        var a = int.Parse(Console.ReadLine());
        var b = int.Parse(Console.ReadLine());

        while (b!=0)
        {
            var oldB = b;
            b = a % b;
            a = oldB;
            
        }
        Console.WriteLine(a);
    }
}

