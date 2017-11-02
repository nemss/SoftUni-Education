using System;

class NumbersNTo1
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        for (int i = n; i >=1; i--)
        {
            Console.WriteLine(i);
        }
    }
}

