using System;

class PowersOfTwo
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var num = 1;

        for (int i = 0; i <= n; i++)
        {
            
            Console.WriteLine(num);
            num *= 2;

        }
    }
}

